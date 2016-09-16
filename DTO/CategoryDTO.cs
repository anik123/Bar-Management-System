
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class CategoryDTO
    {
        public int CatId { get; set; }
        public int? ComId { get; set; }
        public string CategoryName { get; set; }

        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
