using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PBLL;
using Microsoft.Reporting.WebForms;
using BLL;

namespace UI.BranchCollection.Report
{
    public partial class BankAmountIndividualRptUI : System.Web.UI.Page
    {
        BankInfoBLL TBLL = new BankInfoBLL();
        BankAccountInfoBLL ABLL = new BankAccountInfoBLL();
        private void GetAccountType()
        {
            var query = ABLL.LoadAccountType();
            ddlAccountType.DataSource = query;
            ddlAccountType.DataTextField = "AccountTypeName";
            ddlAccountType.DataValueField = "AccountTypeId";
            ddlAccountType.DataBind();
            ddlAccountType.Items.Insert(0, new ListItem("Select AccountType", "0"));
        }
        private void GetBankName()
        {
            var query = TBLL.LoadBankName(0);
            ddlBankName.DataSource = query;
            ddlBankName.DataTextField = "BankName";
            ddlBankName.DataValueField = "BankId";
            ddlBankName.DataBind();
            ddlBankName.Items.Insert(0, new ListItem("Select Bank Name", "0"));

        }
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Individual Bank Amount"; 
                GetAccountType();
                GetBankName();
                string bankid = Request.QueryString["bankid"];
                string accounttypeid = Request.QueryString["accounttypeid"];

                if (bankid != null)
                {
                    ddlBankName.SelectedValue = bankid.ToString();
                }
                if (accounttypeid != null)
                {
                    ddlAccountType.Text = accounttypeid.ToString();
                }
                LoadRept();
            }
        }
        protected void btnChearch_Click(object sender, EventArgs e)
        {
            LoadRept();
        }

        public void LoadRept()
        {
            ReportViewer1.Visible = true;
            ReportParameter p1 = new ReportParameter("bankid");
            ReportParameter p2 = new ReportParameter("accounttypeid");

            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2 });
            this.ReportViewer1.LocalReport.Refresh();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlAccountType.SelectedValue = "0";
            ddlBankName.SelectedValue = "0";
            LoadRept();
            this.ReportViewer1.LocalReport.Refresh();

        }


    }
}