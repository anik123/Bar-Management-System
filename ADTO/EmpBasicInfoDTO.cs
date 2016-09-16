using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public class EmpBasicInfoDTO
    {

        public int EmpId { get; set; }
        public string EmpName { get; set; }
        public string SurName { get; set; }
        public string Gender { get; set; }
        public DateTime? DOB { get; set; }
        public string Age { get; set; }
        public string Address { get; set; }
        public string Phone { get; set; }
        public string Mobile1 { get; set; }
        public string Mobile2 { get; set; }
        public string Email { get; set; }
        public DateTime? JoinDate { get; set; }
        public string NationalID { get; set; }
        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
        public string MotherName { get; set; }
        public string FatherName { get; set; }
        public string PermanentAdd { get; set; }
        public string Nationality { get; set; }
        public string Merital { get; set; }
        public string Religion { get; set; }

        public string ImageName { get; set; }
        public int? BrProId { get; set; }
        public string BrProName { get; set; }
        public int EmpTypeId { get; set; }
        public int EmpSpecilistId { get; set; }
        public string JobType { get; set; }
        public string JobStatus { get; set; }
        public string ReferenceBy { get; set; }
        public string RefContactNum { set; get; }
        public string FamilyContactNum { get; set; }
        public string OtizmStatus { get; set; }
        public string OtizmType { set; get; }
        public string Password { get; set; }
        public string UserName { get; set; }

        // for image load in gv
        public int FileNo { get; set; }
        public string FilePath { get; set; }
        public string FileSize { get; set; }
        public string FileName { get; set; }
        // load purpose
        public string SpecilistName { get; set; }
        public string EmptypeName { get; set; }
        public string Specialist { get; set; }

        // status flag
        public string EduStatus { get; set; }
        public string TariningStatus { get; set; }
        public string ExperienceStatus { get; set; }
        public string SalaryStatus { get; set; }
        public string LocationStatus { get; set; }
        public string DiscountStatus { get; set; }
        // for salary payment 

        public int BasicSalId { get; set; }
        public double? TotalSal { get; set; }

        //load for emp attendance 

        public int WorkShiftId { get; set; }
        public string StartTime { get; set; }
        public string Endtime { get; set; }
        public int LocationId { get; set; }

        // load popup emp
        public int? DiscountId { get; set; }
        public string DiscountType { get; set; }
        public double? DiscountPercentage { get; set; }
        public double? CommissionPercentage { get; set; }

     

    }
}
