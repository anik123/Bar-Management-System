using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public class EmpSpcialistDTO
    {
        public int EmpSpecilistId { get; set; }
        public string Specialist { get; set; }
        public int EmpTypeId { get; set; }
        public string CreateBy { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        //for search
        public string TypeName { set; get; }



        public string Testvalue { get; set; }
       
        // for test purpose
        public string SpecilistName { get; set; }
    }
}
