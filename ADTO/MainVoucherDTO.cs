using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public class MainVoucherDTO
    {
        public int MainVoucherId { get; set; }
        public string MainVoucherCode { get; set; }
        public string MainVoucherName { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        // sub voucher load 

        public string MainVoucherCode_Name { get; set; }
         


    }
}
