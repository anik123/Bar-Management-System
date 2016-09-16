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
    public partial class ProductUI : System.Web.UI.Page
    {
        CategoryBLL CBLL = new CategoryBLL();
        CategoryDTO CDTO = new CategoryDTO();

        UnitDTO UDTO = new UnitDTO();
        UnitBLL UBLL = new UnitBLL();

        ProductDTO PDTO = new ProductDTO();
        ProductBLL PBLL = new ProductBLL();

        CompanyBLL CompBLL = new CompanyBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                pagingLoal();
                LoadCategory();
                LoadUnit();
                loadCompany();
            }
        }
        private void LoadCategory()
        {
            var query = CBLL.GetCategory(0, "");
            ddlCategory.DataSource = query.OrderBy(Items => Items.CategoryName);
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CatId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }
        private void LoadUnit()
        {
            var query = UBLL.GetUnit(0, "");
            ddlUnit.DataSource = query.OrderBy(Items => Items.UnitName);
            ddlUnit.DataTextField = "UnitName";
            ddlUnit.DataValueField = "UnitId";
            ddlUnit.DataBind();
            ddlUnit.Items.Insert(0, new ListItem("Select Unit", "0"));
        }
        private void loadCompany()
        {
            var query = CompBLL.SearchComInfo(0, "", "", "");
            ddlCompany.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCompany.DataTextField = "CompName";
            ddlCompany.DataValueField = "CompId";
            ddlCompany.DataBind();
            ddlCompany.Items.Insert(0, new ListItem("Select Company", "0"));
        }

        private void pagingLoal()
        {

            PagedDataSource objPds = new PagedDataSource();
            objPds.DataSource = PBLL.GetProduct(0, "", 0, 0, 0);
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
            if (txtProductName.Text == "")
            {
                txtProductName.Focus();
                return;
            }
            PDTO.ProductName = txtProductName.Text.ToString();
            PDTO.CategoryId = Convert.ToInt16(ddlCategory.SelectedValue);
            PDTO.UnitId = Convert.ToInt16(ddlUnit.SelectedValue);
            PDTO.CompId = Convert.ToInt16(ddlCompany.SelectedValue);
            PDTO.CenterReorderValue = Convert.ToInt32(txtCenterReorderQuantity.Text);
            PDTO.CreateDate = System.DateTime.Now;
            PDTO.CreateBy = "tarun";
            if (btnSave.Text == "Save")
            {

                PBLL.Add(PDTO);
                pagingLoal();
                clearCntrol();
                // barcode
                var data = PBLL.GetProduct(0, "", 0, 0, 0);
                string productid = data.First().ProductId.ToString();
                txtProductBarCode.Text = productid;
                if (txtProductBarCode.Text != "")
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "key", "launchModal();", true);

            }
            else
            {
                PDTO.ProductId = Convert.ToInt32(HFUID.Value);

                PBLL.Edit(PDTO);
                btnSave.Text = "Save";
                pagingLoal();
                clearCntrol();
                // barcode
                // for barcode popup
                string Empid = Convert.ToString(HFUID.Value);
                txtProductBarCode.Text = Empid;
                if (txtProductBarCode.Text != "")
                    ScriptManager.RegisterClientScriptBlock(Page, this.GetType(), "key", "launchModal();", true);
            }

        }


        private void clearCntrol()
        {
            txtProductName.Text = "";
            ddlCategory.SelectedValue = "0";
            ddlCompany.SelectedValue = "0";
            ddlUnit.SelectedValue = "0";
            pagingLoal();
            txtCenterReorderQuantity.Text = "";
            btnSave.Text = "Save";
        }
        protected void btnCancel_Click(object sender, EventArgs e)
        {
            clearCntrol();

        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            var bb = PBLL.GetProduct(Convert.ToInt32(e.CommandArgument.ToString()), "", 0, 0, 0);
            HFUID.Value = bb.First().ProductId.ToString();
            txtProductName.Text = bb.First().ProductName.ToString();
            ddlUnit.SelectedValue = bb.First().UnitId.ToString();
            ddlCategory.SelectedValue = bb.First().CategoryId.ToString();
            ddlCompany.SelectedValue = bb.First().CompId.ToString();
            txtCenterReorderQuantity.Text = bb.First().CenterReorderValue.ToString();
            btnSave.Text = "Update";
        }

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            try
            {
                var bb = PBLL.GetProduct(0, txtProductName.Text.ToString(), Convert.ToInt16(ddlCategory.SelectedValue), Convert.ToInt16(ddlUnit.SelectedValue), 0);
                RptMainHead.DataSource = bb;
                RptMainHead.DataBind();

            }
            catch
            {

            }
        }
    }
}