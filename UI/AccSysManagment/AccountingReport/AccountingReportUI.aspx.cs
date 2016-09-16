using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PBLL.Page_ObjectBLL;
using ABLL;
using System.Web.Security;

namespace UI.AccSysManagment.AccountingReport
{
    public partial class AccountingReportUI : System.Web.UI.Page
    {
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                RoleName();
           
                Page.Title = "Accounting Report";
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
        protected void btnLastJournal_Click(object sender, EventArgs e)
        {
            string url= "~/AccSysManagment/AccountingReport/JournalRptUI.aspx";
            Response.Redirect(url);
        }

        protected void btnDateToDateJournal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/AccountingReport/JouranlDateToDateRptUI.aspx");
        }

        protected void btnTraialBalance_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/AccountingReport/TrialBalenceRptUI.aspx");
        }

        protected void btnliabilities_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/AccountingReport/LiabilitiesRptUI.aspx");
        }

        protected void btnChartofAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/AccountingReport/ChartofAccountRptUI.aspx");
        }

        protected void btnLedger_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/AccountingReport/LedgerRptUI.aspx");
        }

        protected void btnBalanceSheet_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/AccountingReport/BalanceSheetRptUI.aspx");
        }

        protected void btnIncomeStatement_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/AccountingReport/IncomeStatementRptUI.aspx");
        }

        protected void btnIncomeHardCode_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/AccountingReport/IncomeStatementHardCodeRptUI.aspx");
        }

        protected void btnExpense_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/AccountingReport/ExpenseRpt.aspx");
        }

        protected void btnCashFlow_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/AccountingReport/CashFlowRptUI.aspx");
        }

        protected void BtnTraialBalanceRptNew_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/AccountingReport/TrialBalanceRptUINew.aspx");
        }

        protected void btnLogJournalEdit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/LogFile/LogFileJouranlEditRpt.aspx");
        }

        protected void BtnPartyWiseLiabilities_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/PurchaseStatementUI.aspx");
        }

        protected void btnSalesIncomeReport_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Manager/SalesDetailsBranchWise.aspx");
        }


    }
}