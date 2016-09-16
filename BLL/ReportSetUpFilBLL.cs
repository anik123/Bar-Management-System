using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;
using DTO.BrProfile;
using DTO.CompProfile;

namespace BLL
{
  public  class ReportSetUpFilBLL 
    {
      ReportSetUpFileDAL Dal= new ReportSetUpFileDAL();
      // list of product info
      public List<ProductDTO> ProductList(int cateid, int compid, string producname)
      {
          return Dal.ProductList(cateid, compid, producname);
      }
      // list of Bank Account
      public List<AccountInfoDTO> LoadAccountInfo(int branchid,  int BankID, string accname, string accnum)
      {
          return Dal.LoadAccountInfo(BankID, branchid, accname, accnum);
      }

      // laod Branch list profile info
      public List<BranchProfileDTO> LoadCompanyBrachList(int proid, string CompName, string CompMobile, string CompAdd)
      {
          return Dal.LoadCompanyBrachList(proid, CompName, CompMobile, CompAdd);
      }
       // client Company List
      public List<CompanyInfoDTO> ClientCompanyList(int CompId, string CompName, string CompMobile, string CompStatus)
      {
          return Dal.ClientCompanyList(CompId, CompName, CompMobile, CompStatus);
      }
         // Company profile Rpt Info
      public List<CompProfileInfoDTO> CompanyProfile()
      {
          return Dal.CompanyProfile();
      }
    }
}
