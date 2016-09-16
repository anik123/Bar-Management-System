using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public class EmpEducationDTO
    {
        public int EduId { get; set; }
        public int? EmpId { get; set; }
        public string ResultType { get; set; }
        public string Division { get; set; }
        public string Cgpa { get; set; }
        public string InstituteName { get; set; }
        public string Board { get; set; }
        public string Eximination { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? Updatedate { get; set; }
        public string UpdateBy { get; set; }
        public string PassingYear { get; set; }
        public string Note { get; set; }

        //for load rpt

        public string EmpSepicilistName { get; set; }
        public int? EmpSpecilistId { get; set; }
        public string Mobile2 { get; set; }
        public string EmpTypeName { get; set; }
        public int? EmpTypeId { get; set; }
        public string Mobile1 { get; set; }
        public string EmpName { get; set; }


    }
}
