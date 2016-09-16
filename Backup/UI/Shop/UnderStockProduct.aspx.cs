using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.CompProfile;
using BLL;
using ABLL;

namespace UI.Shop
{
    public partial class UnderStockProduct : System.Web.UI.Page
    {
        CategoryBLL CBLL = new CategoryBLL();
        CompanyBLL compBLL = new CompanyBLL();
        InvenReorderBLL RBLL = new InvenReorderBLL();
        BranchProfileBLL BrPrBLL = new BranchProfileBLL();// branch load
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();
        InvenStoreStatusBLL StockBLL = new InvenStoreStatusBLL();

        public int? BranchId;
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetBranchId();
                LoadCategory();
                Company();
                LoadGvProductReorderInfo();
                if (GvUpdate.Rows.Count > 0)
                {
                    pnlAction.Visible = true;
                }
                else
                    pnlAction.Visible = false;
            }
        }
        private void LoadCategory()
        {
            var query = CBLL.GetCategory(0, "");
            ddlCategory.DataSource = query;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CatId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }
        // load branch
        private void Company()
        {

            var query = compBLL.SearchComInfo(0, "", "", "");
            ddlCompany.DataSource = query;
            ddlCompany.DataTextField = "CompName";
            ddlCompany.DataValueField = "CompId";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("Select CompanyName", "0"));

        }

        public void GetBranchId()
        {
            string empusername = HttpContext.Current.User.Identity.Name;
            var brid = empBLL.GetCurrentUserBranchName(empusername);
            BranchId = brid.First().BrProId;
        }
        private void LoadGvProductReorderInfo()
        {
            var ReOrder = RBLL.GetReorderInfo(0, 0, Convert.ToInt16(BranchId), 0, 0);
            GvUpdate.DataSource = ReOrder;
            GvUpdate.DataBind();
            LoadCurrentStockStatus();

        }
        private void LoadCurrentStockStatus()
        {
            foreach (GridViewRow row in GvUpdate.Rows)
            {
                int reorder = Convert.ToInt16(row.Cells[5].Text);
                string productid = row.Cells[3].Text;
                var currstock = StockBLL.GetStoreStatusById(0, Convert.ToInt16(ddlCategory.SelectedValue), Convert.ToInt16(productid), Convert.ToInt16(BranchId), Convert.ToInt16(ddlCompany.SelectedValue), reorder);

                if (currstock.Count == 0)
                {
                    row.Cells[6].Text = "0";
                    row.Cells[7].Text = row.Cells[5].Text;

                }
                else
                {
                    row.Cells[6].Text = currstock.First().QuantityStore.ToString();
                    row.Cells[7].Text = Convert.ToString(Convert.ToInt16(row.Cells[5].Text) - Convert.ToInt16(row.Cells[6].Text));
                }

            }
        }

        protected void GvUpdate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvUpdate.PageIndex = e.NewPageIndex;
            LoadGvProductReorderInfo();
            LoadCurrentStockStatus();
        }

        protected void btnRefresh_Click(object sender, EventArgs e)
        {
            ddlCompany.SelectedValue = "0";
            ddlCategory.SelectedValue = "0";
            LoadGvProductReorderInfo();
            LoadCurrentStockStatus();
        }


        protected void btnCreateReqisisiton_Click(object sender, EventArgs e)
        {
            Response.Redirect("/Shop/PurchaseRequisition.aspx");
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();

        }
        public static void Show(string message)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                message = message.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + message + "');", true);
            }
        }
        public void Search()
        {

            if (ddlCategory.SelectedValue == "0" && ddlCompany.SelectedValue == "0")
            {
                Show("Search By Valid Data");
            }
            else
            {

                var ReOrder = RBLL.GetReorderInfo(0, Convert.ToInt16(ddlCategory.SelectedValue), Convert.ToInt16(BranchId), Convert.ToInt16(ddlCompany.SelectedValue), 0);

                if (ReOrder.Count == 0)
                {
                    Show("No Data Found !");
                    return;
                }
                GvUpdate.DataSource = ReOrder;
                GvUpdate.DataBind();
            }
        }
        protected void btnSearchCancel_Click(object sender, EventArgs e)
        {
            ddlCategory.SelectedValue = "0";
            ddlCompany.SelectedValue = "0";
            LoadGvProductReorderInfo();
        }






    }
}