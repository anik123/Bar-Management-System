using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class InvenCentralPurchaseDAL
    {

        public void PurchaseInfo(InvenCentralPurchaeInfoDTO DTO)
        {

            using (var container = new InventoryContainer())
            {
                InvenCentralPurchaseInfo gur = new InvenCentralPurchaseInfo();
                container.InvenCentralPurchaseInfoes.AddObject((InvenCentralPurchaseInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }

        public void SavePurchaseDtl(InvenCentralPurchaseDtlDto DTO)
        {

            using (var container = new InventoryContainer())
            {
                InvenCentralPurchaseDtl gur = new InvenCentralPurchaseDtl();
                container.InvenCentralPurchaseDtls.AddObject((InvenCentralPurchaseDtl)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }
        public void SavePaymentInfo(InvenCentralPurchasePaymentDTO DTO)
        {

            using (var container = new InventoryContainer())
            {
                InvenCentralPurchcasePayment gur = new InvenCentralPurchcasePayment();
                container.InvenCentralPurchcasePayments.AddObject((InvenCentralPurchcasePayment)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }
        public void SavePurPaymentDtl(InvenCentralPurchasePaymentDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenCentralPurchcasePaymentDtl ino = new InvenCentralPurchcasePaymentDtl();

                container.InvenCentralPurchcasePaymentDtls.AddObject((InvenCentralPurchcasePaymentDtl)DTOMapper.DTOObjectConverter(DTO, ino));
                container.SaveChanges();
            }
        }
        // load pur payment dtl id
        public List<InvenCentralPurchasePaymentDtlDto> LoadPharmPaymentDtlId()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCentralPurchcasePaymentDtls
                            select new { s };

                var result = from o in query
                             orderby o.s.PurPayDtlId descending
                             select new InvenCentralPurchasePaymentDtlDto
                             {
                                 PurPayDtlId = o.s.PurPayDtlId

                             };
                return result.ToList<InvenCentralPurchasePaymentDtlDto>();
            }
        }
        // purcahse Payment 
        public void EditPurchasePayment(InvenCentralPurchasePaymentDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenCentralPurchcasePayment();
                Comp = container.InvenCentralPurchcasePayments.FirstOrDefault(o => o.PurPaymentId.Equals(DTO.PurPaymentId));
                Comp.DueAmount = DTO.DueAmount;
                Comp.PurId = DTO.PurId;
                Comp.FirstPaymentStatus = DTO.FirstPaymentStatus;
                Comp.PaidAmount = DTO.PaidAmount;

                Comp = (InvenCentralPurchcasePayment)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        public List<InvenCentralPurchaeInfoDTO> LoadPurID()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCentralPurchaseInfoes
                            select new { s };

                var result = from o in query
                             orderby o.s.PurId descending

                             select new InvenCentralPurchaeInfoDTO
                             {
                                 PurId = o.s.PurId

                             };
                return result.ToList<InvenCentralPurchaeInfoDTO>();
            }
        }
        //load central pur payument company 
        public List<InvenCentralPurchasePaymentDTO> CentralPurchasePayment_Client_Load(int purid, int orderid, int Compid, string SalesManName, string FromDate, string ToDate)
        {
            DateTime From, To;
            using (var Container = new InventoryContainer())
            {
                var query = from payinfo in Container.InvenCentralPurchcasePayments
                            join purinfo in Container.InvenCentralPurchaseInfoes on payinfo.PurId equals purinfo.PurId
                            // join purdtl in Container.InvenCentralPurchaseDtls on purinfo.PurId equals purdtl.PurId
                            // join Comp in Container.CompanyInfoes on purinfo.DurgCompId equals Comp.CompId
                            select new { payinfo, purinfo };

                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    To = To.AddDays(1);
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.purinfo.CreateDate >= From && c.purinfo.CreateDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.purinfo.CreateDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.purinfo.CreateDate == From);
                }
                if (purid != 0)
                    query = query.Where(c => c.purinfo.PurId.Equals(purid));

                if (orderid != 0)
                    query = query.Where(c => c.purinfo.PurOrderNo.Equals(orderid));

                if (!string.IsNullOrEmpty(SalesManName))
                    query = query.Where(c => c.purinfo.SalesManName.Contains(SalesManName));


                var result = from o in query
                             orderby o.purinfo.PurId ascending
                             where o.payinfo.FirstPaymentStatus == "0"
                             select new InvenCentralPurchasePaymentDTO
                             {
                                 //  CompId = o.purdtl.Product.CompanyInfo.CompId,
                                 //  CompName = o.purdtl.Product.CompanyInfo.CompName,
                                 // CompId=o.payinfo.InvenCentralPurchaseInfo.InvenCentralPurchaseDtls.pro
                                 SalesManName = o.purinfo.SalesManName,
                                 PurId = o.purinfo.PurId,
                                 PurOrderNo = o.purinfo.PurOrderNo,
                                 CreateDate = o.purinfo.CreateDate,
                                 TotalPrice = o.payinfo.TotalPrice,
                                 PurPaymentId = o.payinfo.PurPaymentId,
                                 FirstPaymentStatus = o.payinfo.FirstPaymentStatus

                             };
                return result.ToList<InvenCentralPurchasePaymentDTO>();
            }
        }

        //load pharm pur Due payument company 

        public List<InvenCentralPurchasePaymentDTO> PharmPurchase_Due_Payment(int purid, int orderid, int Compid, string SalesManName, string FromDate, string ToDate)
        {
            DateTime From, To;
            using (var Container = new InventoryContainer())
            {
                var query = from payinfo in Container.InvenCentralPurchcasePayments
                            join purinfo in Container.InvenCentralPurchaseInfoes on payinfo.PurId equals purinfo.PurId
                            // join purdtl in Container.InvenCentralPurchaseDtls on purinfo.PurId equals purdtl.PurId
                            // join Comp in Container.CompanyInfoes on purinfo.DurgCompId equals Comp.CompId
                            select new { payinfo, purinfo };

                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    To = To.AddDays(1);
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.purinfo.CreateDate >= From && c.purinfo.CreateDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.purinfo.CreateDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.purinfo.CreateDate == From);
                }
                if (purid != 0)
                    query = query.Where(c => c.purinfo.PurId.Equals(purid));

                if (orderid != 0)
                    query = query.Where(c => c.purinfo.PurOrderNo.Equals(orderid));

                if (!string.IsNullOrEmpty(SalesManName))
                    query = query.Where(c => c.purinfo.SalesManName.Contains(SalesManName));


                var result = from o in query
                             orderby o.purinfo.PurId ascending
                             where o.payinfo.DueAmount != 0
                             select new InvenCentralPurchasePaymentDTO
                             {
                                 //  CompId = o.purdtl.Product.CompanyInfo.CompId,
                                 //  CompName = o.purdtl.Product.CompanyInfo.CompName,
                                 // CompId=o.payinfo.InvenCentralPurchaseInfo.InvenCentralPurchaseDtls.pro
                                 SalesManName = o.purinfo.SalesManName,
                                 PurId = o.purinfo.PurId,
                                 PurOrderNo = o.purinfo.PurOrderNo,
                                 CreateDate = o.purinfo.CreateDate,
                                 TotalPrice = o.payinfo.TotalPrice,
                                 PurPaymentId = o.payinfo.PurPaymentId,
                                 FirstPaymentStatus = o.payinfo.FirstPaymentStatus

                             };
                return result.ToList<InvenCentralPurchasePaymentDTO>();
            }
        }
        //load sales  payument company 
        public List<InvenCentralPurchasePaymentDTO> PurchaseStatementLaod(int purid, int compid, string FromDate, string ToDate)
        {
            DateTime From, To;
            using (var Container = new InventoryContainer())
            {
                var query = from purpay in Container.InvenCentralPurchcasePayments
                            join payinfo in Container.InvenCentralPurchaseInfoes on purpay.PurId equals payinfo.PurId
                            //     join purdtl in Container.InvenCentralPurchaseDtls on payinfo.PurId equals purdtl.PurId

                            select new { purpay, payinfo };

                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    To = To.AddDays(1);
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.payinfo.CreateDate >= From && c.payinfo.CreateDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.payinfo.CreateDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.payinfo.CreateDate == From);
                }
                if (purid != 0)
                    query = query.Where(c => c.payinfo.PurId.Equals(purid));

                if (compid != 0)
                    query = query.Where(c => c.purpay.CompanyInfo.CompId.Equals(compid));


                var result = from o in query
                             orderby o.payinfo.PurId ascending

                             select new InvenCentralPurchasePaymentDTO
                             {
                                 PurId = o.payinfo.PurId,
                                 CompId = o.purpay.CompanyInfo.CompId,
                                 CompName = o.purpay.CompanyInfo.CompName,
                                 CreateBy = o.payinfo.CreateBy,
                                 CreateDate = o.payinfo.CreateDate,
                                 TotalPrice = o.purpay.TotalPrice,
                                 PaidAmount = o.purpay.PaidAmount,
                                 DueAmount = o.purpay.DueAmount,
                             };
                return result.ToList<InvenCentralPurchasePaymentDTO>();
            }
        }
        ////load sales  payument company 
        //public List<InvenCentralPurchasePaymentDTO> PurchaseStatementLaod(int purid, int compid, string FromDate, string ToDate)
        //{
        //    DateTime From, To;
        //    using (var Container = new InventoryContainer())
        //    {
        //        var query = from purpay in Container.InvenCentralPurchaseDtls
        //                    join payinfo in Container.InvenCentralPurchaseInfoes on purpay.PurId equals payinfo.PurId
        //                    join purdtl in Container.InvenCentralPurchcasePayments on payinfo.PurId equals purdtl.PurId

        //                    select new { purpay, payinfo, purdtl };

        //        if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
        //        {
        //            To = Convert.ToDateTime(ToDate);
        //            To = To.AddDays(1);
        //            From = Convert.ToDateTime(FromDate);
        //            query = query.Where(c => c.payinfo.CreateDate >= From && c.payinfo.CreateDate <= To);
        //        }
        //        else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
        //        {
        //            To = Convert.ToDateTime(ToDate);
        //            query = query.Where(c => c.payinfo.CreateDate == To);
        //        }
        //        else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
        //        {
        //            From = Convert.ToDateTime(FromDate);
        //            query = query.Where(c => c.payinfo.CreateDate == From);
        //        }
        //        if (purid != 0)
        //            query = query.Where(c => c.payinfo.PurId.Equals(purid));

        //        //  if (compid != 0)
        //        //   query = query.Where(c => c.purdtl.Product.CompanyInfo.CompId.Equals(compid));


        //        var result = from o in query
        //                     orderby o.payinfo.PurId ascending

        //                     select new InvenCentralPurchasePaymentDTO
        //                     {
        //                         PurId = o.payinfo.PurId,

        //                         CreateBy = o.payinfo.CreateBy,
        //                         CreateDate = o.payinfo.CreateDate,
        //                         TotalPrice = o.purdtl.TotalPrice,
        //                         PaidAmount = o.purdtl.PaidAmount,
        //                         DueAmount = o.purdtl.DueAmount,
        //                     };
        //        return result.ToList<InvenCentralPurchasePaymentDTO>();
        //    }
        //}
    }
}
