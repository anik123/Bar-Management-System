using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class InvenChangeDAL
    {
        public void SaveChangeInfo(InvenChangeInfoDto DTO)
        {

            using (var container = new InventoryContainer())
            {
                InvenChangeInfo gur = new InvenChangeInfo();
                container.InvenChangeInfoes.AddObject((InvenChangeInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }

        public void SaveChangeDtl(InvenChangeDtlDto DTO)
        {

            using (var container = new InventoryContainer())
            {
                InvenChangeDtl gur = new InvenChangeDtl();
                container.InvenChangeDtls.AddObject((InvenChangeDtl)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }
        public void Edit_ChangeDtl_CentralSendStatus(InvenChangeDtlDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenChangeDtl();
                Comp = container.InvenChangeDtls.FirstOrDefault(o => o.ChangeDtlId.Equals(DTO.ChangeDtlId));
                Comp.CentranlReturnStatus = DTO.CentranlReturnStatus;
                Comp = (InvenChangeDtl)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        public void SaveChangePaymentInfo(InvenChangePaymentDto DTO)
        {

            using (var container = new InventoryContainer())
            {
                InvenChangePayment gur = new InvenChangePayment();
                container.InvenChangePayments.AddObject((InvenChangePayment)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }
        public void SaveChangePaymentDtl(InvenChangePaymentDtlDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenChangePaymentDtl ino = new InvenChangePaymentDtl();

                container.InvenChangePaymentDtls.AddObject((InvenChangePaymentDtl)DTOMapper.DTOObjectConverter(DTO, ino));
                container.SaveChanges();
            }
        }
        public List<InvenChangeInfoDto> LoadChangeInofId()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenChangeInfoes
                            select new { s };

                var result = from o in query
                             orderby o.s.ChangeId descending

                             select new InvenChangeInfoDto
                             {
                                 ChangeId = o.s.ChangeId

                             };
                return result.ToList<InvenChangeInfoDto>();
            }
        }

        //load sales  payument company 
        public List<InvenChangePaymentDtlDto> BranchWise_ChangeInfoLaod(int salid, int brid, string FromDate, string ToDate)
        {
            DateTime From, To;
            using (var Container = new InventoryContainer())
            {
                var query = from changepay in Container.InvenChangePayments
                            join changeinfo in Container.InvenChangeInfoes on changepay.ChangeId equals changeinfo.ChangeId

                            select new { changeinfo, changepay };

                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    To = To.AddDays(1);
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.changeinfo.CreateDate >= From && c.changeinfo.CreateDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.changeinfo.CreateDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.changeinfo.CreateDate == From);
                }
                if (salid != 0)
                    query = query.Where(c => c.changeinfo.ChangeId.Equals(salid));

                if (brid != 0)
                    query = query.Where(c => c.changeinfo.InvenBranchProfile.BrProId.Equals(brid));


                var result = from o in query
                             orderby o.changeinfo.ChangeId ascending
                             select new InvenChangePaymentDtlDto
                             {
                                 ChangeId = o.changeinfo.ChangeId,
                                 BrProName = o.changeinfo.InvenBranchProfile.BrProName,
                                 CreateBy = o.changeinfo.CreateBy,
                                 CreateDate = o.changeinfo.CreateDate,
                                 TotalPrice = o.changepay.TotalPrice,
                                 PaidAmount = o.changepay.PaidAmount,
                                 DueAmount = o.changepay.DueAmount,
                             };
                return result.ToList<InvenChangePaymentDtlDto>();
            }
        }
    }
}
