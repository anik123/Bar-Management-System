using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;
using DAL;

namespace DAL
{
    public class BankInfoDAL
    {
        public void Add(BankInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                PayBankInfo gur = new PayBankInfo();
                container.PayBankInfoes.AddObject((PayBankInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(BankInfoDTO EduDTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new PayBankInfo();
                Comp = container.PayBankInfoes.FirstOrDefault(o => o.BankId.Equals(EduDTO.BankId));

                Comp.BankId = EduDTO.BankId;
                Comp.BankName = EduDTO.BankName;
                Comp.UpdateBy = EduDTO.UpdateBy;
                Comp.UpdateDate = EduDTO.UpdateDate;
                Comp = (PayBankInfo)DTOMapper.DTOObjectConverter(EduDTO, Comp);

                container.SaveChanges();
            }
        }

        public List<BankInfoDTO> LoadBankName(int bankid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PayBankInfoes
                            //       join emp in Container.PayEmpBasicInfoes on s.EmpId equals emp.EmpId
                            select new { s };
                if (bankid != 0)
                    query = query.Where(c => c.s.BankId.Equals(bankid));
                var result = (from o in query
                              orderby o.s.BankId descending
                              select new BankInfoDTO
                              {
                                  BankId = o.s.BankId,
                                  BankName = o.s.BankName,
                                  CreateBy = o.s.CreateBy,
                              }).ToList<BankInfoDTO>();

                return result;
            }
        }
    }
}
