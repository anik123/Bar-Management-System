using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

using Microsoft.Reporting.WebForms;
using BLL.CompProfile;

namespace UI.BranchCollection.Report
{
    public partial class BankTranDtlRpt : System.Web.UI.Page
    { // collection item
        BranchProfileBLL BrBLL = new BranchProfileBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!IsPostBack)
            {
                Page.Title = "Bank Transection";
                LoadIncomeCollectionItem_Bank();
                string fromdate = Request.QueryString["fromdate"];
                string todate = Request.QueryString["todate"];
                string itemcolletionid = Request.QueryString["itemcolletionid"];

                if (fromdate != null)
                {
                    txtfromdate.Text = fromdate.ToString();
                }
                if (todate != null)
                {
                    txtTodate.Text = todate.ToString();
                }
                if (itemcolletionid != null)
                {
                    ddlBank_CollectionItem.SelectedValue = itemcolletionid.ToString();
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

            ReportParameter p3 = new ReportParameter("itemcolletionid");
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2,p3 });
            this.ReportViewer1.LocalReport.Refresh();
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtfromdate.Text = "";
            txtTodate.Text = "";
            ddlBank_CollectionItem.SelectedValue = "0";
            this.ReportViewer1.LocalReport.Refresh();
        }
        private void LoadIncomeCollectionItem_Bank()
        {
            var query = BrBLL.LoadBrProfileInfo(0,"","", "");
            ddlBank_CollectionItem.DataSource = query.OrderBy(Items => Items.BrProName);
            ddlBank_CollectionItem.DataTextField = "BrProName";
            ddlBank_CollectionItem.DataValueField = "BrProId";
            ddlBank_CollectionItem.DataBind();
            ddlBank_CollectionItem.Items.Insert(0, new ListItem("Select Collection Item", "0"));
        }
        
    }
}