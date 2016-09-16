using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using BLL;
using PBLL.Page_ObjectBLL;
using ABLL;
using System.Web.Security;

namespace UI.Admin
{
    public partial class ProductUnitUI : System.Web.UI.Page
    {
        UnitBLL UBLL = new UnitBLL();
        UnitDTO UDTO = new UnitDTO();
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Product Unit";
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
            objPds.DataSource = UBLL.GetUnit(0, "");
            objPds.AllowPaging = true;
            objPds.PageSize = 6;
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
            if (txtProductUnitName.Text == "")
            {
                txtProductUnitName.Focus();
                return;
            }

            UDTO.UnitName = txtProductUnitName.Text.ToString();


            UDTO.CreateDate = System.DateTime.Now;
            UDTO.CreateBy = HttpContext.Current.User.Identity.Name;
            if (btnSave.Text == "Save")
            {
                UBLL.Add(UDTO);
                pagingLoal();
                clearCntrol();
            }
            else
            {
                UDTO.UnitId = Convert.ToInt32(HFUID.Value);
                UDTO.UpdateDate = System.DateTime.Now;
                UDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                UBLL.Edit(UDTO);
                btnSave.Text = "Save";
                pagingLoal();
                clearCntrol();
            }

        }

        //protected void RptMainHead_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    LinkButton btn = e.CommandSource as LinkButton;
        //    RepeaterItem item = btn.NamingContainer as RepeaterItem;
        //    Panel p = item.FindControl("Panel1") as Panel;
        //    p.BackColor = System.Drawing.Color.Red;
        //}
        private void clearCntrol()
        {
            txtProductUnitName.Text = "";
            pagingLoal();
            btnSave.Text = "Save";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();

        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            List<UnitDTO> bb = new List<UnitDTO>();

            bb = UBLL.GetUnit(Convert.ToInt32(e.CommandArgument.ToString()), "");
            HFUID.Value = bb.First().UnitId.ToString();
            txtProductUnitName.Text = bb.First().UnitName.ToString();
            btnSave.Text = "Update";
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var bb = UBLL.GetUnit(0, txtProductUnitName.Text.ToString());
                RptMainHead.DataSource = bb;
                RptMainHead.DataBind();

            }
            catch
            {

            }
        }

    }
}