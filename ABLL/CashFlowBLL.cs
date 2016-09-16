using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
   public  class CashFlowBLL
    {
       CashFlowEntityDAL Dal = new CashFlowEntityDAL();

       public void Add(CashFolwEntityDTO DTO)
       {
           Dal.Add(DTO);
       }
       public void Edit(CashFolwEntityDTO DTO)
       {
           Dal.Edit(DTO);
       }
       public List<CashFolwEntityDTO> LoadCashFlowEntity(int id)
       {
           return Dal.LoadCashFlowEntity(id);
       }
    }
}
