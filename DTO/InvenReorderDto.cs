using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenReorderDto
    {
        public int ReorderId { get; set; }
        public int ProductId { get; set; }
        public int BrProId { get; set; }
        public int? CategoryId { get; set; }
        public int? ReorderValue { get; set; }
        public double? RateOfInterest { get; set; }
        public string PurRequisitonStatus { get; set; }

        public string CreateBy { get; set; }
        public DateTime? Createdate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        //load
        public string ReorderInsertStatus { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public double? ProductSalePrice { get; set; }
       
        public string UnitName { get; set; }
        public string CompName { get; set; }
        public int UnitId { get; set; }
        public int CompId { get; set; }
        public string BrProName { get; set; }
        public double? ProductPurchasePrice { get; set; }
        public int? SalePrice { get; set; }
        // for understock
        public int? QuantityStore { get; set; }
        public int? PurReqQuantity { get; set; }
        public int? ReqiredPurQuantity { get; set; }



    }
}
