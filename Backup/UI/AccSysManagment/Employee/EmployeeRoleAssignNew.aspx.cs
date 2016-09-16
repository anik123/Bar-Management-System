using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABLL;
using ADTO;

namespace UI.AccSysManagment.Employee
{
    public partial class EmployeeRoleAssignNew : System.Web.UI.Page
    {
        EmpBasinInfoBLL EBLL = new EmpBasinInfoBLL();

        UserRoleBLL URBLL = new UserRoleBLL();
        RoleBLL RBLL = new RoleBLL();
        UserRoleDTO DTO = new UserRoleDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                pagingLoal();
                LoadEmpName();
                LoadRole();
            }

        }
        private void LoadEmpName()
        {
            var quary = URBLL.LoadEmpName(0, 0);
            CEmpName.DataSource = quary;
            CEmpName.DataTextField = "EmpName";
            CEmpName.DataValueField = "EmpId";
            CEmpName.DataBind();
            CEmpName.Items.Insert(0, new ListItem("Select Emp Name", "0"));
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
        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            List<UserRoleDTO> pp = new List<UserRoleDTO>();
            pp = URBLL.LoadUserRole_linkbuttonEmpName_New_2(Convert.ToInt32(e.CommandArgument.ToString()), 0, 0);
            HFUserRoleId.Value = pp.First().UserRoleId.ToString();

            ddlRoleName.SelectedValue = pp.First().RoleId.ToString();
            CEmpName.SelectedValue = pp.First().EmpId.ToString();
            btnSave.Text = "Update";
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (CEmpName.SelectedValue == "0")
            {
                lblEmpvalidation.Visible = true;
                CEmpName.Focus();
                return;
            }

            if (btnSave.Text == "Save")
            {
                DTO.EmpId = Convert.ToInt32(CEmpName.SelectedValue);
                DTO.RoleId = Convert.ToInt32(ddlRoleName.SelectedValue);
                DTO.CreateDate = System.DateTime.Now;
                DTO.CreateBy = HttpContext.Current.User.Identity.Name;
                URBLL.Add(DTO);
            }
            else
            {
                DTO.UserRoleId = Convert.ToInt32(HFUserRoleId.Value);
                DTO.EmpId = Convert.ToInt32(CEmpName.SelectedValue);
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
          //  CEmpName.SelectedValue = "0";
            LoadEmpName();
            LoadRole();
            btnSave.Text = "Save";
            HFUserRoleId.Value = "";
            lblEmpvalidation.Visible = false;
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();

        }
    }
}