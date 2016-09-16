using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.CompProfile;
using ABLL;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.Manager
{
    public partial class CentarlUnderStock : System.Web.UI.Page
    {
        CategoryBLL CBLL = new CategoryBLL();
        CompanyBLL compBLL = new CompanyBLL();
        InvenCentralStoreStatusBLL storBLL = new InvenCentralStoreStatusBLL();

        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Central Under Stock";
                LoadCategory();
                Company();
                LoadGvProductReorderInfo();

                if (GvUpdate.Rows.Count > 0)
                {
                    pnlAction.Visible = true;
                }
                else
                    pnlAction.Visible = false;
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
        // load branch
        private void Company()
        {
            var query = compBLL.SearchComInfo(0, "", "", "");
            ddlCompany.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCompany.DataTextField = "CompName";
            ddlCompany.DataValueField = "CompId";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("Select CompanyName", "0"));

        }

        private void LoadGvProductReorderInfo()
        {
            var ReOrder = storBLL.GetProduct(0, "", Convert.ToInt16(ddlCategory.SelectedValue), 0, Convert.ToInt16(ddlCompany.SelectedValue));
            GvUpdate.DataSource = ReOrder;
            GvUpdate.DataBind();
        }

        protected void GvUpdate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvUpdate.PageIndex = e.NewPageIndex;
            LoadGvProductReorderInfo();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            ddlCompany.SelectedValue = "0";
            ddlCategory.SelectedValue = "0";
            LoadGvProductReorderInfo();
        }
        protected void btnCreateReqisisiton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Manager/PurchaseRequisitionCentralUI.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnSearchCancel_Click(object sender, EventArgs e)
        {
            ddlCompany.SelectedValue = "0";
            ddlCategory.SelectedValue = "0";
            LoadGvProductReorderInfo();
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
        public void Search()
        {

            if (ddlCategory.SelectedValue == "0" && ddlCompany.SelectedValue == "0")
            {
                Show("Search By Valid Data");
            }
            else
            {

                var ReOrder = storBLL.GetProduct(0, "", Convert.ToInt16(ddlCategory.SelectedValue), 0, Convert.ToInt16(ddlCompany.SelectedValue));

                if (ReOrder.Count == 0)
                {
                    Show("No Data Found !");
                    return;
                }
                GvUpdate.DataSource = ReOrder;
                GvUpdate.DataBind();
            }
        }

    }
}