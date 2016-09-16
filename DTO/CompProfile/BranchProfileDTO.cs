using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.BrProfile
{
    public class BranchProfileDTO
    {
        public int BrProId { get; set; }
        public int CompProId { get; set; }
        public string BrProName { get; set; }
        public string BrAddress { get; set; }
        public string BrPhone { get; set; }
        public string BrMobile1 { get; set; }
        public string BrMobile2 { get; set; }
        public string BrEmail { get; set; }
        public string BrWebsite { get; set; }
        public string BrDescription { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        // load 
        public string CompProName { get; set; }
        public string CompAddress { get; set; }
        public string CompanyContractNo { get; set; }

    }
}
