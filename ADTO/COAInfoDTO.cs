using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public class COAInfoDTO
    {
        public int COAId { get; set; }
        public string COAACCId { get; set; }
        public string AccountName { get; set; }
        public Int64? AID { get; set; }
        public int? SubCode_2Id { get; set; }
        public Int64? APPID { get; set; }
        public string Description { get; set; }
        public string Status { get; set; }
        public double? Balance { get; set; }
        public DateTime? OpeningDate { get; set; }
        public string OpenBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        // for load name and num
        public string COAName_Num { get; set; }

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
        public string SubCode2Name_Num { get;set; }
    }
}
