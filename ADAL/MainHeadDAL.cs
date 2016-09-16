using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using Utility;
using DAL;

namespace ADAL
{
   public class MainHeadDAL
    {

       public void Add(MainHeadDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                AccMainHead gur = new AccMainHead();
                container.AccMainHeads.AddObject((AccMainHead)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

       public void Edit(MainHeadDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccMainHead();
                Comp = container.AccMainHeads.FirstOrDefault(o => o.MainHeadId.Equals(DTO.MainHeadId));
                Comp.MainHadeNum = DTO.MainHadeNum;
                Comp.MainHeadName = DTO.MainHeadName;
                Comp.AID = DTO.AID;
                Comp.Description = DTO.Description;
                Comp.UpdateDate = DTO.UpdateDate;
                Comp.UpdateBy = DTO.UpdateBy;
                // Comp.Testvalue = DTO.Testvalue;
                Comp = (AccMainHead)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

       public List<MainHeadDTO> LoadMainHead(int id)
       {
           using (var Container = new InventoryContainer())
           {
               var query = from s in Container.AccMainHeads

                           select new { s };
               //if (!string.IsNullOrEmpty(Deptname))
               //    query = query.Where(c => c.emp.EmpType.TypeName.Contains(Deptname));
               if (id != 0)
                   query = query.Where(c => c.s.MainHeadId.Equals(id));

               



               var result = from o in query
                            orderby o.s.MainHeadId descending
                         //   where o.s.MainHeadId.Equals(id)
                            select new MainHeadDTO
                            {

                                MainHeadName = o.s.MainHeadName,
                                MainHeadId = o.s.MainHeadId,
                                MainHadeNum = o.s.MainHadeNum,
                                AID = o.s.AID,
                                CreateBy = o.s.CreateBy,
                                CreateDate = o.s.CreateDate,
                                Description = o.s.Description,
                                MainHeadName_Num =o.s.MainHadeNum +"-"+ o.s.MainHeadName

                            };
               return result.ToList<MainHeadDTO>();
           }
       }
       public List<MainHeadDTO> LoadMainHead_Validation(int id,string mainheadnum, string  mainheadname)
       {
           using (var Container = new InventoryContainer())
           {
               var query = from s in Container.AccMainHeads

                           select new { s };

               if (id != 0)
                   query = query.Where(c => c.s.MainHeadId.Equals(id));
               if (!string.IsNullOrEmpty(mainheadname))
               {
                   query = query.Where(c => c.s.MainHadeNum.Contains(mainheadname));
               }
               if (!string.IsNullOrEmpty(mainheadname))
               {
                   query = query.Where(c => c.s.MainHeadName.Contains(mainheadname));
               }

               var result = from o in query
                            orderby o.s.MainHeadId descending
                            //   where o.s.MainHeadId.Equals(id)
                            select new MainHeadDTO
                            {

                                MainHeadName = o.s.MainHeadName,
                                MainHeadId = o.s.MainHeadId,
                                MainHadeNum = o.s.MainHadeNum,
                                AID = o.s.AID,
                                CreateBy = o.s.CreateBy,
                                CreateDate = o.s.CreateDate,
                                Description = o.s.Description,

                            };
               return result.ToList<MainHeadDTO>();
           }
       }

    }
}
