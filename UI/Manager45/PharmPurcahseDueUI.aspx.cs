using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.MedicationBLL;
using DTO.MedicinDTO;
using PBLL;
using PDTO;
using System.Data;

namespace HMS.UI.MedicationUI
{
    public partial class PharmPurcahseDueUI : System.Web.UI.Page
    {
        DurgCompanyInfoBLL CompBLL = new DurgCompanyInfoBLL();
        PurchaseDueBLL DBLL = new PurchaseDueBLL();
        BankAccountInfoBLL ABLL = new BankAccountInfoBLL();//load account info
        BankTransectionBLL TBLL = new BankTransectionBLL();
        PharmPurchaseBLL PBLL = new PharmPurchaseBLL();
        CompanyCashEntryBLL CBLL = new CompanyCashEntryBLL();
        SalaryPaymentBLL SPBLL = new SalaryPaymentBLL();
        SalaryPaymentBLL EmpSALPay = new SalaryPaymentBLL();// for bank amount load

        PharmPurchasePaymentDTO PaymentDTO = new PharmPurchasePaymentDTO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadCompanyName();
                loadAccountName();
            }
        }
        private void LoadCompanyName()
        {
            var data = CompBLL.GetCompanyName(0);
            ddlCompanyName.DataSource = data;
            ddlCompanyName.DataTextField = "CompName";
            ddlCompanyName.DataValueField = "CompId";
            ddlCompanyName.DataBind();
            ddlCompanyName.Items.Insert(0, new ListItem("Select Company Name", "0"));
        }

        private void loadAccountName()
        {

            var query = ABLL.AccountNameLoad();
            ddlBank.DataSource = query;
            ddlBank.DataTextField = "AccountAllName";
            ddlBank.DataValueField = "AccountInfoId";
            ddlBank.DataBind();
            ddlBank.Items.Insert(0, new ListItem("Select Account Name", "0"));

        }


        protected void txtCompIdS_TextChanged(object sender, EventArgs e)
        {
            try
            // Convert.ToInt32(e.CommandArgument.ToString())
            {
                var bb = DBLL.GetPurchaseDue(0, 0, txtSalesManName.Text.ToString());
                GvDueInfo.DataSource = bb;
                GvDueInfo.DataBind();

                HFPaymentID.Value = "";
                HFPurID.Value = "";
            }
            catch { }



        }



        protected void LinkButton_Command_GvDueInfo(object sender, CommandEventArgs e)
        {
            List<PharmPurchasePaymentDTO> bb = new List<PharmPurchasePaymentDTO>();
            bb = DBLL.GetPurchaseDue(Convert.ToInt32(e.CommandArgument.ToString()), 0, "");
            txtTotalPayable.Text = bb.First().DueAmount.ToString();

            txtSalesManNameS.Text = bb.First().SalesManName.ToString();
            HFPaymentID.Value = bb.First().PharmPurPaymentId.ToString();
            HFPurID.Value = bb.First().PurId.ToString();
            lblTotalPrice.Text = bb.First().TotalPrice.ToString();
        }

        protected void LinkButton_Command_GvDueInfo_ViewDtl(object sender, CommandEventArgs e)
        {
            int purid;
            List<PharmPurchasePaymentDTO> bb = new List<PharmPurchasePaymentDTO>();
            bb = DBLL.GetPurchaseDue(Convert.ToInt32(e.CommandArgument.ToString()), 0, "");
            purid = Convert.ToInt32(bb.First().PurId.ToString());
            Response.Redirect("~/MedicationUI/PharmPurchaseDueDtl.aspx?purid=" + purid.ToString());
        }
        private void loadDataGVDueInfo(int payid, int Compid, string SalesManName)
        {
            var data = DBLL.GetPurchaseDue(0, Convert.ToInt32(ddlCompanyName.SelectedValue), txtSalesManName.Text.ToString());
            GvDueInfo.DataSource = data;
            GvDueInfo.DataBind();
        }

        protected void GvDueInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDueInfo.PageIndex = e.NewPageIndex;
            loadDataGVDueInfo(0, 0, "");
        }

        protected void ddlCompanyName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadDataGVDueInfo(0, Convert.ToInt32(ddlCompanyName.SelectedValue), "");
            HFPaymentID.Value = "";
            HFPurID.Value = "";
        }

        protected void ddlBank_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (ddlBank.SelectedValue.ToString() != "0")
            {

                var pp = PBLL.SumOfCashAmount_PharmPurchasePayment_Bank(Convert.ToInt32(ddlBank.SelectedValue));
                if (pp.Count != 0)
                {
                    lblPurPay.Text = Convert.ToString(pp.First().PaidAmount);
                }
                else
                {
                    lblPurPay.Text = " 0";
                }


                var salpay = EmpSALPay.Sum_SlaryPayment_Bank(Convert.ToInt32(ddlBank.SelectedValue));
                if (salpay.Count != 0)
                {
                    lblSalPay.Text = Convert.ToString(salpay.First().PayableAmount);
                }
                else
                {
                    lblSalPay.Text = " 0";
                }


                List<BankTransectionDTO> bb = new List<BankTransectionDTO>();
                try
                {
                    bb = TBLL.SumOfAmount(Convert.ToInt32(ddlBank.SelectedValue));
                    if (bb.Count != 0)
                    {
                        lblCurrBankAmount.Text = Convert.ToString(bb.First().Amount);
                    }
                    else
                    {
                        lblCurrBankAmount.Text = " 0";
                    }

                    lblBankAmount.Text = Convert.ToString(Convert.ToDouble(lblCurrBankAmount.Text) - (Convert.ToDouble(lblSalPay.Text) + Convert.ToDouble(lblPurPay.Text)));
                    hfaccountid.Value = bb.First().AccountInfoId.ToString();
                }
                catch
                {
                    lblBankAmount.Text = "0";
                    hfaccountid.Value = String.Empty;

                }
            }
            else
            {
                lblBankAmount.Text = String.Empty;
                hfaccountid.Value = string.Empty;
            }
        }

        private void loadcash()
        {
            var cc = CBLL.SumOfCashAmount();// load total cash amount
            if (cc.Count != 0)
            {
                lblCashTotal.Text = Convert.ToString(cc.First().CashAmount);
            }
            else
            {
                lblCashTotal.Text = " 0";
            }

            var sp = SPBLL.SumOfCashAmount_Salpayment();//laod salary payment
            if (sp.Count != 0)
            {
                lblCashSalPay.Text = Convert.ToString(sp.First().CashAmount);
            }
            else
            {
                lblCashSalPay.Text = " 0";
            }
            var pp = PBLL.SumOfCashAmount_PharmPurchasePayment();
            if (pp.Count != 0)
            {
                lblCashPurchase.Text = Convert.ToString(pp.First().PaidAmount);
            }
            else
            {
                lblCashPurchase.Text = " 0";
            }
            lblCashAount.Text = Convert.ToString(Convert.ToDouble(lblCashTotal.Text) - (Convert.ToDouble(lblCashPurchase.Text) + Convert.ToDouble(lblCashSalPay.Text)));

        }

        protected void rdoPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTotalPayable.Text == "")
            {
                txtTotalPayable.Focus();
                return;
            }
            if (rdoPayment.SelectedValue == "Cash")
            {
                pnlBank.Visible = false;
                PnlCash.Visible = true;
                txtPaidAmoun.Text = Convert.ToString(Convert.ToDouble(txtTotalPayable.Text));

                loadcash();// load cash amount
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
                PnlCash.Visible = false;
            }
        }

        protected void txtPaidAmoun_TextChanged(object sender, EventArgs e)
        {
            if (lblCashAount.Text.ToString() == "0" || Convert.ToDouble(lblCashAount.Text) < Convert.ToDouble(txtPaidAmoun.Text) || Convert.ToDouble(txtTotalPayable.Text) < Convert.ToDouble(txtPaidAmoun.Text))
            {
                txtPaidAmoun.Text = "";
            }
            else
            {
                txtDueAmount.Text = Convert.ToString(Convert.ToDouble(txtTotalPayable.Text) - Convert.ToDouble(txtPaidAmoun.Text));
            }
        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
           

            PaymentDTO.PaymentMode = rdoPayment.SelectedItem.ToString();
            PaymentDTO.TotalPrice = Convert.ToDouble(lblTotalPrice.Text);//Convert.ToDouble(txtTotalPayable.Text);
            PaymentDTO.PaidAmount = Convert.ToDouble(txtPaidAmoun.Text);
            PaymentDTO.DueAmount = Convert.ToDouble(txtDueAmount.Text);
            PaymentDTO.Note = txtNote.Text.ToString();
            PaymentDTO.PaymentDate = System.DateTime.Now;
            PaymentDTO.PaymentBy = "tarun";

            if (ddlBank.SelectedValue.ToString() != "0")
            {
                PaymentDTO.AccountInfoId = Convert.ToInt32(ddlBank.SelectedValue);
            }

            if (txtChequeNo.Text.ToString() != "")
            {
                PaymentDTO.ChequeNo = txtChequeNo.Text.ToString();
            }
            if (txtChequeDate.Text.ToString() != "")
                PaymentDTO.ChequeDate = Convert.ToDateTime(txtChequeDate.Text);
            if (txtIssueDate.Text.ToString() != "")

                PaymentDTO.IssDate = Convert.ToDateTime(txtIssueDate.Text);
            if (txtLCNumber.Text.ToString() != "")
            {
                PaymentDTO.LCNumber = txtLCNumber.Text.ToString();
            }

            PaymentDTO.PurId = Convert.ToInt32(HFPurID.Value);

            //List<PharmPurchaseInfoDTO> PP = new List<PharmPurchaseInfoDTO>();
            //PP = PBLL.LoadPurID();
            //PaymentDTO.PurId = Convert.ToInt32(PP.FirstOrDefault().PurId.ToString());
            // PBLL.SavePaymentInfo(PaymentDTO);
            PBLL.SavePurchasePaymentDtl(PaymentDTO);

            List<PharmPurchasePaymentDTO> bb1 = new List<PharmPurchasePaymentDTO>();
            bb1 = DBLL.GetPurchaseDue(0, 0, "");
            PaymentDTO.PharmPurPaymentId = Convert.ToInt32(HFPaymentID.Value);
            lblPreviousPayAmount.Text = bb1.First().PaidAmount.ToString();
            PaymentDTO.PaidAmount = Convert.ToDouble(Convert.ToDouble(lblPreviousPayAmount.Text) + Convert.ToDouble(txtPaidAmoun.Text));
            PaymentDTO.DueAmount = Convert.ToDouble(txtDueAmount.Text);
            PaymentDTO.PurId = Convert.ToInt32(HFPurID.Value);
            DBLL.EditPurchasePayment(PaymentDTO);
            Response.Redirect("/MedicationUI/Report/PurchasePartialPaymentRptUI.aspx");
            clearCntrol();
            ClearControlPurchase();
            ClearControlBank();

        }

        protected void btnCancelPurchase_Click(object sender, EventArgs e)
        {
            clearCntrol();
            ClearControlPurchase();
            ClearControlBank();


        }

        public void ClearControlPurchase()
        {
            this.ViewState["CurrentData"] = null;
            DataTable dt = new DataTable();
            GvDueInfo.DataSource = dt;
            GvDueInfo.DataBind();

            rdoPayment.SelectedIndex = 0;
            pnlBank.Visible = true;
            PnlCash.Visible = false;
            txtPaidAmoun.Text = "";
            txtDueAmount.Text = "";
            txtTotalPayable.Text = "";
            txtNote.Text = "";
        }
        private void clearCntrol()
        {
            txtSalesManName.Text = "";
            txtSalesManNameS.Text = "";
            LoadCompanyName();
        }

        public void ClearControlBank()
        {
            loadAccountName();
            txtChequeDate.Text = "";
            txtChequeNo.Text = "";
            txtDueAmount.Text = "";
            txtIssueDate.Text = "";
            txtLCNumber.Text = "";
            txtNote.Text = "";
            txtPaidAmoun.Text = "";
            lblBankAmount.Text = "";
            lblCashAount.Text = "";

        }

    }
}