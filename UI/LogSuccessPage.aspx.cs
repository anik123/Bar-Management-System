using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using ABLL;
using System.Web.Security;
using PBLL.Page_ObjectBLL;
using BLL;
using DTO;

namespace UI
{
    public partial class LogSuccessPage : System.Web.UI.Page
    {
        LoginBLL LBLL = new LoginBLL();
        PageObjectRoleBLL PObjRoleBLL = new PageObjectRoleBLL();



        //Close Balance


        //Temp
        InvenTempSaleBLL tempBLL = new InvenTempSaleBLL();
        InvenTempSaleDTO tempDTO = new InvenTempSaleDTO();

        // Sales  
        InvenSalesBLL SaleBLL = new InvenSalesBLL();
        InvenSalesInfoDto SalInfoDTO = new InvenSalesInfoDto();
        InvenSalesDtlDto SaldtlDTO = new InvenSalesDtlDto();
        InvenSalesPaymentDto SalPayDTO = new InvenSalesPaymentDto();
        InvenSalePaymentDtlDto SalpayDtlDTO = new InvenSalePaymentDtlDto();

        //emp
        EmpBasinInfoBLL empBLL = new EmpBasinInfoBLL();

        ProductBLL PBLL = new ProductBLL();

        //Cocktail Info
        CocktailInfoBLL cockBLL = new CocktailInfoBLL();

        //Invencentersotre
        InvenCentralStoreStatusBLL SBLL = new InvenCentralStoreStatusBLL();
        InvenCentralStoreStatusDTO SDTO = new InvenCentralStoreStatusDTO();

        //Report
        InvenSalesDetailBLL DetailBLL = new InvenSalesDetailBLL();
        InvenSalesDetailDTO DetailDTO = new InvenSalesDetailDTO();

        protected void Page_Load(object sender, EventArgs e)
        {
            if (!Page.IsPostBack)
            {
                Page.Title = "Login Success";
                Label27.Text = HttpContext.Current.User.Identity.Name;
                GetBranchId();
                var data = tempBLL.GetOpenBalanceDate(DateTime.Now.ToShortDateString());
                if (data.Count > 0)
                {
                    CloseBalance();
                }
                // RoleName();
            }

        }
        public void GetBranchId()
        {
            string empusername = HttpContext.Current.User.Identity.Name;
            var brid = empBLL.GetCurrentUserBranchName(empusername);

            HFBranceId.Value = brid.First().BrProId.ToString();
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


        public class PairClose : IEquatable<PairClose>
        {
            public int? MemberId { set; get; }
            public string CreatedDate { set; get; }
            public PairClose()
            {

            }
            public PairClose(int? MemberId, string CreatedDate)
            {
                this.MemberId = MemberId;
                this.CreatedDate = CreatedDate;
            }
            public bool Equals(PairClose other)
            {
                if (this.MemberId == other.MemberId && this.CreatedDate.Equals(other.CreatedDate))
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
        }

        private void CloseBalance()
        {
            var data = tempBLL.GetOpenBalanceDate(DateTime.Now.ToShortDateString());
            var CheckData = new List<PairClose>();
            foreach (var Item in data)
            {

                if (!CheckData.Equals(new PairClose(int.Parse(Item.MemberId.ToString()), Item.CreateDate.Value.ToShortDateString())))
                {
                    var p = new PairClose();
                    p.MemberId = Item.MemberId;
                    p.CreatedDate = Item.CreateDate.Value.ToShortDateString();
                    CheckData.Add(p);




                    SalInfoDTO.CreateBy = HttpContext.Current.User.Identity.Name;
                    SalInfoDTO.CreateDate = Item.CreateDate.Value;
                    SalInfoDTO.BrProId = Convert.ToInt32(HFBranceId.Value);
                    SalInfoDTO.CustomerName = "";
                    SalInfoDTO.CusMobileNo = "";
                    SalInfoDTO.CusContactAdd = "";
                    SalInfoDTO.MemberId = Item.MemberId;
                    // Show(SalInfoDTO.MemberId+"");
                    //  SalInfoDTO.CusRemarks = txtRemarks.Text;
                    SaleBLL.SaveSalesInfo(SalInfoDTO);

                    var salid = SaleBLL.LaadSalInofId();
                    int Salid = salid.First().SalId;

                    // DataTable dt = (DataTable)ViewState["CurrentPurData"];
                    // int count = dt.Rows.Count;
                    var dt = tempBLL.getTempById(int.Parse(Item.MemberId.ToString()), Item.CreateDate.Value.ToShortDateString());
                    double sum = 0;
                    for (int i = 0; i < dt.Count; i++)
                    {
                        sum += (double.Parse(dt[i].PegSize.ToString()) * double.Parse(dt[i].UnitPrize.ToString()));

                        SaldtlDTO.SalePrice = dt[i].UnitPrize;
                        SaldtlDTO.Quantity = dt[i].PegSize;
                        SaldtlDTO.SalId = Salid;
                        SaldtlDTO.ProductId = int.Parse(dt[i].ProductId.ToString());
                        SaldtlDTO.SaleType = dt[i].SaleType;
                        var unit = PBLL.GetProduct(Convert.ToInt32(dt[i].ProductId), "", 0, 0, 0);
                        SaldtlDTO.BarPrice = unit.First().ProductSalePrice;
                        SaldtlDTO.OffPrice = unit.First().ProductOffSalePrice;
                        // SaldtlDTO.BarPrice
                        if (dt[i].SaleType.ToString().ToLower().Contains("bar".ToLower()))
                        {
                            SaldtlDTO.BarQuantity = Convert.ToDouble(dt[i].PegSize);
                            SaldtlDTO.OffQuantity = 0;
                        }
                        if (dt[i].SaleType.ToString().ToLower().Contains("off".ToLower()))
                        {
                            SaldtlDTO.OffQuantity = Convert.ToDouble(dt[i].PegSize);
                            SaldtlDTO.BarQuantity = 0;
                        }
                        SaleBLL.SaveSalesDtl(SaldtlDTO);
                        tempBLL.DeleteTempId(dt[i].TempId);
                    }
                    SalPayDTO.PaidAmount = 0;
                    SalPayDTO.DueAmount = sum;
                    SalPayDTO.Discount = 0;
                    SalPayDTO.TotalPrice = sum;
                    SalPayDTO.SalId = Salid;
                    SalPayDTO.Vat = 0;
                    SalPayDTO.DiscountDescription = "";
                    SaleBLL.SaveSalesPaymentInfo(SalPayDTO);


                    SalpayDtlDTO.SalId = Salid;
                    SalpayDtlDTO.PaymentMode = "Cash";
                    SalpayDtlDTO.PaidAmount = 0;
                    SalpayDtlDTO.Note = "";
                    SalpayDtlDTO.PaymentDate = data.First().CreateDate;
                    SalpayDtlDTO.PaymentBy = HttpContext.Current.User.Identity.Name;
                    SalpayDtlDTO.CardNo = "";
                    SalpayDtlDTO.ApprCode = "";
                    SalpayDtlDTO.BankName = "";
                    SalpayDtlDTO.HolderName = "";
                    SaleBLL.SaveSalesPaymentDtl(SalpayDtlDTO);


                }
            }
            tempBLL.DeleteByDate(DateTime.Now.ToShortDateString());
        }

    }
}