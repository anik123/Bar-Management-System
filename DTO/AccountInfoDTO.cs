using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class AccountInfoDTO
    {
        public int AccountInfoId { get; set; }
        public int? BankId { get; set; }
        public string BranchName { get; set; }
        public string CreateBy { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mobile { get; set; }
        public int? AccountTypeId { get; set; }
        public string AccountName { get; set; }
        public string AccountNum { get; set; }
        public string ActivationSatus { get; set; }
        public string Remarks { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public int? BrProId { get; set; }
        //search
        public string BankName { get; set; }
        public string AccountTypeName { get; set; }
        //for load accountname in banktransection aspx
        public string AccountAllName { get; set; }

        // for report
        public int TransectionId { get; set; }
        public int? Year { get; set; }
        public double? Amount { get; set; }
        public double? SumAmountYear { get; set; }
        // comp profile
        public int CompProId { get; set; }
        public string CompProName { get; set; }
        public string CompAddress { get; set; }
        public string CompPhone { get; set; }
        public string CompanyContractNo { get; set; }
        //branch info
        public string BrProName { get; set; }
        public string BrAddress { get; set; }

    }
}
