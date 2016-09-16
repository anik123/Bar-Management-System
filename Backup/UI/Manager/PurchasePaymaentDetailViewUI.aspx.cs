using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace UI.Manager
{
    public partial class PurchasePaymaentDetailViewUI : System.Web.UI.Page
    {
        PurchaseDueBLL PayDueBLL = new PurchaseDueBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                string purid = Request.QueryString["purid"];
                int PurId;
                PurId = Convert.ToInt32(purid);
                loadDataGvDueInfo(PurId, 0, 0, "");
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