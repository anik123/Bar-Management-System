using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DTO;

namespace UI.Admin
{
    public partial class ExpenseUI : System.Web.UI.Page
    {
        ExpenseBLL ExBLL = new ExpenseBLL();
        ExpenseDTO ExDTO = new ExpenseDTO();

        ExpenseHeadBLL ExHBLL = new ExpenseHeadBLL();
        ExpenseHeadDTO ExHDTO = new ExpenseHeadDTO();


        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                pagingLoal();
                LoadExpenseHead();
                txtDate.Text = System.DateTime.Now.ToShortDateString();

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
                ExDTO.CreateBy = "tarun";
                ExBLL.Add(ExDTO);
                pagingLoal();
                clearCntrol();
            }
            else
            {
                ExDTO.ExpanseId = Convert.ToInt32(HFExId.Value);
                ExDTO.UpdateDate = System.DateTime.Now;
                ExDTO.UpdateBy = "tarun";
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