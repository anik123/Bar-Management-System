using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
 public   class LiabilitiesRptBLL
 {
     LiabilitiesRptDAL dal = new LiabilitiesRptDAL();

     public void Add(LiabilitiesRptDTO DTO)
     {
         dal.Add(DTO);
     }
     public void Edit(LiabilitiesRptDTO DTO)
     {
         dal.Edit(DTO);
     }
     public List<LiabilitiesRptDTO> LoadLiabilitiesRptData(int id)
     {
         return dal.LoadLiabilitiesRptData(id);
     }
     public List<LiabilitiesRptDTO> CheckPriorityNumber_liabilities(int id)
     {
         return dal.CheckPriorityNumber_liabilities(id);
     }
    }
}
