using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class InvenPerRequisitionDal
    {
        public void Add(InvenPerRequisitionDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenPerRequisition inreo = new InvenPerRequisition();
                container.InvenPerRequisitions.AddObject((InvenPerRequisition)DTOMapper.DTOObjectConverter(DTO, inreo));
                container.SaveChanges();
            }
        }
        public void Edit(InvenPerRequisitionDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenPerRequisition();
                Comp = container.InvenPerRequisitions.FirstOrDefault(o => o.PurReqId.Equals(DTO.PurReqId));
                Comp.PurReqId = DTO.PurReqId;
                Comp.PurReqStatus = DTO.PurReqStatus;
                Comp.RequisitionBy = DTO.RequisitionBy;
                Comp.Quantity = DTO.Quantity;
                Comp.BrProId = DTO.BrProId;
                Comp.RequisitionDate = DTO.RequisitionDate;
                Comp.RequisitionNo = DTO.RequisitionNo;
                Comp.UnitPrice = DTO.UnitPrice;
                Comp.Quantity = DTO.Quantity;
                Comp.Priority = DTO.Priority;
                Comp = (InvenPerRequisition)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        public void Edit_PurRequsitionStatus(InvenPerRequisitionDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenPerRequisition();
                Comp = container.InvenPerRequisitions.FirstOrDefault(o => o.PurReqId.Equals(DTO.PurReqId));
                Comp.PurReqId = DTO.PurReqId;
                Comp.PurReqStatus = DTO.PurReqStatus;

                Comp = (InvenPerRequisition)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public List<InvenPerRequisitionDto> GetRequisitionInfo(int id, int reqno)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenPerRequisitions
                            join brance in Container.InvenBranchProfiles on s.BrProId equals brance.BrProId
                            join pro in Container.Products on s.ProductId equals pro.ProductId
                            // join instore in Container.InvenStoreStatus on pro.ProductId equals instore.ProductId
                            select new { s, brance, pro };
                if (id != 0)
                    query = query.Where(c => c.s.PurReqId.Equals(id));
                if (reqno != 0)
                    query = query.Where(c => c.s.RequisitionNo.Equals(reqno));

                var result = from o in query
                             orderby o.s.PurReqId descending

                             select new InvenPerRequisitionDto
                             {
                                 PurReqId = o.s.PurReqId,
                                 PurReqStatus = o.s.PurReqStatus,
                                 ProductId = o.pro.ProductId,
                                 BrProId = o.brance.BrProId,
                                 RequisitionBy = o.s.RequisitionBy,
                                 RequisitionDate = o.s.RequisitionDate,
                                 RequisitionNo = o.s.RequisitionNo,
                                 UnitPrice = o.s.UnitPrice,
                                 CompId = o.pro.CompanyInfo.CompId,
                                 CompName = o.pro.CompanyInfo.CompName,
                                 BrProName = o.brance.BrProName,
                                 Priority = o.s.Priority,
                                 Quantity = o.s.Quantity,
                                 CategoryName = o.pro.Category.CategoryName,
                                 ProductName = o.pro.ProductName,
                                 UnitName = o.pro.Unit.UnitName,
                                 CatId = o.pro.Category.CatId,
                                 UnitId = o.pro.Unit.UnitId,
                                 //QuantityStore = o.instore.QuantityStore
                             };
                return result.ToList<InvenPerRequisitionDto>();
            }
        }

        public List<InvenPerRequisitionDto> GetRequisition_PurOrderpage(string FromDate, string ToDate, int CompanyId, int Recno)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenPerRequisitions
                            join brance in Container.InvenBranchProfiles on s.BrProId equals brance.BrProId
                            join reqsit in Container.InvenCentralPurRequisitions on s.PurReqId equals reqsit.PurReqId
                            join pro in Container.Products on s.ProductId equals pro.ProductId
                            join reqorder in Container.InvenCentrealPurOrders on s.ProductId equals reqorder.ProductId
                            select new {reqsit, s, brance, pro,reqorder };
                DateTime From, To;
                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    //  To = To.AddDays(1);
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.s.RequisitionDate >= From && c.s.RequisitionDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.s.RequisitionDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.s.RequisitionDate == From);
                }
                if (CompanyId != 0)
                    query = query.Where(c => c.pro.CompanyInfo.CompId == CompanyId);
                if (Recno != 0)
                    query = query.Where(c => c.s.RequisitionNo == Recno);

                var result = from o in query
                             orderby o.s.PurReqId descending
                             where o.reqsit.PurReqStatus == "1" && o.reqorder.PurChallanStatus=="0"
                             
                             select new InvenPerRequisitionDto
                             {
                                 PurReqId = o.s.PurReqId,
                                 PurReqStatus = o.s.PurReqStatus,
                                 ProductId = o.pro.ProductId,
                                 BrProId = o.brance.BrProId,
                                 RequisitionBy = o.s.RequisitionBy,
                                 RequisitionDate = o.s.RequisitionDate,
                                 RequisitionNo = o.s.RequisitionNo,
                                 UnitPrice = o.s.UnitPrice,
                                 CompId = o.pro.CompanyInfo.CompId,
                                 CompName = o.pro.CompanyInfo.CompName,
                                 BrProName = o.brance.BrProName,
                                 Priority = o.s.Priority,
                                 Quantity = o.s.Quantity,
                                 ReqPurOrderId=o.reqorder.CentralPurOrderId

                             };
                return result.ToList<InvenPerRequisitionDto>();
            }
        }

        public List<InvenPerRequisitionDto> GetRequisitionNo_BranchChallen(string FromDate, string ToDate, int brproid, int Recno)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenPerRequisitions
                            join brance in Container.InvenBranchProfiles on s.BrProId equals brance.BrProId

                            select new { s, brance };
                DateTime From, To;
                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    To = To.AddDays(1);
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.s.RequisitionDate >= From && c.s.RequisitionDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.s.RequisitionDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.s.RequisitionDate == From);
                }

                if (Recno != 0)
                    query = query.Where(c => c.s.RequisitionNo == Recno);
                if (brproid != 0)
                    query = query.Where(c => c.brance.BrProId == brproid);

                var result = from o in query
                             //   orderby o.s.PurReqId descending
                             // where o.s.PurReqStatus == "0"
                             select new InvenPerRequisitionDto
                             {
                                 PurReqId = o.s.PurReqId,
                                 PurReqStatus = o.s.PurReqStatus,

                                 BrProId = o.brance.BrProId,
                                 RequisitionBy = o.s.RequisitionBy,
                                 RequisitionDate = o.s.RequisitionDate,
                                 RequisitionNo = o.s.RequisitionNo,
                                 UnitPrice = o.s.UnitPrice,

                                 BrProName = o.brance.BrProName,
                                 Priority = o.s.Priority,
                                 Quantity = o.s.Quantity
                             };
                return result.ToList<InvenPerRequisitionDto>();
            }
        }


        public List<InvenPerRequisitionDto> RequsiitonWiseProdctInfoLoad(int RecNo)
        {
            using (var content = new InventoryContainer())
            {
                var result = (from data1 in content.InvenPerRequisitions
                              join data2 in content.Products on data1.ProductId equals data2.ProductId
                              //  join data3 in content.PharmDurgCompanyInfoes on data1.CompId equals data3.CompId

                              where data1.RequisitionNo == RecNo

                              select new InvenPerRequisitionDto
                              {
                                  PurReqId = data1.PurReqId,
                                  ProductId = data1.ProductId,
                                  ProductName = data2.ProductName,//+ "-" + data2.Unit.UnitName,
                                  CompId = data2.CompanyInfo.CompId,
                                  CompName = data2.CompanyInfo.CompName,
                                  Quantity = data1.Quantity,
                                  UnitPrice = data1.UnitPrice,
                                  Priority = data1.Priority,
                                  RequisitionNo = data1.RequisitionNo,
                                  RequisitionBy = data1.RequisitionBy,
                                  RequisitionDate = data1.RequisitionDate,
                                  PurReqStatus = data1.PurReqStatus,
                                  UnitName = data2.Unit.UnitName,
                                  CategoryName = data2.Category.CategoryName,
                                  CatId = data2.Category.CatId

                              }).ToList<InvenPerRequisitionDto>();
                return result;
            }
        }

        public List<InvenPerRequisitionDto> GetReqList()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenPerRequisitions
                            select new { s };


                var result = from o in query
                             orderby o.s.PurReqId descending
                             select new InvenPerRequisitionDto
                             {

                                 RequisitionNo = o.s.RequisitionNo,

                             };
                return result.ToList<InvenPerRequisitionDto>();
            }
        }
    }
}
