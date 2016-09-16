using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Globalization;

namespace ADTO
{
    
    public class LedgerDTO
    {

        public int LedgerId { get; set; }
        public int? JournalId{get;set;}
        public double? OPBAL { get; set; }
        public double? DRAmount { get; set; }
        public double? CRAmount { get; set; }
        public double? CLBAL { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }


        //for journal
        public int TransectionNo { get; set; }
        public string JournalType { get; set; }      
        public DateTime? TransectionDate { get; set; }
        public string VONO { get; set; }
        public string MRNO { get; set; }
        public string Remarks { get; set; }

        // for reproting 
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }


        // load main head name
        public string MainHeadName { get; set; }
        public string MainheadNum { get; set; }
        public int MainHeadId { get; set; }
        public string MainHeadName_Num { get; set; }

        // load subcode_1 data
        public string SubCode_1Name { get; set; }
        public string SubCode_1Num { get; set; }
        public int SubCode_1Id { get; set; }
        public string SubCode1Name_Num { get; set; }

        // load subcode2
        public int SubCode2Id { get; set; }
        public string SubCode2_Num { get; set; }
        public string SubCode_2Name { get; set; }
        public string SubCode2Name_Num { get; set; }
        // load COA 
        public int COAId { get; set; }
        public string COAACCId { get; set; }
        public string AccountName { get; set; }
        public string COAName_Num { get; set; }

        // sub voucher 
        public int SubVoucherId { get; set; }
        public string SubVoucherCode { get; set; }
        public string SubVoucherName { get; set; }
        public string SubVoucherCodeName { get; set; }

        // for load main voucher
        public string MainVoucherCode { get; set; }
        public string MainVoucherName { get; set; }
        public int MainVoucherId { get; set; }
        public string MainVoucherCode_Name { get; set; }


        // For Account Payable Info Additional ( Later  devolopment)
        public int? CompId { get; set; }
        public string CompanyName { get; set; }
        public string PayableHolderName { get; set; }
        public string PurPose { get;set;}
        public DateTime? PayableDate { get; set; }
        public DateTime? PayableLastDate { get; set; }

        // for balace sheet 
        public double? Amount { get; set; }

        // IncomeStatement
        public double? Tax { get; set; }
        public string CurrentYear { get; set; }
        public string LastYear { get; set; }

    
        // cash flow entity name
        public string CFEName { get; set; }
        public int? Priority { get; set; }
        public int CFRId { get; set; }
        public int CFEId { get; set; }
  }
}
