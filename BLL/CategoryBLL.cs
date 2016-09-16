using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class CategoryBLL
    {
        CategoryDAL DAL = new CategoryDAL();
        public void Add(CategoryDTO DTO)
        {
            DAL.Add(DTO);
        }
        public void Edit(CategoryDTO DTO)
        {
            DAL.Edit(DTO);
        }
        public List<CategoryDTO> GetCategory(int id, string catename)
        {
            return DAL.GetCategory(id,catename);
        }
    }
}
