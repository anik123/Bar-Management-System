using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ABLL;
using PBLL.Page_ObjectBLL;
using DTO;
using System.Web.Security;

namespace UI.Manager
{
    public partial class StockReturnUI : System.Web.UI.Page
    {
        CategoryBLL CBLL = new CategoryBLL();
        UnitBLL UBLL = new UnitBLL();
        ProductBLL PBLL = new ProductBLL();
        CompanyBLL CompBLL = new CompanyBLL();
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();
        InvenCentralStoreStatusDTO SDTO = new InvenCentralStoreStatusDTO();
        InvenCentralStoreStatusBLL SBLL = new InvenCentralStoreStatusBLL();
        CocktailInfoBLL cockBLL = new CocktailInfoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            string strProcessScript = "this.value='Processing...';this.disabled=true;";
            btnSave.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnSave, "").ToString());
            if (!Page.IsPostBack)
            {
                LoadCategory();
                LoadSubCategory();
                LoadUnit();
                GetBranchId();
                RoleName();
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
        private void LoadSubCategory()
        {
            var query = PBLL.GetProduct_Categorywise(int.Parse(ddlCategory.SelectedValue), 0);
            ddlSubCategory.DataSource = query;
            ddlSubCategory.DataTextField = "CompName";
            ddlSubCategory.DataValueField = "ProductId";
            ddlSubCategory.DataBind();
            ddlSubCategory.Items.Insert(0, new ListItem("Select Sub Category", "0"));
        }
        private void LoadCategory()
        {
            var query = CBLL.GetCategory(0, "");
            ddlCategory.DataSource = query.OrderBy(Items => Items.CategoryName).Where(o => !o.CategoryName.ToLower().Contains("extra".ToString()));
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CatId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }
        private void LoadUnit()
        {
            var data = UBLL.GetUnit(0, "");
            ddlSize.DataSource = data.ToList().Distinct();
            ddlSize.DataTextField = "UnitName";
            ddlSize.DataValueField = "UnitName";
            ddlSize.DataBind();
            ddlSize.Items.Insert(0, new ListItem("Select Quantity", "0"));
        }
        private void clear()
        {
            ddlSize.SelectedIndex = 0;
            ddlCategory.SelectedIndex = 0;
            ddlSubCategory.SelectedIndex = 0;
        }
        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubCategory();
        }
        public void GetBranchId()
        {
            string empusername = HttpContext.Current.User.Identity.Name;
            var brid = empBLL.GetCurrentUserBranchName(empusername);

            HFBranceId.Value = brid.First().BrProId.ToString();
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
        protected void btnSave_Click(object sender, EventArgs e)
        {
            var Quantity = SBLL.LoadCentralStockStatus(int.Parse(ddlSubCategory.SelectedValue));
            //var reqprolist = PurOrBLL.GetPurchaseOrderInfo(Convert.ToInt32(row.Cells[3].Text), 0);

            if (Quantity.Count <= 0)
            {
                // HFCompId.Value = Quantity.First().CompId.ToString();
                SDTO.ProductId = int.Parse(ddlSubCategory.SelectedValue);
                SDTO.QuantityStore = Convert.ToDouble(ddlSize.SelectedValue.ToString());
                SDTO.BranchId = int.Parse(HFBranceId.Value);
                SDTO.DateStored = DateTime.Now.Date;
                SDTO.DateUpdated = DateTime.Now.Date;
                SDTO.QuantityLastPurchase = Convert.ToDouble(ddlSize.SelectedValue.ToString());
                SDTO.QuantityPurchase = Convert.ToDouble(ddlSize.SelectedValue.ToString());


                //  SDTO.CompanyId =reqprolist.First().CompId ;
                SBLL.Add(SDTO);




            }
            else
            {
                //  HFCompId.Value = Quantity.First().CompId.ToString();
                var cock = cockBLL.GetCocktail(Convert.ToInt32(ddlSubCategory.SelectedValue), 0);
                if (cock.Count > 0)
                {

                    for (int j = 0; j < cock.Count; j++)
                    {
                        var Quantity1 = SBLL.LoadCentralStockStatus(int.Parse(cock[j].ItemProId.ToString()));
                        SDTO.CentralStoreId = Quantity1.First().CentralStoreId;
                        SDTO.ProductId = Convert.ToInt32(cock[j].ItemProId.ToString());
                        SDTO.QuantityStore = Convert.ToDouble(Quantity1.First().QuantityStore + Convert.ToDouble(cock[j].Quantity));
                        SBLL.EditStoreQty(SDTO);

                    }
                }
                else
                {
                    SDTO.ProductId = int.Parse(ddlSubCategory.SelectedValue);
                    SDTO.CentralStoreId = Convert.ToInt32(Quantity.First().CentralStoreId);
                    // SDTO.BranchId = int.Parse(HFBranceId.Value);
                    //SDTO.CompanyId = reqprolist.First().CompId;
                    SDTO.BranchId = int.Parse(HFBranceId.Value);

                    SDTO.QuantityStore = Convert.ToDouble(Convert.ToDouble(ddlSize.SelectedValue.ToString()) + Quantity.First().QuantityStore);
                    SDTO.DateUpdated = DateTime.Now.Date;
                    SDTO.QuantityLastPurchase = Convert.ToDouble(ddlSize.SelectedValue);
                    if (Quantity.First().QuantityPurchase == null)
                    {
                        SDTO.DateStored = DateTime.Now.Date;
                        SDTO.QuantityPurchase = 0 + Convert.ToDouble(Convert.ToDouble(ddlSize.SelectedValue));
                    }
                    else
                    {
                        SDTO.QuantityPurchase = Quantity.First().QuantityPurchase + Convert.ToDouble(Convert.ToDouble(ddlSize.SelectedValue));
                    }
                    SBLL.Edit(SDTO);
                }
            }
            Show("Sucessfully Returned!");
            clear();

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clear();
        }
    }
}