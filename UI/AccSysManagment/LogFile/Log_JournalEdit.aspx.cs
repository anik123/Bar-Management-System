using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABLL;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.AccSysManagment.LogFile
{
    public partial class Log_JournalEdit : System.Web.UI.Page
    {
        Log_AccJournalBLL BLL = new Log_AccJournalBLL();
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                txtFromDate.Text = System.DateTime.Now.ToShortDateString();
                txtTodate.Text = System.DateTime.Now.ToShortDateString();
                LoadLogFileDataInGv();
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

        private void LoadLogFileDataInGv()
        {

            var data = BLL.LoadLog_JournalUpdateData(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtTodate.Text));
            GridView1.DataSource = data;
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadLogFileDataInGv();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var data = BLL.LoadLog_JournalUpdateData(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtTodate.Text));
            GridView1.DataSource = data;
            GridView1.DataBind();
        }

        protected void BtncanCel_Click(object sender, EventArgs e)
        {
            txtFromDate.Text = System.DateTime.Now.ToShortDateString();
            txtTodate.Text = System.DateTime.Now.ToShortDateString();
            LoadLogFileDataInGv();
        }
    }
}