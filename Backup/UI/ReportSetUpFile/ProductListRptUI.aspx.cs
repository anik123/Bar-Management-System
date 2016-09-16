using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using Microsoft.Reporting.WebForms;

namespace UI.ReportSetUpFile
{
    public partial class ProductListRptUI : System.Web.UI.Page
    {
        CategoryBLL CateBLL = new CategoryBLL();
        CompanyBLL CompBLL = new CompanyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCategory();
                LoadComp();

                string cateid = Request.QueryString["cateid"];
                string compid = Request.QueryString["compid"];
                string producname = Request.QueryString["producname"];

                if (cateid != null)
                {
                    ddlCategory.SelectedValue = cateid.ToString();
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

            ReportParameter p1 = new ReportParameter("cateid");
            ReportParameter p2 = new ReportParameter("compid");
            ReportParameter p3 = new ReportParameter("producname");

            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3});
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