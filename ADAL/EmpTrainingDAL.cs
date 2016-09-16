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
    public class EmpTrainingDAL
    {

        public void Add(EmpTrainingDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                EmpTraining  gur = new EmpTraining   ();
                container.EmpTrainings.AddObject((EmpTraining   )DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }
        public void Edit(EmpTrainingDTO EduDTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new EmpTraining   ();
                Comp = container.EmpTrainings.FirstOrDefault(o => o.TrainingId.Equals(EduDTO.TrainingId));
                Comp.TrainingId = EduDTO.TrainingId;
                Comp.EmpId = EduDTO.EmpId;
                Comp.Duration = EduDTO.Duration;
                Comp.InstituteName = EduDTO.InstituteName;
                Comp.Location = EduDTO.Location;
                Comp.TopicsCovered = EduDTO.TopicsCovered;
                Comp.TrainingName = EduDTO.TrainingName;
                Comp.TrainingYear = EduDTO.TrainingYear;
                Comp.UpdateBy = EduDTO.UpdateBy;
                Comp.UpdateDate = EduDTO.UpdateDate;          //problem can be occur
                Comp = (EmpTraining   )DTOMapper.DTOObjectConverter(EduDTO, Comp);

                container.SaveChanges();
            }
        }

        public List<EmpBasicInfoDTO> LoadEmpName_training(int spcilistid)
        {
            using (var Container = new InventoryContainer())
            {
                var data = (from o in Container.Employees

                            where o.EmpSpecialist.EmpSpecilistId.Equals(spcilistid) && o.TariningStatus.Equals("1")
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

        public List<EmpTrainingDTO> ShowtrianingInfo_ForUpdate(int tarinid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.EmpTrainings
                            select new { s };

                if (tarinid != 0)
                    query = query.Where(c => c.s.TrainingId.Equals(tarinid));

                var result = from o in query

                             select new EmpTrainingDTO
                             {
                                 EmpId = o.s.Employee.EmpId,
                                 TrainingYear = o.s.TrainingYear,
                                 TrainingName = o.s.TrainingName,
                                 TopicsCovered = o.s.TopicsCovered,
                                 Location = o.s.Location,
                                 InstituteName = o.s.InstituteName,
                                 Duration = o.s.Duration,
                                 TrainingId = o.s.TrainingId

                             };
                return result.ToList<EmpTrainingDTO>();
            }
        }

        public List<EmpTrainingDTO> LoadEmpTrainingInfo_modified(int empid, int trinId, string Deptname, string pname, string designation, string mobile)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.EmpTrainings
                            join emp in Container.Employees on s.EmpId equals emp.EmpId
                            join designa in Container.EmpSpecialists on emp.EmpSpecilistId equals designa.EmpSpecilistId
                            join dept in Container.EmpTypes on emp.EmpTypeId equals dept.EmpTypeId
                            select new { s, emp, dept, designa };

                if (trinId != 0)
                    query = query.Where(c => c.s.TrainingId.Equals(trinId));
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
                              where o.s.TrainingId == o.s.TrainingId
                              orderby o.s.TrainingId descending
                              select new EmpTrainingDTO

                              {
                                  
                                  EmpId = o.emp.EmpId,
                                  EmpName = o.emp.EmpName,
                                  Mobile1 = o.emp.Mobile1,
                                  Mobile2 = o.emp.Mobile2,
                                  EmpTypeId = o.dept.EmpTypeId,
                                  EmpTypeName = o.dept.TypeName,
                                  EmpSpecilistId = o.designa.EmpSpecilistId,
                                  EmpSepicilistName = o.designa.Specialist,
                                  TrainingYear = o.s.TrainingYear,
                                  TrainingName = o.s.TrainingName,
                                  TopicsCovered = o.s.TopicsCovered,
                                  Location = o.s.Location,
                                  InstituteName = o.s.InstituteName,
                                  Duration = o.s.Duration,
                                  TrainingId = o.s.TrainingId
                              }).ToList<EmpTrainingDTO>();
                return result;
            }
        }
    }
}
