using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenCentralChallanDtlDTO
    {
        public int ChallanDtlId { get; set; }
        public int ProductId { get; set; }
        public int ChallanId { get; set; }
        public int? ChallanQuantity { get; set; }
        public double? ChallanPrice { get; set; }

        // company info

        public string CompName { get; set; }
        // for Report 

        public string ProductName { get; set; }
        public string CategoryName { get; set; }
        public string DONO { get; set; }
        public string UnitName { get; set; }

        // challan info

        public int? PurReqNo { get; set; }
        public string ChallanBy { get; set; }
        public DateTime? ChallanDate { get; set; }
        public string Note { get; set; }
        public double? TotalPrice { get; set; }
        // branch 
        public string BrProName { get; set; }


    }
}
