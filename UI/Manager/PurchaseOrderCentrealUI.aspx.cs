using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.CompProfile;
using DTO;
using System.Data;
using ABLL;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.Manager
{
    public partial class PurchaseOrderCentrealUI : System.Web.UI.Page
    {
        InvenCentralPurRequisitionBLL ReqBLL = new InvenCentralPurRequisitionBLL();
        InvenCentralPurRequisitonDTO ReqDTO = new InvenCentralPurRequisitonDTO();
        CompanyBLL compBLL = new CompanyBLL();
        BranchProfileBLL BrBLL = new BranchProfileBLL();
        CategoryBLL CBLL = new CategoryBLL();
        ProductBLL PBLL = new ProductBLL();
        InvenReorderBLL RBLL = new InvenReorderBLL();
        InvenCentralStoreStatusBLL StockBLL = new InvenCentralStoreStatusBLL();
        InvenCentralPurOrderBLL PurOrBLL = new InvenCentralPurOrderBLL();
        InvenCentralPurOrderDTO PurOrDTO = new InvenCentralPurOrderDTO();

        // central store status bll
        InvenCentralStoreStatusBLL SBLL = new InvenCentralStoreStatusBLL();

        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Purchase Order";
                LoadRequisitionNo();
                Company();
                LoadPurReqGridView();
                Company_productEntryPnl();
                LoadCategory_productEntryPnl();
                Product_productEntryPnl();
               // Unit_productEntryPnl();
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

        private void LoadRequisitionNo()
        {

            var query = ReqBLL.GetReqList_Dropdownlist();
            ddlRequisionNo.DataSource = query;//OrderBy(Items => Items.BrProId);
            ddlRequisionNo.DataTextField = "RequisitionNo";
            ddlRequisionNo.DataValueField = "RequisitionNo";
            ddlRequisionNo.DataBind();
            ddlRequisionNo.Items.Insert(0, new ListItem("Select Branch", "0"));

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
            if (txtDateTo.Text == "" && txtDateFrom.Text == "" && ddlRequisionNo.SelectedValue == "0" && ddlCName_S.SelectedValue == "0")
            {
                Show(" Plz Insert Data For Search");
                return;

            }
            var search = ReqBLL.GetRequisition_CentralPurOrderpage(txtDateFrom.Text, txtDateTo.Text, Convert.ToInt16(ddlCName_S.SelectedValue), Convert.ToInt32(ddlRequisionNo.SelectedValue));
            if (search.Count == 0)
            {
                Show(" No data Found !");
                return;
            }
            GVCOA.DataSource = search;
            GVCOA.DataBind();
            LoadOtherEntity();
        }

        // for rpt payment status
        public void LoadOtherEntity()
        {
            foreach (GridViewRow row in GVCOA.Rows)
            {
                var Rptstatus = ReqBLL.GetInfo_By_RequisitionNoWise(Convert.ToInt32(row.Cells[1].Text));
                row.Cells[2].Text = Rptstatus.First().CompName;
                row.Cells[3].Text = Rptstatus.First().RequisitionBy;
                row.Cells[4].Text = Rptstatus.First().RequisitionDate.Value.ToShortDateString();
            }
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
            ddlRequisionNo.SelectedValue = "0";
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            ddlCName_S.SelectedValue = "0";
            GVCOA.SelectedIndex = -1;

        }
        private void LoadPurReqGridView()
        {
            var search = ReqBLL.GetRequisition_CentralPurOrderpage(txtDateFrom.Text, txtDateTo.Text, Convert.ToInt16(ddlCName_S.SelectedValue), Convert.ToInt16(ddlRequisionNo.SelectedValue));
            GVCOA.DataSource = search;
            GVCOA.DataBind();
            LoadOtherEntity();
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

        protected void GvUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bb = ReqBLL.GetRequisitionInfo(Convert.ToInt32(GvUpdate.DataKeys[GvUpdate.SelectedIndex].Values["CenPurReqId"].ToString()), 0);

            ddlCName.SelectedValue = bb.First().CompId.ToString();
            ddlCateName.SelectedValue = bb.First().CatId.ToString();
            ddlPName.SelectedValue = bb.First().ProductId.ToString();
            ddlUnit.SelectedValue = bb.First().UnitId.ToString();
            txtPQuality.Text = bb.First().Quantity.ToString();
            txtPurPrice.Text = bb.First().UnitPrice.ToString();
            RbPriority.SelectedValue = bb.First().Priority.ToString();
            HFPurReqId.Value = bb.First().CenPurReqId.ToString();
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
            //var reqprolist = ReqBLL.GetRequisitionInfo(0, Convert.ToInt32(GVCOA.DataKeys[GVCOA.SelectedIndex].Values["RequisitionNo"].ToString()));
            //GVPur.DataSource = reqprolist;
            //GVPur.DataBind();
            //pnlAction.Visible = true;
            foreach (GridViewRow row in GvUpdate.Rows)
            {
                var bb = ReqBLL.GetRequisitionInfo(Convert.ToInt32(GvUpdate.DataKeys[row.RowIndex].Values["CenPurReqId"].ToString()), 0);
                ddlCName.SelectedValue = bb.First().CompId.ToString();
                ddlCateName.SelectedValue = bb.First().CatId.ToString();
                ddlPName.SelectedValue = bb.First().ProductId.ToString();
                ddlUnit.SelectedValue = bb.First().UnitId.ToString();
                txtPQuality.Text = bb.First().Quantity.ToString();
                txtPurPrice.Text = bb.First().UnitPrice.ToString();
                RbPriority.SelectedValue = bb.First().Priority.ToString();
                HFPurReqId.Value = bb.First().CenPurReqId.ToString();
                CurrentStockLoad();

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
                        if (Convert.ToInt32(dt.Rows[i][7].ToString())==0)
                        {
                            Show("Product Purchase Qty Must Greater than 0  !");
                            PurCancel();
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
                AddPayable();
            }

        }

        private void Company_productEntryPnl()
        {
            //var query = compBLL.SearchComInfo(0, "", "", "");
            //ddlCName.DataSource = query.OrderBy(Items => Items.CompName);
            //ddlCName.DataTextField = "CompName";
            //ddlCName.DataValueField = "CompId";
            //ddlCName.DataBind();
            //ddlCName.Items.Insert(0, new ListItem("Select Company", "0"));

            var query = compBLL.SearchComInfo(0, "", "", "");
            ddlCName.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCName.DataTextField = "CompName";
            ddlCName.DataValueField = "CompId";
            ddlCName.DataBind();
            ddlCName.Items.Insert(0, new ListItem("Select Company", "0"));

        }
        private void LoadCategory_productEntryPnl()
        {
            //var query = PBLL.GetProduct_Categorywise(0, Convert.ToInt16(ddlCName.SelectedValue));

            //// var query = CBLL.GetCategory(0, "");
            //ddlCateName.DataSource = query.OrderBy(Items => Items.CategoryName);
            //ddlCateName.DataTextField = "CategoryName";
            //ddlCateName.DataValueField = "CatId";
            //ddlCateName.DataBind();
            //ddlCateName.Items.Insert(0, new ListItem("Select Product", "0"));

            var query = CBLL.GetCategory(0, "");
            ddlCateName.DataSource = query.OrderBy(Items => Items.CategoryName);
            ddlCateName.DataTextField = "CategoryName";
            ddlCateName.DataValueField = "CatId";
            ddlCateName.DataBind();
            ddlCateName.Items.Insert(0, new ListItem("Select Product", "0"));
        }

        private void Product_productEntryPnl()
        {
            //var query = PBLL.GetProduct_Categorywise(Convert.ToInt16(ddlCateName.SelectedValue), Convert.ToInt16(ddlCName.SelectedValue));
            //ddlPName.DataSource = query.OrderBy(Items => Items.ProductName);
            //ddlPName.DataTextField = "ProductName";
            //ddlPName.DataValueField = "ProductId";
            //ddlPName.DataBind();
            //ddlPName.Items.Insert(0, new ListItem("Select Product Code", "0"));
            var query = PBLL.GetProduct_Categorywise(Convert.ToInt16(ddlCateName.SelectedValue), 0);
            if (query.Count()!=0)
            {
                ddlPName.DataSource = query.OrderBy(Items => Items.ProductName);
                ddlPName.DataTextField = "ProductName";
                ddlPName.DataValueField = "ProductId";
                ddlPName.DataBind();
                ddlPName.Items.Insert(0, new ListItem("Select Product Code", "0"));
                Unit_productEntryPnl();

            }
            else
            {
                txtCurrent.Text = "0";
                txtPurPrice.Text = "";
                ddlPName.Items.Clear();

            }
        }
        private void Unit_productEntryPnl()
        {
            //var query = PBLL.GetUnnit_Productwise(Convert.ToInt32(ddlPName.SelectedValue));
            //ddlUnit.DataSource = query.OrderBy(Items => Items.UnitName);
            //ddlUnit.DataTextField = "UnitName";
            //ddlUnit.DataValueField = "UnitId";
            //ddlUnit.DataBind();
          //  ddlUnit.Items.Insert(0, new ListItem("Select Unit", "0"));

            var query = PBLL.GetUnnit_Productwise(Convert.ToInt32(ddlPName.SelectedValue));
            ddlUnit.DataSource = query.OrderBy(Items => Items.UnitName);
            ddlUnit.DataTextField = "UnitName";
            ddlUnit.DataValueField = "UnitId";
            ddlUnit.DataBind();
        }
        private void CurrentStockLoad()
        {
            var stockquan = StockBLL.GetProduct(Convert.ToInt16(ddlPName.SelectedValue), "", 0, 0, 0);
            if (stockquan.Count!= 0)
            {
                txtCurrent.Text = stockquan.First().QuantityStore.ToString();
                txtPurPrice.Text = stockquan.First().ProductPurchasePrice.ToString();
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

            if (int.Parse(txtPQuality.Text) > 0)
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
                AddPayable();
                pnlAction.Visible = true;
                ClearAddToOrder();
            }
            else
            {
                Show(" Purchase Order Quantity Must Greater Than 0 !");
                return;
            }
        }
        public void ClearAddToOrder()
        {
            ddlUnit.SelectedIndex = -1;
            ddlPName.SelectedIndex = -1;
            ddlCName.SelectedIndex =-1;
            ddlCateName.SelectedIndex =-1;
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
            dt.Columns.Add(new System.Data.DataColumn("CenPurReqId", typeof(String)));
            //dt.Columns.Add(new System.Data.DataColumn("BrProId", typeof(String)));
            if (ViewState["CurrentPurData"] != null)
            {
                for (int i = 0; i < rowcount; i++)
                {
                    dt = (DataTable)ViewState["CurrentPurData"];

                     if (Convert.ToInt32(dt.Rows[i][7].ToString())==0)
                        {
                            Show("Product Purchase Qty Must Greater than 0  !");
                            return;
                        }
                    else
                    {
                        if (dt.Rows.Count > 0)
                        {
                            dr = dt.NewRow();
                            dr[0] = dt.Rows[0][0].ToString();
                        }
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
                // dr[11] = HFBrProId.Value;
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
                dr[9] = ddlUnit.SelectedValue.ToString();
                dr[10] = HFPurReqId.Value;
                //dr[11] = HFBrProId.Value;
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

            int OrderNo;
            var data = PurOrBLL.GetPurOrderNo();
            if (data.Count <= 0)
                OrderNo = 1;
            else
                OrderNo = Convert.ToInt32(data.FirstOrDefault().PurOrderNO.ToString()) + 1;
            foreach (GridViewRow row in GVPur.Rows)
            {

                //  PurOrDTO.BrProId = Convert.ToInt32(row.Cells[10].Text);
                PurOrDTO.Priority = row.Cells[6].Text;
                PurOrDTO.ProductId = Convert.ToInt32(row.Cells[3].Text);
                PurOrDTO.PurOrderBy = HttpContext.Current.User.Identity.Name;
                PurOrDTO.PurOrderDate = System.DateTime.Now;
                PurOrDTO.PurOrderStatus = "0";
                PurOrDTO.Quantity = Convert.ToInt32(row.Cells[7].Text);
                if (row.Cells[8].Text != "&nbsp;")
                    PurOrDTO.UnitPrice = Convert.ToDouble(row.Cells[8].Text);
                else
                    PurOrDTO.UnitPrice = 0;
                PurOrDTO.PurOrderNO = OrderNo;
                PurOrBLL.Add(PurOrDTO);

                //var puroder = PurOrBLL.GetPurOrderNo();
                // int purorderno = puroder.First().PurOrderNO;

                if (row.Cells[9].Text != "&nbsp;")
                {
                    ReqDTO.CenPurReqId = Convert.ToInt32(row.Cells[9].Text);
                    ReqDTO.PurReqStatus = "1";
                    ReqBLL.Edit_PurRequsitionStatus(ReqDTO);
                }
            }
            Show(" Data Save Succesfully");
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Manager/Report/CentralPurchaseOrderRptUI.aspx?PurOrderNO=" + OrderNo.ToString() + "');", true);

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

        public void AddPayable()
        {
            if (GVPur.Rows.Count > 0)
            {
                double sum = 0;
                foreach (GridViewRow row in GVPur.Rows)
                {
                    TextBox txtquantity = (TextBox)row.FindControl("txtQuantity");
                    if (row.Cells[8].Text != "&nbsp;")
                        sum += Convert.ToDouble(row.Cells[7].Text) * Convert.ToDouble(row.Cells[8].Text);
                }
                txtTotalPayable.Text = sum.ToString();
            }
            else
                txtTotalPayable.Text = "0";
        }

    }
}