using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenSalesInputDTO
    {
        public int InputId { set; get; }
        public double? GuestCharge { set; get; }
        public double? Card { set; get; }
        public double? ExtraBill { set; get; }
        public double? GuestChagePlus { set; get; }
        public double? TotalAmount { set; get; }
        public DateTime? CreatedDate { set; get; }
    }
}
