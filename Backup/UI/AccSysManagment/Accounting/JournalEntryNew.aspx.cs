using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADTO;
using ABLL;
using System.Data;

namespace UI.AccSysManagment.Accounting
{
    public partial class JournalEntryNew : System.Web.UI.Page
    {
        MainHeadDTO MDTO = new MainHeadDTO();
        MainHeadBLL MBLL = new MainHeadBLL();

        SubCode_1DTO S1DTO = new SubCode_1DTO();
        SubCode_1BLL S1BLL = new SubCode_1BLL();

        SubCode_2DTO S2DTO = new SubCode_2DTO();
        SubCode_2BLL S2BLL = new SubCode_2BLL();

        COAInfoDTO CDTO = new COAInfoDTO();
        COAInfoBLL CBLL = new COAInfoBLL();

        MainVoucherDTO MVDTO = new MainVoucherDTO();
        MainVoucherBLL MVBLL = new MainVoucherBLL();

        SubVoucherDTO SDTO = new SubVoucherDTO();
        SubVoucherBLL SBLL = new SubVoucherBLL();

        JournalDTO JDTO = new JournalDTO();
        JournalBLL JBLL = new JournalBLL();

        ReportBLL rbll = new ReportBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtTransectionDate.Text = System.DateTime.Now.ToShortDateString();
                LoadMainHead();
                LoadSubCodeId1();
                LoadSubCodeId2();
                LoadCOA();
                LoadMainVocher();
                LoadSubVocher();
                pagingLoal();

            }
        }
        private void LoadMainVocher() // MainVoucherName
        {
            var query = MVBLL.LoadMainVocher(0);
            ddlMaintVoucher.DataSource = query;
            ddlMaintVoucher.DataTextField = "MainVoucherCode_Name";
            ddlMaintVoucher.DataValueField = "MainVoucherId";
            ddlMaintVoucher.DataBind();
            ddlMaintVoucher.Items.Insert(0, new ListItem("Select One", "0"));
        }
        protected void ddlMaintVoucher_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubVocher();
        }
        private void LoadSubVocher() // MainVoucherName
        {
            var query = SBLL.LoadSubVoucherData(0, Convert.ToInt32(ddlMaintVoucher.SelectedValue));
            ddlSubVoucher.DataSource = query;
            ddlSubVoucher.DataTextField = "SubVoucherCodeName";
            ddlSubVoucher.DataValueField = "SubVoucherId";
            ddlSubVoucher.DataBind();
            ddlSubVoucher.Items.Insert(0, new ListItem("Select One", "0"));
        }

        // start main head
        private void LoadMainHead()
        {
            var query = MBLL.LoadMainHead(0);
            ddlMainHeadCodeId_DR.DataSource = query;
            ddlMainHeadCodeId_DR.DataTextField = "MainHeadName_Num";
            ddlMainHeadCodeId_DR.DataValueField = "MainHeadId";
            ddlMainHeadCodeId_DR.DataBind();
            ddlMainHeadCodeId_DR.Items.Insert(0, new ListItem("Select One", "0"));
        }

        // start sub code1
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

        protected void BtnSave_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["CurrentData"];
            int count = dt.Rows.Count;

            int rowCount = 0;
            double drAmount = 0;
            double crAmount = 0;
            rowCount = GvJrEntry.Rows.Count;
            for (int i = 0; i < rowCount; i++)
            {
                if (Convert.ToString(dt.Rows[i][0]) == "DR")
                    drAmount = drAmount + Convert.ToDouble(dt.Rows[i][5]);
                else
                {
                    crAmount = crAmount + Convert.ToDouble(dt.Rows[i][5]);
                }
            }


            if (Convert.ToInt32(drAmount) != Convert.ToInt32(crAmount))
            {
                lblCheckDRC_R.Visible = true;
                lblCheckDRC_R.Text = "Please Check DR. & CR. Amount";
            }
            else
            {
                for (int i = 0; i < count; i++)
                {
                    JDTO.JournalType = Convert.ToString(dt.Rows[i][0]);
                    JDTO.COAId = Convert.ToInt32(dt.Rows[i][1]);
                    JDTO.SubCode2Id = Convert.ToInt32(dt.Rows[i][3]);
                    JDTO.SubVoucherId = Convert.ToInt32(dt.Rows[i][8]);

                    if (Convert.ToString(dt.Rows[i][0]) == "DR")
                    {
                        JDTO.DRAmount = Convert.ToInt32(dt.Rows[i][5]);
                        JDTO.CRAmount = null;
                    }
                    else
                    {
                        JDTO.DRAmount = null;
                        JDTO.CRAmount = Convert.ToInt32(dt.Rows[i][5]);
                    }
                    JDTO.VONO = Convert.ToString(dt.Rows[i][6]);
                    JDTO.MRNO = Convert.ToString(dt.Rows[i][7]);
                    JDTO.Remarks = Convert.ToString(dt.Rows[i][10]);
                    JDTO.TransectionNo = Convert.ToInt32(dt.Rows[i][11]);

                    JDTO.TransectionDate = Convert.ToDateTime(dt.Rows[i][12]);
                    JDTO.PostLeadgerStatus = "N";
                    JDTO.CreateBy = HttpContext.Current.User.Identity.Name;// HttpContext.Current.User.Identity.Name;
                    JDTO.CreateDate = System.DateTime.Now;
                    JBLL.Add(JDTO);
                }

                CLearContorl();
                Page.ClientScript.RegisterStartupScript(Page.GetType(), null, "window.open('/AccSysManagment/AccountingReport/JournalRptUI.aspx', '_newtab')", true);
            }


        }

        protected void BtnCancel_Click(object sender, EventArgs e)
        {
            CLearContorl();
            clearControl_Add();


        }

        public void CLearContorl()
        {
            this.ViewState["CurrentData"] = null;
            DataTable dt = new DataTable();
            GvJrEntry.DataSource = dt;
            GvJrEntry.DataBind();
            PnlAction.Visible = false;
            RbtJournalType.SelectedIndex = 0;
            lblCheckDRC_R.Visible = false;
            pagingLoal();
            txtTransectionDate.Text = "Today";
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
        protected void btnAddDR_Click(object sender, EventArgs e)
        {
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


            if (ViewState["CurrentData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentData"];
                int count = dt.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    if (ddlCOA_DR.SelectedValue.ToString() == dt.Rows[i][1].ToString())
                    {
                        Show(" Data Already Exist !");
                        return;

                    }

                }
                BindGrid(count);
            }
            else
            {
                BindGrid(1);
            }
            clearControl_Add();
            PnlAction.Visible = true;

        }

        public void ActionPanleVisibolity()
        {

            if (GvJrEntry.Rows.Count == 0)
            {
                PnlAction.Visible = false;
            }
            else
            {
                PnlAction.Visible = true;
            }
        }
        protected void BtnClearDR_Click(object sender, EventArgs e)
        {
            clearControl_Add();
        }
        public void clearControl_Add()
        {
            LoadMainHead();
            LoadSubCodeId1();
            LoadSubCodeId2();
            LoadCOA();
            LoadMainVocher();
            LoadSubVocher();
            txtDRAmount.Text = "";
            txtMRNO.Text = "";
            txtRemarksDR.Text = "";
            txtVoucherNo.Text = "";

        }


        protected void LinkButton_Click(object sender, EventArgs e)
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
                int count = dt.Rows.Count;

                for (int i = 0; i < count; i++)
                {

                }

                GvJrEntry.DataSource = dt;
                GvJrEntry.DataBind();
                ActionPanleVisibolity();
            }
        }

        private void BindGrid(int rowcount)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("JournalType", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("COAId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("COAName_Num", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("SubCode2Id", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("SubCode2Name_Num", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Amount", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("VONO", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("MRNO", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("SubVoucherId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("SubVoucherCodeName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Remarks", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("TransectionNO", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("TransectionDate", typeof(String)));

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
                dr[0] = RbtJournalType.SelectedItem.ToString();
                dr[1] = ddlCOA_DR.SelectedValue.ToString();
                dr[2] = ddlCOA_DR.SelectedItem.ToString();
                dr[3] = ddlSubcode2_DR.SelectedValue.ToString();
                dr[4] = ddlSubcode2_DR.SelectedItem.ToString();
                dr[5] = txtDRAmount.Text;
                dr[6] = txtVoucherNo.Text.ToString();
                dr[7] = txtMRNO.Text;
                dr[8] = ddlSubVoucher.SelectedValue.ToString();
                dr[9] = ddlSubVoucher.SelectedItem.ToString();
                dr[10] = txtRemarksDR.Text.ToString();
                dr[11] = HFTransectionNo.Value;
                dr[12] = txtTransectionDate.Text;

                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = RbtJournalType.SelectedItem.ToString();
                dr[1] = ddlCOA_DR.SelectedValue.ToString();
                dr[2] = ddlCOA_DR.SelectedItem.ToString();
                dr[3] = ddlSubcode2_DR.SelectedValue.ToString();
                dr[4] = ddlSubcode2_DR.SelectedItem.ToString();
                dr[5] = txtDRAmount.Text;
                dr[6] = txtVoucherNo.Text.ToString();
                dr[7] = txtMRNO.Text;
                dr[8] = ddlSubVoucher.SelectedValue.ToString();
                dr[9] = ddlSubVoucher.SelectedItem.ToString();
                dr[10] = txtRemarksDR.Text.ToString();
                dr[11] = HFTransectionNo.Value;
                dr[12] = txtTransectionDate.Text;
                dt.Rows.Add(dr);
            }
            if (ViewState["CurrentData"] != null)
            {
                GvJrEntry.DataSource = (DataTable)ViewState["CurrentData"];
                GvJrEntry.DataBind();
            }
            else
            {
                GvJrEntry.DataSource = dt;
                GvJrEntry.DataBind();
            }
            ViewState["CurrentData"] = dt;

        }


        protected void GvJrEntry_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {


            GvJrEntry.PageIndex = e.NewPageIndex;
            if (ViewState["CurrentData"] != null)
            {
                GvJrEntry.DataSource = (DataTable)ViewState["CurrentData"];
                GvJrEntry.DataBind();
            }
            GvJrEntry.DataBind();
        }

        private void pagingLoal()
        {

            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = JBLL.LoadJournalData_update(0);
            objPds.AllowPaging = true;
            objPds.PageSize = 6;
            int CurPage;
            if (Request.QueryString["Page"] != null)
                CurPage = Convert.ToInt32(Request.QueryString["Page"]);
            else
                CurPage = 1;


            objPds.CurrentPageIndex = CurPage - 1;
            lblCurrentPage.Text = "Page: " + CurPage.ToString();

            if (!objPds.IsFirstPage)
                lnkPrev.NavigateUrl = Request.CurrentExecutionFilePath
                + "?Page=" + Convert.ToString(CurPage - 1);

            if (!objPds.IsLastPage)
                lnkNext.NavigateUrl = Request.CurrentExecutionFilePath
                + "?Page=" + Convert.ToString(CurPage + 1);

            RptJournalShow.DataSource = objPds;
            RptJournalShow.DataBind();
        }




    }
}