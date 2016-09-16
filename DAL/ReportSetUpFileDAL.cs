using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DTO.BrProfile;
using DTO.CompProfile;

namespace DAL
{
    public class ReportSetUpFileDAL
    {
        // list of product info
        public List<ProductDTO> ProductList(int cateid, int compid, string producname)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Products
                            join unit in Container.Units on s.UnitId equals unit.UnitId
                            join cate in Container.Categories on s.CategoryId equals cate.CatId
                            join comp in Container.CompanyInfoes on s.CompId equals comp.CompId
                            select new { s, unit, cate, comp };

                if (cateid != 0)
                    query = query.Where(c => c.cate.CatId.Equals(cateid));
                if (compid != 0)
                    query = query.Where(c => c.comp.CompId.Equals(compid));

                if (!string.IsNullOrEmpty(producname))
                    query = query.Where(c => c.s.ProductName.Contains(producname));


                var result = (from o in query
                              orderby o.s.ProductId descending

                              select new ProductDTO
                              {
                                  ProductName = o.s.ProductName,
                                  CompName = o.comp.CompName,
                                  CategoryName = o.cate.CategoryName,
                                  UnitName = o.unit.UnitName

                              }).ToList<ProductDTO>();
                return result;
            }
        }
        // list of Bank Account
        public List<AccountInfoDTO> LoadAccountInfo(int branchid, int BankID, string accname, string accnum)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PayBankAccountInfoes
                            join bank in Container.PayBankInfoes on s.BankId equals bank.BankId
                            join accounttype in Container.PayAccountTypeInfoes on s.AccountTypeId equals accounttype.AccountTypeId
                            join branch in Container.InvenBranchProfiles on s.BrProId equals branch.BrProId
                            select new { s, bank, accounttype, branch };

                if (BankID != 0)
                    query = query.Where(c => c.bank.BankId.Equals(BankID));
                if (branchid != 0)
                    query = query.Where(c => c.branch.BrProId.Equals(branchid));

                if (!string.IsNullOrEmpty(accname))
                    query = query.Where(c => c.s.AccountName.Contains(accname));
                if (!string.IsNullOrEmpty(accnum))
                    query = query.Where(c => c.s.AccountNum.Contains(accnum));

                var result = (from o in query
                              orderby o.s.AccountInfoId descending

                              select new AccountInfoDTO
                              {
                                  AccountInfoId = o.s.AccountInfoId,
                                  AccountName = o.s.AccountName,
                                  AccountNum = o.s.AccountNum,
                                  AccountTypeId = o.accounttype.AccountTypeId,
                                  ActivationSatus = o.s.ActivationSatus,
                                  Address = o.s.Address,
                                  BankId = o.bank.BankId,
                                  AccountTypeName = o.accounttype.AccountTypeName,
                                  BankName = o.bank.BankName,
                                  BranchName = o.s.BranchName,
                                  Mobile = o.s.Mobile,
                                  Phone = o.s.Phone,

                                  // branch
                                  BrProName = o.branch.BrProName + "-" + o.branch.BrAddress,
                                  //company profile
                                  CompProName = o.branch.InvenCompProfileInfo.CompProName,
                                  CompAddress = o.branch.InvenCompProfileInfo.CompAddress,
                                  CompanyContractNo = o.branch.InvenCompProfileInfo.CompPhone + "," + o.branch.InvenCompProfileInfo.CompMobile1,
                              }).ToList<AccountInfoDTO>();
                return result;
            }
        }

        // laod Branch list profile info
        public List<BranchProfileDTO> LoadCompanyBrachList(int proid, string CompName, string CompMobile, string CompAdd)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenBranchProfiles
                            join compf in Container.InvenCompProfileInfoes on s.CompProId equals compf.CompProId
                            select new { s, compf };

                if (proid != 0)
                    query = query.Where(c => c.s.BrProId.Equals(proid));
                if (!string.IsNullOrEmpty(CompName))
                    query.Where(c => c.s.BrProName.Equals(CompName));

                if (!string.IsNullOrEmpty(CompMobile))
                    query.Where(c => c.s.BrMobile1.Contains(CompMobile) || c.s.BrMobile2.Contains(CompMobile));

                if (!string.IsNullOrEmpty(CompAdd))
                    query.Where(c => c.s.BrAddress.Contains(CompAdd));

                var result = (from o in query
                              orderby o.s.BrProId descending
                              select new BranchProfileDTO
                              {
                                  //company profile
                                  CompProName = o.compf.CompProName,
                                  CompAddress = o.compf.CompAddress,
                                  CompanyContractNo = o.compf.CompPhone + "," + o.compf.CompMobile1,

                                  BrAddress = o.s.BrAddress,

                                  BrEmail = o.s.BrEmail,
                                  BrMobile1 = o.s.BrMobile1,
                                  BrMobile2 = o.s.BrMobile2,
                                  BrPhone = o.s.BrPhone,
                                  BrProName = o.s.BrProName,
                                  BrWebsite = o.s.BrWebsite,

                              }).ToList<BranchProfileDTO>();

                return result;
            }
        }
        // client Company List
        public List<CompanyInfoDTO> ClientCompanyList(int CompId, string CompName, string CompMobile, string CompStatus)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.CompanyInfoes

                            select new { s };
                if (CompId != 0)
                    query = query.Where(c => c.s.CompId.Equals(CompId));
                if (!string.IsNullOrEmpty(CompName))
                    query.Where(c => c.s.CompName.Equals(CompName));
                if (!string.IsNullOrEmpty(CompMobile))
                    query.Where(c => c.s.CompMobile1.Contains(CompMobile) || c.s.CompMobile2.Contains(CompMobile));
                if (!string.IsNullOrEmpty(CompStatus))
                    query.Where(c => c.s.CompStatus.Contains(CompStatus));

                var result = from o in query
                             orderby o.s.CompId descending

                             select new CompanyInfoDTO
                             {
                                 CompId = o.s.CompId,
                                 CompName = o.s.CompName,
                                 CompPermanantAdd = o.s.CompPermanantAdd,
                                 CompMobile1 = o.s.CompMobile1,
                                 CompPresentAdd = o.s.CompPresentAdd,
                                 CompDes = o.s.CompDes,
                                 CompEmail = o.s.CompEmail,
                                 CompMobile2 = o.s.CompMobile2,
                                 Website = o.s.Website,
                                 CompPhone = o.s.CompPhone,
                                 CompStatus = o.s.CompStatus

                             };
                return result.ToList<CompanyInfoDTO>();
            }
        }

        // Company profile Rpt Info
        public List<CompProfileInfoDTO> CompanyProfile()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCompProfileInfoes

                            select new { s };

                var result = (from o in query

                              select new CompProfileInfoDTO
                              {
                                  //company profile
                                  CompProName = o.s.CompProName,
                                  CompAddress = o.s.CompAddress,
                                  CompanyContractNo = o.s.CompPhone + "," + o.s.CompMobile1,
                              }).ToList<CompProfileInfoDTO>();
                return result;
            }
        }
    }
}
