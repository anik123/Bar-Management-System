using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DTO;
using System.Data;
using System.Web.Security;
using PBLL.Page_ObjectBLL;
using ABLL;


namespace UI.Manager
{
    public partial class InvenCentralPurchse : System.Web.UI.Page
    {
        InvenCentralPurRequisitionBLL ReqBLL = new InvenCentralPurRequisitionBLL();
        InvenCentralPurRequisitonDTO ReqDTO = new InvenCentralPurRequisitonDTO();
        CompanyBLL compBLL = new CompanyBLL();

        CategoryBLL CBLL = new CategoryBLL();
        ProductBLL PBLL = new ProductBLL();
        InvenReorderBLL RBLL = new InvenReorderBLL();

        InvenCentralPurOrderBLL PurOrBLL = new InvenCentralPurOrderBLL();
        InvenCentralPurOrderDTO PurOrDTO = new InvenCentralPurOrderDTO();




        // store table
        InvenCentralStoreStatusDTO SDTO = new InvenCentralStoreStatusDTO();
        InvenCentralStoreStatusBLL SBLL = new InvenCentralStoreStatusBLL();

        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();

        InvenCentralPurchseBLL PurBLL = new InvenCentralPurchseBLL();
        InvenCentralPurchaeInfoDTO PurInfoDTO = new InvenCentralPurchaeInfoDTO();

        InvenCentralPurchaseDtlDto PurDtlDTO = new InvenCentralPurchaseDtlDto();


        // payment
        InvenCentralPurchasePaymentDTO PayDTO = new InvenCentralPurchasePaymentDTO();
        InvenCentralPurchasePaymentDtlDto PayDtlDTO = new InvenCentralPurchasePaymentDtlDto();


        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        //Report 

        InvenSalesDetailBLL DetailBLL = new InvenSalesDetailBLL();
        InvenSalesDetailDTO DetailDTO = new InvenSalesDetailDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            string strProcessScript = "this.value='Processing...';this.disabled=true;";
            btnPrint.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnPrint, "").ToString());
            try
            {
                if (!Page.IsPostBack)
                {

                    RoleName();
                    Page.Title = "Central Purchase";
                    LoadRequisitionNo();
                    Company();
                    LoadPurReqGridView();
                    Company_productEntryPnl();
                    LoadCategory_productEntryPnl();
                    Product_productEntryPnl();
                    Unit_productEntryPnl();
                    GetBranchId();
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
        private void LoadRequisitionNo()
        {
            /*
            var query = PurOrBLL.GetOrderNum_Dropdownlist();
            ddlRequisionNo.DataSource = query;//OrderBy(Items => Items.BrProId);
            ddlRequisionNo.DataTextField = "PurOrderNO";
            ddlRequisionNo.DataValueField = "PurOrderNO";
            ddlRequisionNo.DataBind();
            ddlRequisionNo.Items.Insert(0, new ListItem("Select Branch", "0"));
             * */

        }
        private void Company()
        {
            /*
            var query = compBLL.SearchComInfo(0, "", "", "");
            ddlCName_S.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCName_S.DataTextField = "CompName";
            ddlCName_S.DataValueField = "CompId";
            ddlCName_S.DataBind();
            ddlCName_S.Items.Insert(0, new ListItem("Select Company", "0"));
             * */

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
            /*
            if (txtDateTo.Text == "" && txtDateFrom.Text == "" && ddlRequisionNo.SelectedValue == "0" && ddlCName_S.SelectedValue == "0")
            {
                Show(" Plz Insert Data For Search");
                return;
            }
            var search = PurOrBLL.GetOrderNo_CentralPurchasepage(txtDateFrom.Text, txtDateTo.Text, Convert.ToInt16(ddlCName_S.SelectedValue), Convert.ToInt32(ddlRequisionNo.SelectedValue));
            if (search.Count == 0)
            {
                Show("No data Found !");
                return;
            }
            GVCOA.DataSource = search;
            GVCOA.DataBind();
            LoadOtherEntity();
             * */

        }
        // for rpt payment status
        public void LoadOtherEntity()
        {
            /*
            foreach (GridViewRow row in GVCOA.Rows)
            {
                var Rptstatus = PurOrBLL.GetOrderNo_CentralPurchasepage_UnderPurOrder(Convert.ToInt32(row.Cells[1].Text));
                row.Cells[2].Text = Rptstatus.First().CompName;
                row.Cells[3].Text = Rptstatus.First().PurOrderBy;
                row.Cells[4].Text = Rptstatus.First().PurOrderDate.Value.ToShortDateString();
            }
             */
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchReq();
        }

        protected void btnSearchCancel_Click(object sender, EventArgs e)
        {

            Search_Clear();
            LoadPurReqGridView();
            //  PnlLoadRequsionDatalist.Visible = false;
        }
        public void Search_Clear()
        {
            /*
            ddlRequisionNo.SelectedValue = "0";
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            ddlCName_S.SelectedValue = "0";
            GVCOA.SelectedIndex = -1;
             * */

        }
        public void GetBranchId()
        {
            string empusername = HttpContext.Current.User.Identity.Name;
            var brid = empBLL.GetCurrentUserBranchName(empusername);

            HFBranceId.Value = brid.First().BrProId.ToString();
        }
        private void LoadPurReqGridView()
        {
            /*
            var search = PurOrBLL.GetOrderNo_CentralPurchasepage(txtDateFrom.Text, txtDateTo.Text, Convert.ToInt16(ddlCName_S.SelectedValue), Convert.ToInt16(ddlRequisionNo.SelectedValue));
            
                GVCOA.DataSource = search;
                GVCOA.DataBind();
                LoadOtherEntity();
            */
        }

        protected void GVCOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            var reqprolist = PurOrBLL.GetPurchaseOrderInfo(0, Convert.ToInt32(GVCOA.DataKeys[GVCOA.SelectedIndex].Values["PurOrderNO"].ToString()));
            GvUpdate.DataSource = reqprolist;
            GvUpdate.DataBind();
            HFCompId.Value = reqprolist.First().CompId.ToString();
            PnlLoadRequsionDatalist.Visible = true;
             * */
        }
        /*
        protected void GVCOA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVCOA.PageIndex = e.NewPageIndex;
            LoadPurReqGridView();
        }
        */
        protected void GvUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            /*
            var bb = PurOrBLL.GetPurchaseOrderInfo(Convert.ToInt32(GvUpdate.DataKeys[GvUpdate.SelectedIndex].Values["CentralPurOrderId"].ToString()), 0);

            ddlCName.SelectedValue = bb.First().CompId.ToString();
            //   HFBrProId.Value = bb.First().BrProId.ToString();
            ddlCateName.SelectedValue = bb.First().CatId.ToString();
            ddlPName.SelectedValue = bb.First().ProductId.ToString();
            ddlUnit.SelectedValue = bb.First().UnitId.ToString();
            txtPQuality.Text = bb.First().Quantity.ToString();
            txtPurPrice.Text = bb.First().UnitPrice.ToString();
            RbPriority.SelectedValue = bb.First().Priority.ToString();
            HFPurOrderId.Value = bb.First().CentralPurOrderId.ToString();
            CurrentStockLoad();
             * */
        }
        protected void GvUpdate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            /*
            GvUpdate.PageIndex = e.NewPageIndex;
            var reqprolist = PurOrBLL.GetPurchaseOrderInfo(0, Convert.ToInt32(GVCOA.DataKeys[GVCOA.SelectedIndex].Values["PurOrderNO"].ToString()));
            GvUpdate.DataSource = reqprolist;
            GvUpdate.DataBind();
             * */
        }

        protected void btnPost_Click(object sender, EventArgs e)
        {
            /*
            var reqprolist = PurOrBLL.GetPurchaseOrderInfo(0, Convert.ToInt32(GVCOA.DataKeys[GVCOA.SelectedIndex].Values["PurOrderNO"].ToString()));
            GVPur.DataSource = reqprolist;
            GVPur.DataBind();
            pnlAction.Visible = true;
            AddPayable();
             * */
        }

        private void Company_productEntryPnl()
        {

            var query = compBLL.SearchComInfo(0, "", "", "");
            ddlCName.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCName.DataTextField = "CompName";
            ddlCName.DataValueField = "CompId";
            ddlCName.DataBind();
            ddlCName.Items.Insert(0, new ListItem("Select Sub Category", "0"));

        }
        private void LoadCategory_productEntryPnl()
        {
            var query = CBLL.GetCategory(0, "");
            ddlCateName.DataSource = query.OrderBy(Items => Items.CategoryName).Where(o => !o.CategoryName.ToLower().Contains("Cocktail".ToLower()) && !o.CategoryName.ToLower().Contains("extra".ToLower()));
            ddlCateName.DataTextField = "CategoryName";
            ddlCateName.DataValueField = "CatId";
            ddlCateName.DataBind();
            ddlCateName.Items.Insert(0, new ListItem("Select Category", "0"));
        }

        private void Product_productEntryPnl()
        {


            var query = PBLL.GetProduct_Categorywise(Convert.ToInt16(ddlCateName.SelectedValue), 0);
            ddlCName.DataSource = query.OrderBy(Items => Items.ProductName);
            ddlCName.DataTextField = "CompName";
            ddlCName.DataValueField = "CompId";
            ddlCName.DataBind();
            ddlCName.Items.Insert(0, new ListItem("Select Sub Category", "0"));


        }
        private void Unit_productEntryPnl()
        {
            /*
            var query = PBLL.GetUnnit_Productwise(Convert.ToInt32(ddlPName.SelectedValue));
            ddlUnit.DataSource = query.OrderBy(Items => Items.UnitName);
            ddlUnit.DataTextField = "UnitName";
            ddlUnit.DataValueField = "UnitId";
            ddlUnit.DataBind();
            ddlUnit.Items.Insert(0, new ListItem("Select Unit", "0"));
             * */
        }
        private void CurrentStockLoad()
        {
            var query = PBLL.GetProduct_Categorywise(Convert.ToInt16(ddlCateName.SelectedValue), Convert.ToInt16(ddlCName.SelectedValue));
            HFProductId.Value = query.First().ProductId.ToString();
            // Show(HFProductId.Value);
            var stockquan = SBLL.LoadCentralStockStatus(query.First().ProductId);
            //Show(stockquan.First().QuantityStore.ToString());

            if (stockquan.Count != 0)
            {
                txtCurrent.Text = stockquan.First().QuantityStore.ToString();
                // Show(stockquan.First().QuantityStore.ToString());
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

                    if (Convert.ToInt32(HFProductId.Value.ToString()) == Convert.ToInt32(dt.Rows[i][0].ToString()))
                    {
                        Show("Product Already Inserted  !");
                        return;
                    }

                    /*  if (Convert.ToInt32(ddlCName.SelectedValue) != Convert.ToInt32(dt.Rows[i][2].ToString()))
                      {
                          Show(" Different Company Product Not Allow !");
                          return;
                      }
                     * */
                }
                BindGrid(count);
            }
            else
            {
                BindGrid(1);
            }
            HFCompId.Value = ddlCName.SelectedValue.ToString();
            pnlAction.Visible = true;
            ClearAddToOrder();
            AddPayable();

        }

        public void AddPayable()
        {
            //  Show(GVPur..Count+"");

            if (GVPur.Rows.Count > 0)
            {
                double sum = 0;
                string a = "";
                foreach (GridViewRow row in GVPur.Rows)
                {

                    sum += double.Parse(row.Cells[5].Text) * double.Parse(row.Cells[4].Text);
                    // Show(row.Cells[11].Text);
                }

                txtTotalPayable.Text = sum.ToString();
            }
            else
                txtTotalPayable.Text = "0";

        }
        public void ClearAddToOrder()
        {
            //   ddlUnit.SelectedValue = "0";
            // ddlPName.SelectedValue = "0";
            ddlCName.SelectedValue = "0";
            ddlCName.SelectedValue = "0";
            ddlCateName.SelectedValue = "0";
            ddlCateName.SelectedValue = "0";
            txtPQuality.Text = "";
            txtPurPrice.Text = "";
            txtCurrent.Text = "0";
            // GvUpdate.SelectedIndex = -1;
        }


        private void BindGrid(int rowcount)
        {
            try
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
                dt.Columns.Add(new System.Data.DataColumn("CentralPurOrderId", typeof(String)));
                dt.Columns.Add(new System.Data.DataColumn("Total", typeof(String)));
                //dt.Columns.Add(new System.Data.DataColumn("BrProId", typeof(String)));
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

                    dr[0] = HFProductId.Value;
                    dr[1] = "";
                    dr[3] = ddlCName.SelectedItem.ToString();
                    dr[2] = ddlCName.SelectedValue.ToString();
                    dr[4] = ddlCateName.SelectedItem.ToString();
                    dr[5] = ddlCateName.SelectedValue.ToString();
                    dr[6] = "";
                    dr[7] = txtPQuality.Text;
                    dr[8] = txtPurPrice.Text;
                    dr[9] = "";
                    dr[10] = HFPurOrderId.Value;
                    dr[11] = double.Parse(txtPQuality.Text) * double.Parse(txtPurPrice.Text);
                    // dr[11] = HFBrProId.Value;
                    dt.Rows.Add(dr);

                }
                else
                {
                    dr = dt.NewRow();
                    dr[0] = HFProductId.Value;
                    dr[1] = "";
                    dr[3] = ddlCName.SelectedItem.ToString();
                    dr[2] = ddlCName.SelectedValue.ToString();
                    dr[4] = ddlCateName.SelectedItem.ToString();
                    dr[5] = ddlCateName.SelectedValue.ToString();
                    dr[6] = "";
                    dr[7] = txtPQuality.Text;
                    dr[8] = txtPurPrice.Text;
                    dr[9] = "";
                    dr[10] = HFPurOrderId.Value;
                    dr[11] = double.Parse(txtPQuality.Text) * double.Parse(txtPurPrice.Text);
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
            try
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
                    AddPayable();
                }
            }
            catch (Exception ex)
            {
                Show(ex.Message);
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


            PurInfoDTO.PurDes = txtNote.Text;
            PurInfoDTO.CreateBy = HttpContext.Current.User.Identity.Name;
            PurInfoDTO.CreateDate = System.DateTime.Now;
            PurInfoDTO.SalesManName = txtSalesmanName.Text;
            //  PurInfoDTO.PurOrderNo = Convert.ToInt32(GVPur.Rows[0].Cells[9].Text);
            PurInfoDTO.SalesManName = txtSalesmanName.Text;

            PurBLL.PurchaseInfo(PurInfoDTO);



            var Infopur = PurBLL.LoadPurID();
            int purid = Infopur.First().PurId;
            foreach (GridViewRow row in GVPur.Rows)
            {

                PurDtlDTO.PurId = purid;
                PurDtlDTO.PurchasePrice = Convert.ToDouble(row.Cells[5].Text);
                PurDtlDTO.Quantity = Convert.ToDouble(row.Cells[4].Text);

                PurDtlDTO.ProductId = Convert.ToInt16(row.Cells[1].Text);

                PurBLL.SavePurchaseDtl(PurDtlDTO);




                if (row.Cells[6].Text != "&nbsp;")
                {
                    PurOrDTO.CentralPurOrderId = Convert.ToInt32(row.Cells[6].Text);
                    PurOrDTO.PurOrderStatus = "1";
                    PurOrDTO.PurChallanStatus = "0";
                    PurOrBLL.Edit(PurOrDTO);
                }

                // data save in store table

                var Quantity = SBLL.LoadCentralStockStatus(Convert.ToInt32(row.Cells[1].Text));
                //var reqprolist = PurOrBLL.GetPurchaseOrderInfo(Convert.ToInt32(row.Cells[3].Text), 0);

                if (Quantity.Count <= 0)
                {
                    // HFCompId.Value = Quantity.First().CompId.ToString();
                    SDTO.ProductId = Convert.ToInt32(row.Cells[1].Text);
                    SDTO.QuantityStore = Convert.ToDouble(row.Cells[4].Text);
                    SDTO.BranchId = int.Parse(HFBranceId.Value);
                    SDTO.DateStored = DateTime.Now.Date;
                    SDTO.DateUpdated = DateTime.Now.Date;
                    SDTO.QuantityLastPurchase = Convert.ToDouble(row.Cells[4].Text);
                    SDTO.QuantityPurchase = Convert.ToDouble(row.Cells[4].Text);


                    var detail = DetailBLL.GetdtlId(Convert.ToInt32(row.Cells[1].Text), DateTime.Now.ToShortDateString());
                    if (detail.Count <= 0)
                    {

                        DetailDTO.ProductId = Convert.ToInt32(row.Cells[1].Text);
                        DetailDTO.TotalQuantity = 0;
                        DetailDTO.UsedQuantity = 0;
                        DetailDTO.TodayStock = Convert.ToDouble(row.Cells[4].Text);
                        DetailDTO.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                        DetailDTO.RemainingQuantity = Convert.ToDouble(row.Cells[4].Text);

                        DetailBLL.Add(DetailDTO);
                    }


                    //  SDTO.CompanyId =reqprolist.First().CompId ;
                    SBLL.Add(SDTO);




                }
                else
                {
                    //  HFCompId.Value = Quantity.First().CompId.ToString();
                    SDTO.ProductId = Convert.ToInt32(row.Cells[1].Text);
                    SDTO.CentralStoreId = Convert.ToInt32(Quantity.First().CentralStoreId);
                    // SDTO.BranchId = int.Parse(HFBranceId.Value);
                    //SDTO.CompanyId = reqprolist.First().CompId;
                    SDTO.BranchId = int.Parse(HFBranceId.Value);

                    SDTO.QuantityStore = Convert.ToDouble(Convert.ToDouble(row.Cells[4].Text) + Quantity.First().QuantityStore);
                    SDTO.DateUpdated = DateTime.Now.Date;
                    SDTO.QuantityLastPurchase = Convert.ToDouble(row.Cells[4].Text);
                    if (Quantity.First().QuantityPurchase == null)
                    {
                        SDTO.DateStored = DateTime.Now.Date;
                        SDTO.QuantityPurchase = 0 + Convert.ToDouble(row.Cells[4].Text);
                    }
                    else
                    {
                        SDTO.QuantityPurchase = Quantity.First().QuantityPurchase + Convert.ToDouble(row.Cells[4].Text);
                    }

                    var detail = DetailBLL.GetdtlId(Convert.ToInt32(row.Cells[1].Text), DateTime.Now.ToShortDateString());
                    if (detail.Count > 0)
                    {
                        DetailDTO.DtlId = detail.First().DtlId;
                        DetailDTO.ProductId = detail.First().ProductId;
                        DetailDTO.TodayStock = detail.First().TodayStock + Convert.ToDouble(row.Cells[4].Text);
                        DetailDTO.RemainingQuantity = detail.First().RemainingQuantity + Convert.ToDouble(row.Cells[4].Text);
                        DetailBLL.EditStockOnlyStockInPage(DetailDTO);
                    }
                    else
                    {
                        DetailDTO.ProductId = Convert.ToInt32(row.Cells[1].Text);
                        DetailDTO.TotalQuantity = Quantity.First().QuantityStore;
                        DetailDTO.UsedQuantity = 0;
                        DetailDTO.RemainingQuantity = Convert.ToDouble(Convert.ToDouble(row.Cells[4].Text) + Quantity.First().QuantityStore);
                        DetailDTO.TodayStock = Convert.ToDouble(Convert.ToDouble(row.Cells[4].Text));
                        DetailDTO.CreatedDate = DateTime.Parse(DateTime.Now.ToShortDateString());
                        DetailBLL.Add(DetailDTO);
                    }


                    SBLL.Edit(SDTO);
                }

            }

            PayDTO.CompId = Convert.ToInt16(HFCompId.Value);
            PayDTO.PurId = purid;
            PayDTO.TotalPrice = Convert.ToDouble(txtTotalPayable.Text);
            PayDTO.FirstPaymentStatus = "0";
            PurBLL.SavePaymentInfo(PayDTO);




            Show(" Data Save Succesfully !");

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Manager/Report/PurchaseProductRptUI.aspx?PurId=" + purid.ToString() + "');", true);

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
            //  PnlLoadRequsionDatalist.Visible = false;
            //  GVCOA.SelectedIndex = -1;
            txtSalesmanName.Text = "";
            txtTotalPayable.Text = "";

        }

        protected void btnTotalAmount_Click(object sender, EventArgs e)
        {
            AddPayable();
        }

        protected void ddlCName_SelectedIndexChanged(object sender, EventArgs e)
        {
            CurrentStockLoad();

        }
    }
}