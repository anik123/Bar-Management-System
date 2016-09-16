using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDAL.Page_Object;
using PDTO;

namespace PBLL.Page_ObjectBLL
{
    public class PageObjectBLL
    {
        PageObjectDAL Dal = new PageObjectDAL();
        public void Add(PageObjectDTO DTO)
        {
            Dal.Add(DTO);
        }
        public void Edit(PageObjectDTO EduDTO)
        {
            Dal.Edit(EduDTO);
        }
        public List<PageObjectDTO> LoadPageObject(int pageobjid)
        {
            return Dal.LoadPageObject(pageobjid);
        }

        public List<PageObjectDTO> LoadPageObject_PageTypeName()
        {
            return Dal.LoadPageObject_PageTypeName();
        }
        public List<PageObjectDTO> LoadPageObject_PageTypeName_PageName(string pagetypename)
        {
            return Dal.LoadPageObject_PageTypeName_PageName(pagetypename);
        }
    }
}
