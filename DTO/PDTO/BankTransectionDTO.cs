using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDTO
{
    public class BankTransectionDTO
    {
        public int BankTransectionId { get; set; }
        public int AccountInfoId { get; set; }
        public double? BankAmount { get; set; }

        // previous data not req
        public int TransectionId { get; set; }
        public string BankName { get; set; }
        public string CreateBy { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateDate { get; set; }
        public int? Year { get; set; }
        // previous data not req


        //for report 
        public string BranchName { get; set; }
        public int? BankId { get; set; }
        public int? AccountTypeId { get; set; }
        public string AccountName { get; set; }
        public string AccountNum { get; set; }
        public string ActivationSatus { get; set; }
        public string AccountTypeName { get; set; }
    }
}
