using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public class LiabilitiesRptDTO
    {
        public int LiabRptId { get; set; }
        public int? MainHeadId { get; set; }
        public int? SubCode1Id { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? Priority { get; set; }
        public string ActiveStatus { get; set; }

        // cash flow entity name
        public string CFEName { get; set; }


        // load main head name
        public string MainHeadName { get; set; }
        public string MainheadNum { get; set; }

        public string MainHeadName_Num { get; set; }

        // load subcode_1 data
        public string SubCode_1Name { get; set; }
        public string SubCode_1Num { get; set; }
        public string SubCode1Name_Num { get; set; }

        // load subcode2
        public int SubCode2Id { get; set; }
        public string SubCode2_Num { get; set; }
        public string SubCode_2Name { get; set; }
        public string SubCode2Name_Num { get; set; }
        // load COA 
        public string COAId { get; set; }
        public string AccountName { get; set; }
        public string COAName_Num { get; set; }

    }
}
