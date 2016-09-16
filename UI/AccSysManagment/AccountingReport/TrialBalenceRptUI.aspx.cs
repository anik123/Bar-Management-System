using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace UI.AccSysManagment.AccountingReport
{
    public partial class TrialBalenceRptUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "Trail Balance";
                string fromdate = Request.QueryString["fromdate"];
                string todate = Request.QueryString["todate"];

                if (fromdate != null)
                {
                    txtfromdate.Text = fromdate.ToString();
                }
                if (todate != null)
                {
                    txtTodate.Text = todate.ToString();
                }
                Loaddata();
            }

        }



        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Loaddata();

        }
        public void Loaddata()
        {
            ReportViewer1.Visible = true;

            ReportParameter p1 = new ReportParameter("fromdate");
            ReportParameter p2 = new ReportParameter("todate");


            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
            this.ReportViewer1.LocalReport.Refresh();
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtfromdate.Text = "";
            txtTodate.Text = "";
            this.ReportViewer1.LocalReport.Refresh();
        }
    }
}