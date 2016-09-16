using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ADTO;
using ABLL;

namespace UI.AccSysManagment.Employee
{
    public partial class EmployeeType : System.Web.UI.Page
    {
        EmpTypeDTO DTO = new EmpTypeDTO();
        EmpTypeBLL TBLL = new EmpTypeBLL();


        EmpSpecialistBLL Sbll = new EmpSpecialistBLL();
        EmpSpcialistDTO SDTO = new EmpSpcialistDTO();

        RoleBLL RBLL = new RoleBLL();
        RoleDTO Rdto = new RoleDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                loadDataGVRole(0);
                loadDept();
                loadDataGVEmpBasic(0);
                pagingLoal();
            }
        }

        private void loadDataGVRole(int id)
        {
            var data = TBLL.GetEmpType(id);
            GridRole.DataSource = data;
            GridRole.DataBind();
        }

        protected void GridRole_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GridRole.PageIndex = e.NewPageIndex;
            loadDataGVRole(0);
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            DTO.TypeName = txtdeptName.Text.ToString();

            DTO.CreateDate = System.DateTime.Now;
            DTO.CreateBy = HttpContext.Current.User.Identity.Name;
            if (btnSave.Text == "Save")
            {
                TBLL.Add(DTO);
            }
            else
            {
                DTO.EmpTypeId = Convert.ToInt32(hDepttId.Value);
                DTO.UpdateDate = System.DateTime.Now;
                DTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                TBLL.Edit(DTO);
                btnSave.Text = "Save";
            }
            loadDataGVRole(0);
            clearCntrol();
            loadDept();
        }

        private void clearCntrol()
        {
            txtdeptName.Text = "";
            btnSave.Text = "Save";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();

        }

        protected void LinkButton_Command_GridRole(object sender, CommandEventArgs e)
        {
            List<EmpTypeDTO> bb = new List<EmpTypeDTO>();

            bb = TBLL.GetEmpType(Convert.ToInt32(e.CommandArgument.ToString()));
            hDepttId.Value = bb.First().EmpTypeId.ToString();
            txtdeptName.Text = bb.First().TypeName.ToString();
            btnSave.Text = "Update";
        }

        // designation
        private void loadDept()
        {

            var query = TBLL.GetEmpType(0);
            ddldeptName.DataSource = query;
            ddldeptName.DataTextField = "TypeName";
            ddldeptName.DataValueField = "EmpTypeId";
            ddldeptName.DataBind();
            ddldeptName.Items.Insert(0, new ListItem("Select Dept Name", "0"));

        }

        protected void BtnSaveDesigantion_Click(object sender, EventArgs e)
        {
            SDTO.Specialist = txtdisignation.Text.ToString();
            SDTO.EmpTypeId = Convert.ToInt32(ddldeptName.SelectedValue.ToString());
            SDTO.CreateDate = System.DateTime.Now;
            SDTO.CreateBy = HttpContext.Current.User.Identity.Name;
            if (BtnSaveDesigantion.Text == "Save")
            {
                Sbll.Add(SDTO);
                loadDataGVEmpBasic(0);
                clearCntrol_designation();
            }
            else
            {
                SDTO.EmpSpecilistId = Convert.ToInt32(HFDesigantion.Value);
                SDTO.UpdateDate = System.DateTime.Now;
                SDTO.UpdateBy = HttpContext.Current.User.Identity.Name;
                Sbll.Edit(SDTO);
                btnSave.Text = "Save";
                loadDataGVEmpBasic(0);
                clearCntrol_designation();
            }

        }

        private void clearCntrol_designation()
        {
            txtdisignation.Text = "";
            BtnSaveDesigantion.Text = "Save";
            loadDept();
        }
        protected void BtnCanelDesigantion_Click(object sender, EventArgs e)
        {
            clearCntrol_designation();

        }

        private void loadDataGVEmpBasic(int id)
        {
            var data = Sbll.GetSpcialistSearch(id);
            GvEmpBasic.DataSource = data;
            GvEmpBasic.DataBind();
        }

        protected void GvEmpBasic_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvEmpBasic.PageIndex = e.NewPageIndex;
            loadDataGVEmpBasic(0);
        }
        protected void LinkButton_Command_Basic(object sender, CommandEventArgs e)
        {
            List<EmpSpcialistDTO> bb = new List<EmpSpcialistDTO>();
            bb = Sbll.GetSpcialistSearch(Convert.ToInt32(e.CommandArgument.ToString()));
            HFDesigantion.Value = bb.First().EmpSpecilistId.ToString();
            txtdisignation.Text = bb.First().Specialist.ToString();
            ddldeptName.SelectedValue = bb.First().EmpTypeId.ToString();
            BtnSaveDesigantion.Text = "Update";
        }
        // desigantion

        // Role Set up
        private void pagingLoal()
        {

            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = RBLL.LoadRole(0);
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
            List<RoleDTO> bb = new List<RoleDTO>();

            bb = RBLL.LoadRole(Convert.ToInt32(e.CommandArgument.ToString()));
            HFRoleId.Value = bb.First().RoleId.ToString();
            txtRolename.Text = bb.First().RoleName.ToString();
            btnSave.Text = "Update";
        }
        protected void BtnSaveRole_Click(object sender, EventArgs e)
        {
            Rdto.RoleName = txtRolename.Text.ToString();

            Rdto.CreateDate = System.DateTime.Now;
            Rdto.CreateBy = HttpContext.Current.User.Identity.Name;
            if (btnSave.Text == "Save")
            {
                RBLL.Add(Rdto);
            }
            else
            {
                Rdto.RoleId = Convert.ToInt32(HFRoleId.Value);
                Rdto.UpdateDate = System.DateTime.Now;
                Rdto.UpdateBy = HttpContext.Current.User.Identity.Name;
                RBLL.Edit(Rdto);
                btnSave.Text = "Save";
            }
            pagingLoal();
            clearCntrol_role();
        }

        private void clearCntrol_role()
        {
            txtRolename.Text = "";
            btnSave.Text = "Save";
        }
        protected void BtnCancelRole_Click(object sender, EventArgs e)
        {
            clearCntrol_role();

        }
        // Role Set up

    }
}