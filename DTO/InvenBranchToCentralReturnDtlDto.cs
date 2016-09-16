using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class InvenBranchToCentralReturnDtlDto
    {

       public int branchReId { get; set; }
        public int? reQty { get; set;}
        public string reBy { get; set;}
        public DateTime reDate { get; set;}
        public int reCompId { get; set;}
        public int reProId { get; set;}
        public int reProAmount { get; set;}
        public int reProBranchId { get; set;}


    }
}
