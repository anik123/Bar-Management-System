using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.Manager
{
    public partial class CentralReportUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

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
            Response.Redirect("~/Manager/Report/RatingOfGoodsRptUI.aspx");
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

       
        



    }
}