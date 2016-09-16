using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDTO;
using DAL;
using Utility;
namespace PDAL.Page_Object
{
    public class PageObjectDAL
    {
        public void Add(PageObjectDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                PageObject gur = new PageObject();
                container.PageObjects.AddObject((PageObject)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(PageObjectDTO EduDTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new PageObject();
                Comp = container.PageObjects.FirstOrDefault(o => o.PageObjectId.Equals(EduDTO.PageObjectId));

                Comp.PageObjectId = EduDTO.PageObjectId;
                Comp.PageTypeName = EduDTO.PageTypeName;
                Comp.PageName = EduDTO.PageName;
                Comp.PagePath = EduDTO.PagePath;
                Comp.PageMethodeName = EduDTO.PageMethodeName;
                Comp = (PageObject)DTOMapper.DTOObjectConverter(EduDTO, Comp);

                container.SaveChanges();
            }
        }

        public List<PageObjectDTO> LoadPageObject(int pageobjid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PageObjects
                            select new { s };
                if (pageobjid != 0)
                    query = query.Where(c => c.s.PageObjectId.Equals(pageobjid));
                var result = (from o in query
                              orderby o.s.PageObjectId descending
                              select new PageObjectDTO
                              {
                                  PageObjectId = o.s.PageObjectId,
                                  PageTypeName = o.s.PageTypeName,
                                  PagePath = o.s.PagePath,
                                  PageMethodeName = o.s.PageMethodeName,
                                  PageName = o.s.PageName,
                              }).ToList<PageObjectDTO>();

                return result;
            }
        }
        public List<PageObjectDTO> LoadPageObject_PageTypeName()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PageObjects
                            select new { s };
                var result = (from o in query
                              orderby o.s.PageObjectId descending
                              select new PageObjectDTO
                              {

                                  PageTypeName = o.s.PageTypeName,

                              }).Distinct().ToList<PageObjectDTO>();

                return result;
            }
        }
        public List<PageObjectDTO> LoadPageObject_PageTypeName_PageName(string pagetypename)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PageObjects
                            select new { s };

                if (!string.IsNullOrEmpty(pagetypename))
                    query = query.Where(c => c.s.PageTypeName.Contains(pagetypename));

                var result = (from o in query
                              orderby o.s.PageObjectId descending
                              select new PageObjectDTO
                              {

                                  PageTypeName = o.s.PageTypeName,
                                  PageName = o.s.PageName,
                                  PageObjectId = o.s.PageObjectId

                              }).Distinct().ToList<PageObjectDTO>();

                return result;
            }
        }
    }
}
