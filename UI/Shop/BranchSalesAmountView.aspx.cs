using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.CompProfile;
using ABLL;
using System.Web.Security;
using PBLL.Page_ObjectBLL;

namespace UI.Shop
{
    public partial class BranchSalesAmountView : System.Web.UI.Page
    {
        InvenSalesBLL SalBLL = new InvenSalesBLL();
        BranchProfileBLL BrBLL = new BranchProfileBLL();
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();
        decimal grdTotal = 0;
        decimal grdPaidTotal = 0;
        decimal grdDueTotal = 0;

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                RoleName();
                Page.Title = "Sales Details";
                GetBranchId();
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
        protected void GetBranchId()
        {
            string empusername = HttpContext.Current.User.Identity.Name;
            var brid = empBLL.GetCurrentUserBranchName(empusername);

            HFBranceId.Value = brid.First().BrProId.ToString();
        }



        public void loadDataGVInfo()
        {
            var data = SalBLL.BranchWise_SalesInfoLaod(0, Convert.ToInt32(HFBranceId.Value), "", "");
            GvDueInfo.DataSource = data;
            GvDueInfo.DataBind();

            LoadRowdata(data.Count());

        }

        protected void GvDueInfo_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            GvDueInfo.PageIndex = e.NewPageIndex;
            loadDataGVInfo();
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            
            Search();


        }

        protected void btnSearchCancel_Click(object sender, EventArgs e)
        {
            Clear();
            var data = SalBLL.BranchWise_SalesInfoLaod(0, Convert.ToInt16(HFBranceId.Value), "", "");
            LoadRowdata(data.Count());
        }
        protected void Clear()
        {

            GvDueInfo.SelectedIndex = -1;
            txtDateFrom.Text = "";
            txtDateTo.Text = "";
            txtSalesInvoiceNo.Text = "";
            GvDueInfo.SelectedIndex = -1;
            //if (txtDateFrom.Text != "")
            //{
            //    txtDateFrom.Text = "";
            //}
            //else
            //{

            loadDataGVInfo();
            // }
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
        protected void Search()
        {
            if (txtSalesInvoiceNo.Text == "" && txtDateTo.Text == "" && txtDateFrom.Text == "")
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



                var data = SalBLL.BranchWise_SalesInfoLaod(salid, Convert.ToInt16(HFBranceId.Value), txtDateFrom.Text.ToString(), txtDateTo.Text.ToString());

                if (data.Count == 0)
                {
                    Show("No Data Found !");
                    return;
                }
                else
                {
                    
                   
                    GvDueInfo.DataSource = data;
                    GvDueInfo.DataBind();
                    int cnt = data.Count();
                    LoadRowdata(cnt);

                }

            }
        }


        protected void LinkButton_Command_GvDueInfo_ViewDtl(object sender, CommandEventArgs e)
        {
            var bb = SalBLL.BranchWise_SalesInfoLaod(Convert.ToInt32(e.CommandArgument.ToString()), 0, "", "");
            int? SalId = bb.First().SalId;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Shop/Report/BranchSalesRptUI.aspx?SalId=" + SalId.ToString() + "');", true);
        }

        public void LoadRowdata(int count)
        {
            double totoalPrice = 0.0;
            double paidAmount = 0.0;
            double dueAmount = 0.0;
          //  string str = "Total: ";
            for (int i = 0; i < count; i++)
            {

                totoalPrice = totoalPrice + Convert.ToDouble(GvDueInfo.Rows[i].Cells[3].Text);
                  paidAmount += Convert.ToDouble(GvDueInfo.Rows[i].Cells[4].Text);
                dueAmount += Convert.ToDouble(GvDueInfo.Rows[i].Cells[5].Text);

            }
            //GvDueInfo.Columns[2].FooterText = Convert.ToString(str);
           // GvDueInfo.Columns[3].FooterText = Convert.ToString(totoalPrice);
            //GvDueInfo.Columns[4].FooterText = Convert.ToString(paidAmount);
            //GvDueInfo.Columns[5].FooterText = Convert.ToString(dueAmount);
            //lblTotalCalculation.Text = "Total Price: " + Convert.ToString(totoalPrice) + "|=" + ";   " + "Paid Amount: " + Convert.ToString(paidAmount) + "|=" + ";   " + " Due Amount: " + Convert.ToString(dueAmount) + "|=" + ";   ";
        }

        protected void GvDueInfo_RowDataBound(object sender, GridViewRowEventArgs e)
        {
            
                     if (e.Row.RowType == DataControlRowType.DataRow)
                     {
                         decimal rowTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "TotalPrice"));
                         grdTotal = grdTotal + rowTotal;

                         decimal rowPaidTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "PaidAmount"));
                         grdPaidTotal = grdPaidTotal + rowPaidTotal;

                         decimal rowDueTotal = Convert.ToDecimal(DataBinder.Eval(e.Row.DataItem, "DueAmount"));
                         grdDueTotal = grdDueTotal + rowDueTotal;



                         
                     }

                     GvDueInfo.Columns[3].FooterText = grdTotal.ToString();
                     GvDueInfo.Columns[2].FooterText = "Total";
                     GvDueInfo.Columns[4].FooterText = grdPaidTotal.ToString();
                     GvDueInfo.Columns[5].FooterText = grdDueTotal.ToString();


                 //if (e.Row.RowType == DataControlRowType.Footer)
                 //   {
                 //       if (grdTotal != null)
                 //       {
                            
                 //           GvDueInfo.Columns[3].FooterText =Convert.ToString(grdTotal);
                 //       }
                 //   }
               }



    }
}