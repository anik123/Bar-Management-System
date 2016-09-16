using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using Utility;
using DAL;

namespace ADAL
{
    public class COAInfoDAL
    {
        public void Add(COAInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                AccCOAInfo gur = new AccCOAInfo();
                container.AccCOAInfoes.AddObject((AccCOAInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(COAInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccCOAInfo();
                Comp = container.AccCOAInfoes.FirstOrDefault(o => o.COAId.Equals(DTO.COAId));
                Comp.COAACCId = DTO.COAACCId;
                Comp.AccountName = DTO.AccountName;
                Comp.AID = DTO.AID;
                Comp.SubCode_2Id = DTO.SubCode_2Id;
                Comp.APPID = DTO.APPID;
                Comp.Description = DTO.Description;
                Comp.Status = DTO.Status;
                Comp.Balance = DTO.Balance;
                Comp.OpenBy = DTO.OpenBy;
                Comp.OpeningDate = DTO.OpeningDate;
                Comp.UpdateDate = DTO.UpdateDate;
                Comp.UpdateBy = DTO.UpdateBy;
                Comp = (AccCOAInfo)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        // load data for main vocher page
        public List<COAInfoDTO> LoadCoAInfo(int id,string CoaNo, string accountName,   int subcode_2id, string s2no, string s2name, string s1no, string s1name, string MHeadNo,string MHeadname)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccCOAInfoes
                            join s2 in Container.AccSubCode2 on s.SubCode_2Id equals s2.SubCode2_Id
                            select new { s, s2 };

                if (id != 0)
                    query = query.Where(c => c.s.COAId.Equals(id));
                if (!string.IsNullOrEmpty(CoaNo))
                    query = query.Where(c => c.s.COAACCId.Contains(CoaNo));
                if (!string.IsNullOrEmpty(accountName))
                    query = query.Where(c => c.s.AccountName.Contains(accountName));
                if (subcode_2id != 0)
                    query = query.Where(c => c.s2.SubCode2_Id.Equals(subcode_2id));

                if (!string.IsNullOrEmpty(s2no))
                    query = query.Where(c => c.s2.SubCode2_Num.Contains(s2no));
                if (!string.IsNullOrEmpty(s2name))
                    query = query.Where(c => c.s2.SubCode_2Name. Contains(s2name));
                if (!string.IsNullOrEmpty(s1no))
                    query = query.Where(c => c.s2.AccSubCode1.SubCode_1Num.Contains(s1no));
                if (!string.IsNullOrEmpty(s1name))
                    query = query.Where(c =>  c.s2.AccSubCode1.SubCode_1Name.Contains(s1name));
                if (!string.IsNullOrEmpty(MHeadNo))
                    query = query.Where(c => c.s2.AccSubCode1.AccMainHead.MainHadeNum. Contains(MHeadNo));
                if (!string.IsNullOrEmpty(MHeadname))
                    query = query.Where(c =>  c.s2.AccSubCode1.AccMainHead.MainHeadName.Contains(MHeadname));
             
                var result = from o in query
                             orderby o.s.COAId descending
                             select new COAInfoDTO
                          {
                              COAId = o.s.COAId,
                              COAACCId = o.s.COAACCId,
                              AccountName = o.s.AccountName,
                              AID = o.s.AID,
                              APPID = o.s.APPID,
                              Description = o.s.Description,
                              Status = o.s.Status,
                              Balance = o.s.Balance,
                              OpeningDate = o.s.OpeningDate,
                              OpenBy = o.s.OpenBy,
                              UpdateBy = o.s.UpdateBy,
                              UpdateDate = o.s.UpdateDate,
                             

                              COAName_Num = o.s.COAACCId + "-" + o.s.AccountName,

                              SubCode_2Id = o.s2.SubCode2_Id,
                              SubCode_2Name = o.s2.SubCode_2Name,
                              SubCode2_Num = o.s2.SubCode2_Num,

                              SubCode_1Id = o.s2.AccSubCode1.SubCode_1Id,
                              SubCode_1Num = o.s2.AccSubCode1.SubCode_1Num,
                              SubCode_1Name = o.s2.AccSubCode1.SubCode_1Name,

                              MainHeadId = o.s2.AccSubCode1.AccMainHead.MainHeadId,
                              MainHeadName = o.s2.AccSubCode1.AccMainHead.MainHeadName,
                              MainheadNum = o.s2.AccSubCode1.AccMainHead.MainHadeNum

                          };
                return result.ToList<COAInfoDTO>();
            }
        }

        // edit for journal update page
        public void Edit_COAUpdate(COAInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccCOAInfo();
                Comp = container.AccCOAInfoes.FirstOrDefault(o => o.COAId.Equals(DTO.COAId));

                Comp.COAId = DTO.COAId;
                Comp.Balance = DTO.Balance;
                Comp = (AccCOAInfo)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
    }
}
