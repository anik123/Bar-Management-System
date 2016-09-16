using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{

    public class InvenSalePaymentDtlDto
    {
        public int SalePayDtlId { get; set; }
        public int? SalId { get; set; }
        public string PaymentMode { get; set; }
        public double? PaidAmount { get; set; }
        public string Note { get; set; }
        public DateTime? PaymentDate { set; get; }
        public string PaymentBy { set; get; }
        public string CardNo { set; get; }
        public string ApprCode { set; get; }
        public string BankName { set; get; }
        public string HolderName { get; set; }

        // datetime to string
        public string CreateDate_String { get; set; }

        // payment info

        public int SalePaymentId { get; set; }
        public double? DueAmount { get; set; }
        public double? Discount { get; set; }
        public double? TotalPrice { get; set; }
        public double? Vat { get; set; }
        public string DiscountDescription { get; set; }
        // sale infoo

        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int? BrProId { get; set; }
        public string CustomerName { get; set; }
        public string CusMobileNo { get; set; }
        public string CusContactAdd { get; set; }
        public string CusRemarks { get; set; }
        public int? MemberId { set; get; }
        public string MemberName { set; get; }
        public string MemberNo { set; get; }
        // sales dtl
        public int SaleDtlId { get; set; }
        public double? SalePrice { get; set; }
        public double? Quantity { get; set; }
        public int ProductId { get; set; }
        public string SaleType { set; get; }
        public double? BarQuantity { set; get; }
        public double? OffQuantity { set; get; }
        public double? BarPrice { set; get; }
        public double? OffPrice { set; get; }
        // for Report 
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CompName { get; set; }
        public string BrProName { get; set; }
        public string UnitName { get; set; }
        public double? ProductPuchasePrice { get; set; }
        public double? ProductSalePrice { get; set; }

        public int? CompId { get; set; }
        public int? CatId { get; set; }
        public int? UnitId { get; set; }
        // 
        public double? TotalPriceQuan_Price { get; set; }
        //sales rating
        public string Fromdate { get; set; }
        public string ToDate { get; set; }

        //Reporting \
        public double? TotalSale { set; get; }
        public double? GuestCharge { set; get; }
        public double? card { set; get; }
        public double? ExtraBill { set; get; }
        public double? GouestChargePlus { set; get; }
        public double? TotalAmount { set; get; }

        //xtra
        public double? CateringBill { set; get; }
        public double? RestuarentBill { set; get; }
        public double? BekaryBill { set; get; }
        public double? GuestChargeBar { set; get; }
        public double? BarSale { set; get; }

        //FInal Quantity
        public double? FinalQuantity { set; get; }


        public double? ProductOffPrice { set; get; }

    }

}
