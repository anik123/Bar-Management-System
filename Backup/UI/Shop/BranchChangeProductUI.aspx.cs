using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ABLL;
using System.Data;
using DTO;

namespace UI.Shop
{
    public partial class BranchChangeProductUI : System.Web.UI.Page
    {
        InvenChangeBLL CHBLL = new InvenChangeBLL();
        InvenSalesBLL SalBLL = new InvenSalesBLL(); // sales table insert
        InvenSalesInfoDto SalInfoDTO = new InvenSalesInfoDto();
        InvenSalesDtlDto SaldtlDTO = new InvenSalesDtlDto();
        InvenSalesPaymentDto SalPayDTo = new InvenSalesPaymentDto();
        InvenSalePaymentDtlDto SalPaydtlDTO = new InvenSalePaymentDtlDto();


        CompanyBLL compBLL = new CompanyBLL();
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();
        CategoryBLL CBLL = new CategoryBLL();
        ProductBLL PBLL = new ProductBLL();
        // store branch
        InvenStoreStatusBLL BrStoreBLL = new InvenStoreStatusBLL();
        InvenStoreStatusDto BrStoreDTO = new InvenStoreStatusDto();
        // 
        InvenChangeInfoDto ChInfoDTO = new InvenChangeInfoDto();
        InvenChangeDtlDto ChDtlDTO = new InvenChangeDtlDto();
        InvenChangePaymentDto ChPayDTO = new InvenChangePaymentDto();
        InvenChangePaymentDtlDto ChPaydtlDTO = new InvenChangePaymentDtlDto();




        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetBranchId();
                Company_productEntryPnl();
                LoadCategory_productEntryPnl();
                Product_productEntryPnl();
                Unit_productEntryPnl();
            }
        }
        public void GetBranchId()
        {
            string empusername = HttpContext.Current.User.Identity.Name;
            var brid = empBLL.GetCurrentUserBranchName(empusername);

            HFBranceId.Value = brid.First().BrProId.ToString();
        }
        protected void txtCustomerName_TextChanged(object sender, EventArgs e)
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

            if (txtInvoiceNo.Text == "" && txtDate.Text == "" && txtCustomerName.Text == "" && txtContactAdd.Text == "" && txtMobileNo.Text == "" && txtRemarks.Text == "")
            {
                Show("Search By Valid Data");
            }
            else
            {
                int pid = 0;
                if (txtInvoiceNo.Text.ToString() != "")
                {
                    pid = Convert.ToInt32(txtInvoiceNo.Text);
                }
                else pid = 0;

                //  (salid, brid, CusName, CusMbNo, CusRemarks, Cuscontactadd, FromDate);

                var data = SalBLL.BranchWise_SalesInfoLaod_ChangeProduct(pid, Convert.ToInt16(HFBranceId.Value), txtCustomerName.Text.ToString(), txtMobileNo.Text.ToString(), txtContactAdd.Text.ToString(), txtRemarks.Text.ToString(), txtDate.Text.ToString());
                GvUpdate.DataSource = data;
                GvUpdate.DataBind();

                if (GvUpdate.Rows.Count <= 0)
                    Show("No Data Found !");
            }
        }

        public void LoadSalesInfoGridView()
        {
            int pid = 0;
            if (txtInvoiceNo.Text.ToString() != "")
            {
                pid = Convert.ToInt32(txtInvoiceNo.Text);
            }
            else pid = 0;
            var data = SalBLL.BranchWise_SalesInfoLaod_ChangeProduct(pid, Convert.ToInt16(HFBranceId.Value), txtCustomerName.Text.ToString(), txtMobileNo.Text.ToString(), txtContactAdd.Text.ToString(), txtRemarks.Text.ToString(), txtDate.Text.ToString());
            GvUpdate.DataSource = data;
            GvUpdate.DataBind();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }
        public void SearchClearControl()
        {
            GvUpdate.DataSource = null;
            GvUpdate.DataBind();
            GvUpdate.Visible = false;
            txtCustomerName.Text = "";
            txtMobileNo.Text = "";
            txtContactAdd.Text = "";
            txtRemarks.Text = "";
            GvUpdate.SelectedIndex = -1;
            txtDate.Text = "";
            txtInvoiceNo.Text = "";
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            SearchClearControl();
        }


        protected void GvUpdate_SelectedIndexChanged(object sender, EventArgs e)
        {
            var bb = SalBLL.BranchWise_SalesInfoLaod_ChangeProduct(Convert.ToInt32(GvUpdate.DataKeys[GvUpdate.SelectedIndex].Values["SalId"].ToString()), Convert.ToInt16(HFBranceId.Value), "", "", "", "", "");

            ddlCName.SelectedValue = bb.First().CompId.ToString();
            HFSalDtlId.Value = bb.First().SaleDtlId.ToString();
            ddlCateName.SelectedValue = bb.First().CatId.ToString();
            ddlPName.SelectedValue = bb.First().ProductId.ToString();
            ddlUnit.SelectedValue = bb.First().UnitId.ToString();
            txtPurPrice.Text = bb.First().SalePrice.ToString();
            txtPQuality.Text = bb.First().Quantity.ToString();
            // txttotalPrice.Text = bb.First().TotalPrice.ToString();
            CurrentStockLoad();
            txtCustomerName.Text = bb.First().CustomerName.ToString();
            txtMobileNo.Text = bb.First().CusMobileNo.ToString();
            txtContactAdd.Text = bb.First().CusContactAdd.ToString();
            txtRemarks.Text = bb.First().CusRemarks.ToString();

        }
        protected void GvUpdate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GvUpdate.PageIndex = e.NewPageIndex;
            LoadSalesInfoGridView();
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
        { // for branch store status  GetCurrentStockStaus(int id, int catid, int proid, int branchid, int compid, int reordervalue)
            var Quantitybr = BrStoreBLL.GetCurrentStockStaus(0, 0, Convert.ToInt32(ddlPName.SelectedValue), Convert.ToInt32(HFBranceId.Value), 0, 0);

            // var stockquan = SBLL.GetProduct(Convert.ToInt16(ddlPName.SelectedValue), "", 0, 0, 0);
            if (Quantitybr.Count != 0)
            {
                txtCurrent.Text = Quantitybr.First().QuantityStore.ToString();
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
            if (txtCustomerName.Text == "")
            {
                Show("Plz Search Invoice First!");
                return;
            }
            if (Convert.ToInt32(txtCurrent.Text) < Convert.ToInt32(txtPQuality.Text))
            {
                Show("Sales Quantity More than Available Quantity");
                return;
            }
            if (ViewState["CurrentPurData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentPurData"];
                int count = dt.Rows.Count;

                //for (int i = 0; i < count; i++)
                //{
                //    if (Convert.ToInt32(ddlPName.SelectedValue.ToString()) == Convert.ToInt32(dt.Rows[i][0].ToString()))
                //    {
                //        Show("Product Already Inserted  !");
                //        return;
                //    }
                //    if (Convert.ToInt32(ddlCName.SelectedValue) != Convert.ToInt32(dt.Rows[i][2].ToString()))
                //    {
                //        Show(" Different Company Product Not Allow !");
                //        return;
                //    }
                //}
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

        public void AddPayable()
        {
            if (GVPur.Rows.Count > 0)
            {
                double sum = 0;
                foreach (GridViewRow row in GVPur.Rows)
                {

                    sum += Convert.ToDouble(row.Cells[8].Text) * Convert.ToDouble(row.Cells[7].Text);
                }

                txtTotalPayable.Text = sum.ToString();
                txtPaidAmount.Text = sum.ToString();
                txtNetTotalPayable.Text = sum.ToString();
            }
            else
            {
                txtTotalPayable.Text = "0";
                txtNetTotalPayable.Text = "0";
                txtPaidAmount.Text = "0";

            }
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
            RbtTransectionType.SelectedIndex = -1;
            RbtChangeCause.SelectedIndex = -1;


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
            // dt.Columns.Add(new System.Data.DataColumn("Priority", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Quantity", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("UnitName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("SaleDtlId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("TransectionType", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Caused", typeof(string)));
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
                dr[0] = ddlPName.SelectedValue.ToString();
                dr[1] = ddlPName.SelectedItem.ToString();
                dr[2] = ddlCName.SelectedValue.ToString();
                dr[3] = ddlCName.SelectedItem.ToString();
                dr[4] = ddlCateName.SelectedItem.ToString();
                dr[5] = ddlCateName.SelectedValue.ToString();
                dr[6] = txtPQuality.Text;
                dr[7] = txtPurPrice.Text;
                dr[8] = ddlUnit.SelectedItem.ToString();
                dr[9] = HFSalDtlId.Value;
                dr[10] = RbtTransectionType.SelectedItem.ToString();
                dr[11] = RbtChangeCause.SelectedItem.ToString();
                dt.Rows.Add(dr);

            }
            else
            {

                dr = dt.NewRow();
                dr[0] = ddlPName.SelectedValue.ToString();
                dr[1] = ddlPName.SelectedItem.ToString();
                dr[2] = ddlCName.SelectedValue.ToString();
                dr[3] = ddlCName.SelectedItem.ToString();
                dr[4] = ddlCateName.SelectedItem.ToString();
                dr[5] = ddlCateName.SelectedValue.ToString();
                dr[6] = txtPQuality.Text;
                dr[7] = txtPurPrice.Text;
                dr[8] = ddlUnit.SelectedItem.ToString();
                dr[9] = HFSalDtlId.Value;
                dr[10] = RbtTransectionType.SelectedItem.ToString();
                dr[11] = RbtChangeCause.SelectedItem.ToString();
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
            AddPayable();
        }




        protected void rdoPayment_SelectedIndexChanged(object sender, EventArgs e)
        {

            if (rdoPayment.SelectedIndex == 0)
            {

                pnlBank.Visible = false;
            }
            else
            {
                pnlBank.Visible = true;

            }

        }

        protected void txtVatPercentage_TextChanged(object sender, EventArgs e)
        {
            VatCalculation();

        }

        private void VatCalculation()
        {
            if (txtVatPercentage.Text == "")
            {
                txtVatPercentage.Text = "0";
                txtVatAfterpercentage.Text = Convert.ToString(Convert.ToDouble(txtTotalPayable.Text) * Convert.ToDouble(txtVatPercentage.Text) / 100);
                txtNetTotalPayable.Text = Convert.ToString(Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text));
                txtPaidAmount.Text = Convert.ToString(txtNetTotalPayable.Text);
                txtDueAmount.Text = "0";
                txtDicountpercentage.Text = "0";
                txtVatAfterpercentage.Text = "0";
                txtDicountAfterpercentage.Text = "0";
            }
            else
            {
                txtVatAfterpercentage.Text = Convert.ToString(Convert.ToDouble(txtTotalPayable.Text) * Convert.ToDouble(txtVatPercentage.Text) / 100);
                txtNetTotalPayable.Text = Convert.ToString(Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text));
                txtPaidAmount.Text = Convert.ToString(Convert.ToDouble(txtNetTotalPayable.Text));
                txtDueAmount.Text = "0";

            }
        }
        protected void txtDicountpercentage_TextChanged(object sender, EventArgs e)
        {
            DiscountCalulation();
        }
        private void DiscountCalulation()
        {
            if (txtDicountpercentage.Text == "")
            {
                txtDicountpercentage.Text = "0";
                txtDicountAfterpercentage.Text = Convert.ToString((Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text)) * Convert.ToDouble(txtDicountpercentage.Text) / 100);
                txtNetTotalPayable.Text = Convert.ToString((Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text)) - Convert.ToDouble(txtDicountAfterpercentage.Text));
                txtPaidAmount.Text = Convert.ToString((Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text)) - Convert.ToDouble(txtDicountAfterpercentage.Text));
                txtDueAmount.Text = "0";
                txtDicountAfterpercentage.Text = "0";
                //  txtVatAfterpercentage.Text = "0";
                // txtDicountAfterpercentage.Text = "0";

            }
            else
            {

                txtDicountAfterpercentage.Text = Convert.ToString((Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text)) * Convert.ToDouble(txtDicountpercentage.Text) / 100);
                txtNetTotalPayable.Text = Convert.ToString((Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text)) - Convert.ToDouble(txtDicountAfterpercentage.Text));
                txtPaidAmount.Text = Convert.ToString((Convert.ToDouble(txtTotalPayable.Text) + Convert.ToDouble(txtVatAfterpercentage.Text)) - Convert.ToDouble(txtDicountAfterpercentage.Text));
                txtDueAmount.Text = "0";

            }
        }

        protected void BtnDiscountCal_Click(object sender, EventArgs e)
        {
            DiscountCalulation();
        }

        protected void BtnPaidAmount_Click(object sender, EventArgs e)
        {
            PaidAmount();
        }
        private void PaidAmount()
        {
            if (Convert.ToDouble(txtNetTotalPayable.Text) >= Convert.ToDouble(txtPaidAmount.Text))
            {
                txtDueAmount.Text = Convert.ToString(Convert.ToDouble(txtNetTotalPayable.Text) - Convert.ToDouble(txtPaidAmount.Text));

            }
            else
            {
                txtDueAmount.Text = "0";
                txtPaidAmount.Text = txtNetTotalPayable.Text;
            }
        }

        protected void txtPaidAmount_TextChanged(object sender, EventArgs e)
        {
            PaidAmount();
        }

        protected void btnVatcalculation_Click(object sender, EventArgs e)
        {
            VatCalculation();
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            ChInfoDTO.CreateBy = "tarun";
            //ChInfoDTO.SalId = Convert.ToInt32(HFSaleId.Value);
            ChInfoDTO.CreateDate = System.DateTime.Now;
            ChInfoDTO.BrProId = Convert.ToInt32(HFBranceId.Value);
            ChInfoDTO.CustomerName = txtCustomerName.Text;
            ChInfoDTO.CusMobileNo = txtMobileNo.Text;
            ChInfoDTO.CusContactAdd = txtContactAdd.Text;
            ChInfoDTO.CusRemarks = txtRemarks.Text;
            CHBLL.SaveChangeInfo(ChInfoDTO);

            SalInfoDTO.CreateBy = "tarun";
            //ChInfoDTO.SalId = Convert.ToInt32(HFSaleId.Value);
            SalInfoDTO.CreateDate = System.DateTime.Now;
            SalInfoDTO.BrProId = Convert.ToInt32(HFBranceId.Value);
            SalInfoDTO.CustomerName = txtCustomerName.Text;
            SalInfoDTO.CusMobileNo = txtMobileNo.Text;
            SalInfoDTO.CusContactAdd = txtContactAdd.Text;
            SalInfoDTO.CusRemarks = txtRemarks.Text;
            SalBLL.SaveSalesInfo(SalInfoDTO);
            var salid = SalBLL.LaadSalInofId();
            int SalID = salid.First().SalId;


            var changeid = CHBLL.LoadChangeInofId();
            int ChangeID = changeid.First().ChangeId;

            DataTable dt = (DataTable)ViewState["CurrentPurData"];
            int count = dt.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                // change dtl tabel
                ChDtlDTO.ChangeId = ChangeID;
                ChDtlDTO.SalePrice = Convert.ToDouble(dt.Rows[i][7]);
                ChDtlDTO.Quantity = Convert.ToInt32(dt.Rows[i][6]);
                ChDtlDTO.SaleDtlId = Convert.ToInt32(dt.Rows[i][9]);
                ChDtlDTO.ProductId = Convert.ToInt32(dt.Rows[i][0]);
                ChDtlDTO.TransectionType = Convert.ToString(dt.Rows[i][10]);
                ChDtlDTO.Caused = Convert.ToString(dt.Rows[i][11]);
                ChDtlDTO.CentranlReturnStatus = "0";
                CHBLL.SaveChangeDtl(ChDtlDTO);


                // save sal dtl table
                SaldtlDTO.SalId = SalID;
                SaldtlDTO.SalePrice = Convert.ToDouble(dt.Rows[i][7]);
                SaldtlDTO.Quantity = Convert.ToInt32(dt.Rows[i][6]);
                SaldtlDTO.ProductId = Convert.ToInt32(dt.Rows[i][0]);
                SaldtlDTO.TransectionType = Convert.ToString(dt.Rows[i][10]);
                SalBLL.SaveSalesDtl(SaldtlDTO);


                SaldtlDTO.SaleDtlId = Convert.ToInt32(dt.Rows[i][9]);
                SaldtlDTO.TransectionType = Convert.ToString(dt.Rows[i][10]);
                SalBLL.Edit_ChangeProductPage(SaldtlDTO);


                var product_saldtl = SalBLL.LaodProductId_FromSaledtltable(Convert.ToInt32(dt.Rows[i][9]));

                int productid = product_saldtl.First().ProductId;
                if (productid == Convert.ToInt32(dt.Rows[i][0]))
                {
                }
                else
                {
                    // for branch store status for current sales/ change product subract
                    var Quantitybr = BrStoreBLL.GetCurrentStockStaus(0, 0, Convert.ToInt32(dt.Rows[i][0]), Convert.ToInt32(HFBranceId.Value), 0, 0);
                    BrStoreDTO.BrProId = Convert.ToInt32(HFBranceId.Value);
                    BrStoreDTO.ProductId = Convert.ToInt32(dt.Rows[i][0]);
                    BrStoreDTO.InvenStoreId = Convert.ToInt32(Quantitybr.First().InvenStoreId);
                    BrStoreDTO.QuantityStore = Convert.ToInt32(Quantitybr.First().QuantityStore - Convert.ToInt16(dt.Rows[i][6]));
                    BrStoreBLL.Edit(BrStoreDTO);

                    // for branch store status for current sales/ change product Addition
                    var Quantitybr_change = BrStoreBLL.GetCurrentStockStaus(0, 0, productid, Convert.ToInt32(HFBranceId.Value), 0, 0);
                    BrStoreDTO.BrProId = Convert.ToInt32(HFBranceId.Value);
                    BrStoreDTO.ProductId = productid;
                    BrStoreDTO.InvenStoreId = Convert.ToInt32(Quantitybr_change.First().InvenStoreId);
                    BrStoreDTO.QuantityStore = Convert.ToInt32(Convert.ToInt16(dt.Rows[i][6]) + Quantitybr.First().QuantityStore);
                    BrStoreBLL.Edit(BrStoreDTO);
                }
            }
            // change payment table
            ChPayDTO.PaidAmount = Convert.ToDouble(txtPaidAmount.Text);
            ChPayDTO.DueAmount = Convert.ToDouble(txtDueAmount.Text);
            ChPayDTO.Discount = Convert.ToDouble(txtDicountAfterpercentage.Text);
            ChPayDTO.TotalPrice = Convert.ToDouble(txtTotalPayable.Text);
            ChPayDTO.ChangeId = ChangeID;
            ChPayDTO.Vat = Convert.ToDouble(txtVatAfterpercentage.Text);
            ChPayDTO.DiscountDescription = txtDiscountDescription.Text;
            CHBLL.SaveChangePaymentInfo(ChPayDTO);
            // sal payment table
            SalPayDTo.PaidAmount = Convert.ToDouble(txtPaidAmount.Text);
            SalPayDTo.DueAmount = Convert.ToDouble(txtDueAmount.Text);
            SalPayDTo.Discount = Convert.ToDouble(txtDicountAfterpercentage.Text);
            SalPayDTo.TotalPrice = Convert.ToDouble(txtTotalPayable.Text);
            SalPayDTo.SalId = SalID;
            SalPayDTo.Vat = Convert.ToDouble(txtVatAfterpercentage.Text);
            SalPayDTo.DiscountDescription = txtDiscountDescription.Text;
            SalBLL.SaveSalesPaymentInfo(SalPayDTo);

            // change payment dtl table
            ChPaydtlDTO.ChangeId = ChangeID;
            ChPaydtlDTO.PaymentMode = rdoPayment.SelectedValue.ToString();
            ChPaydtlDTO.PaidAmount = Convert.ToDouble(txtPaidAmount.Text);
            ChPaydtlDTO.Note = txtNote.Text;
            ChPaydtlDTO.PaymentDate = System.DateTime.Now;
            ChPaydtlDTO.PaymentBy = "tarun";
            ChPaydtlDTO.CardNo = txtCardNo.Text;
            ChPaydtlDTO.ApprCode = txtApprCode.Text;
            ChPaydtlDTO.BankName = txtBankName.Text;
            ChPaydtlDTO.HolderName = txtHolderName.Text;
            CHBLL.SaveChangePaymentDtl(ChPaydtlDTO);
            // sal payment dtl table
            SalPaydtlDTO.SalId = SalID;
            SalPaydtlDTO.PaymentMode = rdoPayment.SelectedValue.ToString();
            SalPaydtlDTO.PaidAmount = Convert.ToDouble(txtPaidAmount.Text);
            SalPaydtlDTO.Note = txtNote.Text;
            SalPaydtlDTO.PaymentDate = System.DateTime.Now;
            SalPaydtlDTO.PaymentBy = "tarun";
            SalPaydtlDTO.CardNo = txtCardNo.Text;
            SalPaydtlDTO.ApprCode = txtApprCode.Text;
            SalPaydtlDTO.BankName = txtBankName.Text;
            SalPaydtlDTO.HolderName = txtHolderName.Text;
            SalBLL.SaveSalesPaymentDtl(SalPaydtlDTO);


            ClearPaymentMode();
            Show("Change Data Save Sucessfully");

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Shop/Report/BranchSalesRptUI.aspx?SalId=" + SalID.ToString() + "');", true);



        }
        private void ClearPaymentMode()
        {
            pnlAction.Visible = false;
            GvUpdate.DataSource = null;
            GvUpdate.DataBind();
            GvUpdate.Visible = false;
            txtDate.Text = "";
            txtInvoiceNo.Text = "";


            this.ViewState["CurrentPurData"] = null;
            DataTable dt = new DataTable();
            GVPur.DataSource = dt;
            GVPur.DataBind();
            txtCustomerName.Text = "";
            txtMobileNo.Text = "";
            txtContactAdd.Text = "";
            txtRemarks.Text = "";
            txtApprCode.Text = "";
            txtBankName.Text = "";
            txtCardNo.Text = "";
            txtDicountAfterpercentage.Text = "0";
            txtDicountpercentage.Text = "";
            txtDueAmount.Text = "0";
            txtHolderName.Text = "";
            txtPaidAmount.Text = "";
            txtTotalPayable.Text = "0";
            txtVatAfterpercentage.Text = "0";
            txtVatPercentage.Text = "";
            txtNetTotalPayable.Text = "";
            txtNote.Text = "";


        }

        protected void btnCancelPurchase_Click(object sender, EventArgs e)
        {
            ClearPaymentMode();
        }
    }
}