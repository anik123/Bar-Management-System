using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using Utility;
using DAL;

namespace ADAL
{
    public class BalanceSheetRptDAL
    {
        public void Add(BalanceSheetRptDTO DTO)
        {
            using (var container = new InventoryContainer())
            {

                AccBalanceSheetRpt gur = new AccBalanceSheetRpt();
                container.AccBalanceSheetRpts.AddObject((AccBalanceSheetRpt)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(BalanceSheetRptDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccBalanceSheetRpt();
                Comp = container.AccBalanceSheetRpts.FirstOrDefault(o => o.BalanceShtId.Equals(DTO.BalanceShtId));
                Comp.BalanceShtId = DTO.BalanceShtId;
                Comp.MainHeadId = DTO.MainHeadId;
                Comp.SubCode1Id = DTO.SubCode1Id;
                Comp.UpdateDate = DTO.UpdateDate;
                Comp.Priority = DTO.Priority;
                Comp.ActiveStatus = DTO.ActiveStatus;
                Comp.UpdateBy = DTO.UpdateBy;
                Comp = (AccBalanceSheetRpt)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public List<BalanceSheetRptDTO> LoadBalanceSheetRpt(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccBalanceSheetRpts
                            join main in Container.AccMainHeads on s.MainHeadId equals main.MainHeadId
                            join s1code in Container.AccSubCode1 on s.MainHeadId equals s1code.SubCode_1Id

                            select new { s, main, s1code };

                if (id != 0)
                    query = query.Where(c => c.s.BalanceShtId.Equals(id));

                var result = from o in query
                             orderby o.s.Priority descending
                             select new BalanceSheetRptDTO
                          {

                              BalanceShtId = o.s.BalanceShtId,
                              MainHeadId = o.s.MainHeadId,
                              MainHeadName_Num = o.main.MainHadeNum + "-" + o.main.MainHeadName,
                              SubCode1Id = o.s.SubCode1Id,
                              SubCode1Name_Num = o.s1code.SubCode_1Num + "-" + o.s1code.SubCode_1Name,
                              ActiveStatus = o.s.ActiveStatus,
                              Priority = o.s.Priority,
                              CreateBy = o.s.CreateBy,
                              CreateDate = o.s.CreateDate,

                          };
                return result.ToList<BalanceSheetRptDTO>();
            }
        }


        public List<BalanceSheetRptDTO> CheckPriorityNumber(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccBalanceSheetRpts
                            select new { s };

                if (id != 0)
                    query = query.Where(c => c.s.BalanceShtId.Equals(id));

                var result = from o in query
                             orderby o.s.BalanceShtId descending
                             select new BalanceSheetRptDTO
                             {

                                 BalanceShtId = o.s.BalanceShtId,
                                 Priority = o.s.Priority,

                             };
                return result.ToList<BalanceSheetRptDTO>();
            }
        }

    }
}
