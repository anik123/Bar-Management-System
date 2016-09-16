using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDAL;
using PDTO;

namespace PBLL
{
    public class BankTransectionBLL
    {
        BankTransectionDAL BTDAL = new BankTransectionDAL();
        public void Add(BankTransectionDTO DTO)
        {
            BTDAL.Add(DTO);
        }
        public void Edit(BankTransectionDTO DTO)
        {
            BTDAL.Edit(DTO);
        }
        public List<BankTransectionDTO> LoadBankTransection(int accountid)
        {
            return BTDAL.LoadBankTransection(accountid);
        }

        // i think not req
        public List<BankTransectionDTO> SumOfAmount(int id)
        {
            return BTDAL.SumOfAmount(id);
        }
        public List<BankTransectionDTO> LoadTansectionId()
        {
            return BTDAL.LoadTansectionId();
        }

        // i think not req

    }
}
