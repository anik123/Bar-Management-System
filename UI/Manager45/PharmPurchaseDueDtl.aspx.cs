using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL.MedicationBLL;

namespace HMS.UI.MedicationUI
{
    public partial class PharmPurchaseDueDtl : System.Web.UI.Page
    {
        PurchaseDueBLL DBLL = new PurchaseDueBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                string purid = Request.QueryString["purid"];
                int PurId;
                PurId = Convert.ToInt32(purid);
                //if (purid != null)
                //  {
                loadDataGvDueInfo(PurId, 0, "");
                  //}
            }

        }

        private void loadDataGvDueInfo(int payid, int Compid, string SalesManName)
        {
            var data = DBLL.GetPyurchaseDueDtalil(payid,Compid,SalesManName);
            GvDueInfo.DataSource = data;
            GvDueInfo.DataBind();
        }

        protected void GvDueInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDueInfo.PageIndex = e.NewPageIndex;
            loadDataGvDueInfo(0,0,"");
        }
    }
}