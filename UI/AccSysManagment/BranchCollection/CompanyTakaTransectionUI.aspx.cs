using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDTO;
using PBLL;
using BLL;
using BLL.CompProfile;
using ABLL;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.BranchCollection
{
    public partial class CompanyTakaTransectionUI : System.Web.UI.Page
    {
        // for bank transection
        BankTransectionDTO DTO = new BankTransectionDTO();
        BankTransectionBLL TBLL = new BankTransectionBLL();
        BankTransectionDtlDTO DtlDTO = new BankTransectionDtlDTO();
        BankTransectionDtlBLL DtlBLL = new BankTransectionDtlBLL();
        BankAccountInfoBLL ABLL = new BankAccountInfoBLL();
        // for cash
        CompanyCashEntryDTO CDTO = new CompanyCashEntryDTO();
        CompanyCashEntryBLL CBLL = new CompanyCashEntryBLL();

        // current cash or bank amount load
        AssetBLL AssBLL = new AssetBLL();
        AssetDTO AssDTO = new AssetDTO();
        // branch
        BranchProfileBLL BrBLL = new BranchProfileBLL();

        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Collection";
                // for cash
                LoadIncomeCollectionItem_Cash();
                LoadCurrentCashAmount();
                // for bank
                loadAccountName();
                LoadCurrentBankAmount();
                LoadIncomeCollectionItem_Bank();
                txtCollectionDate_Cash.Text = System.DateTime.Now.ToShortDateString();
                txtCollectionDate_Bank.Text = System.DateTime.Now.ToShortDateString();
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
        // for cash entry
        private void LoadIncomeCollectionItem_Cash()
        {
            var query = BrBLL.LoadBrProfileInfo(0, "", "", "");
            ddlCollectionItem_Cash.DataSource = query.OrderBy(Items => Items.BrProName);
            ddlCollectionItem_Cash.DataTextField = "BrProName";
            ddlCollectionItem_Cash.DataValueField = "BrProId";
            ddlCollectionItem_Cash.DataBind();
            ddlCollectionItem_Cash.Items.Insert(0, new ListItem("Select Branch", "0"));
        }
        protected void BtnSaveCash_Click(object sender, EventArgs e)
        {

            CDTO.CashAmount = Convert.ToDouble(txtamountCash.Text);
            CDTO.IncomeItemId = Convert.ToInt16(ddlCollectionItem_Cash.SelectedValue);
            if (txtCollectionDate_Cash.Text == "Today")
            {
                CDTO.CollectionDate = System.DateTime.Today;
            }
            else
            {
                CDTO.CollectionDate = Convert.ToDateTime(txtCollectionDate_Cash.Text.ToString());
            }
            CDTO.Remarks = txtRemarksCash.Text.ToString();
            CDTO.Year = System.DateTime.Now.Year;
            DateTime dt = DateTime.Now;
            //Console.WriteLine(dt.ToString("MMMM"));
            CDTO.Month = dt.ToString("MMMM");//System.DateTime.Now.AddMonths.to;
            CDTO.CrateDate = System.DateTime.Now;
            CDTO.CreateBy = HttpContext.Current.User.Identity.Name;
            CBLL.Add(CDTO);

            // start asset cash 
            var currentAsset = AssBLL.Asset_Current();

            if (currentAsset.Count != 0)
            {

                if (currentAsset.First().CashAmount_Current == null)
                {
                    AssDTO.BankAmount_Current = currentAsset.First().BankAmount_Current;
                    AssDTO.AssetId = currentAsset.First().AssetId;
                    AssDTO.CashAmount_Current = Convert.ToDouble(txtamountCash.Text);
                    AssBLL.Edit(AssDTO);
                }
                else
                {
                    AssDTO.BankAmount_Current = currentAsset.First().BankAmount_Current;
                    AssDTO.AssetId = currentAsset.First().AssetId;
                    AssDTO.CashAmount_Current = Convert.ToDouble(currentAsset.First().CashAmount_Current.ToString()) + Convert.ToDouble(txtamountCash.Text);
                    AssBLL.Edit(AssDTO);
                }
            }
            else
            {
                AssDTO.CashAmount_Current = Convert.ToDouble(txtamountCash.Text);
                AssBLL.Add(AssDTO);
            }

            clearCntrol_Cash();
            LoadCurrentCashAmount();
        }

        public void LoadCurrentCashAmount()
        {
            var amount = AssBLL.Asset_Current();
            if (amount.Count != 0)
            {
                if (amount.First().CashAmount_Current == null)
                {
                    lblCash.Text = "0";
                }
                else
                {
                    lblCash.Text = amount.First().CashAmount_Current.ToString();
                }
            }
            else
            {

                lblCash.Text = "0";


            }

        }
        private void clearCntrol_Cash()
        {
            txtamountCash.Text = "";
            BtnSaveCash.Text = "Save";
            txtRemarksCash.Text = "";
            ddlCollectionItem_Cash.SelectedValue = "0";
            txtCollectionDate_Cash.Text = System.DateTime.Now.ToShortDateString();

        }
        protected void BtnCancelCash_Click(object sender, EventArgs e)
        {
            clearCntrol_Cash();
            LoadCurrentCashAmount();
        }
        // for cash entry

        // for bank transection

        private void loadAccountName()
        {

            var query = ABLL.AccountNameLoad();
            ddlBankName.DataSource = query.OrderBy(Items => Items.AccountAllName);
            ddlBankName.DataTextField = "AccountAllName";
            ddlBankName.DataValueField = "AccountInfoId";
            ddlBankName.DataBind();
            ddlBankName.Items.Insert(0, new ListItem("Select Account", "0"));

        }
        private void LoadIncomeCollectionItem_Bank()
        {
            var query = BrBLL.LoadBrProfileInfo(0, "", "", "");
            ddlBank_CollectionItem.DataSource = query.OrderBy(Items => Items.BrProName);
            ddlBank_CollectionItem.DataTextField = "BrProName";
            ddlBank_CollectionItem.DataValueField = "BrProId";
            ddlBank_CollectionItem.DataBind();
            ddlBank_CollectionItem.Items.Insert(0, new ListItem("Select Branch ", "0"));
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            DtlDTO.AccountInfoId = Convert.ToInt16(ddlBankName.SelectedValue);
            DtlDTO.IncomeItemId = Convert.ToInt16(ddlBank_CollectionItem.SelectedValue);
            DtlDTO.Amount_EachTransection = Convert.ToDouble(txtamount.Text);
            DtlDTO.Remarks = txtRemarks.Text;


            DtlDTO.CollectionDate = Convert.ToDateTime(txtCollectionDate_Bank.Text);

            DtlDTO.PaymentDate = System.DateTime.Now;
            DtlDTO.PaymentBy = HttpContext.Current.User.Identity.Name;
            DtlDTO.Year = System.DateTime.Now.Year;
            DtlBLL.Add(DtlDTO);

            DTO.BankAmount = Convert.ToDouble(txtamount.Text);
            DTO.AccountInfoId = Convert.ToInt16(ddlBankName.SelectedValue);
            var accountAmount = TBLL.LoadBankTransection(Convert.ToInt16(ddlBankName.SelectedValue));
            if (accountAmount.Count == 0)
            {
                TBLL.Add(DTO);
            }
            else
            {
                DTO.BankTransectionId = accountAmount.First().BankTransectionId;
                DTO.BankAmount = Convert.ToDouble(accountAmount.First().BankAmount.ToString()) + Convert.ToDouble(txtamount.Text);
                TBLL.Edit(DTO);

            }
            // start asset cash 
            var currentAsset = AssBLL.Asset_Current();

            if (currentAsset.Count != 0)
            {

                if (currentAsset.First().BankAmount_Current == null)
                {
                    AssDTO.AssetId = currentAsset.First().AssetId;
                    AssDTO.CashAmount_Current = currentAsset.First().CashAmount_Current;
                    AssDTO.BankAmount_Current = Convert.ToDouble(txtamount.Text);
                    AssBLL.Edit(AssDTO);
                }
                else
                {
                    AssDTO.CashAmount_Current = currentAsset.First().CashAmount_Current;
                    AssDTO.AssetId = currentAsset.First().AssetId;
                    AssDTO.BankAmount_Current = Convert.ToDouble(currentAsset.First().BankAmount_Current.ToString()) + Convert.ToDouble(txtamount.Text);
                    AssBLL.Edit(AssDTO);
                }

            }
            else
            {
                AssDTO.BankAmount_Current = Convert.ToDouble(txtamount.Text);
                AssBLL.Add(AssDTO);
            }
            // end asset cash
            clearCntrol();
            LoadCurrentBankAmount();

        }
        public void LoadCurrentBankAmount_AccountWise()
        {

            var amount = TBLL.LoadBankTransection(Convert.ToInt16(ddlBankName.SelectedValue));
            if (amount.Count == 0)
            {
                lbltotalCurrentAmount.Text = "Current Amount 0 Tk";
            }
            else
            {
                lbltotalCurrentAmount.Text = Convert.ToString("Current Amount  " + amount.First().BankAmount.ToString() + " Tk");
            }
        }
        public void LoadCurrentBankAmount()
        {
            var amount = AssBLL.Asset_Current();

            if (amount.Count != 0)
            {
                if (amount.First().BankAmount_Current == null)
                {
                    lblBankAmountTotal.Text = "0";
                }
                else
                {
                    lblBankAmountTotal.Text = amount.First().BankAmount_Current.ToString();
                }
            }
            else
            {
                lblBankAmountTotal.Text = "0";
            }
        }
        private void clearCntrol()
        {
            txtCollectionDate_Bank.Text = System.DateTime.Now.ToShortDateString();
            txtamount.Text = "";
            btnSave.Text = "Save";
            ddlBankName.SelectedValue = "0";
            lbltotalCurrentAmount.Text = "";
            txtRemarks.Text = "";
            ddlBank_CollectionItem.SelectedValue = "0";
            // LoadIncomeCollectionItem_Bank();

        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();
            LoadCurrentBankAmount();
        }
        protected void ddlBankName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCurrentBankAmount_AccountWise();
        }

        // for bank transection
    }
}