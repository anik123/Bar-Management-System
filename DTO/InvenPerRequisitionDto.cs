using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenPerRequisitionDto
    {

        public int PurReqId { get; set; }
        public int ProductId { get; set; }
        public Nullable<int> Quantity { get; set; }
        public Nullable<double> UnitPrice { get; set; }
        public string Priority { get; set; }
        public int RequisitionNo { get; set; }
        public string RequisitionBy { get; set; }
        public DateTime? RequisitionDate { get; set; }
        public string PurReqStatus{ get; set; }
        public int? BrProId { get; set; }
        public int? ReqPurOrderId { get; set; }

        // load 
        public int? CompId { get; set; }
        public string CompName { get; set; }
        public string CategoryName { get; set; }
        public string BrProName { get; set; }
        public string ProductName { get; set; }
        public string UnitName { get; set; }
        public int CatId { get; set; }
        public int UnitId { get; set; }
        public int? QuantityStore { get; set; }
    }
}
