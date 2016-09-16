using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{

    public class InvenChangePaymentDtlDto
    {
        public int ChangePayDtlId { get; set; }
        public int? ChangeId { get; set; }
        public string PaymentMode { get; set; }
        public double? PaidAmount { get; set; }
        public string Note { get; set; }
        public DateTime? PaymentDate { set; get; }
        public string PaymentBy { set; get; }
        public string CardNo { set; get; }
        public string ApprCode { set; get; }
        public string BankName { set; get; }
        public string HolderName { get; set; }
        // payment info

        public int ChangePaymentId { get; set; }
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
        // sales dtl
        public int ChangeDtlId { get; set; }
        public double? SalePrice { get; set; }
        public int? Quantity { get; set; }
        public int ProductId { get; set; }

        // for Report 
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CompName { get; set; }
        public string BrProName { get; set; }
        // 
        public double? TotalPriceQuan_Price { get; set; }
        // branch Return Info
        public int BranchReturnId { get; set; }

        public string ReturnBy { get; set; }
        public DateTime ReturnDate { get; set; }
        public int? ReturnNo { get; set; }
        public string PartyReturnStatus { get; set; }
        public int PartyReturnNo { get; set; }
        public DateTime? PartyReturnDate { get; set; }
        public string PartyReturnBy { get; set; }

    }

}
