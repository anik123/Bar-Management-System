using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.CompProfile;
using System.Data;
using DTO;

namespace UI.Manager
{
    public partial class PurchaseOrderUI : System.Web.UI.Page
    {
        InvenPerRequisitionBLL ReqBLL = new InvenPerRequisitionBLL();
        CompanyBLL compBLL = new CompanyBLL();
        BranchProfileBLL BrBLL = new BranchProfileBLL();
        CategoryBLL CBLL = new CategoryBLL();
        ProductBLL PBLL = new ProductBLL();
        InvenReorderBLL RBLL = new InvenReorderBLL();
        InvenStoreStatusBLL StockBLL = new InvenStoreStatusBLL();
        InvenPurOrderBLL PurOrBLL = new InvenPurOrderBLL();
        InvenPurOrderDto PurOrDTO = new InvenPurOrderDto();
        InvenPerRequisitionDto ReqDTO = new InvenPerRequisitionDto();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Branch();
                Company();
                LoadPurReqGridView();
                Company_productEntryPnl();
                LoadCategory_productEntryPnl();
                Product_productEntryPnl();
                Unit_productEntryPnl();
            }
        }

        private void Branch()
        {

            var query = BrBLL.LoadBrProfileInfo(0, "", "", "");
            ddlBranch.DataSource = query.OrderBy(Items => Items.BrProName);
            ddlBranch.DataTextField = "BrProName";
            ddlBranch.DataValueField = "BrProId";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("Select Branch", "0"));

        }
        private void Company()
        {
            var query = compBLL.SearchComInfo(0, "", "", "");
            ddlCName_S.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCName_S.DataTextField = "CompName";
            ddlCName_S.DataValueField = "CompId";
            ddlCName_S.DataBind();
            ddlCName_S.Items.Insert(0, new ListItem("Select Company", "0"));

        }
        protected void txtSearch(object sender, EventArgs e)
        {

            SearchReq();

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
        private void SearchReq()
        {
            if (txtDateTo.Text == "" && txtDateFrom.Text == "" && ddlBranch.SelectedValue == "0" && ddlCName_S.SelectedValue == "0")
            {
                Show(" Plz Insert Data For Search");
                return;

            }
            var search = ReqBLL.GetRequisition_PurOrderpage(txtDateFrom.Text, txtDateTo.Text, Convert.ToInt16(ddlCName_S.SelectedValue), Convert.ToInt32(ddlBranch.SelectedValue));
            if (search.Count == 0)
            {
                Show(" No data Found !");
                return;
            }
            GVCOA.DataSource = search;
            GVCOA.DataBind();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchReq();
        }

        protected void btnSearchCancel_Click(object sender, EventArgs e)
        {
            Search_Clear();
            LoadPurReqGridView();
        }
        public void Search_Clear()
        {
            ddlBranch.SelectedValue = "0";
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            ddlCName_S.SelectedValue = "0";
            GVCOA.SelectedIndex = -1;

        }
        private void LoadPurReqGridView()
        {
            var search = ReqBLL.GetRequisition_PurOrderpage(txtDateFrom.Text, txtDateTo.Text, Convert.ToInt16(ddlCName_S.SelectedValue), Convert.ToInt16(ddlBranch.SelectedValue));
            GVCOA.DataSource = search;
            GVCOA.DataBind();
        }

        protected void GVCOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            var reqprolist = ReqBLL.GetRequisitionInfo(0, Convert.ToInt32(GVCOA.DataKeys[GVCOA.SelectedIndex].Values["RequisitionNo"].ToString()));
            GvUpdate.DataSource = reqprolist;
            GvUpdate.DataBind();
            PnlLoadRequsionDatalist.Visible = true;
        }
        protected void GVCOA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVCOA.PageIndex = e.NewPageIndex;
            LoadPurReqGridView();
        }
        // copy
        protected void GvUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bb = ReqBLL.GetRequisitionInfo(Convert.ToInt32(GvUpdate.DataKeys[GvUpdate.SelectedIndex].Values["PurReqId"].ToString()), 0);

            ddlCName.SelectedValue = bb.First().CompId.ToString();
            HFBrProId.Value = bb.First().BrProId.ToString();
            ddlCateName.SelectedValue = bb.First().CatId.ToString();
            ddlPName.SelectedValue = bb.First().ProductId.ToString();
            ddlUnit.SelectedValue = bb.First().UnitId.ToString();
            txtPQuality.Text = bb.First().Quantity.ToString();
            txtPurPrice.Text = bb.First().UnitPrice.ToString();
            RbPriority.SelectedValue = bb.First().Priority.ToString();
            HFPurReqId.Value = bb.First().PurReqId.ToString();
            CurrentStockLoad();
        }
        protected void GvUpdate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvUpdate.PageIndex = e.NewPageIndex;
            var reqprolist = ReqBLL.GetRequisitionInfo(0, Convert.ToInt32(GVCOA.DataKeys[GVCOA.SelectedIndex].Values["RequisitionNo"].ToString()));
            GvUpdate.DataSource = reqprolist;
            GvUpdate.DataBind();
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            var reqprolist = ReqBLL.GetRequisitionInfo(0, Convert.ToInt32(GVCOA.DataKeys[GVCOA.SelectedIndex].Values["RequisitionNo"].ToString()));
            GVPur.DataSource = reqprolist;
            GVPur.DataBind();
            pnlAction.Visible = true;
        }


        private void Company_productEntryPnl()
        {

            var query = compBLL.SearchComInfo(0, "", "", "");
            ddlCName.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCName.DataTextField = "CompName";
            ddlCName.DataValueField = "CompId";
            ddlCName.DataBind();
            ddlCName.Items.Insert(0, new ListItem("Select Company", "0"));

        }
        private void LoadCategory_productEntryPnl()
        {
            var query = CBLL.GetCategory(0, "");
            ddlCateName.DataSource = query.OrderBy(Items => Items.CategoryName);
            ddlCateName.DataTextField = "CategoryName";
            ddlCateName.DataValueField = "CatId";
            ddlCateName.DataBind();
            ddlCateName.Items.Insert(0, new ListItem("Select Category", "0"));
        }

        private void Product_productEntryPnl()
        {

            var query = PBLL.GetProduct_Categorywise(Convert.ToInt16(ddlCateName.SelectedValue));
            ddlPName.DataSource = query.OrderBy(Items => Items.ProductName);
            ddlPName.DataTextField = "ProductName";
            ddlPName.DataValueField = "ProductId";
            ddlPName.DataBind();
            ddlPName.Items.Insert(0, new ListItem("Select Product", "0"));

        }
        private void Unit_productEntryPnl()
        {
            var query = PBLL.GetUnnit_Productwise(Convert.ToInt32(ddlPName.SelectedValue));
            ddlUnit.DataSource = query.OrderBy(Items => Items.UnitName);
            ddlUnit.DataTextField = "UnitName";
            ddlUnit.DataValueField = "UnitId";
            ddlUnit.DataBind();
            ddlUnit.Items.Insert(0, new ListItem("Select Unit", "0"));
        }
        private void CurrentStockLoad()
        {                                                   //(id, catid, proid, branchid,compid,reordervalue)
            var stockquan = StockBLL.GetCurrentStockStaus(0, 0, Convert.ToInt16(ddlPName.SelectedValue), Convert.ToInt32(ddlBranch.SelectedValue), 0, 0);
            if (stockquan.Count != 0)
            {
                txtCurrent.Text = stockquan.First().QuantityStore.ToString();
            }
            else
            {
                txtCurrent.Text = "0";
            }
        }

        protected void ddlPName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Unit_productEntryPnl();
            CurrentStockLoad();
        }

        protected void ddlCateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product_productEntryPnl();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAddToOrder();

        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ViewState["CurrentPurData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentPurData"];
                int count = dt.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    if (Convert.ToInt32(ddlPName.SelectedValue.ToString()) == Convert.ToInt32(dt.Rows[i][0].ToString()))
                    {
                        Show("Product Already Inserted  !");
                        return;
                    }
                    if (Convert.ToInt32(ddlCName.SelectedValue) != Convert.ToInt32(dt.Rows[i][2].ToString()))
                    {
                        Show(" Different Company Product Not Allow !");
                        return;
                    }
                }
                BindGrid(count);
            }
            else
            {
                BindGrid(1);
            }
            pnlAction.Visible = true;
            ClearAddToOrder();
        }
        public void ClearAddToOrder()
        {
            ddlUnit.SelectedValue = "0";
            ddlPName.SelectedValue = "0";
            ddlCName.SelectedValue = "0";
            ddlCName.SelectedValue = "0";
            ddlCateName.SelectedValue = "0";
            ddlCateName.SelectedValue = "0";
            txtPQuality.Text = "";
            txtPurPrice.Text = "";
            txtCurrent.Text = "0";
            GvUpdate.SelectedIndex = -1;
        }


        private void BindGrid(int rowcount)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("ProductId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("ProductName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CompName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CategoryName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CategoryId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Priority", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Quantity", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("UnitName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("PurReqId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("BrProId", typeof(String)));
            if (ViewState["CurrentPurData"] != null)
            {
                for (int i = 0; i < rowcount + 1; i++)
                {
                    dt = (DataTable)ViewState["CurrentPurData"];
                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();
                    }
                }
                dr = dt.NewRow();

                dr[1] = ddlPName.SelectedItem.ToString();
                dr[0] = ddlPName.SelectedValue.ToString();
                dr[3] = ddlCName.SelectedItem.ToString();
                dr[2] = ddlCName.SelectedValue.ToString();
                dr[4] = ddlCateName.SelectedItem.ToString();
                dr[5] = ddlCateName.SelectedValue.ToString();
                dr[6] = RbPriority.SelectedItem.ToString();
                dr[7] = txtPQuality.Text;
                dr[8] = txtPurPrice.Text;
                dr[9] = ddlUnit.SelectedItem.ToString();
                dr[10] = HFPurReqId.Value;
                dr[11] = HFBrProId.Value;
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[1] = ddlPName.SelectedItem.ToString();
                dr[0] = ddlPName.SelectedValue.ToString();
                dr[3] = ddlCName.SelectedItem.ToString();
                dr[2] = ddlCName.SelectedValue.ToString();
                dr[4] = ddlCateName.SelectedItem.ToString();
                dr[5] = ddlCateName.SelectedValue.ToString();
                dr[6] = RbPriority.SelectedItem.ToString();
                dr[7] = txtPQuality.Text;
                dr[8] = txtPurPrice.Text;
                dr[9] = ddlUnit.SelectedItem.ToString();
                dr[10] = HFPurReqId.Value;
                dr[11] = HFBrProId.Value;
                dt.Rows.Add(dr);
            }
            if (ViewState["CurrentPurData"] != null)
            {
                GVPur.DataSource = (DataTable)ViewState["CurrentPurData"];
                GVPur.DataBind();
            }
            else
            {
                GVPur.DataSource = dt;
                GVPur.DataBind();
            }
            ViewState["CurrentPurData"] = dt;

            pnlAction.Visible = true;

        }
        protected void LBPurr_Click(object sender, CommandEventArgs e)
        {

            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentPurData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentPurData"];
                if (dt.Rows.Count > 0)
                {
                    dt.Rows.RemoveAt(rowID);
                }
                ViewState["CurrentPurData"] = dt;
                GVPur.DataSource = dt;
                GVPur.DataBind();
                if (GVPur.Rows.Count == 0)
                {
                    pnlAction.Visible = false;

                }

            }

        }
        protected void GVPur_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GVPur.PageIndex = e.NewPageIndex;
            if (ViewState["CurrentPurData"] != null)
            {
                GVPur.DataSource = (DataTable)ViewState["CurrentPurData"];
                GVPur.DataBind();
            }
            GVPur.DataBind();
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            int count =0;
            foreach (GridViewRow row1 in GVPur.Rows)
            {
                if (row1.Cells[10].Text == "&nbsp;")
                {
                    count = count + 1;
                }
            }
            if (count != 0)
            {
                Show(" This is For Branch Wise Purchase Order");
                return;
            }
            int OrderNo;
            var data = PurOrBLL.GetPurOrderNo();
            if (data.Count <= 0)
                OrderNo = 1;
            else
                OrderNo = Convert.ToInt32(data.FirstOrDefault().PurOrderNO.ToString()) + 1;
            foreach (GridViewRow row in GVPur.Rows)
            {

                PurOrDTO.BrProId = Convert.ToInt32(row.Cells[10].Text);
                PurOrDTO.Priority = row.Cells[6].Text;
                PurOrDTO.ProductId = Convert.ToInt32(row.Cells[3].Text);
                PurOrDTO.PurOrderBy = "tarun";
                PurOrDTO.PurOrderDate = System.DateTime.Now;
                PurOrDTO.PurOrderStatus = "0";
                PurOrDTO.Quantity = Convert.ToInt32(row.Cells[7].Text);
                if (row.Cells[8].Text != "&nbsp;")
                    PurOrDTO.UnitPrice = Convert.ToDouble(row.Cells[8].Text);
                else
                    PurOrDTO.UnitPrice = 0;
                PurOrDTO.PurOrderNO = OrderNo;
                PurOrBLL.Add(PurOrDTO);

                ReqDTO.PurReqId = Convert.ToInt32(row.Cells[9].Text);
                ReqDTO.PurReqStatus = "1";
                ReqBLL.Edit_PurRequsitionStatus(ReqDTO);
            }
            Show(" Data Save Succesfully");
            PurCancel();
        }

        protected void btnCancelPurchase_Click(object sender, EventArgs e)
        {
            PurCancel();
        }
        public void PurCancel()
        {
            LoadPurReqGridView();
            this.ViewState["CurrentPurData"] = null;
            DataTable dt = new DataTable();
            GVPur.DataSource = dt;
            GVPur.DataBind();
            pnlAction.Visible = false;
            PnlLoadRequsionDatalist.Visible = false;
            GVCOA.SelectedIndex = -1;

        }
    }
}