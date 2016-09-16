using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADTO;
using ABLL;

namespace UI.AccSysManagment.Report_Setup_File
{
    public partial class BalanceSheetRptUI : System.Web.UI.Page
    {
        BalanceSheetRptDTO BDTO = new BalanceSheetRptDTO();
        BalanceSheetRptBLL BBLL = new BalanceSheetRptBLL();

        MainHeadDTO MDTO = new MainHeadDTO();
        MainHeadBLL MBLL = new MainHeadBLL();

        SubCode_1DTO S1DTO = new SubCode_1DTO();
        SubCode_1BLL S1BLL = new SubCode_1BLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadMainHead();
                // LoadSubCodeId1();
                LaodBalanceSheetRpt(0);
            }
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
        //private void LoadSubCodeId1()
        //{
        //    var query = S1BLL.LoadSuvCode_1Data(0, "", "", Convert.ToInt32(ddlMainHeadCodeId_DR.SelectedValue), "", "");
        //    ddlSubcode1_DR.DataSource = query;
        //    ddlSubcode1_DR.DataTextField = "SubCode1Name_Num";
        //    ddlSubcode1_DR.DataValueField = "SubCode_1Id";
        //    ddlSubcode1_DR.DataBind();
        //    ddlSubcode1_DR.Items.Insert(0, new ListItem("Select One", "0"));
        //}


        public void ClearControl()
        {
            LoadMainHead();
            // LoadSubCodeId1();
            LaodBalanceSheetRpt(0);
            BtnSaveBalaceRpt.Text = "Save";
            txtPriority.Text = "";
            GVCFR.SelectedIndex = -1;

        }
        // gv cash flow code
        private void LaodBalanceSheetRpt(int id)
        {
            var data = BBLL.LoadBalanceSheetRpt(id);
            GVCFR.DataSource = data;
            GVCFR.DataBind();
        }

        protected void GVCFR_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GVCFR.PageIndex = e.NewPageIndex;
            LaodBalanceSheetRpt(0);

        }
        protected void GVCFR_SelectedIndexChanged(object sender, EventArgs e)
        {
            List<BalanceSheetRptDTO> bb = new List<BalanceSheetRptDTO>();
            bb = BBLL.LoadBalanceSheetRpt(Convert.ToInt32(GVCFR.DataKeys[GVCFR.SelectedIndex].Values["BalanceShtId"].ToString()));
            HFBId.Value = bb.First().BalanceShtId.ToString();
            ddlMainHeadCodeId_DR.SelectedValue = bb.First().MainHeadId.ToString();
            txtPriority.Text = bb.First().Priority.ToString();
            BtnSaveBalaceRpt.Text = "Update";
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


        protected void BtnSaveBalaceRpt_Click(object sender, EventArgs e)
        {
            BDTO.MainHeadId = Convert.ToInt16(ddlMainHeadCodeId_DR.SelectedValue);
            BDTO.Priority = Convert.ToInt16(txtPriority.Text);
            if (BtnSaveBalaceRpt.Text == "Save")
            {
                BDTO.CreateDate = System.DateTime.Now;
                BDTO.CreateBy = HttpContext.Current.User.Identity.Name;
                BBLL.Add(BDTO);


            }
            else
            {
                BDTO.BalanceShtId = Convert.ToInt16(HFBId.Value);
                BDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                BDTO.UpdateDate = System.DateTime.Now;
                BBLL.Edit(BDTO);
            }

            ClearControl();

        }

        protected void BtnCanelBalaceRpt_Click(object sender, EventArgs e)
        {
            ClearControl();
        }
    }
}