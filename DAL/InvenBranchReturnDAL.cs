using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;
using DTO;

namespace DAL
{
    public class InvenBranchReturnDAL
    {
        public void SaveBranchReturn(InvenBranchReturnDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenBranchReturn gur = new InvenBranchReturn();
                container.InvenBranchReturns.AddObject((InvenBranchReturn)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }
        public void Edit(InvenBranchReturnDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenBranchReturn();
                Comp = container.InvenBranchReturns.First(o => o.BranchReturnId.Equals(DTO.BranchReturnId));
                Comp.ReciveBy = DTO.ReciveBy;
                Comp.ReciveDate = DTO.ReciveDate;
                Comp.ReturnReciveStatus = DTO.ReturnReciveStatus;

                Comp = (InvenBranchReturn)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        // edit brnch central to party
        public void Edit_Central_To_Party(InvenBranchReturnDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenBranchReturn();
                Comp = container.InvenBranchReturns.First(o => o.BranchReturnId.Equals(DTO.BranchReturnId));
                Comp.CentralToPartyStatus = DTO.CentralToPartyStatus;

                Comp = (InvenBranchReturn)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        //load return product send branch to central 
        public List<InvenChangePaymentDtlDto> Branchwise_Return_Product(int chdtlid, int catid, int compid, int brid, string FromDate, string ToDate)
        {
            DateTime From, To;
            using (var Container = new InventoryContainer())
            {
                var query = from chdtl in Container.InvenChangeDtls
                            join chinfo in Container.InvenChangeInfoes on chdtl.ChangeId equals chinfo.ChangeId

                            select new { chdtl, chinfo };

                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    To = To.AddDays(1);
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.chinfo.CreateDate >= From && c.chinfo.CreateDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.chinfo.CreateDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.chinfo.CreateDate == From);
                }
                if (catid != 0)
                    query = query.Where(c => c.chdtl.Product.Category.CatId.Equals(catid));

                if (compid != 0)
                    query = query.Where(c => c.chdtl.Product.CompanyInfo.CompId.Equals(compid));
                if (brid != 0)
                    query = query.Where(c => c.chinfo.InvenBranchProfile.BrProId.Equals(brid));
                if (chdtlid != 0)
                    query = query.Where(c => c.chdtl.ChangeDtlId.Equals(chdtlid));


                var result = from o in query
                             orderby o.chdtl.ChangeDtlId ascending
                             where o.chdtl.Caused == "Rejection" && o.chdtl.CentranlReturnStatus == "0"
                             select new InvenChangePaymentDtlDto
                             {
                                 ChangeDtlId = o.chdtl.ChangeDtlId,
                                 CreateDate = o.chinfo.CreateDate,
                                 CategoryName = o.chdtl.Product.Category.CategoryName,
                                 CompName = o.chdtl.Product.CompanyInfo.CompName,
                                 ProductName = o.chdtl.Product.ProductName,
                                 Quantity = o.chdtl.Quantity,
                                 ProductId = o.chdtl.Product.ProductId,



                             };
                return result.ToList<InvenChangePaymentDtlDto>();
            }
        }
        public List<InvenBranchReturnDTO> LoadReturnId()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenBranchReturns
                            select new { s };

                var result = from o in query
                             orderby o.s.BranchReturnId descending

                             select new InvenBranchReturnDTO
                             {
                                 // BranchReturnId = o.s.BranchReturnId,
                                 // ReturnDate=o.s.ReturnDate
                                 ReturnNo = o.s.ReturnNo

                             };
                return result.ToList<InvenBranchReturnDTO>();
            }
        }
        //load return product recive  
        public List<InvenChangePaymentDtlDto> Central_Return_Product_Recive(int retunid, int catid, int productid, int compid, int brid, string FromDate, string ToDate)
        {
            DateTime From, To;
            using (var Container = new InventoryContainer())
            {
                var query = from retun in Container.InvenBranchReturns
                            join chdtl in Container.InvenChangeDtls on retun.ChangeDtlId equals chdtl.ChangeDtlId
                            join chinfo in Container.InvenChangeInfoes on chdtl.ChangeId equals chinfo.ChangeId

                            select new { retun, chdtl, chinfo };

                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    To = To.AddDays(1);
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.retun.ReturnDate >= From && c.retun.ReturnDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.retun.ReturnDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.retun.ReturnDate == From);
                }
                if (catid != 0)
                    query = query.Where(c => c.chdtl.Product.Category.CatId.Equals(catid));
                if (productid != 0)
                    query = query.Where(c => c.chdtl.Product.ProductId.Equals(productid));

                if (compid != 0)
                    query = query.Where(c => c.chdtl.Product.CompanyInfo.CompId.Equals(compid));
                if (brid != 0)
                    query = query.Where(c => c.chinfo.InvenBranchProfile.BrProId.Equals(brid));
                if (retunid != 0)
                    query = query.Where(c => c.retun.BranchReturnId.Equals(retunid));


                var result = from o in query
                             orderby o.retun.BranchReturnId ascending
                             where o.retun.ReturnReciveStatus == "0"
                             select new InvenChangePaymentDtlDto
                             {
                                 BrProName = o.chinfo.InvenBranchProfile.BrProName,
                                 BranchReturnId = o.retun.BranchReturnId,
                                 ReturnDate = o.retun.ReturnDate,
                                 CategoryName = o.chdtl.Product.Category.CategoryName,
                                 CompName = o.chdtl.Product.CompanyInfo.CompName,
                                 ProductName = o.chdtl.Product.ProductName,
                                 Quantity = o.chdtl.Quantity,
                                 ProductId = o.chdtl.Product.ProductId


                             };
                return result.ToList<InvenChangePaymentDtlDto>();
            }
        }



        //load return product send  central to party 
        public List<InvenChangePaymentDtlDto> Central_Return_Product_To_Party(int retunid, int catid, int productid, int compid, int brid)
        {

            using (var Container = new InventoryContainer())
            {
                var query = from retun in Container.InvenBranchReturns
                            join chdtl in Container.InvenChangeDtls on retun.ChangeDtlId equals chdtl.ChangeDtlId
                            join chinfo in Container.InvenChangeInfoes on chdtl.ChangeId equals chinfo.ChangeId

                            select new { retun, chdtl, chinfo };


                if (catid != 0)
                    query = query.Where(c => c.chdtl.Product.Category.CatId.Equals(catid));
                if (productid != 0)
                    query = query.Where(c => c.chdtl.Product.ProductId.Equals(productid));

                if (compid != 0)
                    query = query.Where(c => c.chdtl.Product.CompanyInfo.CompId.Equals(compid));
                if (brid != 0)
                    query = query.Where(c => c.chinfo.InvenBranchProfile.BrProId.Equals(brid));
                if (retunid != 0)
                    query = query.Where(c => c.retun.BranchReturnId.Equals(retunid));


                var result = from o in query
                             orderby o.retun.BranchReturnId ascending
                             where o.retun.ReturnReciveStatus == "1" && o.retun.CentralToPartyStatus == "0"
                             select new InvenChangePaymentDtlDto
                             {
                                 BranchReturnId = o.retun.BranchReturnId,
                                 ReturnDate = o.retun.ReturnDate,
                                 CategoryName = o.chdtl.Product.Category.CategoryName,
                                 CompName = o.chdtl.Product.CompanyInfo.CompName,
                                 ProductName = o.chdtl.Product.ProductName,
                                 Quantity = o.chdtl.Quantity,
                                 ProductId = o.chdtl.Product.ProductId,
                                 BrProName = o.chinfo.InvenBranchProfile.BrProName
                             };
                return result.ToList<InvenChangePaymentDtlDto>();
            }
        }
        //branch  to central product rept
        public List<InvenChangePaymentDtlDto> Return_Branch_To_Central_ProductRpt_Detail(int brprid, int retunno, int compid, string FromDate, string ToDate)
        {
            DateTime From, To;
            using (var Container = new InventoryContainer())
            {
                var query = from brRet in Container.InvenBranchReturns
                            //  join brRet in Container.InvenBranchReturns on central.BranchReturnId equals brRet.BranchReturnId
                            join chdtl in Container.InvenChangeDtls on brRet.ChangeDtlId equals chdtl.ChangeDtlId
                            join chinfo in Container.InvenChangeInfoes on chdtl.ChangeId equals chinfo.ChangeId
                            select new { brRet, chdtl, chinfo };

                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    //  To = To.AddDays(1);
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.brRet.ReturnDate >= From && c.brRet.ReturnDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.brRet.ReturnDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.brRet.ReturnDate == From);
                }
                if (compid != 0)
                    query = query.Where(c => c.chdtl.Product.CompanyInfo.CompId.Equals(compid));
                if (retunno != 0)
                    query = query.Where(c => c.brRet.ReturnNo.Equals(retunno));
                if (brprid != 0)
                    query = query.Where(c => c.chinfo.InvenBranchProfile.BrProId.Equals(brprid));

                var result = (from o in query
                              orderby o.brRet.ReturnNo ascending

                              select new InvenChangePaymentDtlDto
                              {

                                  ReturnNo = o.brRet.ReturnNo
                              }).Distinct(); //.Distinct()
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

    }
}
