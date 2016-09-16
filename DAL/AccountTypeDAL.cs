using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;
using DAL;

namespace DAL
{
    public class AccountTypeDAL
    {
        public void Add(AccountTypeDTO DTO)
        {

            using (var container = new InventoryContainer())
            {
                PayAccountTypeInfo gur = new PayAccountTypeInfo();
                container.PayAccountTypeInfoes.AddObject((PayAccountTypeInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(AccountTypeDTO EduDTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new PayAccountTypeInfo();
                Comp = container.PayAccountTypeInfoes.FirstOrDefault(o => o.AccountTypeId.Equals(EduDTO.AccountTypeId));

                Comp.AccountTypeId = EduDTO.AccountTypeId;
                Comp.AccountTypeName = EduDTO.AccountTypeName;
                Comp.UpdateBy = EduDTO.UpdateBy;
                Comp.UpdateDate = EduDTO.UpdateDate;
                Comp = (PayAccountTypeInfo)DTOMapper.DTOObjectConverter(EduDTO, Comp);

                container.SaveChanges();
            }
        }

        public List<AccountTypeDTO> LoadAccountTypeName(int accountypeid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PayAccountTypeInfoes
                            //       join emp in Container.PayEmpBasicInfoes on s.EmpId equals emp.EmpId
                            select new { s };
                if (accountypeid != 0)
                    query = query.Where(c => c.s.AccountTypeId.Equals(accountypeid));
                var result = (from o in query
                              orderby o.s.AccountTypeId descending
                              select new AccountTypeDTO
                              {
                                  AccountTypeId = o.s.AccountTypeId,
                                  AccountTypeName = o.s.AccountTypeName,
                                  CreateBy = o.s.CreateBy,
                              }).ToList<AccountTypeDTO>();

                return result;
            }
        }
    }
}