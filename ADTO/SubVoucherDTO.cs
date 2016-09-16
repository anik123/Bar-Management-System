using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public class SubVoucherDTO
    {

        public int SubVoucherId { get; set; }
        public string SubVoucherCode { get; set; }
        public string SubVoucherName { get; set; }
        public int? MainVoucherId { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        // for load sub vocher name and code
        public string SubVoucherCodeName { get; set; }

        // for load main voucher
        public string MainVoucherCode { get; set; }
        public string MainVoucherName { get; set; }
    }
}
