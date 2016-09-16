using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenCentralPurchaseDtlDto
    {
        public int PurchaseDtlID { get; set; }
        public double? PurchasePrice { get; set; }
        public double? Quantity { get; set; }
        public int ProductId { get; set; }
        public int? PurId { get; set; }

        // for report
        public string BatchNo { get; set; }
        public string ExpirySalesStatus { get; set; }
        public DateTime? ExpriyDate { get; set; }


    }
}
