using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABLL;

namespace UI.AccSysManagment.LogFile
{
    public partial class LogFileJouranlEditRpt : System.Web.UI.Page
    {
        Log_AccJournalBLL BLL = new Log_AccJournalBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                txtFromDate.Text = System.DateTime.Now.ToShortDateString();
                txtTodate.Text = System.DateTime.Now.ToShortDateString();
                LoadLogFileDataInGv();
            }

        }

        private void LoadLogFileDataInGv()
        {

            var data = BLL.LoadLog_JournalUpdateData(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtTodate.Text));
            GridView1.DataSource = data;
            GridView1.DataBind();
        }
        protected void GridView1_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView1.PageIndex = e.NewPageIndex;
            LoadLogFileDataInGv();
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            var data = BLL.LoadLog_JournalUpdateData(Convert.ToDateTime(txtFromDate.Text), Convert.ToDateTime(txtTodate.Text));
            GridView1.DataSource = data;
            GridView1.DataBind();
        }

        protected void BtncanCel_Click(object sender, EventArgs e)
        {
            txtFromDate.Text = System.DateTime.Now.ToShortDateString();
            txtTodate.Text = System.DateTime.Now.ToShortDateString();
            LoadLogFileDataInGv();
        }
    }
}