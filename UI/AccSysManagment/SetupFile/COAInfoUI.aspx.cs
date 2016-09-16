using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABLL;
using ADTO;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.AccSysManagment.SetupFile
{
    public partial class COAInfoUI : System.Web.UI.Page
    {
        MainHeadDTO MDTO = new MainHeadDTO();
        MainHeadBLL MBLL = new MainHeadBLL();

        SubCode_1DTO S1DTO = new SubCode_1DTO();
        SubCode_1BLL S1BLL = new SubCode_1BLL();

        SubCode_2DTO S2DTO = new SubCode_2DTO();
        SubCode_2BLL S2BLL = new SubCode_2BLL();

        COAInfoDTO CDTO = new COAInfoDTO();
        COAInfoBLL CBLL = new COAInfoBLL();

        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "COA Setup";
                LoadMainHead();
                LoadSubCodeId1();
                LoadSubCodeId2();
                loadDataGVCOA(0, "", "", 0, "", "", "", "", "", "");
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
        // start main head
        private void LoadMainHead()
        {
            var query = MBLL.LoadMainHead(0);
            ddlMainHeadCodeId.DataSource = query;
            ddlMainHeadCodeId.DataTextField = "MainHeadName_Num";
            ddlMainHeadCodeId.DataValueField = "MainHeadId";
            ddlMainHeadCodeId.DataBind();
            ddlMainHeadCodeId.Items.Insert(0, new ListItem("Select One", "0"));
        }

        protected void ddlMainHeadCodeId_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubCodeId1();
            LoadSubCodeId2();
            txtAccountId.Text = "";
        }// end main head


        // start sub code1
        private void LoadSubCodeId1()
        {
            var query = S1BLL.LoadSuvCode_1Data(0, "", "", Convert.ToInt32(ddlMainHeadCodeId.SelectedValue), "", "");
            ddlSubcode1.DataSource = query;
            ddlSubcode1.DataTextField = "SubCode1Name_Num";
            ddlSubcode1.DataValueField = "SubCode_1Id";
            ddlSubcode1.DataBind();
            ddlSubcode1.Items.Insert(0, new ListItem("Select One", "0"));
        }

        protected void ddlSubcode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubCodeId2();
            txtAccountId.Text = "";
        }  // End Sub code1

        // start sub code2
        private void LoadSubCodeId2()
        {
            var query = S2BLL.LoadSuvCode_2Data(0, "", "", Convert.ToInt32(ddlSubcode1.SelectedValue), "", "", "", "");
            //var query = S2BLL.LoadSuvCode_2Data_COAPage(0, "", Convert.ToInt32(ddlMainHeadCodeId.SelectedValue), Convert.ToInt32(ddlSubcode1.SelectedValue), 0);
            ddlSubcode2.DataSource = query;
            ddlSubcode2.DataTextField = "SubCode2Name_Num";
            ddlSubcode2.DataValueField = "SubCode_2Id";
            ddlSubcode2.DataBind();
            ddlSubcode2.Items.Insert(0, new ListItem("Select One", "0"));
        }

        protected void ddlSubcode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            GernerateCOA();
        }// end of ssub code 2

        // generate COA Id
        public void GernerateCOA()
        {
            List<SubCode_2DTO> bb = new List<SubCode_2DTO>();
            bb = S2BLL.LoadSuvCode_2Data_COAPage(0, "", 0, 0, Convert.ToInt32(ddlSubcode2.SelectedValue));

            List<COAInfoDTO> bb1 = new List<COAInfoDTO>();
            bb1 = CBLL.LoadCoAInfo(0, "", "", Convert.ToInt32(ddlSubcode2.SelectedValue), "", "", "", "", "", "");

            if (bb1.Count() == 0)
            {
                string GenerateSubCode = Convert.ToString(bb.First().SubCode2_Num.ToString());
                GenerateSubCode = GenerateSubCode + "001";
                txtAccountId.Text = Convert.ToString(GenerateSubCode);
            }

            else
            {

                Int64 GenerateSubCode = Convert.ToInt64(bb1.First().COAACCId.ToString());// +"01";
                GenerateSubCode = GenerateSubCode + 1;
                txtAccountId.Text = Convert.ToString(GenerateSubCode);
            }
        }// end of COA ID Generation

        // GVCOA head code
        private void loadDataGVCOA(int id, string CoaNo, string accountName, int subcode_2id, string s2no, string s2name, string s1no, string s1name, string MHeadNo, string MHeadname)
        {
            var data = CBLL.LoadCoAInfo(id, CoaNo, accountName, subcode_2id, s2no, s2name, s1no, s1name, MHeadNo, MHeadname);
            GVCOA.DataSource = data;
            GVCOA.DataBind();
            //lblNoOFDataCount.Text = Convert.ToString( GVCOA.items.count);
        }

        protected void GVCOA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVCOA.PageIndex = e.NewPageIndex;
            loadDataGVCOA(0, "", "", 0, "", "", "", "", "", "");
        }
        protected void GVCOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<COAInfoDTO> bb = new List<COAInfoDTO>();
            bb = CBLL.LoadCoAInfo(Convert.ToInt32(GVCOA.DataKeys[GVCOA.SelectedIndex].Values["COAId"].ToString()), "", "", 0, "", "", "", "", "", "");
            HFCOAID.Value = bb.First().COAId.ToString();

            txtDescription.Text = bb.First().Description.ToString();
            txtAccountId.Text = bb.First().COAACCId.ToString();

            txtBalance.Text = bb.First().Balance.ToString();
            txtAccountName.Text = bb.First().AccountName.ToString();

            ddlMainHeadCodeId.SelectedValue = bb.First().MainHeadId.ToString();

            ddlSubcode1.SelectedValue = bb.First().SubCode_1Id.ToString();

            ddlSubcode2.SelectedValue = bb.First().SubCode_2Id.ToString();

            string[] str = new string[] { " bb.First().OpeningDate.ToString()" };
            // string[] countries = new string[] { "str" };
            str = DateTime.Now.Date.ToShortDateString().Split('/');
            int yearnew = Convert.ToInt16(str[2]);



            btnSave.Text = "Update";
        }
        // gvmain head code

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            CLearControl();
        }

        private void CLearControl()
        {
            txtAccountId.Text = "";
            txtAccountName.Text = "";
            txtBalance.Text = "";
            txtDescription.Text = "";
            loadDataGVCOA(0, "", "", 0, "", "", "", "", "", "");
            LoadMainHead();
            LoadSubCodeId1();
            LoadSubCodeId2();
            GVCOA.SelectedIndex = -1;
            btnSave.Text = "Save";

            txt_S_S2_COAID.Text = "";
            txt_S_S2_COAName.Text = "";
            txt_S_S2_MainHeadName.Text = "";
            txt_S_S2_MainHeadNo.Text = "";
            txt_S_S2_SubCode1Id.Text = "";
            txt_S_S2_SubCode1Name.Text = "";
            txt_S_S2_SubCode2Name.Text = "";
            txt_S_S2_SucCode2_Id.Text = "";

        }


        protected void btnSave_Click(object sender, EventArgs e)
        {

            CDTO.COAACCId = Convert.ToString(txtAccountId.Text);
            CDTO.AccountName = txtAccountName.Text.ToString();
            CDTO.SubCode_2Id = Convert.ToInt32(ddlSubcode2.SelectedValue);
            //  if (txtDescription.Text.ToString() != "")
            CDTO.Description = txtDescription.Text.ToString();
            if (txtBalance.Text.ToString() != "")
                CDTO.Balance = Convert.ToDouble(txtBalance.Text);

            if (btnSave.Text == "Save")
            {
                CDTO.OpenBy = HttpContext.Current.User.Identity.Name;
                CDTO.OpeningDate = System.DateTime.Now;
                CBLL.Add(CDTO);

            }
            else
            {
                CDTO.COAId = Convert.ToInt32(HFCOAID.Value);
                CDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                CDTO.UpdateDate = System.DateTime.Now;
                CBLL.Edit(CDTO);
                btnSave.Text = "Save";
            }
            CLearControl();


        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {

            Search();

        }
        protected void txtSubCode2ID_S_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        public void Search()
        {    // (int id,string CoaNo, string accountName, int subcode_2id, string s2no, string s2name, string s1no, string s1name, string MHeadNo,string MHeadname)
            var data = CBLL.LoadCoAInfo(0, txt_S_S2_COAID.Text.ToString(), txt_S_S2_COAName.Text.ToString(), 0, txt_S_S2_SucCode2_Id.Text.ToString(), txt_S_S2_SubCode2Name.Text.ToString(), txt_S_S2_SubCode1Id.Text.ToString(), txt_S_S2_SubCode1Name.Text.ToString(), txt_S_S2_MainHeadNo.Text.ToString(), txt_S_S2_MainHeadName.Text.ToString());
            GVCOA.DataSource = data;
            GVCOA.DataBind();

        }

    }
}