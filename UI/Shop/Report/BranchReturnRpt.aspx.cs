using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace UI.Shop.Report
{
    public partial class BranchReturnRpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Branch Return Report";
                Loaddata();
            }
        }


        public void Loaddata()
        {
            if (HFBranceId.Value != null)
            {
                ReportViewer1.Visible = true;

                //ReportParameter p1 = new ReportParameter("salid");
                //ReportParameter p2 = new ReportParameter("brid");
                //ReportParameter p3 = new ReportParameter("FromDate");
                //ReportParameter p4 = new ReportParameter("ToDate");


                //this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });

                ReportViewer1.DocumentMapCollapsed = true;
                Branch xsd = new Branch();
                xsd.EnforceConstraints = false;
                xsd.BeginInit();

                ReportDataSource rptdataSource1 = new ReportDataSource();
                ReportViewer1.LocalReport.DataSources.Add(rptdataSource1);
                rptdataSource1.Name = "DataSet1";
                rptdataSource1.Value = xsd.BranchReturnProduct;

                xsd.EndInit();
                BranchTableAdapters.BranchReturnProductTableAdapter storeAdp = new BranchTableAdapters.BranchReturnProductTableAdapter();
                // xsd.BranchSalesDetails.Clear();

                storeAdp.FillByReturnProduct(xsd.BranchReturnProduct);
                storeAdp.ClearBeforeFill = true;
                this.ReportViewer1.LocalReport.Refresh();
            }
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

    }
}