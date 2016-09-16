using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class BankAccountInfoBLL
    {
        AccountInfoDAL ADAL = new AccountInfoDAL();
        public void Add(AccountInfoDTO DTO)
        {
            ADAL.Add(DTO);
        }

        public void Edit(AccountInfoDTO EduDTO)
        {
            ADAL.Edit(EduDTO);
        }

        public List<AccountInfoDTO> LoadAccountInfo(int AccID, int BankID, string bankname, string branchname, string accname, string accnum)
        {
            return ADAL.LoadAccountInfo(AccID, BankID, bankname, branchname, accname, accnum);
        }


        // load accounttype 
        public List<AccountTypeDTO> LoadAccountType()
        {
            return ADAL.LoadAccountType();
        }

        //load account name for bnak transection aspx
        public List<AccountInfoDTO> AccountNameLoad()
        {
            return ADAL.AccountNameLoad();
        }
    }
}
