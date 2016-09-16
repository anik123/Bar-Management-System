using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;

namespace UI.Test
{
    public partial class WebForm1 : System.Web.UI.Page
    {
        ReportBLL bll = new ReportBLL();
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void Button1_Click(object sender, EventArgs e)
        {
            var data = bll.BranchStockStatus_Details(0, 0, 0, 3);
            int i = data.Count;
        }
    }
}