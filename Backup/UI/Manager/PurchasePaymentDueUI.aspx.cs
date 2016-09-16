using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using PBLL;
using PDTO;
using DTO;

namespace UI.Manager
{
    public partial class PurchasePaymentDueUI : System.Web.UI.Page
    {

        CompanyBLL CompBLL = new CompanyBLL();
        InvenCentralPurchseBLL PurchseBLL = new InvenCentralPurchseBLL();
        AssetBLL AssBLL = new AssetBLL(); // Current asset
        BankTransectionBLL TBLL = new BankTransectionBLL();// each bank account balence
        BankTransectionDTO TDTO = new BankTransectionDTO();
        BankAccountInfoBLL ABLL = new BankAccountInfoBLL();//load account info
        AssetDTO AssDTO = new AssetDTO();

        InvenCentralPurchasePaymentDTO PaymentDTO = new InvenCentralPurchasePaymentDTO();

        InvenCentralPurchasePaymentDtlDto PayDtlDTO = new InvenCentralPurchasePaymentDtlDto();


        PurchaseDueBLL PayDueBLL = new PurchaseDueBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCompanyName();
                loadDataGVInfo();
                loadAccountName();
                var assetAmount = AssBLL.Asset_Current();
                lblTotalBankAmount.Text = assetAmount.First().BankAmount_Current.ToString();

            }

        }

        private void loadAccountName()
        {

            var query = ABLL.AccountNameLoad();
            ddlBank.DataSource = query;
            ddlBank.DataTextField = "AccountAllName";
            ddlBank.DataValueField = "AccountInfoId";
            ddlBank.DataBind();
            ddlBank.Items.Insert(0, new ListItem("Select Dept Name", "0"));

        }
        private void LoadCompanyName()
        {
            var data = CompBLL.SearchComInfo(0, "", "", "");
            ddlCompanyName.DataSource = data;
            ddlCompanyName.DataTextField = "CompName";
            ddlCompanyName.DataValueField = "CompId";
            ddlCompanyName.DataBind();
            ddlCompanyName.Items.Insert(0, new ListItem("Select Company Name", "0"));
        }

        private void loadDataGVInfo()
        {
            var data = PayDueBLL.CentralPurchase_Due_Payment(0, 0, 0, "", "", "");
            GvDueInfo.DataSource = data;
            GvDueInfo.DataBind();
        }

        protected void GvDueInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDueInfo.PageIndex = e.NewPageIndex;
            loadDataGVInfo();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnSearchCancel_Click(object sender, EventArgs e)
        {
            SearchClear();
        }
        public void SearchClear()
        {
            loadDataGVInfo();
            GvDueInfo.SelectedIndex = -1;
            ddlCompanyName.SelectedValue = "0";
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            txtOrderNO.Text = "";
            txtPurchaseInvoiceNO.Text = "";
            txtSalesManName.Text = "";
        }

        protected void txtSearch(object sender, EventArgs e)
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
            if (txtPurchaseInvoiceNO.Text == "" && txtOrderNO.Text == "" && ddlCompanyName.SelectedValue == "0" && txtSalesManName.Text == "" && txtDateTo.Text == "" && txtDateFrom.Text == "")
            {
                Show("Search By Valid Data");
            }
            else
            {
                int pid = 0;
                if (txtPurchaseInvoiceNO.Text.ToString() != "")
                {
                    pid = Convert.ToInt32(txtPurchaseInvoiceNO.Text);
                }
                else pid = 0;

                int orid = 0;
                if (txtOrderNO.Text.ToString() != "")
                {
                    orid = Convert.ToInt32(txtOrderNO.Text);
                }
                else orid = 0;

                var data = PayDueBLL.CentralPurchase_Due_Payment(pid, orid, Convert.ToInt16(ddlCompanyName.SelectedValue), txtSalesManName.Text.ToString(), txtDateFrom.Text.ToString(), txtDateTo.Text.ToString());
                GvDueInfo.DataSource = data;
                GvDueInfo.DataBind();

                if (GvDueInfo.Rows.Count <= 0)
                    Show("No Data Found !");
            }
        }

        protected void GvDueInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            int purid = Convert.ToInt32(GvDueInfo.DataKeys[GvDueInfo.SelectedIndex].Values["PurId"].ToString());
            var bb = PayDueBLL.CentralPurchase_Due_Payment(purid, 0, 0, "", "", "");
            txtSalesManNamePayment.Text = bb.First().SalesManName.ToString();
            txtTotalPayable.Text = bb.First().DueAmount.ToString();
            txtPaidAmoun.Text = bb.First().DueAmount.ToString();
            HFPhamrPaymentID.Value = bb.First().PurPaymentId.ToString();
            HFPurId.Value = bb.First().PurId.ToString();
            HFTotalPrice.Value = bb.First().TotalPrice.ToString();
        }
        protected void LinkButton_Command_GvDueInfo_ProductInfo(object sender, CommandEventArgs e)
        {
            var bb = PayDueBLL.CentralPurchase_Due_Payment(Convert.ToInt32(e.CommandArgument.ToString()), 0, 0, "", "", "");
            int PurId = bb.First().PurId;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Manager/Report/PurchaseProductRptUI.aspx?PurId=" + PurId.ToString() + "');", true);
        }

        protected void rdoPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTotalPayable.Text == "")
            {
                Show(" Plz Search First");
                txtTotalPayable.Focus();
                return;
            }
            if (rdoPayment.SelectedValue == "Cash")
            {
                pnlBank.Visible = false;
                lblCashLbl.Visible = true;
                lblCashAount.Visible = true;
                txtPaidAmoun.Text = Convert.ToString(Convert.ToDouble(txtTotalPayable.Text));

                LoadCurrentCashAmount();// load cash amount
                if (lblCashAount.Text.ToString() == "0" || Convert.ToDouble(lblCashAount.Text) < Convert.ToDouble(txtPaidAmoun.Text) || Convert.ToDouble(txtTotalPayable.Text) < Convert.ToDouble(txtPaidAmoun.Text))
                {
                    txtPaidAmoun.Text = "";
                }
                else
                {
                    txtDueAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalPayable.Text) - Convert.ToDouble(txtPaidAmoun.Text));
                }
            }
            else
            {
                pnlBank.Visible = true;
                lblCashLbl.Visible = false;
                lblCashAount.Visible = false;
            }
        }
        public void LoadCurrentCashAmount()
        {
            var amount = AssBLL.Asset_Current();
            if (amount.Count != 0)
            {
                if (amount.First().CashAmount_Current == null)
                {
                    lblCashAount.Text = "0";
                }
                else
                {
                    lblCashAount.Text = amount.First().CashAmount_Current.ToString();
                }
            }
            else
            {
                lblCashAount.Text = "0";
            }
        }
        public void LoadCurrentBankAmount_AccountWise()
        {

            var amount = TBLL.LoadBankTransection(Convert.ToInt16(ddlBank.SelectedValue));
            if (amount.Count == 0)
            {
                lblBankAmount.Text = "0";
            }
            else
            {
                lblBankAmount.Text = Convert.ToString(amount.First().BankAmount.ToString());
            }
        }
        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCurrentBankAmount_AccountWise();
        }

        protected void txtPaidAmoun_TextChanged(object sender, EventArgs e)
        {
            PaidAmount();

        }
        public void PaidAmount()
        {
            if (txtPaidAmoun.Text == "")
            {
                Show("Plz Insert Paid Amount !");
            }
            else
            {
                if (rdoPayment.SelectedValue == "Cash")
                {
                    if (Convert.ToDouble(lblCashAount.Text) < Convert.ToDouble(txtPaidAmoun.Text))
                    {
                        Show("Paid Amount > Current Amount");
                        return;
                    }
                }
                if (Convert.ToDouble(txtTotalPayable.Text.ToString()) < Convert.ToDouble(txtPaidAmoun.Text.ToString()))
                {
                    Show(" Your Paid Amount > Total Payable Amount");
                    txtPaidAmoun.Text = "";
                }
                else
                {
                    txtDueAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalPayable.Text) - Convert.ToDouble(txtPaidAmoun.Text));
                }
            }
        }

        protected void BtnPaid_Click(object sender, EventArgs e)
        {
            PaidAmount();
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (txtTotalPayable.Text == "")
            {
                Show(" Plz Select You Want TO Pay");
                return;
            }
            if (rdoPayment.SelectedValue == "Bank")
            {
                if (ddlBank.SelectedValue.ToString() == "0")
                {
                    ddlBank.Focus();
                    return;
                }
                if (txtLCNumber.Text.ToString() == "")
                {
                    txtLCNumber.Focus();
                    return;
                }
                if (txtChequeNo.Text.ToString() == "")
                {
                    txtChequeNo.Focus();
                    return;
                }
                if (txtIssueDate.Text.ToString() == "")
                {
                    txtIssueDate.Focus();
                    return;
                }

                if (Convert.ToDouble(lblTotalBankAmount.Text) < Convert.ToDouble(txtPaidAmoun.Text))
                {
                    Show("Paid Amount > Total Bank Amount");
                    return;
                }
                if (Convert.ToDouble(lblBankAmount.Text.ToString()) < Convert.ToDouble(txtPaidAmoun.Text.ToString()))
                {
                    Show("Payable Amount > Cureent Account Amount !");
                    return;
                }
            }
            else
            {
                if (txtPaidAmoun.Text.ToString() == "")
                {
                    txtPaidAmoun.Focus();
                    return;
                }
                if ((Convert.ToInt32(txtPaidAmoun.Text)) > (Convert.ToInt32(lblCashAount.Text)))
                {
                    Show("Paid Amount > Current Cash Amount");

                    txtPaidAmoun.Focus();
                    return;
                }
            }

            PayDtlDTO.PaymentMode = rdoPayment.SelectedItem.ToString();
            PayDtlDTO.PaidAmount = Convert.ToDouble(txtPaidAmoun.Text);
            PayDtlDTO.DueAmount = Convert.ToDouble(txtDueAmount.Text);
            PayDtlDTO.Note = txtNote.Text.ToString();
            PayDtlDTO.PaymentDate = System.DateTime.Now;
            PayDtlDTO.PaymentBy = HttpContext.Current.User.Identity.Name;

            if (ddlBank.SelectedValue.ToString() != "0")
                PayDtlDTO.AccountInfoId = Convert.ToInt32(ddlBank.SelectedValue);
            if (txtChequeNo.Text.ToString() != "")
                PayDtlDTO.ChequeNo = txtChequeNo.Text.ToString();
            if (txtChequeDate.Text.ToString() != "")
                PayDtlDTO.ChequeDate = Convert.ToDateTime(txtChequeDate.Text);
            if (txtIssueDate.Text.ToString() != "")
                PayDtlDTO.IssDate = Convert.ToDateTime(txtIssueDate.Text);
            if (txtLCNumber.Text.ToString() != "")
                PayDtlDTO.LCNumber = txtLCNumber.Text.ToString();
            PayDtlDTO.TotalPrice = Convert.ToDouble(HFTotalPrice.Value);
            PayDtlDTO.PurPaymentId = Convert.ToInt32(HFPhamrPaymentID.Value);
            PayDtlDTO.DueAmount = Convert.ToDouble(txtDueAmount.Text);
            PayDueBLL.SavePurchasePaymentDtl_Pay_Due(PayDtlDTO);
            var paydtl = PurchseBLL.LoadPharmPaymentDtlId();
            int PurPayDtlId = paydtl.First().PurPayDtlId;
            // start edit current  payment 
            var data = PayDueBLL.CentralPurchase_Due_Payment(Convert.ToInt32(HFPurId.Value), 0, 0, "", "", "");

            PaymentDTO.PurId = Convert.ToInt32(HFPurId.Value);
            PaymentDTO.PurPaymentId = Convert.ToInt32(HFPhamrPaymentID.Value);
            PaymentDTO.PaidAmount = Convert.ToDouble(data.First().PaidAmount) + Convert.ToDouble(txtPaidAmoun.Text);
            PaymentDTO.DueAmount = Convert.ToDouble(data.First().DueAmount) - Convert.ToDouble(txtPaidAmoun.Text);
            PaymentDTO.FirstPaymentStatus = "1";
            PurchseBLL.EditPurchasePayment(PaymentDTO);
            // end edit current payment 

            // asset  transection  bank transection
            if (rdoPayment.SelectedValue == "Cash")
            {
                var assetAmount = AssBLL.Asset_Current();
                AssDTO.AssetId = assetAmount.First().AssetId;
                AssDTO.BankAmount_Current = assetAmount.First().BankAmount_Current;
                AssDTO.CashAmount_Current = Convert.ToDouble(assetAmount.First().CashAmount_Current) - Convert.ToDouble(txtPaidAmoun.Text);
                AssBLL.Edit(AssDTO);
            }
            else
            {
                var bankamount = TBLL.LoadBankTransection(Convert.ToInt16(ddlBank.SelectedValue));
                TDTO.BankTransectionId = bankamount.First().BankTransectionId;
                TDTO.AccountInfoId = bankamount.First().AccountInfoId;

                TDTO.BankAmount = Convert.ToDouble(bankamount.First().BankAmount) - Convert.ToDouble(txtPaidAmoun.Text);
                TBLL.Edit(TDTO);

                var assetAmount = AssBLL.Asset_Current();
                AssDTO.AssetId = assetAmount.First().AssetId;
                AssDTO.CashAmount_Current = assetAmount.First().CashAmount_Current;
                AssDTO.BankAmount_Current = Convert.ToDouble(assetAmount.First().BankAmount_Current) - Convert.ToDouble(txtPaidAmoun.Text);
                AssBLL.Edit(AssDTO);
            }
            // asset  transection  bank transection
            if (GvDueInfo.Rows.Count < 0)
                pnlRec.Visible = false;
            else
                pnlRec.Visible = true;

            // reporting data pharm pay dtl 

            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Manager/Report/CentralPurchasePaymentRptUI.aspx?PurPayDtlId=" + PurPayDtlId.ToString() + "');", true);
            ClearPrint();
        }
        protected void LinkButton_Command_GvDueInfo_ViewDtl(object sender, CommandEventArgs e)
        {
            int purid;

            var bb = PayDueBLL.GetPurchaseDue(Convert.ToInt32(e.CommandArgument.ToString()), 0, "");
            purid = Convert.ToInt32(bb.First().PurId.ToString());
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Manager/PurchasePaymaentDetailViewUI.aspx?purid=" + purid.ToString() + "');", true);
        }
        protected void btnCancelPurchase_Click(object sender, EventArgs e)
        {
            ClearPrint();
        }
        private void ClearPrint()
        {
            SearchClear();

            txtPaidAmoun.Text = "";
            txtSalesManNamePayment.Text = "";
            txtTotalPayable.Text = "0";
            txtChequeDate.Text = "";
            txtChequeNo.Text = "";
            txtDueAmount.Text = "0";
            txtIssueDate.Text = "";
            txtLCNumber.Text = "";
            pnlBank.Visible = true;
            rdoPayment.SelectedValue = "Bank";
            txtNote.Text = "";
            lblBankAmount.Text = "";
            ddlBank.SelectedValue = "0";
            lblCashAount.Visible = false;
            lblCashLbl.Visible = false;
        }
    }
}