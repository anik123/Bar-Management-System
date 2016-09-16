using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenStoreStatusDto
    {
        public int InvenStoreId { get; set; }
        public int? ProductId { get; set; }
        public int? BrProId { get; set; }
        public int? QuantityStore { get; set; }
        public int? QuantityPurchase { get; set; }
        public int? QuantityLastPurchase { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateStored { get; set; }

        // for Report 
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CompName { get; set; }
        public double? ProductPurchasePrice { get; set; }
        public string BrProName { get; set; }

        public int? ProdcutId { get; set; }
        public int? CatId { get; set; }
        public int? CompId { get; set; }
        public int? ReqiredPurQuantity { get; set; }
        // inven reorder rate of interest
        public double? RateOfInterest { get; set; }
        // purchase price from purdtl table
        public double? PurchasePrice { get; set; }
        public double? SalesPrice { get; set; }
        public double? ProductSalePrice{ get; set; }

        public double? TotalPurPrice { get; set; }

        public double? TotalSalePrice { get; set; }

    }
}
