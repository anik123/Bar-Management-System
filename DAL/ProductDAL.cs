using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class ProductDAL
    {
        public void Add(ProductDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                Product gur = new Product();
                container.Products.AddObject((Product)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(ProductDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new Product();
                Comp = container.Products.FirstOrDefault(o => o.ProductId.Equals(DTO.ProductId));
                Comp.ProductId = DTO.ProductId;
                Comp.UnitId = DTO.UnitId;
                Comp.ProductPurchasePrice = DTO.ProductPurchasePrice;
                Comp.CategoryId = DTO.CategoryId;
                Comp.ProductName = DTO.ProductName;
                Comp.CreateBy = DTO.CreateBy;
                Comp.CreateDate = DTO.CreateDate;
                Comp.CompId = DTO.CompId;
                Comp.ProductSalePrice = DTO.ProductSalePrice;
                Comp.ProductOffSalePrice = DTO.ProductOffSalePrice;
                Comp.CenterReorderValue = DTO.CenterReorderValue;
                Comp = (Product)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }


        public List<ProductDTO> GetProduct(int proid, string productname, int catid, int unitid, int compid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Products

                            join cat in Container.Categories on s.CategoryId equals cat.CatId
                            select new { s, cat };
                if (proid != 0)
                    query = query.Where(c => c.s.ProductId.Equals(proid));
                if (compid != 0)
                    query = query.Where(c => c.s.CompanyInfo.CompId.Equals(compid));
                if (!string.IsNullOrEmpty(productname))
                    query = query.Where(c => c.s.ProductName.Contains(productname));
                if (catid != 0)
                    query = query.Where(c => c.cat.CatId.Equals(catid));
                /*
                  if (unitid != 0)
                      query = query.Where(c => c.unit.UnitId.Equals(unitid));
                  */
                var result = from o in query
                             orderby o.s.ProductId descending

                             select new ProductDTO
                             {
                                 CompName = o.s.CompanyInfo.CompName,
                                 CompId = o.s.CompanyInfo.CompId,
                                 CatId = o.cat.CatId,
                                 //    UnitId = o.unit.UnitId,
                                 //  UnitName = o.unit.UnitName,
                                 ProductPurchasePrice = o.s.ProductPurchasePrice,
                                 ProductOffSalePrice = o.s.ProductOffSalePrice,
                                 CategoryId = o.cat.CatId,
                                 CategoryName = o.cat.CategoryName,
                                 ProductId = o.s.ProductId,
                                 ProductName = o.s.ProductName,
                                 CreateBy = o.s.CreateBy,
                                 CenterReorderValue = o.s.CenterReorderValue,
                                 CreateDate = o.s.CreateDate,
                                 ProductSalePrice = o.s.ProductSalePrice
                             };
                return result.ToList<ProductDTO>();
            }
        }

        public List<ProductDTO> GetProductByCategory(string CateName)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Products

                            join cat in Container.Categories on s.CategoryId equals cat.CatId
                            join comp in Container.CompanyInfoes on s.CompId equals comp.CompId
                            select new { s, cat,comp };

                if (!string.IsNullOrEmpty(CateName))
                    query = query.Where(c => c.comp.CompName.Contains(CateName));

                var result = from o in query
                             orderby o.s.ProductId descending

                             select new ProductDTO
                             {
                                 CompName = o.s.CompanyInfo.CompName,
                                 CompId = o.s.CompanyInfo.CompId,
                                 CatId = o.cat.CatId,
                                 //    UnitId = o.unit.UnitId,
                                 //  UnitName = o.unit.UnitName,
                                 ProductPurchasePrice = o.s.ProductPurchasePrice,
                                 ProductOffSalePrice = o.s.ProductOffSalePrice,
                                 CategoryId = o.cat.CatId,
                                 CategoryName = o.cat.CategoryName,
                                 ProductId = o.s.ProductId,
                                 ProductName = o.s.ProductName,
                                 CreateBy = o.s.CreateBy,
                                 CenterReorderValue = o.s.CenterReorderValue,
                                 CreateDate = o.s.CreateDate,
                                 ProductSalePrice = o.s.ProductSalePrice
                             };
                return result.ToList<ProductDTO>();
            }
        }

        // for product purchase 
        public List<ProductDTO> GetProduct_Categorywise(int id, int compid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = (from s in Container.Products
                             // join unit in Container.Units on s.UnitId equals unit.UnitId
                             join cat in Container.Categories on s.CategoryId equals cat.CatId
                             select new { s, cat }).Distinct();
                if (id != 0)
                    query = query.Where(c => c.cat.CatId.Equals(id));

                if (compid != 0)
                    query = query.Where(c => c.s.CompanyInfo.CompId.Equals(compid));
                var result = from o in query
                             orderby o.s.ProductId descending

                             select new ProductDTO
                             {
                                 CenterReorderValue = o.s.CenterReorderValue,
                                 //   UnitId = o.unit.UnitId,
                                 //   UnitName = o.unit.UnitName,
                                 ProductPurchasePrice = o.s.ProductPurchasePrice,
                                 CompName = o.s.CompanyInfo.CompName,
                                 CompId = o.s.CompanyInfo.CompId,
                                 CatId = o.cat.CatId,
                                 CategoryName = o.cat.CategoryName,
                                 ProductId = o.s.ProductId,
                                 ProductName = o.s.ProductName,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,
                                 ProductSalePrice = o.s.ProductSalePrice
                             };
                return result.ToList<ProductDTO>();
            }
        }



        public List<ProductDTO> GetProduct_Category(int id, int compid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = (from cat in Container.Categories select new { cat });
                if (id != 0)
                    query = query.Where(c => c.cat.CatId.Equals(id));
                var result = from o in query


                             select new ProductDTO
                             {
                                 CatId = o.cat.CatId,
                                 CategoryName = o.cat.CategoryName,
                             };
                return result.ToList<ProductDTO>();
            }
        }
        // for product reorder 
        public List<ProductDTO> GetProduct_Categorywise_ReorderLevel(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Products
                            join unit in Container.Units on s.UnitId equals unit.UnitId
                            join cat in Container.Categories on s.CategoryId equals cat.CatId
                            select new { s, unit, cat };
                if (id != 0)
                    query = query.Where(c => c.cat.CatId.Equals(id));

                var result = from o in query
                             orderby o.s.ProductId descending
                             where o.s.ReorderInsertStatus == "0"
                             select new ProductDTO
                             {
                                 CenterReorderValue = o.s.CenterReorderValue,
                                 UnitId = o.unit.UnitId,
                                 UnitName = o.unit.UnitName,
                                 CompName = o.s.CompanyInfo.CompName,
                                 ProductPurchasePrice = o.s.ProductPurchasePrice,
                                 CompId = o.s.CompanyInfo.CompId,
                                 CategoryId = o.cat.CatId,
                                 CategoryName = o.cat.CategoryName,
                                 ProductId = o.s.ProductId,
                                 ProductName = o.s.ProductName,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,
                                 ProductSalePrice = o.s.ProductSalePrice
                             };
                return result.ToList<ProductDTO>();
            }
        }
        public List<ProductDTO> GetUnnit_Productwise(int proid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Products

                            select new { s };
                if (proid != 0)
                    query = query.Where(c => c.s.ProductId.Equals(proid));

                var result = from o in query

                             select new ProductDTO
                             {
                                 UnitId = o.s.Unit.UnitId,
                                 UnitName = o.s.Unit.UnitName,
                                 ProductPurchasePrice = o.s.ProductPurchasePrice,

                                 ProductSalePrice = o.s.ProductSalePrice

                             };
                return result.ToList<ProductDTO>();
            }
        }
        // load all data for sales using  barcode  
        public List<ProductDTO> LoadALL_Using_BarCode_Sales(int proid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Products

                            select new { s };
                if (proid != 0)
                    query = query.Where(c => c.s.ProductId.Equals(proid));

                var result = from o in query

                             select new ProductDTO
                             {
                                 UnitId = o.s.Unit.UnitId,
                                 UnitName = o.s.Unit.UnitName,
                                 CompId = o.s.CompanyInfo.CompId,
                                 CompName = o.s.CompanyInfo.CompName,
                                 CategoryName = o.s.Category.CategoryName,
                                 CatId = o.s.Category.CatId,
                                 ProductId = o.s.ProductId,
                                 ProductName = o.s.ProductName,
                                 ProductPurchasePrice = o.s.ProductPurchasePrice,

                                 ProductSalePrice = o.s.ProductSalePrice

                             };
                return result.ToList<ProductDTO>();
            }
        }

        public List<ProductDTO> GetProductForReturn(int compid, int catid, int proid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Products
                            join unit in Container.Units on s.UnitId equals unit.UnitId
                            join cat in Container.Categories on s.CategoryId equals cat.CatId
                            join storests in Container.InvenStoreStatus on s.ProductId equals storests.ProductId
                            select new { s, unit, cat, storests };
                if (proid != 0)
                    query = query.Where(c => c.s.ProductId.Equals(proid));
                if (compid != 0)
                    query = query.Where(c => c.s.CompanyInfo.CompId.Equals(compid));
                if (catid != 0)
                    query = query.Where(c => c.cat.CatId.Equals(catid));

                var result = from o in query
                             orderby o.s.ProductId descending

                             select new ProductDTO
                             {
                                 CompName = o.s.CompanyInfo.CompName,
                                 CompId = o.s.CompanyInfo.CompId,
                                 CatId = o.cat.CatId,
                                 UnitId = o.unit.UnitId,
                                 UnitName = o.unit.UnitName,
                                 ProductPurchasePrice = o.s.ProductPurchasePrice,
                                 CategoryId = o.cat.CatId,
                                 CategoryName = o.cat.CategoryName,
                                 ProductId = o.s.ProductId,
                                 ProductName = o.s.ProductName,
                                 CreateBy = o.s.CreateBy,
                                 CenterReorderValue = o.s.CenterReorderValue,
                                 CreateDate = o.s.CreateDate,
                                 ProductSalePrice = o.s.ProductSalePrice,
                                 QuantityStore = o.storests.QuantityStore
                             };
                return result.ToList<ProductDTO>();
            }
        }

        public List<ProductDTO> GetProductForCentralReturn(int compid, int catid, int proid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Products
                            join unit in Container.Units on s.UnitId equals unit.UnitId
                            join cat in Container.Categories on s.CategoryId equals cat.CatId
                            join storests in Container.InvenCenteralStoreStatus on s.ProductId equals storests.ProductId
                            select new { s, unit, cat, storests };
                if (proid != 0)
                    query = query.Where(c => c.s.ProductId.Equals(proid));
                if (compid != 0)
                    query = query.Where(c => c.s.CompanyInfo.CompId.Equals(compid));
                if (catid != 0)
                    query = query.Where(c => c.cat.CatId.Equals(catid));

                var result = from o in query
                             orderby o.s.ProductId descending

                             select new ProductDTO
                             {
                                 CompName = o.s.CompanyInfo.CompName,
                                 CompId = o.s.CompanyInfo.CompId,
                                 CatId = o.cat.CatId,
                                 UnitId = o.unit.UnitId,
                                 UnitName = o.unit.UnitName,
                                 ProductPurchasePrice = o.s.ProductPurchasePrice,
                                 CategoryId = o.cat.CatId,
                                 CategoryName = o.cat.CategoryName,
                                 ProductId = o.s.ProductId,
                                 ProductName = o.s.ProductName,
                                 CreateBy = o.s.CreateBy,
                                 CenterReorderValue = o.s.CenterReorderValue,
                                 CreateDate = o.s.CreateDate,
                                 ProductSalePrice = o.s.ProductSalePrice,
                                 QuantityStore = o.storests.QuantityStore
                             };
                return result.ToList<ProductDTO>();
            }
        }

        public List<ProductDTO> GetProductForReOrder(int proid, string productname, int catid, int unitid, int compid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Products
                            join unit in Container.Units on s.UnitId equals unit.UnitId
                            join cat in Container.Categories on s.CategoryId equals cat.CatId
                            select new { s, unit, cat };
                if (proid != 0)
                    query = query.Where(c => c.s.ProductId.Equals(proid));
                if (compid != 0)
                    query = query.Where(c => c.s.CompanyInfo.CompId.Equals(compid));
                if (!string.IsNullOrEmpty(productname))
                    query = query.Where(c => c.s.ProductName.Contains(productname));
                if (catid != 0)
                    query = query.Where(c => c.cat.CatId.Equals(catid));
                if (unitid != 0)
                    query = query.Where(c => c.unit.UnitId.Equals(unitid));

                var result = from o in query
                             orderby o.s.ProductId descending
                             where o.s.ProductReOrderStatus != 1

                             select new ProductDTO
                             {
                                 CompName = o.s.CompanyInfo.CompName,
                                 CompId = o.s.CompanyInfo.CompId,
                                 CatId = o.cat.CatId,
                                 UnitId = o.unit.UnitId,
                                 UnitName = o.unit.UnitName,
                                 ProductPurchasePrice = o.s.ProductPurchasePrice,
                                 CategoryId = o.cat.CatId,
                                 CategoryName = o.cat.CategoryName,
                                 ProductId = o.s.ProductId,
                                 ProductName = o.s.ProductName,
                                 CreateBy = o.s.CreateBy,
                                 CenterReorderValue = o.s.CenterReorderValue,
                                 CreateDate = o.s.CreateDate,
                                 ProductSalePrice = o.s.ProductSalePrice
                             };
                return result.ToList<ProductDTO>();
            }
        }

        public List<ProductDTO> CheckProductCodeExits(int compid, string pcode, int pid)
        {
            using (var Container = new InventoryContainer())
            {

                var checkPro = from pro in Container.Products select new { pro };

                if (pcode != "")
                    checkPro = checkPro.Where(c => c.pro.ProductName == pcode);
                if (pid != 0)
                    checkPro = checkPro.Where(c => c.pro.ProductId != pid);
                if (compid != 0)
                    checkPro = checkPro.Where(c => c.pro.CompId == compid);


                var result = from o in checkPro
                             orderby o.pro.ProductId descending

                             select new ProductDTO
                             {
                                 CompName = o.pro.CompanyInfo.CompName,
                                 CompId = o.pro.CompanyInfo.CompId,

                             };
                return result.ToList<ProductDTO>();



            }
        }

        public void EditStatus(ProductDTO PDTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new Product();
                Comp = container.Products.FirstOrDefault(o => o.ProductId.Equals(PDTO.ProductId));
                Comp.ProductId = PDTO.ProductId;
                Comp.ProductReOrderStatus = PDTO.ProductReOrderStatus;
                Comp = (Product)DTOMapper.DTOObjectConverter(PDTO, Comp);
                container.SaveChanges();
            }
        }

    }
}
