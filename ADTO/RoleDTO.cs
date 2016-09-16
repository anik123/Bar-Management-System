using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public  class RoleDTO
    {
        public int RoleId {get;set; }
        public string RoleName { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
