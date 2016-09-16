using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.AccSysManagment.SetupFile
{
    public partial class ReportSetUpFile : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
        }

        protected void btnCashFlowSetup_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/Report Setup File/CashFlowEntityUI.aspx");

        }

        protected void btnBalanceSheetRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/Report Setup File/BalanceSheetRptUI.aspx");
        }

        protected void btnIncomeStatementRpt_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/Report Setup File/IncomeStatementRptUI.aspx");
        }

        protected void btnLiabilities_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/Report Setup File/LiabilitiesRptSetupUI.aspx");
        }

        protected void btnTransectionItemSetup_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/AccSysManagment/Report Setup File/Transaction.aspx");
        }
    }
}