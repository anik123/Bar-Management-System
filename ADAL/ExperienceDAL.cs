using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;


using ADAL;
using Utility;
using DAL;

namespace ADAL
{
    public class ExperienceDAL
    {
        public void Add(ExperienceDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                EmpExperienceInfo gur = new EmpExperienceInfo();
                container.EmpExperienceInfoes.AddObject((EmpExperienceInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }
        public void Edit(ExperienceDTO EduDTO)
        {
           using (var container = new InventoryContainer())
            {
                var Comp = new EmpExperienceInfo();
                Comp = container. EmpExperienceInfoes.FirstOrDefault(o => o.ExperienceId.Equals(EduDTO.ExperienceId));
                Comp.ExperienceId = EduDTO.ExperienceId;
                Comp.EmpId = EduDTO.EmpId;
                Comp.Year = EduDTO.Year;
                Comp.UpdateBy = EduDTO.UpdateBy;
                Comp.UpdateDate = EduDTO.UpdateDate;
                Comp.ToDate = EduDTO.ToDate;
                Comp.FromDate = EduDTO.FromDate;
                Comp.Disignation = EduDTO.Disignation;
                Comp.Responsibility = EduDTO.Responsibility;
                Comp.OrganizationName = EduDTO.OrganizationName;          //problem can be occur
                Comp = (EmpExperienceInfo)DTOMapper.DTOObjectConverter(EduDTO, Comp);

                container.SaveChanges();
            }
        }
        public List<EmpBasicInfoDTO> LoadEmpName_Experience(int spcilistid)
        {
            using (var Container = new InventoryContainer())
            {
                var data = (from o in Container.Employees

                            where o.EmpSpecialist.EmpSpecilistId.Equals(spcilistid) && o.ExperienceStatus.Equals("1")
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

       
        public List<ExperienceDTO> LoadEmpExperienceInfo_new_update(int expid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container. EmpExperienceInfoes
                            select new { s };

                if (expid != 0)
                    query = query.Where(c => c.s.ExperienceId.Equals(expid));

                var result = from o in query

                             select new ExperienceDTO
                             {
                                 EmpId = o.s.Employee.EmpId,
                                 Disignation = o.s.Disignation,
                                 OrganizationName = o.s.OrganizationName,
                                 Responsibility = o.s.Responsibility,
                                 FromDate = o.s.FromDate,
                                 ToDate = o.s.ToDate,
                                 Year = o.s.Year,
                                 ExperienceId = o.s.ExperienceId
                             };
                return result.ToList<ExperienceDTO>();
            }
        }

        public List<ExperienceDTO> LoadEmpExperienceInfo_modified(int empid, int expid, string Deptname, string pname, string designation, string mobile)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container. EmpExperienceInfoes
                            join emp in Container.Employees on s.EmpId equals emp.EmpId
                            join designa in Container.EmpSpecialists on emp.EmpSpecilistId equals designa.EmpSpecilistId
                            join dept in Container.EmpTypes on emp.EmpTypeId equals dept.EmpTypeId
                            select new { s, emp, dept, designa };

                if (expid != 0)
                    query = query.Where(c => c.s.ExperienceId.Equals(expid));
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
                              where o.s.ExperienceId == o.s.ExperienceId
                         //   where o.emp.Id==o.emp.Id
                            orderby o.s.ExperienceId descending
                              select new ExperienceDTO

                              {

                                  EmpId = o.emp.EmpId,
                                  EmpName = o.emp.EmpName,
                                  Mobile1 = o.emp.Mobile1,
                                  Mobile2 = o.emp.Mobile2,
                                  EmpTypeId = o.dept.EmpTypeId,
                                  EmpTypeName = o.dept.TypeName,
                                  EmpSpecilistId = o.designa.EmpSpecilistId,
                                  EmpSepicilistName = o.designa.Specialist,
                                  Disignation = o.s.Disignation,
                                  OrganizationName = o.s.OrganizationName,
                                  Responsibility = o.s.Responsibility,
                                  FromDate = o.s.FromDate,
                                  ToDate = o.s.ToDate,
                                  Year = o.s.Year,
                                  ExperienceId = o.s.ExperienceId
                              }).ToList<ExperienceDTO>();
                return result;
            }
        }


    }
}
