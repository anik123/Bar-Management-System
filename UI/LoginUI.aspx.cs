using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADTO;
using System.Configuration;
using System.Web.Security;
using System.Text;
using ABLL;


namespace AUI
{
    public partial class LoginUI : System.Web.UI.Page
    {

        LoginBLL LBLL = new LoginBLL();

        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnlogin_Click(object sender, EventArgs e)
        {

            List<UserRoleDTO> DTOL = new List<UserRoleDTO>();
            List<EmpBasicInfoDTO> DTOU = new List<EmpBasicInfoDTO>();
            DTOU = LBLL.LogInTest(txtUserName.Text.ToString(), txtPassword.Text.ToString());

            if (DTOU.Count > 0)
            {
                double EXPIRETIMELIMIT = Convert.ToDouble(ConfigurationManager.AppSettings["EXPIRETIMELIMIT"]);

                FormsAuthentication.Initialize();
                FormsAuthentication.HashPasswordForStoringInConfigFile(txtPassword.Text.ToString(), "md5");

                StringBuilder roles = new StringBuilder();
                /* bellow i have added 2 roles , you may add roles according to your logic.*/
                DTOL = LBLL.GetRolebyUser(txtUserName.Text.ToString(), txtPassword.Text.ToString());

                for (int i = 0; i < DTOL.Count; i++)
                {
                    roles.Append(DTOL[i].RoleName.ToString());
                    //roles.Append("Admin");
                    //roles.Append("Manager");
                }

              //  FormsAuthenticationTicket t= new FormsAuthenticationTicket(
                FormsAuthenticationTicket ticket = new FormsAuthenticationTicket(1, txtUserName.Text.ToString(), DateTime.Now, DateTime.Now.AddMinutes(EXPIRETIMELIMIT), true, roles.ToString(), FormsAuthentication.FormsCookiePath);

                string hash = FormsAuthentication.Encrypt(ticket);
                HttpCookie cookie = new HttpCookie(FormsAuthentication.FormsCookieName, hash);
                /*We have to set the cookie expire time manually,its not working which we set in the parameter  of the FormsAuthenticationTicket's constructor .*/
                cookie.Expires = DateTime.Now.AddMinutes(EXPIRETIMELIMIT);

                if (ticket.IsPersistent)
                    cookie.Expires = ticket.Expiration;

                Response.Cookies.Add(cookie);
                Response.Redirect("LogSuccessPage.aspx");

            }
            else
            {

            }

            
        }
    }
}

