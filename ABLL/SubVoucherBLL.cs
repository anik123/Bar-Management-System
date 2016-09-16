using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
  public  class SubVoucherBLL
    {

      SubVocherDAL DAL = new SubVocherDAL();

      // save data 
      public void Add(SubVoucherDTO DTO)
      {
          DAL.Add(DTO);
      }
      // edit or update data
      public void Edit(SubVoucherDTO DTO)
      {
          DAL.Edit(DTO);
      }

      ////load data 

      public List<SubVoucherDTO> LoadSubVoucherData(int id, int mainvoucherid)
      {
          return DAL.LoadSubVoucherData(id, mainvoucherid);
      }
      
        //generate sub voucher code no#

      public List<SubVoucherDTO> GenerateSuvCodeNo(int id)
      {
          return DAL.GenerateSuvCodeNo(id);
      }
      public List<SubVoucherDTO> LoadSubVoucherData_Validation(int id, string subvouchername)
      {
          return DAL.LoadSubVoucherData_Validation(id, subvouchername);
      }
                 

    }
}
