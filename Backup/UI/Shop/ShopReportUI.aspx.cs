using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABLL;

namespace UI.Shop
{
    public partial class ShopReportUI : System.Web.UI.Page
    {
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetBranchId();

            }
        }
        public void GetBranchId()
        {
            string empusername = HttpContext.Current.User.Identity.Name;
            var brid = empBLL.GetCurrentUserBranchName(empusername);

            HFBranceId.Value = brid.First().BrProId.ToString();
        }

        protected void btnCurrentStockStatus_Branch_Click(object sender, EventArgs e)
        {
            int brproid = Convert.ToInt32(HFBranceId.Value);
            Response.Redirect("~/Shop/Report/BranchStockStatusRptUI.aspx?brproid=" + brproid.ToString());
        }

        protected void btnSalesAmountView_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Shop/BranchSalesAmountView.aspx");
        }

        protected void btnShopSalesPrintUI_Click(object sender, EventArgs e)
        {
            int brid = Convert.ToInt32(HFBranceId.Value);

            Response.Redirect("/Shop/Report/BranchWiseSaleReportUI.aspx?brid=" + brid.ToString());
        }

        protected void btnShopReturnRptView_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Shop/ShopToPartyReturnView.aspx");

        }
        protected void btnRatingofGoods_BranchWise_Click(object sender, EventArgs e)
        {
            int brid = Convert.ToInt32(HFBranceId.Value);

            Response.Redirect("/Shop/Report/RatingOfGoods_BranchWiseRptUI.aspx?brid=" + brid.ToString());
        }


    }
}