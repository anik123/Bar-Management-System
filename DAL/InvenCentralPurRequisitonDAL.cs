using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class InvenCentralPurRequisitonDAL
    {
        public void Add(InvenCentralPurRequisitonDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenCentralPurRequisition inreo = new InvenCentralPurRequisition();
                container.InvenCentralPurRequisitions.AddObject((InvenCentralPurRequisition)DTOMapper.DTOObjectConverter(DTO, inreo));
                container.SaveChanges();
            }
        }
        public void Edit(InvenCentralPurRequisitonDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenCentralPurRequisition();
                Comp = container.InvenCentralPurRequisitions.FirstOrDefault(o => o.CenPurReqId.Equals(DTO.CenPurReqId));

                Comp.PurReqStatus = DTO.PurReqStatus;
                Comp.RequisitionBy = DTO.RequisitionBy;
                Comp.Quantity = DTO.Quantity;
                Comp.RequisitionDate = DTO.RequisitionDate;
                Comp.RequisitionNo = DTO.RequisitionNo;
                Comp.UnitPrice = DTO.UnitPrice;
                Comp.Priority = DTO.Priority;

                Comp = (InvenCentralPurRequisition)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        public void Edit_PurRequsitionStatus(InvenCentralPurRequisitonDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenCentralPurRequisition();
                Comp = container.InvenCentralPurRequisitions.FirstOrDefault(o => o.CenPurReqId.Equals(DTO.CenPurReqId));
                Comp.CenPurReqId = DTO.CenPurReqId;
                Comp.PurReqStatus = DTO.PurReqStatus;

                Comp = (InvenCentralPurRequisition)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public List<InvenCentralPurRequisitonDTO> GetRequisitionInfo(int id, int reqno)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCentralPurRequisitions

                            join pro in Container.Products on s.ProductId equals pro.ProductId
                            // join instore in Container.InvenStoreStatus on pro.ProductId equals instore.ProductId
                            select new { s, pro };
                if (id != 0)
                    query = query.Where(c => c.s.CenPurReqId.Equals(id));
                if (reqno != 0)
                    query = query.Where(c => c.s.RequisitionNo.Equals(reqno));

                var result = from o in query
                             orderby o.s.CenPurReqId descending
                             where o.s.PurReqStatus == "0"
                             select new InvenCentralPurRequisitonDTO
                             {
                                 CenPurReqId = o.s.CenPurReqId,
                                 PurReqStatus = o.s.PurReqStatus,
                                 ProductId = o.pro.ProductId,
                                  PurReqId=o.s.PurReqId,

                                 RequisitionBy = o.s.RequisitionBy,
                                 RequisitionDate = o.s.RequisitionDate,
                                 RequisitionNo = o.s.RequisitionNo,
                                 UnitPrice = o.s.UnitPrice,
                                 CompId = o.pro.CompanyInfo.CompId,
                                 CompName = o.pro.CompanyInfo.CompName,

                                 Priority = o.s.Priority,
                                 Quantity = o.s.Quantity,
                                 CategoryName = o.pro.Category.CategoryName,
                                 ProductName = o.pro.ProductName,
                                 UnitName = o.pro.Unit.UnitName,
                                 CatId = o.pro.Category.CatId,
                                 UnitId = o.pro.Unit.UnitId,
                                
                                 //QuantityStore = o.instore.QuantityStore
                             };
                return result.ToList<InvenCentralPurRequisitonDTO>();
            }
        }

        public List<InvenCentralPurRequisitonDTO> GetRequisition_PurOrderpage(string FromDate, string ToDate, int CompanyId, int Recno)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCentralPurRequisitions

                            join pro in Container.Products on s.ProductId equals pro.ProductId
                            select new { s, pro };
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
                if (CompanyId != 0)
                    query = query.Where(c => c.pro.CompanyInfo.CompId == CompanyId);
                if (Recno != 0)
                    query = query.Where(c => c.s.RequisitionNo == Recno);

                var result = from o in query
                             orderby o.s.CenPurReqId descending
                             where o.s.PurReqStatus == "0"
                             select new InvenCentralPurRequisitonDTO
                             {
                                 CenPurReqId = o.s.CenPurReqId,
                                 PurReqStatus = o.s.PurReqStatus,
                                 ProductId = o.pro.ProductId,
                                  PurReqId=o.s.PurReqId,

                                 RequisitionBy = o.s.RequisitionBy,
                                 RequisitionDate = o.s.RequisitionDate,
                                 RequisitionNo = o.s.RequisitionNo,
                                 UnitPrice = o.s.UnitPrice,
                                 CompId = o.pro.CompanyInfo.CompId,
                                 CompName = o.pro.CompanyInfo.CompName,

                                 Priority = o.s.Priority,
                                 Quantity = o.s.Quantity
                             };
                return result.ToList<InvenCentralPurRequisitonDTO>();
            }
        }

        public List<InvenCentralPurRequisitonDTO> GetReqList()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCentralPurRequisitions
                            select new { s };


                var result = from o in query
                             orderby o.s.CenPurReqId descending
                             select new InvenCentralPurRequisitonDTO
                             {
                                 CenPurReqId = o.s.CenPurReqId,
                                 RequisitionNo = o.s.RequisitionNo,

                             };
                return result.ToList<InvenCentralPurRequisitonDTO>();
            }
        }
        public List<InvenCentralPurRequisitonDTO> GetReqList_Dropdownlist()
        {
            using (var content = new InventoryContainer())
            {
                var data = (from amount in content.InvenCentralPurRequisitions
                            orderby amount.CenPurReqId descending
                            where amount.PurReqStatus == "0"
                            select new InvenCentralPurRequisitonDTO
                            {
                                RequisitionNo = amount.RequisitionNo
                            }).Distinct().ToList<InvenCentralPurRequisitonDTO>();
                return data;
            }
        }
        public List<InvenCentralPurRequisitonDTO> GetRequisition_CentralPurOrderpage(string FromDate, string ToDate, int CompanyId, int Recno)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCentralPurRequisitions
                            join pro in Container.Products on s.ProductId equals pro.ProductId
                            select new { s, pro };
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
                if (CompanyId != 0)
                    query = query.Where(c => c.pro.CompanyInfo.CompId == CompanyId);
                if (Recno != 0)
                    query = query.Where(c => c.s.RequisitionNo == Recno);

                var result = (from o in query
                              orderby o.s.CenPurReqId descending
                              where o.s.PurReqStatus == "0"
                              select new InvenCentralPurRequisitonDTO
                              {

                                  RequisitionNo = o.s.RequisitionNo,

                              }).Distinct();
                return result.ToList<InvenCentralPurRequisitonDTO>();
            }
        }

        public List<InvenCentralPurRequisitonDTO> GetInfo_By_RequisitionNoWise(int RecNo)
        {
            using (var content = new InventoryContainer())
            {
                var result = (from data1 in content.InvenCentralPurRequisitions
                              join data2 in content.Products on data1.ProductId equals data2.ProductId
                              where data1.RequisitionNo == RecNo

                              select new InvenCentralPurRequisitonDTO
                              {
                                  CenPurReqId = data1.CenPurReqId,
                                  ProductId = data1.ProductId,
                                  ProductName = data2.ProductName,
                                  PurReqId = data1.PurReqId,
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

                              }).ToList<InvenCentralPurRequisitonDTO>();
                return result;
            }
        }
        public List<InvenCentralPurRequisitonDTO> GetInfo(int RecNo)
        {
            using (var content = new InventoryContainer())
            {
                var result = (from data1 in content.InvenCentralPurRequisitions
                              join data2 in content.Products on data1.ProductId equals data2.ProductId
                              where data1.RequisitionNo == RecNo

                              select new InvenCentralPurRequisitonDTO
                              {
                                  CenPurReqId = data1.CenPurReqId,
                                  ProductId = data1.ProductId,
                                  ProductName = data2.ProductName,
                                  PurReqId = data1.PurReqId,
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

                              }).ToList<InvenCentralPurRequisitonDTO>();
                return result;
            }
        }
    }
}
