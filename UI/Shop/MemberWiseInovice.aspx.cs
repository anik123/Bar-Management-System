using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ABLL;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.Shop
{
    public partial class MemberWiseInovice : System.Web.UI.Page
    {
        MemberBLL memBLL = new MemberBLL();
        InvenSalesBLL SaleBLL = new InvenSalesBLL();
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SearchMember();
                //LoadMember();
                RoleName();
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
        protected void GVMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GVMember.PageIndex = e.NewPageIndex;
            SearchMember();

        }
        void SearchMember()
        {

            var data = memBLL.GetActiveMemeberList(txtMemno.Text, txtMemName.Text, txtMobileNo.Text, ddlSMemType.SelectedValue);

            GVMember.DataSource = data;
            GVMember.DataBind();
            // ddlMember.SelectedValue=
        }
        protected void LinkButton_Inovice(object sender, CommandEventArgs e)
        {
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Shop/Report/BranchSalesRptUI.aspx?SalId=" + e.CommandArgument.ToString() + "');", true);
        }
        protected void LinkButton_Activity(object sender, CommandEventArgs e)
        {
            var data = SaleBLL.LoadActiveMemberDateWise(int.Parse(HFMemberId.Value), e.CommandArgument.ToString());
            if (data.Count > 0)
            {
                //  HFMemberId.Value = e.CommandArgument.ToString();
                // ddlMember.SelectedValue = e.CommandArgument.ToString();
                PagedDataSource objPds = new PagedDataSource();
                objPds.DataSource = data;
                objPds.AllowPaging = true;
                objPds.PageSize = 8;
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

                RptDetails.DataSource = objPds;
                RptDetails.DataBind();
                pnlDetails.Visible = true;
            }
            else
            {
                Show("No Activity!");
            }
        }
        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            var data = SaleBLL.LoadActiveMember(int.Parse(e.CommandArgument.ToString()), 0, 0);
            if (data.Count > 0)
            {
                HFMemberId.Value = e.CommandArgument.ToString();
                // ddlMember.SelectedValue = e.CommandArgument.ToString();
                PagedDataSource objPds = new PagedDataSource();
                objPds.DataSource = data;
                objPds.AllowPaging = true;
                objPds.PageSize = 8;
                int CurPage;
                if (Request.QueryString["Page"] != null)
                    CurPage = Convert.ToInt32(Request.QueryString["Page"]);
                else
                    CurPage = 1;


                objPds.CurrentPageIndex = CurPage - 1;
                lblPayCurrentPage.Text = "Page: " + CurPage.ToString();

                if (!objPds.IsFirstPage)
                    lnkPayPrev.NavigateUrl = Request.CurrentExecutionFilePath
                    + "?Page=" + Convert.ToString(CurPage - 1);

                if (!objPds.IsLastPage)
                    lnkPayNext.NavigateUrl = Request.CurrentExecutionFilePath
                    + "?Page=" + Convert.ToString(CurPage + 1);

                RptPayment.DataSource = objPds;
                RptPayment.DataBind();
                pnlSale.Visible = true;
            }
            else
            {
                Show("No Activity!");
            }
        }
        public static void Show(string message)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                message = message.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + message + "');", true);
            }
        }
        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchMember();
        }

        protected void btnSearchClear_Click(object sender, EventArgs e)
        {
            ClearView();
        }

        private void ClearView()
        {
            txtMemName.Text = "";
            txtMemno.Text = "";
            txtMobileNo.Text = "";
            ddlSMemType.SelectedIndex = 0;
            pnlSale.Visible = false;
            pnlDetails.Visible = false;
        }
    }
}