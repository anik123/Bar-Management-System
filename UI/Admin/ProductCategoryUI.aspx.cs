using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DTO;
using ABLL;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.Admin
{
    public partial class ProductCategoryUI : System.Web.UI.Page
    {
        CategoryBLL CBLL = new CategoryBLL();
        CategoryDTO CDTO = new CategoryDTO();

        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Product Category";
                pagingLoal();

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
        private void pagingLoal()
        {

            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = CBLL.GetCategory(0, "");
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

        protected void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (txtCategoryName.Text == "")
                {
                    txtCategoryName.Focus();
                    return;
                }

                CDTO.CategoryName = txtCategoryName.Text.ToString();


                CDTO.CreateDate = System.DateTime.Now;
                CDTO.CreateBy = HttpContext.Current.User.Identity.Name;
                if (btnSave.Text == "Save")
                {
                    CBLL.Add(CDTO);
                    pagingLoal();
                    clearCntrol();
                }
                else
                {
                    CDTO.CatId = Convert.ToInt32(HFUID.Value);
                    CDTO.UpdateDate = System.DateTime.Now;
                    CDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                    CBLL.Edit(CDTO);
                    btnSave.Text = "Save";
                    pagingLoal();
                    clearCntrol();
                }
            }
            catch (Exception ex)
            {
                Show(ex.Message);
            }
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
        private void clearCntrol()
        {
            txtCategoryName.Text = "";
            pagingLoal();
            btnSave.Text = "Save";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();

        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            List<CategoryDTO> bb = new List<CategoryDTO>();
            bb = CBLL.GetCategory(Convert.ToInt32(e.CommandArgument.ToString()), "");
            HFUID.Value = bb.First().CatId.ToString();
            txtCategoryName.Text = bb.First().CategoryName.ToString();
            btnSave.Text = "Update";
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var bb = CBLL.GetCategory(0, txtCategoryName.Text.ToString());
                RptMainHead.DataSource = bb;
                RptMainHead.DataBind();

            }
            catch
            {

            }
        }
    }
}