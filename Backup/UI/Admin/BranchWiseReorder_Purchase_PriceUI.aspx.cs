using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DTO;
using BLL.CompProfile;

namespace UI.Admin
{
    public partial class BranchWiseReorder_Purchase_PriceUI : System.Web.UI.Page
    {
        // for log file
        Log_InventoryBLL LogBLL = new Log_InventoryBLL();
        LogInvenReorderDTO LogDTO = new LogInvenReorderDTO();


        CategoryBLL CBLL = new CategoryBLL();
        InvenReorderBLL RBLL = new InvenReorderBLL();
        // branch load
        BranchProfileBLL BrPrBLL = new BranchProfileBLL();
        InvenReorderDto RDTO = new InvenReorderDto();
        ProductBLL PBLL = new ProductBLL();
        ProductDTO PDTO = new ProductDTO();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                ///LoadProductGridView();
                LoadCategory();
                CompanyBranch();
            }
        }

        private void LoadCategory()
        {
            var query = CBLL.GetCategory(0, "");
            ddlCategory.DataSource = query;
            ddlCategory.DataTextField = "CategoryName";
            ddlCategory.DataValueField = "CatId";
            ddlCategory.DataBind();
            ddlCategory.Items.Insert(0, new ListItem("Select Category", "0"));
        }
        // load branch
        private void CompanyBranch()
        {

            var query = BrPrBLL.LoadBrProfileInfo(0, "", "", "");
            ddlBranch.DataSource = query;
            ddlBranch.DataTextField = "BrProName";
            ddlBranch.DataValueField = "BrProId";
            ddlBranch.DataBind();
            ddlBranch.Items.Insert(0, new ListItem("Select Branch", "0"));

        }
        /*Start Javascript Popup ALert*/
        public static void Show(string message)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                message = message.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + message + "');", true);
            }
        }
        //protected void ddlCategory_SelectedIndexChanged(object sender, EventArgs e)
        //{
        //    PnlGridView.Visible = true;
        //    LoadProductGridView();

        //}
        public void LoadProductGridView()
        {
            if (ddlBranch.SelectedValue == "0")
            {
                Show("Plz Selcct Brach For Search");
                return;
            }
            if (RbtTriningInfo.SelectedItem.ToString() == "New Entry")
            {
                var pp = RBLL.GetProduct_Categorywise_ReorderLevel_New(Convert.ToInt16(ddlCategory.SelectedValue), Convert.ToInt16(ddlBranch.SelectedValue));
                if (pp.Count != 0)
                {
                    PnlAction.Visible = true;
                }
                else
                {
                    PnlAction.Visible = false;
                    Show("No New Data Reorder Record");
                }
                GvUpdate.DataSource = pp;
                GvUpdate.DataBind();
            }
            else
            {
                var pp = RBLL.GetProduct_Categorywise_ReorderLevel_Update(Convert.ToInt16(ddlCategory.SelectedValue), Convert.ToInt16(ddlBranch.SelectedValue));
                if (pp.Count != 0)
                {
                    PnlAction.Visible = true;
                }
                else
                {
                    PnlAction.Visible = false;
                    Show(" No Data Found !");
                }
                GvUpdate.DataSource = pp;
                GvUpdate.DataBind();
            }
        }

        protected void GvUpdate_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvUpdate.PageIndex = e.NewPageIndex;
            LoadProductGridView();
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ClearControl();
        }

        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ddlBranch.SelectedValue == "0")
            {
                Show("Plz Select Branch");
                return;
            }
            int blankcount = 0;
            foreach (GridViewRow row in GvUpdate.Rows)
            {

                TextBox txt = (TextBox)row.FindControl("txtReorderValue");
                string data = txt.Text;

                if (data == "")
                {
                    blankcount = blankcount + 1;

                }
            }

            if (blankcount > 0)
            {
                Show(" Plz Insert Reorder Quantity");
                return;
            }

            else
            {
                foreach (GridViewRow row in GvUpdate.Rows)
                {
                    RDTO.ProductId = Convert.ToInt32(row.Cells[3].Text);
                    RDTO.BrProId = Convert.ToInt16(ddlBranch.SelectedValue);
                    TextBox txtreorder = (TextBox)row.FindControl("txtReorderValue");
                    RDTO.ReorderValue = Convert.ToInt16(txtreorder.Text);
                    RDTO.PurRequisitonStatus = "0";
                    TextBox txtRate = (TextBox)row.FindControl("txtRateOfInterest");
                    RDTO.RateOfInterest = Convert.ToDouble(txtRate.Text);

                    if (btnSave.Text == "Save")
                    {
                        RDTO.Createdate = System.DateTime.Now;
                        RDTO.CreateBy = "tarun";
                        RBLL.Add(RDTO);

                        Show("Data Save Successfully ");
                        return;
                    }
                    else
                    {


                        // start log insert
                        string Logfield = "";
                        var pp = RBLL.GetProduct_Categorywise_ReorderLevel_Update(Convert.ToInt16(ddlBranch.SelectedValue), Convert.ToInt16(ddlCategory.SelectedValue));
                        Logfield = "ReorderId-" + row.Cells[7].Text + ";" + "Branch-" + pp.First().BrProName + ";" + "Product-" + pp.First().ProductName.ToString() + ";" + " Reorder Value-" + pp.First().ReorderValue.ToString() + "#" + txtreorder.Text + ";" + " Sales Interest Rate-" + pp.First().RateOfInterest + "#" + txtRate.Text + ";";
                        LogDTO.LogField = Logfield;
                        LogDTO.LogBy = HttpContext.Current.User.Identity.Name;
                        LogDTO.LogDate = System.DateTime.Now;
                        LogBLL.Add_Reorder_BranchWise_Log(LogDTO);
                        // end log insert

                        RDTO.ReorderId = Convert.ToInt32(row.Cells[7].Text);
                        RDTO.UpdateDate = System.DateTime.Now;
                        RDTO.UpdateBy = "tarun";
                        RBLL.Edit(RDTO);
                        Show("Data Update Successfully ");
                        return;

                    }
                }
            }
            ClearControl();
        }
        protected void RbtTriningInfo_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (RbtTriningInfo.SelectedItem.ToString() == "Update ")
            {
                btnSave.Text = "Update";
            }
            else
            {
                btnSave.Text = "Save";
                ClearControl();
            }

        }
        public void ClearControl()
        {
            ddlBranch.SelectedValue = "0";
            ddlCategory.SelectedValue = "0";
            PnlGridView.Visible = false;
            PnlAction.Visible = false;
        }

        protected void btnSearch_Click(object sender, EventArgs e)
        {
            PnlGridView.Visible = true;
            LoadProductGridView();
        }

        protected void btnSearchCancel_Click(object sender, EventArgs e)
        {
            ddlBranch.SelectedValue = "0";
            ddlCategory.SelectedValue = "0";
            LoadProductGridView();
            PnlAction.Visible = false;
            PnlGridView.Visible = false;
        }
    }
}