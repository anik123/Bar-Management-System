using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ABLL;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.Manager
{
    public partial class PurchasePaymaentDetailViewUI : System.Web.UI.Page
    {
        PurchaseDueBLL PayDueBLL = new PurchaseDueBLL();

        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
              //  RoleName();
                Page.Title = "Payment Details";
                string purid = Request.QueryString["purid"];
                int PurId;
                PurId = Convert.ToInt32(purid);
                loadDataGvDueInfo(PurId, 0, 0, "");
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
        private void loadDataGvDueInfo(int payid, int paymentdtlid, int Compid, string SalesManName)
        {
            var data = PayDueBLL.GetPyurchaseDueDtalil(payid, paymentdtlid, Compid, SalesManName);
            GvDueInfo.DataSource = data;
            GvDueInfo.DataBind();
        }

        protected void GvDueInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDueInfo.PageIndex = e.NewPageIndex;
            loadDataGvDueInfo(0, 0, 0, "");
        }

        protected void LinkButton_Command_GvDueInfo_ViewDtl(object sender, CommandEventArgs e)
        {
            string[] arg = new string[2];
            arg = e.CommandArgument.ToString().Split(';');

            string paydtlid = arg[0];
            string purid = arg[1];

            var bb = PayDueBLL.GetPyurchaseDueDtalil(Convert.ToInt32(purid), Convert.ToInt32(paydtlid), 0, "");
            int PurPayDtlId = bb.First().PurPayDtlId;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Manager/Report/CentralPurchasePaymentRptUI.aspx?PurPayDtlId=" + PurPayDtlId.ToString() + "');", true);
        }

        protected void LinkButton_Command_GvDueInfo_ProductInfo(object sender, CommandEventArgs e)
        {
            var bb = PayDueBLL.CentralPurchase_Due_Payment(Convert.ToInt32(e.CommandArgument.ToString()), 0, 0, "", "", "");
            int PurId = bb.First().PurId;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Manager/Report/PurchaseProductRptUI.aspx?PurId=" + PurId.ToString() + "');", true);
        }



    }
}