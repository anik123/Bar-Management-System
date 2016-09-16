using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.CompProfile;
using ABLL;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.Manager
{
    public partial class SalesDetailsBranchWise : System.Web.UI.Page
    {
        InvenSalesBLL SalBLL = new InvenSalesBLL();
        BranchProfileBLL BrBLL = new BranchProfileBLL();
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Sales Details";
                branchLoad();
                loadDataGVInfo();

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
        private void branchLoad()
        {

            var query = BrBLL.LoadBrProfileInfo(0, "", "", "");
            ddlBranchName.DataSource = query.OrderBy(Items => Items.BrProName);
            ddlBranchName.DataTextField = "BrProName";
            ddlBranchName.DataValueField = "BrProId";
            ddlBranchName.DataBind();
            ddlBranchName.Items.Insert(0, new ListItem("Select Branch Name", "0"));

        }


        private void loadDataGVInfo()
        {
            var data = SalBLL.BranchWise_SalesInfoLaod(0, 0, "", "");
            GvDueInfo.DataSource = data;
            GvDueInfo.DataBind();
            LoadRowdata();
        }

        protected void GvDueInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDueInfo.PageIndex = e.NewPageIndex;
            loadDataGVInfo();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            LoadRowdata();
            Search();

        }

        protected void btnSearchCancel_Click(object sender, EventArgs e)
        {
            SearchClear();
        }
        public void SearchClear()
        {
            loadDataGVInfo();
            GvDueInfo.SelectedIndex = -1;
            ddlBranchName.SelectedValue = "0";
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            txtSalesInvoiceNo.Text = "";
            GvDueInfo.SelectedIndex = -1;
        }

        protected void txtSearch(object sender, EventArgs e)
        {
            Search();

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
            if (txtSalesInvoiceNo.Text == "" && ddlBranchName.SelectedValue == "0" && txtDateTo.Text == "" && txtDateFrom.Text == "")
            {
                Show("Search By Valid Data");
                return;
            }
            else
            {
                int salid = 0;
                if (txtSalesInvoiceNo.Text.ToString() != "")
                {
                    salid = Convert.ToInt32(txtSalesInvoiceNo.Text);
                }
                else salid = 0;



                var data = SalBLL.BranchWise_SalesInfoLaod(salid, Convert.ToInt16(ddlBranchName.SelectedValue), txtDateFrom.Text.ToString(), txtDateTo.Text.ToString());
                GvDueInfo.DataSource = data;
                GvDueInfo.DataBind();

                if (GvDueInfo.Rows.Count <= 0)
                    Show("No Data Found !");
                return;
            }
        }


        protected void LinkButton_Command_GvDueInfo_ViewDtl(object sender, CommandEventArgs e)
        {
            var bb = SalBLL.BranchWise_SalesInfoLaod(Convert.ToInt32(e.CommandArgument.ToString()), 0, "", "");
            int? SalId = bb.First().SalId;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Shop/Report/BranchSalesRptUI.aspx?SalId=" + SalId.ToString() + "');", true);
        }

        private void LoadRowdata()
        {
            double totoalPrice = 0.0;
            double paidAmount = 0.0;
            double dueAmount = 0.0;
            string str = "Total: ";
            foreach (GridViewRow row in GvDueInfo.Rows)
            {



                if (row.Cells[3].Text != "&nbsp;")
                    totoalPrice = totoalPrice + Convert.ToDouble(row.Cells[3].Text);
                if (row.Cells[4].Text != "&nbsp;")
                    paidAmount += Convert.ToDouble(row.Cells[4].Text);
                if (row.Cells[5].Text != "&nbsp;")
                    dueAmount += Convert.ToDouble(row.Cells[5].Text);

            }
            GvDueInfo.Columns[2].FooterText = Convert.ToString(str);
            GvDueInfo.Columns[3].FooterText = Convert.ToString(totoalPrice);
            GvDueInfo.Columns[4].FooterText = Convert.ToString(paidAmount);
            GvDueInfo.Columns[5].FooterText = Convert.ToString(dueAmount);
            lblTotalCalculation.Text = "Total Price: " + Convert.ToString(totoalPrice) + "|=" + ";   " + "Paid Amount: " + Convert.ToString(paidAmount) + "|=" + ";   " + " Due Amount: " + Convert.ToString(dueAmount) + "|=" + ";   ";

        }
        protected void GvDueInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            // LoadRowdata();
            //double? TotalSales = 0.0;
            //// check row type
            //if (e.Row.RowType == DataControlRowType.DataRow)
            //    // if row type is DataRow, add ProductSales value to TotalSales
            //    TotalSales += Convert.ToDouble(DataBinder.Eval(e.Row.DataItem, "TotalPrice"));
            //else if (e.Row.RowType == DataControlRowType.Footer)
            //    // If row type is footer, show calculated total value
            //    // Since this example uses sales in dollars, I formatted output as currency
            //    e.Row.Cells[3].Text = String.Format("{0:c}", TotalSales);
        }


    }
}