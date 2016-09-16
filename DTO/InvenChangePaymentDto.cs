using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenChangePaymentDto
    {
        public int ChangePaymentId { get; set; }
        public double? PaidAmount { get; set; }
        public double? DueAmount { get; set; }
        public double? Discount { get; set; }
        public double? TotalPrice { get; set; }
        public int? ChangeId { get; set; }
        public double? Vat { get; set; }
        public string DiscountDescription { get; set; }

    }
}
