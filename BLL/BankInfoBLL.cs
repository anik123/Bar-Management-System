using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAL;


namespace BLL
{
    public class BankInfoBLL
    {
        BankInfoDAL BDAL = new BankInfoDAL();

        public void Add(BankInfoDTO DTO)
        {
            BDAL.Add(DTO);
        }
        public void Edit(BankInfoDTO EduDTO)
        {
            BDAL.Edit(EduDTO);
        }

        public List<BankInfoDTO> LoadBankName(int bankid)
        {
            return BDAL.LoadBankName(bankid);
        }
    }
}