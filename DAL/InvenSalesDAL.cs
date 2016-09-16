using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class InvenSalesDAL
    {
        public void SaveSalesInfo(InvenSalesInfoDto DTO)
        {

            using (var container = new InventoryContainer())
            {
                InvenSalesInfo gur = new InvenSalesInfo();
                container.InvenSalesInfoes.AddObject((InvenSalesInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }
        public void Edit_Salespayment(InvenSalesPaymentDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenSalePayment();
                Comp = container.InvenSalePayments.FirstOrDefault(o => o.SalePaymentId.Equals(DTO.SalePaymentId));
                Comp.SalePaymentId = DTO.SalePaymentId;
                Comp.PaidAmount = DTO.PaidAmount;
                Comp.DueAmount = DTO.DueAmount;
                //  Comp.TransectionType = DTO.TransectionType;
                Comp = (InvenSalePayment)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        public void Edit_Adjustpayment(InvenSalesPaymentDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenSalePayment();
                Comp = container.InvenSalePayments.FirstOrDefault(o => o.SalePaymentId.Equals(DTO.SalePaymentId));
                Comp.SalePaymentId = DTO.SalePaymentId;

                Comp.TotalPrice = DTO.TotalPrice;
                //  Comp.TransectionType = DTO.TransectionType;
                Comp = (InvenSalePayment)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        public void Edit_AdjustpaymentDtl(InvenSalePaymentDtlDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenSalesPaymentDtl();
                Comp = container.InvenSalesPaymentDtls.FirstOrDefault(o => o.SalePayDtlId.Equals(DTO.SaleDtlId));
                Comp.SalePayDtlId = DTO.SalePayDtlId;

                Comp.PaidAmount = DTO.TotalPrice;
                //  Comp.TransectionType = DTO.TransectionType;
                Comp = (InvenSalesPaymentDtl)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        public void Edit_ChangeProductPage(InvenSalesDtlDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenSaleDtl();
                Comp = container.InvenSaleDtls.FirstOrDefault(o => o.SaleDtlId.Equals(DTO.SaleDtlId));

                Comp.TransectionType = DTO.TransectionType;
                Comp = (InvenSaleDtl)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public void SaveSalesDtl(InvenSalesDtlDto DTO)
        {

            using (var container = new InventoryContainer())
            {
                InvenSaleDtl gur = new InvenSaleDtl();
                container.InvenSaleDtls.AddObject((InvenSaleDtl)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }
        public void SaveSalesPaymentInfo(InvenSalesPaymentDto DTO)
        {

            using (var container = new InventoryContainer())
            {
                InvenSalePayment gur = new InvenSalePayment();
                container.InvenSalePayments.AddObject((InvenSalePayment)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }
        public void SaveSalesPaymentDtl(InvenSalePaymentDtlDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenSalesPaymentDtl ino = new InvenSalesPaymentDtl();

                container.InvenSalesPaymentDtls.AddObject((InvenSalesPaymentDtl)DTOMapper.DTOObjectConverter(DTO, ino));
                container.SaveChanges();
            }
        }
        public List<InvenSalesInfoDto> LaadSalInofId()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenSalesInfoes
                            select new { s };

                var result = from o in query
                             orderby o.s.SalId descending

                             select new InvenSalesInfoDto
                             {
                                 SalId = o.s.SalId

                             };
                return result.ToList<InvenSalesInfoDto>();
            }
        }


        // last purchase price load
        public List<InvenCentralPurchaseDtlDto> LastPurchasePrice_ProductWise(int productid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCentralPurchaseDtls
                            select new { s };


                var result = from o in query
                             where o.s.ProductId.Equals(productid)
                             orderby o.s.PurchaseDtlID descending
                             select new InvenCentralPurchaseDtlDto
                             {
                                 PurchasePrice = o.s.PurchasePrice

                             };
                return result.ToList<InvenCentralPurchaseDtlDto>();
            }
        }

        public List<InvenSalesDtlDto> LaodProductId_FromSaledtltable(int saldtlid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenSaleDtls
                            select new { s };

                var result = from o in query

                             where o.s.SaleDtlId.Equals(saldtlid)
                             select new InvenSalesDtlDto
                             {
                                 SaleDtlId = o.s.SaleDtlId,
                                 ProductId = o.s.ProductId
                             };
                return result.ToList<InvenSalesDtlDto>();
            }
        }

        //load sales  payument company 
        public List<InvenSalePaymentDtlDto> BranchWise_SalesInfoLaod(int salid, int brid, string FromDate, string ToDate)
        {
            DateTime From, To;
            using (var Container = new InventoryContainer())
            {
                var query = from salpay in Container.InvenSalePayments
                            join salinfo in Container.InvenSalesInfoes on salpay.SalId equals salinfo.SalId

                            select new { salpay, salinfo };

                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    To = To.AddDays(1);
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.salinfo.CreateDate >= From && c.salinfo.CreateDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.salinfo.CreateDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.salinfo.CreateDate == From);
                }
                if (salid != 0)
                    query = query.Where(c => c.salinfo.SalId.Equals(salid));

                if (brid != 0)
                    query = query.Where(c => c.salinfo.InvenBranchProfile.BrProId.Equals(brid));


                var result = from o in query
                             orderby o.salinfo.SalId descending

                             select new InvenSalePaymentDtlDto
                             {
                                 SalId = o.salinfo.SalId,
                                 BrProName = o.salinfo.InvenBranchProfile.BrProName,
                                 CreateBy = o.salinfo.CreateBy,
                                 CreateDate = o.salinfo.CreateDate,
                                 TotalPrice = o.salpay.TotalPrice,
                                 PaidAmount = o.salpay.PaidAmount,
                                 DueAmount = o.salpay.DueAmount,
                             };
                return result.ToList<InvenSalePaymentDtlDto>();
            }
        }


        //load sales  payument company 
        public List<InvenSalePaymentDtlDto> BranchWise_SalesInfoLaod_ChangeProduct(int salid, int brid, string CusName, string CusMbNo, string CusRemarks, string Cuscontactadd, string FromDate)
        {

            using (var Container = new InventoryContainer())
            {
                var query = from salpay in Container.InvenSalePayments
                            join salinfo in Container.InvenSalesInfoes on salpay.SalId equals salinfo.SalId
                            join saldtl in Container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                            select new { salpay, salinfo, saldtl };

                if (!string.IsNullOrEmpty(CusName))
                    query = query.Where(c => c.salinfo.CustomerName.Contains(CusName));
                if (!string.IsNullOrEmpty(FromDate))
                // if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(FromDate.ToString()))
                {
                    DateTime From = Convert.ToDateTime(FromDate);
                    // var data = salinfo.CreateDate.Date.ToShortDateString();
                    // From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.salinfo.CreateDate == From);
                }

                if (!string.IsNullOrEmpty(CusMbNo))
                    query = query.Where(c => c.salinfo.CusMobileNo.Contains(CusMbNo));
                if (!string.IsNullOrEmpty(CusRemarks))
                    query = query.Where(c => c.salinfo.CusRemarks.Contains(CusRemarks));
                if (!string.IsNullOrEmpty(Cuscontactadd))
                    query = query.Where(c => c.salinfo.CusContactAdd.Contains(Cuscontactadd));
                if (salid != 0)
                    query = query.Where(c => c.salinfo.SalId.Equals(salid));

                if (brid != 0)
                    query = query.Where(c => c.salinfo.InvenBranchProfile.BrProId.Equals(brid));


                var result = from o in query
                             orderby o.salinfo.SalId descending

                             select new InvenSalePaymentDtlDto
                             {
                                 SalId = o.salinfo.SalId,
                                 BrProName = o.salinfo.InvenBranchProfile.BrProName,
                                 CreateBy = o.salinfo.CreateBy,
                                 CreateDate = o.salinfo.CreateDate,//.Date.ToShortDateString(),
                                 TotalPrice = o.salpay.TotalPrice,
                                 PaidAmount = o.salpay.PaidAmount,
                                 DueAmount = o.salpay.DueAmount,
                                 CatId = o.saldtl.Product.Category.CatId,
                                 CategoryName = o.saldtl.Product.Category.CategoryName,
                                 CusContactAdd = o.salinfo.CusContactAdd,
                                 CusMobileNo = o.salinfo.CusMobileNo,
                                 CusRemarks = o.salinfo.CusRemarks,
                                 CustomerName = o.salinfo.CustomerName,
                                 CompName = o.saldtl.Product.CompanyInfo.CompName,
                                 CompId = o.saldtl.Product.CompanyInfo.CompId,
                                 ProductName = o.saldtl.Product.ProductName,
                                 ProductId = o.saldtl.Product.ProductId,
                                 UnitId = o.saldtl.Product.Unit.UnitId,
                                 UnitName = o.saldtl.Product.Unit.UnitName,
                                 Quantity = o.saldtl.Quantity,
                                 SalePrice = o.saldtl.SalePrice,
                                 SaleDtlId = o.saldtl.SaleDtlId,
                                 SalePaymentId = o.salpay.SalePaymentId
                             };
                return result.ToList<InvenSalePaymentDtlDto>();
            }
        }

        //Member
        public List<InvenSalePaymentDtlDto> LoadMemberDue(int MemId, int SalId, int SalePaymentId)
        {
            using (var container = new InventoryContainer())
            {
                var query = from mem in container.Members
                            join salinfo in container.InvenSalesInfoes on mem.MemberId equals salinfo.MemberId
                            join sale in container.InvenSalePayments on salinfo.SalId equals sale.SalId

                            select new { mem, sale, salinfo };
                if (MemId != 0)
                    query = query.Where(o => o.mem.MemberId == MemId);
                if (SalId != 0)
                    query = query.Where(o => o.salinfo.SalId == SalId);
                if (SalePaymentId != 0)
                    query = query.Where(o => o.sale.SalePaymentId == SalePaymentId);
                var result = (from o in query
                              where o.sale.DueAmount > 0
                              orderby o.salinfo.CreateDate descending
                              select new InvenSalePaymentDtlDto
                              {
                                  SalePaymentId = o.sale.SalePaymentId,
                                  PaidAmount = o.sale.PaidAmount,
                                  DueAmount = o.sale.DueAmount,
                                  SalId = o.sale.SalId,
                                  CreateDate = o.salinfo.CreateDate
                              }).Distinct().ToList<InvenSalePaymentDtlDto>();
                return result;

            }
        }
        public List<InvenSalePaymentDtlDto> LoadActiveMember(int MemId, int SalId, int SalePaymentId)
        {
            using (var container = new InventoryContainer())
            {
                var query = from mem in container.Members
                            join salinfo in container.InvenSalesInfoes on mem.MemberId equals salinfo.MemberId
                            join sale in container.InvenSalePayments on salinfo.SalId equals sale.SalId

                            select new { mem, sale, salinfo };
                if (MemId != 0)
                    query = query.Where(o => o.mem.MemberId == MemId);
                if (SalId != 0)
                    query = query.Where(o => o.salinfo.SalId == SalId);
                if (SalePaymentId != 0)
                    query = query.Where(o => o.sale.SalePaymentId == SalePaymentId);
                var result = (from o in query

                              orderby o.salinfo.CreateDate descending
                              group o by new { o.salinfo.CreateDate } into os
                              select new InvenSalePaymentDtlDto
                              {
                                  CreateDate = os.Key.CreateDate
                              }).ToList<InvenSalePaymentDtlDto>();
                return result;

            }
        }
        public List<InvenSalePaymentDtlDto> LoadActiveMemberDateWise(int MemId, string date)
        {
            using (var container = new InventoryContainer())
            {
                var query = from mem in container.Members
                            join salinfo in container.InvenSalesInfoes on mem.MemberId equals salinfo.MemberId
                            join sale in container.InvenSalePayments on salinfo.SalId equals sale.SalId

                            select new { mem, sale, salinfo };
                if (MemId != 0)
                    query = query.Where(o => o.mem.MemberId == MemId);
                if (date != String.Empty)
                {
                    DateTime Date = DateTime.Parse(date);
                    query = query.Where(o => o.salinfo.CreateDate == Date);
                }
                var result = (from o in query
                              orderby o.salinfo.CreateDate descending
                              select new InvenSalePaymentDtlDto
                              {
                                  SalePaymentId = o.sale.SalePaymentId,
                                  PaidAmount = o.sale.PaidAmount,
                                  DueAmount = o.sale.DueAmount,
                                  TotalAmount = o.sale.TotalPrice,
                                  SalId = o.sale.SalId,
                                  CreateDate = o.salinfo.CreateDate
                              }).ToList<InvenSalePaymentDtlDto>();
                return result;
            }
        }
        public List<InvenSalePaymentDtlDto> LoadSalesDate(string FromDate, string ToDate)
        {
            using (var container = new InventoryContainer())
            {
                DateTime To, From;
                var query = from salinfo in container.InvenSalesInfoes
                            select new { salinfo };
                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);

                    From = Convert.ToDateTime(FromDate);
                    if (To < From)
                    {
                        DateTime toTime, fromTime;
                        toTime = From;
                        fromTime = To;
                        To = toTime;
                        From = fromTime;
                    }
                    query = query.Where(c => c.salinfo.CreateDate >= From && c.salinfo.CreateDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.salinfo.CreateDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.salinfo.CreateDate == From);
                }
                var result = (from o in query
                              group o by o.salinfo.CreateDate into os
                              select new InvenSalePaymentDtlDto
                              {
                                  CreateDate = os.Key
                              }).ToList<InvenSalePaymentDtlDto>();

                return result;
            }
        }

        public List<InvenSalePaymentDtlDto> LoadDailySaleWihoutCocktail(string date)
        {
            using (var container = new InventoryContainer())
            {

                DateTime Date;
                var query = from salpay in container.InvenSalePayments
                            join salinfo in container.InvenSalesInfoes on salpay.SalId equals salinfo.SalId
                            join saldtl in container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                            where salpay.DueAmount <= 0
                            select new { salpay, salinfo, saldtl };

                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.salinfo.CreateDate.Equals(Date));
                }

                var result = from o in query
                             where !o.saldtl.Product.Category.CategoryName.ToLower().Contains("extra".ToLower()) && !o.saldtl.Product.Category.CategoryName.ToLower().Contains("cockt".ToLower())
                             orderby o.salinfo.SalId ascending
                             group o by new { o.saldtl.Product.CompanyInfo.CompName }
                                 into os
                                 select new InvenSalePaymentDtlDto
                                 {
                                     Quantity = os.Sum(o => o.saldtl.Quantity),
                                 };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }

        public List<InvenSalePaymentDtlDto> LoadDailySaleCocktail(string date)
        {
            using (var container = new InventoryContainer())
            {

                DateTime Date;
                var query = from saldtl in container.InvenSaleDtls
                            join salpay in container.InvenSalePayments on saldtl.SalId equals salpay.SalId
                            join cock in container.CocktailInfoes on saldtl.ProductId equals cock.CocktaiProId

                            where salpay.DueAmount <= 0
                            select new { cock, saldtl };

                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.saldtl.InvenSalesInfo.CreateDate.Equals(Date));
                }

                var result = from o in query
                             where o.saldtl.Product.Category.CategoryName.ToLower().Contains("cockt".ToLower())

                             select new InvenSalePaymentDtlDto
                             {
                                 Quantity = o.saldtl.Quantity * o.cock.Quantity
                             };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }


        public List<InvenSalePaymentDtlDto> LoadDailySale(string date)
        {
            using (var container = new InventoryContainer())
            {

                DateTime Date;
                var query = from salpay in container.InvenSalePayments
                            join salinfo in container.InvenSalesInfoes on salpay.SalId equals salinfo.SalId
                            join saldtl in container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                            where salpay.DueAmount <= 0
                            select new { salpay, salinfo, saldtl };

                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.salinfo.CreateDate.Equals(Date));
                }

                var result = from o in query
                             where !o.saldtl.Product.Category.CategoryName.ToLower().Contains("extra".ToLower())
                             orderby o.salinfo.SalId ascending
                             group o by new { o.saldtl.Product.Category.CategoryName, o.saldtl.Quantity, o.saldtl.Product.CompanyInfo.CompName, o.saldtl.SalePrice, o.saldtl.Product.ProductOffSalePrice }
                                 into os
                                 select new InvenSalePaymentDtlDto
                                 {
                                     //Quantity=os.Sum(o=>o.saldtl.Quantity),
                                     BarQuantity = os.Sum(o => o.saldtl.BarQuantity),
                                     OffQuantity = os.Sum(o => o.saldtl.OffQuantity),
                                     CategoryName = os.Key.CategoryName,
                                     CompName = os.Key.CompName,
                                     Quantity = os.Sum(o => o.saldtl.Quantity),
                                     ProductSalePrice = os.Key.SalePrice * os.Key.Quantity,

                                     Fromdate = date,
                                     PaidAmount = os.Sum(o => o.saldtl.Quantity) * os.Key.SalePrice,
                                     //  CateringBill = os.Sum(o => o.salextra.CateringBill),
                                     //  RestuarentBill = os.Sum(o => o.salextra.RestuarentBill),
                                     //  BekaryBill = os.Sum(o => o.salextra.BekaryBill)

                                 };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }
        public List<InvenSalePaymentDtlDto> LoadDailyResturent(string date)
        {
            using (var container = new InventoryContainer())
            {

                DateTime Date;
                var query = from salpay in container.InvenSalePayments
                            join salinfo in container.InvenSalesInfoes on salpay.SalId equals salinfo.SalId
                            join saldtl in container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                            where salpay.DueAmount <= 0
                            select new { salpay, salinfo, saldtl };

                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.salinfo.CreateDate.Equals(Date));
                }

                var result = from o in query
                             where o.saldtl.Product.CompanyInfo.CompName.ToLower().Contains("rest".ToLower())
                             orderby o.salinfo.SalId ascending
                             group o by new { o.saldtl.Product.Category.CategoryName, o.saldtl.Product.ProductSalePrice }
                                 into os
                                 select new InvenSalePaymentDtlDto
                                 {


                                     PaidAmount = os.Sum(o => o.saldtl.SalePrice)


                                 };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }

        public List<InvenSalePaymentDtlDto> LoadDailyCatering(string date)
        {
            using (var container = new InventoryContainer())
            {

                DateTime Date;
                var query = from salpay in container.InvenSalePayments
                            join salinfo in container.InvenSalesInfoes on salpay.SalId equals salinfo.SalId
                            join saldtl in container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                            //  join salextra in container.InvenSaleXtraInfoes on salinfo.SalId equals salextra.SalId
                            where salpay.DueAmount <= 0
                            select new { salpay, salinfo, saldtl };

                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.salinfo.CreateDate.Equals(Date));
                }

                var result = from o in query
                             where o.saldtl.Product.CompanyInfo.CompName.ToLower().Contains("catering".ToLower())
                             orderby o.salinfo.SalId ascending
                             group o by new { o.saldtl.Product.Category.CategoryName, o.saldtl.Product.ProductSalePrice }
                                 into os
                                 select new InvenSalePaymentDtlDto
                                 {


                                     PaidAmount = os.Sum(o => o.saldtl.SalePrice)


                                 };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }
        public List<InvenSalePaymentDtlDto> LoadDailyBekary(string date)
        {
            using (var container = new InventoryContainer())
            {

                DateTime Date;
                var query = from salpay in container.InvenSalePayments
                            join salinfo in container.InvenSalesInfoes on salpay.SalId equals salinfo.SalId
                            join saldtl in container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                            //  join salextra in container.InvenSaleXtraInfoes on salinfo.SalId equals salextra.SalId
                            where salpay.DueAmount <= 0
                            select new { salpay, salinfo, saldtl };

                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.salinfo.CreateDate.Equals(Date));
                }

                var result = from o in query
                             where o.saldtl.Product.CompanyInfo.CompName.ToLower().Contains("bekar".ToLower())
                             orderby o.salinfo.SalId ascending
                             group o by new { o.saldtl.Product.Category.CategoryName, o.saldtl.Product.ProductSalePrice }
                                 into os
                                 select new InvenSalePaymentDtlDto
                                 {


                                     PaidAmount = os.Sum(o => o.saldtl.SalePrice)


                                 };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }
        public List<InvenSalePaymentDtlDto> LoadDailyGuestCharge(string date)
        {
            using (var container = new InventoryContainer())
            {

                DateTime Date;
                var query = from salpay in container.InvenSalePayments
                            join salinfo in container.InvenSalesInfoes on salpay.SalId equals salinfo.SalId
                            join saldtl in container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                            //join salextra in container.InvenSaleXtraInfoes on salinfo.SalId equals salextra.SalId
                            where salpay.DueAmount <= 0
                            select new { salpay, salinfo, saldtl };

                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.salinfo.CreateDate.Equals(Date));
                }

                var result = from o in query
                             where o.saldtl.Product.CompanyInfo.CompName.ToLower().Contains("guest".ToLower())
                             orderby o.salinfo.SalId ascending
                             group o by new { o.saldtl.Product.Category.CategoryName, o.saldtl.Product.ProductSalePrice }
                                 into os
                                 select new InvenSalePaymentDtlDto
                                 {


                                     PaidAmount = os.Sum(o => o.saldtl.Quantity * os.Key.ProductSalePrice)


                                 };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }
        public List<InvenSalePaymentDtlDto> DeleteAdjustment(int saldtlid)
        {
            using (var container = new InventoryContainer())
            {
                var data = from dtl in container.InvenSaleDtls
                           where dtl.SaleDtlId == saldtlid
                           select dtl;
                var result = (from o in data
                              select new InvenSalePaymentDtlDto
                              {
                                  SaleDtlId = o.SaleDtlId,
                                  SalId = o.SalId,
                                  ProductId = o.ProductId,
                                  Quantity = o.Quantity
                              }).ToList<InvenSalePaymentDtlDto>();
                /*
                   foreach (var content in data)
                   {
                       container.InvenSaleDtls.DeleteObject(content);
                   }
                   container.SaveChanges();
                  */
                return result;

            }
        }
        public void DeleteAdjustmentById(int saldtlid)
        {
            using (var container = new InventoryContainer())
            {
                var data = from dtl in container.InvenSaleDtls
                           where dtl.SaleDtlId == saldtlid
                           select dtl;
                foreach (var content in data)
                {
                    container.InvenSaleDtls.DeleteObject(content);
                }
                container.SaveChanges();
            }
        }
        public List<InvenSalePaymentDtlDto> GetPaymentId(int salid)
        {
            using (var container = new InventoryContainer())
            {
                var query = from sale in container.InvenSalePayments
                            join dtl in container.InvenSalesPaymentDtls on sale.SalId equals dtl.SalId
                            select new { sale, dtl };
                if (salid != 0)
                    query = query.Where(o => o.sale.SalId == salid);
                var result = (from o in query
                              select new InvenSalePaymentDtlDto
                              {
                                  SalePayDtlId = o.dtl.SalePayDtlId,
                                  SalePaymentId = o.sale.SalePaymentId
                              }).ToList<InvenSalePaymentDtlDto>();
                return result;
            }
        }
        public void DeleteSalePayment(int Salid)
        {
            using (var container = new InventoryContainer())
            {
                var query = from sal in container.InvenSalePayments
                            where sal.SalId == Salid
                            select sal;
                foreach (var content in query)
                {
                    container.InvenSalePayments.DeleteObject(content);
                }
                container.SaveChanges();
            }
        }
        public void DeleteSalePaymentDtl(int Salid)
        {
            using (var container = new InventoryContainer())
            {
                var query = from dtl in container.InvenSalesPaymentDtls
                            where dtl.SalId == Salid
                            select dtl;
                foreach (var content in query)
                {
                    container.InvenSalesPaymentDtls.DeleteObject(content);
                }
                container.SaveChanges();
            }
        }
        public void DeleteSalInfo(int Salid)
        {
            using (var container = new InventoryContainer())
            {
                var query = from dtl in container.InvenSalesInfoes
                            where dtl.SalId == Salid
                            select dtl;
                foreach (var content in query)
                {
                    container.InvenSalesInfoes.DeleteObject(content);
                }
                container.SaveChanges();
            }
        }




        // DUE SECTION





        public List<InvenSalePaymentDtlDto> LoadSalesDateDue(string FromDate, string ToDate)
        {
            using (var container = new InventoryContainer())
            {
                DateTime To, From;
                var query = from salinfo in container.InvenSalesInfoes
                            join salpay in container.InvenSalePayments on salinfo.SalId equals salpay.SalId
                            where salpay.DueAmount > 0
                            select new { salinfo, salpay };
                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);

                    From = Convert.ToDateTime(FromDate);
                    if (To < From)
                    {
                        DateTime toTime, fromTime;
                        toTime = From;
                        fromTime = To;
                        To = toTime;
                        From = fromTime;
                    }
                    query = query.Where(c => c.salinfo.CreateDate >= From && c.salinfo.CreateDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.salinfo.CreateDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.salinfo.CreateDate == From);
                }
                var result = (from o in query

                              group o by o.salinfo.CreateDate into os
                              select new InvenSalePaymentDtlDto
                              {
                                  CreateDate = os.Key
                              }).ToList<InvenSalePaymentDtlDto>();

                return result;
            }
        }

        public List<InvenSalePaymentDtlDto> LoadDailySaleWihoutCocktailDue(string date)
        {
            using (var container = new InventoryContainer())
            {

                DateTime Date;
                var query = from salpay in container.InvenSalePayments
                            join salinfo in container.InvenSalesInfoes on salpay.SalId equals salinfo.SalId
                            join saldtl in container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                            where salpay.DueAmount > 0
                            select new { salpay, salinfo, saldtl };

                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.salinfo.CreateDate.Equals(Date));
                }

                var result = from o in query
                             where !o.saldtl.Product.Category.CategoryName.ToLower().Contains("extra".ToLower()) && !o.saldtl.Product.Category.CategoryName.ToLower().Contains("cockt".ToLower())
                             orderby o.salinfo.SalId ascending
                             group o by new { o.saldtl.Product.CompanyInfo.CompName }
                                 into os
                                 select new InvenSalePaymentDtlDto
                                 {
                                     Quantity = os.Sum(o => o.saldtl.Quantity),
                                 };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }

        public List<InvenSalePaymentDtlDto> LoadDailySaleCocktailDue(string date)
        {
            using (var container = new InventoryContainer())
            {

                DateTime Date;
                var query = from saldtl in container.InvenSaleDtls
                            join salpay in container.InvenSalePayments on saldtl.SalId equals salpay.SalId
                            join cock in container.CocktailInfoes on saldtl.ProductId equals cock.CocktaiProId

                            where salpay.DueAmount > 0
                            select new { cock, saldtl };

                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.saldtl.InvenSalesInfo.CreateDate.Equals(Date));
                }

                var result = from o in query
                             where o.saldtl.Product.Category.CategoryName.ToLower().Contains("cockt".ToLower())

                             select new InvenSalePaymentDtlDto
                             {
                                 Quantity = o.saldtl.Quantity * o.cock.Quantity
                             };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }


        public List<InvenSalePaymentDtlDto> LoadDailySaleDue(string date)
        {
            using (var container = new InventoryContainer())
            {

                DateTime Date;
                var query = from salpay in container.InvenSalePayments
                            join salinfo in container.InvenSalesInfoes on salpay.SalId equals salinfo.SalId
                            join saldtl in container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                            where salpay.DueAmount > 0
                            select new { salpay, salinfo, saldtl };

                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.salinfo.CreateDate.Equals(Date));
                }

                var result = from o in query
                             where !o.saldtl.Product.Category.CategoryName.ToLower().Contains("extra".ToLower())
                             orderby o.salinfo.SalId ascending
                             group o by new { o.saldtl.Product.Category.CategoryName, o.saldtl.Quantity, o.saldtl.Product.CompanyInfo.CompName, o.saldtl.SalePrice, o.saldtl.Product.ProductOffSalePrice }
                                 into os
                                 select new InvenSalePaymentDtlDto
                                 {
                                     //Quantity=os.Sum(o=>o.saldtl.Quantity),
                                     BarQuantity = os.Sum(o => o.saldtl.BarQuantity),
                                     OffQuantity = os.Sum(o => o.saldtl.OffQuantity),
                                     CategoryName = os.Key.CategoryName,
                                     CompName = os.Key.CompName,
                                     Quantity = os.Sum(o => o.saldtl.Quantity),
                                     ProductSalePrice = os.Key.SalePrice * os.Key.Quantity,

                                     Fromdate = date,
                                     PaidAmount = os.Sum(o => o.saldtl.Quantity) * os.Key.SalePrice,
                                     //  CateringBill = os.Sum(o => o.salextra.CateringBill),
                                     //  RestuarentBill = os.Sum(o => o.salextra.RestuarentBill),
                                     //  BekaryBill = os.Sum(o => o.salextra.BekaryBill)

                                 };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }
        public List<InvenSalePaymentDtlDto> LoadDailyResturentDue(string date)
        {
            using (var container = new InventoryContainer())
            {

                DateTime Date;
                var query = from salpay in container.InvenSalePayments
                            join salinfo in container.InvenSalesInfoes on salpay.SalId equals salinfo.SalId
                            join saldtl in container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                            where salpay.DueAmount > 0
                            select new { salpay, salinfo, saldtl };

                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.salinfo.CreateDate.Equals(Date));
                }

                var result = from o in query
                             where o.saldtl.Product.CompanyInfo.CompName.ToLower().Contains("rest".ToLower())
                             orderby o.salinfo.SalId ascending
                             group o by new { o.saldtl.Product.Category.CategoryName, o.saldtl.Product.ProductSalePrice }
                                 into os
                                 select new InvenSalePaymentDtlDto
                                 {


                                     PaidAmount = os.Sum(o => o.saldtl.SalePrice)


                                 };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }

        public List<InvenSalePaymentDtlDto> LoadDailyCateringDue(string date)
        {
            using (var container = new InventoryContainer())
            {

                DateTime Date;
                var query = from salpay in container.InvenSalePayments
                            join salinfo in container.InvenSalesInfoes on salpay.SalId equals salinfo.SalId
                            join saldtl in container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                            //  join salextra in container.InvenSaleXtraInfoes on salinfo.SalId equals salextra.SalId
                            where salpay.DueAmount > 0
                            select new { salpay, salinfo, saldtl };

                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.salinfo.CreateDate.Equals(Date));
                }

                var result = from o in query
                             where o.saldtl.Product.CompanyInfo.CompName.ToLower().Contains("catering".ToLower())
                             orderby o.salinfo.SalId ascending
                             group o by new { o.saldtl.Product.Category.CategoryName, o.saldtl.Product.ProductSalePrice }
                                 into os
                                 select new InvenSalePaymentDtlDto
                                 {


                                     PaidAmount = os.Sum(o => o.saldtl.SalePrice)


                                 };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }
        public List<InvenSalePaymentDtlDto> LoadDailyBekaryDue(string date)
        {
            using (var container = new InventoryContainer())
            {

                DateTime Date;
                var query = from salpay in container.InvenSalePayments
                            join salinfo in container.InvenSalesInfoes on salpay.SalId equals salinfo.SalId
                            join saldtl in container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                            //  join salextra in container.InvenSaleXtraInfoes on salinfo.SalId equals salextra.SalId
                            where salpay.DueAmount > 0
                            select new { salpay, salinfo, saldtl };

                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.salinfo.CreateDate.Equals(Date));
                }

                var result = from o in query
                             where o.saldtl.Product.CompanyInfo.CompName.ToLower().Contains("bekar".ToLower())
                             orderby o.salinfo.SalId ascending
                             group o by new { o.saldtl.Product.Category.CategoryName, o.saldtl.Product.ProductSalePrice }
                                 into os
                                 select new InvenSalePaymentDtlDto
                                 {


                                     PaidAmount = os.Sum(o => o.saldtl.SalePrice)


                                 };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }
        public List<InvenSalePaymentDtlDto> LoadDailyGuestChargeDue(string date)
        {
            using (var container = new InventoryContainer())
            {

                DateTime Date;
                var query = from salpay in container.InvenSalePayments
                            join salinfo in container.InvenSalesInfoes on salpay.SalId equals salinfo.SalId
                            join saldtl in container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                            //join salextra in container.InvenSaleXtraInfoes on salinfo.SalId equals salextra.SalId
                            where salpay.DueAmount > 0
                            select new { salpay, salinfo, saldtl };

                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.salinfo.CreateDate.Equals(Date));
                }

                var result = from o in query
                             where o.saldtl.Product.CompanyInfo.CompName.ToLower().Contains("guest".ToLower())
                             orderby o.salinfo.SalId ascending
                             group o by new { o.saldtl.Product.Category.CategoryName, o.saldtl.Product.ProductSalePrice }
                                 into os
                                 select new InvenSalePaymentDtlDto
                                 {
                                     PaidAmount = os.Sum(o => o.saldtl.Quantity * os.Key.ProductSalePrice)
                                 };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }





    }
}
