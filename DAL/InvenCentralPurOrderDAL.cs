using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class InvenCentralPurOrderDAL
    {
        public void Add(InvenCentralPurOrderDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenCentrealPurOrder inreo = new InvenCentrealPurOrder();

                container.InvenCentrealPurOrders.AddObject((InvenCentrealPurOrder)DTOMapper.DTOObjectConverter(DTO, inreo));
                container.SaveChanges();
            }
        }

        public void Edit(InvenCentralPurOrderDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenCentrealPurOrder();
                Comp = container.InvenCentrealPurOrders.FirstOrDefault(o => o.CentralPurOrderId.Equals(DTO.CentralPurOrderId));

                Comp.CentralPurOrderId = DTO.CentralPurOrderId;
                Comp.PurOrderStatus = DTO.PurOrderStatus;
                Comp.PurChallanStatus = DTO.PurChallanStatus;

                Comp = (InvenCentrealPurOrder)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }


        public List<InvenCentralPurOrderDTO> GetPurchaseOrderInfo(int id, int orderno)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCentrealPurOrders
                            // join brance in Container.InvenBranchProfiles on s.BrProId equals brance.BrProId
                            join pro in Container.Products on s.ProductId equals pro.ProductId
                            join com in Container.CompanyInfoes on pro.CompId equals com.CompId
                            //    join cat in Container.Categories on s.CategoryId equals cat.CatId
                            select new { s, pro };
                if (id != 0)
                    query = query.Where(c => c.s.CentralPurOrderId.Equals(id));
                if (orderno != 0)
                    query = query.Where(c => c.s.PurOrderNO.Equals(orderno));

                var result = from o in query
                             orderby o.s.CentralPurOrderId descending

                             select new InvenCentralPurOrderDTO
                             {
                                 CentralPurOrderId = o.s.CentralPurOrderId,
                                 Quantity = o.s.Quantity,
                                 ProductId = o.pro.ProductId,
                                 UnitPrice = o.s.UnitPrice,
                                 Priority = o.s.Priority,
                                 PurOrderStatus = o.s.PurOrderStatus,
                                 PurOrderNO = o.s.PurOrderNO,
                                 PurOrderDate = o.s.PurOrderDate,
                                 PurOrderBy = o.s.PurOrderBy,
                                 CatId = o.pro.Category.CatId,
                                 PurchasePrice = o.pro.ProductPurchasePrice,
                              
                              
                                 UnitId = o.pro.Unit.UnitId,
                                 CategoryName = o.pro.Category.CategoryName,
                                 ProductName = o.pro.ProductName,
                                 CompId = o.pro.CompanyInfo.CompId,
                                 CompName = o.pro.CompanyInfo.CompName

                             };
                return result.ToList<InvenCentralPurOrderDTO>();
            }
        }
        public List<InvenCentralPurOrderDTO> GetPurOrderNo()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCentrealPurOrders
                            select new { s };


                var result = from o in query
                             orderby o.s.CentralPurOrderId descending
                             select new InvenCentralPurOrderDTO
                             {
                                 CentralPurOrderId = o.s.CentralPurOrderId,
                                 PurOrderNO = o.s.PurOrderNO,

                             };
                return result.ToList<InvenCentralPurOrderDTO>();
            }
        }


        public List<InvenCentralPurOrderDTO> GetOrderNum_Dropdownlist()
        {
            using (var content = new InventoryContainer())
            {
                var data = (from amount in content.InvenCentrealPurOrders
                            orderby amount.CentralPurOrderId descending
                            where amount.PurOrderStatus == "0"
                            select new InvenCentralPurOrderDTO
                            {
                                PurOrderNO = amount.PurOrderNO
                            }).Distinct().ToList<InvenCentralPurOrderDTO>();
                return data;
            }
        }
        public List<InvenCentralPurOrderDTO> GetOrderNo_CentralPurchasepage(string FromDate, string ToDate, int CompanyId, int Recno)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCentrealPurOrders
                            join pro in Container.Products on s.ProductId equals pro.ProductId
                            select new { s, pro };
                DateTime From, To;
                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    To = To.AddDays(1);
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.s.PurOrderDate >= From && c.s.PurOrderDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.s.PurOrderDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.s.PurOrderDate == From);
                }
                if (CompanyId != 0)
                    query = query.Where(c => c.pro.CompanyInfo.CompId == CompanyId);
                if (Recno != 0)
                    query = query.Where(c => c.s.PurOrderNO == Recno);

                var result = (from o in query
                              orderby o.s.PurOrderNO descending
                              where o.s.PurOrderStatus == "0"
                              select new InvenCentralPurOrderDTO
                              {
                                  PurOrderNO = o.s.PurOrderNO
                              }).Distinct();
                return result.ToList<InvenCentralPurOrderDTO>();
            }
        }
        // purorder no wise load
        public List<InvenCentralPurOrderDTO> GetOrderNo_CentralPurchasepage_UnderPurOrder(int Recno)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCentrealPurOrders
                            join pro in Container.Products on s.ProductId equals pro.ProductId
                            select new { s, pro };
                if (Recno != 0)
                    query = query.Where(c => c.s.PurOrderNO == Recno);

                var result = from o in query
                             select new InvenCentralPurOrderDTO
                             {
                                 CentralPurOrderId = o.s.CentralPurOrderId,
                                 PurOrderStatus = o.s.PurOrderStatus,
                                 ProductId = o.pro.ProductId,

                                 PurOrderBy = o.s.PurOrderBy,
                                 PurOrderDate = o.s.PurOrderDate,
                                 PurOrderNO = o.s.PurOrderNO,
                                 UnitPrice = o.s.UnitPrice,
                                 CompId = o.pro.CompanyInfo.CompId,
                                 CompName = o.pro.CompanyInfo.CompName,

                                 Priority = o.s.Priority,
                                 Quantity = o.s.Quantity
                             };
                return result.ToList<InvenCentralPurOrderDTO>();
            }
        }
    }
}
