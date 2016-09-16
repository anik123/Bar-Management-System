using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.CompProfile;
using Microsoft.Reporting.WebForms;
using Microsoft.Reporting.Common;

namespace UI.Shop.Report
{
    public partial class RatingOfGoods_BranchWiseRptUI : System.Web.UI.Page
    {
        CategoryBLL catbll = new CategoryBLL();

        DateTime FirstDayInMonth = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Branch Wise Rating Goods";
                LoadCategory();
                txtDateFrom.Text = FirstDayInMonth.ToShortDateString();
                txtTodate.Text = System.DateTime.Now.ToShortDateString();
                string catid = Request.QueryString["catid"];
                string brid = Request.QueryString["brid"];
                string FromDate = Request.QueryString["FromDate"];
                string ToDate = Request.QueryString["ToDate"];

                if (catid != null)
                {
                    ddlCategory.SelectedValue = catid.ToString();
                }
                if (brid != null)
                {
                    HFBranceId.Value = brid.ToString();
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
            if (HFBranceId.Value != null)
            {
                ReportViewer1.Visible = true;
                ReportParameter p1 = new ReportParameter("catid");
                ReportParameter p2 = new ReportParameter("brid");
                ReportParameter p3 = new ReportParameter("FromDate");
                ReportParameter p4 = new ReportParameter("ToDate");

                this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });
                this.ReportViewer1.LocalReport.Refresh();
                this.ReportViewer1.DocumentMapCollapsed = true;
                
                
            }
        }

        private void LoadCategory()
        {
            var query = catbll.GetCategory(0, "");
            ddlCategory.DataSource = query.OrderBy(Items => Items.CategoryName);
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CatId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

            ddlCategory.SelectedValue = "0";
            txtTodate.Text = System.DateTime.Now.ToShortDateString();
            txtDateFrom.Text = FirstDayInMonth.ToShortDateString();
            this.ReportViewer1.LocalReport.Refresh();
        }
    }
}