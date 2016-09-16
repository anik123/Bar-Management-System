using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.CompProfile;
using ABLL;
using System.Data;
using DTO;
using System.Web.Security;
using PBLL.Page_ObjectBLL;

namespace UI.Shop
{
    public partial class PurchaseRequisition : System.Web.UI.Page
    {
        CategoryBLL CBLL = new CategoryBLL();
        CompanyBLL compBLL = new CompanyBLL();
        InvenReorderBLL RBLL = new InvenReorderBLL();
        BranchProfileBLL BrPrBLL = new BranchProfileBLL();// branch load
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();
        InvenStoreStatusBLL StockBLL = new InvenStoreStatusBLL();
        ProductBLL PBLL = new ProductBLL();
        UnitBLL UBLL = new UnitBLL();
        InvenPerRequisitionBLL ReqBLL = new InvenPerRequisitionBLL();
        InvenPerRequisitionDto PRDTO = new InvenPerRequisitionDto();
        InvenReorderDto RDTO = new InvenReorderDto();
        public int? BranchId;
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            try{
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Branch Requisiton";
                GetBranchId();
                LoadCategory();
                Company();
                LoadGvProductReorderInfo();
                LoadCurrentStockStatus();
                Company_productEntryPnl();
                LoadCategory_productEntryPnl();
                Product_productEntryPnl();
                Unit_productEntryPnl();
            }

            }
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }
        public void RoleName()
        {

            string empusername = HttpContext.Current.User.Identity.Name;

            var role = LBLL.GetRoleName_By_User(empusername);
            int roleid = role.First().RoleId;

            var loadPage = PObjRoleBLL.Page_ObjectRole(0, roleid, "", "");
            int count = loadPage.Count;

            int matcheddata = 0;
            for (int i = 0; i < count; i++)
            {
                if (HttpContext.Current.Request.Url.AbsolutePath == loadPage[i].PagePath.ToString())
                {
                    matcheddata = matcheddata + 1;
                }
            }
            if (matcheddata == 1)
            {
            }
            else
            {
                FormsAuthenticationTicket ticket1 = new FormsAuthenticationTicket("", true, 0);
                string hash1 = FormsAuthentication.Encrypt(ticket1);
                HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, hash1);
                cookie1.Expires = DateTime.Now.AddMinutes(0);

                if (ticket1.IsPersistent)
                    cookie1.Expires = ticket1.Expiration;

                Response.Cookies.Add(cookie1);
                Response.Redirect(" LoginUI.aspx");
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
        // load branch
        private void Company()
        {

            var query = compBLL.SearchComInfo(0, "", "", "");
            ddlCompany.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCompany.DataTextField = "CompName";
            ddlCompany.DataValueField = "CompId";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("Select Company", "0"));

        }

        public void GetBranchId()
        {
            string empusername = HttpContext.Current.User.Identity.Name;
            var brid = empBLL.GetCurrentUserBranchName(empusername);
            BranchId = brid.First().BrProId;
            HFBranceId.Value = BranchId.ToString();
        }
        private void LoadGvProductReorderInfo()
        {
            var ReOrder = RBLL.GetReorderInfo(0, Convert.ToInt16(ddlCategory.SelectedValue), Convert.ToInt16(BranchId), Convert.ToInt16(ddlCompany.SelectedValue), 0);
            GvUpdate.DataSource = ReOrder;
            GvUpdate.DataBind();
            LoadCurrentStockStatus();

        }
        private void LoadCurrentStockStatus()
        {
            try{
            foreach (GridViewRow row in GvUpdate.Rows)
            {
                int reorder = Convert.ToInt16(row.Cells[6].Text);
                string productid = row.Cells[4].Text;
                var currstock = StockBLL.GetStoreStatusById(0, Convert.ToInt16(ddlCategory.SelectedValue), Convert.ToInt16(productid), Convert.ToInt16(BranchId), Convert.ToInt16(ddlCompany.SelectedValue), reorder);

                if (currstock.Count == 0)
                {
                    row.Cells[7].Text = "0";
                    row.Cells[8].Text = row.Cells[6].Text;

                }
                else
                {
                    row.Cells[7].Text = currstock.First().QuantityStore.ToString();
                    row.Cells[8].Text = Convert.ToString(Convert.ToInt16(row.Cells[6].Text) - Convert.ToInt16(row.Cells[7].Text));
                }

            }
            }
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }

        //protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LoadGvProductReorderInfo();
        //    LoadCurrentStockStatus();

        //}

        //protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    LoadGvProductReorderInfo();
        //    LoadCurrentStockStatus();
        //}
        protected void GvUpdate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvUpdate.PageIndex = e.NewPageIndex;
            LoadGvProductReorderInfo();
            LoadCurrentStockStatus();
        }

        protected void GvUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bb = RBLL.GetReorderInfo(0, 0, 0, 0, Convert.ToInt32(GvUpdate.DataKeys[GvUpdate.SelectedIndex].Values["ProductId"].ToString()));

            ddlCName.SelectedValue = bb.First().CompId.ToString();
            HFReOrderId.Value = bb.First().ReorderId.ToString();
            ddlCateName.SelectedValue = bb.First().CategoryId.ToString();
            ddlPName.SelectedValue = bb.First().ProductId.ToString();
            ddlUnit.SelectedValue = bb.First().UnitId.ToString();
            txtCurrent.Text = GvUpdate.Rows[GvUpdate.SelectedIndex].Cells[7].Text;
            txtPQuality.Text = GvUpdate.Rows[GvUpdate.SelectedIndex].Cells[8].Text;
            txtPurPrice.Text = bb.First().ProductPurchasePrice.ToString();
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

            var query = PBLL.GetProduct_Categorywise(Convert.ToInt16(ddlCateName.SelectedValue),0);
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

        protected void ddlPName_SelectedIndexChanged(object sender, EventArgs e)
        {
            try{
            Unit_productEntryPnl();
            int? reorderquantity;
            var minpur = RBLL.GetReorderInfo(0, 0, 0, 0, Convert.ToInt16(ddlPName.SelectedValue));
            if (minpur.Count != 0)
                reorderquantity = minpur.First().ReorderValue;

            else
            {
                reorderquantity = 0;
            }
            var stockquan = StockBLL.GetStoreStatusById(0, 0, Convert.ToInt16(ddlPName.SelectedValue), 0, 0, Convert.ToInt16(reorderquantity));
            if (stockquan.Count != 0)
            {
                txtCurrent.Text = stockquan.First().QuantityStore.ToString();
                txtPurPrice.Text = stockquan.First().PurchasePrice.ToString();
            }
            else
            {
                txtCurrent.Text = "0";
            }

            if (stockquan.Count != 0)
            {
                txtPQuality.Text = Convert.ToString(reorderquantity - Convert.ToInt32(txtCurrent.Text));
            }
            else
            {
                txtPQuality.Text = reorderquantity.ToString();
            }
        }
        catch (Exception ex)
        {
            Show(ex.Message);
        }
        }

        protected void ddlCateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product_productEntryPnl();
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
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (int.Parse(txtPQuality.Text) == 0)
            {
                Show("Purchase Qty Must Be Greater Than 0");
                return;
            }
            else
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
                        //if (Convert.ToInt32(ddlCName.SelectedValue) != Convert.ToInt32(dt.Rows[i][2].ToString()))
                        //{
                        //    Show(" Different Company Product Not Allow !");
                        //    return;
                        //}
                    }
                    BindGrid(count);
                }
                else
                {
                    BindGrid(1);

                }
                pnlAction.Visible = true;
                Clear();
            }
        }
        public void Clear()
        {

            ddlUnit.SelectedValue = "0";
            ddlPName.SelectedValue = "0";
            ddlCompany.SelectedValue = "0";
            ddlCName.SelectedValue = "0";
            ddlCateName.SelectedValue = "0";
            ddlCategory.SelectedValue = "0";

            txtPQuality.Text = "";
            txtPurPrice.Text = "";
            txtCurrent.Text = "0";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }

        private void BindGrid(int rowcount)
        {
            try{
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
            dt.Columns.Add(new System.Data.DataColumn("ReorderId", typeof(String)));
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
                dr[10] = HFReOrderId.Value;
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
                dr[10] = HFReOrderId.Value;
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
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }
        protected void LBPurr_Click(object sender, CommandEventArgs e)
        {
            try{
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
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            try
            {
                // if ( ddlb
                DataTable dt = (DataTable)ViewState["CurrentPurData"];
                int count = dt.Rows.Count;
                int ReqNo;
                var data = ReqBLL.GetReqList();
                if (data.Count <= 0)
                    ReqNo = 1;
                else
                {
                    ReqNo = data.First().RequisitionNo + 1;
                }
                for (int i = 0; i < count; i++)
                {
                    PRDTO.ProductId = Convert.ToInt32(dt.Rows[i][0].ToString());
                    PRDTO.BrProId = Convert.ToInt16(HFBranceId.Value);
                    PRDTO.Quantity = Convert.ToInt32(dt.Rows[i][7].ToString());
                    if (dt.Rows[i][8].ToString() != "")
                        PRDTO.UnitPrice = Convert.ToDouble(dt.Rows[i][8].ToString());
                    PRDTO.Priority = dt.Rows[i][6].ToString();
                    PRDTO.RequisitionNo = ReqNo;
                    PRDTO.RequisitionBy = HttpContext.Current.User.Identity.Name;
                    PRDTO.RequisitionDate = System.DateTime.Now;
                    PRDTO.PurReqStatus = "0";
                    ReqBLL.Add(PRDTO);

                    // edit purreqsioton status in reorder table
                    if (dt.Rows[i][10].ToString() != "")
                    {
                        RDTO.ReorderId = Convert.ToInt32(dt.Rows[i][10].ToString());
                        RDTO.PurRequisitonStatus = "1";
                        RBLL.Edit_PurrequisitonStatus(RDTO);
                        Show("Sucessfull");
                    }

                    LoadGvProductReorderInfo();
                    LoadCurrentStockStatus();
                    // dr[10] = HFReOrderId.Value;

                }
                CancelControl();
            }
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }

        protected void btnCancelPurchase_Click(object sender, EventArgs e)
        {
            CancelControl();
        }
        public void CancelControl()
        {
            this.ViewState["CurrentPurData"] = null;
            DataTable dt = new DataTable();
            GVPur.DataSource = dt;
            GVPur.DataBind();
            Clear();
            pnlAction.Visible = false;
            GvUpdate.SelectedIndex = -1;
            
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

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
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
                //   GvUpdate.DataSource = ReOrder;
                //  GvUpdate.DataBind();

                // var ReOrder = storBLL.GetProduct(0, "", Convert.ToInt16(ddlCategory.SelectedValue), 0, Convert.ToInt16(ddlCompany.SelectedValue));
                if (ReOrder.Count == 0)
                {
                    Show("No Data Found !");
                    return;
                }
                GvUpdate.DataSource = ReOrder;
                GvUpdate.DataBind();
                LoadCurrentStockStatus();
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