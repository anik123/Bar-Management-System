using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;

namespace UI.Shop.Report
{
    public partial class CentralReturnRpt : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Loaddata();
            }
        }


        private void Loaddata()
        {
            
                ReportViewer1.Visible = true;

                //ReportParameter p1 = new ReportParameter("salid");
                //ReportParameter p2 = new ReportParameter("brid");
                //ReportParameter p3 = new ReportParameter("FromDate");
                //ReportParameter p4 = new ReportParameter("ToDate");


                //this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });

                ReportViewer1.DocumentMapCollapsed = true;
                Central xsdDataSet=new Central();
                xsdDataSet.EnforceConstraints = false;
                xsdDataSet.BeginInit();

                ReportDataSource rptdataSource1 = new ReportDataSource();
                ReportViewer1.LocalReport.DataSources.Add(rptdataSource1);
                rptdataSource1.Name = "DataSet1";
                rptdataSource1.Value = xsdDataSet.CentralByRetun;

                xsdDataSet.EndInit();

                CentralTableAdapters.CentralByRetunTableAdapter storeAdp = new CentralTableAdapters.CentralByRetunTableAdapter();
                // xsd.BranchSalesDetails.Clear();

                storeAdp.FillCentralByRetun(xsdDataSet.CentralByRetun);
                storeAdp.ClearBeforeFill=true;
                this.ReportViewer1.LocalReport.Refresh();
            
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {

        }

    }
}