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
    public partial class ExpenseUI : System.Web.UI.Page
    {
        ExpenseBLL ExBLL = new ExpenseBLL();
        ExpenseDTO ExDTO = new ExpenseDTO();

        ExpenseHeadBLL ExHBLL = new ExpenseHeadBLL();
        ExpenseHeadDTO ExHDTO = new ExpenseHeadDTO();


        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Expense Entry";
                pagingLoal();
                LoadExpenseHead();
                txtDate.Text = System.DateTime.Now.ToShortDateString();

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
        private void LoadExpenseHead()
        {
            var query = ExHBLL.GetExpenseHead(0);
            ddlExHeadName.DataSource = query;
            ddlExHeadName.DataTextField = "HeadName";
            ddlExHeadName.DataValueField = "ExHeadId";
            ddlExHeadName.DataBind();
            ddlExHeadName.Items.Insert(0, new ListItem("Select Category", "0"));
        }


        private void pagingLoal()
        {

            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = ExBLL.GetExpenseInfo(0);
            objPds.AllowPaging = true;
            objPds.PageSize = 6;
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
            if (txtAmount.Text == "")
            {
                txtAmount.Focus();
                return;
            }

            ExDTO.Amount = Convert.ToInt32(txtAmount.Text);
            ExDTO.Remarks = txtRemarks.Text.ToString();
            ExDTO.ExHeadId = Convert.ToInt32(ddlExHeadName.SelectedValue);

            ExDTO.Date = Convert.ToDateTime(txtDate.Text.ToString());


            //  ExDTO.Date = Convert.ToDateTime(txtDate.Text);
            if (btnSave.Text == "Save")
            {
                ExDTO.CreateDate = System.DateTime.Now;
                ExDTO.CreateBy = HttpContext.Current.User.Identity.Name;
                ExBLL.Add(ExDTO);
                pagingLoal();
                clearCntrol();
            }
            else
            {
                ExDTO.ExpanseId = Convert.ToInt32(HFExId.Value);
                ExDTO.UpdateDate = System.DateTime.Now;
                ExDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                ExBLL.Edit(ExDTO);
                btnSave.Text = "Save";
                pagingLoal();
                clearCntrol();
            }

        }


        private void clearCntrol()
        {
            LoadExpenseHead();
            txtAmount.Text = "";
            txtAmount.Text = "";
            txtDate.Text = "Today";
            txtRemarks.Text = "";
            btnSave.Text = "Save";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();
        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            List<ExpenseDTO> bb = new List<ExpenseDTO>();
            bb = ExBLL.GetExpenseInfo(Convert.ToInt32(e.CommandArgument.ToString()));
            HFExId.Value = bb.First().ExpanseId.ToString();
            txtAmount.Text = bb.First().Amount.ToString();
            txtRemarks.Text = bb.First().Remarks.ToString();
            txtDate.Text = bb.First().Date.ToString();
            ddlExHeadName.SelectedValue = bb.First().ExHeadId.ToString();
            btnSave.Text = "Update";
        }
    }
}