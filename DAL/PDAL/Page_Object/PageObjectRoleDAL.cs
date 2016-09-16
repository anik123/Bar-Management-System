using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDTO;
using DAL;
using Utility;

namespace PDAL.Page_Object
{
    public class PageObjectRoleDAL
    {
        public void Add(PageObjectRoleDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                PageObjectRole gur = new PageObjectRole();
                container.PageObjectRoles.AddObject((PageObjectRole)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(PageObjectRoleDTO EduDTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new PageObjectRole();
                Comp = container.PageObjectRoles.FirstOrDefault(o => o.PageObjAccId.Equals(EduDTO.PageObjAccId));

                Comp.PageObjAccId = EduDTO.PageObjAccId;
                Comp.RoleId = EduDTO.RoleId;
                Comp.PageObjectId = EduDTO.PageObjectId;
                Comp.UpdateBy = EduDTO.UpdateBy;
                Comp.UpdateDate = EduDTO.UpdateDate;

                Comp = (PageObjectRole)DTOMapper.DTOObjectConverter(EduDTO, Comp);

                container.SaveChanges();
            }
        }

        // delete data
        public void Delete_Data(int pageobjectid, int roleid)
        {
            using (var Container = new InventoryContainer())
            {
                var delete = new PageObjectRole();
                delete = Container.PageObjectRoles.FirstOrDefault(o => o.PageObjectId.Equals(pageobjectid) && o.RoleId.Equals(roleid));

                Container.PageObjectRoles.DeleteObject(delete);
                Container.SaveChanges();
            }

            //CustomerDataContext ctx = new CustomerDataContext("connection string");

            //Customer cust = ctx.Customers.Where(c = c.CustomerID == "ALFKI").Single();
            //ctx.Customers.DeleteOnSubmit(cust);
            //ctx.SubmitChanges();
        }

        public List<PageObjectRoleDTO> Page_ObjectRole(int pageobjaccid, int roleid, string pagetypename, string pagename)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PageObjectRoles
                            join pobj in Container.PageObjects on s.PageObjectId equals pobj.PageObjectId
                            select new { s, pobj };

                if (pageobjaccid != 0)
                    query = query.Where(c => c.s.PageObjAccId.Equals(pageobjaccid));
                if (roleid != 0)
                    query = query.Where(c => c.s.PayRole.RoleId.Equals(roleid));

                if (!string.IsNullOrEmpty(pagetypename))
                    query = query.Where(c => c.pobj.PageTypeName.Contains(pagetypename));

                if (!string.IsNullOrEmpty(pagename))
                    query = query.Where(c => c.pobj.PageName.Contains(pagename));


                var result = (from o in query

                              select new PageObjectRoleDTO
                              {
                                  PageObjAccId = o.s.PageObjAccId,
                                  RoleId = o.s.PayRole.RoleId,
                                  RoleName = o.s.PayRole.RoleName,
                                  PageObjectId = o.s.PageObjectId,
                                  PageTypeName = o.pobj.PageTypeName,
                                  PageName = o.pobj.PageName,
                                  PageMethodeName = o.pobj.PageMethodeName,
                                  PagePath = o.pobj.PagePath,
                                  CreateBy = o.s.CreateBy,
                                  CreateDate = o.s.CreateDate
                              }).ToList<PageObjectRoleDTO>();

                return result;
            }
        }
        // load only roal name
        public List<PageObjectRoleDTO> Page_ObjectRole_Name(int pageobjaccid, int roleid, string pagetypename, string pagename)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PageObjectRoles
                            join pobj in Container.PageObjects on s.PageObjectId equals pobj.PageObjectId
                            select new { s, pobj };

                if (pageobjaccid != 0)
                    query = query.Where(c => c.s.PageObjAccId.Equals(pageobjaccid));
                if (roleid != 0)
                    query = query.Where(c => c.s.PayRole.RoleId.Equals(roleid));

                if (!string.IsNullOrEmpty(pagetypename))
                    query = query.Where(c => c.pobj.PageTypeName.Contains(pagetypename));

                if (!string.IsNullOrEmpty(pagename))
                    query = query.Where(c => c.pobj.PageName.Contains(pagename));


                var result = (from o in query

                              select new PageObjectRoleDTO
                              {
                                  RoleId = o.s.PayRole.RoleId,
                                  RoleName = o.s.PayRole.RoleName,

                              }).Distinct().ToList<PageObjectRoleDTO>();

                return result;
            }
        }
    }
}
