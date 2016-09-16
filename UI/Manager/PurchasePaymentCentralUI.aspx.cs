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
using ABLL;
using ADTO;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.Manager
{
    public partial class PurchasePaymentCentralUI : System.Web.UI.Page
    {

        CompanyBLL CompBLL = new CompanyBLL();
        InvenCentralPurchseBLL PurchseBLL = new InvenCentralPurchseBLL();
        AssetBLL AssBLL = new AssetBLL(); // Current asset
        BankTransectionBLL TBLL = new BankTransectionBLL();// each bank account balence
        BankTransectionDTO TDTO = new BankTransectionDTO();
        BankAccountInfoBLL ABLL = new BankAccountInfoBLL();//load account info
        AssetDTO AssDTO = new AssetDTO();

        InvenCentralPurchasePaymentDTO PaymentDTO = new InvenCentralPurchasePaymentDTO();

        // jopurnal
        JournalDTO JDTO = new JournalDTO();
        JournalBLL JBLL = new JournalBLL();

        // transection dtl 
        TransDetailsBLL TranBLL = new TransDetailsBLL();
        TransDetailsDTO TranDTO = new TransDetailsDTO();


        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Purchase Payment";
                LoadCompanyName();
                loadDataGVInfo();
                loadAccountName();
                var assetAmount = AssBLL.Asset_Current();
                if (assetAmount.Count > 0)
                {
                    lblTotalBankAmount.Text = assetAmount.First().BankAmount_Current.ToString();
                }
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
        private void loadAccountName()
        {

            var query = ABLL.AccountNameLoad();
            ddlBank.DataSource = query.OrderBy(Items => Items.AccountAllName);
            ddlBank.DataTextField = "AccountAllName";
            ddlBank.DataValueField = "AccountInfoId";
            ddlBank.DataBind();
            ddlBank.Items.Insert(0, new ListItem("Select Dept Name", "0"));

        }
        private void LoadCompanyName()
        {
            var data = CompBLL.SearchComInfo(0, "", "", "");
            ddlCompanyName.DataSource = data.OrderBy(Items => Items.CompName);
            ddlCompanyName.DataTextField = "CompName";
            ddlCompanyName.DataValueField = "CompId";
            ddlCompanyName.DataBind();
            ddlCompanyName.Items.Insert(0, new ListItem("Select Company Name", "0"));
        }

        private void loadDataGVInfo()
        {
            var data = PurchseBLL.CentralPurchasePayment_Client_Load(0, 0, 0, "", "", "");
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
            SearchPurchase();
        }

        protected void btnSearchCancel_Click(object sender, EventArgs e)
        {
            SearchClear();
        }
        public void SearchClear()
        {

            ddlCompanyName.SelectedValue = "0";
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            txtOrderNO.Text = "";
            txtPurchaseInvoiceNO.Text = "";
            txtSalesManName.Text = "";
            loadDataGVInfo();
            GvDueInfo.SelectedIndex = -1;
        }

        protected void txtOrderNO_TextChanged(object sender, EventArgs e)
        {

            SearchPurchase();

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
        public void SearchPurchase()
        {
            if (txtPurchaseInvoiceNO.Text == "" && txtOrderNO.Text == "" && ddlCompanyName.SelectedValue == "0" && txtSalesManName.Text == "" && txtDateTo.Text == "" && txtDateFrom.Text == "")
            {
                Show("Search By Valid Data");
                return;
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

                var data = PurchseBLL.CentralPurchasePayment_Client_Load(pid, orid, Convert.ToInt16(ddlCompanyName.SelectedValue), txtSalesManName.Text.ToString(), txtDateFrom.Text.ToString(), txtDateTo.Text.ToString());
                GvDueInfo.DataSource = data;
                GvDueInfo.DataBind();

                if (GvDueInfo.Rows.Count <= 0)
                    Show("No Data Found !");
                return;
            }
        }

        protected void GvDueInfo_SelectedIndexChanged(object sender, EventArgs e)
        {

            var bb = PurchseBLL.CentralPurchasePayment_Client_Load(Convert.ToInt32(GvDueInfo.DataKeys[GvDueInfo.SelectedIndex].Values["PurId"].ToString()), 0, 0, "", "", "");
            txtSalesManNamePayment.Text = bb.First().SalesManName.ToString();
            txtTotalPayable.Text = bb.First().TotalPrice.ToString();
            txtPaidAmoun.Text = bb.First().TotalPrice.ToString();
            HFPhamrPaymentID.Value = bb.First().PurPaymentId.ToString();
            HFPurId.Value = bb.First().PurId.ToString();
            HFTotalPrice.Value = bb.First().TotalPrice.ToString();
        }
        protected void LinkButton_Command_GvDueInfo_ViewDtl(object sender, CommandEventArgs e)
        {
            var bb = PurchseBLL.CentralPurchasePayment_Client_Load(Convert.ToInt32(e.CommandArgument.ToString()), 0, 0, "", "", "");
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

            PaymentDTO.PaymentMode = rdoPayment.SelectedItem.ToString();
            // PaymentDTO.TotalPrice = Convert.ToDouble(lblTotalPrice.Text);//Convert.ToDouble(txtTotalPayable.Text);
            PaymentDTO.PaidAmount = Convert.ToDouble(txtPaidAmoun.Text);
            PaymentDTO.DueAmount = Convert.ToDouble(txtDueAmount.Text);
            PaymentDTO.Note = txtNote.Text.ToString();
            PaymentDTO.PaymentDate = System.DateTime.Now;
            PaymentDTO.PaymentBy = HttpContext.Current.User.Identity.Name;

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
                PaymentDTO.LCNumber = txtLCNumber.Text.ToString();

            PaymentDTO.TotalPrice = Convert.ToDouble(HFTotalPrice.Value);
            PaymentDTO.PurId = Convert.ToInt32(HFPurId.Value);
            PaymentDTO.PurPaymentId = Convert.ToInt32(HFPhamrPaymentID.Value);

            PaymentDTO.FirstPaymentStatus = "1";
            PaymentDTO.DueAmount = Convert.ToDouble(txtDueAmount.Text);

            PurchseBLL.EditPurchasePayment(PaymentDTO);
            PurchseBLL.SavePurPaymentDtl(PaymentDTO);
            // reporting data pharm pay dtl 
            var data = PurchseBLL.LoadPharmPaymentDtlId();
            int purpaydtlid = data.First().PurPayDtlId;
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
                if (assetAmount.Count > 0)
                {
                    AssDTO.AssetId = assetAmount.First().AssetId;
                    AssDTO.CashAmount_Current = assetAmount.First().CashAmount_Current;
                    AssDTO.BankAmount_Current = Convert.ToDouble(assetAmount.First().BankAmount_Current) - Convert.ToDouble(txtPaidAmoun.Text);
                    AssBLL.Edit(AssDTO);
                }
            }
            // asset  transection  bank transection
            if (GvDueInfo.Rows.Count < 0)
                pnlRec.Visible = false;
            else
                pnlRec.Visible = true;

            // start Journal Insert

            List<JournalDTO> jt = new List<JournalDTO>();
            jt = JBLL.Load_Journal_Transection_No();

            if (jt.Count == 0)
            {
                HFTransectionNo.Value = "1";

            }
            else
            {
                HFTransectionNo.Value = Convert.ToString(Convert.ToInt32(jt.First().TransectionNo.ToString()) + 1);
            }
            var trandata = TranBLL.LoadTransDetailsData_DR(6);// purchase transection Item
            JDTO.JournalType = "DR";
            JDTO.COAId = trandata.First().DRCOAId;
            JDTO.SubCode2Id = trandata.First().DRSubCoId2;
            JDTO.SubVoucherId = trandata.First().DrSubVoucherId;
            JDTO.DRAmount = Convert.ToDouble(txtPaidAmoun.Text);
            JDTO.CRAmount = null;
            JDTO.VONO = "";
            JDTO.MRNO = "";
            JDTO.Remarks = txtNote.Text;
            JDTO.TransectionNo = Convert.ToInt32(HFTransectionNo.Value);
            JDTO.TransectionDate = System.DateTime.Now;
            JDTO.PostLeadgerStatus = "N";
            JDTO.CreateBy = HttpContext.Current.User.Identity.Name;
            JDTO.CreateDate = System.DateTime.Now;
            JDTO.ReferenceEntity = "PurPay" + "-" + HFPurId.Value; // reference of sales invoice

            JBLL.Add(JDTO);

            var trandata_Cr = TranBLL.LoadTransDetailsData_CR(5);
            JDTO.JournalType = "CR";
            JDTO.COAId = trandata_Cr.First().CRCOAId;
            JDTO.SubCode2Id = trandata_Cr.First().CRSubCoId2;
            JDTO.SubVoucherId = trandata_Cr.First().CrSubVoucherId;
            JDTO.DRAmount = null;
            JDTO.CRAmount = Convert.ToDouble(txtPaidAmoun.Text);
            JDTO.VONO = "";
            JDTO.MRNO = "";
            JDTO.Remarks = "";
            JDTO.TransectionNo = Convert.ToInt32(HFTransectionNo.Value);
            JDTO.TransectionDate = System.DateTime.Now;
            JDTO.PostLeadgerStatus = "N";
            JDTO.CreateBy = HttpContext.Current.User.Identity.Name;// HttpContext.Current.User.Identity.Name;
            JDTO.CreateDate = System.DateTime.Now;
            JDTO.ReferenceEntity = "PurPay" + "-" + HFPurId.Value; // reference of sales invoice
            JBLL.Add(JDTO);
            if (txtDueAmount.Text != "0")
            {

                JDTO.JournalType = "CR";
                JDTO.COAId = 42;
                JDTO.SubCode2Id = 20;
                JDTO.SubVoucherId = 3;
                JDTO.DRAmount = null;
                JDTO.CRAmount = Convert.ToDouble(txtDueAmount.Text);
                JDTO.VONO = "";
                JDTO.MRNO = "";
                JDTO.Remarks = "";
                JDTO.TransectionNo = Convert.ToInt32(HFTransectionNo.Value);
                JDTO.TransectionDate = System.DateTime.Now;
                JDTO.PostLeadgerStatus = "N";
                JDTO.ReferenceEntity = "PurDue" + "-" + HFPurId.Value; // reference of sales invoice
          
                JDTO.CreateBy = HttpContext.Current.User.Identity.Name;// HttpContext.Current.User.Identity.Name;
                JDTO.CreateDate = System.DateTime.Now;
                JBLL.Add(JDTO);
            }


            //// End Journal Insert



            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Manager/Report/CentralPurchasePaymentRptUI.aspx?PurPayDtlId=" + purpaydtlid.ToString() + "');", true);
            ClearPrint();
        }

        protected void btnCancelPurchase_Click(object sender, EventArgs e)
        {
            ClearPrint();
        }
        private void ClearPrint()
        {
            ddlBank.SelectedValue = "0";
            SearchClear();
            txtPaidAmoun.Text = "";
            txtSalesManNamePayment.Text = "";
            txtTotalPayable.Text = "0";
            txtChequeDate.Text = "";
            txtChequeNo.Text = "";
            txtDueAmount.Text = "0";
            txtIssueDate.Text = "";
            txtLCNumber.Text = "";
            txtNote.Text = "";
            lblBankAmount.Text = "";
            pnlBank.Visible = true;
            rdoPayment.SelectedValue = "Bank";
            lblCashAount.Visible = false;
            lblCashLbl.Visible = false;
        }


    }
}