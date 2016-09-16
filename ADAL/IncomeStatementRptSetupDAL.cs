using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using Utility;
using DAL;

namespace ADAL
{
   public class IncomeStatementRptSetupDAL
   {
       public void Add(IncomeStatementRptDTO DTO)
       {
           using (var container = new InventoryContainer())
           {

               AccIncomeStatementRpt gur = new AccIncomeStatementRpt();
               container.AccIncomeStatementRpts.AddObject((AccIncomeStatementRpt)DTOMapper.DTOObjectConverter(DTO, gur));
               container.SaveChanges();
           }
       }

       public void Edit(IncomeStatementRptDTO DTO)
       {
           using (var container = new InventoryContainer())
           {
               var Comp = new AccIncomeStatementRpt();
               Comp = container.AccIncomeStatementRpts.FirstOrDefault(o => o.InStaRptId.Equals(DTO.InStaRptId));
               Comp.InStaRptId = DTO.InStaRptId;
               Comp.MainHeadId = DTO.MainHeadId;
               Comp.SubCode1Id = DTO.SubCode1Id;
               Comp.UpdateDate = DTO.UpdateDate;
               Comp.Priority = DTO.Priority;
               Comp.ActiveStatus = DTO.ActiveStatus;
               Comp.UpdateBy = DTO.UpdateBy;
               Comp = (AccIncomeStatementRpt)DTOMapper.DTOObjectConverter(DTO, Comp);
               container.SaveChanges();
           }
       }

       public List<IncomeStatementRptDTO> LoadIncomeStatementRpt(int id)
       {
           using (var Container = new InventoryContainer())
           {
               var query = from s in Container.AccIncomeStatementRpts
                           join main in Container.AccMainHeads on s.MainHeadId equals main.MainHeadId
                           join s1code in Container.AccSubCode1 on s.MainHeadId equals s1code.SubCode_1Id

                           select new { s, main, s1code };

               if (id != 0)
                   query = query.Where(c => c.s.InStaRptId.Equals(id));

               var result = from o in query
                            orderby o.s.Priority descending
                            select new IncomeStatementRptDTO
                            {

                                InStaRptId = o.s.InStaRptId,
                                MainHeadId = o.s.MainHeadId,
                                MainHeadName_Num = o.main.MainHadeNum + "-" + o.main.MainHeadName,
                                SubCode1Id = o.s.SubCode1Id,
                                SubCode1Name_Num = o.s1code.SubCode_1Num + "-" + o.s1code.SubCode_1Name,
                                ActiveStatus = o.s.ActiveStatus,
                                Priority = o.s.Priority,
                                CreateBy = o.s.CreateBy,
                                CreateDate = o.s.CreateDate,

                            };
               return result.ToList<IncomeStatementRptDTO>();
           }
       }


       public List<IncomeStatementRptDTO> CheckIncomeStatementRptPriority(int id)
       {
           using (var Container = new InventoryContainer())
           {
               var query = from s in Container.AccIncomeStatementRpts
                           select new { s };

               if (id != 0)
                   query = query.Where(c => c.s.InStaRptId.Equals(id));

               var result = from o in query
                            orderby o.s.InStaRptId descending
                            select new IncomeStatementRptDTO
                            {

                                InStaRptId = o.s.InStaRptId,
                                Priority = o.s.Priority,

                            };
               return result.ToList<IncomeStatementRptDTO>();
           }
       }

   }
}