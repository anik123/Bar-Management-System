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
    public partial class ExpenseHeadUI : System.Web.UI.Page
    {
        ExpenseHeadBLL BLL = new ExpenseHeadBLL();
        ExpenseHeadDTO DTO = new ExpenseHeadDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                pagingLoal();

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