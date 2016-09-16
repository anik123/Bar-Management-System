using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace UI.Manager
{
    public partial class CentralAllPurchaseView : System.Web.UI.Page
    {
        InvenCentralPurchseBLL PurBLL = new InvenCentralPurchseBLL();
        CompanyBLL CompBLL = new CompanyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                CompanyName();
                loadDataGVInfo();
            }

        }

        private void CompanyName()
        {
            var query = CompBLL.SearchComInfo(0, "", "", "");
            ddlcompany.DataSource = query.OrderBy(Items => Items.CompName);
            ddlcompany.DataTextField = "CompName";
            ddlcompany.DataValueField = "CompId";
            ddlcompany.DataBind();
            ddlcompany.Items.Insert(0, new ListItem("Select Company Name", "0"));
        }


        private void loadDataGVInfo()
        {
            var data = PurBLL.PurchaseStatementLaod(0, 0, "", "");
            GvDueInfo.DataSource = data;
            GvDueInfo.DataBind();

        }

        protected void GvDueInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDueInfo.PageIndex = e.NewPageIndex;
            loadDataGVInfo();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            Search();

        }

        protected void btnSearchCancel_Click(object sender, EventArgs e)
        {
            SearchClear();
        }
        public void SearchClear()
        {
            loadDataGVInfo();
            GvDueInfo.SelectedIndex = -1;
            ddlcompany.SelectedValue = "0";
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            txtPurchaseInvoiceNo.Text = "";
            GvDueInfo.SelectedIndex = -1;
        }

        protected void txtSearch(object sender, EventArgs e)
        {
            Search();

        }

        public static void Show(string message)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                message = message.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + message + "');", true);
            }

        }
        public void Search()
        {
            if (txtPurchaseInvoiceNo.Text == "" && ddlcompany.SelectedValue == "0" && txtDateTo.Text == "" && txtDateFrom.Text == "")
            {
                Show("Search By Valid Data");
                return;
            }
            else
            {
                int salid = 0;
                if (txtPurchaseInvoiceNo.Text.ToString() != "")
                {
                    salid = Convert.ToInt32(txtPurchaseInvoiceNo.Text);
                }
                else salid = 0;



                var data = PurBLL.PurchaseStatementLaod(salid, Convert.ToInt16(ddlcompany.SelectedValue), txtDateFrom.Text.ToString(), txtDateTo.Text.ToString());
                GvDueInfo.DataSource = data;
                GvDueInfo.DataBind();

                if (GvDueInfo.Rows.Count <= 0)
                    Show("No Data Found !");
                return;
            }
        }
        protected void LinkButton_Command_GvDueInfo_ViewDtl(object sender, CommandEventArgs e)
        {
            int purid;

            var bb = PurBLL.PurchaseStatementLaod(Convert.ToInt32(e.CommandArgument.ToString()), 0, "", "");
            purid = Convert.ToInt32(bb.First().PurId.ToString());
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Manager/PurchasePaymaentDetailViewUI.aspx?purid=" + purid.ToString() + "');", true);
        }
        protected void LinkButton_Command_GvDueInfo_ProductInfo(object sender, CommandEventArgs e)
        {
            var bb = PurBLL.PurchaseStatementLaod(Convert.ToInt32(e.CommandArgument.ToString()), 0, "", "");
            int PurId = bb.First().PurId;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Manager/Report/PurchaseProductRptUI.aspx?PurId=" + PurId.ToString() + "');", true);
        }

    }
}