using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class ExpenseDTO
    {

        public int ExpanseId { get; set; }
        public int ExHeadId { get; set; }
        public double Amount { get; set; }
        public DateTime? Date { get; set; }
        public string Remarks { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        // for Load
        public string HeadName { get; set; }
         
    }
}
