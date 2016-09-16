using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using DTO;
using BLL;

namespace UI.Admin
{
    public partial class ProductUnitUI : System.Web.UI.Page
    {
        UnitBLL UBLL = new UnitBLL();
        UnitDTO UDTO = new UnitDTO();
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
            objPds.DataSource = UBLL.GetUnit(0,"");
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
            if (txtProductUnitName.Text == "")
            {
                txtProductUnitName.Focus();
                return;
            }

            UDTO.UnitName = txtProductUnitName.Text.ToString();


            UDTO.CreateDate = System.DateTime.Now;
            UDTO.CreateBy = "tarun";
            if (btnSave.Text == "Save")
            {
                UBLL.Add(UDTO);
                pagingLoal();
                clearCntrol();
            }
            else
            {
                UDTO.UnitId = Convert.ToInt32(HFUID.Value);
                UDTO.UpdateDate = System.DateTime.Now;
                UDTO.UpdateBy = "tarun";
                UBLL.Edit(UDTO);
                btnSave.Text = "Save";
                pagingLoal();
                clearCntrol();
            }

        }

        //protected void RptMainHead_ItemCommand(object source, RepeaterCommandEventArgs e)
        //{
        //    LinkButton btn = e.CommandSource as LinkButton;
        //    RepeaterItem item = btn.NamingContainer as RepeaterItem;
        //    Panel p = item.FindControl("Panel1") as Panel;
        //    p.BackColor = System.Drawing.Color.Red;
        //}
        private void clearCntrol()
        {
            txtProductUnitName.Text = "";
            pagingLoal();
            btnSave.Text = "Save";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();

        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            List<UnitDTO> bb = new List<UnitDTO>();

            bb = UBLL.GetUnit(Convert.ToInt32(e.CommandArgument.ToString()),"");
            HFUID.Value = bb.First().UnitId.ToString();
            txtProductUnitName.Text = bb.First().UnitName.ToString();
            btnSave.Text = "Update";
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var bb = UBLL.GetUnit(0, txtProductUnitName.Text.ToString());
                RptMainHead.DataSource = bb;
                RptMainHead.DataBind();

            }
            catch
            {

            }
        }

    }
}