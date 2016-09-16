using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace UI.Shop.Report
{
    public partial class BranchSalesRptUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string salid = Request.QueryString["salid"];
                if (salid != null)
                {
                    HFRptdtlId.Value = salid.ToString();
                }

                if (HFRptdtlId.Value != null)
                {
                    ReportViewer1.Visible = true;
                    ReportParameter p1 = new ReportParameter("salid");
                    this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
                    this.ReportViewer1.LocalReport.Refresh();
                }

            }

        }
    }
}