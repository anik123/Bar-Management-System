using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDTO;

using DAL;
using Utility;

namespace PDAL
{
    public class BankTransectionDAL
    {
        public void Add(BankTransectionDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                PayBankTransectionInfo gur = new PayBankTransectionInfo();
                container.PayBankTransectionInfoes.AddObject((PayBankTransectionInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }
        public void Edit(BankTransectionDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new PayBankTransectionInfo();
                Comp = container.PayBankTransectionInfoes.FirstOrDefault(o => o.BankTransectionId.Equals(DTO.BankTransectionId));
                Comp.BankTransectionId = DTO.BankTransectionId;
                Comp.BankAmount = DTO.BankAmount;
                Comp.AccountInfoId = DTO.AccountInfoId;

                Comp = (PayBankTransectionInfo)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public List<BankTransectionDTO> LoadBankTransection(int accountid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PayBankTransectionInfoes
                            select new { s };
                if (accountid != 0)
                    query = query.Where(c => c.s.AccountInfoId.Equals(accountid));

                var result = (from o in query
                             
                              select new BankTransectionDTO
                              {
                                  BankTransectionId = o.s.BankTransectionId,
                                  BankAmount=o.s.BankAmount,
                                  AccountInfoId= o.s.AccountInfoId

                              }).ToList<BankTransectionDTO>();

                return result;
            }
        }


        // i think not req
        public List<BankTransectionDTO> LoadTansectionId()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PayBankTransectionInfoes
                            select new { s };


                var result = (from o in query
                              orderby o.s.BankTransectionId descending
                              select new BankTransectionDTO
                              {
                                  BankTransectionId = o.s.BankTransectionId,

                              }).ToList<BankTransectionDTO>();

                return result;
            }
        }



        public List<BankTransectionDTO> SumOfAmount(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var data = (from amount in Container.PayBankTransectionInfoes
                            where amount.PayBankAccountInfo.AccountInfoId.Equals(id)

                            group amount by new { amount.PayBankAccountInfo.AccountInfoId } into amounts
                            select new BankTransectionDTO
                                {
                                    AccountInfoId = amounts.Key.AccountInfoId,
                                    BankAmount = amounts.Sum(amount => amount.BankAmount)
                                }).ToList<BankTransectionDTO>();
                return data;
            }
        }
        // i think not req
    }
}