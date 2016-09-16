using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;
namespace DAL
{
    public class InvenReorderDal
    {
        public void Add(InvenReorderDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenReorder inreo = new InvenReorder();
                container.InvenReorders.AddObject((InvenReorder)DTOMapper.DTOObjectConverter(DTO, inreo));
                container.SaveChanges();
            }
        }
        public void Edit(InvenReorderDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenReorder();
                Comp = container.InvenReorders.FirstOrDefault(o => o.ReorderId.Equals(DTO.ReorderId));
                Comp.ReorderId = DTO.ReorderId;
                Comp.ReorderValue = DTO.ReorderValue;
                Comp.RateOfInterest = DTO.RateOfInterest;
                Comp.ProductId = DTO.ProductId;
                Comp.BrProId = DTO.BrProId;
                Comp.UpdateBy = DTO.UpdateBy;
                Comp.SalePrice = DTO.SalePrice;
                Comp.PurRequisitonStatus = DTO.PurRequisitonStatus;
                Comp.UpdateDate = DTO.UpdateDate;
                Comp = (InvenReorder)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public void Edit_PurrequisitonStatus(InvenReorderDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenReorder();
                Comp = container.InvenReorders.FirstOrDefault(o => o.ReorderId.Equals(DTO.ReorderId));

                Comp.PurRequisitonStatus = DTO.PurRequisitonStatus;
                Comp = (InvenReorder)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public List<InvenReorderDto> GetReorderInfo_UpdateProductInfo(int id, int catid, int brid, int compid, int proid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenReorders
                            join brance in Container.InvenBranchProfiles on s.BrProId equals brance.BrProId
                            join pro in Container.Products on s.ProductId equals pro.ProductId

                            select new { s, brance, pro };
                if (id != 0)
                    query = query.Where(c => c.s.ReorderId.Equals(id));
                if (catid != 0)
                    query = query.Where(c => c.pro.Category.CatId.Equals(catid));
                if (brid != 0)
                    query = query.Where(c => c.brance.BrProId.Equals(brid));
                if (compid != 0)
                    query = query.Where(c => c.pro.CompanyInfo.CompId.Equals(compid));
                if (proid != 0)
                    query = query.Where(c => c.pro.ProductId.Equals(proid));

                var result = from o in query
                             orderby o.s.ReorderId descending
                           where o.pro.ProductReOrderStatus==1
                             select new InvenReorderDto
                             {
                                 CategoryId = o.pro.Category.CatId,
                                 CategoryName = o.pro.Category.CategoryName,
                                 ReorderId = o.s.ReorderId,
                                 ReorderValue = o.s.ReorderValue,
                                 ProductId = o.pro.ProductId,
                                 ProductName = o.pro.ProductName,
                                 UnitId = o.pro.Unit.UnitId,
                                 UnitName = o.pro.Unit.UnitName,
                                 BrProId = o.brance.BrProId,
                                 RateOfInterest = o.s.RateOfInterest,
                                 CreateBy = o.s.CreateBy,
                                 SalePrice=o.s.SalePrice,
                                 ProductSalePrice=o.pro.ProductSalePrice,
                                 Createdate = o.s.Createdate,
                                 CompName = o.pro.CompanyInfo.CompName,
                                 ProductPurchasePrice=o.pro.ProductPurchasePrice,
                                 CompId = o.pro.CompanyInfo.CompId

                             };
                return result.ToList<InvenReorderDto>();
            }
        }

        public List<InvenReorderDto> GetReorderInfo(int id, int catid, int brid, int compid, int proid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenReorders
                            join brance in Container.InvenBranchProfiles on s.BrProId equals brance.BrProId
                            join pro in Container.Products on s.ProductId equals pro.ProductId

                            select new { s, brance, pro};
                if (id != 0)
                    query = query.Where(c => c.s.ReorderId.Equals(id));
                if (catid != 0)
                    query = query.Where(c => c.pro.Category.CatId.Equals(catid));
                if (brid != 0)
                    query = query.Where(c => c.brance.BrProId.Equals(brid));
                if (compid != 0)
                    query = query.Where(c => c.pro.CompanyInfo.CompId.Equals(compid));
                if (proid != 0)
                    query = query.Where(c => c.pro.ProductId.Equals(proid));

                var result = from o in query
                             orderby o.s.ReorderId descending
                             select new InvenReorderDto
                              {
                                  CategoryId = o.pro.Category.CatId,
                                  CategoryName = o.pro.Category.CategoryName,
                                  ReorderId = o.s.ReorderId,
                                  ReorderValue = o.s.ReorderValue,
                                  ProductId = o.pro.ProductId,
                                  ProductName = o.pro.ProductName,
                                  UnitId = o.pro.Unit.UnitId,
                                  UnitName = o.pro.Unit.UnitName,
                                  BrProId = o.brance.BrProId,
                                  RateOfInterest = o.s.RateOfInterest,
                                  CreateBy = o.s.CreateBy,
                                  Createdate = o.s.Createdate,
                                  SalePrice=o.s.SalePrice,
                                  ProductPurchasePrice = o.pro.ProductPurchasePrice,
                                  CompName = o.pro.CompanyInfo.CompName,
                                  CompId = o.pro.CompanyInfo.CompId

                              };
                return result.ToList<InvenReorderDto>();
            }
        }
        //load  rate of interest
        //public List<InvenReorderDto> GetInterestPrice_OrderInfo_BranchWise(int brprid, int proid)
        //{

        //    using (var Container = new InventoryContainer())
        //    {
        //        var query = from s in Container.InvenReorders
        //                    join brance in Container.InvenBranchProfiles on s.BrProId equals brance.BrProId
        //                    join pro in Container.Products on s.ProductId equals pro.ProductId

        //                    select new { s, brance, pro };
        //        if (brprid != 0)
        //            query = query.Where(c => c.brance.Equals(brprid));
        //        if (proid != 0)
        //            query = query.Where(c => c.pro.ProductId.Equals(proid));

        //        var result = from o in query
        //                     orderby o.s.ReorderId descending
        //                     select new InvenReorderDto
        //                         {
        //                             ProductId = o.pro.ProductId,
        //                             BrProId = o.brance.BrProId,
        //                             RateOfInterest = o.s.RateOfInterest,
        //                         };
        //        return result.ToList<InvenReorderDto>();
        //    }
        //}


        //// for product reorder using outer join
        //public List<ProductDTO> GetProduct_Categorywise_ReorderLevel_New(int catid, int brproid)
        //{
        //    using (var Container = new InventoryContainer())
        //    {
        //        var query = from s in Container.Products
        //                    join unit in Container.Units on s.UnitId equals unit.UnitId
        //                    join cat in Container.Categories on s.CategoryId equals cat.CatId
        //                  //  join reorder in Container.InvenReorders on s.ProductId equals reorder.ProductId
        //                   // join reorder in Container.InvenReorders on s.ProductId equals reorder.ProductId into outer
        //                   // from reorder in outer.DefaultIfEmpty()
        //                    select new { s, unit, cat };

        //        if (catid != 0)
        //            query = query.Where(c => c.cat.CatId.Equals(catid));
        //        if (brproid != 0)
        //            query = query.Where(c => c.cat.CatId.Equals(brproid));

        //        var result = from o in query
        //                     orderby o.s.ProductId descending
        //                    // where o.s.InvenReorders.
        //                     /// where o.reorder.ReorderValue == null
        //                     select new ProductDTO
        //                     {
        //                         UnitId = o.unit.UnitId,
        //                         UnitName = o.unit.UnitName,
        //                         CompName = o.s.CompanyInfo.CompName,
        //                         CompId = o.s.CompanyInfo.CompId,
        //                         CategoryId = o.cat.CatId,
        //                         CategoryName = o.cat.CategoryName,
        //                         ProductId = o.s.ProductId,
        //                         ProductName = o.s.ProductName,
        //                      //   ReorderValue = ((o.reorder == null) ? 0 : o.reorder.ReorderValue),
        //                        // RateOfInterest = ((o.reorder == null) ? 0 : o.reorder.RateOfInterest)

        //                     };
        //        return result.ToList<ProductDTO>();
        //    }
        //}

        //// for product reorder using outer join for update
        //public List<ProductDTO> GetProduct_Categorywise_ReorderLevel_Update(int catid, int brproid)
        //{
        //    using (var Container = new InventoryContainer())
        //    {
        //        var query = from s in Container.Products
        //                    join unit in Container.Units on s.UnitId equals unit.UnitId
        //                    join cat in Container.Categories on s.CategoryId equals cat.CatId
        //                    join reorder in Container.InvenReorders on s.ProductId equals reorder.ProductId into outer
        //                    from reorder in outer.DefaultIfEmpty()

        //                    select new { s, unit, cat, reorder };
        //        if (catid != 0)
        //            query = query.Where(c => c.cat.CatId.Equals(catid));
        //        if (brproid != 0)
        //            query = query.Where(c => c.cat.CatId.Equals(brproid));

        //        var result = from o in query
        //                     orderby o.s.ProductId descending
        //                    // where o.reorder.ReorderValue != null
        //                     select new ProductDTO
        //                   {
        //                       UnitId = o.unit.UnitId,
        //                       UnitName = o.unit.UnitName,
        //                       CompName = o.s.CompanyInfo.CompName,
        //                       CompId = o.s.CompanyInfo.CompId,
        //                       CategoryId = o.cat.CatId,
        //                       CategoryName = o.cat.CategoryName,
        //                       ProductId = o.s.ProductId,
        //                       ProductName = o.s.ProductName,
        //                       ReorderValue= o.reorder==null? 0:o.reorder.ReorderValue,
        //                       //ReorderValue = ((o.reorder == null) ? 0 : o.reorder.ReorderValue),
        //                     // RateOfInterest = ((o.reorder == null) ? 0 : o.reorder.RateOfInterest),
        //                       ReorderId = o.reorder.ReorderId,
        //                       BrProName = o.reorder.InvenBranchProfile.BrProName

        //                   };
        //        return result.ToList<ProductDTO>();
        //    }
        //}
    }
}
