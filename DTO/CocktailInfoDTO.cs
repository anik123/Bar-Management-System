using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class CocktailInfoDTO
    {
        public int CocktaiInfoId { set; get; }
        public int? CocktaiProId { set; get; }
        public int? ItemProId { set; get; }
        public double? Quantity { set; get; }
        public string CreateBy { set; get; }
        public DateTime? CreateDate { set; get; }

        //extra
        public string CategoryName { set; get; }
        public string CompName { set; get; }
    }
}
