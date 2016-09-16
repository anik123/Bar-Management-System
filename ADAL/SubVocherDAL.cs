using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using Utility;
using DAL;

namespace ADAL
{
    public class SubVocherDAL
    {
        public void Add(SubVoucherDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                AccSubVoucher gur = new AccSubVoucher();
                container.AccSubVouchers.AddObject((AccSubVoucher)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(SubVoucherDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccSubVoucher();
                Comp = container.AccSubVouchers.FirstOrDefault(o => o.SubVoucherId.Equals(DTO.SubVoucherId));
                Comp.MainVoucherId = DTO.MainVoucherId;
                Comp.SubVoucherId = DTO.SubVoucherId;
                Comp.SubVoucherCode = DTO.SubVoucherCode;
                Comp.SubVoucherName = DTO.SubVoucherName;

                Comp.UpdateDate = DTO.UpdateDate;
                Comp.UpdateBy = DTO.UpdateBy;
                // Comp.Testvalue = DTO.Testvalue;
                Comp = (AccSubVoucher)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public List<SubVoucherDTO> LoadSubVoucherData(int id,int mainvoucherid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccSubVouchers
                            join mainvoucher in Container.AccMainVouchers on s.MainVoucherId equals mainvoucher.MainVoucherId
                            select new { s, mainvoucher };

                if (id != 0)
                    query = query.Where(c => c.s.SubVoucherId.Equals(id));
                if (mainvoucherid != 0)
                    query = query.Where(c => c.mainvoucher.MainVoucherId.Equals(mainvoucherid));


                var result = from o in query
                             orderby o.s.SubVoucherId descending
                             //   where o.s.MainHeadId.Equals(id)
                             select new SubVoucherDTO
                             {

                                 MainVoucherCode = o.mainvoucher.MainVoucherCode,
                                 MainVoucherName = o.mainvoucher.MainVoucherName,
                                 MainVoucherId = o.mainvoucher.MainVoucherId,
                                 SubVoucherId = o.s.SubVoucherId,
                                 SubVoucherName = o.s.SubVoucherName,
                                 SubVoucherCode = o.s.SubVoucherCode,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,

                                 SubVoucherCodeName = o.s.SubVoucherCode + "-"+ o.s.SubVoucherName 

                             };
                return result.ToList<SubVoucherDTO>();
            }
        }
       
        //
        public List<SubVoucherDTO> LoadSubVoucherData_Validation(int id, string subvouchername)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccSubVouchers
                            join mainvoucher in Container.AccMainVouchers on s.MainVoucherId equals mainvoucher.MainVoucherId
                            select new { s, mainvoucher };

                if (id != 0)
                    query = query.Where(c => c.s.SubVoucherId.Equals(id));
                if (!string.IsNullOrEmpty(subvouchername))
                {
                    query = query.Where(c => c.s.SubVoucherName.Contains(subvouchername));
                }

                var result = from o in query
                             orderby o.s.SubVoucherId descending
                             //   where o.s.MainHeadId.Equals(id)
                             select new SubVoucherDTO
                             {

                                 MainVoucherCode = o.mainvoucher.MainVoucherCode,
                                 MainVoucherName = o.mainvoucher.MainVoucherName,
                                 MainVoucherId = o.mainvoucher.MainVoucherId,
                                 SubVoucherId = o.s.SubVoucherId,
                                 SubVoucherName = o.s.SubVoucherName,
                                 SubVoucherCode = o.s.SubVoucherCode,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,


                             };
                return result.ToList<SubVoucherDTO>();
            }
        }

        //generate sub voucher code no#

        public List<SubVoucherDTO> GenerateSuvCodeNo(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccSubVouchers
                            join mainvoucher in Container.AccMainVouchers on s.MainVoucherId equals mainvoucher.MainVoucherId
                            select new { s, mainvoucher };

                if (id != 0)
                    query = query.Where(c => c.mainvoucher.MainVoucherId.Equals(id));


                var result = from o in query
                             orderby o.s.SubVoucherId descending
                             //   where o.s.MainHeadId.Equals(id)
                             select new SubVoucherDTO
                             {

                                 MainVoucherCode = o.mainvoucher.MainVoucherCode,
                                 MainVoucherName = o.mainvoucher.MainVoucherName,
                                 MainVoucherId = o.mainvoucher.MainVoucherId,
                                 SubVoucherId = o.s.SubVoucherId,
                                 SubVoucherName = o.s.SubVoucherName,
                                 SubVoucherCode = o.s.SubVoucherCode,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,


                             };
                return result.ToList<SubVoucherDTO>();
            }
        }


        public List<MainVoucherDTO> GenerateSubVoucherCodeNO(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccMainVouchers

                            select new { s };

                if (id != 0)
                    query = query.Where(c => c.s.MainVoucherId.Equals(id));


                var result = from o in query
                             orderby o.s.MainVoucherId descending
                             //   where o.s.MainHeadId.Equals(id)
                             select new MainVoucherDTO
                             {

                                 MainVoucherCode = o.s.MainVoucherCode,
                                 //  MainVoucherName = o.s.MainVoucherName,
                                 MainVoucherId = o.s.MainVoucherId,
                                 //  CreateBy = o.s.CreateBy,
                                 // CreateDate = o.s.CreateDate,
                                 //  MainVoucherCode_Name = o.s.MainVoucherName + "   " + "(" + o.s.MainVoucherCode + ")"

                             };
                return result.ToList<MainVoucherDTO>();
            }
        }
    }
}

