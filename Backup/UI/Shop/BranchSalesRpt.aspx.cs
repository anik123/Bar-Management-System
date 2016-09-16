using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Data;
using BLL;
using DTO;
using ABLL;
using ADTO;

namespace UI.Shop
{
    public partial class BranchSalesRpt : System.Web.UI.Page
    {
        CompanyBLL compBLL = new CompanyBLL();
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();
        CategoryBLL CBLL = new CategoryBLL();
        ProductBLL PBLL = new ProductBLL();
        // store branch
        InvenStoreStatusBLL BrStoreBLL = new InvenStoreStatusBLL();
        InvenStoreStatusDto BrStoreDTO = new InvenStoreStatusDto();
        // Sales  
        InvenSalesBLL SaleBLL = new InvenSalesBLL();
        InvenSalesInfoDto SalInfoDTO = new InvenSalesInfoDto();
        InvenSalesDtlDto SaldtlDTO = new InvenSalesDtlDto();
        InvenSalesPaymentDto SalPayDTO = new InvenSalesPaymentDto();
        InvenSalePaymentDtlDto SalpayDtlDTO = new InvenSalePaymentDtlDto();


        // jopurnal
        JournalDTO JDTO = new JournalDTO();
        JournalBLL JBLL = new JournalBLL();

        // transection dtl 
        TransDetailsBLL TranBLL = new TransDetailsBLL();
        TransDetailsDTO TranDTO = new TransDetailsDTO();

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
        private void Company_productEntryPnl()
        {

            var query = compBLL.SearchComInfo(0, "", "", "");

            var list = ddlCName.Items.Cast<ListItem>().Select(item => item.Value).ToList();
            list.Sort();
            ddlCName.DataSource = query;//.OrderBy(Items => Items.CompName);

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
            Purchase_PriceLoad();
        }
        private void Purchase_PriceLoad()
        {
            var data = SaleBLL.LastPurchasePrice_ProductWise(Convert.ToInt32(ddlPName.SelectedValue));

            txtPurPrice.Text = data.Last().PurchasePrice.ToString();
        }
        protected void ddlCateName_SelectedIndexChanged(object sender, EventArgs e)
        {
            Product_productEntryPnl();
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearAddToOrder();

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
            if (Convert.ToInt32(txtCurrent.Text) < Convert.ToInt32(txtPQuality.Text))
            {
                Show("Sales Quantity More than Available Quantity");
                return;
            }
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

        public void AddPayable()
        {
            if (GVPur.Rows.Count > 0)
            {
                double sum = 0;
                foreach (GridViewRow row in GVPur.Rows)
                {

                    sum += Convert.ToDouble(row.Cells[6].Text) * Convert.ToDouble(row.Cells[7].Text);
                }

                txtTotalPayable.Text = sum.ToString();
                txtNetTotalPayable.Text = sum.ToString();
                txtPaidAmount.Text = sum.ToString();
            }
            else
            {
                txtTotalPayable.Text = "0";
                txtPaidAmount.Text = "0";
                txtNetTotalPayable.Text = "0";
            }
        }
        public void ClearAddToOrder()
        {
            ddlUnit.SelectedValue = "0";
            ddlPName.SelectedValue = "0";
            ddlCName.SelectedValue = "0";
            ddlCateName.SelectedValue = "0";
            txtPQuality.Text = "";
            txtPurPrice.Text = "";
            txtCurrent.Text = "0";


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
            dt.Columns.Add(new System.Data.DataColumn("Quantity", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("UnitPrice", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("UnitName", typeof(String)));
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
                txtPaidAmount.Text = Convert.ToString(Convert.ToDouble(txtNetTotalPayable.Text));
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

            SalInfoDTO.CreateBy = "tarun";
            SalInfoDTO.CreateDate = System.DateTime.Now;
            SalInfoDTO.BrProId = Convert.ToInt32(HFBranceId.Value);
            SalInfoDTO.CustomerName = txtCustomerName.Text;
            SalInfoDTO.CusMobileNo = txtMobileNo.Text;
            SalInfoDTO.CusContactAdd = txtContactAdd.Text;
            SalInfoDTO.CusRemarks = txtRemarks.Text;
            SaleBLL.SaveSalesInfo(SalInfoDTO);

            var salid = SaleBLL.LaadSalInofId();
            int Salid = salid.First().SalId;

            DataTable dt = (DataTable)ViewState["CurrentPurData"];
            int count = dt.Rows.Count;
            for (int i = 0; i < count; i++)
            {


                SaldtlDTO.SalePrice = Convert.ToDouble(dt.Rows[i][7]);
                SaldtlDTO.Quantity = Convert.ToInt32(dt.Rows[i][6]);
                SaldtlDTO.SalId = Salid;
                SaldtlDTO.ProductId = Convert.ToInt32(dt.Rows[i][0]);
                SaleBLL.SaveSalesDtl(SaldtlDTO);
                // for branch store status  GetCurrentStockStaus(int id, int catid, int proid, int branchid, int compid, int reordervalue)
                var Quantitybr = BrStoreBLL.GetCurrentStockStaus(0, 0, Convert.ToInt32(dt.Rows[i][0]), Convert.ToInt32(HFBranceId.Value), 0, 0);

                BrStoreDTO.BrProId = Convert.ToInt32(HFBranceId.Value);
                BrStoreDTO.ProductId = Convert.ToInt32(dt.Rows[i][0]);
                BrStoreDTO.InvenStoreId = Convert.ToInt32(Quantitybr.First().InvenStoreId);
                BrStoreDTO.QuantityStore = Convert.ToInt32(Convert.ToInt16(dt.Rows[i][6]) + Quantitybr.First().QuantityStore);
                BrStoreBLL.Edit(BrStoreDTO);
            }
            SalPayDTO.PaidAmount = Convert.ToDouble(txtPaidAmount.Text);
            SalPayDTO.DueAmount = Convert.ToDouble(txtDueAmount.Text);
            SalPayDTO.Discount = Convert.ToDouble(txtDicountAfterpercentage.Text);
            SalPayDTO.TotalPrice = Convert.ToDouble(txtNetTotalPayable.Text);
            SalPayDTO.SalId = Salid;
            SalPayDTO.Vat = Convert.ToDouble(txtVatAfterpercentage.Text);
            SalPayDTO.DiscountDescription = txtDiscountDescription.Text;
            SaleBLL.SaveSalesPaymentInfo(SalPayDTO);


            SalpayDtlDTO.SalId = Salid;
            SalpayDtlDTO.PaymentMode = rdoPayment.SelectedValue.ToString();
            SalpayDtlDTO.PaidAmount = Convert.ToDouble(txtPaidAmount.Text);
            SalpayDtlDTO.Note = txtNote.Text;
            SalpayDtlDTO.PaymentDate = System.DateTime.Now;
            SalpayDtlDTO.PaymentBy = "tarun";
            SalpayDtlDTO.CardNo = txtCardNo.Text;
            SalpayDtlDTO.ApprCode = txtApprCode.Text;
            SalpayDtlDTO.BankName = txtBankName.Text;
            SalpayDtlDTO.HolderName = txtHolderName.Text;
            SaleBLL.SaveSalesPaymentDtl(SalpayDtlDTO);
            // start Journal Insert

            List<JournalDTO> jt = new List<JournalDTO>();
            jt = JBLL.Load_Journal_Transection_No();

            int TransectionNO;
            if (jt.Count == 0)
            {
                TransectionNO = 1;

            }
            else
            {
                TransectionNO = Convert.ToInt32(jt.First().TransectionNo.ToString()) + 1;
            }
            var trandata = TranBLL.LoadTransDetailsData(2);// purchase transection Item
            JDTO.JournalType = "DR";
            JDTO.COAId = trandata.First().DRCOAId;
            JDTO.SubCode2Id = trandata.First().DRSubCoId2;
            JDTO.SubVoucherId = trandata.First().DrSubVoucherId;
            JDTO.DRAmount = Convert.ToDouble(txtPaidAmount.Text);
            JDTO.CRAmount = null;
            JDTO.VONO = "";
            JDTO.MRNO = "";
            JDTO.Remarks = txtNote.Text;
            JDTO.TransectionNo = TransectionNO;
            JDTO.TransectionDate = System.DateTime.Now;
            JDTO.PostLeadgerStatus = "N";
            JDTO.CreateBy = HttpContext.Current.User.Identity.Name;// HttpContext.Current.User.Identity.Name;
            JDTO.CreateDate = System.DateTime.Now;
            JBLL.Add(JDTO);


            JDTO.JournalType = "CR";
            JDTO.COAId = trandata.First().CRCOAId;
            JDTO.SubCode2Id = trandata.First().CRSubCoId2;
            JDTO.SubVoucherId = trandata.First().CrSubVoucherId;
            JDTO.DRAmount = null;
            JDTO.CRAmount = Convert.ToDouble(txtPaidAmount.Text);
            JDTO.VONO = "";
            JDTO.MRNO = "";
            JDTO.Remarks = "";
            JDTO.TransectionNo = TransectionNO;
            JDTO.TransectionDate = System.DateTime.Now;
            JDTO.PostLeadgerStatus = "N";
            JDTO.CreateBy = HttpContext.Current.User.Identity.Name;// HttpContext.Current.User.Identity.Name;
            JDTO.CreateDate = System.DateTime.Now;
            JBLL.Add(JDTO);
            if (txtDueAmount.Text != "0")
            {

                JDTO.JournalType = "CR";
                JDTO.COAId = 43;
                JDTO.SubCode2Id = 13;
                JDTO.SubVoucherId = 3;
                JDTO.DRAmount = null;
                JDTO.CRAmount = Convert.ToDouble(txtDueAmount.Text);
                JDTO.VONO = "";
                JDTO.MRNO = "";
                JDTO.Remarks = "";
                JDTO.TransectionNo = TransectionNO;
                JDTO.TransectionDate = System.DateTime.Now;
                JDTO.PostLeadgerStatus = "N";
                JDTO.CreateBy = HttpContext.Current.User.Identity.Name;// HttpContext.Current.User.Identity.Name;
                JDTO.CreateDate = System.DateTime.Now;
                JBLL.Add(JDTO);
            }
            //// End Journal Insert
            ClearPaymentMode();
            Show("Sales Data Save Sucessfully");
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Shop/Report/BranchSalesRptUI.aspx?SalId=" + Salid.ToString() + "');", true);
        }

        protected void btnCancelPurchase_Click(object sender, EventArgs e)
        {
            ClearPaymentMode();
        }
        private void ClearPaymentMode()
        {
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

        }
    }
}