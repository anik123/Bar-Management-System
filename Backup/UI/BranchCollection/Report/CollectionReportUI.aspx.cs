using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.BranchCollection.Report
{
    public partial class CollectionReportUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void BtnCurrentAsset_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BranchCollection/Report/CurrentAssetRptUI.aspx");

        }

        protected void btnCompanyCash_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BranchCollection/Report/CompanyCashEntryRptUI.aspx");
        }

        protected void BtnBankAmountIndividual_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BranchCollection/Report/BankAmountIndividualRptUI.aspx");
        }

        protected void btnBankTransection_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/BranchCollection/Report/BankTranDtlRpt.aspx");
        }
    }
}