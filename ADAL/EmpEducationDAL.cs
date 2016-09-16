using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using ADAL;
using Utility;
using ADTO;
using DAL;

namespace ADAL
{
    public class EmpEducationDAL
    {
        public void Add(EmpEducationDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                EmpEducation gur = new EmpEducation();
                container.EmpEducations.AddObject((EmpEducation)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }
        public void Edit(EmpEducationDTO EduDTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new EmpEducation();
                Comp = container.EmpEducations  .FirstOrDefault(o => o.EduId.Equals(EduDTO.EduId));
                //  Comp = container.EmpEducations  .FirstOrDefault(o => o.EmpId.Equals(EduDTO.EmpId));
                //  Comp.EmpId = EduDTO.EmpId;
                // Comp.EduId = EduDTO.EduId;
                Comp.Board = EduDTO.Board;
                Comp.UpdateBy = EduDTO.UpdateBy;
                Comp.Updatedate = EduDTO.Updatedate;
                Comp.Cgpa = EduDTO.Cgpa;
                Comp.Division = EduDTO.Division;
                Comp.Eximination = EduDTO.Eximination;
                Comp.InstituteName = EduDTO.InstituteName;
                Comp.PassingYear = EduDTO.PassingYear;          //problem can be occur
                Comp.ResultType = EduDTO.ResultType;
                Comp.Note = EduDTO.Note;

                Comp = (EmpEducation)DTOMapper.DTOObjectConverter(EduDTO, Comp);

                container.SaveChanges();
            }
        }


        public List<EmpEducationDTO> LoadEmpEducationInfo_modified(int empid, int eduid, string Deptname, string pname, string designation, string mobile)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.EmpEducations  
                            join emp in Container.Employees on s.EmpId equals emp.EmpId
                            join designa in Container.EmpSpecialists on emp.EmpSpecilistId equals designa.EmpSpecilistId
                            join dept in Container.EmpTypes on emp.EmpTypeId equals dept.EmpTypeId
                            select new { s, emp, dept, designa };

                if (eduid != 0)
                    query = query.Where(c => c.s.EduId.Equals(eduid));
                if (empid != 0)
                    query = query.Where(c => c.emp.EmpId.Equals(empid));

                if (!string.IsNullOrEmpty(Deptname))
                    query = query.Where(c => c.emp.EmpType.TypeName.Contains(Deptname));

                if (!string.IsNullOrEmpty(pname))
                    query = query.Where(c => c.emp.EmpName.Contains(pname));


                if (!string.IsNullOrEmpty(designation))
                    query = query.Where(c => c.designa.Specialist.Contains(designation));

                if (!string.IsNullOrEmpty(mobile))
                    query = query.Where(c => c.emp.Mobile1.Contains(mobile) || c.emp.Mobile2.Contains(mobile));

                var result = (from o in query
                              where o.s.EduId == o.s.EduId
                              orderby o.s.EduId descending
                              select new EmpEducationDTO
                              {
                                  // EmpId = o.emp.EmpId,
                                  //   EmpId=o.s.PayEmpBasicInfo.EmpId,
                                  EmpId = o.emp.EmpId,
                                  EmpName = o.emp.EmpName,
                                  Mobile1 = o.emp.Mobile1,
                                  Mobile2 = o.emp.Mobile2,
                                  EmpTypeId = o.dept.EmpTypeId,
                                  EmpTypeName = o.dept.TypeName,
                                  EmpSpecilistId = o.designa.EmpSpecilistId,
                                  EmpSepicilistName = o.designa.Specialist,
                                  Eximination = o.s.Eximination,
                                  Board = o.s.Board,
                                  InstituteName = o.s.InstituteName,
                                  ResultType = o.s.ResultType,
                                  PassingYear = o.s.PassingYear,
                                  Division = o.s.Division,
                                  EduId = o.s.EduId
                              }).ToList<EmpEducationDTO>();
                return result;
            }
        }

        public List<EmpEducationDTO> ShowEducationInfo_ForUpdate(int eduid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.EmpEducations  
                            select new { s };

                if (eduid != 0)
                    query = query.Where(c => c.s.EduId.Equals(eduid));

                var result = from o in query

                             select new EmpEducationDTO
                             {
                                 EmpId = o.s.Employee.EmpId,
                                 Eximination = o.s.Eximination,
                                 Board = o.s.Board,
                                 InstituteName = o.s.InstituteName,
                                 ResultType = o.s.ResultType,
                                 PassingYear = o.s.PassingYear,
                                 Division = o.s.Division,
                                 EduId = o.s.EduId

                             };
                return result.ToList<EmpEducationDTO>();
            }
        }

        // load emp name  //////
        public List<EmpBasicInfoDTO> LoadEmpName_Train(int spcilistid)
        {
            using (var Container = new InventoryContainer())
            {
                var data = (from o in Container.Employees

                            where o.EmpSpecialist.EmpSpecilistId.Equals(spcilistid) && o.TariningStatus.Equals("1")
                            select new EmpBasicInfoDTO
                            {
                                EmpId = o.EmpId ,
                                EmpName = o.EmpName ,
                                EmpSpecilistId = o.EmpSpecialist.EmpSpecilistId

                            }

                       ).ToList<EmpBasicInfoDTO>();
                return data;
            }
        }

        public List<EmpBasicInfoDTO> LoadEmpName_Edu(int spcilistid)
        {
            using (var Container = new InventoryContainer())
            {
                var data = (from o in Container.Employees

                            where o.EmpSpecialist.EmpSpecilistId.Equals(spcilistid) && o.EduStatus.Equals("1")
                            select new EmpBasicInfoDTO
                            {
                                EmpId = o.EmpId,
                                EmpName = o.EmpName,
                                EmpSpecilistId = o.EmpSpecialist.EmpSpecilistId

                            }

                       ).ToList<EmpBasicInfoDTO>();
                return data;
            }
        }

        public List<EmpBasicInfoDTO> LoadEmpName_Discount(int emptypeid, int spcilistid)
        {
            using (var Container = new InventoryContainer())
            {
                var data = (from o in Container.Employees

                            where o.EmpType.EmpTypeId.Equals(emptypeid)&&  o.EmpSpecialist.EmpSpecilistId.Equals(spcilistid) && o.DiscountStatus.Equals("1")
                            select new EmpBasicInfoDTO
                            {
                                EmpId = o.EmpId,
                                EmpName = o.EmpName,
                                EmpSpecilistId = o.EmpSpecialist.EmpSpecilistId

                            }

                       ).ToList<EmpBasicInfoDTO>();
                return data;
            }
        }

        public List<EmpBasicInfoDTO> LoadEmpName_Discount_EmpPopUp(int emptypeid, int spcilistid)
        {
            using (var Container = new InventoryContainer())
            {
                var data = (from o in Container.Employees

                            where o.EmpType.EmpTypeId.Equals(emptypeid) && o.EmpSpecialist.EmpSpecilistId.Equals(spcilistid) 
                            select new EmpBasicInfoDTO
                            {
                                EmpId = o.EmpId,
                                EmpName = o.EmpName,
                                EmpSpecilistId = o.EmpSpecialist.EmpSpecilistId

                            }

                       ).ToList<EmpBasicInfoDTO>();
                return data;
            }
        }
        

        public List<EmpBasicInfoDTO> GetALLOtherInfo(int deptid, int designationid, int empid)
        {

            using (var Container = new InventoryContainer())
            {
                var query =	//joins
              from r in Container.Employees
              join dept in Container.EmpTypes on r.EmpTypeId equals dept.EmpTypeId
              join designation in Container.EmpSpecialists on r.EmpSpecilistId equals designation.EmpSpecilistId


              select new { r, dept, designation };


                if (deptid != 0)
                    query = query.Where(c => c.dept.EmpTypeId.Equals(deptid));

                if (designationid != 0)
                    query = query.Where(c => c.designation.EmpSpecilistId.Equals(designationid));
                if (empid != 0)
                    query = query.Where(c => c.r.EmpId.Equals(empid));
                var result =
           from o in query
           orderby o.r.EmpId descending
           select new EmpBasicInfoDTO
           {

               CreateDate = o.r.CreateDate,
               EmpId = o.r.EmpId,
               EmpTypeId = o.dept.EmpTypeId,
               EmptypeName = o.dept.TypeName,
               EmpSpecilistId = o.designation.EmpSpecilistId,
               SpecilistName = o.designation.Specialist,
               Mobile1 = o.r.Mobile1,
               EmpName = o.r.EmpName

           };
                return result.ToList<EmpBasicInfoDTO>();

            }

        }
        // load emppopup all other info
        public List<EmpBasicInfoDTO> GetALLOtherInfo_EmpPopUp(int deptid, int designationid, int empid)
        {

            using (var Container = new InventoryContainer())
            {
                var query =	//joins
              from r in Container.Employees
              join dept in Container.EmpTypes on r.EmpTypeId equals dept.EmpTypeId
              join designation in Container.EmpSpecialists on r.EmpSpecilistId equals designation.EmpSpecilistId
            //  join discount in Container.PayDiscountComissionofPatinents on r.Id equals discount.EmpId

              select new { r, dept, designation };


                if (deptid != 0)
                    query = query.Where(c => c.dept.EmpTypeId.Equals(deptid));

                if (designationid != 0)
                    query = query.Where(c => c.designation.EmpSpecilistId.Equals(designationid));
                if (empid != 0)
                    query = query.Where(c => c.r.EmpId.Equals(empid));
                var result =
           from o in query
           orderby o.r.EmpId descending
           select new EmpBasicInfoDTO
           {

               CreateDate = o.r.CreateDate,
               EmpId = o.r.EmpId,
               EmpTypeId = o.dept.EmpTypeId,
               EmptypeName = o.dept.TypeName,
               EmpSpecilistId = o.designation.EmpSpecilistId,
               SpecilistName = o.designation.Specialist,
               Mobile1 = o.r.Mobile1,
               EmpName = o.r.EmpName,
               UserName=o.r.UserName,
             
           };
                return result.ToList<EmpBasicInfoDTO>();

            }

        }
    }
}