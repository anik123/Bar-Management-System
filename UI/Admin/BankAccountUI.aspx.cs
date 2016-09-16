using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using BLL;
using BLL.CompProfile;
using ABLL;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.Admin
{
    public partial class BankAccountUI : System.Web.UI.Page
    {
        // for Bank 
        BankInfoDTO DTO = new BankInfoDTO();
        BankInfoBLL TBLL = new BankInfoBLL();
        // for Bank 

        // for account Type 
        AccountTypeDTO ATDTO = new AccountTypeDTO();
        AccountTypeBLL ATBLL = new AccountTypeBLL();
        // for account Type 

        // for account Info
        AccountInfoDTO ADTO = new AccountInfoDTO();
        BankAccountInfoBLL ABLL = new BankAccountInfoBLL();
        // for account info 

        // branch load
        BranchProfileBLL BrPrBLL = new BranchProfileBLL();

        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Bank Account";
                LoadBankNam();// for bank info insert
                loadDataGVAccountType(0);// load grid view of account type

                // for acount info
                GetBankName();
                GetAccountType();
                //  pagingLoal_accountinfo();
                loadDataGVAccountInof(0, 0, "", "", "", "");
                // for account info
                CompanyBranch();
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

        // load branch
        private void CompanyBranch()
        {

            var query = BrPrBLL.LoadBrProfileInfo(0, "", "", "");
            ddlCompBranchName.DataSource = query;
            ddlCompBranchName.DataTextField = "BrProName";
            ddlCompBranchName.DataValueField = "BrProId";
            ddlCompBranchName.DataBind();
            ddlCompBranchName.Items.Insert(0, new ListItem("Select Bank Name", "0"));

        }
        // for account info 

        private void GetBankName()
        {

            var query = TBLL.LoadBankName(0);
            ddlBankName.DataSource = query;
            ddlBankName.DataTextField = "BankName";
            ddlBankName.DataValueField = "BankId";
            ddlBankName.DataBind();
            ddlBankName.Items.Insert(0, new ListItem("Select Bank Name", "0"));

        }
        private void GetAccountType()
        {
            var query = ABLL.LoadAccountType();
            ddlAccountType.DataSource = query;
            ddlAccountType.DataTextField = "AccountTypeName";
            ddlAccountType.DataValueField = "AccountTypeId";
            ddlAccountType.DataBind();
            ddlAccountType.Items.Insert(0, new ListItem("Select AccountType", "0"));
        }


        protected void BtnSaveAccountIndfo_Click(object sender, EventArgs e)
        {
            if (txtAccountName.Text == "")
            {
                txtAccountName.Focus();
                return;
            }

            if (txtAccountNum.Text == "")
            {
                txtAccountNum.Focus();
                return;
            }
            ADTO.BankId = Convert.ToInt32(ddlBankName.SelectedValue.ToString());
            ADTO.AccountTypeId = Convert.ToInt32(ddlAccountType.SelectedValue.ToString());

            ADTO.AccountName = txtAccountName.Text.ToString();
            ADTO.AccountNum = txtAccountNum.Text.ToString();
            ADTO.ActivationSatus = RbActivationStatus.SelectedItem.ToString();
            ADTO.Address = txtaddress.Text.ToString();
            ADTO.BranchName = txtBranch.Text.ToString();
            ADTO.Mobile = txtMobile.Text.ToString();
            ADTO.Phone = txtPhone.Text.ToString();
            ADTO.BrProId = Convert.ToInt16(ddlCompBranchName.SelectedValue);
            ADTO.CreateDate = System.DateTime.Now;
            ADTO.CreateBy = HttpContext.Current.User.Identity.Name;
            if (BtnSaveAccountIndfo.Text == "Save")
            {
                ABLL.Add(ADTO);
            }
            else
            {
                ADTO.AccountInfoId = Convert.ToInt32(hfAID.Value);
                ADTO.UpdateDate = System.DateTime.Now;
                ADTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                ABLL.Edit(ADTO);
                BtnSaveAccountIndfo.Text = "Save";
            }
            // pagingLoal_accountinfo();
            loadDataGVAccountInof(0, 0, "", "", "", "");
            clearCntrol_accountInfo();
        }

        private void clearCntrol_accountInfo()
        {
            txtAccountName.Text = "";
            txtAccountNameS.Text = "";
            txtAccountNum.Text = "";
            txtAccountNumberS.Text = "";
            txtaddress.Text = "";
            txtBankNameS.Text = "";
            txtBranch.Text = "";
            txtBranchNameS.Text = "";
            txtMobile.Text = "";
            txtPhone.Text = "";
            ddlCompBranchName.SelectedValue = "0";
            ddlAccountType.SelectedValue = "0";
            ddlBankName.SelectedValue = "0";
            RbActivationStatus.SelectedValue = "Active";
            BtnSaveAccountIndfo.Text = "Save";
            GVAccountInfo.SelectedIndex = -1;
        }
        protected void BtnCancelAccountInfo_Click(object sender, EventArgs e)
        {
            clearCntrol_accountInfo();
            //pagingLoal_accountinfo();
            loadDataGVAccountInof(0, 0, "", "", "", "");

        }


        private void loadDataGVAccountInof(int AccID, int BankID, string bankname, string branchname, string accname, string accnum)
        {
            //LoadAccountInfo(AccID, BankID, bankname, branchname, accname, accnum)
            var data = ABLL.LoadAccountInfo(AccID, BankID, bankname, branchname, accname, accnum);
            GVAccountInfo.DataSource = data;
            GVAccountInfo.DataBind();
        }

        protected void GVAccountInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVAccountInfo.PageIndex = e.NewPageIndex;
            loadDataGVAccountInof(0, 0, "", "", "", "");
        }
        protected void GVAccountInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<AccountInfoDTO> bb = new List<AccountInfoDTO>();
            bb = ABLL.LoadAccountInfo(Convert.ToInt32(GVAccountInfo.DataKeys[GVAccountInfo.SelectedIndex].Values["AccountInfoId"].ToString()), 0, "", "", "", "");
            // bb = ABLL.LoadAccountInfo(Convert.ToInt32(e.CommandArgument.ToString()), 0, "", "", "", "");
            hfAID.Value = bb.First().AccountInfoId.ToString();
            txtAccountName.Text = bb.First().AccountName.ToString();
            txtAccountNum.Text = bb.First().AccountNum.ToString();
            ddlBankName.SelectedValue = bb.First().BankId.ToString();
            ddlAccountType.SelectedValue = bb.First().AccountTypeId.ToString();
            txtaddress.Text = bb.First().Address.ToString();
            txtBranch.Text = bb.First().BranchName.ToString();
            txtMobile.Text = bb.First().Mobile.ToString();
            txtPhone.Text = bb.First().Phone.ToString();
            ddlCompBranchName.SelectedValue = bb.First().BrProId.ToString();
            RbActivationStatus.SelectedValue = bb.First().ActivationSatus.ToString();
            BtnSaveAccountIndfo.Text = "Update";
        }


        protected void txtAccountInfoIdS_TextChanged(object sender, EventArgs e)
        {
            Search();

        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        /*Start Javascript Popup ALert*/
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
            try
            {   //    (AccID,BankID, bankname,branchname,accname,accnum);
                var bb = ABLL.LoadAccountInfo(0, 0, txtBankNameS.Text.ToString(), txtBranchNameS.Text.ToString(), txtAccountNameS.Text.ToString(), txtAccountNumberS.Text.ToString());
                GVAccountInfo.DataSource = bb;
                GVAccountInfo.DataBind();
                if (bb.Count == 0)
                {
                    ScriptManager.RegisterClientScriptBlock(this, typeof(Page), " Guid.NewGuid", "alert('Hello');", true);
                    //Show("No Data Found!");
                }
            }
            catch
            {

            }
        }



        // for account info

        // for AccountType info insert

        protected void BtnAccountTypeSave_Click(object sender, EventArgs e)
        {
            if (TxtAccountType.Text.ToString() == "")
            {
                TxtAccountType.Focus();
                return;
            }
            ATDTO.AccountTypeName = TxtAccountType.Text.ToString();
            ATDTO.CreateDate = System.DateTime.Now;
            ATDTO.CreateBy = HttpContext.Current.User.Identity.Name;
            if (BtnAccountTypeSave.Text == "Save")
            {
                ATBLL.Add(ATDTO);
            }
            else
            {
                ATDTO.AccountTypeId = Convert.ToInt32(HfAccountType.Value);
                ATDTO.UpdateDate = System.DateTime.Now;
                ATDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                ATBLL.Edit(ATDTO);
                BtnAccountTypeSave.Text = "Save";
            }
            loadDataGVAccountType(0);
            clearCntrol_AccountType();
            GetAccountType();
        }
        private void clearCntrol_AccountType()
        {
            TxtAccountType.Text = "";
            BtnAccountTypeSave.Text = "Save";
            GVAccountType.SelectedIndex = -1;
        }
        protected void BtnAccountTypeSaveCLear_Click(object sender, EventArgs e)
        {
            clearCntrol_AccountType();

        }
        protected void GVAccountType_SelectedIndexChanged(object sender, EventArgs e)
        {

            var bb = ATBLL.LoadAccountTypeName(Convert.ToInt32(GVAccountType.DataKeys[GVAccountType.SelectedIndex].Values["AccountTypeId"].ToString()));

            HfAccountType.Value = bb.First().AccountTypeId.ToString();
            TxtAccountType.Text = bb.First().AccountTypeName.ToString();

            BtnAccountTypeSave.Text = "Update";
        }
        private void loadDataGVAccountType(int accounttypeId)
        {
            var data = ATBLL.LoadAccountTypeName(accounttypeId);
            GVAccountType.DataSource = data;
            GVAccountType.DataBind();
        }

        protected void GVAccountType_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVAccountType.PageIndex = e.NewPageIndex;
            loadDataGVAccountType(0);
        }

        // for AccountType info insert
        // for bank info insert

        private void LoadBankNam()
        {
            var data = TBLL.LoadBankName(0);
            GVBank.DataSource = data;
            GVBank.DataBind();
        }

        protected void GVBank_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVBank.PageIndex = e.NewPageIndex;
            LoadBankNam();
        }
        protected void GVBank_SelectedIndexChanged(object sender, EventArgs e)
        {

            var bb = TBLL.LoadBankName(Convert.ToInt32(GVBank.DataKeys[GVBank.SelectedIndex].Values["BankId"].ToString()));
            hfbankid.Value = bb.First().BankId.ToString();
            txtBankName.Text = bb.First().BankName.ToString();
            btnSave.Text = "Update";
        }


        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtBankName.Text.ToString() == "")
            {
                txtBankName.Focus();
                return;
            }
            DTO.BankName = txtBankName.Text.ToString();

            if (btnSave.Text == "Save")
            {
                DTO.CreateDate = System.DateTime.Now;
                DTO.CreateBy = HttpContext.Current.User.Identity.Name;
                TBLL.Add(DTO);
            }
            else
            {
                DTO.BankId = Convert.ToInt32(hfbankid.Value);
                DTO.UpdateDate = System.DateTime.Now;
                DTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                TBLL.Edit(DTO);
                btnSave.Text = "Save";
            }
            LoadBankNam();
            clearCntrol();
            GetBankName();
            // GetAccountType();
        }

        private void clearCntrol()
        {
            txtBankName.Text = "";
            btnSave.Text = "Save";
            LoadBankNam();
            GVBank.SelectedIndex = -1;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();

        }










        // for bank info insert

    }
}