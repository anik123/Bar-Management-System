using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using BLL.CompProfile;
using ABLL;

namespace UI.Shop.Report
{
    public partial class BranchWiseSaleReportUI : System.Web.UI.Page
    {
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Branch Wise Sales Report";
                txtDateFrom.Text = System.DateTime.Now.ToShortDateString();
                txtTodate.Text = System.DateTime.Now.ToShortDateString();

                //int salid, int brid, string FromDate, string ToDate
                string salid = Request.QueryString["salid"];
                string brid = Request.QueryString["brid"];
                string FromDate = Request.QueryString["FromDate"];
                string ToDate = Request.QueryString["ToDate"];

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
        //public void GetBranchId()
        //{
        //    string empusername = HttpContext.Current.User.Identity.Name;
        //    var brid = empBLL.GetCurrentUserBranchName(empusername);

        //    HFBranceId.Value = brid.First().BrProId.ToString();
        //}
        public void Loaddata()
        {
            if (HFBranceId.Value != null)
            {
                ReportViewer1.Visible = true;

                ReportParameter p1 = new ReportParameter("salid");
                ReportParameter p2 = new ReportParameter("brid");
                ReportParameter p3 = new ReportParameter("FromDate");
                ReportParameter p4 = new ReportParameter("ToDate");


                this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });
                this.ReportViewer1.LocalReport.Refresh();
            }
        }

        //private void LoadBranch()
        //{
        //    var query = BrBLL.LoadBrProfileInfo(0, "", "", "");
        //    ddlBranchName.DataSource = query;
        //    ddlBranchName.DataTextField = "BrProName";
        //    ddlBranchName.DataValueField = "BrProId";
        //    ddlBranchName.DataBind();
        //    ddlBranchName.Items.Insert(0, new ListItem("Select One", "0"));
        //}


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            // ddlBranchName.SelectedValue = "0";
            txtTodate.Text = "";
            txtDateFrom.Text = "";
            this.ReportViewer1.LocalReport.Refresh();
        }
    }
}