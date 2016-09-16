using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Web.Security;
using PBLL.Page_ObjectBLL;
using ABLL;

namespace UI.ReportSetUpFile
{
    public partial class ReportSetUpFileUI : System.Web.UI.Page
    {
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               // RoleName();
                Page.Title = "Company Report";
            }

        }

        //public void RoleName()
        //{

        //    string empusername = HttpContext.Current.User.Identity.Name;

        //    var role = LBLL.GetRoleName_By_User(empusername);
        //    int roleid = role.First().RoleId;

        //    var loadPage = PObjRoleBLL.Page_ObjectRole(0, roleid, "", "");
        //    int count = loadPage.Count;

        //    int matcheddata = 0;
        //    for (int i = 0; i < count; i++)
        //    {
        //        if (HttpContext.Current.Request.Url.AbsolutePath == loadPage[i].PagePath.ToString())
        //        {
        //            matcheddata = matcheddata + 1;
        //        }
        //    }
        //    if (matcheddata == 1)
        //    {
        //    }
        //    else
        //    {
        //        FormsAuthenticationTicket ticket1 = new FormsAuthenticationTicket("", true, 0);
        //        string hash1 = FormsAuthentication.Encrypt(ticket1);
        //        HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, hash1);
        //        cookie1.Expires = DateTime.Now.AddMinutes(0);

        //        if (ticket1.IsPersistent)
        //            cookie1.Expires = ticket1.Expiration;

        //        Response.Cookies.Add(cookie1);
        //        Response.Redirect(" LoginUI.aspx");
        //    }
        //}


        protected void btnBankAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportSetUpFile/BankAccountInfoRptUI.aspx");
        }

        protected void btnBranchList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportSetUpFile/CompanyBranchListRptUI.aspx");
        }

        protected void btnClientCompanyList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportSetUpFile/ClientCompanyListRptUI.aspx");
        }

        protected void btnProductList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportSetUpFile/ProductListRptUI.aspx");

        }
    }
}