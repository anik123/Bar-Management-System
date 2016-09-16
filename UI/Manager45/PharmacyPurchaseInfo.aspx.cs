using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.MedicationBLL;
using System.Data;
using PBLL;
using PDTO;
using DTO.MedicinDTO;

namespace HMS.UI.MedicationUI
{
    public partial class PharmacyPurchaseInfo : System.Web.UI.Page
    {
        PharmPurchaseInfoDTO InfoDTO = new PharmPurchaseInfoDTO();
        PharmPurchasePaymentDTO PaymentDTO = new PharmPurchasePaymentDTO();
        PharmPurcahseDtlDTO DtlDTO = new PharmPurcahseDtlDTO();
        //PharmPurchasePaymentDtlDTO PayDtlDto = new PharmPurchasePaymentDtlDTO();
        // 
        SalaryPaymentBLL EmpSALPay = new SalaryPaymentBLL();// for bank amount load

        MedicationTypeBLL MBLL = new MedicationTypeBLL();
        PharmPurchaseBLL PBLL = new PharmPurchaseBLL();

        // for trnsection
        BankAccountInfoBLL ABLL = new BankAccountInfoBLL();//load account info
        BankTransectionBLL TBLL = new BankTransectionBLL();
        CompanyCashEntryBLL CBLL = new CompanyCashEntryBLL();
        SalaryPaymentBLL SPBLL = new SalaryPaymentBLL();

        // load cash amount

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                // Start of load
                LoadMedicationType();
                LoadCompanyName();
                LoadMedicaitonName();
                GridView1.Columns[2].Visible = false;
                // End of load

                // tarnsection
                loadAccountName();
            }

        }



        // Start of load
        private void LoadMedicationType()
        {
            var query = PBLL.GetMedicationType();
            ddlPType.DataSource = query;
            ddlPType.DataTextField = "MedShortFrom";
            ddlPType.DataValueField = "MedTypeId";
            ddlPType.DataBind();
            ddlPType.Items.Insert(0, new ListItem("Select Medication Type", "0"));
        }

        private void LoadCompanyName()
        {
            var data = PBLL.GetCompanyName(Convert.ToInt32(ddlPType.SelectedValue));
            ddlCompName.DataSource = data;
            ddlCompName.DataTextField = "CompanyName";
            ddlCompName.DataValueField = "CompanyId";
            ddlCompName.DataBind();
            ddlCompName.Items.Insert(0, new ListItem("Select Company Name", "0"));
        }

        private void LoadMedicaitonName()
        {
            var data = PBLL.GetMedicationName(Convert.ToInt32(ddlPType.SelectedValue), Convert.ToInt32(ddlCompName.SelectedValue));
            ddlTName.DataSource = data;
            ddlTName.DataTextField = "MedicationName";
            ddlTName.DataValueField = "MedicationId";
            ddlTName.DataBind();
            ddlTName.Items.Insert(0, new ListItem("Select Medication Name", "0"));
        }



        protected void ddlPType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCompanyName();
        }
        protected void ddlCompany_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadMedicaitonName();


        }

        protected void ddlTreadName_SelectedIndexChanged(object sender, EventArgs e)
        {
            loadorganicname_Unit();

        }


        public void loadorganicname_Unit()
        {

            var data = PBLL.GetMedicationUnit_OrganicName(Convert.ToInt32(ddlPType.SelectedValue), Convert.ToInt32(ddlCompName.SelectedValue), Convert.ToInt32(ddlTName.SelectedValue));
            txtOrganicName.Text = data.First().OrganicName.ToString();
            txtUnit.Text = data.First().UnitType.ToString();
        }

        // end of load

        // load data gv

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlPType.SelectedValue == "0")
            {
                txtUnit.Focus();
                return;
            }
            if (ddlTName.SelectedValue == "0")
            {
                txtUnit.Focus();
                return;
            }

            if (ddlCompName.SelectedValue == "0")
            {
                txtUnit.Focus();
                return;
            }

            if (txtPurQuan.Text == "")
            {
                txtPurQuan.Focus();
                return;
            }
            if (txtPurPrice.Text == "")
            {
                txtPurPrice.Focus();
                return;
            }


            if (ViewState["CurrentData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentData"];
                int count = dt.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    //((ddlUnit.SelectedItem.ToString()) == dt.Rows[i][6].ToString()) &&
                    if ((Convert.ToInt32(ddlTName.SelectedValue.ToString()) == Convert.ToInt32(dt.Rows[i][3].ToString())))
                    {
                        return;
                    }

                }
                BindGrid(count);

            }
            else
            {
                BindGrid(1);

                pnlAction.Visible = true;

            }


            txtDueAmount.Text = "0";
            ddlPType.Focus();
            //clearCntrol();

        }

        protected void LinkButton1_Click(object sender, EventArgs e)
        {

            LinkButton lb = (LinkButton)sender;

            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;

            int rowID = gvRow.RowIndex;

            if (ViewState["CurrentData"] != null)
            {

                DataTable dt = (DataTable)ViewState["CurrentData"];

                if (dt.Rows.Count > 0)
                {
                    dt.Rows.RemoveAt(rowID);
                }

                ViewState["CurrentData"] = dt;
                double sum = 0;
                int count = dt.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    double total = Convert.ToDouble(dt.Rows[i][9]);
                    sum = total + sum;
                    txtTotalPayable.Text = sum.ToString();
                    txtPaidAmoun.Text = sum.ToString();
                }

                if (count == 0)
                {
                    txtTotalPayable.Text = "";
                    txtPaidAmoun.Text = "";

                    pnlAction.Visible = false;
                }


                GridView1.DataSource = dt;
                GridView1.DataBind();

            }
        }

        private double CalulationPrice(double price, double qty)
        {
            double calculate = 0;

            calculate = (qty * price);//other

            return calculate;
        }

        private void BindGrid(int rowcount)
        {
            // getDONO();
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("Type", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("TypeId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("MedicationName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Id", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CompId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CompanyName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Unit", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("PurchaseQuantity", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("PurUnitPrice", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("TotalPrice", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("OrganicName", typeof(String)));
            if (ViewState["CurrentData"] != null)
            {
                for (int i = 0; i < rowcount + 1; i++)
                {
                    dt = (DataTable)ViewState["CurrentData"];
                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();

                    }
                }
                dr = dt.NewRow();
                dr[0] = ddlPType.SelectedItem.ToString();
                dr[1] = ddlPType.SelectedValue.ToString();
                dr[2] = ddlTName.SelectedItem.ToString();
                dr[3] = ddlTName.SelectedValue.ToString();
                dr[4] = ddlCompName.SelectedValue.ToString();
                dr[5] = ddlCompName.SelectedItem.ToString();
                dr[6] = txtUnit.Text;
                dr[7] = txtPurQuan.Text;
                dr[8] = txtPurPrice.Text;
                dr[9] = CalulationPrice(Convert.ToDouble(txtPurPrice.Text), Convert.ToInt32(txtPurQuan.Text));
                dr[10] = txtOrganicName.Text;
                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = ddlPType.SelectedItem.ToString();
                dr[1] = ddlPType.SelectedValue.ToString();
                dr[2] = ddlTName.SelectedItem.ToString();
                dr[3] = ddlTName.SelectedValue.ToString();
                dr[4] = ddlCompName.SelectedValue.ToString();
                dr[5] = ddlCompName.SelectedItem.ToString();
                dr[6] = txtUnit.Text;
                dr[7] = txtPurQuan.Text;
                dr[8] = txtPurPrice.Text;
                dr[9] = CalulationPrice(Convert.ToDouble(txtPurPrice.Text), Convert.ToInt32(txtPurQuan.Text));
                dr[10] = txtOrganicName.Text;
                dt.Rows.Add(dr);
            }


            if (ViewState["CurrentData"] != null)
            {
                GridView1.DataSource = (DataTable)ViewState["CurrentData"];
                GridView1.DataBind();
            }
            else
            {

                GridView1.DataSource = dt;
                GridView1.DataBind();


            }

            ViewState["CurrentData"] = dt;
            double sum = 0;
            int count = dt.Rows.Count;

            for (int i = 0; i < count; i++)
            {
                double total = Convert.ToDouble(dt.Rows[i][9]);
                sum = total + sum;

            }
            txtTotalPayable.Text = sum.ToString();
            txtPaidAmoun.Text = sum.ToString();

        }


        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


            GridView1.PageIndex = e.NewPageIndex;
            if (ViewState["CurrentData"] != null)
            {
                GridView1.DataSource = (DataTable)ViewState["CurrentData"];
                GridView1.DataBind();
            }
            GridView1.DataBind();
        }


        protected void GridView1_RowDeleting(object sender, GridViewDeleteEventArgs e)
        {

        }

        protected void GridView1_SelectedIndexChanged(object sender, EventArgs e)
        {

        }




        // end data gv
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            if (rdoPayment.SelectedValue == "Bank")
            {
                if (ddlBank.SelectedValue.ToString() == "0")
                {
                    ddlBank.Focus();
                    //ddlBank.ViewStateMode =;
                    // ddlBank.
                    return;
                }
                if (txtChequeNo.Text.ToString() == "")
                {
                    txtChequeNo.Focus();
                    return;
                }
                if (txtLCNumber.Text.ToString() == "")
                {
                    txtLCNumber.Focus();
                    return;
                }

                if (txtIssueDate.Text.ToString() == "")
                {
                    txtIssueDate.Focus();
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
                    txtPaidAmoun.Focus();
                    return;
                }
            }
            if (txtSalesmanName.Text == "")
            {
                txtSalesmanName.Focus();
                return;
            }
            InfoDTO.PurDes = txtRemarks.Text.ToString();
            InfoDTO.CreateBy = "tarun";
            InfoDTO.CreateDate = System.DateTime.Now;
            InfoDTO.SalesManName = txtSalesmanName.Text.ToString();
            InfoDTO.DurgCompId = Convert.ToInt32(ddlCompName.SelectedValue);
            PBLL.PurchaseInfo(InfoDTO);

            PaymentDTO.PaymentMode = rdoPayment.SelectedItem.ToString();
            PaymentDTO.TotalPrice = Convert.ToDouble(txtTotalPayable.Text);
            PaymentDTO.PaidAmount = Convert.ToDouble(txtPaidAmoun.Text);
            PaymentDTO.DueAmount = Convert.ToDouble(txtDueAmount.Text);
            PaymentDTO.Note = txtNote.Text.ToString();
            PaymentDTO.PaymentDate = System.DateTime.Now;
            PaymentDTO.PaymentBy = "tarun";

            if (ddlBank.SelectedValue.ToString() != "0")
            {
                PaymentDTO.AccountInfoId = Convert.ToInt32(ddlBank.SelectedValue);
            }
           // else { PaymentDTO.AccountInfoId = 0; }
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



            List<PharmPurchaseInfoDTO> PP = new List<PharmPurchaseInfoDTO>();
            PP = PBLL.LoadPurID();
            PaymentDTO.PurId = Convert.ToInt32(PP.FirstOrDefault().PurId.ToString());
            PBLL.SavePaymentInfo(PaymentDTO);
            PBLL.SavePurchasePaymentDtl(PaymentDTO);


            DataTable dt = (DataTable)ViewState["CurrentData"];
            int count = dt.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                DtlDTO.PurId = Convert.ToInt32(PP.FirstOrDefault().PurId.ToString());/////////////////////////////////problem
                DtlDTO.MedicationId = Convert.ToInt32(dt.Rows[i][3]);
                DtlDTO.Quantity = Convert.ToInt32(dt.Rows[i][7]);
                DtlDTO.PurchasePrice = Convert.ToDouble(dt.Rows[i][8]);
                PBLL.SavePurchaseDtl(DtlDTO);

            }

            // for add if database exit//////////////

            clearCntrol();
            ClearControlPurchase();
            ClearControlBank();

            Response.Redirect("/MedicationUI/Report/PharmPurchaseRptUI.aspx");

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
            GridView1.DataSource = dt;
            GridView1.DataBind();


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


            txtPurPrice.Text = "";
            txtPurQuan.Text = "";
            // txtOrganicName.Text = "";
            txtRemarks.Text = "";
            LoadMedicationType();
            LoadMedicaitonName();
            LoadCompanyName();
            txtSalesmanName.Text = "";
            txtUnit.Text = "";
            txtOrganicName.Text = "";

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
            txtPurPrice.Text = "";
            lblBankAmount.Text = "";
            lblCashAount.Text = "";

        }

        //protected void txtPaidAmoun_TextChanged(object sender, EventArgs e)
        //{
        //    DataTable dt = (DataTable)ViewState["CurrentData"];
        //    double sum = 0;
        //    int count = dt.Rows.Count;

        //    for (int i = 0; i < count; i++)
        //    {
        //        double total = Convert.ToDouble(dt.Rows[i][9]);
        //        sum = total + sum;

        //    }

        //    //if (txtPaidAmoun.Text.ToString() == "" || (sum < Convert.ToInt32(txtPaidAmoun.Text)))
        //    if (txtPaidAmoun.Text.ToString() == "" || (sum < Convert.ToInt32(txtPaidAmoun.Text)))
        //    {
        //        txtPaidAmoun.Text = sum.ToString();
        //        txtDueAmount.Text = "0";
        //    }
        //    else
        //    {
        //        txtDueAmount.Text = Convert.ToString(sum - Convert.ToInt32(txtPaidAmoun.Text));

        //    }
        //}

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();
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

        // transection
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
            //if (cc.Count != 0 && sp.Count != 0 && pp.Count != 0)
            //{
            //    // lblCashAount.Text = cc.First().CashAmount.ToString() + " Tk";
            //    //  lblCashAount.Text = (cc.First().CashAmount.ToString() - sp.First().CashAmount.ToString()) + " Tk";
            //    lblCashAount.Text = Convert.ToString((cc.First().CashAmount - (sp.First().CashAmount + pp.First().PaidAmount)));
            //}
            //else if (cc.Count != 0 && sp.Count != 0 && pp.Count == 0)
            //{
            //    lblCashAount.Text = Convert.ToString((cc.First().CashAmount - (sp.First().CashAmount)));

            //}
            //else if (cc.Count != 0 && sp.Count == 0 && pp.Count != 0)
            //{
            //    lblCashAount.Text = Convert.ToString((cc.First().CashAmount - (pp.First().PaidAmount)));

            //}
            //else if (cc.Count != 0 && sp.Count == 0 && pp.Count == 0)
            //{
            //    lblCashAount.Text = cc.First().CashAmount.ToString();

            //}
            //else
            //{
            //    lblCashAount.Text = "0";
            //}
        }

        protected void rdoPayment_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (txtTotalPayable.Text == "")
            {
                txtPurQuan.Focus();
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
    }
}