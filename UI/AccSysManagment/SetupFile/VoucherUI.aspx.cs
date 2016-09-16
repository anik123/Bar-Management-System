using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADTO;
using ABLL;
using System.Data;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.AccSysManagment.SetupFile
{
    public partial class VoucherUI : System.Web.UI.Page
    {
        MainVoucherDTO MDTO = new MainVoucherDTO();
        MainVoucherBLL MBLL = new MainVoucherBLL();
        SubVoucherDTO SDTO = new SubVoucherDTO();
        SubVoucherBLL SBLL = new SubVoucherBLL();

        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();

                Page.Title = "Voucher";
                loadDataGVMainVoucher(0);
                loadDataGVSubVoucher(0, 0);

                LoadMainVocher();
                if (ddlMainVoucher.SelectedValue.ToString() != "")
                {
                    GernerateSubVoucherCode();// generate sub voucher code
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
        // tab
        // main voucher code start from here
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMainVoucherNo.Text == "")
            {
                txtMainVoucherNo.Focus();
                return;
            }

            if (txtMainVoucherName.Text == "")
            {
                txtMainVoucherName.Focus();
                return;
            }

            MDTO.MainVoucherName = txtMainVoucherName.Text.ToString();
            MDTO.MainVoucherCode = txtMainVoucherNo.Text.ToString();
            MDTO.CreateDate = System.DateTime.Now;
            MDTO.CreateBy = HttpContext.Current.User.Identity.Name;
            if (btnSave.Text == "Save")
            {
                MBLL.Add(MDTO);

                clearCntrol_mainVoucher();
                loadDataGVMainVoucher(0);
            }
            else
            {
                MDTO.MainVoucherId = Convert.ToInt32(HFMVID.Value);
                MDTO.UpdateDate = System.DateTime.Now;
                MDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                MBLL.Edit(MDTO);
                btnSave.Text = "Save";
                clearCntrol_mainVoucher();
                loadDataGVMainVoucher(0);
            }
            LoadMainVocher();
            GernerateSubVoucherCode();// generate sub voucher code
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }


        private void clearCntrol_mainVoucher()
        {
            this.ViewState["CurrentData"] = null;
            DataTable dt = new DataTable();
            GVMainVoucher.DataSource = dt;
            GVMainVoucher.DataBind();

            txtMainVoucherNo.Text = "";
            txtMainVoucherName.Text = "";
            loadDataGVMainVoucher(0);
            btnSave.Text = "Save";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol_mainVoucher();
            loadDataGVMainVoucher(0);
        }

        // gvmain voucher code
        private void loadDataGVMainVoucher(int id)
        {
            var data = MBLL.LoadMainVocher(id);
            GVMainVoucher.DataSource = data;
            GVMainVoucher.DataBind();
        }

        protected void GVMainVoucher_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVMainVoucher.PageIndex = e.NewPageIndex;
            loadDataGVMainVoucher(0);
        }
        protected void GVMainVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<MainVoucherDTO> bb = new List<MainVoucherDTO>();
            bb = MBLL.LoadMainVocher(Convert.ToInt32(GVMainVoucher.DataKeys[GVMainVoucher.SelectedIndex].Values["MainVoucherId"].ToString()));
            HFMVID.Value = bb.First().MainVoucherId.ToString();
            txtMainVoucherName.Text = bb.First().MainVoucherName.ToString();
            txtMainVoucherNo.Text = bb.First().MainVoucherCode.ToString();
            btnSave.Text = "Update";
        }



        // gvmain voucher code

        // main voucher code end here


        // sub vocher code start 

        protected void BtnSubVoucheerSave_Click(object sender, EventArgs e)
        {
            if (txtSubVNAME.Text == "")
            {
                txtSubVNAME.Focus();
                return;
            }
            //if (txtMainVoucherName.Text == "")
            //{
            //    txtMainVoucherName.Focus();
            //    return;
            //}

            SDTO.SubVoucherCode = txtSubVNO.Text.ToString();
            SDTO.SubVoucherName = txtSubVNAME.Text.ToString();
            SDTO.MainVoucherId = Convert.ToInt32(ddlMainVoucher.SelectedValue);
            SDTO.CreateDate = System.DateTime.Now;
            SDTO.CreateBy = HttpContext.Current.User.Identity.Name;
            if (BtnSubVoucheerSave.Text == "Save")
            {
                SBLL.Add(SDTO);
                clearCntrol_SUbVoucher();
                loadDataGVSubVoucher(0, 0);
                GernerateSubVoucherCode();

            }
            else
            {
                SDTO.SubVoucherId = Convert.ToInt32(HFSVID.Value);
                SDTO.MainVoucherId = Convert.ToInt32(ddlMainVoucher.SelectedValue);
                SDTO.UpdateDate = System.DateTime.Now;
                SDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                SBLL.Edit(SDTO);
                btnSave.Text = "Save";
                clearCntrol_SUbVoucher();

                loadDataGVSubVoucher(0, 0);
                GernerateSubVoucherCode();
            }
            clearCntrol_SUbVoucher();

        }


        private void clearCntrol_SUbVoucher()
        {
            this.ViewState["CurrentData"] = null;
            DataTable dt = new DataTable();
            GVSubVoucher.DataSource = dt;
            GVSubVoucher.DataBind();
            GVSubVoucher.SelectedIndex = -1;
            loadDataGVMainVoucher(0);
            loadDataGVSubVoucher(0, 0);
            GernerateSubVoucherCode();
            txtSubVNAME.Text = "";
            // txtSubVNO.Text = "";
            BtnSubVoucheerSave.Text = "Save";
        }
        protected void BtnSubVoucheerClear_Click(object sender, EventArgs e)
        {
            clearCntrol_SUbVoucher();
            // loadDataGVMainVoucher(0);
        }



        // gvsub voucher code
        private void loadDataGVSubVoucher(int id, int mainvoucehrid)
        {
            var data = SBLL.LoadSubVoucherData(id, mainvoucehrid);
            GVSubVoucher.DataSource = data;
            GVSubVoucher.DataBind();
        }

        protected void GVSubVoucher_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVSubVoucher.PageIndex = e.NewPageIndex;
            loadDataGVSubVoucher(0, 0);
        }
        protected void GVSubVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<SubVoucherDTO> bb = new List<SubVoucherDTO>();
            bb = SBLL.LoadSubVoucherData(Convert.ToInt32(GVSubVoucher.DataKeys[GVSubVoucher.SelectedIndex].Values["SubVoucherId"].ToString()), 0);
            HFSVID.Value = bb.First().SubVoucherId.ToString();
            txtSubVNAME.Text = bb.First().SubVoucherName.ToString();
            txtSubVNO.Text = bb.First().SubVoucherCode.ToString();
            ddlMainVoucher.SelectedValue = bb.First().MainVoucherId.ToString();
            BtnSubVoucheerSave.Text = "Update";
        }

        // gvsub voucher code
        protected void ddlMainVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            GernerateSubVoucherCode();
        }

        private void LoadMainVocher() // MainVoucherName
        {
            var query = MBLL.LoadMainVocher(0);
            ddlMainVoucher.DataSource = query;
            ddlMainVoucher.DataTextField = "MainVoucherCode_Name";
            ddlMainVoucher.DataValueField = "MainVoucherId";
            ddlMainVoucher.DataBind();
            //  ddlMainVoucher.Items.Insert(0, new ListItem("Select Type Name", "0"));
        }

        //generate sub voucher code no# START
        public void GernerateSubVoucherCode()
        {
            List<SubVoucherDTO> bb = new List<SubVoucherDTO>();
            bb = SBLL.GenerateSuvCodeNo(Convert.ToInt32(ddlMainVoucher.SelectedValue));
            // int SuBVocherCodeNO
            List<MainVoucherDTO> bb1 = new List<MainVoucherDTO>();
            bb1 = MBLL.LoadMainVocher(Convert.ToInt32(ddlMainVoucher.SelectedValue));

            if (bb.Count() == 0)
            //if (bb.First().MainVoucherCode.ToString() == "")
            {
                string GenerateSubCode = bb1.First().MainVoucherCode.ToString() + "01";
                txtSubVNO.Text = GenerateSubCode;
            }

            else
            {
                //int roww = Convert.ToInt32(row.ToString());
                //int subcode = roww + 1;
                //maxSub = subcode.ToString();
                int GenerateSubCode = Convert.ToInt32(bb.First().SubVoucherCode.ToString());// +"01";
                // int Row = bb.Count();
                //int subcode= Row +1;
                GenerateSubCode = GenerateSubCode + 1;
                txtSubVNO.Text = Convert.ToString(GenerateSubCode);
            }
        }
        //generate sub voucher code no#  END
        // end sub voucher code end
    }
}