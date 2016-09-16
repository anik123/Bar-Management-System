using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using Utility;
using DAL;

namespace ADAL
{
    public class JournalDAL
    {
        public void Add(JournalDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                AccJournalEntry gur = new AccJournalEntry();
                container.AccJournalEntries.AddObject((AccJournalEntry)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(JournalDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccJournalEntry();
                Comp = container.AccJournalEntries.FirstOrDefault(o => o.JournalId.Equals(DTO.JournalId));
                Comp.SubCode2Id = DTO.SubCode2Id;
                Comp.COAId = DTO.COAId;
                Comp.SubVoucherId = DTO.SubVoucherId;
                Comp.TransectionNo = DTO.TransectionNo;
                Comp.DRAmount = DTO.DRAmount;
                Comp.CRAmount = DTO.CRAmount;
                Comp.TransectionDate = DTO.TransectionDate;
                Comp.JournalType = DTO.JournalType;
                Comp.VONO = DTO.VONO;
                Comp.Remarks = DTO.Remarks;
                Comp.PostLeadgerStatus = DTO.PostLeadgerStatus;
                Comp.UpdateDate = DTO.UpdateDate;
                Comp.UpdateBy = DTO.UpdateBy;
                Comp = (AccJournalEntry)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        // edit for journal update page
        public void Edit_JournalUpdate(JournalDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccJournalEntry();
                Comp = container.AccJournalEntries.FirstOrDefault(o => o.JournalId.Equals(DTO.JournalId));

                Comp.JournalId = DTO.JournalId;
                Comp.PostLeadgerStatus = DTO.PostLeadgerStatus;
                Comp = (AccJournalEntry)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        // load data for  page
        public List<JournalDTO> LoadJournalData_update(int jounalid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccJournalEntries
                            join s2 in Container.AccSubCode2 on s.SubCode2Id equals s2.SubCode2_Id
                            join SV in Container.AccSubVouchers on s.SubVoucherId equals SV.SubVoucherId
                            join coa in Container.AccCOAInfoes on s.COAId equals coa.COAId
                            select new { s, s2, SV, coa };

                if (jounalid != 0)
                    query = query.Where(c => c.s.JournalId.Equals(jounalid));

                var result = from o in query

                             where o.s.PostLeadgerStatus == "N"
                             orderby o.s.JournalId descending
                             select new JournalDTO
                             {
                                 JournalId = o.s.JournalId,
                                 TransectionNo = o.s.TransectionNo,
                                 DRAmount = o.s.DRAmount,
                                 CRAmount = o.s.CRAmount,
                                 TransectionDate = o.s.TransectionDate,
                                 VONO = o.s.VONO,
                                 MRNO = o.s.MRNO,
                                 Remarks = o.s.Remarks,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,
                                 UpdateBy = o.s.UpdateBy,
                                 UpdateDate = o.s.UpdateDate,
                                 JournalType = o.s.JournalType,

                                 SubCode2Id = o.s2.SubCode2_Id,
                                 SubCode2Name_Num = o.s2.SubCode2_Num + "-" + o.s2.SubCode_2Name,


                                 COAId = o.coa.COAId,
                                 COAName_Num = o.coa.COAACCId + "-" + o.coa.AccountName,

                                 SubVoucherId = o.SV.SubVoucherId,
                                 SubVoucherCodeName = o.SV.SubVoucherCode + "-" + o.SV.SubVoucherName

                             };
                return result.ToList<JournalDTO>();
            }
        }

        // Load transection No
        public List<JournalDTO> Load_Journal_Transection_No()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccJournalEntries
                            select new { s };


                var result = from o in query
                             orderby o.s.JournalId descending
                             select new JournalDTO
                             {
                                 JournalId = o.s.JournalId,
                                 TransectionNo = o.s.TransectionNo,

                             };
                return result.ToList<JournalDTO>();
            }
        }



        // load data for  update journal link button
        public List<JournalDTO> LoadJournalUpdate_ladger(int jounalid, int transectionno)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccJournalEntries
                            join s2 in Container.AccSubCode2 on s.SubCode2Id equals s2.SubCode2_Id
                            join SV in Container.AccSubVouchers on s.SubVoucherId equals SV.SubVoucherId
                            join coa in Container.AccCOAInfoes on s.COAId equals coa.COAId
                            select new { s, s2, SV, coa };

                if (jounalid != 0)
                    query = query.Where(c => c.s.JournalId.Equals(jounalid));
                if (transectionno != 0)
                    query = query.Where(c => c.s.TransectionNo.Equals(transectionno));

                var result = from o in query

                             where o.s.PostLeadgerStatus == "N"
                             orderby o.s.JournalId ascending
                             select new JournalDTO
                             {
                                 JournalId = o.s.JournalId,
                                 TransectionNo = o.s.TransectionNo,
                                 DRAmount = o.s.DRAmount,
                                 CRAmount = o.s.CRAmount,
                                 TransectionDate = o.s.TransectionDate,
                                 VONO = o.s.VONO,
                                 MRNO = o.s.MRNO,
                                 Remarks = o.s.Remarks,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,
                                 UpdateBy = o.s.UpdateBy,
                                 UpdateDate = o.s.UpdateDate,

                                 JournalType = o.s.JournalType,

                                 SubCode2Id = o.s2.SubCode2_Id,
                                 SubCode2Name_Num = o.s2.SubCode2_Num + "-" + o.s2.SubCode_2Name,


                                 COAId = o.coa.COAId,
                                 COAName_Num = o.coa.COAACCId + "-" + o.coa.AccountName,

                                 SubVoucherId = o.SV.SubVoucherId,
                                 SubVoucherCodeName = o.SV.SubVoucherCode + "-" + o.SV.SubVoucherName,

                                 MainVoucherId = o.SV.AccMainVoucher.MainVoucherId,
                                 MainVoucherCode_Name = o.SV.AccMainVoucher.MainVoucherCode + "-" + o.SV.AccMainVoucher.MainVoucherName,

                                 SubCode_1Id = o.s2.AccSubCode1.SubCode_1Id,
                                 SubCode1Name_Num = o.s2.AccSubCode1.SubCode_1Num + "-" + o.s2.AccSubCode1.SubCode_1Name,


                                 MainHeadId = o.s2.AccSubCode1.AccMainHead.MainHeadId,
                                 MainHeadName_Num = o.s2.AccSubCode1.AccMainHead.MainHadeNum + "-" + o.s2.AccSubCode1.AccMainHead.MainHeadName


                             };
                return result.ToList<JournalDTO>();
            }
        }
        // load data for  update journal for purchae duepayment load
        public List<JournalDTO> LoadJournalUpdate_Purchase_DuePayment(int coaid, int subcode2id, string referenceentity)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccJournalEntries
                            join s2 in Container.AccSubCode2 on s.SubCode2Id equals s2.SubCode2_Id
                            join SV in Container.AccSubVouchers on s.SubVoucherId equals SV.SubVoucherId
                            join coa in Container.AccCOAInfoes on s.COAId equals coa.COAId
                            select new { s, s2, SV, coa };

                if (coaid != 0)
                    query = query.Where(c => c.coa.COAId.Equals(coaid));
                if (subcode2id != 0)
                    query = query.Where(c => c.s2.SubCode2_Id.Equals(subcode2id));


                if (!string.IsNullOrEmpty(referenceentity))
                    query = query.Where(c => c.s.ReferenceEntity.Contains(referenceentity));


                var result = from o in query
                             select new JournalDTO
                     {
                         JournalId = o.s.JournalId,
                         CRAmount = o.s.CRAmount,
                         COAId = o.coa.COAId,
                         SubVoucherId = o.SV.SubVoucherId,
                         SubCode2Id = o.s2.SubCode2_Id,

                     };
                return result.ToList<JournalDTO>();
            }
        }
        // edit for journal update page
        public void Edit_Journal_Due_Payment(JournalDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccJournalEntry();
                Comp = container.AccJournalEntries.FirstOrDefault(o => o.JournalId.Equals(DTO.JournalId));

                Comp.JournalId = DTO.JournalId;
                Comp.CRAmount = DTO.CRAmount;
                Comp = (AccJournalEntry)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
    }
}
