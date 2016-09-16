using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.AccSysManagment.AccountingReport
{
    public partial class AccountingReportUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnLastJournal_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/AccountingReport/JournalRptUI.aspx");
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


    }
}