using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using ABLL;
using ADTO;

namespace UI.AccSysManagment.AccountingReport
{
    public partial class IncomeStatementRptUI : System.Web.UI.Page
    {
       
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = " Income Statement";
                string tax = Request.QueryString["tax"];
                if (tax != null)
                {
                    txtTaxAmount.Text = tax.ToString();
                }

            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

            if (txtTaxAmount.Text.ToString() == "")
            {
                txtTaxAmount.Focus();
                return;

            }
            else
            {
                Loaddata();
            }
        }
        public void Loaddata()
        {
            ReportViewer1.Visible = true;
            ReportParameter p1 = new ReportParameter("tax");

            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1 });
            this.ReportViewer1.LocalReport.Refresh();
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            this.ReportViewer1.LocalReport.Refresh();
            txtTaxAmount.Text = "37.5";
            Loaddata();
        }
    }
}