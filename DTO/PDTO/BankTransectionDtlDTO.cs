using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDTO
{
    public class BankTransectionDtlDTO
    {
        public int TransectionDtlId { get; set; }
        public int AccountInfoId { get; set; }
        public int? IncomeItemId { get; set; }
        public double? Amount_EachTransection { get; set; }
        public string Remarks { get; set; }
        public DateTime? CollectionDate { get; set; }
        public string PaymentBy { get; set; }
        public DateTime? PaymentDate { get; set; }
        public int? Year { get; set; }


        //previous data not req
        public double? Amount { get; set; }
        public string BankName { get; set; }
        public int? TransectionId { get; set; }
        
        // previoues data not req
      
     
       // for rpt
        public string BrProName { set; get; }
        public int bankId { get; set; }
        public string BranchName { get; set; }
        public string AccountName { get; set; }
        public string AccountNum { get; set; }

        public string AccountTypeName { get; set; }
        public int AccountTypeID { get; set; }

        // for reproting 
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }

        // for individual bank amount rpt
        public double? BankAmount {get;set;}
        public string BankRemarks { get; set; }
    }
}
