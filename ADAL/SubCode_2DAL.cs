using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using ADAL;
using Utility;
using DAL;

namespace ADAL
{
    public class SubCode_2DAL
    {

        public void Add(SubCode_2DTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                AccSubCode2 gur = new AccSubCode2();
                container.AccSubCode2.AddObject((AccSubCode2)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(SubCode_2DTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccSubCode2();
                Comp = container.AccSubCode2.FirstOrDefault(o => o.SubCode2_Id.Equals(DTO.SubCode_2Id));
                Comp.AID = DTO.AID;
                Comp.AssetType = DTO.AssetType;
                Comp.Balance = DTO.Balance;
                Comp.Description = DTO.Description;
                Comp.SubCode_1Id = DTO.SubCode_1Id;
                Comp.SubCode_2Name = DTO.SubCode_2Name;
                Comp.SubCode2_Num = DTO.SubCode2_Num;
                Comp.UpdateDate = DTO.UpdateDate;
                Comp.UpdateBy = DTO.UpdateBy;
                Comp = (AccSubCode2)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        // load data for  page
        public List<SubCode_2DTO> LoadSuvCode_2Data(int id, string Subcode2Num, string SubCode2name, int sucodeid1, string subc1no, string subcode1name, string mainheadno, string mainheadname)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccSubCode2
                            join subcode1 in Container.AccSubCode1 on s.SubCode_1Id equals subcode1.SubCode_1Id
                            join  mainhead in Container.AccMainHeads on subcode1.MainHeadId equals mainhead.MainHeadId
                            select new { s, subcode1,mainhead };

                if (id != 0)
                    query = query.Where(c => c.s.SubCode2_Id.Equals(id));
                if (!string.IsNullOrEmpty(Subcode2Num))
                    query = query.Where(c => c.s.SubCode2_Num.Contains(Subcode2Num));
                if (!string.IsNullOrEmpty(SubCode2name))
                    query = query.Where(c => c.s.SubCode_2Name.Contains(SubCode2name));
                if (sucodeid1 != 0)
                    query = query.Where(c => c.subcode1.SubCode_1Id.Equals(sucodeid1));

                if (!string.IsNullOrEmpty(subc1no))
                    query = query.Where(c => c.subcode1.SubCode_1Num.Contains(subc1no));
                if (!string.IsNullOrEmpty(subcode1name))
                    query = query.Where(c => c.subcode1.SubCode_1Name.Contains(subcode1name));
                if (!string.IsNullOrEmpty(mainheadno))
                    query = query.Where(c => c.mainhead.MainHadeNum.Contains(mainheadno));
                if (!string.IsNullOrEmpty(mainheadname))
                    query = query.Where(c => c.mainhead.MainHeadName.Contains(mainheadname));
               
                var result = from o in query
                             orderby o.s.SubCode2_Id descending
                             select new SubCode_2DTO
                    {
                        AID = o.s.AID,
                        AssetType = o.s.AssetType,
                        Balance = o.s.Balance,
                        CreateBy = o.s.CreateBy,
                        CreateDate = o.s.CreateDate,
                        Description = o.s.Description,
                        SubCode_2Id = o.s.SubCode2_Id,
                        SubCode_2Name = o.s.SubCode_2Name,
                        SubCode2_Num = o.s.SubCode2_Num,

                        SubCode2Name_Num=o.s.SubCode2_Num +"-" +o.s.SubCode_2Name,

                        SubCode_1Id = o.subcode1.SubCode_1Id,
                        SubCode_1Name = o.subcode1.SubCode_1Name,
                        SubCode_1Num = o.subcode1.SubCode_1Num,

                        MainHeadId = o.mainhead.MainHeadId,
                        MainHeadName = o.mainhead.MainHeadName,
                        MainheadNum = o.mainhead.MainHadeNum
                    };
                return result.ToList<SubCode_2DTO>();
            }
        }

        // load data for  COA Page
        public List<SubCode_2DTO> LoadSuvCode_2Data_COAPage(int SubcodeNum, string SubCodename, int maincodeid, int sucodeid1, int subcode2id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccSubCode2
                            join subcode1 in Container.AccSubCode1 on s.SubCode_1Id equals subcode1.SubCode_1Id
                            join main in Container.AccMainHeads on subcode1.MainHeadId equals main.MainHeadId
                            select new { s, subcode1,main };

                if (subcode2id != 0)
                    query = query.Where(c => c.s.SubCode2_Id.Equals(subcode2id));

                if (SubcodeNum != 0)
                    query = query.Where(c => c.s.SubCode2_Num.Equals(SubcodeNum));
                if (!string.IsNullOrEmpty(SubCodename))
                    query = query.Where(c => c.s.SubCode_2Name.Contains(SubCodename));
                if (maincodeid != 0)
                    query = query.Where(c => c.main.MainHeadId.Equals(maincodeid));
                if (sucodeid1 != 0)
                    query = query.Where(c => c.subcode1.SubCode_1Id.Equals(sucodeid1));
                var result = from o in query
                             orderby o.s.SubCode2_Id descending
                             select new SubCode_2DTO
                             {
                                 AID = o.s.AID,
                                 AssetType = o.s.AssetType,
                                 Balance = o.s.Balance,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,
                                 Description = o.s.Description,
                                 SubCode_2Id = o.s.SubCode2_Id,
                                 SubCode_2Name = o.s.SubCode_2Name,
                                 SubCode2_Num = o.s.SubCode2_Num,

                                 SubCode_1Id = o.subcode1.SubCode_1Id,
                                 SubCode_1Name = o.subcode1.SubCode_1Name,
                                 SubCode_1Num = o.subcode1.SubCode_1Num,

                                 MainHeadId = o.subcode1.AccMainHead.MainHeadId,
                                 MainHeadName = o.subcode1.AccMainHead.MainHeadName,
                                 MainheadNum = o.subcode1.AccMainHead.MainHadeNum
                             };
                return result.ToList<SubCode_2DTO>();
            }
        }
    }
}

