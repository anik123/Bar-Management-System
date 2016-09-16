using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class InvenTempSaleDAL
    {
        public void Add(InvenTempSaleDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenTempSale ino = new InvenTempSale();
                container.InvenTempSales.AddObject((InvenTempSale)DTOMapper.DTOObjectConverter(DTO, ino));
                container.SaveChanges();
            }
        }
        public void Delete(int MemId)
        {
            using (var container = new InventoryContainer())
            {
                var temp = from o in container.InvenTempSales
                           where o.MemberId == MemId
                           select o;
                foreach (var content in temp)
                {
                    container.InvenTempSales.DeleteObject(content);
                }
                container.SaveChanges();
            }
        }
        public void DeleteByTempId(int TempId)
        {
            using (var container = new InventoryContainer())
            {
                var temp = from o in container.InvenTempSales
                           where o.TempId == TempId
                           select o;
                foreach (var content in temp)
                {
                    container.InvenTempSales.DeleteObject(content);
                }
                container.SaveChanges();
            }
        }
        public void DeleteByDate(string date)
        {
            using (var container = new InventoryContainer())
            {
                if (!String.IsNullOrEmpty(date))
                {
                    DateTime Date = DateTime.Parse(date);
                    var temp = from o in container.InvenTempSales
                               where o.CreateDate < Date
                               select o;
                    foreach (var content in temp)
                    {
                        container.InvenTempSales.DeleteObject(content);
                    }
                    container.SaveChanges();
                }
            }
        }
        public void Delete(int MemId, int ProId)
        {
            using (var container = new InventoryContainer())
            {
                var temp = from o in container.InvenTempSales
                           where o.MemberId == MemId && o.ProductId == ProId

                           select o;
                foreach (var content in temp)
                {
                    container.InvenTempSales.DeleteObject(content);
                }
                container.SaveChanges();
            }
        }
        public void DeleteTempId(int TempId)
        {
            using (var container = new InventoryContainer())
            {
                var temp = from o in container.InvenTempSales
                           where o.TempId == TempId

                           select o;
                foreach (var content in temp)
                {
                    container.InvenTempSales.DeleteObject(content);
                }
                container.SaveChanges();
            }
        }
        public List<InvenTempSaleDTO> LoadTempId()
        {
            using (var container = new InventoryContainer())
            {
                var data = from temp in container.InvenTempSales
                           select new { temp };
                var result = (from o in data
                              orderby o.temp.TempId descending
                              select new InvenTempSaleDTO
                              {
                                  TempId = o.temp.TempId
                              }).ToList<InvenTempSaleDTO>();
                return result;
            }
        }
        public List<InvenTempSaleDTO> GetAllInfo(int MemId)
        {
            using (var container = new InventoryContainer())
            {
                var query = from temp in container.InvenTempSales
                            select new { temp };
                if (MemId != 0)
                    query = query.Where(o => o.temp.MemberId == MemId);
                var result = (from o in query
                              select new InvenTempSaleDTO
                              {
                                  TempId = o.temp.TempId,
                                  MemberId = o.temp.MemberId,
                                  Category = o.temp.Category,
                                  SubCategory = o.temp.SubCategory,
                                  ProductId = o.temp.ProductId,
                                  Unit = o.temp.Unit,
                                  PegSize = o.temp.PegSize,
                                  UnitPrize = o.temp.UnitPrize,
                                  SaleType = o.temp.SaleType,
                                  CreateDate = o.temp.CreateDate
                              }).ToList<InvenTempSaleDTO>();
                return result;
            }
        }
        public List<InvenTempSaleDTO> GetOpenBalanceDate(string date)
        {
            using (var container = new InventoryContainer())
            {
                var query = from temp in container.InvenTempSales
                            select new { temp };
                DateTime Date;
                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.temp.CreateDate < Date);
                }
                var result = (from o in query
                              orderby o.temp.CreateDate descending
                              select new InvenTempSaleDTO
                              {
                                  TempId = o.temp.TempId,
                                  MemberId = o.temp.MemberId,
                                  Category = o.temp.Category,
                                  SubCategory = o.temp.SubCategory,
                                  ProductId = o.temp.ProductId,
                                  Unit = o.temp.Unit,
                                  PegSize = o.temp.PegSize,
                                  UnitPrize = o.temp.UnitPrize,
                                  SaleType = o.temp.SaleType,
                                  CreateDate = o.temp.CreateDate
                              }).ToList<InvenTempSaleDTO>();
                return result;
            }
        }
        public List<InvenTempSaleDTO> getTempById(int memid, string date)
        {
            using (var container = new InventoryContainer())
            {
                var query = from temp in container.InvenTempSales
                            select new { temp };
                if (memid != 0)
                    query = query.Where(o => o.temp.MemberId == memid);
                if (!String.IsNullOrEmpty(date))
                {
                    DateTime checkdate = DateTime.Parse(date);
                    query = query.Where(o => o.temp.CreateDate == checkdate);
                }
                var result = (from o in query
                              select new InvenTempSaleDTO
                              {
                                  TempId = o.temp.TempId,
                                  MemberId = o.temp.MemberId,
                                  Category = o.temp.Category,
                                  SubCategory = o.temp.SubCategory,
                                  ProductId = o.temp.ProductId,
                                  Unit = o.temp.Unit,
                                  PegSize = o.temp.PegSize,
                                  UnitPrize = o.temp.UnitPrize,
                                  SaleType = o.temp.SaleType,
                                  CreateDate = o.temp.CreateDate
                              }).ToList<InvenTempSaleDTO>();
                return result;
            }
        }
        public List<InvenTempSaleDTO> GetAllByTempId(int temId)
        {
            using (var container = new InventoryContainer())
            {
                var query = from temp in container.InvenTempSales
                            select new { temp };
                if (temId != 0)
                    query = query.Where(o => o.temp.TempId == temId);
                var result = (from o in query
                              select new InvenTempSaleDTO
                              {
                                  TempId = o.temp.TempId,
                                  MemberId = o.temp.MemberId,
                                  Category = o.temp.Category,
                                  SubCategory = o.temp.SubCategory,
                                  ProductId = o.temp.ProductId,
                                  Unit = o.temp.Unit,
                                  PegSize = o.temp.PegSize,
                                  UnitPrize = o.temp.UnitPrize,
                                  SaleType = o.temp.SaleType,
                                  CreateDate = o.temp.CreateDate
                                 
                              }).ToList<InvenTempSaleDTO>();
                return result;
            }
        }

    }
}
