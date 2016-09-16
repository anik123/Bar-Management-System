using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace UI.AccountingReport
{
    public partial class JournalUpdateRptUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                string Rptid = Request.QueryString["TransectionNo"];



                if (Rptid != null)
                {
                    HFID.Value = Rptid.ToString();
                    //  ddltrainingYear.Text = Year.ToString();
                }



                if (HFID.Value != null)
                {
                    ReportViewer1.Visible = true;

                    ReportParameter p1 = new ReportParameter("TransectionNo");

                    this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
                    this.ReportViewer1.LocalReport.Refresh();
                }


            }
        }
    }
}