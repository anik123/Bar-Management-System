using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using BLL.CompProfile;
using ABLL;

namespace UI.Shop
{
    public partial class BranchSalesAmountView : System.Web.UI.Page
    {
        InvenSalesBLL SalBLL = new InvenSalesBLL();
        BranchProfileBLL BrBLL = new BranchProfileBLL();
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                GetBranchId();
                loadDataGVInfo();
                //  LoadRowdata();
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

            LoadRowdata();

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
            LoadRowdata();
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
                    LoadRowdata();
                    GvDueInfo.DataSource = data;
                    GvDueInfo.DataBind();
                   
                }

            }
        }


        protected void LinkButton_Command_GvDueInfo_ViewDtl(object sender, CommandEventArgs e)
        {
            var bb = SalBLL.BranchWise_SalesInfoLaod(Convert.ToInt32(e.CommandArgument.ToString()), 0, "", "");
            int? SalId = bb.First().SalId;
            ScriptManager.RegisterStartupScript(Page, typeof(Page), "OpenWindow", "window.open('/Shop/Report/BranchSalesRptUI.aspx?SalId=" + SalId.ToString() + "');", true);
        }

        public void LoadRowdata()
        {
            double totoalPrice = 0.0;
            double paidAmount = 0.0;
            double dueAmount = 0.0;
            string str = "Total: ";
            foreach (GridViewRow row in GvDueInfo.Rows)
            {

                totoalPrice = totoalPrice + Convert.ToDouble(row.Cells[3].Text);
                paidAmount += Convert.ToDouble(row.Cells[4].Text);
                dueAmount += Convert.ToDouble(row.Cells[5].Text);

            }
            GvDueInfo.Columns[2].FooterText = Convert.ToString(str);
            GvDueInfo.Columns[3].FooterText = Convert.ToString(totoalPrice);
            GvDueInfo.Columns[4].FooterText = Convert.ToString(paidAmount);
            GvDueInfo.Columns[5].FooterText = Convert.ToString(dueAmount);
            lblTotalCalculation.Text = "Total Price: " + Convert.ToString(totoalPrice) + "|=" + ";   " + "Paid Amount: " + Convert.ToString(paidAmount) + "|=" + ";   " + " Due Amount: " + Convert.ToString(dueAmount) + "|=" + ";   ";
        }



    }
}