using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using DAL;

namespace ADAL
{
    public class CrystalReptDAL
    {
        public List<SubVoucherDTO> GenerateSuvCodeNo(string Vochername, string Subvochername)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccSubVouchers
                            join mainvoucher in Container.AccMainVouchers on s.MainVoucherId equals mainvoucher.MainVoucherId
                            select new { s, mainvoucher };

                if (!string.IsNullOrEmpty(Vochername))
                    query = query.Where(c => c.mainvoucher.MainVoucherName.Contains(Vochername));

                if (!string.IsNullOrEmpty(Subvochername))
                    query = query.Where(c => c.s.SubVoucherName.Contains(Subvochername));


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

    }
}
