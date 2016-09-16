using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DTO;
using System.Web.Security;
using ABLL;
using PBLL.Page_ObjectBLL;

namespace UI.Admin
{
    public partial class ExpenseHeadUI : System.Web.UI.Page
    {
        ExpenseHeadBLL BLL = new ExpenseHeadBLL();
        ExpenseHeadDTO DTO = new ExpenseHeadDTO();

        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Expense";
                pagingLoal();

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
        private void pagingLoal()
        {

            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = BLL.GetExpenseHead(0);
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

            RptMainHead.DataSource = objPds;
            RptMainHead.DataBind();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (txtExpenseHeadName.Text == "")
            {
                txtExpenseHeadName.Focus();
                return;
            }

            DTO.HeadName = txtExpenseHeadName.Text.ToString();


            // RDTO.CreateDate = System.DateTime.Now;
            // RDTO.CreateBy = "tarun";
            if (btnSave.Text == "Save")
            {
                BLL.Add(DTO);
                pagingLoal();
                clearCntrol();
            }
            else
            {
                DTO.ExHeadId = Convert.ToInt32(HFExHID.Value);
                // RDTO.UpdateDate = System.DateTime.Now;
                // CDTO.UpdateBy = "tarun";
                BLL.Edit(DTO);
                btnSave.Text = "Save";
                pagingLoal();
                clearCntrol();
            }

        }


        private void clearCntrol()
        {
            txtExpenseHeadName.Text = "";
            btnSave.Text = "Save";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();

        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            List<ExpenseHeadDTO> bb = new List<ExpenseHeadDTO>();
            bb = BLL.GetExpenseHead(Convert.ToInt32(e.CommandArgument.ToString()));
            HFExHID.Value = bb.First().ExHeadId.ToString();
            txtExpenseHeadName.Text = bb.First().HeadName.ToString();
            btnSave.Text = "Update";
        }
    }
}