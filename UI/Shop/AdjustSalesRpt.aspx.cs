using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using BLL;
using ABLL;
using PBLL.Page_ObjectBLL;
using DTO;
using System.Web.Security;

namespace UI.Shop
{
    public partial class AdjustSalesRpt : System.Web.UI.Page
    {
        MemberBLL memBLL = new MemberBLL();
        InvenSalesBLL SaleBLL = new InvenSalesBLL();
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();
        InvenSalesPaymentDto SaleDTO = new InvenSalesPaymentDto();
        InvenSalePaymentDtlDto SaleDtlDTO = new InvenSalePaymentDtlDto();
        CocktailInfoBLL cockBLL = new CocktailInfoBLL();
        InvenCentralStoreStatusDTO SDTO = new InvenCentralStoreStatusDTO();
        InvenCentralStoreStatusBLL SBLL = new InvenCentralStoreStatusBLL();
        //Report
        InvenSalesDetailBLL DetailBLL = new InvenSalesDetailBLL();
        InvenSalesDetailDTO DetailDTO = new InvenSalesDetailDTO();
        ProductBLL PBLL = new ProductBLL();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                SearchPagload();
                RoleName();
            }
        }

        private void RoleName()
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
        public static void Show(string message)
        {
            Page page = HttpContext.Current.Handler as Page;
            if (page != null)
            {
                message = message.Replace("'", "\'");
                ScriptManager.RegisterStartupScript(page, page.GetType(), "err_msg", "alert('" + message + "');", true);
            }
        }
        protected void GVPur_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GVPur.PageIndex = e.NewPageIndex;
            SearchPagload();

        }
        private void SearchPagload()
        {

            var data = memBLL.GetActiveMemeberList(txtContactAdd.Text, txtCustomerName.Text, txtMobileNo.Text, ddlSMemType.SelectedValue);
            if (data.Count > 0)
            {
                GVPur.DataSource = data;
                GVPur.DataBind();
            }
            else
                Show("No data found!");
        }

        protected void LinkButton_Command(object sender, CommandEventArgs e)
        {
            var data = SaleBLL.LoadActiveMember(int.Parse(e.CommandArgument.ToString()), 0, 0);
            if (data.Count > 0)
            {
                HFMemberId.Value = e.CommandArgument.ToString();
                // ddlMember.SelectedValue = e.CommandArgument.ToString();
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
                lblCurrentPagePayment.Text = "Page: " + CurPage.ToString();

                if (!objPds.IsFirstPage)
                    lnkPrevPayment.NavigateUrl = Request.CurrentExecutionFilePath
                    + "?Page=" + Convert.ToString(CurPage - 1);

                if (!objPds.IsLastPage)
                    lnkNextPayment.NavigateUrl = Request.CurrentExecutionFilePath
                    + "?Page=" + Convert.ToString(CurPage + 1);

                RptPayment.DataSource = objPds;
                RptPayment.DataBind();
                pnlSale.Visible = true;
            }
            else
            {
                Show("No Activity!");
            }
        }
        protected void LinkButton_Inovice(object sender, CommandEventArgs e)
        {
            var data = SaleBLL.BranchWise_SalesInfoLaod_ChangeProduct(int.Parse(e.CommandArgument.ToString()), 0, "", "", "", "", "");
            if (data.Count > 0)
            {
                //  HFMemberId.Value = e.CommandArgument.ToString();
                // ddlMember.SelectedValue = e.CommandArgument.ToString();
                HFDate.Value = data.First().CreateDate.ToShortDateString();
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
                lblCurrentProduct.Text = "Page: " + CurPage.ToString();

                if (!objPds.IsFirstPage)
                    lnkPrevProduct.NavigateUrl = Request.CurrentExecutionFilePath
                    + "?Page=" + Convert.ToString(CurPage - 1);

                if (!objPds.IsLastPage)
                    lnkNextProduct.NavigateUrl = Request.CurrentExecutionFilePath
                    + "?Page=" + Convert.ToString(CurPage + 1);

                RptProduct.DataSource = objPds;
                RptProduct.DataBind();
                pnlProduct.Visible = true;
            }
            else
                Show("No data!");
        }
        protected void LinkButton_Product(object sender, CommandEventArgs e)
        {
            var data = SaleBLL.DeleteAdjustment(int.Parse(e.CommandArgument.ToString()));
            var Quantity = SBLL.LoadCentralStockStatus(data.First().ProductId);
            var pro = PBLL.GetProduct(data.First().ProductId, "", 0, 0, 0);
            if (Quantity.Count > 0 || pro.First().CategoryName.ToLower().Contains("cockt"))
            {

                // HFCompId.Value = Quantity.First().CompId.ToString();
                /// var tempdata = tempBLL.GetAllByTempId(int.Parse(dt.Rows[rowID][11].ToString()));

                var cock = cockBLL.GetCocktail(Convert.ToInt32(data.First().ProductId), 0);
                if (cock.Count > 0)
                {

                    for (int j = 0; j < cock.Count; j++)
                    {
                        var Quantity1 = SBLL.LoadCentralStockStatus(int.Parse(cock[j].ItemProId.ToString()));
                        SDTO.CentralStoreId = Quantity1.First().CentralStoreId;
                        SDTO.ProductId = Convert.ToInt32(cock[j].ItemProId.ToString());
                        SDTO.QuantityStore = Convert.ToDouble(Quantity1.First().QuantityStore + Convert.ToDouble(cock[j].Quantity));
                        if (!string.IsNullOrEmpty(HFDate.Value))
                        {

                            var detail = DetailBLL.GetdtlId(Convert.ToInt32(cock[j].ItemProId.ToString()), DateTime.Parse(HFDate.Value).ToShortDateString());
                            if (detail.Count > 0)
                            {
                                DetailDTO.DtlId = detail.First().DtlId;
                                DetailDTO.ProductId = detail.First().ProductId;
                                DetailDTO.UsedQuantity = detail.First().UsedQuantity - (Convert.ToDouble(cock[j].Quantity * data.First().Quantity));
                               // DetailDTO.TotalQuantity=detail.First().TotalQuantity+(Convert.ToDouble(cock[j].Quantity * data.First().Quantity));
                                DetailDTO.RemainingQuantity = Convert.ToDouble(Quantity1.First().QuantityStore + (Convert.ToDouble(cock[j].Quantity * data.First().Quantity)));
                                DetailBLL.Edit(DetailDTO);
                            }
                            var detailAfter = DetailBLL.GetdtlIdAfter(Convert.ToInt32(cock[j].ItemProId.ToString()), DateTime.Parse(HFDate.Value).ToShortDateString());
                            if (detailAfter.Count > 0)
                            {
                                for (int d = 0; d < detailAfter.Count; d++)
                                {
                                    DetailDTO.DtlId = detailAfter[d].DtlId;
                                    DetailDTO.ProductId = detailAfter[d].ProductId;
                                    DetailDTO.UsedQuantity = detailAfter[d].UsedQuantity;
                                    DetailDTO.TotalQuantity = detailAfter[d].TotalQuantity + (Convert.ToDouble(cock[j].Quantity * data.First().Quantity));
                                    DetailDTO.RemainingQuantity = Convert.ToDouble(Quantity1.First().QuantityStore + (Convert.ToDouble(cock[j].Quantity * data.First().Quantity)));
                                    DetailBLL.EditTotalQuan(DetailDTO);
                                }
                            }

                        }

                        SBLL.EditStoreQty(SDTO);


                    }
                }
                else
                {

                    SDTO.ProductId = data.First().ProductId;
                    SDTO.CentralStoreId = Convert.ToInt32(Quantity.First().CentralStoreId);
                    SDTO.QuantityStore = (data.First().Quantity + Quantity.First().QuantityStore);
                    SDTO.DateUpdated = DateTime.Now.Date;
                    SDTO.QuantityLastPurchase = Convert.ToDouble(data.First().Quantity);
                    if (Quantity.First().QuantityPurchase == null)
                    {
                        SDTO.DateStored = DateTime.Now.Date;
                        SDTO.QuantityPurchase = 0 + data.First().Quantity;
                    }
                    else
                    {
                        SDTO.QuantityPurchase = Quantity.First().QuantityPurchase + data.First().Quantity;
                    }


                    if (!string.IsNullOrEmpty(HFDate.Value))
                    {

                        var detail = DetailBLL.GetdtlId(int.Parse(data.First().ProductId.ToString()), DateTime.Parse(HFDate.Value).ToShortDateString());
                        if (detail.Count > 0)
                        {
                            DetailDTO.DtlId = detail.First().DtlId;
                            DetailDTO.ProductId = detail.First().ProductId;
                            DetailDTO.UsedQuantity = detail.First().UsedQuantity - data.First().Quantity;
                            DetailDTO.RemainingQuantity = Convert.ToDouble(Quantity.First().QuantityStore + data.First().Quantity);
                            DetailBLL.Edit(DetailDTO);
                        }
                        var detailAfter = DetailBLL.GetdtlIdAfter(int.Parse(data.First().ProductId.ToString()), DateTime.Parse(HFDate.Value).ToShortDateString());
                        if (detailAfter.Count > 0)
                        {
                            for (int d = 0; d < detailAfter.Count; d++)
                            {
                                DetailDTO.DtlId = detailAfter[d].DtlId;
                                DetailDTO.ProductId = detailAfter[d].ProductId;
                                DetailDTO.UsedQuantity = detailAfter[d].UsedQuantity;
                                DetailDTO.TotalQuantity = detailAfter[d].TotalQuantity + data.First().Quantity;
                                DetailDTO.RemainingQuantity = Convert.ToDouble(Quantity.First().QuantityStore + data.First().Quantity);
                                DetailBLL.EditTotalQuan(DetailDTO);
                            }
                        }

                    }

                    SBLL.Edit(SDTO);

                }
                SearchPagload();

            }
            SaleBLL.DeleteAdjustmentById(int.Parse(e.CommandArgument.ToString()));
            var dtldata = SaleBLL.BranchWise_SalesInfoLaod_ChangeProduct(int.Parse(data.First().SalId.ToString()), 0, "", "", "", "", "");
            if (dtldata.Count > 0)
            {
                double? sum = 0;
                foreach (var temp in dtldata)
                {
                    sum += (temp.SalePrice * temp.Quantity);
                }
                var datapay = SaleBLL.GetPaymentId(int.Parse(data.First().SalId.ToString()));
                SaleDTO.SalePaymentId = datapay.First().SalePaymentId;
                SaleDTO.TotalPrice = sum;
                SaleBLL.Edit_Adjustpayment(SaleDTO);
            }
            else
            {
                SaleBLL.DeleteSalePayment(int.Parse(data.First().SalId.ToString()));
                SaleBLL.DeleteSalePaymentDtl(int.Parse(data.First().SalId.ToString()));
                SaleBLL.DeleteSalInfo(int.Parse(data.First().SalId.ToString()));
            }
            /// var dtldata = SaleBLL.BranchWise_SalesInfoLaod_ChangeProduct(int.Parse(data.First().SalId.ToString()), 0, "", "", "", "", "");

            ClearSearch();
            /*
                SaleDtlDTO.SaleDtlId = data.First().SaleDtlId;
                SaleDtlDTO.PaidAmount = sum;
              SaleBLL.Edit_AdjustpaymentDtl(SaleDtlDTO);
              */
            //

            Show("Sucessfully Deleted!");
        }
        protected void LinkButton_Activity(object sender, CommandEventArgs e)
        {
            var data = SaleBLL.LoadActiveMemberDateWise(int.Parse(HFMemberId.Value), e.CommandArgument.ToString());
            if (data.Count > 0)
            {
                //  HFMemberId.Value = e.CommandArgument.ToString();
                // ddlMember.SelectedValue = e.CommandArgument.ToString();
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
                lblCurrentDetails.Text = "Page: " + CurPage.ToString();

                if (!objPds.IsFirstPage)
                    lnkPrevDetails.NavigateUrl = Request.CurrentExecutionFilePath
                    + "?Page=" + Convert.ToString(CurPage - 1);

                if (!objPds.IsLastPage)
                    lnkNextDetails.NavigateUrl = Request.CurrentExecutionFilePath
                    + "?Page=" + Convert.ToString(CurPage + 1);

                RptDetails.DataSource = objPds;
                RptDetails.DataBind();
                pnlDetails.Visible = true;
            }
            else
            {
                Show("No Activity!");
            }
        }
        protected void btnSearch_Click(object sender, EventArgs e)
        {
            SearchPagload();
        }

        protected void btnClear_Click(object sender, EventArgs e)
        {
            ClearSearch();
        }

        private void ClearSearch()
        {
            txtContactAdd.Text = "";
            txtCustomerName.Text = "";
            txtMobileNo.Text = "";
            ddlSMemType.SelectedIndex = 0;
            pnlSale.Visible = false;
            pnlDetails.Visible = false;
            pnlProduct.Visible = false;
        }

        protected void GVMember_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {

            GVPur.PageIndex = e.NewPageIndex;
            SearchPagload();

        }

    }
}