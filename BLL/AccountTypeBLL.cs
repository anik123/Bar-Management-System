using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
   public  class AccountTypeBLL
    {

       AccountTypeDAL acctypedal = new AccountTypeDAL();
       public void Add(AccountTypeDTO DTO)
       {
           acctypedal.Add(DTO);
       }

       public void Edit(AccountTypeDTO EduDTO)
       {
           acctypedal.Edit(EduDTO);
       }

        public List<AccountTypeDTO> LoadAccountTypeName(int accountypeid)
        {
            return acctypedal.LoadAccountTypeName(accountypeid);
        }
    }
}
