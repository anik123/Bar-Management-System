using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDTO
{
    public class CompanyCashEntryDTO
    {
        public int CashId { get; set; }
        public int? IncomeItemId { get; set; }
        public double? CashAmount { get; set; }
        public string Remarks { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CrateDate { get; set; }
        public int? Year { get; set; }
        public string Month { get; set; }
        public DateTime? CollectionDate { get; set; }

        // for report 
        public double? TotolAmount { get; set; }
        public string IncomeCollectionItem { set; get; }
        // for reproting 
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string BrProName { get; set; }
    }
}
