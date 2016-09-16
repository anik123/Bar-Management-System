using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDTO
{
    public class PageObjectRoleDTO
    {
        public int PageObjAccId { get; set; }
        public int RoleId { get; set; }
        public int PageObjectId { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public string UpdateDate { get; set; }

        // load page object 
        public string PageTypeName { get; set; }
        public string PageName { get; set; }
        public string PagePath { get; set; }
        public string PageMethodeName { get; set; }
        // load role data
        public string RoleName { get; set; }
    }
}
