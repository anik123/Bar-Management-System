using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenPurOrderDto
    {
        public int InvenPurOrderId { get; set; }
        public int ProductId { get; set; }
        public int BrProId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public string Priority { get; set; }
        public int PurOrderNO { get; set; }
        public string PurOrderBy { get; set; }
        public Nullable<System.DateTime> PurOrderDate { get; set; }
        public string PurOrderStatus { get; set; }

      
    }
}
