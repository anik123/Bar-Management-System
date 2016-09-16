using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class InvenSalesDetailDAL
    {
        public void Add(InvenSalesDetailDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenSalesDetail ino = new InvenSalesDetail();
                container.InvenSalesDetails.AddObject((InvenSalesDetail)DTOMapper.DTOObjectConverter(DTO, ino));
                container.SaveChanges();
            }
        }
        public void Edit(InvenSalesDetailDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Sale = new InvenSalesDetail();
                Sale = container.InvenSalesDetails.FirstOrDefault(o => o.DtlId.Equals(DTO.DtlId));
                Sale.DtlId = DTO.DtlId;
                Sale.ProductId = DTO.ProductId;
                Sale.UsedQuantity = DTO.UsedQuantity;
                Sale.RemainingQuantity = DTO.RemainingQuantity;
             
                Sale = (InvenSalesDetail)DTOMapper.DTOObjectConverter(DTO, Sale);
                container.SaveChanges();
            }
        }
        public void EditTotalQuan(InvenSalesDetailDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Sale = new InvenSalesDetail();
                Sale = container.InvenSalesDetails.FirstOrDefault(o => o.DtlId.Equals(DTO.DtlId));
                Sale.DtlId = DTO.DtlId;
                Sale.ProductId = DTO.ProductId;
                Sale.TotalQuantity = DTO.TotalQuantity;
                Sale.UsedQuantity = DTO.UsedQuantity;
                Sale.RemainingQuantity = DTO.RemainingQuantity;

                Sale = (InvenSalesDetail)DTOMapper.DTOObjectConverter(DTO, Sale);
                container.SaveChanges();
            }
        }
        public void EditStock(InvenSalesDetailDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Sale = new InvenSalesDetail();
                Sale = container.InvenSalesDetails.FirstOrDefault(o => o.DtlId.Equals(DTO.DtlId));
                Sale.DtlId = DTO.DtlId;
                Sale.ProductId = DTO.ProductId;

                Sale.TodayStock = DTO.TodayStock;

                Sale = (InvenSalesDetail)DTOMapper.DTOObjectConverter(DTO, Sale);
                container.SaveChanges();
            }
        }
        public void EditStockOnlyStockInPage(InvenSalesDetailDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Sale = new InvenSalesDetail();
                Sale = container.InvenSalesDetails.FirstOrDefault(o => o.DtlId.Equals(DTO.DtlId));
                Sale.DtlId = DTO.DtlId;
                Sale.ProductId = DTO.ProductId;

                Sale.TodayStock = DTO.TodayStock;
                Sale.RemainingQuantity = DTO.RemainingQuantity;

                Sale = (InvenSalesDetail)DTOMapper.DTOObjectConverter(DTO, Sale);
                container.SaveChanges();
            }
        }
        public List<InvenSalesDetailDTO> GetdtlId(int ProId, string date)
        {
            using (var container = new InventoryContainer())
            {
                DateTime Date;
                var query = from dtl in container.InvenSalesDetails
                            select new { dtl };
                if (ProId != 0)
                    query = query.Where(o => o.dtl.ProductId == ProId);
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
                                  TotalQuantity = o.dtl.TotalQuantity,
                                  UsedQuantity = o.dtl.UsedQuantity,
                                  RemainingQuantity = o.dtl.RemainingQuantity,
                                  TodayStock = o.dtl.TodayStock,
                                  CreatedDate = o.dtl.CreatedDate
                              }).ToList<InvenSalesDetailDTO>();
                return result;
            }
        }
        public List<InvenSalesDetailDTO> GetdtlIdAfter(int ProId, string date)
        {
            using (var container = new InventoryContainer())
            {
                DateTime Date;
                var query = from dtl in container.InvenSalesDetails
                            select new { dtl };
                if (ProId != 0)
                    query = query.Where(o => o.dtl.ProductId == ProId);
                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.dtl.CreatedDate > Date);
                }
                var result = (from o in query
                              select new InvenSalesDetailDTO
                              {
                                  DtlId = o.dtl.DtlId,
                                  ProductId = o.dtl.ProductId,
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
