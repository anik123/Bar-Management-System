using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using PDTO;
using DAL;
using Utility;

namespace PDAL
{
    public class CompanyCashEntryDAL
    {
        public void Add(CompanyCashEntryDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                PayCompanyCashEntry gur = new PayCompanyCashEntry();
                container.PayCompanyCashEntries.AddObject((PayCompanyCashEntry)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }
        public List<CompanyCashEntryDTO> SumOfCashAmount()
        {
            using (var Container = new InventoryContainer())
            {
                var data = (from amount in Container.PayCompanyCashEntries


                            group amount by new { } into amounts
                            
                            select new CompanyCashEntryDTO
                            {
                               
                                CashAmount = amounts.Sum(s => s.CashAmount)
                            }).ToList<CompanyCashEntryDTO>();
                return data;
            }
        }
    }
}
