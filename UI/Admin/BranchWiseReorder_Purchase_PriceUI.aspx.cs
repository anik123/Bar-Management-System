using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DTO;
using BLL.CompProfile;
using PBLL.Page_ObjectBLL;
using ABLL;
using System.Web.Security;

namespace UI.Admin
{
    public partial class BranchWiseReorder_Purchase_PriceUI : System.Web.UI.Page
    {
        // for log file
        Log_InventoryBLL LogBLL = new Log_InventoryBLL();
        LogInvenReorderDTO LogDTO = new LogInvenReorderDTO();


        CompanyBLL compBLL = new CompanyBLL();
        CategoryBLL CBLL = new CategoryBLL();
        InvenReorderBLL RBLL = new InvenReorderBLL();
        // branch load
        BranchProfileBLL BrPrBLL = new BranchProfileBLL();
        InvenReorderDto RDTO = new InvenReorderDto();
        ProductBLL PBLL = new ProductBLL();
        ProductDTO PDTO = new ProductDTO();
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Branch Wise Reorder";
                LoadCategory();
                CompanyBranch();
                Company_productEntryPnl();
                
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
            ddlCategory.DataSource = query;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CatId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }
        // load branch
        private void CompanyBranch()
        {

            var query = BrPrBLL.LoadBrProfileInfo(0, "", "", "");
            ddlBranch.DataSource = query;
            ddlBranch.DataTextField = "BrProName";
            ddlBranch.DataValueField = "BrProId";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("Select Branch", "0"));

        }
        /*Start Javascript Popup ALert*/
        public static void Show(string message)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                message = message.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + message + "');", true);
            }
        }

        public void LoadProductGridView()
        {

            if (RbtTriningInfo.SelectedItem.ToString() == "New Entry")
            {
                var pp = PBLL.GetProductForReOrder(0, "", Convert.ToInt16(ddlCategory.SelectedValue), 0, int.Parse(ddlCName.SelectedValue)); //Convert.ToInt16(ddlCategory.SelectedValue), Convert.ToInt16(ddlBranch.SelectedValue));
                if (pp.Count != 0)
                {
                    PnlAction.Visible = true;
                }
                else
                {
                    PnlAction.Visible = false;
                    Show("No New Data Reorder Record");
                }
                GvUpdate.DataSource = pp;
                GvUpdate.DataBind();
            }
            else
            {
                if (ddlBranch.SelectedValue == "0")
                {
                    Show("Plz Selcct Brach For Search");
                    return;
                }
                var pp = RBLL.GetReorderInfo_UpdateProductInfo(0, Convert.ToInt16(ddlCategory.SelectedValue), Convert.ToInt16(ddlBranch.SelectedValue), int.Parse(ddlCName.SelectedValue), 0);
                if (pp.Count != 0)
                {
                    PnlAction.Visible = true;
                }
                else
                {
                    PnlAction.Visible = false;
                    Show(" No Data Found !");
                }
                GvUpdate.DataSource = pp;
                GvUpdate.DataBind();
            }
        }

        protected void GvUpdate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvUpdate.PageIndex = e.NewPageIndex;
            LoadProductGridView();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlBranch.SelectedValue == "0")
            {
                Show("Plz Select Branch");
                return;
            }
            //int blankcount = 0;
            //foreach (GridViewRow row in GvUpdate.Rows)
            //{

            //    TextBox txt = (TextBox)row.FindControl("txtReorderValue");
            //    string data = txt.Text;

            //    if (data == "")
            //    {
            //        blankcount = blankcount + 1;

            //    }
            //}

            //if (blankcount > 0)
            //{
            //    Show(" Plz Insert Reorder Quantity");
            //    return;
            //}

            else
            {
                foreach (GridViewRow row in GvUpdate.Rows)
                {
                    TextBox txtreorder = (TextBox)row.FindControl("txtReorderValue");
                    //TextBox txtRate = (TextBox)row.FindControl("txtRateOfInterest");
                   // TextBox txtSalePrice = (TextBox)row.FindControl("txtSalePrice");

                    if (txtreorder.Text != "")
                    {
                        RDTO.ProductId = Convert.ToInt32(row.Cells[1].Text);
                        RDTO.BrProId = Convert.ToInt16(ddlBranch.SelectedValue);
                        RDTO.ReorderValue = Convert.ToInt16(txtreorder.Text);
                        RDTO.PurRequisitonStatus = "0";
                        
                        PDTO.ProductReOrderStatus = 1;
                        PDTO.ProductId = Convert.ToInt32(row.Cells[1].Text);

                        if (btnSave.Text == "Save")
                        {
                            try
                            {
                                RDTO.Createdate = System.DateTime.Now;
                                RDTO.CreateBy = HttpContext.Current.User.Identity.Name;

                                RBLL.Add(RDTO);

                                PBLL.EditStatus(PDTO);
                            }
                            catch
                            {
                            }

                        }
                        else
                        {
                            if (txtreorder.Text != "")
                            {
                                // start log insert
                                string Logfield = "";
                                var pp = RBLL.GetReorderInfo_UpdateProductInfo(0, Convert.ToInt16(ddlCategory.SelectedValue), Convert.ToInt16(ddlBranch.SelectedValue), 0, 0);
                                Logfield = "ReorderId-" + row.Cells[8].Text + ";" + "Branch-" + pp.First().BrProName + ";" + "Product-" + pp.First().ProductName.ToString() + ";" + " Reorder Value-" + pp.First().ReorderValue.ToString() + "#" + txtreorder.Text + ";";
                                LogDTO.LogField = Logfield;
                                LogDTO.LogBy = HttpContext.Current.User.Identity.Name;
                                LogDTO.LogDate = System.DateTime.Now;
                                LogBLL.Add_Reorder_BranchWise_Log(LogDTO);
                                // end log insert
                                // if (row.Cells[8].Text!="")
                                RDTO.ReorderId = Convert.ToInt32(row.Cells[8].Text);
                                RDTO.UpdateDate = System.DateTime.Now;
                                RDTO.UpdateBy = HttpContext.Current.User.Identity.Name;



                                RBLL.Edit(RDTO);
                                // Show("Data Update Successfully ");
                                // return;
                            }
                        }

                       
                                     
                    }


                   
                    
                }


            }
            ClearControl();
            Show(" Save Successfully ");
            return;
        }
        protected void RbtTriningInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RbtTriningInfo.SelectedItem.ToString() == "Update ")
            {
                btnSave.Text = "Update";
            }
            else
            {

                btnSave.Text = "Save";
                ClearControl();
            }

        }
        public void ClearControl()
        {
            btnSave.Text = "Save";
            ddlBranch.SelectedValue = "0";
            ddlCategory.SelectedValue = "0";
            PnlGridView.Visible = false;
            PnlAction.Visible = false;
            
            RbtTriningInfo.SelectedValue = "New Entry";
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PnlGridView.Visible = true;
            LoadProductGridView();
            
        }

        private void Company_productEntryPnl()
        {

            var query = compBLL.SearchComInfo(0, "", "", "");
            ddlCName.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCName.DataTextField = "CompName";
            ddlCName.DataValueField = "CompId";
            ddlCName.DataBind();
            ddlCName.Items.Insert(0, new ListItem("Select Company", "0"));

        }
        protected void btnSearchCancel_Click(object sender, EventArgs e)
        {
            ddlBranch.SelectedValue = "0";
            ddlCategory.SelectedValue = "0";
            PnlAction.Visible = false;
            RbtTriningInfo.SelectedValue = "New Entry";
            PnlGridView.Visible = false;
        }
    }
}