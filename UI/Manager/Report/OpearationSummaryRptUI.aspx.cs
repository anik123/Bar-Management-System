using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Microsoft.Reporting.WebForms;

namespace UI.Manager.Report
{
    public partial class OpearationSummaryRptUI : System.Web.UI.Page
    {
        CompanyBLL CompBLL = new CompanyBLL();
        CategoryBLL catbll = new CategoryBLL();

        DateTime FirstDayInMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Operation Summary";
                LoadBranch();
                LoadCategory();
                txtDateFrom.Text = FirstDayInMonth.ToShortDateString();
                txtTodate.Text = System.DateTime.Now.ToShortDateString();

                //int salid, int brid, string FromDate, string ToDate
                string catid = Request.QueryString["catid"];
                string compid = Request.QueryString["compid"];
                string FromDate = Request.QueryString["FromDate"];
                string ToDate = Request.QueryString["ToDate"];

                if (catid != null)
                {
                    ddlCategory.SelectedValue = catid.ToString();
                }
                if (compid != null)
                {
                    ddlCompName.SelectedValue = compid.ToString();
                }
                if (FromDate != null)
                {
                    txtDateFrom.Text = FromDate.ToString();
                }
                if (ToDate != null)
                {
                    txtTodate.Text = txtTodate.ToString();
                }

                Loaddata();
            }
        }

        public void Loaddata()
        {
            ReportViewer1.Visible = true;


            ReportParameter p1 = new ReportParameter("compid");
            ReportParameter p2 = new ReportParameter("catid");
            ReportParameter p3 = new ReportParameter("FromDate");
            ReportParameter p4 = new ReportParameter("ToDate");


            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });
            this.ReportViewer1.LocalReport.Refresh();
        }

        private void LoadBranch()
        {
            var query = CompBLL.SearchComInfo(0, "", "", "");
            ddlCompName.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCompName.DataTextField = "CompName";
            ddlCompName.DataValueField = "CompId";
            ddlCompName.DataBind();
            ddlCompName.Items.Insert(0, new ListItem("Select Party", "0"));
        }
        private void LoadCategory()
        {
            var query = catbll.GetCategory(0, "");
            ddlCategory.DataSource = query.OrderBy(Items => Items.CategoryName);
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CatId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Product", "0"));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlCompName.SelectedValue = "0";
            ddlCategory.SelectedValue = "0";
            txtTodate.Text = System.DateTime.Now.ToShortDateString();
            txtDateFrom.Text = FirstDayInMonth.ToShortDateString();
            this.ReportViewer1.LocalReport.Refresh();
        }
    }
}