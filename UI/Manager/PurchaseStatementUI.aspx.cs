using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using System.Web.Security;
using ABLL;
using PBLL.Page_ObjectBLL;

namespace UI.Manager
{
    public partial class PurchaseStatementUI : System.Web.UI.Page
    {
        InvenCentralPurchseBLL PurBLL = new InvenCentralPurchseBLL();
        CompanyBLL CompBLL = new CompanyBLL();
       LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
               // RoleName();
                if (!Page.IsPostBack)
                {
                    Page.Title = " Purchase Statement";
                    CompanyName();
                    loadDataGVInfo();

                }
                LoadRowdata();
            }
        }
        //public void RoleName()
        //{

        //    string empusername = HttpContext.Current.User.Identity.Name;

        //    var role = LBLL.GetRoleName_By_User(empusername);
        //    int roleid = role.First().RoleId;

        //    var loadPage = PObjRoleBLL.Page_ObjectRole(0, roleid, "", "");
        //    int count = loadPage.Count;

        //    int matcheddata = 0;
        //    for (int i = 0; i < count; i++)
        //    {
        //        if (HttpContext.Current.Request.Url.AbsolutePath == loadPage[i].PagePath.ToString())
        //        {
        //            matcheddata = matcheddata + 1;
        //        }
        //    }
        //    if (matcheddata == 1)
        //    {
        //    }
        //    else
        //    {
        //        FormsAuthenticationTicket ticket1 = new FormsAuthenticationTicket("", true, 0);
        //        string hash1 = FormsAuthentication.Encrypt(ticket1);
        //        HttpCookie cookie1 = new HttpCookie(FormsAuthentication.FormsCookieName, hash1);
        //        cookie1.Expires = DateTime.Now.AddMinutes(0);

        //        if (ticket1.IsPersistent)
        //            cookie1.Expires = ticket1.Expiration;

        //        Response.Cookies.Add(cookie1);
        //       // Response.Redirect(" LoginUI.aspx");
        //    }
        //}
        private void CompanyName()
        {

            var query = CompBLL.SearchComInfo(0, "", "", "");
            ddlcompany.DataSource = query.OrderBy(Items => Items.CompName);
            ddlcompany.DataTextField = "CompName";
            ddlcompany.DataValueField = "CompId";
            ddlcompany.DataBind();
            ddlcompany.Items.Insert(0, new ListItem("Select Company Name", "0"));

        }


        private void loadDataGVInfo()
        {
            var data = PurBLL.PurchaseStatementLaod(0, 0, "", "");
            GvDueInfo.DataSource = data;
            GvDueInfo.DataBind();

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
            ddlcompany.SelectedValue = "0";
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            txtPurchaseInvoiceNo.Text = "";
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
            if (txtPurchaseInvoiceNo.Text == "" && ddlcompany.SelectedValue == "0" && txtDateTo.Text == "" && txtDateFrom.Text == "")
            {
                Show("Search By Valid Data");
                return;
            }
            else
            {
                int salid = 0;
                if (txtPurchaseInvoiceNo.Text.ToString() != "")
                {
                    salid = Convert.ToInt32(txtPurchaseInvoiceNo.Text);
                }
                else salid = 0;



                var data = PurBLL.PurchaseStatementLaod(salid, Convert.ToInt16(ddlcompany.SelectedValue), txtDateFrom.Text.ToString(), txtDateTo.Text.ToString());
                GvDueInfo.DataSource = data;
                GvDueInfo.DataBind();

                if (GvDueInfo.Rows.Count <= 0)
                    Show("No Data Found !");
                return;
            }
        }
        protected void LinkButton_Command_GvDueInfo_ViewDtl(object sender, CommandEventArgs e)
        {
            int purid;

            var bb = PurBLL.PurchaseStatementLaod(Convert.ToInt32(e.CommandArgument.ToString()), 0, "", "");
            purid = Convert.ToInt32(bb.First().PurId.ToString());
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Manager/PurchasePaymaentDetailViewUI.aspx?purid=" + purid.ToString() + "');", true);
        }
        protected void LinkButton_Command_GvDueInfo_ProductInfo(object sender, CommandEventArgs e)
        {
            var bb = PurBLL.PurchaseStatementLaod(Convert.ToInt32(e.CommandArgument.ToString()), 0, "", "");
            int PurId = bb.First().PurId;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Manager/Report/PurchaseProductRptUI.aspx?PurId=" + PurId.ToString() + "');", true);
        }

        private void LoadRowdata()
        {
            double totoalPrice = 0.0;
            double paidAmount = 0.0;
            double dueAmount = 0.0;
            string str = "Total: ";

            foreach (GridViewRow row in GvDueInfo.Rows)
            {
                if (row.Cells[4].Text != "&nbsp;")
                    totoalPrice = totoalPrice + Convert.ToDouble(row.Cells[4].Text);
                if (row.Cells[5].Text != "&nbsp;")
                    paidAmount += Convert.ToDouble(row.Cells[5].Text);
                if (row.Cells[6].Text != "&nbsp;")
                    dueAmount += Convert.ToDouble(row.Cells[6].Text);

            }
            GvDueInfo.Columns[3].FooterText = Convert.ToString(str);
            GvDueInfo.Columns[4].FooterText = Convert.ToString(totoalPrice);
            GvDueInfo.Columns[5].FooterText = Convert.ToString(paidAmount);
            GvDueInfo.Columns[6].FooterText = Convert.ToString(dueAmount);
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