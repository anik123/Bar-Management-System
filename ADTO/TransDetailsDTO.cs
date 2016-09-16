using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public class TransDetailsDTO
    {

        public int AccTransDtlId { get; set; }
        public int TranId { get; set; }
        public int DRCOAId { get; set; }
        public int DRSubCoId2 { get; set; }
        public int? DRSubCoId1 { get; set; }
        public int? CRSubCoId1 { get; set; }
        public int CRSubCoId2 { get; set; }
        public int CRCOAId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }

        //  for load purpose
        public int DRMainHeadId { get; set; }
        public int CRMainHeadId { get; set; }
        public string DrMainHeadName { get; set; }
        public string CrMainHeadName { get; set; }
        public string DrSubCode1Num { get; set; }
        public string CrSubCode1Num { get; set; }
        public string DrSubCode2Num { get; set; }
        public string CrSubCode2Num { get; set; }
        public string CRCOAIdNum { get; set; }
        public string DRCOAIdNum { get; set; }
        public string TransName { get; set; }
        public string DrMainVocerCodeName { get; set; }
        public string CrMainVocerCodeName { get; set; }
        public string DrSubVocerCodeName { get; set; }
        public string CrSubVocerCodeName { get; set; }
        public int? DRMainVoucherId { get; set; }
        public int? CRMainVoucherId { get; set; }
        public int CrSubVoucherId { get; set; }
        public int DrSubVoucherId { get; set; }


        public string MainVoucherCode_Name { get; set; }
        public string SubVoucherCodeName { get; set; }
        public string MainHeadName_Num { get; set; }
        public string SubCode1Name_Num { get; set; }

        public string SubCode2Name_Num { get; set; }
        public string COAName_Num { get; set; }





    }
}
