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
    public partial class AccountHead : System.Web.UI.Page
    {
        MainHeadDTO MDTO = new MainHeadDTO();
        MainHeadBLL MBLL = new MainHeadBLL();

        SubCode_1DTO S1DTO = new SubCode_1DTO();
        SubCode_1BLL S1BLL = new SubCode_1BLL();

        SubCode_2DTO S2DTO = new SubCode_2DTO();
        SubCode_2BLL S2BLL = new SubCode_2BLL();


        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Account Head Creation";
                loadDataGVMainHead(0); // main head gv load data

                LoadMainHead_SubCode1();// sub code1 page load main head id
                if (ddlMainHeadCodeId.SelectedValue.ToString() != "")
                {

                    GernerateSubCode1(); // sub code1 page load aganist the mainhead code
                }
                loadDataSobCode_1(0, "", "", 0, "", ""); // sub code1 page gv data load

                LoadMainHead_SubCode2();// sub code2 page load main head id
                if (SC2_ddlMainHead.SelectedValue.ToString() != "")
                {
                    //   LoadMainHeadName_SubCode2(); // sub code2 page load main head name

                    LoadSubCodeId1_InSubCode2();// sub code1 in sub code2 page
                }
                if (SC2_ddlSubcode1.SelectedValue != "")
                {
                    // LoadSubCodeName1_InSubCode2();
                    // GernerateSubCode2();
                }

                loadDataSobCode_2(0, "", "", 0, "", "", "", "");
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
        // Start Code of Main head 
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtMainHeadNo.Text == "")
            {
                txtMainHeadNo.Focus();
                return;
            }
            if (txtMainHeadName.Text == "")
            {
                txtMainHeadName.Focus();
                return;
            }
            MDTO.MainHadeNum = txtMainHeadNo.Text.ToString();
            MDTO.MainHeadName = txtMainHeadName.Text.ToString();
            MDTO.Description = txtDescription.Text.ToString();
            MDTO.AID = 100;
            MDTO.CreateDate = System.DateTime.Now;
            MDTO.CreateBy = HttpContext.Current.User.Identity.Name;
            if (btnSave.Text == "Save")
            {
                MBLL.Add(MDTO);
                loadDataGVMainHead(0);
                clearCntrol();
                LoadMainHead_SubCode1();
            }
            else
            {
                MDTO.MainHeadId = Convert.ToInt32(HFMHID.Value);
                MDTO.UpdateDate = System.DateTime.Now;
                MDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                MBLL.Edit(MDTO);
                btnSave.Text = "Save";
                loadDataGVMainHead(0);
                clearCntrol();
                LoadMainHead_SubCode1();

            }

            LoadMainHead_SubCode2();// sub code2 page load main head id
            LoadSubCodeId1_InSubCode2();// sub code1 in sub code2 page
            GernerateSubCode1(); // generate subcode1

        }
        // gvmain head code
        private void loadDataGVMainHead(int id)
        {
            var data = MBLL.LoadMainHead(id);
            GVMainHead.DataSource = data;
            GVMainHead.DataBind();
        }

        protected void GVMainHead_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVMainHead.PageIndex = e.NewPageIndex;
            loadDataGVMainHead(0);
        }
        protected void GVMainHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<MainHeadDTO> bb = new List<MainHeadDTO>();
            bb = MBLL.LoadMainHead(Convert.ToInt32(GVMainHead.DataKeys[GVMainHead.SelectedIndex].Values["MainHeadId"].ToString()));
            HFMHID.Value = bb.First().MainHeadId.ToString();
            txtMainHeadNo.Text = bb.First().MainHadeNum.ToString();
            txtMainHeadName.Text = bb.First().MainHeadName.ToString();
            txtDescription.Text = bb.First().Description.ToString();
            btnSave.Text = "Update";
        }
        // gvmain head code

        private void clearCntrol()
        {
            txtDescription.Text = "";
            txtMainHeadName.Text = "";
            txtMainHeadNo.Text = "";
            btnSave.Text = "Save";
            GVMainHead.SelectedIndex = -1;
            // GVSubCode1.SelectedIndex = -1;
            //  SC2_Gv.SelectedIndex = -1;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();
            //Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }
        // End Code of Main  Head 


        // start  subcode1 


        // gvsub coed1 
        private void loadDataSobCode_1(int id, string SubcodeNum, string SubCodename, int mainheadid, string mainheadname, string mainheadno)
        {
            var data = S1BLL.LoadSuvCode_1Data(id, SubcodeNum, SubCodename, mainheadid, mainheadname, mainheadno);
            GVSubCode1.DataSource = data;
            GVSubCode1.DataBind();
        }

        protected void GVSubCode1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVSubCode1.PageIndex = e.NewPageIndex;
            loadDataSobCode_1(0, "", "", 0, "", "");
        }
        protected void GVSubCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<SubCode_1DTO> bb = new List<SubCode_1DTO>();
            bb = S1BLL.LoadSuvCode_1Data(Convert.ToInt32(GVSubCode1.DataKeys[GVSubCode1.SelectedIndex].Values["SubCode_1Id"].ToString()), "", "", 0, "", "");
            HFSC1.Value = bb.First().SubCode_1Id.ToString();
            ddlMainHeadCodeId.SelectedValue = bb.First().MainHeadId.ToString();

            txtSubCode1Name.Text = bb.First().SubCode_1Name.ToString();
            txtSubCode1No.Text = bb.First().SubCode_1Num.ToString();
            txtSubCode1Description.Text = bb.First().Description.ToString();
            btnSaveSubCode1.Text = "Update";
        }

        // gv Subcode1  

        private void LoadMainHead_SubCode1() // MainVoucherName
        {
            var query = MBLL.LoadMainHead(0);
            ddlMainHeadCodeId.DataSource = query;
            ddlMainHeadCodeId.DataTextField = "MainHeadName_Num";
            ddlMainHeadCodeId.DataValueField = "MainHeadId";
            ddlMainHeadCodeId.DataBind();
            //  ddlMainVoucher.Items.Insert(0, new ListItem("Select Type Name", "0"));
        }



        protected void ddlMainHeadCodeId_SelectedIndexChanged(object sender, EventArgs e)
        {

            GernerateSubCode1();
        }

        //generate sub code1 code no# START
        public void GernerateSubCode1()
        {
            List<SubCode_1DTO> bb = new List<SubCode_1DTO>();
            bb = S1BLL.LoadSuvCode_1Data(0, "", "", Convert.ToInt32(ddlMainHeadCodeId.SelectedValue), "", "");


            List<MainHeadDTO> bb1 = new List<MainHeadDTO>();
            bb1 = MBLL.LoadMainHead(Convert.ToInt32(ddlMainHeadCodeId.SelectedValue));

            if (bb.Count() == 0)
            {
                int GenerateSubCode = Convert.ToInt32(bb1.First().MainHadeNum.ToString());
                GenerateSubCode = GenerateSubCode + 1;
                txtSubCode1No.Text = Convert.ToString(GenerateSubCode);
            }
            else
            {
                int GenerateSubCode = Convert.ToInt32(bb.First().SubCode_1Num.ToString());// +"01";
                GenerateSubCode = GenerateSubCode + 1;
                txtSubCode1No.Text = Convert.ToString(GenerateSubCode);
            }
        }


        //generate sub voucher code no#  END

        protected void btnSaveSubCode1_Click(object sender, EventArgs e)
        {
            S1DTO.SubCode_1Num = txtSubCode1No.Text.ToString();
            S1DTO.SubCode_1Name = txtSubCode1Name.Text.ToString();
            S1DTO.Description = txtSubCode1Description.Text.ToString();
            S1DTO.MainHeadId = Convert.ToInt32(ddlMainHeadCodeId.SelectedValue);

            if (btnSaveSubCode1.Text == "Save")
            {
                S1DTO.CreateBy = HttpContext.Current.User.Identity.Name;
                S1DTO.CreateDate = System.DateTime.Now;
                S1BLL.Add(S1DTO);
            }
            else
            {
                S1DTO.SubCode_1Id = Convert.ToInt32(HFSC1.Value);
                S1DTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                S1DTO.UpdateDate = System.DateTime.Now;
                S1BLL.Edit(S1DTO);
            }

            GernerateSubCode1();
            LoadSubCodeId1_InSubCode2();
            LoadMainHead_SubCode2();// sub code2 page load main head id

            LoadSubCodeId1_InSubCode2();// sub code1 in sub code2 page

            GernerateSubCode2();
            ClearContorl();

        }

        protected void btnCancelSubCode1_Click(object sender, EventArgs e)
        {
            ClearContorl();
            //Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

        private void ClearContorl()
        {
            txtSubCode1Description.Text = "";
            txtSubCode1Name.Text = "";
            GVMainHead.SelectedIndex = -1;
            GVSubCode1.SelectedIndex = -1;
            txtMainHeadId_S.Text = "";
            txtMainHeadName_S.Text = "";
            txtSubCode1ID_S.Text = "";
            txtSubCode1Name_S.Text = "";
            loadDataSobCode_1(0, "", "", 0, "", "");
        }

        public void Search_SubCode1Page()
        {
            var data = S1BLL.LoadSuvCode_1Data(0, txtSubCode1ID_S.Text.ToString(), txtSubCode1Name_S.Text.ToString(), 0, txtMainHeadName_S.Text.ToString(), txtMainHeadId_S.Text.ToString());
            GVSubCode1.DataSource = data;
            GVSubCode1.DataBind();
        }

        protected void txtSubCode1ID_S_TextChanged(object sender, EventArgs e)
        {
            Search_SubCode1Page();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search_SubCode1Page();
        }
        // end Sub Code1



        // Start Sub Code 2 

        private void LoadMainHead_SubCode2() // MainVoucherName
        {
            var query = MBLL.LoadMainHead(0);
            SC2_ddlMainHead.DataSource = query;
            SC2_ddlMainHead.DataTextField = "MainHeadName_Num";
            SC2_ddlMainHead.DataValueField = "MainHeadId";
            SC2_ddlMainHead.DataBind();
            SC2_ddlMainHead.Items.Insert(0, new ListItem("Select One", "0"));
        }



        protected void SC2_ddlMainHead_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadSubCodeId1_InSubCode2();

            txtSC2_No2.Text = "";

        }

        private void LoadSubCodeId1_InSubCode2() // SubCode2 Page Subcode1 load
        {
            var query = S1BLL.LoadSuvCode_1Data(0, "", "", Convert.ToInt32(SC2_ddlMainHead.SelectedValue), "", "");
            SC2_ddlSubcode1.DataSource = query;
            SC2_ddlSubcode1.DataTextField = "SubCode1Name_Num";
            SC2_ddlSubcode1.DataValueField = "SubCode_1Id";
            SC2_ddlSubcode1.DataBind();
            SC2_ddlSubcode1.Items.Insert(0, new ListItem("Select One", "0"));
        }



        protected void SC2_ddlSubcode1_SelectedIndexChanged(object sender, EventArgs e)
        {

            GernerateSubCode2();
            // txtSC2_No2.Text = "";

        }
        //generate sub code2 code no# START
        public void GernerateSubCode2()
        {
            List<SubCode_2DTO> bb2 = new List<SubCode_2DTO>();
            bb2 = S2BLL.LoadSuvCode_2Data(0, "", "", Convert.ToInt32(SC2_ddlSubcode1.SelectedValue), "", "", "", "");

            if (bb2.Count() == 0)
            {
                char[] a = new char[] { '-' };
                string[] un = SC2_ddlSubcode1.SelectedItem.ToString().Split(a);

                string GenerateSubCode = un[0];
                GenerateSubCode = GenerateSubCode + "001";
                txtSC2_No2.Text = Convert.ToString(GenerateSubCode);
            }

            else
            {
                // char[] a = new char[] { '-' };
                //string[] un = SC2_ddlSubcode1.SelectedItem.ToString().Split(a);

                //  string GenerateSubCode = un[0];
                int GenerateSubCode = Convert.ToInt32(bb2.First().SubCode2_Num.ToString());// +"01";
                GenerateSubCode = GenerateSubCode + 1;
                txtSC2_No2.Text = Convert.ToString(GenerateSubCode);
            }
        }
        private void loadDataSobCode_2(int id, string Subcode2Num, string SubCode2name, int sucodeid1, string subc1no, string subcode1name, string mainheadno, string mainheadname)
        {
            var data = S2BLL.LoadSuvCode_2Data(id, Subcode2Num, SubCode2name, sucodeid1, subc1no, subcode1name, mainheadno, mainheadname);
            SC2_Gv.DataSource = data;
            SC2_Gv.DataBind();
        }

        protected void SC2_Gv_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            SC2_Gv.PageIndex = e.NewPageIndex;
            loadDataSobCode_2(0, "", "", 0, "", "", "", "");
        }
        protected void SC2_Gv_SelectedIndexChanged(object sender, EventArgs e)
        {
            SC2_ddlMainHead.SelectedValue = "0";
            SC2_ddlSubcode1.SelectedValue = "0";
            List<SubCode_2DTO> bb = new List<SubCode_2DTO>();
            //  bb = S1BLL.LoadSuvCode_1Data(Convert.ToInt32(GVSubCode1.DataKeys[GVSubCode1.SelectedIndex].Values["SubCode_1Id"].ToString()), 0, "", 0);
            bb = S2BLL.LoadSuvCode_2Data(Convert.ToInt32(SC2_Gv.DataKeys[SC2_Gv.SelectedIndex].Values["SubCode_2Id"].ToString()), "", "", 0, "", "", "", "");
            HFSC2_Id2.Value = bb.First().SubCode_2Id.ToString();
            SC2_ddlMainHead.SelectedValue = bb.First().MainHeadId.ToString();
            SC2_ddlSubcode1.SelectedValue = bb.First().SubCode_1Id.ToString();

            txtSC2_Name.Text = bb.First().SubCode_2Name.ToString();
            txtSC2_No2.Text = bb.First().SubCode2_Num.ToString();
            txtSC2_Description.Text = bb.First().Description.ToString();
            btnSC2_Save.Text = "Update";
        }


        protected void btnSC2_Save_Click(object sender, EventArgs e)
        {

            S2DTO.SubCode_1Id = Convert.ToInt32(SC2_ddlSubcode1.SelectedValue);
            S2DTO.SubCode2_Num = Convert.ToString(txtSC2_No2.Text);
            S2DTO.SubCode_2Name = txtSC2_Name.Text.ToString();
            S2DTO.Description = txtSC2_Description.Text.ToString();

            if (btnSC2_Save.Text == "Save")
            {
                S2DTO.CreateBy = HttpContext.Current.User.Identity.Name;
                S2DTO.CreateDate = System.DateTime.Now;
                S2BLL.Add(S2DTO);
            }
            else
            {
                S2DTO.SubCode_2Id = Convert.ToInt32(HFSC2_Id2.Value);
                S2DTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                S2DTO.UpdateDate = System.DateTime.Now;
                S2BLL.Edit(S2DTO);
                btnSC2_Save.Text = "Save";
            }
            clearSubcode_2();
            GernerateSubCode2();
            txtSC2_No2.Text = "";
        }

        protected void btnSC2_Clear_Click(object sender, EventArgs e)
        {
            clearSubcode_2();
        }

        public void clearSubcode_2()
        {
            loadDataSobCode_2(0, "", "", 0, "", "", "", "");
            GVMainHead.SelectedIndex = -1;
            GVSubCode1.SelectedIndex = -1;
            SC2_Gv.SelectedIndex = -1;

            SC2_ddlMainHead.SelectedValue = "0";
            SC2_ddlSubcode1.SelectedValue = "0";
            txtSC2_Name.Text = "";
            txtSC2_Description.Text = "";

            txtSC2_Name.Text = "";
            txtSC2_No2.Text = "";
            btnSC2_Save.Text = "Save";
            txt_S_S2_MainHeadName.Text = "";
            txt_S_S2_MainHeadNo.Text = "";
            txt_S_S2_SubCode1Id.Text = "";
            txt_S_S2_SubCode1Name.Text = "";
            txt_S_S2_SubCode2Name.Text = "";
            txt_S_S2_SucCode2_Id.Text = "";



        }
        public void Search_SubCode2Page()
        {                                   // (int id, string Subcode2Num, string SubCode2name, int sucodeid1, string subc1no, string subcode1name, string mainheadno, string mainheadname)
            var data = S2BLL.LoadSuvCode_2Data(0, txt_S_S2_SucCode2_Id.Text.ToString(), txt_S_S2_SubCode2Name.Text.ToString(), 0, txt_S_S2_SubCode1Id.Text.ToString(), txt_S_S2_SubCode1Name.Text.ToString(), txt_S_S2_MainHeadNo.Text.ToString(), txt_S_S2_MainHeadName.Text.ToString());
            SC2_Gv.DataSource = data;
            SC2_Gv.DataBind();
        }

        protected void txtSubCode2ID_S_TextChanged(object sender, EventArgs e)
        {
            Search_SubCode2Page();
        }

        protected void BtnSearchSubCode2_Click(object sender, EventArgs e)
        {
            Search_SubCode2Page();
        }




        // End Sub Code 2


    }
}