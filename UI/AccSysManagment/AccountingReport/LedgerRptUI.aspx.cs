using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABLL;
using Microsoft.Reporting.WebForms;

namespace UI.AccSysManagment.AccountingReport
{
    public partial class LedgerRptUI : System.Web.UI.Page
    {
        MainHeadBLL MBLL = new MainHeadBLL();
        SubCode_1BLL S1BLL = new SubCode_1BLL();
        SubCode_2BLL S2BLL = new SubCode_2BLL();
        COAInfoBLL CBLL = new COAInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Ledger Report";
                LoadMainHead();
                LoadSubCodeId1();
                LoadSubCodeId2();
                LoadCOA();
                string fromdate = Request.QueryString["fromdate"];
                string todate = Request.QueryString["todate"];

                if (fromdate != null)
                {
                    txtfromdate.Text = fromdate.ToString();
                }
                if (todate != null)
                {
                    txtTodate.Text = todate.ToString();
                }
                string mainheadid = Request.QueryString["mainheadid"];
                string subcode1id = Request.QueryString["subcode1id"];
                string subcode2id = Request.QueryString["subcode2id"];
                string coaid = Request.QueryString["coaid"];

                if (mainheadid != null)
                {

                    ddlMainHead.SelectedValue = mainheadid.ToString();
                    if (subcode1id != null)
                    {
                        ddlSubCode1.SelectedValue = subcode1id.ToString();

                    }
                    if (subcode2id != null)
                    {
                        ddlSubCode2.SelectedValue = subcode2id.ToString();


                    }
                    if (coaid != null)
                    {
                        ddlCOA.SelectedValue = coaid.ToString();
                    }

                }


            }


        }
        private void LoadMainHead()
        {
            var query = MBLL.LoadMainHead(0);
            ddlMainHead.DataSource = query;
            ddlMainHead.DataTextField = "MainHeadName_Num";
            ddlMainHead.DataValueField = "MainHeadId";
            ddlMainHead.DataBind();
            ddlMainHead.Items.Insert(0, new ListItem("Select One", "0"));
        }
        private void LoadSubCodeId1()
        {
            var query = S1BLL.LoadSuvCode_1Data(0, "", "", Convert.ToInt32(ddlMainHead.SelectedValue), "", "");
            ddlSubCode1.DataSource = query;
            ddlSubCode1.DataTextField = "SubCode1Name_Num";
            ddlSubCode1.DataValueField = "SubCode_1Id";
            ddlSubCode1.DataBind();
            ddlSubCode1.Items.Insert(0, new ListItem("Select One", "0"));
        }
        private void LoadSubCodeId2()
        {
            var query = S2BLL.LoadSuvCode_2Data(0, "", "", Convert.ToInt32(ddlSubCode1.SelectedValue), "", "", "", "");
            ddlSubCode2.DataSource = query;
            ddlSubCode2.DataTextField = "SubCode2Name_Num";
            ddlSubCode2.DataValueField = "SubCode_2Id";
            ddlSubCode2.DataBind();
            ddlSubCode2.Items.Insert(0, new ListItem("Select One", "0"));
        }
        // start sub code2
        private void LoadCOA()
        {

            var query = CBLL.LoadCoAInfo(0, "", "", Convert.ToInt32(ddlSubCode2.SelectedValue), "", "", "", "", "", "");
            ddlCOA.DataSource = query;
            ddlCOA.DataTextField = "COAName_Num";
            ddlCOA.DataValueField = "COAId";
            ddlCOA.DataBind();
            ddlCOA.Items.Insert(0, new ListItem("Select One", "0"));
        }
        protected void ddlMainHead_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubCodeId1();
        }
        protected void ddlSubCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubCodeId2();
        }
        protected void ddlSubCode2_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadCOA();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            if (txtAccountCodeNO.Text == "" && ddlMainHead.SelectedValue == "0")
            {

            }

            else
            {
                Loaddata();
            }
            //DateTime value;
            //if (!DateTime.TryParse(txtfromdate.Text, out value))
            //{
            //    txtfromdate.Text = DateTime.Today.ToShortDateString();
            //}
            //else
            //{
            //    Label9.Visible = true;
            //}

        }
        public void Loaddata()
        {
            ReportViewer1.Visible = true;
            ReportParameter p1 = new ReportParameter("fromdate");
            ReportParameter p2 = new ReportParameter("todate");
            ReportParameter p3 = new ReportParameter("coanum");
            ReportParameter p4 = new ReportParameter("mainheadid");
            ReportParameter p5 = new ReportParameter("subcode1id");
            ReportParameter p6 = new ReportParameter("subcode2id");
            ReportParameter p7 = new ReportParameter("coaid");
            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4, p5, p6, p7 });
            this.ReportViewer1.LocalReport.Refresh();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            LoadMainHead();
            LoadSubCodeId1();
            LoadSubCodeId2();
            LoadCOA();
            Loaddata();
            txtAccountCodeNO.Text = "";
            txtfromdate.Text = "";
            txtTodate.Text = "";
            this.ReportViewer1.LocalReport.Refresh();
        }
    }
}