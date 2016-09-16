using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenSalesDtlDto
    {
        public int SaleDtlId { get; set; }
        public double? SalePrice { get; set; }
        public double? Quantity { get; set; }
        public int? SalId { get; set; }
        public int ProductId { get; set; }
        public string TransectionType { get; set; }
        public string SaleType { set; get; }
        public double? BarQuantity { set; get; }
        public double? OffQuantity { set; get; }
        public double? BarPrice { set; get; }
        public double? OffPrice { set; get; }
    }
}
