using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using DTO;
using Utility;

namespace DAL
{
  public  class InvenPurOrderDal
    {
        public void Add(InvenPurOrderDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenPurOrder inreo = new InvenPurOrder();

                container.InvenPurOrders.AddObject((InvenPurOrder)DTOMapper.DTOObjectConverter(DTO, inreo));
                container.SaveChanges();
            }
        }

        public void Edit(InvenPurOrderDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenPurOrder();
                Comp = container.InvenPurOrders.FirstOrDefault(o => o.InvenPurOrderId.Equals(DTO.InvenPurOrderId));
                Comp.InvenPurOrderId = DTO.InvenPurOrderId;
                Comp.Priority = DTO.Priority;
                Comp.PurOrderBy = DTO.PurOrderBy;
                Comp.ProductId = DTO.ProductId;
                Comp.PurOrderNO = DTO.PurOrderNO;
                Comp.PurOrderStatus = DTO.PurOrderStatus;
                Comp.UnitPrice = DTO.UnitPrice;
                Comp.BrProId = DTO.BrProId;
                Comp.PurOrderDate = DTO.PurOrderDate;
                Comp.Quantity = DTO.Quantity;
                

                Comp = (InvenPurOrder)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }


        public List<InvenPurOrderDto> GetPurchaseInfo(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenPurOrders
                            join brance in Container.InvenBranchProfiles on s.BrProId equals brance.BrProId
                            join pro in Container.Products on s.ProductId equals pro.ProductId
                            //    join cat in Container.Categories on s.CategoryId equals cat.CatId
                            select new { s, brance, pro };
                if (id != 0)
                    query = query.Where(c => c.s.InvenPurOrderId.Equals(id));

                var result = from o in query
                             orderby o.s.InvenPurOrderId descending

                             select new InvenPurOrderDto
                             {
                                 InvenPurOrderId = o.s.InvenPurOrderId,
                                 Quantity = o.s.Quantity,
                                 ProductId = o.pro.ProductId,
                                 BrProId = o.brance.BrProId,
                                 UnitPrice = o.s.UnitPrice,
                                 Priority = o.s.Priority,
                                 PurOrderStatus = o.s.PurOrderStatus,
                                 PurOrderNO=o.s.PurOrderNO,
                                 PurOrderDate=o.s.PurOrderDate,
                                 PurOrderBy=o.s.PurOrderBy

                             };
                return result.ToList<InvenPurOrderDto>();
            }
        }
        public List<InvenPurOrderDto> GetPurOrderNo()
        {
            using (var content = new InventoryContainer())
            {
                var data = (from amount in content.InvenPurOrders
                            orderby amount.InvenPurOrderId descending
                            select new InvenPurOrderDto
                            {
                                PurOrderNO = amount.PurOrderNO
                            }).ToList<InvenPurOrderDto>();
                return data;
            }
        }


    }
}
