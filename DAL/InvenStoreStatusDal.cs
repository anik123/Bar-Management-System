using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class InvenStoreStatusDal
    {

        public void Add(InvenStoreStatusDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenStoreStatu ino = new InvenStoreStatu();
                container.InvenStoreStatus.AddObject((InvenStoreStatu)DTOMapper.DTOObjectConverter(DTO, ino));
                container.SaveChanges();
            }
        }

        public void Edit(InvenStoreStatusDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenStoreStatu();
                Comp = container.InvenStoreStatus.FirstOrDefault(o => o.InvenStoreId.Equals(DTO.InvenStoreId));
                Comp.InvenStoreId = DTO.InvenStoreId;
                Comp.ProductId = DTO.ProductId;
                Comp.BrProId = DTO.BrProId;
                Comp.QuantityStore = DTO.QuantityStore;
                Comp.QuantityPurchase = DTO.QuantityPurchase;
                Comp.QuantityLastPurchase=DTO.QuantityLastPurchase;
                               
                Comp.DateUpdated = DTO.DateUpdated;
                
                Comp = (InvenStoreStatu)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public void EditQty(InvenStoreStatusDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenStoreStatu();
                Comp = container.InvenStoreStatus.FirstOrDefault(o => o.InvenStoreId.Equals(DTO.InvenStoreId));
                Comp.InvenStoreId = DTO.InvenStoreId;
                Comp.ProductId = DTO.ProductId;
                Comp.QuantityStore = DTO.QuantityStore;
                Comp.QuantityLastPurchase = DTO.QuantityLastPurchase;
                
                Comp.DateUpdated = DTO.DateUpdated;
                Comp.QuantityPurchase = DTO.QuantityPurchase;
                Comp = (InvenStoreStatu)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        public List<InvenStoreStatusDto> GetStoreStatus_Central(int id, int catid, int proid, int branchid, int compid, int reordervalue)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenStoreStatus
                            join brance in Container.InvenBranchProfiles on s.BrProId equals brance.BrProId
                            join pro in Container.Products on s.ProductId equals pro.ProductId
                            //    join cat in Container.Categories on s.CategoryId equals cat.CatId
                            select new { s, brance, pro };
                if (id != 0)
                    query = query.Where(c => c.s.InvenStoreId.Equals(id));
                if (catid != 0)
                    query = query.Where(c => c.pro.Category.CatId.Equals(catid));
                if (proid != 0)
                    query = query.Where(c => c.pro.ProductId.Equals(proid));
                if (branchid != 0)
                    query = query.Where(c => c.brance.BrProId.Equals(branchid));
                if (compid != 0)
                    query = query.Where(c => c.pro.CompanyInfo.CompId.Equals(compid));

                var result = from o in query
                             orderby o.s.InvenStoreId descending
                             where o.s.QuantityStore < reordervalue
                             select new InvenStoreStatusDto
                             {


                                 ProductId = o.pro.ProductId,
                                 BrProId = o.brance.BrProId,
                                 InvenStoreId = o.s.InvenStoreId,
                                 QuantityStore = o.s.QuantityStore,
                                 QuantityPurchase = o.s.QuantityPurchase,
                                 QuantityLastPurchase = o.s.QuantityLastPurchase,
                                 DateStored = o.s.DateStored,
                                 DateUpdated = o.s.DateUpdated


                             };
                return result.ToList<InvenStoreStatusDto>();
            }
        }


        public List<InvenStoreStatusDto> GetStoreStatusById(int id,int catid, int proid , int branchid,int compid,int reordervalue)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenStoreStatus
                            join brance in Container.InvenBranchProfiles on s.BrProId equals brance.BrProId
                            join pro in Container.Products on s.ProductId equals pro.ProductId
                            //    join cat in Container.Categories on s.CategoryId equals cat.CatId
                            select new { s, brance, pro };
                if (id != 0)
                    query = query.Where(c => c.s.InvenStoreId.Equals(id));
                if (catid != 0)
                    query = query.Where(c => c.pro.Category.CatId.Equals(catid));
                if (proid != 0)
                    query = query.Where(c => c.pro.ProductId.Equals(proid));
                if (branchid != 0)
                    query = query.Where(c => c.brance.BrProId.Equals(branchid));
                if (compid != 0)
                    query = query.Where(c => c.pro.CompanyInfo.CompId.Equals(compid));

                var result = from o in query
                             orderby o.s.InvenStoreId descending
                             where o.s.QuantityStore<reordervalue
                             select new InvenStoreStatusDto
                             {


                                 ProductId = o.pro.ProductId,
                                 BrProId = o.brance.BrProId,
                                 InvenStoreId = o.s.InvenStoreId,
                                 QuantityStore = o.s.QuantityStore,
                                 PurchasePrice=o.pro.ProductPurchasePrice,
                                 QuantityPurchase = o.s.QuantityPurchase,
                                 QuantityLastPurchase = o.s.QuantityLastPurchase,
                                 DateStored = o.s.DateStored,
                                 DateUpdated = o.s.DateUpdated

                             };
                return result.ToList<InvenStoreStatusDto>();
            }
        }

        public List<InvenStoreStatusDto> GetCurrentStockStaus(int id, int catid, int proid, int branchid, int compid, int reordervalue)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenStoreStatus
                            join brance in Container.InvenBranchProfiles on s.BrProId equals brance.BrProId
                            join pro in Container.Products on s.ProductId equals pro.ProductId
                            //    join cat in Container.Categories on s.CategoryId equals cat.CatId
                            select new { s, brance, pro };
                if (id != 0)
                    query = query.Where(c => c.s.InvenStoreId.Equals(id));
                if (catid != 0)
                    query = query.Where(c => c.pro.Category.CatId.Equals(catid));
                if (proid != 0)
                    query = query.Where(c => c.pro.ProductId.Equals(proid));
                if (branchid != 0)
                    query = query.Where(c => c.brance.BrProId.Equals(branchid));
                if (compid != 0)
                    query = query.Where(c => c.pro.CompanyInfo.CompId.Equals(compid));

                var result = from o in query
                            // orderby o.s.InvenStoreId descending
                            /// where o.s.QuantityStore < reordervalue
                             select new InvenStoreStatusDto
                             {


                                 ProductId = o.pro.ProductId,
                                 BrProId = o.brance.BrProId,
                                 InvenStoreId = o.s.InvenStoreId,
                                 QuantityStore = o.s.QuantityStore,
                                 QuantityPurchase = o.s.QuantityPurchase,
                                 QuantityLastPurchase = o.s.QuantityLastPurchase,
                                 DateStored = o.s.DateStored,
                                 DateUpdated=o.s.DateUpdated
                                 

                             };
                return result.ToList<InvenStoreStatusDto>();
            }
        }


        public List<InvenStoreStatusDto> GetStoreStatusByProId(int proid, int branchid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenStoreStatus
                            join brance in Container.InvenBranchProfiles on s.BrProId equals brance.BrProId
                            join pro in Container.Products on s.ProductId equals pro.ProductId
                            //    join cat in Container.Categories on s.CategoryId equals cat.CatId
                            select new { s, brance, pro };
                if (proid != 0)
                    query = query.Where(c => c.pro.ProductId.Equals(proid));
                if (branchid != 0)
                    query = query.Where(c => c.brance.BrProId.Equals(branchid));
                var result = from o in query
                             // orderby o.s.InvenStoreId descending
                             /// where o.s.QuantityStore < reordervalue
                             select new InvenStoreStatusDto
                             {


                                 ProductId = o.pro.ProductId,
                                 BrProId = o.brance.BrProId,
                                 InvenStoreId = o.s.InvenStoreId,
                                 QuantityStore = o.s.QuantityStore,
                                 QuantityPurchase = o.s.QuantityPurchase,
                                 QuantityLastPurchase = o.s.QuantityLastPurchase,
                                 DateStored = o.s.DateStored,
                                 DateUpdated = o.s.DateUpdated

                             };
                return result.ToList<InvenStoreStatusDto>();
            }
        }
    }
}
