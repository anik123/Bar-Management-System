using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
   public class MainVoucherBLL
    {
       MainVoucherDAL DAL = new MainVoucherDAL();
       // save main voucher datar

       public void Add(MainVoucherDTO DTO)
       {
           DAL.Add(DTO);
       }
       // update data
       public void Edit(MainVoucherDTO DTO)
       {
           DAL.Edit(DTO);
       }
       // load data 
       public List<MainVoucherDTO> LoadMainVocher(int id)
       {
           return DAL.LoadMainVocher(id);
       }

    }
}
