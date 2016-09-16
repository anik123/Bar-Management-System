using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class InvenCentralReturnDAL
    {
        public void SaveCentralReturn(InvenCentralReturnDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenCentralReturn gur = new InvenCentralReturn();
                container.InvenCentralReturns.AddObject((InvenCentralReturn)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }
        public List<InvenCentralReturnDTO> LaodPartyReturnNO()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCentralReturns
                            select new { s };

                var result = from o in query
                             orderby o.s.CentralReturnId descending

                             select new InvenCentralReturnDTO
                             {
                                 ReturnNo = o.s.ReturnNo
                             };
                return result.ToList<InvenCentralReturnDTO>();
            }
        }

        //Central to party product rept
        public List<InvenChangePaymentDtlDto> Return_Central_To_Party_ProductRpt_Detail(int retunno, int compid, string FromDate, string ToDate)
        {
            DateTime From, To;
            using (var Container = new InventoryContainer())
            {
                var query = from central in Container.InvenCentralReturns
                            join brRet in Container.InvenBranchReturns on central.BranchReturnId equals brRet.BranchReturnId
                            join chdtl in Container.InvenChangeDtls on brRet.ChangeDtlId equals chdtl.ChangeDtlId
                            join chinfo in Container.InvenChangeInfoes on chdtl.ChangeId equals chinfo.ChangeId
                            select new { central, brRet, chdtl, chinfo };

                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                  //  To = To.AddDays(1);
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.central.ReturnDate >= From && c.central.ReturnDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.central.ReturnDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.central.ReturnDate == From);
                }
                if (compid != 0)
                    query = query.Where(c => c.chdtl.Product.CompanyInfo.CompId.Equals(compid));
                if (retunno != 0)
                    query = query.Where(c => c.central.ReturnNo.Equals(retunno));

                var result = (from o in query
                              orderby o.central.ReturnNo ascending

                              select new InvenChangePaymentDtlDto
                              {
                                  //   ReturnDate = o.central.ReturnDate,
                                  //  CategoryName = o.chdtl.Product.Category.CategoryName,
                                  //   CompName = o.chdtl.Product.CompanyInfo.CompName,
                                  //   ProductName = o.chdtl.Product.ProductName,
                                  //   Quantity = o.chdtl.Quantity,
                                  //   ProductId = o.chdtl.Product.ProductId,
                                  //    BrProName = o.chinfo.InvenBranchProfile.BrProName,
                                  ReturnNo = o.central.ReturnNo
                              }).Distinct(); //.Distinct()
                return result.ToList<InvenChangePaymentDtlDto>();
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
    }
}
