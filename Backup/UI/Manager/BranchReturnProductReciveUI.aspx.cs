using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.CompProfile;
using BLL;
using DTO;

namespace UI.Manager
{
    public partial class BranchReturnProductReciveUI : System.Web.UI.Page
    {
        BranchProfileBLL BrBLL = new BranchProfileBLL();
        ProductBLL ProBLL = new ProductBLL();
        CompanyBLL CompBLL = new CompanyBLL();
        CategoryBLL CBLL = new CategoryBLL();
        InvenBranchReturnBLL RutBLL = new InvenBranchReturnBLL();
        InvenBranchReturnDTO RutDTO = new InvenBranchReturnDTO();

        InvenChangeDtlDto chdtlDTO = new InvenChangeDtlDto();
        InvenChangeBLL ChBLL = new InvenChangeBLL();
        // store branch
        InvenStoreStatusBLL BrStoreBLL = new InvenStoreStatusBLL();
        InvenStoreStatusDto BrStoreDTO = new InvenStoreStatusDto();
        // store table center
        InvenCentralStoreStatusDTO SDTO = new InvenCentralStoreStatusDTO();
        InvenCentralStoreStatusBLL SBLL = new InvenCentralStoreStatusBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadBranch();
                LoadCategory();
                LoadNeedToReturn();
                if (GvUpdate.Rows.Count == 0)
                {
                    pnlAcction.Visible = false;
                }

            }

        }

        private void LoadBranch()
        {
            var query = BrBLL.LoadBrProfileInfo(0, "", "", "");
            ddlBranch.DataSource = query.OrderBy(Items => Items.BrProName);
            ddlBranch.DataTextField = "BrProName";
            ddlBranch.DataValueField = "BrProId";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("Select Branch", "0"));
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }

        private void LoadCategory()
        {
            var query = CBLL.GetCategory(0, "");
            ddlCategory.DataSource = query.OrderBy(Items => Items.CategoryName);
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CatId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }
        public void ClearSearch()
        {
            ddlCategory.SelectedValue = "0";
            ddlBranch.SelectedValue = "0";
            txtToDate.Text = "";
            txtFromDate.Text = "";
            LoadNeedToReturn();
            if (GvUpdate.Rows.Count == 0)
            {
                pnlAcction.Visible = false;
            }
            else
            {
                pnlAcction.Visible = true;

            }
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

            if (txtFromDate.Text == "" && txtToDate.Text == "" && ddlBranch.SelectedValue == "0" && ddlCategory.SelectedValue == "0")
            {
                Show("Search By Valid Data");
            }
            else
            {//Central_Return_Product_Recive(int retunid, int catid, int productid, int compid, int brid)
                var data = RutBLL.Central_Return_Product_Recive(0, Convert.ToInt32(ddlCategory.SelectedValue), 0, 0, Convert.ToInt32(ddlBranch.SelectedValue), txtFromDate.Text.ToString(), txtToDate.Text.ToString());
                GvUpdate.DataSource = data;
                GvUpdate.DataBind();

                if (GvUpdate.Rows.Count <= 0)
                {
                    Show("No Data Found !");
                    pnlAcction.Visible = false;
                }

            }
        }
        public void LoadNeedToReturn()
        {

            var data = RutBLL.Central_Return_Product_Recive(0, 0, 0, 0, 0, "", "");
            GvUpdate.DataSource = data;
            GvUpdate.DataBind();
        }
        protected void GvUpdate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GvUpdate.PageIndex = e.NewPageIndex;
            LoadNeedToReturn();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            int noseectcount = 0;

            foreach (GridViewRow row in GvUpdate.Rows)
            {
                CheckBox chkbox = (CheckBox)row.FindControl("myCheckBox");

                if (chkbox.Checked == true)
                {
                    noseectcount = noseectcount + 1;

                }

            }
            if (noseectcount == 0)
            {
                Show("Plz Select Product");
                return;
            }

            foreach (GridViewRow row in GvUpdate.Rows)
            {
                CheckBox chkbox = (CheckBox)row.FindControl("myCheckBox");

                if (chkbox.Checked == true)
                {
                    // edit branch stock
                    var data = RutBLL.Central_Return_Product_Recive(Convert.ToInt32(row.Cells[0].Text), 0, 0, 0, 0, "", "");
                    int productid = data.First().ProductId;

                    // edit central stock
                    var Quantity = SBLL.LoadCentralStockStatus(productid);
                    SDTO.ProductId = productid;
                    SDTO.CentralStoreId = Quantity.First().CentralStoreId;
                    SDTO.QuantityStore = Convert.ToInt32(Convert.ToInt16(row.Cells[6].Text) + Quantity.First().QuantityStore);
                    SBLL.Edit(SDTO);

                    // insert return table
                    RutDTO.BranchReturnId = Convert.ToInt32(row.Cells[0].Text);
                    RutDTO.ReciveBy = "tarun";
                    RutDTO.ReciveDate = System.DateTime.Now;
                    RutDTO.ReturnReciveStatus = "1";
                    RutDTO.CentralToPartyStatus = "0";
                    RutBLL.Edit(RutDTO);

                }
            }


            // Show("Collect Central Return Report");
            // ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Shop/Report/BranchReturnProductRptUI.aspx?retunno=" + retunno.ToString() + "');", true);
            ClearSearch();
        }

        protected void btnCancelPurchase_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GvUpdate.Rows)
            {
                CheckBox chkbox = (CheckBox)row.FindControl("myCheckBox");

                chkbox.Checked = false;
            }
            ClearSearch();
        }


    }
}
