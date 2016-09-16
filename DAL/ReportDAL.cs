using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;

namespace DAL
{
    public class ReportDAL
    {

        // operaton summary
        public List<ProductDTO> OperationSummary(int compid, int catid, string FromDate, string ToDate)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Products
                            join cate in Container.Categories on s.CategoryId equals cate.CatId
                            join comp in Container.CompanyInfoes on s.CompId equals comp.CompId

                            join cendtl in Container.InvenCenteralStoreStatus on s.ProductId equals cendtl.ProductId
                            join purdtl in Container.InvenCentralPurchaseDtls on s.ProductId equals purdtl.ProductId into outerpurdtl
                            from purdtl in outerpurdtl.DefaultIfEmpty()


                            select new { s, cate, comp, purdtl, cendtl };

                DateTime From, To;
                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    From = Convert.ToDateTime(FromDate);
                    // query = query.Where(c => c.s.CreateDate >= From && c.s.CreateDate <= To);

                    query = query.Where(c => c.purdtl.InvenCentralPurchaseInfo.CreateDate >= From && c.purdtl.InvenCentralPurchaseInfo.CreateDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.purdtl.InvenCentralPurchaseInfo.CreateDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.purdtl.InvenCentralPurchaseInfo.CreateDate == From);
                }

                if (catid != 0)
                    query = query.Where(c => c.cate.CatId.Equals(catid));

                if (compid != 0)
                    query = query.Where(c => c.comp.CompId.Equals(compid));

                var result = from o in query
                             // orderby o.s.ProductId
                             group o by new { o.s.ProductId, o.cate.CategoryName, o.comp.CompName, o.s.ProductName } into sales

                             select new ProductDTO
                             {
                                 ProductId = sales.Key.ProductId,
                                 CategoryName = sales.Key.CategoryName,
                                 ProductName = sales.Key.ProductName,
                                 CompName = sales.Key.CompName,

                                 PurQuantity = sales.Sum(c => (c.purdtl == null) ? 0 : c.purdtl.Quantity),
                                 PurAmount = sales.Sum(c => (c.purdtl == null) ? 0 : c.purdtl.PurchasePrice * c.purdtl.Quantity),
                                 Fromdate = FromDate,
                                 ToDate = ToDate,

                             };

                return result.ToList<ProductDTO>();
            }
        }


        public List<ProductDTO> PurchaseOperationSummary(int compid, int catid, string FromDate, string ToDate)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Products
                            join cate in Container.Categories on s.CategoryId equals cate.CatId
                            join comp in Container.CompanyInfoes on s.CompId equals comp.CompId

                            join cendtl in Container.InvenCenteralStoreStatus on s.ProductId equals cendtl.ProductId
                            join purdtl in Container.InvenCentralPurchaseDtls on s.ProductId equals purdtl.ProductId into outerpurdtl
                            from purdtl in outerpurdtl.DefaultIfEmpty()


                            select new { s, cate, comp, purdtl, cendtl };

                DateTime From, To;
                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    From = Convert.ToDateTime(FromDate);
                    // query = query.Where(c => c.s.CreateDate >= From && c.s.CreateDate <= To);

                    query = query.Where(c => c.purdtl.InvenCentralPurchaseInfo.CreateDate >= From && c.purdtl.InvenCentralPurchaseInfo.CreateDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.purdtl.InvenCentralPurchaseInfo.CreateDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.purdtl.InvenCentralPurchaseInfo.CreateDate == From);
                }

                if (catid != 0)
                    query = query.Where(c => c.cate.CatId.Equals(catid));

                if (compid != 0)
                    query = query.Where(c => c.comp.CompId.Equals(compid));

                var result = from o in query
                             orderby o.cendtl.CentralStoreId descending
                             select new ProductDTO
                             {
                                 ProductId = o.s.ProductId,
                                 CategoryName = o.cate.CategoryName,
                                 ProductName = o.s.ProductName,
                                 CompName = o.comp.CompName,
                                 QuantityPurchase = o.cendtl.QuantityPurchase,
                                 QuantityStore = o.cendtl.QuantityStore,
                                 QuantityLastPurchase = o.cendtl.QuantityLastPurchase,
                                 DateStored = o.cendtl.DateStored,
                                 DateUpdated = o.cendtl.DateUpdated,


                                 PurQuantity = o.purdtl.Quantity,
                                 PurAmount = o.purdtl.Quantity * o.s.ProductPurchasePrice,

                                 Fromdate = FromDate,
                                 ToDate = ToDate,

                             };

                return result.ToList<ProductDTO>();
            }
        }


        public List<ProductDTO> FinalOperationSummary(int compid, int catid, string FromDate, string ToDate)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Products
                            join cate in Container.Categories on s.CategoryId equals cate.CatId
                            join comp in Container.CompanyInfoes on s.CompId equals comp.CompId

                            join purdtl in Container.InvenCentralPurchaseDtls on s.ProductId equals purdtl.ProductId into outerpurdtl
                            from purdtl in outerpurdtl.DefaultIfEmpty()

                            join saldtl in Container.InvenSaleDtls on s.ProductId equals saldtl.ProductId into outersaldtl
                            from saldtl in outersaldtl.DefaultIfEmpty()
                            select new { s, cate, comp, purdtl, saldtl };

                DateTime From, To;
                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    From = Convert.ToDateTime(FromDate);
                    // query = query.Where(c => c.s.CreateDate >= From && c.s.CreateDate <= To);

                    query = query.Where(c => c.purdtl.InvenCentralPurchaseInfo.CreateDate >= From && c.purdtl.InvenCentralPurchaseInfo.CreateDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.purdtl.InvenCentralPurchaseInfo.CreateDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.purdtl.InvenCentralPurchaseInfo.CreateDate == From);
                }

                if (catid != 0)
                    query = query.Where(c => c.cate.CatId.Equals(catid));

                if (compid != 0)
                    query = query.Where(c => c.comp.CompId.Equals(compid));

                var result = from o in query
                             // orderby o.s.ProductId
                             group o by new { o.s.ProductId, o.cate.CategoryName, o.comp.CompName, o.s.ProductName } into sales

                             select new ProductDTO
                             {
                                 ProductId = sales.Key.ProductId,
                                 CategoryName = sales.Key.CategoryName,
                                 ProductName = sales.Key.ProductName,
                                 CompName = sales.Key.CompName,
                                 PurQuantity = sales.Sum(c => (c.purdtl == null) ? 0 : c.purdtl.Quantity),
                                 SaleQuantity = sales.Sum(c => (c.saldtl == null) ? 0 : c.saldtl.Quantity),
                                 SalAmount = sales.Sum(c => (c.saldtl == null) ? 0 : c.saldtl.SalePrice * c.saldtl.Quantity),
                                 PurAmount = sales.Sum(c => (c.purdtl == null) ? 0 : c.purdtl.PurchasePrice * c.purdtl.Quantity),
                                 Fromdate = FromDate,
                                 ToDate = ToDate
                             };

                return result.ToList<ProductDTO>();
            }
        }




        public List<ProductDTO> SaleOperationSummary(int compid, int catid, string FromDate, string ToDate)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Products
                            join cate in Container.Categories on s.CategoryId equals cate.CatId
                            join comp in Container.CompanyInfoes on s.CompId equals comp.CompId


                            join saldtl in Container.InvenSaleDtls on s.ProductId equals saldtl.ProductId into outersaldtl
                            from saldtl in outersaldtl.DefaultIfEmpty()
                            where saldtl.TransectionType.Equals(null)
                            select new { s, cate, comp, saldtl };

                DateTime From, To;
                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    From = Convert.ToDateTime(FromDate);
                    // query = query.Where(c => c.s.CreateDate >= From && c.s.CreateDate <= To);

                    query = query.Where(c => c.saldtl.InvenSalesInfo.CreateDate >= From && c.saldtl.InvenSalesInfo.CreateDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.saldtl.InvenSalesInfo.CreateDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.saldtl.InvenSalesInfo.CreateDate == From);
                }

                if (catid != 0)
                    query = query.Where(c => c.cate.CatId.Equals(catid));

                if (compid != 0)
                    query = query.Where(c => c.comp.CompId.Equals(compid));

                var result = from o in query
                             // orderby o.s.ProductId
                             group o by new { o.s.ProductId, o.cate.CategoryName, o.comp.CompName, o.s.ProductName } into sales

                             select new ProductDTO
                             {
                                 ProductId = sales.Key.ProductId,
                                 CategoryName = sales.Key.CategoryName,
                                 ProductName = sales.Key.ProductName,
                                 CompName = sales.Key.CompName,
                                 // PurQuantity = sales.Sum(c => (c.purdtl == null) ? 0 : c.purdtl.Quantity),
                                 SaleQuantity = sales.Sum(c => (c.saldtl == null) ? 0 : c.saldtl.Quantity),
                                 SalAmount = sales.Sum(c => (c.saldtl == null) ? 0 : c.saldtl.SalePrice * c.saldtl.Quantity),
                                 //   PurAmount = sales.Sum(c => (c.purdtl == null) ? 0 : c.purdtl.PurchasePrice * c.purdtl.Quantity),
                                 Fromdate = FromDate,
                                 ToDate = ToDate

                             };

                return result.ToList<ProductDTO>();
            }
        }

        //Central to party product rept
        public List<InvenChangePaymentDtlDto> Return_Central_To_Party_ProductRpt(int retunno)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from central in Container.InvenCentralReturns
                            join brRet in Container.InvenBranchReturns on central.BranchReturnId equals brRet.BranchReturnId
                            join chdtl in Container.InvenChangeDtls on brRet.ChangeDtlId equals chdtl.ChangeDtlId
                            join chinfo in Container.InvenChangeInfoes on chdtl.ChangeId equals chinfo.ChangeId
                            select new { central, brRet, chdtl, chinfo };

                var result = from o in query
                             orderby o.central.CentralReturnId ascending
                             where o.central.ReturnNo.Equals(retunno)
                             select new InvenChangePaymentDtlDto
                             {
                                 ReturnDate = o.central.ReturnDate,
                                 CategoryName = o.chdtl.Product.Category.CategoryName,
                                 CompName = o.chdtl.Product.CompanyInfo.CompName,
                                 ProductName = o.chdtl.Product.ProductName,
                                 Quantity = o.chdtl.Quantity,
                                 ProductId = o.chdtl.Product.ProductId,
                                 BrProName = o.chinfo.InvenBranchProfile.BrProName,
                                 ReturnNo = o.central.ReturnNo
                             };
                return result.ToList<InvenChangePaymentDtlDto>();
            }
        }
        //load return product send to central company 
        public List<InvenChangePaymentDtlDto> Branchwise_Return_ProductRpt(int retunno)
        {

            using (var Container = new InventoryContainer())
            {
                var query = from brRet in Container.InvenBranchReturns
                            join chdtl in Container.InvenChangeDtls on brRet.ChangeDtlId equals chdtl.ChangeDtlId
                            join chinfo in Container.InvenChangeInfoes on chdtl.ChangeId equals chinfo.ChangeId
                            select new { brRet, chdtl, chinfo };
                var result = from o in query
                             orderby o.brRet.BranchReturnId ascending
                             where o.brRet.ReturnNo.Equals(retunno)
                             select new InvenChangePaymentDtlDto
                             {
                                 ReturnDate = o.brRet.ReturnDate,
                                 CategoryName = o.chdtl.Product.Category.CategoryName,
                                 CompName = o.chdtl.Product.CompanyInfo.CompName,
                                 ProductName = o.chdtl.Product.ProductName,
                                 Quantity = o.chdtl.Quantity,
                                 ProductId = o.chdtl.Product.ProductId,
                                 BrProName = o.chinfo.InvenBranchProfile.BrProName,
                                 ReturnNo = o.brRet.ReturnNo
                             };
                return result.ToList<InvenChangePaymentDtlDto>();
            }
        }
        //load sales  rating of product 
        public List<InvenSalePaymentDtlDto> SalesRating_BranchWise(int catid, int brid, string FromDate, string ToDate)
        {
            DateTime From, To;
            using (var Container = new InventoryContainer())
            {
                var query = from saldtl in Container.InvenSaleDtls
                            join salinfo in Container.InvenSalesInfoes on saldtl.SalId equals salinfo.SalId

                            select new { saldtl, salinfo };

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
                if (catid != 0)
                    query = query.Where(c => c.saldtl.Product.Category.CatId.Equals(catid));

                if (brid != 0)
                    query = query.Where(c => c.salinfo.InvenBranchProfile.BrProId.Equals(brid));


                var result = from o in query
                             group o by new { o.saldtl.Product.Category.CatId, o.saldtl.Product.Category.CategoryName, o.saldtl.Product.CompanyInfo.CompName, o.saldtl.Product.ProductName, o.saldtl.Product.CenterReorderValue } into sales

                             select new InvenSalePaymentDtlDto
                             {
                                 CatId = sales.Key.CatId,
                                 CategoryName = sales.Key.CategoryName,
                                 ProductName = sales.Key.ProductName,
                                 CompName = sales.Key.CompName,
                                 Quantity = sales.Sum(s => s.saldtl.Quantity),
                                 SalePrice = sales.Sum(s => s.saldtl.SalePrice * s.saldtl.Quantity),
                                 Fromdate = FromDate,
                                 ToDate = ToDate
                             };
                return result.ToList<InvenSalePaymentDtlDto>();
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
                            join saldtl in Container.InvenSaleDtls on salpay.SalId equals saldtl.SalId
                            join salpaydtls in Container.InvenSalesPaymentDtls on salinfo.SalId equals salpaydtls.SalId
                            select new { salpay, salinfo, saldtl, salpaydtls };

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
                             orderby o.salinfo.SalId ascending

                             select new InvenSalePaymentDtlDto
                             {
                                 SalId = o.salinfo.SalId,
                                 BrProId = o.salinfo.InvenBranchProfile.BrProId,
                                 BrProName = o.salinfo.InvenBranchProfile.BrProName,
                                 CreateBy = o.salinfo.CreateBy,
                                 CreateDate = o.salinfo.CreateDate,
                                 TotalPrice = o.salpay.TotalPrice,
                                 PaidAmount = o.salpay.PaidAmount,
                                 DueAmount = o.salpay.DueAmount,
                                 Quantity = o.saldtl.Quantity,
                                 PaymentMode = o.salpaydtls.PaymentMode


                             };
                return result.ToList<InvenSalePaymentDtlDto>();
            }
        }

        // Profit Branch wise

        public List<InvenSalePaymentDtlDto> BranchWise_Profit(int salid, int brid, string FromDate, string ToDate)
        {
            DateTime From, To;
            using (var Container = new InventoryContainer())
            {
                var query = from salinfo in Container.InvenSalesInfoes
                            join salpay in Container.InvenSalePayments on salinfo.SalId equals salpay.SalId
                            join saldtl in Container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                            join proinfo in Container.Products on saldtl.ProductId equals proinfo.ProductId
                            join salpaydtls in Container.InvenSalesPaymentDtls on salinfo.SalId equals salpaydtls.SalId
                            select new { salpay, salinfo, saldtl, salpaydtls, proinfo };

                if (!String.IsNullOrEmpty(FromDate) && !String.IsNullOrEmpty(ToDate))
                {
                    To = DateTime.Parse(ToDate);
                    //To = To.AddDays(1);
                    From = DateTime.Parse(FromDate);

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
                             orderby o.salinfo.SalId ascending

                             select new InvenSalePaymentDtlDto
                             {
                                 SalId = o.salinfo.SalId,
                                 BrProId = o.salinfo.InvenBranchProfile.BrProId,
                                 BrProName = o.salinfo.InvenBranchProfile.BrProName,
                                 CreateBy = o.salinfo.CreateBy,
                                 CreateDate = o.salinfo.CreateDate,
                                 TotalPrice = o.salpay.TotalPrice,
                                 PaidAmount = o.salpay.PaidAmount,
                                 DueAmount = o.salpay.DueAmount,
                                 Quantity = o.saldtl.Quantity,
                                 PaymentMode = o.salpaydtls.PaymentMode,
                                 ProductPuchasePrice = o.proinfo.ProductPurchasePrice,
                                 ProductSalePrice = o.proinfo.ProductSalePrice,
                                 ProductName = o.proinfo.ProductName
                             };
                return result.ToList<InvenSalePaymentDtlDto>();
            }
        }

        // Sales Info Branch Wisr
        public List<InvenSalePaymentDtlDto> BranchSalesProduct(int salid)
        {
            using (var Container = new InventoryContainer())
            {
                var query =
                    from salpaydtl in Container.InvenSalesPaymentDtls
                    join salpay in Container.InvenSalePayments on salpaydtl.SalId equals salpay.SalId
                    join salinfo in Container.InvenSalesInfoes on salpaydtl.SalId equals salinfo.SalId
                    join saldtl in Container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                    // join xtra in Container.InvenSaleXtraInfoes on salinfo.SalId equals xtra.SalId

                    select new { salpaydtl, salpay, salinfo, saldtl };

                if (salid != 0)
                    query = query.Where(c => c.salinfo.SalId.Equals(salid));


                var result = from o in query

                             select new InvenSalePaymentDtlDto
                             {
                                 //paydtl
                                 PaymentMode = o.salpaydtl.PaymentMode,
                                 PaidAmount = o.salpay.PaidAmount,
                                 Note = o.salpaydtl.Note,
                                 PaymentBy = o.salpaydtl.PaymentBy,
                                 PaymentDate = o.salpaydtl.PaymentDate,
                                 CardNo = o.salpaydtl.CardNo,
                                 ApprCode = o.salpaydtl.ApprCode,
                                 BankName = o.salpaydtl.BankName,
                                 HolderName = o.salpaydtl.HolderName,
                                 // payment info
                                 DueAmount = o.salpay.DueAmount,
                                 Discount = o.salpay.Discount,
                                 TotalPrice = o.salpay.TotalPrice,
                                 Vat = o.salpay.Vat,
                                 DiscountDescription = o.salpay.DiscountDescription,

                                 // salinfo
                                 SalId = o.salinfo.SalId,
                                 CusContactAdd = o.salinfo.CusContactAdd,
                                 CusMobileNo = o.salinfo.CusMobileNo,
                                 CustomerName = o.salinfo.CustomerName,
                                 CusRemarks = o.salinfo.CusRemarks,
                                 MemberId = o.salinfo.MemberId,
                                 MemberNo = o.salinfo.Member.MemberNo,
                                 MemberName = o.salinfo.Member.FullName,
                                 //saldtl
                                 SalePrice = o.saldtl.SalePrice,
                                 Quantity = o.saldtl.Quantity,
                                 TotalPriceQuan_Price = o.saldtl.SalePrice * o.saldtl.Quantity,
                                 // other productinfo
                                 CompName = o.saldtl.Product.CompanyInfo.CompName,
                                 ProductName = o.saldtl.Product.ProductName,
                                 BrProName = o.salinfo.InvenBranchProfile.BrProName,
                                 CategoryName = o.saldtl.Product.Category.CategoryName,
                                 SaleType = o.saldtl.SaleType,
                                 CreateDate = o.salinfo.CreateDate
                                 //xtra
                                 /*
                                                                  RestuarentBill = o.xtra.RestuarentBill,
                                                                  BekaryBill = o.xtra.BekaryBill,
                                                                  CateringBill = o.xtra.CateringBill
                                 */
                             };
                return result.ToList<InvenSalePaymentDtlDto>();
            }
        }


        public List<InvenTempSaleDTO> BranchTempSalesProduct(int memid, string tdate)
        {
            using (var Container = new InventoryContainer())
            {
                DateTime date;
                var query =
                   from temp in Container.InvenTempSales
                   join mem in Container.Members on temp.MemberId equals mem.MemberId
                   select new { temp, mem };

                if (memid != 0)
                    query = query.Where(c => c.mem.MemberId==memid);
                if (!String.IsNullOrEmpty(tdate))
                {
                    date = DateTime.Parse(tdate);
                    query = query.Where(o => o.temp.CreateDate==date);
                }


                var result = from o in query

                             select new InvenTempSaleDTO
                             {
                                 MemberName=o.mem.FullName,
                                 MemberNo=o.mem.MemberNo,
                                 Category=o.temp.Category,
                                 SubCategory=o.temp.SubCategory,
                                 ProductId=o.temp.ProductId,
                                 Unit=o.temp.Unit,
                                 PegSize=o.temp.PegSize,
                                 UnitPrize=o.temp.UnitPrize,
                                 SaleType=o.temp.SaleType,
                                 CreateDate=o.temp.CreateDate,
                                 TotalPricr=o.temp.UnitPrize*o.temp.PegSize
                             };
                return result.ToList<InvenTempSaleDTO>();
            }
        }

        // Stock Status In BranchWise
        public List<InvenStoreStatusDto> BranchStockStatus(int proid, int catid, int compid, int brproid)
        {
            using (var Container = new InventoryContainer())
            {
                var query =
                    from purdtl in Container.InvenStoreStatus
                    select new { purdtl };

                if (proid != 0)
                    query = query.Where(c => c.purdtl.Product.ProductId.Equals(proid));
                if (catid != 0)
                    query = query.Where(c => c.purdtl.Product.Category.CatId.Equals(catid));
                if (compid != 0)
                    query = query.Where(c => c.purdtl.Product.CompanyInfo.CompId.Equals(compid));
                if (brproid != 0)
                    query = query.Where(c => c.purdtl.InvenBranchProfile.BrProId.Equals(brproid));

                var result = from o in query

                             select new InvenStoreStatusDto
                             {

                                 // comp info
                                 CompId = o.purdtl.Product.CompanyInfo.CompId,
                                 CompName = o.purdtl.Product.CompanyInfo.CompName,

                                 // product 
                                 ProductName = o.purdtl.Product.ProductName,
                                 ProductId = o.purdtl.Product.ProductId,
                                 BrProId = o.purdtl.InvenBranchProfile.BrProId,
                                 BrProName = o.purdtl.InvenBranchProfile.BrProName,
                                 CategoryName = o.purdtl.Product.Category.CategoryName,

                                 QuantityStore = o.purdtl.QuantityStore,
                                 QuantityPurchase = o.purdtl.QuantityPurchase,
                                 QuantityLastPurchase = o.purdtl.QuantityLastPurchase,
                                 DateUpdated = o.purdtl.DateUpdated,
                                 DateStored = o.purdtl.DateStored,
                             };
                return result.ToList<InvenStoreStatusDto>();
            }
        }

        // Stock Status Details With Client Requirment
        public List<InvenStoreStatusDto> BranchStockStatus_Details(int proid, int catid, int compid, int brproid)
        {
            using (var Container = new InventoryContainer())
            {
                var query =
                    from BrStore in Container.InvenStoreStatus
                    join reorder in Container.InvenReorders on BrStore.ProductId equals reorder.ProductId
                    join purdtl in Container.InvenCentralPurchaseDtls on BrStore.ProductId equals purdtl.ProductId
                    select new { BrStore, reorder, purdtl };

                if (proid != 0)
                    query = query.Where(c => c.BrStore.Product.ProductId.Equals(proid));
                if (catid != 0)
                    query = query.Where(c => c.BrStore.Product.Category.CatId.Equals(catid));
                if (compid != 0)
                    query = query.Where(c => c.BrStore.Product.CompanyInfo.CompId.Equals(compid));
                if (brproid != 0)
                    query = query.Where(c => c.BrStore.InvenBranchProfile.BrProId.Equals(brproid));

                var result = from o in query

                             select new InvenStoreStatusDto
                             {

                                 // comp info
                                 CompId = o.BrStore.Product.CompanyInfo.CompId,
                                 CompName = o.BrStore.Product.CompanyInfo.CompName,
                                 ProductPurchasePrice = o.BrStore.Product.ProductPurchasePrice,
                                 // product 
                                 ProductName = o.BrStore.Product.ProductName,
                                 BrProId = o.BrStore.InvenBranchProfile.BrProId,
                                 BrProName = o.BrStore.InvenBranchProfile.BrProName,
                                 CategoryName = o.BrStore.Product.Category.CategoryName,
                                 // store status
                                 QuantityStore = o.BrStore.QuantityStore,
                                 QuantityPurchase = o.BrStore.QuantityPurchase,
                                 QuantityLastPurchase = o.BrStore.QuantityLastPurchase,
                                 DateUpdated = o.BrStore.DateUpdated,
                                 DateStored = o.BrStore.DateStored,

                                 // reorder rate of in
                                 //ProductPurchasePrice=o.BrStore.Product.ProductPurchasePrice,
                                 RateOfInterest = o.reorder.RateOfInterest,
                                 TotalPurPrice = o.BrStore.Product.ProductPurchasePrice * o.BrStore.QuantityStore,
                                 TotalSalePrice = o.BrStore.Product.ProductSalePrice * o.BrStore.QuantityStore,

                                 SalesPrice = o.BrStore.Product.ProductSalePrice,

                             };
                return result.ToList<InvenStoreStatusDto>();
            }
        }
        public List<InvenStoreStatusDto> BranchStockStatus_Details_Rpt(int proid, int catid, int compid, int brproid)
        {
            using (var Container = new InventoryContainer())
            {
                var query =
                    from BrStore in Container.InvenStoreStatus
                    join proinfo in Container.Products on BrStore.ProductId equals proinfo.ProductId
                    join compinfo in Container.CompanyInfoes on proinfo.CompId equals compinfo.CompId
                    join catinfo in Container.Categories on proinfo.CategoryId equals catinfo.CatId

                    select new { BrStore, proinfo, compinfo, catinfo };

                //                "SELECT        InvenStoreStatus.InvenStoreId, InvenStoreStatus.ProductId, InvenStoreStatus.BrProId, InvenStoreStatus.QuantityStore, Products.ProductName, 
                //                         Products.ProductPurchasePrice, Products.ProductSalePrice, Categories.CategoryName, CompanyInfoes.CompName, Categories.CatId, CompanyInfoes.CompId
                //FROM            InvenStoreStatus INNER JOIN
                //                         Products ON InvenStoreStatus.ProductId = Products.ProductId INNER JOIN
                //                         CompanyInfoes ON Products.CompId = CompanyInfoes.CompId INNER JOIN
                //                         Categories ON Products.CategoryId = Categories.CatId
                //WHERE        (InvenStoreStatus.BrProId = @bid) OR
                //                         (CompanyInfoes.CompId = @comid) OR
                //                         (Categories.CatId = @catid)"
                if (proid != 0)
                    query = query.Where(c => c.BrStore.Product.ProductId.Equals(proid));
                if (catid != 0)
                    query = query.Where(c => c.BrStore.Product.Category.CatId.Equals(catid));
                if (compid != 0)
                    query = query.Where(c => c.BrStore.Product.CompanyInfo.CompId.Equals(compid));
                if (brproid != 0)
                    query = query.Where(c => c.BrStore.InvenBranchProfile.BrProId.Equals(brproid));

                var result = from o in query

                             select new InvenStoreStatusDto
                             {

                                 // comp info
                                 CompId = o.BrStore.Product.CompanyInfo.CompId,
                                 CompName = o.BrStore.Product.CompanyInfo.CompName,
                                 ProductPurchasePrice = o.BrStore.Product.ProductPurchasePrice,
                                 // product 
                                 ProductName = o.BrStore.Product.ProductName,
                                 BrProId = o.BrStore.InvenBranchProfile.BrProId,
                                 BrProName = o.BrStore.InvenBranchProfile.BrProName,
                                 CategoryName = o.BrStore.Product.Category.CategoryName,
                                 // store status
                                 QuantityStore = o.BrStore.QuantityStore,
                                 QuantityPurchase = o.BrStore.QuantityPurchase,
                                 QuantityLastPurchase = o.BrStore.QuantityLastPurchase,
                                 DateUpdated = o.BrStore.DateUpdated,
                                 DateStored = o.BrStore.DateStored,
                                 TotalPurPrice = o.BrStore.Product.ProductPurchasePrice * o.BrStore.QuantityStore,
                                 TotalSalePrice = o.BrStore.Product.ProductSalePrice * o.BrStore.QuantityStore,
                                 ProductSalePrice = o.BrStore.Product.ProductSalePrice,
                                 SalesPrice = o.BrStore.Product.ProductSalePrice,

                             };
                return result.ToList<InvenStoreStatusDto>();
            }
        }


        //

        public List<InvenStoreStatusDto> BranchStockStatus_Rpt(int proid, int catid, int compid, int brproid)
        {
            using (var Container = new InventoryContainer())
            {
                var query =
                    from BrStore in Container.InvenStoreStatus

                    select new { BrStore };


                var result = from o in query

                             select new InvenStoreStatusDto
                             {

                                 // comp info
                                 CompId = o.BrStore.Product.CompanyInfo.CompId,
                                 CompName = o.BrStore.Product.CompanyInfo.CompName,
                                 ProductPurchasePrice = o.BrStore.Product.ProductPurchasePrice,
                                 // product 
                                 ProductName = o.BrStore.Product.ProductName,
                                 BrProId = o.BrStore.InvenBranchProfile.BrProId,
                                 BrProName = o.BrStore.InvenBranchProfile.BrProName,
                                 CategoryName = o.BrStore.Product.Category.CategoryName,
                                 // store status
                                 QuantityStore = o.BrStore.QuantityStore,
                                 QuantityPurchase = o.BrStore.QuantityPurchase,
                                 QuantityLastPurchase = o.BrStore.QuantityLastPurchase,
                                 DateUpdated = o.BrStore.DateUpdated,
                                 DateStored = o.BrStore.DateStored,
                                 TotalPurPrice = o.BrStore.Product.ProductPurchasePrice * o.BrStore.QuantityStore,
                                 TotalSalePrice = o.BrStore.Product.ProductSalePrice * o.BrStore.QuantityStore,
                                 ProductSalePrice = o.BrStore.Product.ProductSalePrice,
                                 SalesPrice = o.BrStore.Product.ProductSalePrice,

                             };
                return result.ToList<InvenStoreStatusDto>();
            }
        }

        // Stock Status In Central
        public List<InvenCentralStoreStatusDTO> CentralStoreStatus(int proid, int catid, int compid)
        {
            using (var Container = new InventoryContainer())
            {
                var query =
                    from purdtl in Container.InvenCenteralStoreStatus

                    select new { purdtl, };

                if (proid != 0)
                    query = query.Where(c => c.purdtl.Product.ProductId.Equals(proid));
                if (catid != 0)
                    query = query.Where(c => c.purdtl.Product.Category.CatId.Equals(catid));
                if (compid != 0)
                    query = query.Where(c => c.purdtl.Product.CompanyInfo.CompId.Equals(compid));

                var result = from o in query
                             where !o.purdtl.Product.Category.CategoryName.ToLower().Contains("extra".ToLower()) && !o.purdtl.Product.Category.CategoryName.ToLower().Contains("cock".ToLower())
                             select new InvenCentralStoreStatusDTO
                             {

                                 // comp info
                                 CompId = o.purdtl.Product.CompanyInfo.CompId,
                                 CompName = o.purdtl.Product.CompanyInfo.CompName,

                                 // product 
                                 ProductName = o.purdtl.Product.ProductName,
                                 CenterReorderValue = o.purdtl.Product.CenterReorderValue,
                                 // category
                                 ProductPurchasePrice = o.purdtl.Product.ProductPurchasePrice,
                                 CategoryName = o.purdtl.Product.Category.CategoryName,

                                 QuantityStore = o.purdtl.QuantityStore,
                                 TotalPurPrice = o.purdtl.QuantityStore * o.purdtl.Product.ProductPurchasePrice
                             };
                return result.ToList<InvenCentralStoreStatusDTO>();
            }
        }

        // Branch Challan 
        public List<InvenCentralChallanDtlDTO> Challan_BranchWiseRpt(int challanid)
        {
            using (var Container = new InventoryContainer())
            {
                var query =
                    from challdtl in Container.InvenCentralChallanDtls
                    join challinfo in Container.InvenCentralChallanInfoes on challdtl.ChallanId equals challinfo.ChallanId

                    select new { challdtl, challinfo };
                if (challanid != 0)
                    query = query.Where(c => c.challinfo.ChallanId.Equals(challanid));

                var result = from o in query

                             select new InvenCentralChallanDtlDTO
                             {
                                 TotalPrice = o.challdtl.ChallanPrice * o.challdtl.ChallanQuantity,
                                 PurReqNo = o.challinfo.PurReqNo,
                                 ChallanDate = o.challinfo.ChallanDate,
                                 CompName = o.challdtl.Product.CompanyInfo.CompName,
                                 ChallanId = o.challinfo.ChallanId,
                                 // product 
                                 ProductName = o.challdtl.Product.ProductName + "-" + o.challdtl.Product.Unit.UnitName,
                                 // category
                                 CategoryName = o.challdtl.Product.Category.CategoryName,
                                 ChallanPrice = o.challdtl.ChallanPrice,
                                 ChallanQuantity = o.challdtl.ChallanQuantity,
                                 // branch
                                 BrProName = o.challinfo.InvenBranchProfile.BrProName
                             };
                return result.ToList<InvenCentralChallanDtlDTO>();
            }
        }
        // purchase due payment
        public List<InvenCentralPurchasePaymentDTO> PurchasePartialPaymentRptDal(int PurPayDtlId)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from purpay in Container.InvenCentralPurchcasePaymentDtls
                            join purpayinfo in Container.InvenCentralPurchcasePayments on purpay.PurPaymentId equals purpayinfo.PurPaymentId
                            join purinfo in Container.InvenCentralPurchaseInfoes on purpayinfo.PurId equals purinfo.PurId
                            join purdtl in Container.InvenCentralPurchaseDtls on purinfo.PurId equals purdtl.PurId
                            select new { purinfo, purpay, purpayinfo, purdtl };

                var result = from o in query
                             where o.purpay.PurPayDtlId.Equals(PurPayDtlId)
                             select new InvenCentralPurchasePaymentDTO
                             {
                                 // companuy info
                                 CompName = o.purdtl.Product.CompanyInfo.CompName,
                                 MobileNo = o.purdtl.Product.CompanyInfo.CompMobile1,
                                 //  pur payment dtl
                                 PurPayDtlId = o.purpay.PurPayDtlId,
                                 PaidAmount = o.purpay.PaidAmount,
                                 DueAmount = o.purpay.DueAmount,
                                 PaymentBy = o.purpay.PaymentBy,
                                 PaymentDate = o.purpay.PaymentDate,
                                 PaymentMode = o.purpay.PaymentMode,
                                 TotalPrice = o.purpay.TotalPrice,
                                 // pur info
                                 PurId = o.purinfo.PurId,
                                 PurchaseDate = o.purinfo.CreateDate,
                                 SalesManName = o.purinfo.SalesManName
                             };
                return result.ToList<InvenCentralPurchasePaymentDTO>();
            }
        }

        // purchse order rept
        public List<InvenCentralPurchasePaymentDTO> PurchaseOrderRpt(int purorderno)
        {
            using (var Container = new InventoryContainer())
            {
                var query =
                    from purdtl in Container.InvenCentrealPurOrders

                    select new { purdtl, };
                if (purorderno != 0)
                    query = query.Where(c => c.purdtl.PurOrderNO.Equals(purorderno));

                var result = from o in query

                             select new InvenCentralPurchasePaymentDTO
                             {
                                 TotalPrice = o.purdtl.UnitPrice * o.purdtl.Quantity,
                                 // pur info

                                 PurorderNo = o.purdtl.PurOrderNO,
                                 // comp info
                                 CompId = o.purdtl.Product.CompanyInfo.CompId,
                                 CompName = o.purdtl.Product.CompanyInfo.CompName,
                                 CompMbbile = o.purdtl.Product.CompanyInfo.CompMobile1,
                                 // product 
                                 ProductName = o.purdtl.Product.ProductName,
                                 // category
                                 CategoryName = o.purdtl.Product.Category.CategoryName,
                                 PurchasePrice = o.purdtl.UnitPrice,
                                 Quantity = o.purdtl.Quantity
                             };
                return result.ToList<InvenCentralPurchasePaymentDTO>();
            }
        }
        // purchase product list
        public List<InvenCentralPurchasePaymentDTO> PurchaseProductReptNew(int purid)
        {
            using (var Container = new InventoryContainer())
            {
                var query =
                    from purinfo in Container.InvenCentralPurchaseInfoes
                    join purdtl in Container.InvenCentralPurchaseDtls on purinfo.PurId equals purdtl.PurId

                    select new { purinfo, purdtl, };
                if (purid != 0)
                    query = query.Where(c => c.purinfo.PurId.Equals(purid));

                var result = from o in query

                             select new InvenCentralPurchasePaymentDTO
                             {
                                 TotalPrice = o.purdtl.PurchasePrice * o.purdtl.Quantity,
                                 // pur info
                                 PurId = o.purinfo.PurId,
                                 SalesManName = o.purinfo.SalesManName,
                                 PurorderNo = o.purinfo.PurOrderNo,
                                 // comp info
                                 CompId = o.purdtl.Product.CompanyInfo.CompId,
                                 CompName = o.purdtl.Product.CompanyInfo.CompName,
                                 CompMbbile = o.purdtl.Product.CompanyInfo.CompMobile1,
                                 // product 
                                 ProductId = o.purdtl.Product.ProductId,
                                 ProductName = o.purdtl.Product.ProductName,
                                 // category
                                 CatId = o.purdtl.Product.Category.CatId,
                                 CategoryName = o.purdtl.Product.Category.CategoryName,
                                 //purchase dtl
                                 PurchaseDtlID = o.purdtl.PurchaseDtlID,
                                 PurchasePrice = o.purdtl.PurchasePrice,
                                 Quantity = o.purdtl.Quantity
                             };
                return result.ToList<InvenCentralPurchasePaymentDTO>();
            }
        }

        public List<InvenSalePaymentDtlDto> LoadDailySale(string date, string TotalSale, string GuestCharge, string card, string ExtraBill, string GouestChargePlus, string TotalAmount, string BarSale, string CateringSale, string BekarySale, string RestuarentSale, string GuestSale, string quan)
        {
            using (var container = new InventoryContainer())
            {

                double TotalSale1 = double.Parse(TotalSale), GuestCharge1 = double.Parse(GuestCharge), BarSale1 = double.Parse(BarSale), CateringSale1 = double.Parse(CateringSale), BekarySale1 = double.Parse(BekarySale), RestuarentSale1 = double.Parse(RestuarentSale), GuestSale1 = double.Parse(GuestSale),
                   card1 = double.Parse(card), quani = double.Parse(quan), ExtraBill1 = double.Parse(ExtraBill), GouestChargePlus1 = double.Parse(GouestChargePlus), TotalAmount1 = double.Parse(TotalAmount);

                DateTime Date;
                var query = from salpay in container.InvenSalePayments
                            join salinfo in container.InvenSalesInfoes on salpay.SalId equals salinfo.SalId
                            join saldtl in container.InvenSaleDtls on salinfo.SalId equals saldtl.SalId
                            where salpay.DueAmount<= 0
                            select new { salpay, salinfo, saldtl };

                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.salinfo.CreateDate.Equals(Date));
                }
                DateTime ReportDate = DateTime.Parse(date);
                var result = from o in query
                             where !o.saldtl.Product.Category.CategoryName.ToLower().Contains("extra".ToLower())
                             orderby o.salinfo.SalId ascending
                             group o by new { o.saldtl.Product.Category.CategoryName, o.saldtl.Product.CompanyInfo.CompName, o.saldtl.BarPrice, o.saldtl.OffPrice }
                                 into os
                                 select new InvenSalePaymentDtlDto
                                 {
                                     //Quantity=os.Sum(o=>o.saldtl.Quantity),
                                     BarQuantity = os.Sum(o => o.saldtl.BarQuantity),
                                     OffQuantity = os.Sum(o => o.saldtl.OffQuantity),
                                     BarPrice = os.Key.BarPrice,
                                     OffPrice = os.Key.OffPrice,
                                     CategoryName = os.Key.CategoryName,
                                     CompName = os.Key.CompName,
                                     Quantity = os.Sum(o => o.saldtl.Quantity),
                                     //ProductSalePrice = os.Key.ProductSalePrice,

                                     CreateDate = ReportDate,
                                     TotalSale = TotalSale1,
                                     GuestCharge = GuestCharge1,
                                     card = card1,
                                     ExtraBill = ExtraBill1,
                                     GouestChargePlus = GouestChargePlus1,
                                     TotalAmount = TotalAmount1,
                                     //PaidAmount = os.Sum(o => o.saldtl.Quantity) * os.Key.ProductSalePrice,
                                     RestuarentBill = RestuarentSale1,
                                     CateringBill = CateringSale1,
                                     BekaryBill = BekarySale1,
                                     GuestChargeBar = GuestSale1,
                                     BarSale = BarSale1,
                                     FinalQuantity = quani

                                 };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }


        // DUE SECTION 



        public List<InvenSalePaymentDtlDto> LoadDailySaleDue(string date, string TotalSale, string GuestCharge, string card, string ExtraBill, string GouestChargePlus, string TotalAmount, string BarSale, string CateringSale, string BekarySale, string RestuarentSale, string GuestSale, string quan)
        {
            using (var container = new InventoryContainer())
            {

                double TotalSale1 = double.Parse(TotalSale), GuestCharge1 = double.Parse(GuestCharge), BarSale1 = double.Parse(BarSale), CateringSale1 = double.Parse(CateringSale), BekarySale1 = double.Parse(BekarySale), RestuarentSale1 = double.Parse(RestuarentSale), GuestSale1 = double.Parse(GuestSale),
                   card1 = double.Parse(card), quani = double.Parse(quan), ExtraBill1 = double.Parse(ExtraBill), GouestChargePlus1 = double.Parse(GouestChargePlus), TotalAmount1 = double.Parse(TotalAmount);

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
                DateTime ReportDate = DateTime.Parse(date);
                var result = from o in query
                             where !o.saldtl.Product.Category.CategoryName.ToLower().Contains("extra".ToLower())
                             orderby o.salinfo.SalId ascending
                             group o by new { o.saldtl.Product.Category.CategoryName, o.saldtl.Product.CompanyInfo.CompName, o.saldtl.BarPrice, o.saldtl.OffPrice }
                                 into os
                                 select new InvenSalePaymentDtlDto
                                 {
                                     //Quantity=os.Sum(o=>o.saldtl.Quantity),
                                     BarQuantity = os.Sum(o => o.saldtl.BarQuantity),
                                     OffQuantity = os.Sum(o => o.saldtl.OffQuantity),
                                     BarPrice = os.Key.BarPrice,
                                     OffPrice = os.Key.OffPrice,
                                     CategoryName = os.Key.CategoryName,
                                     CompName = os.Key.CompName,
                                     Quantity = os.Sum(o => o.saldtl.Quantity),
                                     //ProductSalePrice = os.Key.ProductSalePrice,

                                     CreateDate = ReportDate,
                                     TotalSale = TotalSale1,
                                     GuestCharge = GuestCharge1,
                                     card = card1,
                                     ExtraBill = ExtraBill1,
                                     GouestChargePlus = GouestChargePlus1,
                                     TotalAmount = TotalAmount1,
                                     //PaidAmount = os.Sum(o => o.saldtl.Quantity) * os.Key.ProductSalePrice,
                                     RestuarentBill = RestuarentSale1,
                                     CateringBill = CateringSale1,
                                     BekaryBill = BekarySale1,
                                     GuestChargeBar = GuestSale1,
                                     BarSale = BarSale1,
                                     FinalQuantity = quani

                                 };

                return result.ToList<InvenSalePaymentDtlDto>();

            }
        }
        
        
        //END DUE SECTION




        public List<InvenSalesDetailDTO> GetdtlByDate(string date)
        {
            using (var container = new InventoryContainer())
            {
                DateTime Date;
                var query = from dtl in container.InvenSalesDetails
                            select new { dtl };
                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.dtl.CreatedDate == Date);

                }

                var result = (from o in query
                              select new InvenSalesDetailDTO
                              {
                                  DtlId = o.dtl.DtlId,
                                  ProductId = o.dtl.ProductId,
                                  SubCategoryName = o.dtl.Product.CompanyInfo.CompName,
                                  TotalQuantity = o.dtl.TotalQuantity,
                                  UsedQuantity = o.dtl.UsedQuantity,
                                  RemainingQuantity = o.dtl.RemainingQuantity,
                                  TodayStock = o.dtl.TodayStock,
                                  CreatedDate = o.dtl.CreatedDate
                              }).ToList<InvenSalesDetailDTO>();
                return result;
            }
        }
    }
}
