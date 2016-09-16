using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenChangeDtlDto
    {
        public int ChangeDtlId { get; set; }
        public double? SalePrice { get; set; }
        public int? Quantity { get; set; }
        public int? ChangeId { get; set; }
        public int ProductId { get; set; }
        public int? SaleDtlId { get; set; }
        public string Caused { get; set; }
        public string TransectionType { get; set; }
        public string CentranlReturnStatus { get; set; }


    }
}
