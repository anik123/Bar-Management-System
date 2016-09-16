using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenCentralPurchaeInfoDTO
    {
        public int PurId { get; set; }
        public string PurDes { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public string SalesManName { get; set; }
        public int? PurOrderNo { get; set; }
        public int? CompId { get; set; }
    }
}
