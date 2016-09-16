using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public class EmpTypeDTO
    {

        public int EmpTypeId { set; get; }
        public string TypeName { set; get; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }

    }
}
