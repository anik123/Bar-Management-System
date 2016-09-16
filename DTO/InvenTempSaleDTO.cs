using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenTempSaleDTO
    {
        public int TempId { set; get; }
        public int? MemberId { set; get; }
        public string Category { set; get; }
        public string SubCategory { set; get; }
        public int? ProductId { set; get; }
        public double? Unit { set; get; }
        public double? PegSize { set; get; }
        public double? UnitPrize { set; get; }
        public string SaleType { set; get; }
        public DateTime? CreateDate { set; get; }

        //Xtra\
        public string MemberNo { set; get; }
        public string MemberName { set; get; }
        public double? TotalPricr { set; get; }
    }
}
