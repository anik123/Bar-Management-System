using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABLL;
using PBLL.Page_ObjectBLL;
using BLL;
using DTO;
using System.Web.Security;

namespace UI.Shop
{
    public partial class FirstSale : System.Web.UI.Page
    {
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        //Member

        MemberBLL memBLL = new MemberBLL();
        MemberDTO memDTO = new MemberDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                LoadMember();
                RoleName();
                Page.Title = "Sales Product";
                rbtMember.RepeatLayout = RepeatLayout.Table;
                Session.Remove("member");
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
        void LoadMember()
        {
            // LoadmemDDL();
            var data = memBLL.GetOpenAccountMemeberList(txtActiveMemNo.Text, txtActiveMemName.Text, "", "");
            rbtMember.DataSource = data;
            rbtMember.DataTextField = "FullName";
            rbtMember.DataValueField = "MemberId";
            rbtMember.DataBind();

        }
        private void LoadAllMember()
        {

            var query = memBLL.GetMember("", "", "", "", 0);

            rbtMember.DataSource = query;
            rbtMember.DataTextField = "SellFullName";
            rbtMember.DataValueField = "MemberId";
            rbtMember.DataBind();



        }
        private void SearchAllMember()
        {

            var query = memBLL.GetMember(txtAllMemNo.Text, txtAllMemName.Text, "", "", 0);

            rbtMember.DataSource = query;
            rbtMember.DataTextField = "SellFullName";
            rbtMember.DataValueField = "MemberId";
            rbtMember.DataBind();



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

        protected void BtnActiveSearch_Click(object sender, EventArgs e)
        {
            LoadMember();
        }

        protected void btnViewAll_Click(object sender, EventArgs e)
        {
            LoadAllMember();
        }

        protected void btnAllSearch_Click(object sender, EventArgs e)
        {
            SearchAllMember();
        }

        protected void btnAddMember_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/Admin/MemberUI.aspx");
        }

        protected void btnAddGuest_Click(object sender, EventArgs e)
        {
            memDTO.MemberNo = "";
            memDTO.MemType = "Guest";
            memDTO.FullName = txtAddGuestName.Text;
            memDTO.Type = "";
            memDTO.Exservice = "";
            memDTO.ContactNo = "";
            memBLL.Add(memDTO);
            //txtAddGuestName.Text = "";


            var memdata = memBLL.LoadLastId();

            Session.Remove("member");
            var data = memdata.First().MemberId + "#" + memdata.First().FullName;
            Session.Add("member", data);
            Response.Redirect("~/Shop/SecondSales.aspx");



            //Show("Sucessfully Added!");
        }

        protected void rbtMember_SelectedIndexChanged(object sender, EventArgs e)
        {
            // Show(rbtMember.SelectedItem+" - "+rbtMember.SelectedValue);
            Session.Remove("member");
            var data = rbtMember.SelectedValue + "#" + rbtMember.SelectedItem;
            Session.Add("member", data);
            Response.Redirect("~/Shop/SecondSales.aspx");
        }

        protected void btnExit_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/LogSuccessPage.aspx");
        }
    }
}