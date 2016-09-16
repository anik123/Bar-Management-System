using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using Utility;
using DAL;
namespace ADAL
{
    public class TransDetailsDAL
    {

        public void Add(TransDetailsDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                AccTransDetail gur = new AccTransDetail();
                container.AccTransDetails.AddObject((AccTransDetail)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public List<TransDetailsDTO> LoadTransDetailsData_DR(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from trandetails in Container.AccTransDetails
                            join tranitem in Container.AccTranItems on trandetails.TranId equals tranitem.TranId
                            join subcode2 in Container.AccSubCode2 on trandetails.DRSubCoId2 equals subcode2.SubCode2_Id
                            join coaid in Container.AccCOAInfoes on trandetails.DRCOAId equals coaid.COAId
                            join subvoucher in Container.AccSubVouchers on trandetails.DrSubVoucherId equals subvoucher.SubVoucherId

                            join subcode1 in Container.AccSubCode1 on subcode2.SubCode_1Id equals subcode1.SubCode_1Id
                            join mainhead in Container.AccMainHeads on subcode1.MainHeadId equals mainhead.MainHeadId

                            select new { trandetails, tranitem, subcode2, coaid, subvoucher, subcode1, mainhead };
                if (id != 0)
                    query = query.Where(c => c.trandetails.AccTransDtlId.Equals(id));


                var result = from o in query
                             orderby o.trandetails.AccTransDtlId descending
                             select new TransDetailsDTO
                       {

                           TranId = o.tranitem.TranId,


                           AccTransDtlId = o.trandetails.AccTransDtlId,
                           CreateBy = o.trandetails.CreateBy,
                           CreateDate = o.trandetails.CreateDate,

                           DRMainHeadId = o.mainhead.MainHeadId,
                          // CRMainHeadId = o.mainhead.MainHeadId,
                           MainHeadName_Num = o.mainhead.MainHadeNum + "-" + o.mainhead.MainHeadName,


                           //DRMainHeadId = o.subcode2.AccSubCode1.AccMainHead.MainHeadId,
                           //CRMainHeadId = o.subcode2.AccSubCode1.AccMainHead.MainHeadId,
                           //MainHeadName_Num = o.subcode2.AccSubCode1.AccMainHead.MainHadeNum + "-" + o.subcode2.AccSubCode1.AccMainHead.MainHeadName,
                           ////  CrMainHeadName = o.subcode2.AccSubCode1.AccMainHead.MainHadeNum + "-" + o.subcode2.AccSubCode1.AccMainHead.MainHeadName,

                           DRSubCoId1 = o.subcode1.SubCode_1Id,
                          // CRSubCoId1 = o.subcode1.SubCode_1Id,
                           //DrSubCode1Num = o.subcode2.AccSubCode1.SubCode_1Num + "-" + o.subcode2.AccSubCode1.SubCode_1Num,
                           SubCode1Name_Num = o.subcode1.SubCode_1Num + "-" + o.subcode1.SubCode_1Name,


                           //DRSubCoId1 = o.subcode2.AccSubCode1.SubCode_1Id,
                           //CRSubCoId1 = o.subcode2.AccSubCode1.SubCode_1Id,
                           ////DrSubCode1Num = o.subcode2.AccSubCode1.SubCode_1Num + "-" + o.subcode2.AccSubCode1.SubCode_1Num,
                           //SubCode1Name_Num = o.subcode2.AccSubCode1.SubCode_1Num + "-" + o.subcode2.AccSubCode1.SubCode_1Num,

                           DRSubCoId2 = o.subcode2.SubCode2_Id,
                           //CRSubCoId2 = o.subcode2.SubCode2_Id,
                           //  CrSubCode2Num = o.subcode2.SubCode2_Num + "-" + o.subcode2.SubCode_2Name,
                           SubCode2Name_Num = o.subcode2.SubCode2_Num + "-" + o.subcode2.SubCode_2Name,

                          // CRCOAId = o.coaid.COAId,
                           DRCOAId = o.coaid.COAId,
                           COAName_Num = o.coaid.COAACCId + "-" + o.coaid.AccountName,
                           //CRCOAIdNum = o.coaid.COAACCId + "-" + o.coaid.AccountName,


                           DRMainVoucherId = o.subvoucher.AccMainVoucher.MainVoucherId,
                           //CRMainVoucherId = o.subvoucher.AccMainVoucher.MainVoucherId,
                           // DrMainVocerCodeName = o.subvoucher.AccMainVoucher.MainVoucherName,
                           MainVoucherCode_Name = o.subvoucher.AccMainVoucher.MainVoucherName,


                           //CrSubVoucherId = o.subvoucher.SubVoucherId,
                           DrSubVoucherId = o.subvoucher.SubVoucherId,
                           SubVoucherCodeName = o.subvoucher.SubVoucherName,
                           // CrSubVocerCodeName = o.subvoucher.SubVoucherName,

                           TransName = o.tranitem.TranName
                           //TranId = o.tranitem.TranId,
                           //AccTransDtlId = o.trandetails.AccTransDtlId,
                           //CRCOAId = o.trandetails.CRCOAId,
                           //DRCOAId = o.trandetails.DRCOAId,
                           //CreateBy = o.trandetails.CreateBy,
                           //CrSubVoucherId = o.trandetails.CrSubVoucherId,
                           //DrSubVoucherId = o.trandetails.DrSubVoucherId,
                           //CreateDate = o.trandetails.CreateDate,
                           //DRSubCoId2 = o.trandetails.DRSubCoId2,
                           //CRSubCoId2 = o.trandetails.CRSubCoId2,
                           //DRCOAIdNum = o.drcoid.AccountName,
                           //CRCOAIdNum = o.drcoid.AccountName,
                           //CrSubCode2Num = o.crsubcoid2.SubCode2_Num,
                           //DrSubCode2Num = o.crsubcoid2.SubCode2_Num,
                           //DrSubVocerCodeName = o.crsubvocarn.SubVoucherName,
                           //CrSubVocerCodeName = o.crsubvocarn.SubVoucherName,
                           //DRMainVoucherId = o.crsubvocarn.MainVoucherId,
                           //CRMainVoucherId = o.crsubvocarn.MainVoucherId,
                           //DRSubCoId1 = o.crsubcoid2.SubCode_1Id,
                           //CRSubCoId1 = o.crsubcoid2.SubCode_1Id,
                           //DRMainHeadId = o.crsubcoid2.AccSubCode1.AccMainHead.MainHeadId,
                           //CRMainHeadId = o.crsubcoid2.AccSubCode1.AccMainHead.MainHeadId,
                           //TransName = o.tranitem.TranName,

                       };
                return result.ToList<TransDetailsDTO>();
            }
        }

        public List<TransDetailsDTO> LoadTransDetailsData_CR(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from trandetails in Container.AccTransDetails
                            join tranitem in Container.AccTranItems on trandetails.TranId equals tranitem.TranId
                            join subcode2 in Container.AccSubCode2 on trandetails.CRSubCoId2 equals subcode2.SubCode2_Id
                            join coaid in Container.AccCOAInfoes on trandetails.CRCOAId equals coaid.COAId
                            join subvoucher in Container.AccSubVouchers on trandetails.CrSubVoucherId equals subvoucher.SubVoucherId

                            join subcode1 in Container.AccSubCode1 on subcode2.SubCode_1Id equals subcode1.SubCode_1Id
                            join mainhead in Container.AccMainHeads on subcode1.MainHeadId equals mainhead.MainHeadId

                            select new { trandetails, tranitem, subcode2, coaid, subvoucher, subcode1, mainhead };
                if (id != 0)
                    query = query.Where(c => c.trandetails.AccTransDtlId.Equals(id));


                var result = from o in query
                             orderby o.trandetails.AccTransDtlId descending
                             select new TransDetailsDTO
                             {

                               //  TranId = o.tranitem.TranId,


                                 AccTransDtlId = o.trandetails.AccTransDtlId,
                                 CreateBy = o.trandetails.CreateBy,
                                 CreateDate = o.trandetails.CreateDate,

                                // DRMainHeadId = o.mainhead.MainHeadId,
                                 CRMainHeadId = o.mainhead.MainHeadId,
                                 MainHeadName_Num = o.mainhead.MainHadeNum + "-" + o.mainhead.MainHeadName,

                                 //DRSubCoId1 = o.subcode1.SubCode_1Id,
                                 CRSubCoId1 = o.subcode1.SubCode_1Id,
                                 //DrSubCode1Num = o.subcode2.AccSubCode1.SubCode_1Num + "-" + o.subcode2.AccSubCode1.SubCode_1Num,
                                 SubCode1Name_Num = o.subcode1.SubCode_1Num + "-" + o.subcode1.SubCode_1Name,


                                 //DRSubCoId1 = o.subcode2.AccSubCode1.SubCode_1Id,
                                 //CRSubCoId1 = o.subcode2.AccSubCode1.SubCode_1Id,
                                 ////DrSubCode1Num = o.subcode2.AccSubCode1.SubCode_1Num + "-" + o.subcode2.AccSubCode1.SubCode_1Num,
                                 //SubCode1Name_Num = o.subcode2.AccSubCode1.SubCode_1Num + "-" + o.subcode2.AccSubCode1.SubCode_1Num,

                                // DRSubCoId2 = o.subcode2.SubCode2_Id,
                                 CRSubCoId2 = o.subcode2.SubCode2_Id,
                                 //  CrSubCode2Num = o.subcode2.SubCode2_Num + "-" + o.subcode2.SubCode_2Name,
                                 SubCode2Name_Num = o.subcode2.SubCode2_Num + "-" + o.subcode2.SubCode_2Name,

                                 CRCOAId = o.coaid.COAId,
                               //  DRCOAId = o.coaid.COAId,
                                 COAName_Num = o.coaid.COAACCId + "-" + o.coaid.AccountName,
                                 //CRCOAIdNum = o.coaid.COAACCId + "-" + o.coaid.AccountName,


                                // DRMainVoucherId = o.subvoucher.AccMainVoucher.MainVoucherId,
                                 CRMainVoucherId = o.subvoucher.AccMainVoucher.MainVoucherId,
                                 // DrMainVocerCodeName = o.subvoucher.AccMainVoucher.MainVoucherName,
                                 MainVoucherCode_Name = o.subvoucher.AccMainVoucher.MainVoucherName,


                                 CrSubVoucherId = o.subvoucher.SubVoucherId,
                                // DrSubVoucherId = o.subvoucher.SubVoucherId,
                                 SubVoucherCodeName = o.subvoucher.SubVoucherName,
                                 // CrSubVocerCodeName = o.subvoucher.SubVoucherName,

                                // TransName = o.tranitem.TranName


                             };
                return result.ToList<TransDetailsDTO>();
            }
        }


        public void Edit(TransDetailsDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccTransDetail();
                Comp = container.AccTransDetails.FirstOrDefault(o => o.AccTransDtlId.Equals(DTO.AccTransDtlId));
                Comp.TranId = DTO.TranId;
                Comp.AccTransDtlId = DTO.AccTransDtlId;
                Comp.DRCOAId = DTO.DRCOAId;
                Comp.CRCOAId = DTO.CRCOAId;

                Comp.DRSubCoId2 = DTO.DRSubCoId2;
                Comp.CRSubCoId2 = DTO.CRSubCoId2;
                Comp.CrSubVoucherId = DTO.CrSubVoucherId;
                Comp.DrSubVoucherId = DTO.DrSubVoucherId;

                Comp = (AccTransDetail)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }


    }
}
