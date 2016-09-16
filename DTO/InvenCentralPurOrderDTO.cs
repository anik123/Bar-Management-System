using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenCentralPurOrderDTO
    {
        public int CentralPurOrderId { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public Nullable<double> PurchasePrice { get; set; }
        
        public string Priority { get; set; }
        public int PurOrderNO { get; set; }
        public string PurOrderBy { get; set; }
        public Nullable<System.DateTime> PurOrderDate { get; set; }
        public string PurOrderStatus { get; set; }
        public string PurChallanStatus { get; set; }
        public int? CompId { get; set; }
        public string CompName { get; set; }
        public int? CatId { get; set; }
        public int? UnitId { get; set; }
        public string CategoryName { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }
       
    }
}
