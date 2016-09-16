using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenSalesDetailDTO
    {
        public int DtlId { set; get; }
        public int ProductId { set; get; }
        public double? TotalQuantity { set; get; }
        public double? UsedQuantity { set; get; }
        public double? RemainingQuantity { set; get; }
        public double? TodayStock { set; get; }
        public DateTime? CreatedDate { set; get; }


        //Xtra

        public string SubCategoryName { set; get; }
    }
}
