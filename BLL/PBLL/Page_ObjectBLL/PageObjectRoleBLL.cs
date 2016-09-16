using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDAL.Page_Object;
using PDTO;

namespace PBLL.Page_ObjectBLL
{
    public class PageObjectRoleBLL
    {
        PageObjectRoleDAL dal = new PageObjectRoleDAL();
        public void Add(PageObjectRoleDTO DTO)
        {
            dal.Add(DTO);
        }

        public void Edit(PageObjectRoleDTO EduDTO)
        {
            dal.Edit(EduDTO);
        }
        // delete data
        public void Delete_Data(int pageobjectid, int roleid)
        {
            dal.Delete_Data(pageobjectid, roleid);
        }
        // load only roal name
        public List<PageObjectRoleDTO> Page_ObjectRole_Name(int pageobjaccid, int roleid, string pagetypename, string pagename)
        {
            return dal.Page_ObjectRole_Name(pageobjaccid, roleid, pagetypename, pagename);
        }
        public List<PageObjectRoleDTO> Page_ObjectRole(int pageobjaccid, int roleid, string pagetypename, string pagename)
        {
            return dal.Page_ObjectRole(pageobjaccid, roleid, pagetypename, pagename);
        }
    }
}
