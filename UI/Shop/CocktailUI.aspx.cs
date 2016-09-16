using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DTO;
using System.Data;
using PBLL.Page_ObjectBLL;
using ABLL;
using System.Web.Security;

namespace UI.Shop
{
    public partial class CocktailUI : System.Web.UI.Page
    {
        ProductBLL proBLL = new ProductBLL();
        CocktailInfoBLL cockBLL = new CocktailInfoBLL();
        CocktailInfoDTO cockDTO = new CocktailInfoDTO();
        CategoryBLL CBLL = new CategoryBLL();
        UnitBLL uniBLL = new UnitBLL();
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Cocktail Info";
                LoadCategory();
                LoadItemCategory();
                LoadUnit();
                LoadViewCategory();
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
        private void LoadCategory()
        {
            var query = CBLL.GetCategory(0, "");
            ddlCategory.DataSource = query.OrderBy(Items => Items.CategoryName);
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CatId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }
        private void LoadViewCategory()
        {
            var query = CBLL.GetCategory(0, "");
            ddlViewCategory.DataSource = query.OrderBy(Items => Items.CategoryName);
            ddlViewCategory.DataTextField = "CategoryName";
            ddlViewCategory.DataValueField = "CatId";
            ddlViewCategory.DataBind();
            ddlViewCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }
        private void LoadViewSubCategory()
        {
            var query = proBLL.GetProduct_Categorywise(int.Parse(ddlViewCategory.SelectedValue), 0);
            ddlViewSubCategory.DataSource = query;
            ddlViewSubCategory.DataTextField = "CompName";
            ddlViewSubCategory.DataValueField = "ProductId";
            ddlViewSubCategory.DataBind();
        }
        private void LoadItemCategory()
        {
            var query = CBLL.GetCategory(0, "");
            var query1 = query.Where(o => !o.CategoryName.Contains("Cocktail"));
            //  var final = query1.Except(query1);
            ddlItemCategory.DataSource = query1.OrderBy(o => o.CategoryName);
            ddlItemCategory.DataTextField = "CategoryName";
            ddlItemCategory.DataValueField = "CatId";
            ddlItemCategory.DataBind();
            ddlItemCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }
        private void LoadSubCategory()
        {
            var query = proBLL.GetProduct_Categorywise(int.Parse(ddlCategory.SelectedValue), 0);
            ddlSubCategory.DataSource = query;
            ddlSubCategory.DataTextField = "CompName";
            ddlSubCategory.DataValueField = "ProductId";
            ddlSubCategory.DataBind();
        }
        private void LoadUnit()
        {

            var query = uniBLL.GetUnit(0, "");
            ddlQuantity.DataSource = query;
            ddlQuantity.DataTextField = "UnitName";
            ddlQuantity.DataValueField = "UnitName";
            ddlQuantity.DataBind();
            ddlQuantity.Items.Insert(0, new ListItem("Select Quantity", "0"));

        }
        public static void Show(string message)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                message = message.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + message + "');", true);
            }
        }
        private void LoadItemSubCategory()
        {
            var query = proBLL.GetProduct_Categorywise(int.Parse(ddlItemCategory.SelectedValue), 0);
            ddlItemSubCategory.DataSource = query;
            ddlItemSubCategory.DataTextField = "CompName";
            ddlItemSubCategory.DataValueField = "ProductId";
            ddlItemSubCategory.DataBind();
        }
        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {

        }

        protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadSubCategory();
        }

        protected void ddlItemCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadItemSubCategory();
        }
        protected void LBPurr_Click(object sender, CommandEventArgs e)
        {

            LinkButton lb = (LinkButton)sender;
            GridViewRow gvRow = (GridViewRow)lb.NamingContainer;
            int rowID = gvRow.RowIndex;
            if (ViewState["CurrentPurData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentPurData"];
                if (dt.Rows.Count > 0)
                {
                    dt.Rows.RemoveAt(rowID);
                }
                ViewState["CurrentPurData"] = dt;
                GVPur.DataSource = dt;
                GVPur.DataBind();
                if (GVPur.Rows.Count == 0)
                {
                    //gvpurpnlAction.Visible = false;
                    GVPur.Visible = false;
                    pnlSave.Visible = false;

                }

            }
            //  AddPayable();
        }
        private void BindGrid(int rowcount)
        {
            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("ProductId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CategoryName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("CompName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("ItemProductId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("ItemCategoryName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("ItemSubCategoryName", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("Quantity", typeof(String)));


            if (ViewState["CurrentPurData"] != null)
            {
                for (int i = 0; i < rowcount + 1; i++)
                {
                    dt = (DataTable)ViewState["CurrentPurData"];
                    if (dt.Rows.Count > 0)
                    {
                        dr = dt.NewRow();
                        dr[0] = dt.Rows[0][0].ToString();
                    }
                }
                dr = dt.NewRow();
                dr[0] = ddlSubCategory.SelectedValue.ToString();
                dr[1] = ddlCategory.SelectedItem.ToString();
                dr[2] = ddlSubCategory.SelectedItem.ToString();
                dr[3] = ddlItemSubCategory.SelectedValue.ToString();
                dr[4] = ddlItemCategory.SelectedItem.ToString();
                dr[5] = ddlItemSubCategory.SelectedItem.ToString();
                dr[6] = ddlQuantity.SelectedItem.ToString();

                dt.Rows.Add(dr);

            }
            else
            {

                dr = dt.NewRow();
                dr[0] = ddlSubCategory.SelectedValue.ToString();
                dr[1] = ddlCategory.SelectedItem.ToString();
                dr[2] = ddlSubCategory.SelectedItem.ToString();
                dr[3] = ddlItemSubCategory.SelectedValue.ToString();
                dr[4] = ddlItemCategory.SelectedItem.ToString();
                dr[5] = ddlItemSubCategory.SelectedItem.ToString();
                dr[6] = ddlQuantity.SelectedItem.ToString();
                dt.Rows.Add(dr);
            }
            if (ViewState["CurrentPurData"] != null)
            {
                GVPur.DataSource = (DataTable)ViewState["CurrentPurData"];
                GVPur.DataBind();
            }
            else
            {
                GVPur.DataSource = dt;
                GVPur.DataBind();
            }
            GVPur.Visible = true;
            pnlSave.Visible = true;
            ViewState["CurrentPurData"] = dt;

            //  pnlAction.Visible = true;

        }
        protected void GVPur_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GVPur.PageIndex = e.NewPageIndex;
            if (ViewState["CurrentPurData"] != null)
            {
                GVPur.DataSource = (DataTable)ViewState["CurrentPurData"];
                GVPur.DataBind();
            }
            GVPur.DataBind();
        }
        protected void btnAdd_Click(object sender, EventArgs e)
        {
            if (ViewState["CurrentPurData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentPurData"];
                int count = dt.Rows.Count;
                BindGrid(count);
            }
            else
            {
                BindGrid(1);
            }
        }
        private void Clear()
        {
            ddlCategory.SelectedIndex = 0;
            ddlSubCategory.Items.Clear();
            ddlItemCategory.SelectedIndex = 0;
            ddlItemSubCategory.Items.Clear();

        }
        private void ClearControl()
        {
            Clear();
            GVPur.Visible = false;
            pnlSave.Visible = false;
            this.ViewState["CurrentPurData"] = null;
            DataTable dt = new DataTable();
            GVPur.DataSource = dt;
            GVPur.DataBind();
        }
        protected void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["CurrentPurData"];
            int count = dt.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                cockDTO.CocktaiProId = int.Parse(dt.Rows[i][0].ToString());
                cockDTO.ItemProId = int.Parse(dt.Rows[i][3].ToString());
                cockDTO.Quantity = double.Parse(dt.Rows[i][6].ToString());
                cockDTO.CreateBy = HttpContext.Current.User.Identity.Name;
                cockDTO.CreateDate = DateTime.Now;
                cockBLL.Add(cockDTO);
            }
            ClearControl();

            Show("Sucessfully Created");
        }
        private void pagingLoal()
        {
            try
            {
                PagedDataSource objPds = new PagedDataSource();
                if (ddlViewSubCategory.SelectedValue == "")
                    objPds.DataSource = cockBLL.GetCocktail(0, 0);
                else
                    objPds.DataSource = cockBLL.GetCocktail(int.Parse(ddlViewSubCategory.SelectedValue), 0);
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
            catch (Exception ex)
            {
                Show(ex.Message);
            }
        }
        protected void btnCancelCocktail_Click(object sender, EventArgs e)
        {

        }

        protected void ddlViewSubCategory_SelectedIndexChanged(object sender, EventArgs e)
        {

        }

        protected void ddlViewCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadViewSubCategory();
        }

        private void ClearView()
        {
            ddlViewCategory.SelectedIndex = 0;
            ddlViewSubCategory.Items.Clear();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            pagingLoal();
        }

        protected void btnViewClear_Click(object sender, EventArgs e)
        {
            ClearView();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}