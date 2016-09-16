using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.CompProfile;
using BLL;
using Microsoft.Reporting.WebForms;

namespace UI.ReportSetUpFile
{
    public partial class BankAccountInfoRptUI : System.Web.UI.Page
    {
        BranchProfileBLL BrBLL = new BranchProfileBLL();
        BankInfoBLL BBLL = new BankInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadBank();
                LoadBranch();

                string branchid = Request.QueryString["branchid"];
                string BankID = Request.QueryString["BankID"];
                string accname = Request.QueryString["accname"];
                string accnum = Request.QueryString["accnum"];

                if (branchid != null)
                {
                    ddlBranchName.SelectedValue = branchid.ToString();
                }
                if (BankID != null)
                {
                    ddlBankName.SelectedValue = BankID.ToString();
                }

                Loaddata();
            }
        }

        public void Loaddata()
        {
            ReportViewer1.Visible = true;

            ReportParameter p1 = new ReportParameter("branchid");
            ReportParameter p2 = new ReportParameter("BankID");
            ReportParameter p3 = new ReportParameter("accname");
            ReportParameter p4 = new ReportParameter("accnum");


            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });
            this.ReportViewer1.LocalReport.Refresh();
        }
        private void LoadBank()
        {
            var query = BBLL.LoadBankName(0);
            ddlBankName.DataSource = query;
            ddlBankName.DataTextField = "BankName";
            ddlBankName.DataValueField = "BankId";
            ddlBankName.DataBind();
            ddlBankName.Items.Insert(0, new ListItem("Select Bank", "0"));
        }
        private void LoadBranch()
        {
            var query = BrBLL.LoadBrProfileInfo(0, "", "", "");
            ddlBranchName.DataSource = query;
            ddlBranchName.DataTextField = "BrProName";
            ddlBranchName.DataValueField = "BrProId";
            ddlBranchName.DataBind();
            ddlBranchName.Items.Insert(0, new ListItem("Select One", "0"));
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlBranchName.SelectedValue = "0";
            ddlBankName.SelectedValue = "0";
            this.ReportViewer1.LocalReport.Refresh();
        }
    }
}