using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DTO;
using PBLL.Page_ObjectBLL;
using ABLL;
using System.Web.Security;

namespace UI.Admin
{
    public partial class ProductUI : System.Web.UI.Page
    {
        CategoryBLL CBLL = new CategoryBLL();
        CategoryDTO CDTO = new CategoryDTO();

        UnitDTO UDTO = new UnitDTO();
        UnitBLL UBLL = new UnitBLL();

        ProductDTO PDTO = new ProductDTO();
        ProductBLL PBLL = new ProductBLL();

        CompanyBLL CompBLL = new CompanyBLL();
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try
            {
                if (!Page.IsPostBack)
                {
                    RoleName();
                    Page.Title = "Product";
                    pagingLoal();
                    LoadCategory();
                    LoadUnit();
                    loadCompany();

                }
            }
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }
        public void RoleName()
        {

            string empusername = HttpContext.Current.User.Identity.Name;

            var role = LBLL.GetRoleName_By_User(empusername);
            int roleid = role.First().RoleId;

            var loadPage = PObjRoleBLL.Page_ObjectRole(0, roleid, "", "");
            int count = loadPage.Count;

            int matcheddata = 0;
            for (int i = 0; i < count; i++)
            {
                if (HttpContext.Current.Request.Url.AbsolutePath == loadPage[i].PagePath.ToString())
                {
                    matcheddata = matcheddata + 1;
                }
            }
            if (matcheddata == 1)
            {
            }
            else
            {
                FormsAuthenticationTicket ticket1 = new FormsAuthenticationTicket("", true, 0);
                string hash1 = FormsAuthentication.Encrypt(ticket1);
                HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, hash1);
                cookie1.Expires = DateTime.Now.AddMinutes(0);

                if (ticket1.IsPersistent)
                    cookie1.Expires = ticket1.Expiration;

                Response.Cookies.Add(cookie1);
                Response.Redirect(" LoginUI.aspx");
            }
        }
        private void LoadCategory()
        {
            var query = CBLL.GetCategory(0, "");
            ddlCategory.DataSource = query.OrderBy(Items => Items.CategoryName);
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CatId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }
        private void LoadUnit()
        {
            /*
            var query = UBLL.GetUnit(0, "");
            ddlUnit.DataSource = query.OrderBy(Items => Items.UnitName);
            ddlUnit.DataTextField = "UnitName";
            ddlUnit.DataValueField = "UnitId";
            ddlUnit.DataBind();
             * 
             */
            //  ddlUnit.Items.Insert(0, new ListItem("Select Unit", "0"));
        }
        public static void Show(string message)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                message = message.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + message + "');", true);
            }
        }
        private void loadCompany()
        {
            var query = CompBLL.SearchComInfo(0, "", "", "");
            ddlCompany.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCompany.DataTextField = "CompName";
            ddlCompany.DataValueField = "CompId";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("Select Sub Category", "0"));
        }

        private void pagingLoal()
        {
            try
            {
                PagedDataSource objPds = new PagedDataSource();
                objPds.DataSource = PBLL.GetProduct(0, "", 0, 0, 0);
                objPds.AllowPaging = true;
                objPds.PageSize = 8;
                int CurPage;
                if (Request.QueryString["Page"] != null)
                    CurPage = Convert.ToInt32(Request.QueryString["Page"]);
                else
                    CurPage = 1;


                objPds.CurrentPageIndex = CurPage - 1;
                lblCurrentPage.Text = "Page: " + CurPage.ToString();

                if (!objPds.IsFirstPage)
                    lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath
                    + "?Page=" + Convert.ToString(CurPage - 1);

                if (!objPds.IsLastPage)
                    lnkNext.NavigateUrl = Request.CurrentExecutionFilePath
                    + "?Page=" + Convert.ToString(CurPage + 1);

                RptMainHead.DataSource = objPds;
                RptMainHead.DataBind();
            }
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                /*
                if (txtProductName.Text == "")
                {
                    txtProductName.Focus();
                    return;
                }
                 */
                //   PDTO.ProductName = txtProductName.Text.ToString();
                PDTO.ProductPurchasePrice = Convert.ToDouble(txtPurchasePrice.Text);
                PDTO.CategoryId = Convert.ToInt16(ddlCategory.SelectedValue);
                // PDTO.UnitId = Convert.ToInt16(ddlUnit.SelectedValue);
                PDTO.CompId = Convert.ToInt16(ddlCompany.SelectedValue);
                PDTO.CenterReorderValue = Convert.ToInt32(txtCenterReorderQuantity.Text);
                PDTO.CreateDate = System.DateTime.Now;
                PDTO.ProductSalePrice = Convert.ToDouble(txtSalePrice.Text);
                PDTO.ProductOffSalePrice = Convert.ToDouble(txtOffSale.Text);
                PDTO.CreateBy = HttpContext.Current.User.Identity.Name;
                PDTO.ProductReOrderStatus = 0;


                if (btnSave.Text == "Save")
                {
                    var checkCount = PBLL.CheckProductCodeExits(int.Parse(ddlCompany.SelectedValue), "", int.Parse(ddlCategory.SelectedValue));
                    if (checkCount.Count() > 0)
                    {
                        Show("Product already Exist in this company ");
                        return;
                    }
                    else
                    {
                        PBLL.Add(PDTO);
                        Show("Sucessfully Created!");
                        pagingLoal();
                        clearCntrol();
                        // barcode
                        /*
                          var data = PBLL.GetProduct(0, "", 0, 0, 0);
                          string productid = data.First().ProductId.ToString();
                          txtProductBarCode.Text = productid;
                          if (txtProductBarCode.Text != "")
                              ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "key", "launchModal();", true);
                         * */
                    }
                }
                else
                {
                    PDTO.ProductId = Convert.ToInt32(HFUID.Value);

                    //var checkUpCount = PBLL.CheckProductCodeExits(int.Parse(ddlCompany.SelectedValue), txtProductName.Text,int.Parse(HFUID.Value));

                    //if (checkUpCount.Count()> 0)
                    //{
                    //    Show("Product Code :" + txtProductName.Text + " already Used By Another Product in this company ");
                    //    return;
                    //}else{

                    PBLL.Edit(PDTO);
                    btnSave.Text = "Save";
                    Show("Sucessfully Updated!");
                    pagingLoal();
                    clearCntrol();
                    // barcode
                    // for barcode popup

                    /*
                    string Empid = Convert.ToString(HFUID.Value);
                    txtProductBarCode.Text = Empid;
                    if (txtProductBarCode.Text != "")
                        ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "key", "launchModal();", true);
                    
                     */
                    //}
                }
            }
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }


        private void clearCntrol()
        {
            //  txtProductName.Text = "";
            txtPurchasePrice.Text = "";
            ddlCategory.SelectedValue = "0";
            ddlCompany.SelectedValue = "0";
            txtSalePrice.Text = "";
            //ddlUnit.SelectedValue = "0";
            pagingLoal();
            txtCenterReorderQuantity.Text = "";
            btnSave.Text = "Save";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();

        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            var bb = PBLL.GetProduct(Convert.ToInt32(e.CommandArgument.ToString()), "", 0, 0, 0);
            HFUID.Value = bb.First().ProductId.ToString();
            //  txtProductName.Text = bb.First().ProductName.ToString();
            txtPurchasePrice.Text = bb.First().ProductPurchasePrice.ToString();
            // ddlUnit.SelectedValue = bb.First().UnitId.ToString();
            ddlCategory.SelectedValue = bb.First().CategoryId.ToString();
            ddlCompany.SelectedValue = bb.First().CompId.ToString();
            txtCenterReorderQuantity.Text = bb.First().CenterReorderValue.ToString();
            txtSalePrice.Text = bb.First().ProductSalePrice.ToString();
            txtOffSale.Text = bb.First().ProductOffSalePrice.ToString();
            btnSave.Text = "Update";
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var bb = PBLL.GetProduct(0, "", Convert.ToInt16(ddlCategory.SelectedValue), 0, Convert.ToInt16(ddlCompany.SelectedValue));
                RptMainHead.DataSource = bb;
                RptMainHead.DataBind();

            }
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }
    }
}