using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class InvenCentralStoreStatusDAL
    {
        public void Add(InvenCentralStoreStatusDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenCenteralStoreStatu ino = new InvenCenteralStoreStatu();
                container.InvenCenteralStoreStatus.AddObject((InvenCenteralStoreStatu)DTOMapper.DTOObjectConverter(DTO, ino));
                container.SaveChanges();
            }
        }

        public void Edit(InvenCentralStoreStatusDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenCenteralStoreStatu();
                Comp = container.InvenCenteralStoreStatus.FirstOrDefault(o => o.CentralStoreId.Equals(DTO.CentralStoreId));
                Comp.CentralStoreId = DTO.CentralStoreId;
                Comp.ProductId = DTO.ProductId;
                Comp.QuantityStore = DTO.QuantityStore;
                Comp.QuantityLastPurchase = DTO.QuantityLastPurchase;
                Comp.QuantityPurchase = DTO.QuantityPurchase;
                Comp.DateUpdated = DTO.DateUpdated;
                Comp = (InvenCenteralStoreStatu)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public void EditStoreQty(InvenCentralStoreStatusDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenCenteralStoreStatu();
                Comp = container.InvenCenteralStoreStatus.FirstOrDefault(o => o.CentralStoreId.Equals(DTO.CentralStoreId));
                Comp.CentralStoreId = DTO.CentralStoreId;
                Comp.ProductId = DTO.ProductId;
                Comp.QuantityStore = DTO.QuantityStore;
                Comp = (InvenCenteralStoreStatu)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        public void EditCenQty(InvenCentralStoreStatusDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenCenteralStoreStatu();
                Comp = container.InvenCenteralStoreStatus.FirstOrDefault(o => o.CentralStoreId.Equals(DTO.CentralStoreId));
                Comp.CentralStoreId = DTO.CentralStoreId;
                Comp.ProductId = DTO.ProductId;
                Comp.QuantityStore = DTO.QuantityStore;
                Comp.BranchId = DTO.BranchId;
                Comp.CompanyId = DTO.CompanyId;
                Comp.DateUpdated = DTO.DateUpdated;
                Comp = (InvenCenteralStoreStatu)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        public List<InvenCentralStoreStatusDTO> LoadCentralStockStatus(int proid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCenteralStoreStatus

                            select new { s };

                if (proid != 0)
                    query = query.Where(c => c.s.Product.ProductId.Equals(proid));


                var result = from o in query

                             select new InvenCentralStoreStatusDTO
                             {
                                 ProductId = o.s.Product.ProductId,
                                 CategoryName=o.s.Product.Category.CategoryName,
                                 QuantityStore = o.s.QuantityStore,
                                 CentralStoreId = o.s.CentralStoreId,
                                 QuantityLastPurchase = o.s.QuantityLastPurchase,
                                 QuantityPurchase = o.s.QuantityPurchase,
                                 CompName=o.s.Product.CompanyInfo.CompName
                             };
                return result.ToList<InvenCentralStoreStatusDTO>();
            }
        }

        public List<ProductDTO> GetProduct(int proid, string productname, int catid, int unitid, int compid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Products
                            // join unit in Container.Units on s.UnitId equals unit.UnitId
                            join cat in Container.Categories on s.CategoryId equals cat.CatId
                            join store in Container.InvenCenteralStoreStatus on s.ProductId equals store.ProductId into outer
                            from store in outer.DefaultIfEmpty()
                            join purreq in Container.InvenCentralPurRequisitions on s.ProductId equals purreq.ProductId into outerreq
                            from pureq in outerreq.DefaultIfEmpty()
                            join sotrereq in Container.InvenPerRequisitions on s.ProductId equals sotrereq.ProductId
                            select new { s, cat, store, pureq, sotrereq };
                if (proid != 0)
                    query = query.Where(c => c.s.ProductId.Equals(proid));
                if (compid != 0)
                    query = query.Where(c => c.s.CompanyInfo.CompId.Equals(compid));
                if (!string.IsNullOrEmpty(productname))
                    query = query.Where(c => c.s.ProductName.Contains(productname));
                if (catid != 0)
                    query = query.Where(c => c.cat.CatId.Equals(catid));
                // if (unitid != 0)
                //   query = query.Where(c => c.unit.UnitId.Equals(unitid));

                var result = from o in query
                             orderby o.sotrereq.PurReqId descending
                             where o.s.CenterReorderValue >= ((o.store == null) ? 0 : o.store.QuantityStore)//|| o.pureq.PurReqStatus == ((o.pureq==null)?"":"0")
                             select new ProductDTO
                             {
                                 CompName = o.s.CompanyInfo.CompName,
                                 CompId = o.s.CompanyInfo.CompId,
                                 // UnitId = o.unit.UnitId,
                                 // UnitName = o.unit.UnitName,
                                 CategoryId = o.cat.CatId,
                                 CategoryName = o.cat.CategoryName,
                                 ProductId = o.s.ProductId,
                                 ProductName = o.s.ProductName,
                                 CreateBy = o.s.CreateBy,
                                 ProductPurchasePrice = o.s.ProductPurchasePrice,
                                 CenterReorderValue = o.s.CenterReorderValue,
                                 CreateDate = o.s.CreateDate,
                                 BranchRequistion = o.sotrereq.Quantity,
                                 BranchReqNo = o.sotrereq.PurReqId,
                                 CompanyId = o.store.CompanyId,
                                 BrachId = o.store.BranchId,


                                 QuantityStore = ((o.store == null) ? 0 : o.store.QuantityStore),
                                 ReqiredPurQuantity = o.s.CenterReorderValue - ((o.store == null) ? 0 : o.store.QuantityStore),
                                 PurReqQuantity = ((o.pureq == null) ? 0 : o.pureq.Quantity)
                             };

                return result.ToList<ProductDTO>();
            }
        }


        public void EditQty(InvenCentralStoreStatusDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenCenteralStoreStatu();
                Comp = container.InvenCenteralStoreStatus.FirstOrDefault(o => o.CentralStoreId.Equals(DTO.CentralStoreId));
                Comp.CentralStoreId = DTO.CentralStoreId;
                Comp.ProductId = DTO.ProductId;
                Comp.QuantityStore = DTO.QuantityStore;
                Comp = (InvenCenteralStoreStatu)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public List<InvenCentralPurRequisitonDTO> CheckPurReq(int purid, int proid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCentralPurRequisitions
                            where s.PurReqId == purid

                            select new { s };

                if (proid != 0)
                    query = query.Where(c => c.s.Product.ProductId == proid);


                var result = from o in query

                             select new InvenCentralPurRequisitonDTO
                             {
                                 ProductId = o.s.Product.ProductId,
                                 PurReqId = o.s.PurReqId,
                             };

                return result.ToList<InvenCentralPurRequisitonDTO>();
            }
        }
        public List<ProductDTO> GetProductQunatity(int proid)
        {
            using (var container = new InventoryContainer())
            {
                var query = from s in container.Products
                            join store in container.InvenCenteralStoreStatus on s.ProductId equals store.ProductId into outer
                            from store in outer.DefaultIfEmpty()
                            select new { s, store };
                if (proid != 0)
                    query = query.Where(c => c.s.ProductId == proid);
                var result = from o in query
                             select new ProductDTO
                             {
                                 QuantityStore = ((o.store == null) ? 0 : o.store.QuantityStore)
                             };
                return result.ToList<ProductDTO>();
            }
        }
        public List<ProductDTO> GetProductForReorder(int proid, string productname, int catid, int unitid, int compid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Products
                            join unit in Container.Units on s.UnitId equals unit.UnitId
                            join cat in Container.Categories on s.CategoryId equals cat.CatId
                            join store in Container.InvenCenteralStoreStatus on s.ProductId equals store.ProductId into outer
                            from store in outer.DefaultIfEmpty()
                            join sotrereq in Container.InvenPerRequisitions on s.ProductId equals sotrereq.ProductId
                            select new { s, unit, cat, store, sotrereq };
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
                             orderby o.sotrereq.PurReqId descending
                             // where o.s.CenterReorderValue >= ((o.store == null) ? 0 : o.store.QuantityStore)//|| o.pureq.PurReqStatus == ((o.pureq==null)?"":"0")

                             where o.sotrereq.PurReqStatus == "0"
                             select new ProductDTO
                             {
                                 CompName = o.s.CompanyInfo.CompName,
                                 CompId = o.s.CompanyInfo.CompId,
                                 UnitId = o.unit.UnitId,
                                 UnitName = o.unit.UnitName,
                                 CategoryId = o.cat.CatId,
                                 CategoryName = o.cat.CategoryName,
                                 ProductId = o.s.ProductId,
                                 ProductName = o.s.ProductName,
                                 CreateBy = o.s.CreateBy,
                                 ProductPurchasePrice = o.s.ProductPurchasePrice,
                                 CenterReorderValue = o.s.CenterReorderValue,
                                 CreateDate = o.s.CreateDate,
                                 BranchRequistion = o.sotrereq.Quantity,
                                 BranchReqNo = o.sotrereq.PurReqId,
                                 CompanyId = o.store.CompanyId,
                                 BrachId = o.store.BranchId,

                                 RequistionDate = o.sotrereq.RequisitionDate,
                                 QuantityStore = o.store.QuantityStore,
                                 ReqiredPurQuantity = o.s.CenterReorderValue,

                             };

                return result.ToList<ProductDTO>();
            }
        }
    }
}
