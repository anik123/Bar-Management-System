using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{

    public class InvenCentralPurchasePaymentDtlDto
    {
        public int PurPayDtlId { get; set; }
        public int ProductId { get; set; }
        public string PaymentMode { get; set; }
        public double? PaidAmount { get; set; }
        public double? DueAmount { get; set; }
        public double? TotalPrice { get; set; }
        public string Note { get; set; }
        public int? PurPaymentId { get; set; }

        public DateTime? PaymentDate { set; get; }
        public string PaymentBy { set; get; }
        public string ChequeNo { set; get; }
        public DateTime? ChequeDate { set; get; }
        public DateTime? IssDate { set; get; }
        public int? AccountInfoId { set; get; }
        public string LCNumber { set; get; }

       
    }

}
