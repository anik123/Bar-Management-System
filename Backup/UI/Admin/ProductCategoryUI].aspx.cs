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
    public partial class ProductCategoryUI_ : System.Web.UI.Page
    {
        CategoryBLL CBLL = new CategoryBLL();
        CategoryDTO CDTO = new CategoryDTO();

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
            objPds.DataSource = CBLL.GetCategory(0,"");
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
            if (txtCategoryName.Text == "")
            {
                txtCategoryName.Focus();
                return;
            }

            CDTO.CategoryName = txtCategoryName.Text.ToString();


            CDTO.CreateDate = System.DateTime.Now;
            CDTO.CreateBy = "tarun";
            if (btnSave.Text == "Save")
            {
                CBLL.Add(CDTO);
                pagingLoal();
                clearCntrol();
            }
            else
            {
                CDTO.CatId = Convert.ToInt32(HFUID.Value);
                CDTO.UpdateDate = System.DateTime.Now;
                CDTO.UpdateBy = "tarun";
                CBLL.Edit(CDTO);
                btnSave.Text = "Save";
                pagingLoal();
                clearCntrol();
            }

        }


        private void clearCntrol()
        {
            txtCategoryName.Text = "";
            pagingLoal();
            btnSave.Text = "Save";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();

        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            List<CategoryDTO> bb = new List<CategoryDTO>();
            bb = CBLL.GetCategory(Convert.ToInt32(e.CommandArgument.ToString()),"");
            HFUID.Value = bb.First().CatId.ToString();
            txtCategoryName.Text = bb.First().CategoryName.ToString();
            btnSave.Text = "Update";
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var bb = CBLL.GetCategory(0, txtCategoryName.Text.ToString());
                RptMainHead.DataSource = bb;
                RptMainHead.DataBind();
               
            }
            catch
            {

            }
        }
    }
}