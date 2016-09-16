using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public class MainHeadDTO
    {
        public int MainHeadId { get; set; }
        public string MainHadeNum { get; set; }
        public string MainHeadName { get; set; }
        public string Description { get; set; }
        public DateTime? CreateDate { get; set; }

        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? AID { get; set; }

        // for load name and num
        public string MainHeadName_Num { get; set; }
    }
}
