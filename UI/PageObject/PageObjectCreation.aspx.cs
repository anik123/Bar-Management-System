using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using PDTO;
using PBLL.Page_ObjectBLL;
using ABLL;
using System.Web.Security;

namespace UI.PageObject
{
    public partial class PageObjectCreation : System.Web.UI.Page
    {
        PageObjectDTO PObjDTO = new PageObjectDTO();
        PageObjectBLL PObjBLL = new PageObjectBLL();
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                RoleName();

                Page.Title = "Page Object Create";
                LoadPageObject_Gridview();
                var data = PObjBLL.LoadPageObject(0);

                if (data.Count == 0)
                {
                    PnlGridView.Visible = false;
                }
                else
                {
                    PnlGridView.Visible = true;
                }
            }
        }
        public void RoleName()
        {

            //UI.PageObject.PageObjectCreation;
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
        protected void btnWSSave_Click(object sender, EventArgs e)
        {
            PObjDTO.PageTypeName = txtPageType.Text.ToString();
            PObjDTO.PageName = txtPageName.Text;
            PObjDTO.PagePath = txtPagePath.Text;
            PObjDTO.PageMethodeName = txtPageMathode.Text;
            if (btnWSSave.Text == "Save")
            {
                PObjBLL.Add(PObjDTO);
            }
            else
            {
                PObjDTO.PageObjectId = Convert.ToInt16(HFObjId.Value);
                PObjBLL.Edit(PObjDTO);
            }
            ClearControl();
        }
        public void ClearControl()
        {
            LoadPageObject_Gridview();
            GvPageObject.SelectedIndex = -1;
            txtPageMathode.Text = "";
            txtPageName.Text = "";
            txtPagePath.Text = "";
            txtPageType.Text = "";
            btnWSSave.Text = "Save";
        }

        protected void btnWSCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
        }
        private void LoadPageObject_Gridview()
        {
            var data = PObjBLL.LoadPageObject(0);
            GvPageObject.DataSource = data;
            GvPageObject.DataBind();
        }

        protected void GvPageObject_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvPageObject.PageIndex = e.NewPageIndex;
            LoadPageObject_Gridview();
        }
        protected void GvPageObject_SelectedIndexChanged(object sender, EventArgs e)
        {

            var bb = PObjBLL.LoadPageObject(Convert.ToInt32(GvPageObject.DataKeys[GvPageObject.SelectedIndex].Values["PageObjectId"].ToString()));
            HFObjId.Value = bb.First().PageObjectId.ToString();
            txtPageType.Text = bb.First().PageTypeName;
            txtPageMathode.Text = bb.First().PageMethodeName;
            txtPagePath.Text = bb.First().PagePath;
            txtPageName.Text = bb.First().PageName;
            btnWSSave.Text = "Update";
        }
    }
}