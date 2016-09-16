using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABLL;
using ADTO;
using DTO.PDTO;
using BLL.PBLL;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.AccSysManagment.Employee
{
    public partial class EmpRoleAssign : System.Web.UI.Page
    {
        // for log file
        LogPayRollBLL LogBLL = new LogPayRollBLL();
        LogPayUserRollDTO LogDTO = new LogPayUserRollDTO();
        EmpBasinInfoBLL EBLL = new EmpBasinInfoBLL();
        EmpTypeBLL TBLL = new EmpTypeBLL();
        UserRoleBLL URBLL = new UserRoleBLL();
        RoleBLL RBLL = new RoleBLL();
        UserRoleDTO DTO = new UserRoleDTO();


        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {

                RoleName();
                Page.Title = "Employee Role Assign";
                pagingLoal();
                loadDeptName();
                LoadDesignation();
                LoadEmpName();
                LoadRole();
                //LoadEmpNameNew();
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
        private void loadDeptName()
        {
            var query = TBLL.GetEmpType(0);
            ddldeptName.DataSource = query;
            ddldeptName.DataTextField = "TypeName";
            ddldeptName.DataValueField = "EmpTypeId";
            ddldeptName.DataBind();
            ddldeptName.Items.Insert(0, new ListItem("Select Department", "0"));
        }
        private void LoadDesignation()
        {
            var query = EBLL.GetSpcialistSearch(Convert.ToInt32(ddldeptName.SelectedValue));
            ddlDesignation.DataSource = query;
            ddlDesignation.DataTextField = "SpecilistName";
            ddlDesignation.DataValueField = "EmpSpecilistId";
            ddlDesignation.DataBind();
            ddlDesignation.Items.Insert(0, new ListItem("Select Designation", "0"));
        }
        private void LoadRole()
        {
            var query = RBLL.LoadRole(0);
            ddlRoleName.DataSource = query;
            ddlRoleName.DataTextField = "RoleName";
            ddlRoleName.DataValueField = "RoleId";
            ddlRoleName.DataBind();
            ddlRoleName.Items.Insert(0, new ListItem("Select Role", "0"));
        }


        protected void ddldeptName_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadDesignation();

        }

        protected void ddlDesignation_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadEmpName();
        }
        private void pagingLoal()
        {

            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = URBLL.LoadUserRole_linkbuttonEmpName_New(0);
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

            RptDisignation.DataSource = objPds;
            RptDisignation.DataBind();
        }
        private void LoadEmpName()
        {
            var quary = URBLL.LoadEmpName(Convert.ToInt32(ddldeptName.SelectedValue), Convert.ToInt32(ddlDesignation.SelectedValue));
            ddlEmpName.DataSource = quary;
            ddlEmpName.DataTextField = "EmpName";
            ddlEmpName.DataValueField = "EmpId";
            ddlEmpName.DataBind();
            ddlEmpName.Items.Insert(0, new ListItem("Select Employee", "0"));
        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            List<UserRoleDTO> pp = new List<UserRoleDTO>();
            pp = URBLL.LoadUserRole_linkbuttonEmpName_New_2(Convert.ToInt32(e.CommandArgument.ToString()), 0, 0);
            HFUserRoleId.Value = pp.First().UserRoleId.ToString();
            ddldeptName.SelectedValue = pp.First().EmpTypeId.ToString();
            ddlDesignation.SelectedValue = pp.First().EmpSpcilistId.ToString();
            ddlRoleName.SelectedValue = pp.First().RoleId.ToString();


            List<UserRoleDTO> pp1 = new List<UserRoleDTO>();
            pp1 = URBLL.LoadUserRole_linkbuttonEmpName_New_2(Convert.ToInt32(e.CommandArgument.ToString()), Convert.ToInt32(ddldeptName.SelectedValue), Convert.ToInt32(ddlDesignation.SelectedValue));
            string empid = pp1.First().EmpId.ToString();

            ddlEmpName.SelectedValue = empid;


            btnSave.Text = "Update";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (btnSave.Text == "Save")
            {
                DTO.EmpId = Convert.ToInt32(ddlEmpName.SelectedValue);
                DTO.RoleId = Convert.ToInt32(ddlRoleName.SelectedValue);
                DTO.CreateDate = System.DateTime.Now;
                DTO.CreateBy = HttpContext.Current.User.Identity.Name;
                URBLL.Add(DTO);
            }
            else
            {
                // start log insert
                string Logfield = "";
                var bb = URBLL.LoadUserRole_linkbuttonEmpName_New_2(Convert.ToInt32(HFUserRoleId.Value), 0, 0);
                Logfield = "UserRoleId-" + HFUserRoleId.Value + ";" + " Employee-" + ddlEmpName.SelectedItem + ";" + " Role-" + bb.First().RoleName.ToString() + "#" + ddlRoleName.SelectedItem + ";";
                LogDTO.LogField = Logfield;
                LogDTO.LogBy = HttpContext.Current.User.Identity.Name;
                LogDTO.LogDate = System.DateTime.Now;
                LogBLL.AddUserRole_Log(LogDTO);
                // end log insert

                DTO.UserRoleId = Convert.ToInt32(HFUserRoleId.Value);
                DTO.EmpId = Convert.ToInt32(ddlEmpName.SelectedValue);
                DTO.RoleId = Convert.ToInt32(ddlRoleName.SelectedValue);

                DTO.UpdateDate = System.DateTime.Now;
                DTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                URBLL.Edit(DTO);
                btnSave.Text = "Save";
            }
            pagingLoal();
            clearCntrol();
        }

        private void clearCntrol()
        {
            loadDeptName();
            LoadDesignation();
            LoadEmpName();
            LoadRole();
            btnSave.Text = "Save";
            HFUserRoleId.Value = "";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();

        }

        
    }
}