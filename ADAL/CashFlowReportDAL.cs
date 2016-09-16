using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using Utility;
using DAL;

namespace ADAL
{
    public class CashFlowReportDAL
    {
        public void Add(CashFlowReportDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                AccCashFlowReport gur = new AccCashFlowReport();
                container.AccCashFlowReports.AddObject((AccCashFlowReport)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(CashFlowReportDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccCashFlowReport();
                Comp = container.AccCashFlowReports.FirstOrDefault(o => o.CFRId.Equals(DTO.CFRId));
                Comp.CFEId = DTO.CFEId;
                Comp.CFEId = DTO.CFEId;
                Comp.SubCode_1Id = DTO.SubCode_1Id;
                Comp.COAId = DTO.COAId;
            
                Comp.ActiveStatus = DTO.ActiveStatus;
                Comp.UpdateDate = DTO.UpdateDate;
                Comp.UpdateBy = DTO.UpdateBy;

                Comp = (AccCashFlowReport)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public List<CashFlowReportDTO> LoadCashFlowRptData(int crid, string cfname, string coaname, string subcode2name, string subcode1name, string mainheadname)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from cr in Container.AccCashFlowReports
                            join cf in Container.AccCashFlowEntities on cr.CFEId equals cf.CFEId

                            join coa in Container.AccCOAInfoes on cr.COAId equals coa.COAId
                            join s2 in Container.AccSubCode2 on coa.SubCode_2Id equals s2.SubCode2_Id
                            join s1 in Container.AccSubCode1 on cr.SubCode_1Id equals s1.SubCode_1Id
                            join main in Container.AccMainHeads on s1.MainHeadId equals main.MainHeadId
                            select new { cr, cf, coa, s2, s1, main };

                if (crid != 0)
                    query = query.Where(c => c.cr.CFRId.Equals(crid));

                if (!string.IsNullOrEmpty(cfname))
                    query = query.Where(c => c.cf.CFEName.Contains(cfname));
                if (!string.IsNullOrEmpty(coaname))
                    query = query.Where(c => c.coa.AccountName.Contains(coaname));
                if (!string.IsNullOrEmpty(subcode2name))
                    query = query.Where(c => c.s2.SubCode_2Name.Contains(subcode2name));
                if (!string.IsNullOrEmpty(subcode1name))
                    query = query.Where(c => c.s1.SubCode_1Name.Contains(subcode1name));
                if ( !string.IsNullOrEmpty(mainheadname))
                    query= query. Where(c=>c.main.MainHeadName.Contains(mainheadname));

                var result = from o in query
                             orderby o.cr.CFRId descending
                             select new CashFlowReportDTO
                             {

                                 CFRId = o.cr.CFRId,
                                
                                 ActiveStatus = o.cr.ActiveStatus,
                                 CreateDate = o.cr.CreateDate,
                                 CreateBy = o.cr.CreateBy,
                                // Prin

                                 CFEId = o.cf.CFEId,
                                 CFEName = o.cf.CFEName,
                                 Priority=o.cf.Priority,

                                 SubCode_1Id = o.s1.SubCode_1Id,
                                 SubCode_1Name=o.s1.SubCode_1Name,
                                 SubCode1Name_Num = o.s1.SubCode_1Num + "-" + o.s1.SubCode_1Name,

                                 SubCode2Id = o.s2.SubCode2_Id,
                                 SubCode_2Name=o.s2.SubCode_2Name,
                                 SubCode2Name_Num = o.s2.SubCode2_Num + "-" + o.s2.SubCode_2Name,

                                 MainHeadId = o.main.MainHeadId,
                                 MainHeadName= o.main.MainHeadName,
                                 MainHeadName_Num = o.main.MainHadeNum + "-" + o.main.MainHeadName,

                                 COAId = o.coa.COAId,
                                 AccountName=o.coa.AccountName,
                                 COAName_Num = o.coa.COAACCId + "-" + o.coa.AccountName,


                             };
                return result.ToList<CashFlowReportDTO>();
            }
        }
    }
}
