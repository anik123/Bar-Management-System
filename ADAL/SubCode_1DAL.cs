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
    public class SubCode_1DAL
    {

        public void Add(SubCode_1DTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                AccSubCode1 gur = new AccSubCode1();
                container.AccSubCode1.AddObject((AccSubCode1)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(SubCode_1DTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccSubCode1();
                Comp = container.AccSubCode1.FirstOrDefault(o => o.SubCode_1Id.Equals(DTO.SubCode_1Id));
                Comp.AID = DTO.AID;
                Comp.AssetType = DTO.AssetType;
                Comp.Balance = DTO.Balance;
                Comp.Description = DTO.Description;
                Comp.MainHeadId = DTO.MainHeadId;
                Comp.SubCode_1Name = DTO.SubCode_1Name;
                Comp.SubCode_1Num = DTO.SubCode_1Num;
                Comp.UpdateDate = DTO.UpdateDate;
                Comp.UpdateBy = DTO.UpdateBy;
                Comp = (AccSubCode1)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        // load data for  page
        public List<SubCode_1DTO> LoadSuvCode_1Data(int id, string SubcodeNum, string SubCodename,int mainheadid,  string mainheadname, string mainheadno)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccSubCode1
                            join mainhead in Container.AccMainHeads on s.MainHeadId equals mainhead.MainHeadId

                            select new { s, mainhead };

                if (id != 0)
                    query = query.Where(c => c.s.SubCode_1Id.Equals(id));

                if (!string.IsNullOrEmpty(SubcodeNum))
                    query = query.Where(c => c.s.SubCode_1Num.Contains(SubcodeNum));

                if (!string.IsNullOrEmpty(SubCodename))
                    query = query.Where(c => c.s.SubCode_1Name.Contains(SubCodename));

                if (mainheadid != 0)
                    query = query.Where(c => c.mainhead.MainHeadId.Equals(mainheadid));
                if (!string.IsNullOrEmpty(mainheadname))
                    query = query.Where(c => c.mainhead.MainHeadName.Contains(mainheadname));
                if (!string.IsNullOrEmpty(mainheadno))
                    query = query.Where(c => c.mainhead.MainHadeNum.Contains(mainheadno));
                var result = from o in query
                             orderby o.s.SubCode_1Id descending
                             select new SubCode_1DTO
                    {
                        AID = o.s.AID,
                        AssetType = o.s.AssetType,
                        Balance = o.s.Balance,
                        CreateBy = o.s.CreateBy,
                        CreateDate = o.s.CreateDate,
                        Description = o.s.Description,
                        SubCode_1Id = o.s.SubCode_1Id,
                        SubCode_1Name = o.s.SubCode_1Name,
                        SubCode_1Num = o.s.SubCode_1Num,

                        MainHeadId = o.mainhead.MainHeadId,
                        MainHeadName = o.mainhead.MainHeadName,
                        MainheadNum = o.mainhead.MainHadeNum,

                        SubCode1Name_Num=o.s.SubCode_1Num+"-"+ o.s.SubCode_1Name
                    };
                return result.ToList<SubCode_1DTO>();
            }
        }

        //load for liabilities dropdownlist
 
        public List<SubCode_1DTO> LoadSuvCode_1Data_Liabilities()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccSubCode1
                            join mainhead in Container.AccMainHeads on s.MainHeadId equals mainhead.MainHeadId

                            select new { s, mainhead };

                          var result = from o in query
                             where o.mainhead.MainHadeNum=="7000"
                             orderby o.s.SubCode_1Id descending
                             select new SubCode_1DTO
                             {
                                 AID = o.s.AID,
                                 AssetType = o.s.AssetType,
                                 Balance = o.s.Balance,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,
                                 Description = o.s.Description,
                                 SubCode_1Id = o.s.SubCode_1Id,
                                 SubCode_1Name = o.s.SubCode_1Name,
                                 SubCode_1Num = o.s.SubCode_1Num,

                                 MainHeadId = o.mainhead.MainHeadId,
                                 MainHeadName = o.mainhead.MainHeadName,
                                 MainheadNum = o.mainhead.MainHadeNum,

                                 SubCode1Name_Num = o.s.SubCode_1Num + "-" + o.s.SubCode_1Name
                             };
                return result.ToList<SubCode_1DTO>();
            }
        }
    }
}
