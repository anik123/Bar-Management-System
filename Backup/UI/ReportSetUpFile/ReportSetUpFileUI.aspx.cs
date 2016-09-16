using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace UI.ReportSetUpFile
{
    public partial class ReportSetUpFileUI : System.Web.UI.Page
    {
        protected void Page_Load(object sender, EventArgs e)
        {

        }

        protected void btnBankAccount_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportSetUpFile/BankAccountInfoRptUI.aspx");
        }

        protected void btnBranchList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportSetUpFile/CompanyBranchListRptUI.aspx");
        }

        protected void btnClientCompanyList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportSetUpFile/ClientCompanyListRptUI.aspx");
        }

        protected void btnProductList_Click(object sender, EventArgs e)
        {
            Response.Redirect("~/ReportSetUpFile/ProductListRptUI.aspx");

        }
    }
}