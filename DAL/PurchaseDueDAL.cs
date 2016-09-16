using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class PurchaseDueDAL
    {
        // save pur payment dtl in due page
        public void SavePurchasePaymentDtl_Pay_Due(InvenCentralPurchasePaymentDtlDto DTO)
        {

            using (var container = new InventoryContainer())
            {
                InvenCentralPurchcasePaymentDtl gur = new InvenCentralPurchcasePaymentDtl();
                container.InvenCentralPurchcasePaymentDtls.AddObject((InvenCentralPurchcasePaymentDtl)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }
        //load pharm pur Due payument company 
        public List<InvenCentralPurchasePaymentDTO> CentralPurchase_Due_Payment(int purid, int orderid, int Compid, string SalesManName, string FromDate, string ToDate)
        {
            DateTime From, To;
            using (var Container = new InventoryContainer())
            {
                var query = from payinfo in Container.InvenCentralPurchcasePayments
                            join purinfo in Container.InvenCentralPurchaseInfoes on payinfo.PurId equals purinfo.PurId
                            //from purinfo in Container.PharmPurchaseInfoes
                            //  join Comp in Container.PharmDurgCompanyInfoes on purinfo.DurgCompId equals Comp.CompId
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

                //if (Compid != 0)
                //    query = query.Where(c => c.Comp.CompId.Equals(Compid));
                if (orderid != 0)
                    query = query.Where(c => c.purinfo.PurOrderNo.Equals(orderid));

                if (!string.IsNullOrEmpty(SalesManName))
                    query = query.Where(c => c.purinfo.SalesManName.Contains(SalesManName));


                var result = from o in query
                             orderby o.purinfo.PurId ascending
                             where o.payinfo.DueAmount != 0
                             select new InvenCentralPurchasePaymentDTO
                             {
                                 //  CompId = o.Comp.CompId,
                                 //CompName = o.Comp.CompName,

                                 SalesManName = o.purinfo.SalesManName,
                                 PurId = o.purinfo.PurId,
                                 PurOrderNo = o.purinfo.PurOrderNo,

                                 TotalPrice = o.payinfo.TotalPrice,
                                 PurPaymentId = o.payinfo.PurPaymentId,
                                 PaidAmount = o.payinfo.PaidAmount,
                                 //   PaymentDate = o.payinfo.PaymentDate,
                                 DueAmount = o.payinfo.DueAmount,

                             };
                return result.ToList<InvenCentralPurchasePaymentDTO>();
            }
        }

        public List<InvenCentralPurchasePaymentDTO> GetPurchaseDue(int payid, int Compid, string SalesManName)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from purchase in Container.InvenCentralPurchcasePayments
                            join purinfo in Container.InvenCentralPurchaseInfoes on purchase.PurId equals purinfo.PurId

                            //join med in Container.PharmMedicationInfoes on p
                         //   join Comp in Container.PharmDurgCompanyInfoes on purinfo.DurgCompId equals Comp.CompId
                            select new { purchase, purinfo };
                if (payid != 0)
                    query = query.Where(c => c.purchase.PurPaymentId.Equals(payid));

                //if (Compid != 0)
                //    query = query.Where(c => c.Comp.CompId.Equals(Compid));


                if (!string.IsNullOrEmpty(SalesManName))
                    query = query.Where(c => c.purinfo.SalesManName.Contains(SalesManName));


                var result = from o in query
                             orderby o.purchase.PurPaymentId descending
                             where o.purchase.DueAmount != 0
                             select new InvenCentralPurchasePaymentDTO
                             {
                               //  CompId = o.Comp.CompId,
                                 //CompName = o.Comp.CompName,
                                 PurPaymentId = o.purchase.PurPaymentId,
                                 PaidAmount = o.purchase.PaidAmount,
                                 DueAmount = o.purchase.DueAmount,
                                 TotalPrice = o.purchase.TotalPrice,

                                 SalesManName = o.purinfo.SalesManName,
                                 PurId = o.purinfo.PurId
                                 //   PaymentDate = o.purchase.PaymentDate
                             };
                return result.ToList<InvenCentralPurchasePaymentDTO>();
            }
        }

       
       

        // view dtl dal
        public List<InvenCentralPurchasePaymentDTO> GetPyurchaseDueDtalil(int payid, int paymentdtlid, int Compid, string SalesManName)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from purchase in Container.InvenCentralPurchcasePaymentDtls
                            join purpayinfo in Container.InvenCentralPurchcasePayments on purchase.PurPaymentId equals purpayinfo.PurPaymentId
                            join purinfo in Container.InvenCentralPurchaseInfoes on purpayinfo.PurId equals purinfo.PurId
                            // join Comp in Container.PharmDurgCompanyInfoes on purinfo.DurgCompId equals Comp.CompId
                            //     joi
                            select new { purchase, purinfo, purpayinfo };
                if (payid != 0)
                    query = query.Where(c => c.purinfo.PurId.Equals(payid));
                if (paymentdtlid != 0)
                    query = query.Where(c => c.purchase.PurPayDtlId.Equals(paymentdtlid));

                //if (Compid != 0)
                //    query = query.Where(c => c.Comp.CompId.Equals(Compid));


                if (!string.IsNullOrEmpty(SalesManName))
                    query = query.Where(c => c.purinfo.SalesManName.Contains(SalesManName));


                var result = from o in query
                             orderby o.purchase.PurPayDtlId descending
                             where o.purinfo.PurId.Equals(payid)// != 0
                             select new InvenCentralPurchasePaymentDTO
                             {
                                 // CompId = o.Comp.CompId,
                                 //   CompName = o.Comp.CompName,
                                 PurPayDtlId = o.purchase.PurPayDtlId,
                                 //  AccountInfoId = o.purchase.PayBankAccountInfo.AccountInfoId,
                                 PaidAmount = o.purchase.PaidAmount,
                                 DueAmount = o.purchase.DueAmount,
                                 TotalPrice = o.purchase.TotalPrice,

                                 SalesManName = o.purinfo.SalesManName,
                                 PurId = o.purinfo.PurId,
                                 PaymentDate = o.purchase.PaymentDate,


                             };
                return result.ToList<InvenCentralPurchasePaymentDTO>();
            }
        }
    }
}
