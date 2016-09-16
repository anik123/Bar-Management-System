using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABLL;
using ADTO;
using System.Web.Security;
using PBLL.Page_ObjectBLL;

namespace UI.AccSysManagment.Report_Setup_File
{
    public partial class CashFlowEntityUI : System.Web.UI.Page
    {
        CashFlowBLL CFBLL = new CashFlowBLL();
        CashFolwEntityDTO CFDTO = new CashFolwEntityDTO();

        MainHeadDTO MDTO = new MainHeadDTO();
        MainHeadBLL MBLL = new MainHeadBLL();

        SubCode_1DTO S1DTO = new SubCode_1DTO();
        SubCode_1BLL S1BLL = new SubCode_1BLL();

        SubCode_2DTO S2DTO = new SubCode_2DTO();
        SubCode_2BLL S2BLL = new SubCode_2BLL();

        COAInfoDTO CDTO = new COAInfoDTO();
        COAInfoBLL CBLL = new COAInfoBLL();

        CashFlowRptBLL CFRBLL = new CashFlowRptBLL();
        CashFlowReportDTO CFRDTO = new CashFlowReportDTO();

        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               // RoleName();
                Page.Title = "Cash Flow Setup";
                LaodCashFlowGridData(0);
                // load cash flow rpt
                LoadMainHead();
                LoadSubCodeId1();
                LoadSubCodeId2();
                LoadCOA();
                LoadCashFlowEntity();
                LaodCashFlowRpt(0, "", "", "", "", "");
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
        // main voucher code start from here

        private void clearCntrol_CashFlow()
        {
            txtCashFlowEntity.Text = "";
            txtPriority.Text = "";
            btnSaveCashFlow.Text = "Save";
            GvCFE.SelectedIndex = -1;
            LaodCashFlowGridData(0);
        }


        // gv cash flow code
        private void LaodCashFlowGridData(int id)
        {
            var data = CFBLL.LoadCashFlowEntity(id);
            GvCFE.DataSource = data;
            GvCFE.DataBind();
        }

        protected void GvCFE_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvCFE.PageIndex = e.NewPageIndex;
            LaodCashFlowGridData(0);
        }
        protected void GvCFE_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CashFolwEntityDTO> bb = new List<CashFolwEntityDTO>();
            bb = CFBLL.LoadCashFlowEntity(Convert.ToInt32(GvCFE.DataKeys[GvCFE.SelectedIndex].Values["CFEId"].ToString()));
            HFCFID.Value = bb.First().CFEId.ToString();
            txtCashFlowEntity.Text = bb.First().CFEName.ToString();
            txtPriority.Text = bb.First().Priority.ToString();
            btnSaveCashFlow.Text = "Update";
        }

        protected void btnSaveCashFlow_Click(object sender, EventArgs e)
        {
            CFDTO.CFEName = txtCashFlowEntity.Text.ToString();
            CFDTO.Priority = Convert.ToInt16(txtPriority.Text);
            CFDTO.CreateDate = System.DateTime.Now;
            CFDTO.CreateBy = HttpContext.Current.User.Identity.Name;
            if (btnSaveCashFlow.Text == "Save")
            {
                CFBLL.Add(CFDTO);
            }
            else
            {
                CFDTO.CFEId = Convert.ToInt32(HFCFID.Value);
                CFDTO.UpdateDate = System.DateTime.Now;
                CFDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                CFBLL.Edit(CFDTO);

            }
            clearCntrol_CashFlow();
            LoadCashFlowEntity();

        }

        protected void btnCancelCashFlow_Click(object sender, EventArgs e)
        {
            clearCntrol_CashFlow();

        }
        //  End of Cash Flow Entity Set up


        // start for rpt entity setup

        // cash flow entity
        private void LoadCashFlowEntity()
        {
            var query = CFBLL.LoadCashFlowEntity(0);
            ddlCashFlowEntity.DataSource = query;
            ddlCashFlowEntity.DataTextField = "CFEName";
            ddlCashFlowEntity.DataValueField = "CFEId";
            ddlCashFlowEntity.DataBind();
            ddlCashFlowEntity.Items.Insert(0, new ListItem("Select One", "0"));
        }
        //  main head
        private void LoadMainHead()
        {
            var query = MBLL.LoadMainHead(0);
            ddlMainHeadCodeId_DR.DataSource = query;
            ddlMainHeadCodeId_DR.DataTextField = "MainHeadName_Num";
            ddlMainHeadCodeId_DR.DataValueField = "MainHeadId";
            ddlMainHeadCodeId_DR.DataBind();
            ddlMainHeadCodeId_DR.Items.Insert(0, new ListItem("Select One", "0"));
        }

        //  sub code1
        private void LoadSubCodeId1()
        {
            var query = S1BLL.LoadSuvCode_1Data(0, "", "", Convert.ToInt32(ddlMainHeadCodeId_DR.SelectedValue), "", "");
            ddlSubcode1_DR.DataSource = query;
            ddlSubcode1_DR.DataTextField = "SubCode1Name_Num";
            ddlSubcode1_DR.DataValueField = "SubCode_1Id";
            ddlSubcode1_DR.DataBind();
            ddlSubcode1_DR.Items.Insert(0, new ListItem("Select One", "0"));
        }
        // start sub code2
        private void LoadSubCodeId2()
        {

            var query = S2BLL.LoadSuvCode_2Data(0, "", "", Convert.ToInt32(ddlSubcode1_DR.SelectedValue), "", "", "", "");
            ddlSubcode2_DR.DataSource = query;
            ddlSubcode2_DR.DataTextField = "SubCode2Name_Num";
            ddlSubcode2_DR.DataValueField = "SubCode_2Id";
            ddlSubcode2_DR.DataBind();
            ddlSubcode2_DR.Items.Insert(0, new ListItem("Select One", "0"));
        }
        // start sub code2
        private void LoadCOA()
        {

            var query = CBLL.LoadCoAInfo(0, "", "", Convert.ToInt32(ddlSubcode2_DR.SelectedValue), "", "", "", "", "", "");
            ddlCOA_DR.DataSource = query;
            ddlCOA_DR.DataTextField = "COAName_Num";
            ddlCOA_DR.DataValueField = "COAId";
            ddlCOA_DR.DataBind();
            ddlCOA_DR.Items.Insert(0, new ListItem("Select One", "0"));
        }

        protected void ddlMainHeadCodeId_DR_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubCodeId1();
            LoadSubCodeId2();
            LoadCOA();
        }

        protected void ddlSubcode1_DR_SelectedIndexChanged(object sender, EventArgs e)
        {

            LoadSubCodeId2();
            LoadCOA();
        }

        protected void ddlSubcode2_DR_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCOA();
        }

       
        // gv cash flow code
        private void LaodCashFlowRpt(int crid, string cfname, string coaname, string subcode2name, string subcode1name, string mainheadname)
        {
            var data = CFRBLL.LoadCashFlowRptData(crid, cfname, coaname, subcode2name, subcode1name, mainheadname);
            GVCFR.DataSource = data;
            GVCFR.DataBind();
        }

        protected void GVCFR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVCFR.PageIndex = e.NewPageIndex;
            LaodCashFlowRpt(0, "", "", "", "", "");
        }
        protected void GVCFR_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<CashFlowReportDTO> bb = new List<CashFlowReportDTO>();
            bb = CFRBLL.LoadCashFlowRptData(Convert.ToInt32(GVCFR.DataKeys[GVCFR.SelectedIndex].Values["CFRId"].ToString()), "", "", "", "", "");
            HFCFRId.Value = bb.First().CFRId.ToString();
            ddlCashFlowEntity.Text = bb.First().CFEId.ToString();
            ddlCOA_DR.SelectedValue = bb.First().COAId.ToString();
            ddlMainHeadCodeId_DR.SelectedValue = bb.First().MainHeadId.ToString();
            ddlSubcode1_DR.SelectedValue = bb.First().SubCode_1Id.ToString();
            ddlSubcode2_DR.SelectedValue = bb.First().SubCode2Id.ToString();
            RBTActivationStatus.SelectedIndex = Convert.ToInt16(bb.First().ActiveStatus.ToString());

            BtnSaveCashFlowRpt.Text = "Update";
        }

        public void ClearControl()
        {
            LoadMainHead();
            LoadSubCodeId1();
            LoadSubCodeId2();
            LoadCOA();
            LoadCashFlowEntity();
            RBTActivationStatus.SelectedIndex = 0;
            GVCFR.SelectedIndex = -1;
            LaodCashFlowRpt(0, "", "", "", "", "");
            txtCashFlowEntity.Text = "";
            txtCashFlowEntitySearch.Text = "";
            txtCOAName.Text = "";
            txtMainHeadName.Text = "";
            

        }


        protected void BtnCancelCashFlowRpt_Click(object sender, EventArgs e)
        {
            ClearControl();

        }

        protected void BtnSaveCashFlowRpt_Click(object sender, EventArgs e)
        {


            CFRDTO.ActiveStatus = Convert.ToString(RBTActivationStatus.SelectedIndex);
            CFRDTO.CFEId = Convert.ToUInt16(ddlCashFlowEntity.SelectedValue);
            CFRDTO.COAId = Convert.ToInt16(ddlCOA_DR.SelectedValue);

            CFRDTO.SubCode_1Id = Convert.ToInt16(ddlSubcode1_DR.SelectedValue);

            if (BtnSaveCashFlowRpt.Text == "Save")
            {
                CFRDTO.CreateBy = HttpContext.Current.User.Identity.Name;
                CFRDTO.CreateDate = System.DateTime.Now;
                CFRBLL.Add(CFRDTO);

            }
            else
            {
                CFRDTO.CFRId = Convert.ToInt16(HFCFRId.Value);
                CFDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                CFDTO.UpdateDate = System.DateTime.Now;
                CFRBLL.Edit(CFRDTO);
            }
            ClearControl();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void txtCashFlow_TextChanged(object sender, EventArgs e)
        {
            Search();
        }
        public void Search()
        {                                                                                            //  (crid, cfname, coaname, subcode2name, subcode1name, mainheadname)
            var data = CFRBLL.LoadCashFlowRptData(0, txtCashFlowEntitySearch.Text.ToString(), txtCOAName.Text.ToString(), "", txtSubCode1Name.Text.ToString(), txtMainHeadName.Text.ToString());
            GVCFR.DataSource = data;
            GVCFR.DataBind();

        }

        // cash flow Rpt Entry 
    }
}