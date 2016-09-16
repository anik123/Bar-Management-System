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
    public partial class CentralStockStatus : System.Web.UI.Page
    {
        CompanyBLL CompBLL = new CompanyBLL();
        CategoryBLL CateBLL = new CategoryBLL();
        ProductBLL PBLL = new ProductBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Central Stock Status";
                LoadCategory();
                LoadComp();

                string proid = Request.QueryString["proid"];

                string catid = Request.QueryString["catid"];
                string compid = Request.QueryString["compid"];

                if (catid != null)
                {
                    ddlCategory.SelectedValue = catid.ToString();
                }
                if (compid != null)
                {
                    ddlCompany.SelectedValue = compid.ToString();
                }

                Loaddata();
            }
        }

        public void Loaddata()
        {
            ReportViewer1.Visible = true;
            ReportParameter p1 = new ReportParameter("proid");
            ReportParameter p2 = new ReportParameter("catid");
            ReportParameter p3 = new ReportParameter("compid");


            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3 });
            this.ReportViewer1.LocalReport.Refresh();
        }
        private void LoadComp()
        {
            var query = CompBLL.SearchComInfo(0, "", "", "");
            ddlCompany.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCompany.DataTextField = "CompName";
            ddlCompany.DataValueField = "CompId";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("Select Company", "0"));
        }
        private void LoadCategory()
        {
            var query = CateBLL.GetCategory(0, "");
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
            ddlCompany.SelectedValue = "0";
            ddlCategory.SelectedValue = "0";
            this.ReportViewer1.LocalReport.Refresh();
        }
    }
}
