using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ABLL;
using DTO;

namespace UI.Shop
{
    public partial class BranchReturnUI : System.Web.UI.Page
    {
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();

        CompanyBLL CompBLL = new CompanyBLL();

        CategoryBLL CBLL = new CategoryBLL();

        InvenBranchReturnBLL RutBLL = new InvenBranchReturnBLL();
        InvenBranchReturnDTO RutDTO = new InvenBranchReturnDTO();

        InvenChangeDtlDto chdtlDTO = new InvenChangeDtlDto();
        InvenChangeBLL ChBLL = new InvenChangeBLL();
        // store branch
        InvenStoreStatusBLL BrStoreBLL = new InvenStoreStatusBLL();
        InvenStoreStatusDto BrStoreDTO = new InvenStoreStatusDto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetBranchId();
                loadCompany();
                LoadCategory();
                LoadNeedToReturn();
                if (GvUpdate.Rows.Count == 0)
                {
                    pnlAcction.Visible = false;
                }
            }

        }
        public void GetBranchId()
        {
            string empusername = HttpContext.Current.User.Identity.Name;
            var brid = empBLL.GetCurrentUserBranchName(empusername);

            HFBranceId.Value = brid.First().BrProId.ToString();
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

            if (txtFromDate.Text == "" && txtToDate.Text == "" && ddlCompanyName.SelectedValue == "0" && ddlCategory.SelectedValue == "0")
            {
                Show("Search By Valid Data");
            }
            else
            {
                var data = RutBLL.Branchwise_Return_Product(0, Convert.ToInt32(ddlCategory.SelectedValue), Convert.ToInt32(ddlCompanyName.SelectedValue), Convert.ToInt16(HFBranceId.Value), txtFromDate.Text.ToString(), txtToDate.Text.ToString());
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

            var data = RutBLL.Branchwise_Return_Product(0, 0, 0, Convert.ToInt32(HFBranceId.Value), "", "");
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
            var date = RutBLL.LoadReturnId();
            int? retunno;
            if (date.Count == 0)
            {
                retunno = 1;
            }
            else
            {
                retunno = date.First().ReturnNo + 1;
            }
            foreach (GridViewRow row in GvUpdate.Rows)
            {
                CheckBox chkbox = (CheckBox)row.FindControl("myCheckBox");

                if (chkbox.Checked == true)
                {
                    // edit branch stock
                    var data = RutBLL.Branchwise_Return_Product(Convert.ToInt32(row.Cells[0].Text), 0, 0, 0, "", "");
                    int productid = data.First().ProductId;
                    var Quantitybr = BrStoreBLL.GetCurrentStockStaus(0, 0, productid, Convert.ToInt32(HFBranceId.Value), 0, 0);
                    BrStoreDTO.BrProId = Convert.ToInt32(HFBranceId.Value);
                    BrStoreDTO.ProductId = productid;
                    BrStoreDTO.InvenStoreId = Quantitybr.First().InvenStoreId;
                    BrStoreDTO.QuantityStore = Convert.ToInt32(Quantitybr.First().QuantityStore - Convert.ToInt16(row.Cells[5].Text));
                    BrStoreBLL.Edit(BrStoreDTO);
                    // insert return table
                    RutDTO.ChangeDtlId = Convert.ToInt32(row.Cells[0].Text);
                    RutDTO.ReturnBy = "tarun";
                    RutDTO.ReturnDate = System.DateTime.Now;
                    //RutDTO.PartyReturnStatus = "0";
                    RutDTO.ReturnReciveStatus = "0";
                    RutDTO.ReturnNo = retunno;
                    RutBLL.SaveBranchReturn(RutDTO);
                    // edit chagedtl table
                    chdtlDTO.ChangeDtlId = Convert.ToInt32(row.Cells[0].Text);
                    chdtlDTO.CentranlReturnStatus = "1";
                    ChBLL.Edit_ChangeDtl_CentralSendStatus(chdtlDTO);
                }
            }


            Show("Collect Central Return Report");
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Shop/Report/BranchReturnProductRptUI.aspx?retunno=" + retunno.ToString() + "');", true);
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