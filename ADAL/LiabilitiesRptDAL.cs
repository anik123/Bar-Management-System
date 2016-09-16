using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using Utility;
using DAL;

namespace ADAL
{
    public class LiabilitiesRptDAL
    {
        public void Add(LiabilitiesRptDTO DTO)
        {
            using (var container = new InventoryContainer())
            {

                AccLiabilitiesRpt gur = new AccLiabilitiesRpt();
                container.AccLiabilitiesRpts.AddObject((AccLiabilitiesRpt)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(LiabilitiesRptDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccLiabilitiesRpt();
                Comp = container.AccLiabilitiesRpts.FirstOrDefault(o => o.LiabRptId.Equals(DTO.LiabRptId));
                Comp.LiabRptId = DTO.LiabRptId;
                Comp.MainHeadId = DTO.MainHeadId;
                Comp.SubCode1Id = DTO.SubCode1Id;
                Comp.UpdateDate = DTO.UpdateDate;
                Comp.Priority = DTO.Priority;
                Comp.ActiveStatus = DTO.ActiveStatus;
                Comp.UpdateBy = DTO.UpdateBy;
                Comp = (AccLiabilitiesRpt)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public List<LiabilitiesRptDTO> LoadLiabilitiesRptData(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccLiabilitiesRpts
                            join main in Container.AccMainHeads on s.MainHeadId equals main.MainHeadId
                            join s1code in Container.AccSubCode1 on s.MainHeadId equals s1code.SubCode_1Id

                            select new { s, main, s1code };

                if (id != 0)
                    query = query.Where(c => c.s.LiabRptId.Equals(id));

                var result = from o in query
                             orderby o.s.Priority descending
                             select new LiabilitiesRptDTO
                             {

                                 LiabRptId = o.s.LiabRptId,
                                 MainHeadId = o.s.MainHeadId,
                                 MainHeadName_Num = o.main.MainHadeNum + "-" + o.main.MainHeadName,
                                 SubCode1Id = o.s.SubCode1Id,
                                 SubCode1Name_Num = o.s1code.SubCode_1Num + "-" + o.s1code.SubCode_1Name,
                                 ActiveStatus = o.s.ActiveStatus,
                                 Priority = o.s.Priority,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,

                             };
                return result.ToList<LiabilitiesRptDTO>();
            }
        }


        public List<LiabilitiesRptDTO> CheckPriorityNumber_liabilities(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccLiabilitiesRpts
                            select new { s };

                if (id != 0)
                    query = query.Where(c => c.s.LiabRptId.Equals(id));

                var result = from o in query
                             orderby o.s.LiabRptId descending
                             select new LiabilitiesRptDTO
                             {

                                 LiabRptId = o.s.LiabRptId,
                                 Priority = o.s.Priority,

                             };
                return result.ToList<LiabilitiesRptDTO>();
            }
        }

    }
}
