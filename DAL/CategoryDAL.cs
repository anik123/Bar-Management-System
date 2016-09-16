using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class CategoryDAL
    {
        public void Add(CategoryDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                Category gur = new Category();
                container.Categories.AddObject((Category)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(CategoryDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new Category();
                Comp = container.Categories.FirstOrDefault(o => o.CatId.Equals(DTO.CatId));
                Comp.CatId = DTO.CatId;
                Comp.CategoryName = DTO.CategoryName;
                Comp.UpdateBy = DTO.UpdateBy;
                Comp.UpdateDate = DTO.UpdateDate;

                Comp = (Category)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }


        public List<CategoryDTO> GetCategory(int id, string catename)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Categories
                            select new { s };
                if (id != 0)
                    query = query.Where(c => c.s.CatId.Equals(id));
                if (!string.IsNullOrEmpty(catename))
                    query = query.Where(c => c.s.CategoryName.Contains(catename));

                var result = from o in query
                             orderby o.s.CatId descending

                             select new CategoryDTO
                             {
                                 CatId = o.s.CatId,
                                 CategoryName = o.s.CategoryName,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,
                                 UpdateDate = o.s.UpdateDate
                             };
                return result.ToList<CategoryDTO>();
            }
        }


    }
}

