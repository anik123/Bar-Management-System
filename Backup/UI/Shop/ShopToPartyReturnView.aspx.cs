using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ABLL;

namespace UI.Shop
{
    public partial class ShopToPartyReturnView : System.Web.UI.Page
    {
        InvenBranchReturnBLL BrBLL = new InvenBranchReturnBLL();
        CompanyBLL CompBLL = new CompanyBLL();
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetBranchId();
                loadCompany();
                LoadNeedToReturn();


            }
        }
        public void GetBranchId()
        {
            string empusername = HttpContext.Current.User.Identity.Name;
            var brid = empBLL.GetCurrentUserBranchName(empusername);

            HFBranceId.Value = brid.First().BrProId.ToString();
        }

        private void loadCompany()
        {
            var query = CompBLL.SearchComInfo(0, "", "", "");
            ddlCName_S.DataSource = query.OrderBy(Items => Items.CompName);
            ddlCName_S.DataTextField = "CompName";
            ddlCName_S.DataValueField = "CompId";
            ddlCName_S.DataBind();
            ddlCName_S.Items.Insert(0, new ListItem("Select Company", "0"));
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
        public void Search()
        {

            if (ddlCName_S.SelectedValue == "0" && txtReturnNo.Text == "" && txtDateTo.Text == "" && txtDateFrom.Text == "")
            {
                Show("Search By Valid Data");
            }
            else
            {
                int returnno = 0;
                if (txtReturnNo.Text.ToString() != "")
                {
                    returnno = Convert.ToInt32(txtReturnNo.Text);
                }
                else returnno = 0;
                var collection = BrBLL.Return_Branch_To_Central_ProductRpt_Detail(Convert.ToInt16(HFBranceId.Value), returnno, Convert.ToInt16(ddlCName_S.SelectedValue), txtDateFrom.Text.ToString(), txtDateTo.Text.ToString());
                if (collection.Count == 0)
                {
                    Show("No Data Found !");
                    return;
                }
                GVCOA.DataSource = collection;
                GVCOA.DataBind();
                LoadOtherEntity();
            }
        }
        public void LoadNeedToReturn()
        {

            var data = BrBLL.Return_Branch_To_Central_ProductRpt_Detail(Convert.ToInt16(HFBranceId.Value), 0, 0, "", "");
            GVCOA.DataSource = data;
            GVCOA.DataBind();
            LoadOtherEntity();
        }
        // for rpt payment status
        public void LoadOtherEntity()
        {
            foreach (GridViewRow row in GVCOA.Rows)
            {
                var Rptstatus = BrBLL.Branchwise_Return_ProductRpt(Convert.ToInt32(row.Cells[0].Text));
                row.Cells[1].Text = Rptstatus.First().CompName;
                row.Cells[2].Text = Rptstatus.First().ReturnDate.ToShortDateString();
            }
        }
        protected void GVCOA_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GVCOA.PageIndex = e.NewPageIndex;
            LoadNeedToReturn();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            Search();
        }

        protected void btnSearchCancel_Click(object sender, EventArgs e)
        {
            GVCOA.SelectedIndex = -1;
            txtDateTo.Text = "";
            txtDateFrom.Text = "";
            txtReturnNo.Text = "";
            ddlCName_S.SelectedValue = "0";
            LoadNeedToReturn();
        }

        protected void GVCOA_SelectedIndexChanged(object sender, EventArgs e)
        {
            int ReturnNo = Convert.ToInt32(GVCOA.DataKeys[GVCOA.SelectedIndex].Values["ReturnNo"].ToString());
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Shop/Report/BranchReturnProductRptUI.aspx?retunno=" + ReturnNo.ToString() + "');", true);

        }
    }
}