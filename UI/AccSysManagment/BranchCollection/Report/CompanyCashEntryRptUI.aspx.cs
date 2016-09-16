using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using System.Globalization;

namespace UI.BranchCollection.Report
{
    public partial class CompanyCashEntryRptUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "Company Cash Report";

                loadMonthName();
                GetYearInfo();
                string Year = Request.QueryString["year"];
                string Month = Request.QueryString["month"];
                if (Year != null)
                {
                    ddltrainingYear.Text = Year.ToString();
                    ddlMonthName.Text = Month.ToString();

                }


            }
        }

        public List<string> GetYearInfo()
        {
            List<string> list = new List<string>();
            int year = DateTime.Today.Year;
            int index = 0;
            while (index < 150)
            {
                this.ddltrainingYear.Items.Add(year.ToString());
                ddltrainingYear.DataBind();
                year--;
                if (year <= 0)
                {
                    year++;
                }
                index++;
            }
            return list;
        }

        private void loadMonthName()
        {


            string[] names = CultureInfo.CurrentCulture.DateTimeFormat.MonthNames;
            ddlMonthName.DataSource = names;
            ddlMonthName.DataBind();
            ddlMonthName.Items.Insert(0, "");

        }

        protected void btnChearch_Click(object sender, EventArgs e)
        {
            ReportViewer1.Visible = true;


            ReportParameter p1 = new ReportParameter("month");
            ReportParameter p2 = new ReportParameter("year");

            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
            this.ReportViewer1.LocalReport.Refresh();

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

            loadMonthName();
            ddltrainingYear.SelectedValue = System.DateTime.Now.Year.ToString();
            this.ReportViewer1.LocalReport.Refresh();
        }
    }
}