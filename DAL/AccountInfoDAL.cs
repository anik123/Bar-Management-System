using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using Utility;
using DTO;

namespace DAL
{
    public class AccountInfoDAL
    {
        public void Add(AccountInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                PayBankAccountInfo gur = new PayBankAccountInfo();
                container.PayBankAccountInfoes.AddObject((PayBankAccountInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(AccountInfoDTO EduDTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new PayBankAccountInfo();
                Comp = container.PayBankAccountInfoes.FirstOrDefault(o => o.AccountInfoId.Equals(EduDTO.AccountInfoId));

                Comp.AccountInfoId = EduDTO.AccountInfoId;
                Comp.AccountName = EduDTO.AccountName;
                Comp.AccountNum = EduDTO.AccountNum;
                Comp.AccountTypeId = EduDTO.AccountTypeId;
                Comp.ActivationSatus = EduDTO.ActivationSatus;
                Comp.Address = EduDTO.Address;
                Comp.BankId = EduDTO.BankId;
                Comp.BranchName = EduDTO.BranchName;
                Comp.Mobile = EduDTO.Mobile;
                Comp.Phone = EduDTO.Phone;
                Comp.UpdateBy = EduDTO.UpdateBy;
                Comp.UpdateDate = EduDTO.UpdateDate;
                Comp.BrProId = EduDTO.BrProId;
                Comp = (PayBankAccountInfo)DTOMapper.DTOObjectConverter(EduDTO, Comp);

                container.SaveChanges();
            }
        }

        //public List<AccountInfoDTO> LoadAccountInfo(int AccID,int BankID, string accnum, string accname, string branchname, string bankname)
        //{
        public List<AccountInfoDTO> LoadAccountInfo(int AccID, int BankID, string bankname, string branchname, string accname, string accnum)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PayBankAccountInfoes
                            join bank in Container.PayBankInfoes on s.BankId equals bank.BankId
                            join accounttype in Container.PayAccountTypeInfoes on s.AccountTypeId equals accounttype.AccountTypeId
                            select new { s, bank, accounttype };

                if (AccID != 0)
                    query = query.Where(c => c.s.AccountInfoId.Equals(AccID));
                if (BankID != 0)
                    query = query.Where(c => c.bank.BankId.Equals(BankID));

                if (!string.IsNullOrEmpty(bankname))
                    query = query.Where(c => c.bank.BankName.Contains(bankname));
                if (!string.IsNullOrEmpty(branchname))
                    query = query.Where(c => c.s.BranchName.Contains(branchname));
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
                                  BrProId = o.s.InvenBranchProfile.BrProId

                              }).ToList<AccountInfoDTO>();

                return result;
            }
        }

        // load accounttype 
        public List<AccountTypeDTO> LoadAccountType()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PayAccountTypeInfoes
                            //       join emp in Container.PayEmpBasicInfoes on s.EmpId equals emp.EmpId
                            select new { s };
                var result = (from o in query
                              orderby o.s.AccountTypeId descending
                              select new AccountTypeDTO
                              {
                                  AccountTypeId = o.s.AccountTypeId,
                                  AccountTypeName = o.s.AccountTypeName,

                              }).ToList<AccountTypeDTO>();

                return result;
            }
        }
        //load account name for bnak transection aspx
        public List<AccountInfoDTO> AccountNameLoad()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PayBankAccountInfoes
                            join bank in Container.PayBankInfoes on s.BankId equals bank.BankId
                            join acctype in Container.PayAccountTypeInfoes on s.AccountTypeId equals acctype.AccountTypeId
                            select new { s, bank, acctype };

                var result = (from o in query
                              orderby o.s.AccountInfoId descending
                              select new AccountInfoDTO
                              {

                                  AccountInfoId = o.s.AccountInfoId,
                                  BankId = o.bank.BankId,
                                  AccountAllName = o.bank.BankName + " ," + o.s.BranchName + " ," + o.acctype.AccountTypeName + "," + " (" + o.s.AccountNum + ")"

                              }).ToList<AccountInfoDTO>();

                return result;

            }

        }
    }
}

