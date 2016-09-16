using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PBLL.Page_ObjectBLL;
using ABLL;
using System.Web.Security;

namespace UI.Manager
{
    public partial class CentralReportUI : System.Web.UI.Page
    {
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Central Report";
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

        protected void btnCentralStockStatus_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/Report/CentralStockStatus.aspx");
        }
        protected void BtnOperationSummary_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/Report/OpearationSummaryRptUI.aspx");
        }

        protected void btnSalesDtlBreanchWise_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/SalesDetailsBranchWise.aspx");

        }
        protected void btnExportLedger_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/PurchaseStatementUI.aspx");

        }
        protected void btnSalesDtailsRptPrint_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/Report/BranchWiseSalesRptUI.aspx");
        }

        protected void btnPurchaseSatement_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/PurchaseStatementUI.aspx");

        }

        protected void BtnRatingOfProduct_Click(object sender, EventArgs e)
        {

            Response.Redirect("/Shop/Report/RatingOfGoods_BranchWiseRptUI.aspx");
        }
        protected void btnAllPurchaseView_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/CentralAllPurchaseView.aspx");
        }

        protected void BtnAllCahallanView_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/CentralAllChallenViewUI.aspx");
        }
        protected void btnCentralReturnView_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/CentralToPartyReturnView.aspx");
        }

        protected void BtnBranchReorderLog_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/CentralToPartyReturnView.aspx");
        }

        protected void BtnSaleOperationSummary_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/Report/SaleOpearationSummaryRptUI.aspx");
        }

        protected void FinalBtnOperationSummary_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Manager/Report/FinalOpearationSummaryRptUI.aspx");
        }

        protected void btnCentralReturnRpt_Click(object sender, EventArgs e)
        {

            Response.Redirect("~/Manager/Report/CentralReturnRpt.aspx");
        }






    }
}