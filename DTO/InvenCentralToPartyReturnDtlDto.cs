using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
  public class InvenCentralToPartyReturnDtlDto
    {
        public int? reQty { get; set; }
        public int centralReId { get; set; }
        public string reBy { get; set; }
        public DateTime reDate { get; set; }
        public int? reCompId { get; set; }
        public int? reProId { get; set; }
        public int? reProAmount { get; set; }
        public int? reProBranchId { get; set; }

    }
}
