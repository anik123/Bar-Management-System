using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class CocktailInfoDAL
    {
        CocktailInfoDTO cockDTO = new CocktailInfoDTO();
        public void Add(CocktailInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                CocktailInfo gur = new CocktailInfo();
                container.CocktailInfoes.AddObject((CocktailInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }
        public void Edit(CocktailInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new CocktailInfo();
                Comp = container.CocktailInfoes.FirstOrDefault(o => o.CocktaiInfoId.Equals(DTO.CocktaiInfoId));
                Comp.CocktaiInfoId = DTO.CocktaiInfoId;
                Comp.CocktaiProId = DTO.CocktaiProId;
                Comp.ItemProId = DTO.ItemProId;
                Comp.Quantity = DTO.Quantity;
                Comp.CreateBy = DTO.CreateBy;
                Comp.CreateDate = DTO.CreateDate;
                Comp = (CocktailInfo)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        public List<CocktailInfoDTO> GetCocktail(int proid,int itemproid) 
        {
            using(var container=new InventoryContainer())
            {
                var query = from pro in container.Products
                            join cock in container.CocktailInfoes on pro.ProductId equals cock.ItemProId
                            select new { pro, cock };
                if (proid != 0)
                    query = query.Where(o=>o.cock.CocktaiProId==proid);
                if (itemproid != 0)
                    query = query.Where(o=>o.cock.ItemProId==itemproid);
                var result = (from o in query
                              select new CocktailInfoDTO
                              {
                                  CategoryName=o.pro.Category.CategoryName,
                                  CompName=o.pro.CompanyInfo.CompName,
                                  Quantity=o.cock.Quantity,
                                  CocktaiInfoId=o.cock.CocktaiInfoId,
                                  CocktaiProId=o.cock.CocktaiProId,
                                  ItemProId=o.cock.ItemProId

                              }).ToList<CocktailInfoDTO>();
                return result;

            }
        }
    }
}
