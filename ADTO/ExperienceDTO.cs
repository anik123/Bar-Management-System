using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public class ExperienceDTO
    {
        public int ExperienceId { get; set; }
        public int? EmpId { get; set; }
        public string Disignation { get; set; }
        public DateTime? FromDate { get; set; }
        public DateTime? ToDate { get; set; }
        public string OrganizationName { get; set; }
        public string Responsibility { get; set; }
        public string Year { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }

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