using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public class JournalDTO
    {

        public int JournalId { get; set; }
        public int SubCode2Id { get; set; }
        public int COAId { get; set; }
        public int SubVoucherId { get; set; }
        public int TransectionNo { get; set; }
        public string JournalType { get; set; }
        public double? DRAmount { get; set; }
        public double? CRAmount { get; set; }
        public DateTime? TransectionDate { get; set; }
        public string VONO { get; set; }
        public string MRNO { get; set; }
        public string ReferenceEntity { get; set; }
        public string Remarks { get; set; }
        public string PostLeadgerStatus { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }

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
        public string SubCode2_Num { get; set; }
        public string SubCode_2Name { get; set; }
        public string SubCode2Name_Num { get; set; }
        // load COA 
        public string COAACCId { get; set; }
        public string AccountName { get; set; }
        public string COAName_Num { get; set; }

        // sub voucher 
        public string SubVoucherCode { get; set; }
        public string SubVoucherName { get; set; }
        public string SubVoucherCodeName { get; set; }

        // for load main voucher
        public string MainVoucherCode { get; set; }
        public string MainVoucherName { get; set; }
        public int MainVoucherId { get; set; }
        public string MainVoucherCode_Name { get; set; }


    }
}
