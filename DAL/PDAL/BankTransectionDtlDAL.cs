using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDTO;

using DAL;
using Utility;

namespace PDAL
{
    public class BankTransectionDtlDAL
    {
        public void Add(BankTransectionDtlDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                PayBankTransectionDtlInfo gur = new PayBankTransectionDtlInfo();
                container.PayBankTransectionDtlInfoes.AddObject((PayBankTransectionDtlInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }
    }
}
