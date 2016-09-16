using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace PDTO
{
    public class PageObjectDTO
    {
        public int PageObjectId { get; set; }
        public string PageTypeName { get; set; }
        public string PageName { get; set; }
        public string PagePath { get; set; }
        public string PageMethodeName { get; set; }
    }
}
