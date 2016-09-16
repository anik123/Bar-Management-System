using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using Utility;
using DAL;

namespace ADAL
{
    public class MainVoucherDAL
    {
        public void Add(MainVoucherDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                AccMainVoucher gur = new AccMainVoucher();
                container.AccMainVouchers.AddObject((AccMainVoucher)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(MainVoucherDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccMainVoucher();
                Comp = container.AccMainVouchers.FirstOrDefault(o => o.MainVoucherId.Equals(DTO.MainVoucherId));
                Comp.MainVoucherId = DTO.MainVoucherId;
                Comp.MainVoucherCode = DTO.MainVoucherCode;
                Comp.MainVoucherName = DTO.MainVoucherName;

                Comp.UpdateDate = DTO.UpdateDate;
                Comp.UpdateBy = DTO.UpdateBy;
                // Comp.Testvalue = DTO.Testvalue;
                Comp = (AccMainVoucher)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        // load data for main vocher page
        public List<MainVoucherDTO> LoadMainVocher(int id)
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
                                 MainVoucherName = o.s.MainVoucherName,
                                 MainVoucherId = o.s.MainVoucherId,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,
                                 MainVoucherCode_Name = o.s.MainVoucherCode +"-"+ o.s.MainVoucherName 

                             };
                return result.ToList<MainVoucherDTO>();
            }
        }
    }
}
