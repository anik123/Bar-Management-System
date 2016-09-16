using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using DTO;
using System.Data;
using ABLL;
using PBLL.Page_ObjectBLL;
using System.Web.Security;

namespace UI.Shop
{
    public partial class DuePaymentUI : System.Web.UI.Page
    {
        MemberBLL memBLL = new MemberBLL();
        InvenSalesBLL SaleBLL = new InvenSalesBLL();
        InvenSalesInfoDto SalInfoDTO = new InvenSalesInfoDto();
        InvenSalesDtlDto SaldtlDTO = new InvenSalesDtlDto();
        InvenSalesPaymentDto SalPayDTO = new InvenSalesPaymentDto();
        InvenSalePaymentDtlDto SalpayDtlDTO = new InvenSalePaymentDtlDto();
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();
        protected void Page_Load(object sender, EventArgs e)
        {
            string strProcessScript = "this.value='Processing...';this.disabled=true;";
            btnPrint.Attributes.Add("onclick", strProcessScript + ClientScript.GetPostBackEventReference(btnPrint, "").ToString());
            if (!Page.IsPostBack)
            {
                SearchMember();
                LoadMember();
                RoleName();
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
        private void ClearSearch()
        {
            txtMemno.Text = "";
            txtMemName.Text = "";
            txtMobileNo.Text = "";
        }
        protected void GVMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GVMember.PageIndex = e.NewPageIndex;
            SearchMember();

        }
        void SearchMember()
        {

            
            var data= memBLL.GetDueMemeberList(txtMemno.Text, txtMemName.Text, txtMobileNo.Text,ddlSMemType.SelectedValue);

            GVMember.DataSource = data;
            GVMember.DataBind();
            // ddlMember.SelectedValue=
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
                    pnlAction.Visible = false;

                }
            }
        }
        protected void LinkButton_Inovice(object sender, CommandEventArgs e)
        {

            ScriptManager.RegisterStartupScript(Page, typeof(Page),
                "OpenWindow", "window.open('/Shop/Report/BranchSalesRptUI.aspx?SalId=" + e.CommandArgument.ToString() + "');", true);
        }
        private void LoadMember()
        {
            var data = memBLL.GetMember("", "", "","",0);
            ddlMember.DataSource = data.ToList().Distinct();
            ddlMember.DataTextField = "SellFullName";
            ddlMember.DataValueField = "MemberId";
            ddlMember.DataBind();
            ddlMember.Items.Insert(0, new ListItem("Select Member", "0"));
        }
        protected void LinkButton_Dueload(object sender, CommandEventArgs e)
        {
            var data = SaleBLL.LoadMemberDue(0, 0, int.Parse(e.CommandArgument.ToString()));
            txtDueAmount.Text = data.First().DueAmount.ToString();
            txtDueDate.Text = data.First().CreateDate.Date.ToShortDateString();
            HFPaymentId.Value = e.CommandArgument.ToString();
            txtPaidAmount.Text = data.First().PaidAmount.ToString();
            //txtPaidAmount.Text = HFPaymentId.Value;
        }
        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            // Show(e.CommandArgument.ToString());
            var data = SaleBLL.LoadMemberDue(int.Parse(e.CommandArgument.ToString()), 0, 0);
            
            if (data.Count() > 0)
            {
                ddlMember.SelectedValue = e.CommandArgument.ToString();
                PagedDataSource objPds = new PagedDataSource();
                objPds.DataSource = data;
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

                RptPayment.DataSource = objPds;
                RptPayment.DataBind();
                pnlSale.Visible = true;
            }
            else
            {
                Show("No Unpaid Bill!");
            }
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

        protected void BtnSearch_Click(object sender, EventArgs e)
        {
            SearchMember();
        }

        protected void btnSearchClear_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }
        private void BindGrid(int rowcount)
        {

            DataTable dt = new DataTable();
            DataRow dr;
            dt.Columns.Add(new System.Data.DataColumn("SalePaymentId", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("DueAmount", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("PaidAmount", typeof(String)));

            dt.Columns.Add(new System.Data.DataColumn("DueDate", typeof(String)));
            dt.Columns.Add(new System.Data.DataColumn("ReturnAmount", typeof(String)));
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
                dr[0] = HFPaymentId.Value;
                dr[1] = txtDueAmount.Text;
                dr[2] = txtPaidAmount.Text;
                dr[3] = txtDueDate.Text;
                dr[4] = txtReturn.Text;
                dt.Rows.Add(dr);

            }
            else
            {

                dr = dt.NewRow();
                //        dr[0] = ddlPName.SelectedValue.ToString();
                //        dr[1] = ddlPName.SelectedItem.ToString();
                dr[0] = HFPaymentId.Value;
                dr[1] = txtDueAmount.Text;
                dr[2] = txtPaidAmount.Text;
                dr[3] = txtDueDate.Text;
                dr[4] = txtReturn.Text;
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
            ViewState["CurrentPurData"] = dt;

            pnlAction.Visible = true;
            ControlClear();
        }
        protected void btnSave_Click(object sender, EventArgs e)
        {
            if (ViewState["CurrentPurData"] != null)
            {
                DataTable dt = (DataTable)ViewState["CurrentPurData"];
                int count = dt.Rows.Count;

                for (int i = 0; i < count; i++)
                {
                    /*
                    if (Convert.ToInt32(ddlPName.SelectedValue.ToString()) == Convert.ToInt32(dt.Rows[i][0].ToString()))
                    {
                        Show("Product Already Inserted  !");
                        return;
                    }
                     */
                }
                BindGrid(count);
            }
            else
            {
                BindGrid(1);
            }

        }

        protected void btnPrint_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)ViewState["CurrentPurData"];
            int count = dt.Rows.Count;
            for (int i = 0; i < count; i++)
            {
                SalPayDTO.SalePaymentId = int.Parse(dt.Rows[i][0].ToString());
                SalPayDTO.PaidAmount = double.Parse(dt.Rows[i][2].ToString()) + double.Parse(dt.Rows[i][4].ToString());
                SalPayDTO.DueAmount = double.Parse(dt.Rows[i][1].ToString()) - double.Parse(dt.Rows[i][4].ToString());
                SaleBLL.Edit_Salespayment(SalPayDTO);
            }
            Show("Sucessfully Paid!");
            ClearAll();
        }
        void ControlClear()
        {
            ddlMember.SelectedIndex = 0;
            txtDueAmount.Text = "";
            txtDueDate.Text = "";
            txtPaidAmount.Text = "";
            txtReturn.Text = "";
        }

        protected void btnCancel_Click(object sender, EventArgs e)
        {
            ControlClear();
        }
        public void ClearAll()
        {
            ControlClear();
            this.ViewState["CurrentPurData"] = null;
            DataTable dt = new DataTable();
            GVPur.DataSource = dt;
            GVPur.DataBind();
            pnlAction.Visible = false;
        }

        protected void btnCancelPurchase_Click(object sender, EventArgs e)
        {
            ClearAll();
        }




    }

}