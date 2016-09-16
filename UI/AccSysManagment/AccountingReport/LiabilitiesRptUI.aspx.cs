using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using Microsoft.Reporting.WebForms;
using ABLL;
using ADTO;

namespace UI.AccSysManagment.AccountingReport
{
    public partial class LiabilitiesRptUI : System.Web.UI.Page
    {
        SubCode_1BLL s1bll = new SubCode_1BLL();
        SubCode_2BLL s2bll = new SubCode_2BLL();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Liabilities Report";
                LoadSubCode_1_Data();
                LoadSubCode_2_Data();


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


                string subccode1id = Request.QueryString["subccode1id"];
                string subcode2id = Request.QueryString["subcode2id"];

                if (subccode1id != null)
                {
                    //  txtYear.Text = Year.ToString();
                    ddlSubCode1.SelectedValue = subccode1id.ToString();
                    if (subcode2id != null)
                    {

                        ddlSubCode2.SelectedValue = subcode2id.ToString();
                        //ddlMedication.Text = medname.ToString();
                    }

                }
                Loaddata();
            }

        }
        private void LoadSubCode_1_Data()
        {
            var query = s1bll.LoadSuvCode_1Data_Liabilities();
            ddlSubCode1.DataSource = query;
            ddlSubCode1.DataTextField = "SubCode1Name_Num";
            ddlSubCode1.DataValueField = "SubCode_1Id";
            ddlSubCode1.DataBind();
            ddlSubCode1.Items.Insert(0, new ListItem("Select One", "0"));
        }

        private void LoadSubCode_2_Data()
        {
            // (int id, string Subcode2Num, string SubCode2name, int sucodeid1, string subc1no, string subcode1name, string mainheadno, string mainheadname)

            var query = s2bll.LoadSuvCode_2Data(0, "", "", Convert.ToInt32(ddlSubCode1.SelectedValue), "", "", "", "");
            //var query = S2BLL.LoadSuvCode_2Data_COAPage(0, "", Convert.ToInt32(ddlMainHeadCodeId.SelectedValue), Convert.ToInt32(ddlSubcode1.SelectedValue), 0);
            ddlSubCode2.DataSource = query;
            ddlSubCode2.DataTextField = "SubCode2Name_Num";
            ddlSubCode2.DataValueField = "SubCode_2Id";
            ddlSubCode2.DataBind();
            ddlSubCode2.Items.Insert(0, new ListItem("Select One", "0"));
        }
        protected void ddlSubCode1_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubCode_2_Data();

        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Loaddata();

        }
        public void Loaddata()
        {
            ReportViewer1.Visible = true;

            ReportParameter p1 = new ReportParameter("fromdate");
            ReportParameter p2 = new ReportParameter("todate");
            ReportParameter p3 = new ReportParameter("subccode1id");
            ReportParameter p4 = new ReportParameter("Subcode2id");


            this.ReportViewer1.LocalReport.SetParameters(new ReportParameter[] { p1, p2, p3, p4 });
            this.ReportViewer1.LocalReport.Refresh();
        }
        protected void btnClear_Click(object sender, EventArgs e)
        {
            txtfromdate.Text = "";
            txtTodate.Text = "";
            this.ReportViewer1.LocalReport.Refresh();

            LoadSubCode_1_Data();
            LoadSubCode_2_Data();
        }


    }
}