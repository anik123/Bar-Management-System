using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
  public   class MainHeadBLL
    {
      MainHeadDAL Dal = new MainHeadDAL();

      // save methode
      public void Add(MainHeadDTO DTO)
      {
          Dal.Add(DTO);
      }
      // edit methode
      public void Edit(MainHeadDTO DTO)
      {
          Dal.Edit(DTO);
      }

      public List<MainHeadDTO> LoadMainHead(int id)
      {
          return Dal.LoadMainHead(id);
      }
      public List<MainHeadDTO> LoadMainHead_Validation(int id, string mainheadnum, string mainheadname)
      {
          return Dal.LoadMainHead_Validation(id, mainheadname, mainheadnum);
      }


    }
}
