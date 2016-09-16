using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class CompanyInfoDTO
    {
        public int CompId { get; set; }
        public string CompName { get; set; }
        public string CompName_BarCode { get; set; }
             
        public string CompPermanantAdd { get; set; }
        public string CompPresentAdd { get; set; }
        public string Website { get; set; }
        public string CompPhone { get; set; }
        public string CompMobile1 { get; set; }
        public string CompMobile2 { get; set; }
        public string CompEmail { get; set; }
        public string CompDes { get; set; }
        public string CompStatus { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }

        //  public long hCompId { get; set; }
    }
}
