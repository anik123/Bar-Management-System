using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDAL;
using PDTO;

namespace PBLL
{
   public class AssetBLL
    {
       AssetDAL dal = new AssetDAL();
       public void Add(AssetDTO DTO)
       {
           dal.Add(DTO);
       }
       public void Edit(AssetDTO EduDTO)
       {
           dal.Edit(EduDTO);
       }
       public List<AssetDTO> Asset_Current()
       {
           return dal.Asset_Current();
       }
    }
}
