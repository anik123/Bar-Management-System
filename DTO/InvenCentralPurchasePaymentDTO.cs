using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenCentralPurchasePaymentDTO
    {
        public int PurPaymentId { get; set; }
        public string PaymentMode { get; set; }
        public double? PaidAmount { get; set; }
        public double? DueAmount { get; set; }
        public double? TotalPrice { get; set; }
        public string Note { get; set; }
        public int PurId { get; set; }
        public DateTime? PaymentDate { get; set; }
        public string PaymentBy { get; set; }
        public string ChequeNo { get; set; }
        public DateTime? ChequeDate { get; set; }
        public DateTime? IssDate { get; set; }
        public int? AccountInfoId { get; set; }
        public string LCNumber { get; set; }
        public int PurorderNo { get; set; }
        public int? InvenPurOrderId { get; set; }
        public string FirstPaymentStatus { get; set; }
        // payment dtl
        public int PurPayDtlId { get; set; }
        public string CreateBy { get; set; }

        //  // for purchase due page
        public string SalesManName { get; set; }
        public int? CompId { get; set; }
        public string CompName { get; set; }
        public string CompMbbile { get; set; }
        public string MobileNo { get; set; }

        // rpt pur partialpayment
        public DateTime? PurchaseDate { get; set; }

        // for Report 
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public int CatId { get; set; }
        public string CategoryName { get; set; }
        public string DONO { get; set; }
        public int PurchaseDtlID { get; set; }
        // public int PurchaseDtlID { get; set; }
        public double? PurchasePrice { get; set; }
        public double? Quantity { get; set; }
        public int? PurOrderNo { get; set; }
        public DateTime? CreateDate { get; set; }
    }
}
