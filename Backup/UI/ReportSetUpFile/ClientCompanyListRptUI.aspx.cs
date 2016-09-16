using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using BLL;

namespace UI.ReportSetUpFile
{
    public partial class ClientCompanyListRptUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {


                string CompId = Request.QueryString["CompId"];
                string CompName = Request.QueryString["CompName"];
                string CompMobile = Request.QueryString["CompMobile"];
                string CompStatus = Request.QueryString["CompStatus"];

                if (CompName != null)
                {
                    txtCompanyName.Text = CompName.ToString();
                }
                if (CompStatus != null)
                {
                    ddlCompanyType.SelectedValue = CompStatus.ToString();
                }

                Loaddata();
            }
        }

        public void Loaddata()
        {
            ReportViewer1.Visible = true;

            ReportParameter p1 = new ReportParameter("CompId");
            ReportParameter p2 = new ReportParameter("CompName");
            ReportParameter p3 = new ReportParameter("CompMobile");
            ReportParameter p4 = new ReportParameter("CompStatus");


            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });
            // this.ReportViewer1.LocalReport.Refresh();
        }


        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ddlCompanyType.SelectedValue = "";
            txtCompanyName.Text = "";
            this.ReportViewer1.LocalReport.Refresh();
        }
    }
}