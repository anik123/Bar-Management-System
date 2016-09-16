using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using BLL.CompProfile;
using BLL;
using ABLL;

namespace UI.Shop.Report
{
    public partial class BranchStockStatus_Details_RptUI : System.Web.UI.Page
    {
        BranchProfileBLL BrBLL = new BranchProfileBLL();
        CompanyBLL CompBLL = new CompanyBLL();
        CategoryBLL CateBLL = new CategoryBLL();
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();
        // ReportBLL rptbll = new BLL.ReportBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Branch Stock Details";
                LoadCategory();
                LoadComp();
                string proid = Request.QueryString["proid"];
                string catid = Request.QueryString["catid"];
                string compid = Request.QueryString["compid"];
                string brproid = Request.QueryString["brproid"];
                if (catid != null)
                {
                    ddlCategory.SelectedValue = catid.ToString();
                }
                if (compid != null)
                {
                    ddlCompany.SelectedValue = compid.ToString();
                }
                if (brproid != null)
                {
                    HFBranceId.Value = brproid.ToString();
                }

                Loaddata();
            }
        }
        public void GetBranchId()
        {
            string empusername = HttpContext.Current.User.Identity.Name;
            var brid = empBLL.GetCurrentUserBranchName(empusername);

            HFBranceId.Value = brid.First().BrProId.ToString();
        }

        public void Loaddata()
        {
            ReportViewer1.Visible = true;
            ReportParameter p1 = new ReportParameter("proid");
            ReportParameter p2 = new ReportParameter("catid");
            ReportParameter p3 = new ReportParameter("compid");
            ReportParameter p4 = new ReportParameter("brproid");

            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });
            this.ReportViewer1.LocalReport.Refresh();
        }
        private void LoadComp()
        {
            var query = CompBLL.SearchComInfo(0, "", "", "");
            ddlCompany.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCompany.DataTextField = "CompName";
            ddlCompany.DataValueField = "CompId";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("Select Party", "0"));
        }
        private void LoadCategory()
        {
            var query = CateBLL.GetCategory(0, "");
            ddlCategory.DataSource = query.OrderBy(Items => Items.CategoryName);
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CatId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Product", "0"));
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Loaddata();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            //ddlCompany.SelectedValue = "0";
            //ddlCategory.SelectedValue = "0";

            //this.ReportViewer1.LocalReport.Refresh();
        }
        public void loadDataByCat(int catId)
        {
            ReportViewer1.Visible = true;

            ReportViewer1.DocumentMapCollapsed = true;
            Branch xsd = new Branch();
            xsd.BeginInit();
            ReportDataSource rptdataSource1 = new ReportDataSource();
            ReportViewer1.LocalReport.DataSources.Add(rptdataSource1);
            rptdataSource1.Name = "DataSet1";
            rptdataSource1.Value = xsd.BranchStoreStatus;
            xsd.EndInit();
            BranchTableAdapters.BranchStoreStatusTableAdapter storeAdp = new BranchTableAdapters.BranchStoreStatusTableAdapter();
            storeAdp.FillByCat(xsd.BranchStoreStatus, catId);
            storeAdp.ClearBeforeFill = true;
            //ReportParameter p1 = new ReportParameter("proid");
            //ReportParameter p2 = new ReportParameter("catid");
            //ReportParameter p3 = new ReportParameter("compid");
            //ReportParameter p4 = new ReportParameter("brproid");
            // this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });
            this.ReportViewer1.LocalReport.Refresh();
        }
        
        
    }
}