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

namespace UI.AccSysManagment.Accounting
{
    public partial class UpdateJournal : System.Web.UI.Page
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

        Log_AccJournalDTO JLDTO = new Log_AccJournalDTO();
        Log_AccJournalBLL JLBLL = new Log_AccJournalBLL();

        LedgerBLL LBLL = new LedgerBLL();
        LedgerDTO LDTO = new LedgerDTO();

        LoginBLL LBLL1 = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Journal Update";
                LoadMainHead();
                LoadSubCodeId1();
                LoadSubCodeId2();
                LoadCOA();
                LoadMainVocher();
                LoadSubVocher();
                pagingLoal();
                //  GvJrShow.Columns[10].Visible = false;


            }
        }
        public void RoleName()
        {

            //UI.PageObject.PageObjectCreation;
            string empusername = HttpContext.Current.User.Identity.Name;

            var role = LBLL1.GetRoleName_By_User(empusername);
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
                if (Convert.ToString(dt.Rows[i][1]) == "DR")
                    drAmount = drAmount + Convert.ToDouble(dt.Rows[i][6]);
                else
                {
                    crAmount = crAmount + Convert.ToDouble(dt.Rows[i][6]);
                }
            }


            if (Convert.ToInt32(drAmount) != Convert.ToInt32(crAmount))
            {
                lblCheckDRC_R.Visible = true;
                lblCheckDRC_R.Text = "Please Check DR. & CR. Amount";
            }
            else
            {
                // Start for LOG File Journal Update In Ladger page
                for (int i = 0; i < count; i++)
                {

                    string logField = "";
                    var Journalinfo = JBLL.LoadJournalUpdate_ladger(Convert.ToInt32(dt.Rows[i][0]), 0);
                    if (Convert.ToString(dt.Rows[i][4]) != Journalinfo.First().SubCode2Id.ToString())
                    {
                        logField += "SubCode2Id" + "-" + Journalinfo.First().SubCode2Id.ToString() + "#" + dt.Rows[i][4] + ";";
                    }
                    if (Convert.ToString(dt.Rows[i][2]) != Journalinfo.First().COAId.ToString())
                    {
                        logField += "COAId" + "-" + Journalinfo.First().COAId.ToString() + "#" + dt.Rows[i][2] + ";";
                    }
                    if (Convert.ToString(dt.Rows[i][9]) != Journalinfo.First().SubVoucherId.ToString())
                    {
                        logField += "SubVoucherId" + "-" + Journalinfo.First().SubVoucherId.ToString() + "#" + dt.Rows[i][9] + ";";
                    }
                    if (Convert.ToString(dt.Rows[i][1]) != Journalinfo.First().JournalType.ToString())
                    {
                        logField += "JournalType" + "-" + Journalinfo.First().JournalType.ToString() + "#" + dt.Rows[i][1] + ";";
                    }
                    if (Convert.ToString(dt.Rows[i][1]) == "DR")
                    {
                        if (Convert.ToString(dt.Rows[i][6]) != Journalinfo.First().DRAmount.ToString()) // problem
                        {
                            logField += "DRAmount" + "-" + Journalinfo.First().DRAmount.ToString() + "#" + dt.Rows[i][6] + ";";
                        }

                    }
                    else
                    {
                        if (Convert.ToString(dt.Rows[i][6]) != Journalinfo.First().CRAmount.ToString()) // problem
                        {
                            logField += "CRAmount" + "-" + Journalinfo.First().CRAmount.ToString() + "#" + dt.Rows[i][6] + ";";
                        }
                    }

                    if (txtTransectionDate.Text != Journalinfo.First().TransectionDate.ToString())
                    {
                        logField += "TransectionDate" + "-" + Journalinfo.First().TransectionDate.ToString() + "#" + txtTransectionDate.Text + ";";
                    }

                    if (Convert.ToString(dt.Rows[i][7]) != Journalinfo.First().VONO.ToString()) // problem
                    {
                        logField += "VONO" + "-" + Journalinfo.First().VONO.ToString() + "#" + dt.Rows[i][7] + ";";
                    }
                    if (Convert.ToString(dt.Rows[i][8]) != Journalinfo.First().MRNO.ToString()) // problem
                    {
                        logField += "MRNO" + "-" + Journalinfo.First().MRNO.ToString() + "#" + dt.Rows[i][8] + ";";
                    }
                    if (Convert.ToString(dt.Rows[i][11]) != Journalinfo.First().Remarks.ToString()) // problem
                    {
                        logField += "Remarks" + "-" + Journalinfo.First().Remarks.ToString() + "#" + dt.Rows[i][11] + ";";
                    }

                    if (logField.Length > 0)
                    {
                        logField = " JournalId" + "-" + Convert.ToInt32(dt.Rows[i][0]) + ";" + logField;
                        JLDTO.LogField = logField;
                        JLDTO.LogDate = System.DateTime.Now;
                        JLDTO.LogBy = "ABHI";
                        JLBLL.AddLogAccJournal(JLDTO);
                    }
                }
                // End for LOG File Journal Update In Ladger page

                for (int i = 0; i < count; i++)
                {
                    JDTO.JournalId = Convert.ToInt32(dt.Rows[i][0]);
                    JDTO.SubCode2Id = Convert.ToInt32(dt.Rows[i][4]);
                    JDTO.COAId = Convert.ToInt32(dt.Rows[i][2]);
                    JDTO.SubVoucherId = Convert.ToInt32(dt.Rows[i][9]);
                    JDTO.JournalType = Convert.ToString(dt.Rows[i][1]);
                    if (Convert.ToString(dt.Rows[i][1]) == "DR")
                    {
                        JDTO.DRAmount = Convert.ToInt32(dt.Rows[i][6]);
                        JDTO.CRAmount = null;
                    }
                    else
                    {
                        JDTO.DRAmount = null;
                        JDTO.CRAmount = Convert.ToInt32(dt.Rows[i][6]);
                    }
                    JDTO.VONO = Convert.ToString(dt.Rows[i][7]);
                    JDTO.MRNO = Convert.ToString(dt.Rows[i][8]);
                    JDTO.Remarks = Convert.ToString(dt.Rows[i][11]);
                    JDTO.TransectionNo = Convert.ToInt32(dt.Rows[i][12]);
                    if (txtTransectionDate.Text == "Today")
                    {

                        JDTO.TransectionDate = Convert.ToDateTime(DateTime.Now.ToShortDateString());
                    }
                    else
                    {
                        JDTO.TransectionDate = Convert.ToDateTime(txtTransectionDate.Text.ToString());
                    }
                    JDTO.PostLeadgerStatus = "Y";
                    JDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                    JDTO.UpdateDate = System.DateTime.Now;
                    JBLL.Edit(JDTO);

                }


                // insert in to ledger
                for (int i = 0; i < count; i++)
                {
                    LDTO.JournalId = Convert.ToInt32(dt.Rows[i][0]);
                    //  LDTO.OPBAL = 0;
                    if (Convert.ToString(dt.Rows[i][1]) == "DR")
                    {
                        LDTO.DRAmount = Convert.ToDouble(dt.Rows[i][6]);
                        LDTO.CRAmount = null;
                    }
                    else
                    {
                        LDTO.DRAmount = null;
                        LDTO.CRAmount = Convert.ToDouble(dt.Rows[i][6]);
                    }

                    //  LDTO.CLBAL = 0;
                    LDTO.CreateBy = HttpContext.Current.User.Identity.Name;
                    LDTO.CreateDate = System.DateTime.Now;

                    //start clbal, opbal

                    List<COAInfoDTO> coa = new List<COAInfoDTO>();
                    coa = CBLL.LoadCoAInfo(Convert.ToInt32(dt.Rows[i][2]), "", "", 0, "", "", "", "", "", "");
                    double? balance;
                    if (coa.First().Balance != null)
                    {
                        balance = coa.First().Balance;
                    }
                    else
                    {
                        balance = 0;
                    }
                    List<LedgerDTO> ld = new List<LedgerDTO>();
                    ld = LBLL.LoadLedgerData(0, 0, Convert.ToInt32(dt.Rows[i][2]));
                    double? opbal;
                    double? clbal;
                    double? dramoun = 0;
                    double? cramount = 0;
                    if (ld.Count != 0)
                    {

                        if (ld.First().OPBAL != null)
                        {
                            opbal = ld.First().OPBAL;
                        }
                        else
                        {
                            opbal = 0;
                        }
                        if (ld.First().CLBAL != null)
                        {
                            clbal = ld.First().CLBAL;
                        }
                        else { clbal = 0; }

                        if (ld.First().DRAmount != null)
                        {
                            dramoun = ld.First().DRAmount;
                        }
                        else
                        {
                            dramoun = 0;
                        }

                        if (ld.First().CRAmount != null)
                        {
                            cramount = ld.First().CRAmount;
                        }
                        else { cramount = 0; }


                        LDTO.OPBAL = clbal;

                        LDTO.CLBAL = clbal + Convert.ToDouble(dt.Rows[i][6]);

                    }

                    else
                    {

                        LDTO.OPBAL = balance;
                        if (Convert.ToString(dt.Rows[i][1]) == "DR")
                        {

                            LDTO.CLBAL = balance + Convert.ToDouble(dt.Rows[i][6]);
                        }
                        else
                        {
                            LDTO.CLBAL = balance + Convert.ToDouble(dt.Rows[i][6]);
                        }
                    }

                    // end of clbal,opbal
                    CDTO.COAId = Convert.ToInt32(dt.Rows[i][2]);
                    CDTO.Balance = LDTO.CLBAL;
                    CBLL.Edit_COAUpdate(CDTO);
                    LBLL.Add(LDTO);
                }
                CLearContorl();

               

                int TransectionNo;
                TransectionNo = Convert.ToInt32(HFTransectionNo.Value);
                ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('AccSysManagment/AccountingReport/JournalUpdateRptUI.aspx?TransectionNo=" + TransectionNo.ToString() + "');", true);
                pagingLoal();
            }


        }

        protected void BtnPostToLedger_Click(object sender, EventArgs e)
        {
            foreach (GridViewRow row in GvJrShow.Rows)
            {

                LDTO.JournalId = Convert.ToInt32(row.Cells[1].Text);
                if (row.Cells[5].Text.ToString() != "&nbsp;")
                {
                    LDTO.DRAmount = Convert.ToDouble(row.Cells[5].Text);
                    LDTO.CRAmount = null;
                }

                if (row.Cells[6].Text.ToString() != "&nbsp;")
                {
                    LDTO.DRAmount = null;
                    LDTO.CRAmount = Convert.ToDouble(row.Cells[6].Text);
                }


                LDTO.CreateBy = HttpContext.Current.User.Identity.Name;
                LDTO.CreateDate = System.DateTime.Now;



                //start clbal, opbal

                List<COAInfoDTO> coa = new List<COAInfoDTO>();
                coa = CBLL.LoadCoAInfo(Convert.ToInt32(row.Cells[10].Text), "", "", 0, "", "", "", "", "", "");
                double? balance;
                if (coa.First().Balance != null)
                {
                    balance = coa.First().Balance;
                }
                else
                {
                    balance = 0;
                }
                List<LedgerDTO> ld = new List<LedgerDTO>();
                ld = LBLL.LoadLedgerData(0, 0, Convert.ToInt32(row.Cells[10].Text));
                double? opbal;
                double? clbal;
                double? dramoun = 0;
                double? cramount = 0;
                if (ld.Count != 0)
                {

                    if (ld.First().OPBAL != null)
                    {
                        opbal = ld.First().OPBAL;
                    }
                    else
                    {
                        opbal = 0;
                    }
                    if (ld.First().CLBAL != null)
                    {
                        clbal = ld.First().CLBAL;
                    }
                    else { clbal = 0; }

                    if (ld.First().DRAmount != null)
                    {
                        dramoun = ld.First().DRAmount;
                    }
                    else
                    {
                        dramoun = 0;
                    }

                    if (ld.First().CRAmount != null)
                    {
                        cramount = ld.First().CRAmount;
                    }
                    else { cramount = 0; }


                    LDTO.OPBAL = clbal;
                    if (row.Cells[5].Text.ToString() != "&nbsp;")
                    {
                        LDTO.CLBAL = clbal + Convert.ToDouble(row.Cells[5].Text);
                    }
                    if (row.Cells[6].Text.ToString() != "&nbsp;")
                    {
                        LDTO.CLBAL = clbal + Convert.ToDouble(row.Cells[6].Text);
                    }

                }

                else
                {

                    LDTO.OPBAL = balance;
                    if (row.Cells[5].Text.ToString() != "&nbsp;")
                    {
                        LDTO.CLBAL = balance + Convert.ToDouble(row.Cells[5].Text);
                    }
                    if (row.Cells[6].Text.ToString() != "&nbsp;")
                    {
                        LDTO.CLBAL = balance + Convert.ToDouble(row.Cells[6].Text);
                    }



                }

                // end of clbal,opbal

                CDTO.COAId = Convert.ToInt32(row.Cells[10].Text);
                CDTO.Balance = LDTO.CLBAL;
                CBLL.Edit_COAUpdate(CDTO);

                JDTO.JournalId = Convert.ToInt32(row.Cells[1].Text);
                JDTO.PostLeadgerStatus = "Y";
                JBLL.Edit_JournalUpdate(JDTO);

                LBLL.Add(LDTO);
            }
           
            PanelGVShow.Visible = false;
            PanelEntity.Visible = false;
            int TransectionNo;
            TransectionNo = Convert.ToInt32(HFTransectionNo.Value);
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/AccSysManagment/AccountingReport/JournalUpdateRptUI.aspx?TransectionNo=" + TransectionNo.ToString() + "');", true);
            PanleAdd.Visible = false;
            pagingLoal();
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
            PanelGVShow.Visible = false;
            PanelEntity.Visible = false;
            PanleAdd.Visible = false;
            pagingLoal();

        }

        protected void btnAddDR_Click(object sender, EventArgs e)
        {


            if (ViewState["CurrentData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentData"];
                int count = dt.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    if (RbtJournalType.SelectedItem.ToString() == dt.Rows[i][1].ToString() && ddlCOA_DR.SelectedItem.ToString() == dt.Rows[i][3].ToString())
                    {
                        btnAddDR.Attributes.Add("OnClick", "alert ('Data Alredy Exist');");
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

                GvJrEntry.DataSource = dt;
                GvJrEntry.DataBind();
                ActionPanleVisibolity();
            }
        }

        private void BindGrid(int rowcount)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("JournalId", typeof(String)));
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
                dr[0] = HFJournalID.Value;
                dr[1] = RbtJournalType.SelectedItem.ToString();
                dr[2] = ddlCOA_DR.SelectedValue.ToString();
                dr[3] = ddlCOA_DR.SelectedItem.ToString();
                dr[4] = ddlSubcode2_DR.SelectedValue.ToString();
                dr[5] = ddlSubcode2_DR.SelectedItem.ToString();
                dr[6] = txtDRAmount.Text;
                dr[7] = txtVoucherNo.Text.ToString();
                dr[8] = txtMRNO.Text;
                dr[9] = ddlSubVoucher.SelectedValue.ToString();
                dr[10] = ddlSubVoucher.SelectedItem.ToString();
                dr[11] = txtRemarksDR.Text.ToString();
                dr[12] = HFTransectionNo.Value;

                dt.Rows.Add(dr);

            }
            else
            {
                dr = dt.NewRow();
                dr[0] = HFJournalID.Value;
                dr[1] = RbtJournalType.SelectedItem.ToString();
                dr[2] = ddlCOA_DR.SelectedValue.ToString();
                dr[3] = ddlCOA_DR.SelectedItem.ToString();
                dr[4] = ddlSubcode2_DR.SelectedValue.ToString();
                dr[5] = ddlSubcode2_DR.SelectedItem.ToString();
                dr[6] = txtDRAmount.Text;
                dr[7] = txtVoucherNo.Text.ToString();
                dr[8] = txtMRNO.Text;
                dr[9] = ddlSubVoucher.SelectedValue.ToString();
                dr[10] = ddlSubVoucher.SelectedItem.ToString();
                dr[11] = txtRemarksDR.Text.ToString();
                dr[12] = HFTransectionNo.Value;
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



        public void pagingLoal()
        {

            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = JBLL.LoadJournalUpdate_ladger(0, 0);
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
        // code start
        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            List<JournalDTO> bb = new List<JournalDTO>();
            bb = JBLL.LoadJournalUpdate_ladger(0, Convert.ToInt32(e.CommandArgument.ToString()));
            HFTransectionNo.Value = bb.First().TransectionNo.ToString();
            LoadEditGridView();
            GvJrShow.SelectedIndex = -1;
            PanelGVShow.Visible = true;
        }

        private void LoadEditGridView()
        {
            List<JournalDTO> bb = new List<JournalDTO>();
            bb = JBLL.LoadJournalUpdate_ladger(0, Convert.ToInt32(HFTransectionNo.Value));
            GvJrShow.DataSource = bb;
            GvJrShow.DataBind();
        }
        protected void GvJrShow_SelectedIndexChanged(object sender, EventArgs e)
        {
            lblCheckDRC_R.Visible = false;
            PanelEntity.Visible = true;
            PanleAdd.Visible = true;
            List<JournalDTO> bb = new List<JournalDTO>();
            bb = JBLL.LoadJournalUpdate_ladger(Convert.ToInt32(GvJrShow.DataKeys[GvJrShow.SelectedIndex].Values["JournalId"].ToString()), 0);
            HFTransectionNo.Value = bb.First().TransectionNo.ToString();
            HFJournalID.Value = bb.First().JournalId.ToString();
            if (bb.First().DRAmount.ToString() != "")
            {
                txtDRAmount.Text = bb.First().DRAmount.ToString();
            }
            else
            {
                txtDRAmount.Text = bb.First().CRAmount.ToString();
            }

            txtMRNO.Text = bb.First().MRNO.ToString();
            txtRemarksDR.Text = bb.First().Remarks.ToString();
            txtTransectionDate.Text = bb.First().TransectionDate.Value.ToShortDateString();//.ToString();
            txtVoucherNo.Text = bb.First().VONO.ToString();
            ddlCOA_DR.SelectedValue = bb.First().COAId.ToString();
            ddlMainHeadCodeId_DR.SelectedValue = bb.First().MainHeadId.ToString();
            ddlMaintVoucher.SelectedValue = bb.First().MainVoucherId.ToString();
            ddlSubcode1_DR.SelectedValue = bb.First().SubCode_1Id.ToString();
            ddlSubcode2_DR.SelectedValue = bb.First().SubCode2Id.ToString();
            ddlSubVoucher.SelectedValue = bb.First().SubVoucherId.ToString();
            RbtJournalType.SelectedValue = bb.First().JournalType.ToString();

        }
        protected void GvJrShow_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvJrShow.PageIndex = e.NewPageIndex;
            LoadEditGridView();
            lblCheckDRC_R.Visible = false;
        }
        protected void btnRefreshJournal_Click(object sender, EventArgs e)
        {
            pagingLoal();
           // UpdatePanel1.Update();
            Page.Response.Redirect(Page.Request.Url.ToString(), true);
        }

    }
}