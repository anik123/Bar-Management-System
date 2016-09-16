using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public class EmpTrainingDTO
    {
        public int TrainingId { get; set; }
        public int? EmpId { get; set; }
        public string TrainingName { get; set; }
        public string TopicsCovered { get; set; }
        public string InstituteName { get; set; }
        public string Location { get; set; }
        public string TrainingYear { get; set; }
        public string Duration { get; set; }
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
