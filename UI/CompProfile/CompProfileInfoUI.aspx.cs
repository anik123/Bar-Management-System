using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO.CompProfile;
using BLL.CompProfile;
using ABLL;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.CompProfile
{
    public partial class CompProfileInfoUI : System.Web.UI.Page
    {
        CompProfileInfoDTO DTO = new CompProfileInfoDTO();
        CompProfileInfoBLL CBLL = new CompProfileInfoBLL();
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Pageload();
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
        private void Pageload()
        {

            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = CBLL.LoadCompProfileInfo(0);
            objPds.AllowPaging = true;
            objPds.PageSize = 4;
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

            RptComp.DataSource = objPds;
            RptComp.DataBind();

        }
        private void clearCntrol()
        {
            txtCompName.Text = "";
            txtCompPhone.Text = "";
            txtCompMobile1.Text = "";
            txtCompMobile2.Text = "";
            txtCompDes.Text = "";
            txtCompWebsite.Text = "";
            txtCompEmail.Text = "";
            txtContactAdd.Text = "";
            btnSave.Text = "Save";
        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            try
            {
                var bb = CBLL.LoadCompProfileInfo(Convert.ToInt32(e.CommandArgument.ToString()));
                HFCompID.Value = bb.First().CompProId.ToString();
                txtCompName.Text = bb.First().CompProName.ToString();
                txtContactAdd.Text = bb.First().CompAddress.ToString();
                txtCompPhone.Text = bb.First().CompPhone.ToString();
                txtCompMobile1.Text = bb.First().CompMobile1.ToString();
                txtCompMobile2.Text = bb.First().CompMobile2.ToString();
                txtCompEmail.Text = bb.First().CompEmail.ToString();
                txtCompDes.Text = bb.First().CompDescription.ToString();

                txtCompWebsite.Text = bb.First().CompWebsite.ToString();
                btnSave.Text = "Update";
            }
            catch { }
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {

            DTO.CompProName = txtCompName.Text.ToString();
            DTO.CompAddress = txtContactAdd.Text.ToString();
            DTO.CompWebsite = txtCompWebsite.Text.ToString();
            DTO.CompPhone = txtCompPhone.Text.ToString();
            DTO.CompMobile1 = txtCompMobile1.Text.ToString();
            DTO.CompMobile2 = txtCompMobile2.Text.ToString();
            DTO.CompEmail = txtCompEmail.Text.ToString();
            DTO.CompDescription = txtCompDes.Text.ToString();
            if (btnSave.Text == "Save")
            {
                DTO.CreateBy = HttpContext.Current.User.Identity.Name;
                DTO.CreateDate = System.DateTime.Now;
                CBLL.Add(DTO);
            }
            else
            {
                DTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                DTO.UpdateDate = System.DateTime.Now;
                DTO.CompProId = Convert.ToInt32(HFCompID.Value);
                CBLL.Edit(DTO);
                btnSave.Text = "Save";
            }
            clearCntrol();
            Pageload();

        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();
        }
    }
}
