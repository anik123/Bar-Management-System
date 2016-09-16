using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace UI.Admin
{
    public partial class Log_InvenReorder_Branch_WiseUI_Reorder : System.Web.UI.Page
    {
        Log_InventoryBLL BLL = new Log_InventoryBLL();
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

            var data = BLL.LoadLog_Reorder_BranchWise(txtFromDate.Text, txtTodate.Text);
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
            var data = BLL.LoadLog_Reorder_BranchWise(txtFromDate.Text, txtTodate.Text);
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