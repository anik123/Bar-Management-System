using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using BLL;

namespace UI.Manager.Report
{
    public partial class CentralPurchaseOrderRptUI : System.Web.UI.Page
    {
        ReportBLL pp = new ReportBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "Central Pur order Report";
                string purorderno = Request.QueryString["purorderno"];

                var pp1 = pp.PurchaseOrderRpt(Convert.ToInt16( purorderno));
                int p = pp1.First().PurorderNo;
                if (purorderno != null)
                {
                    HFRptdtlId.Value = purorderno.ToString();
                }

                if (HFRptdtlId.Value != null)
                {
                    ReportViewer1.Visible = true;
                    ReportParameter p1 = new ReportParameter("purorderno");
                    this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
                    this.ReportViewer1.LocalReport.Refresh();
                }
            }
        }
    }
}