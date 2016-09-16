using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
   public class UnitBLL
    {
     //  Unit dal =new Unit();
       UnitDAL DAL = new UnitDAL();
       public void Add(UnitDTO DTO)
       {
           DAL.Add(DTO);
       }
       public void Edit(UnitDTO DTO)
       {
           DAL.Edit(DTO);
       }
       public List<UnitDTO> GetUnit(int id, string unit)
       {
           return DAL.GetUnit(id,unit);
       }  
    }
}
