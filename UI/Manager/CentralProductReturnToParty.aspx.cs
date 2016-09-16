using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DTO;
using BLL.CompProfile;

namespace UI.Manager
{
    public partial class CentralProductReturnToParty : System.Web.UI.Page
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
        // central return product
        InvenCentralReturnBLL CentralBLL = new InvenCentralReturnBLL();
        InvenCentralReturnDTO CentralDTO = new InvenCentralReturnDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Return To Party";

                loadCompany();
                LoadCategory();
                LaodProduct();
                LoadBranch();
                LoadNeedToReturn();
                if (GvUpdate.Rows.Count == 0)
                {
                    pnlAcction.Visible = false;
                }

            }

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
        private void LaodProduct()
        {
            var query = ProBLL.GetProduct_Categorywise(Convert.ToInt16(ddlCategory.SelectedValue),0);
            ddlProduct.DataSource = query.OrderBy(Items => Items.ProductName);
            ddlProduct.DataTextField = "ProductName";
            ddlProduct.DataValueField = "ProductId";
            ddlProduct.DataBind();
            ddlProduct.Items.Insert(0, new ListItem("Select Product", "0"));
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
        private void loadCompany()
        {
            var query = CompBLL.SearchComInfo(0, "", "", "");
            ddlCompanyName.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCompanyName.DataTextField = "CompName";
            ddlCompanyName.DataValueField = "CompId";
            ddlCompanyName.DataBind();
            ddlCompanyName.Items.Insert(0, new ListItem("Select Company", "0"));
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();

        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }
        public void ClearSearch()
        {
            ddlCompanyName.SelectedValue = "0";
            ddlCategory.SelectedValue = "0";
            ddlBranch.SelectedValue = "0";
            ddlProduct.SelectedValue = "0";
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

            if (ddlProduct.SelectedValue == "0" && ddlBranch.SelectedValue == "0" && ddlCompanyName.SelectedValue == "0" && ddlCategory.SelectedValue == "0")
            {
                Show("Search By Valid Data");
            }
            else
            {         // Central_Return_Product_To_Party(int retunid, int catid, int productid, int compid, int brid)
                var data = RutBLL.Central_Return_Product_To_Party(0, Convert.ToInt16(ddlCategory.SelectedValue), Convert.ToInt32(ddlProduct.SelectedValue), Convert.ToInt16(ddlCompanyName.SelectedValue), Convert.ToInt16(ddlBranch.SelectedValue));
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

            var data = RutBLL.Central_Return_Product_To_Party(0, 0, 0, 0, 0);
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
            var LoadMaxCentralReturn = CentralBLL.LaodPartyReturnNO();
            int MaxCentralRetNO;

            //  var date = RutBLL.LoadReturnId();
            //int? retunno;
            if (LoadMaxCentralReturn.Count == 0)
            {
                MaxCentralRetNO = 1;
            }
            else
            {
                MaxCentralRetNO = LoadMaxCentralReturn.First().ReturnNo + 1;
            }
            foreach (GridViewRow row in GvUpdate.Rows)
            {
                CheckBox chkbox = (CheckBox)row.FindControl("myCheckBox");
                if (chkbox.Checked == true)
                {
                    // product id get to maintain central stock status
                    var data = RutBLL.Central_Return_Product_To_Party(Convert.ToInt32(row.Cells[0].Text), 0, 0, 0, 0);
                    int productid = data.First().ProductId;
                    // edit central stock
                    var Quantity = SBLL.LoadCentralStockStatus(productid);
                    SDTO.ProductId = productid;
                    SDTO.CentralStoreId = Quantity.First().CentralStoreId;
                    SDTO.QuantityStore = Quantity.First().QuantityStore - Convert.ToInt16(row.Cells[6].Text);
                    SBLL.Edit(SDTO);

                    // insert central  return table
                    CentralDTO.BranchReturnId = Convert.ToInt32(row.Cells[0].Text);
                    CentralDTO.ReturnBy = HttpContext.Current.User.Identity.Name;
                    CentralDTO.ReturnDate = System.DateTime.Now;
                    CentralDTO.ReturnNo = MaxCentralRetNO;
                    CentralBLL.SaveCentralReturn(CentralDTO);
                    // edit chagedtl table
                    RutDTO.BranchReturnId = Convert.ToInt32(row.Cells[0].Text);
                    RutDTO.CentralToPartyStatus = "1";
                    RutBLL.Edit_Central_To_Party(RutDTO);
                }
            }
            ClearSearch();

            //Show("Collect Central Return Report");
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Manager/Report/ReturnCentralToPartyRptUI.aspx?retunno=" + MaxCentralRetNO.ToString() + "');", true);

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