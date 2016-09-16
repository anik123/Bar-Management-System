using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.PBLL;

namespace UI.AccSysManagment.Employee.LogFile
{
    public partial class Log_EmpPayInofUI : System.Web.UI.Page
    {
        LogPayRollBLL BLL = new LogPayRollBLL();

       // DateTime now = DateTime.Now;
        DateTime firstday = new DateTime(System.DateTime.Now.Year, System.DateTime.Now.Month, 1);

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               
                txtFromDate.Text = firstday.ToShortDateString();//System.DateTime.Now.ToShortDateString();
                txtTodate.Text = System.DateTime.Now.ToShortDateString();
                LoadLogFileDataInGv();
                // pay roll
                txtFromDate_Roll.Text = firstday.ToShortDateString();
                txtTodate_Roll.Text = System.DateTime.Now.ToShortDateString();
                LoadLogFileDataInGv_payRoll();
            }
        }
        private void LoadLogFileDataInGv()
        {
            var data = BLL.LoadLog_EmpBaicInfo(txtFromDate.Text, txtTodate.Text);
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
            var data = BLL.LoadLog_EmpBaicInfo(txtFromDate.Text, txtTodate.Text);
            GridView1.DataSource = data;
            GridView1.DataBind();
        }

        protected void BtncanCel_Click(object sender, EventArgs e)
        {
            txtFromDate.Text = firstday.ToShortDateString();
            txtTodate.Text = System.DateTime.Now.ToShortDateString();
            LoadLogFileDataInGv();
        }


        // start pay roll


        private void LoadLogFileDataInGv_payRoll()
        {
            var data = BLL.LoadLog_UserRole(txtFromDate_Roll.Text, txtTodate_Roll.Text);
            GridView2.DataSource = data;
            GridView2.DataBind();
        }
        protected void GridView2_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridView2.PageIndex = e.NewPageIndex;
            LoadLogFileDataInGv_payRoll();
        }

        protected void BtnSearchRoll_Click(object sender, EventArgs e)
        {
            var data = BLL.LoadLog_UserRole(txtFromDate_Roll.Text, txtTodate_Roll.Text);
            GridView2.DataSource = data;
            GridView2.DataBind();
        }
        protected void BtnSearchRoll_Cancel_Click(object sender, EventArgs e)
        {

            txtFromDate_Roll.Text = firstday.ToShortDateString();
            txtTodate_Roll.Text = System.DateTime.Now.ToShortDateString();
            LoadLogFileDataInGv_payRoll();
        }

    }
}