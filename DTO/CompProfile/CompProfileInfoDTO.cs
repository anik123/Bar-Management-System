using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.CompProfile
{
    public class CompProfileInfoDTO
    {
        public int CompProId { get; set; }
        public string CompProName { get; set; }
        public string CompAddress { get; set; }
        public string CompPhone { get; set; }
        public string CompMobile1 { get; set; }
        public string CompMobile2 { get; set; }
        public string CompEmail { get; set; }
        public string CompWebsite { get; set; }
        public string CompDescription { get; set; }

        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }


        // report
        public string CompanyContractNo { get; set; }

    }
}
