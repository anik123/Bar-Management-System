using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ProductDTO
    {
        public int ProductId { get; set; }

        public int? BrachId { get; set; }
        public int? ProductReOrderStatus { get; set; }
        
        public int? CompanyId { get; set; }

        public int? UnitId { get; set; }
        public int? CompId { get; set; }
        public string ProductName { get; set; }
        public double? ProductPurchasePrice { get; set; }
        public double? ProductSalePrice { get; set; }
        public double? ProductOffSalePrice { get; set; }

        public int? CenterReorderValue { get; set; }
        public int? CategoryId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? RequistionDate { get; set; }
        // load 
        public string CompName { get; set; }
        public string UnitName { get; set; }
        public string CategoryName { get; set; }
        public int CatId { get; set; }

        // for re order value
        public int? ReorderValue { get; set; }
        public double? RateOfInterest { get; set; }
        public int? ReorderId { get; set; }
        public int? SalePrice { get; set; }
        // comp profile
        public int CompProId { get; set; }
        public string CompProName { get; set; }
        public string CompAddress { get; set; }
        public string CompPhone { get; set; }
        public string CompanyContractNo { get; set; }
        // stock
        public double? QuantityStore { get; set; }
        public double? ReqiredPurQuantity { get; set; }
        public double? QuantityPurchase { get; set; }
        public double? QuantityLastPurchase { get; set; }
        public DateTime? DateUpdated { get; set; }
        public DateTime? DateStored { get; set; }
        //pur req 
        public int? PurReqQuantity { get; set; }

        // operation summary
        public double? PurQuantity { get; set; }
        public int? BranchReqNo { get; set; }

        public int? CentralRequistion { get; set; }

        public int? BranchRequistion { get; set; }
        public double? SaleQuantity { get; set; }
        public double? PurAmount { get; set; }
        public double? SalAmount { get; set; }
        public string Fromdate { get; set; }
        public string ToDate { get; set; }

        // branch
        public string BrProName { get; set; }


    }
}
