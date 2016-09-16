using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABLL;
using System.Web.Security;
using PBLL.Page_ObjectBLL;

namespace UI.Shop
{
    public partial class ShopReportUI : System.Web.UI.Page
    {
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Shop Report";
                GetBranchId();

            }
        }
        public void RoleName()
        {

            string empusername = HttpContext.Current.User.Identity.Name;

            var role = LBLL.GetRoleName_By_User(empusername);
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
        protected void btnStockDetails_Click(object sender, EventArgs e)
        {
            int brproid = Convert.ToInt32(HFBranceId.Value);
            Response.Redirect("~/Shop/Report/BranchStockStatus_Details_RptUI.aspx?brproid=" + brproid.ToString());
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

        protected void ButtonReturn_Click(object sender, EventArgs e)
        {

            int brid = Convert.ToInt32(HFBranceId.Value);

            Response.Redirect("/Shop/Report/BranchReturnRpt.aspx?brid=" + brid.ToString());
        }

        protected void ButtonProfit_Click(object sender, EventArgs e)
        {
            int brid = Convert.ToInt32(HFBranceId.Value);

            Response.Redirect("/Shop/Report/BranchProfitRpt.aspx?brid=" + brid.ToString());
     
        }



    }
}