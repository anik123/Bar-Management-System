using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenCentralStoreStatusDTO
    {
        public int CentralStoreId { get; set; }
        public int? ProductId { get; set; }
        public double? QuantityStore { get; set; }
        public int? BranchId { get; set; }
        public int? CompanyId { get; set; }


        
        public double? QuantityPurchase { get; set; }
        public double? QuantityLastPurchase { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateStored { get; set; }

        // for Report 
        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string CompName { get; set;}
       // public string BrProName { get; set; }

        public int? ProdcutId { get; set; }
        public int? CatId { get; set; }
        public int? CompId { get; set; }
        public double? ProductPurchasePrice { get; set; }
        
        public int? CenterReorderValue { get; set; }

        public double? TotalPurPrice { get; set; }
    }
}
