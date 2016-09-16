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
    public class EmpBasicInfoDAL
    {
        public void Add(EmpBasicInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                Employee gur = new Employee();
                container.Employees.AddObject((Employee)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(EmpBasicInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new Employee();
                Comp = container.Employees.FirstOrDefault(o => o.EmpId.Equals(DTO.EmpId));
                Comp.EmpId = DTO.EmpId;
                Comp.BrProId = DTO.BrProId;
                Comp.EmpTypeId = DTO.EmpTypeId;
                Comp.EmpSpecilistId = DTO.EmpSpecilistId;
                Comp.UpdateBy = DTO.UpdateBy;
                Comp.UpdateDate = DTO.UpdateDate;
                Comp.DOB = DTO.DOB;
                Comp.Email = DTO.Email;
                Comp.FatherName = DTO.FatherName;
                Comp.ImageName = DTO.ImageName;
                Comp.JobType = DTO.JobType;
                Comp.JoinDate = DTO.JoinDate;
                Comp.JobStatus = DTO.JobStatus;
                Comp.Merital = DTO.Merital;
                Comp.Mobile1 = DTO.Mobile1;
                Comp.Mobile2 = DTO.Mobile2;
                Comp.MotherName = DTO.MotherName;
                Comp.Nationality = DTO.Nationality;
                Comp.Phone = DTO.Phone;
                Comp.PermanentAdd = DTO.PermanentAdd;
                Comp.Address = DTO.Address;
                Comp.Religion = DTO.Religion;
                Comp.Gender = DTO.Gender;
                Comp.MotherName = DTO.MotherName;
                Comp.OtizmStatus = DTO.OtizmStatus;
                Comp.OtizmType = DTO.OtizmType;
                Comp.ReferenceBy = DTO.ReferenceBy;
                Comp.RefContactNum = DTO.RefContactNum;
                Comp.SurName = DTO.SurName;
                Comp.Age = DTO.Age;
                Comp.EduStatus = DTO.EduStatus;
                Comp.EmpName = DTO.EmpName;
                Comp.FamilyContactNum = DTO.FamilyContactNum;
                Comp.NationalID = DTO.NationalID;
                Comp.UserName = DTO.UserName;
                Comp.Password = DTO.Password;
                Comp = (Employee)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        // Edit password
        public void Edit_Password(EmpBasicInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new Employee();
                Comp = container.Employees.FirstOrDefault(o => o.EmpId.Equals(DTO.EmpId));
                Comp.EmpId = DTO.EmpId;
                Comp.Password = DTO.Password;
                Comp = (Employee)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        public List<EmpBasicInfoDTO> LoadEmpBasic(int empid, string empname, string moblie, string username, string SurName)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Employees
                            join specilist in Container.EmpSpecialists on s.EmpSpecilistId equals specilist.EmpSpecilistId
                            join emptype in Container.EmpTypes on specilist.EmpTypeId equals emptype.EmpTypeId

                            select new { s, emptype, specilist };

                if (empid != 0)
                    query = query.Where(c => c.s.EmpId.Equals(empid));

                if (!string.IsNullOrEmpty(empname))
                    query = query.Where(c => c.s.EmpName.Contains(empname));

                if (!string.IsNullOrEmpty(moblie))
                    query = query.Where(c => c.s.Mobile1.Contains(moblie) || c.s.Mobile2.Contains(moblie));

                if (!string.IsNullOrEmpty(username))
                    query = query.Where(c => c.s.UserName.Contains(username));

                if (!string.IsNullOrEmpty(SurName))
                    query = query.Where(c => c.s.SurName.Contains(SurName));


                var result = from o in query
                             // where o.s.EmpId == o.s.EmpId
                             orderby o.s.EmpId descending
                             select new EmpBasicInfoDTO
                             {

                                 EmpId = o.s.EmpId,
                                 EduStatus = o.s.EduStatus,
                                 Mobile1 = o.s.Mobile1,
                                 EmpName = o.s.EmpName,
                                 Email = o.s.Email,
                                 //EmpSpecilistId = o.s.EmpSpecialist.Id,
                                 //SpecilistName = o.s.EmpSpecialist.Specialist,

                                 EmpSpecilistId = o.specilist.EmpSpecilistId,
                                 SpecilistName = o.specilist.Specialist,
                                 Specialist = o.specilist.Specialist,

                                 BrProId = o.s.BrProId,
                                 BrProName=o.s.InvenBranchProfile.BrProName,
                                 EmpTypeId = o.emptype.EmpTypeId,
                                 EmptypeName = o.emptype.TypeName,
                                 DOB = o.s.DOB,
                                 FatherName = o.s.FatherName,
                                 SurName = o.s.SurName,
                                 FileName = o.s.ImageName,
                                 JobStatus = o.s.JobStatus,
                                 JobType = o.s.JobType,
                                 JoinDate = o.s.JoinDate,
                                 Address = o.s.Address,
                                 Merital = o.s.Merital,
                                 Mobile2 = o.s.Mobile2,
                                 MotherName = o.s.MotherName,
                                 Age = o.s.Age,
                                 FamilyContactNum = o.s.FamilyContactNum,
                                 Gender = o.s.Gender,
                                 NationalID = o.s.NationalID,
                                 OtizmStatus = o.s.OtizmStatus,
                                 OtizmType = o.s.OtizmType,
                                 Password = o.s.Password,
                                 RefContactNum = o.s.RefContactNum,
                                 ReferenceBy = o.s.ReferenceBy,
                                 UserName = o.s.UserName,
                                 Nationality = o.s.Nationality,
                                 PermanentAdd = o.s.PermanentAdd,
                                 Phone = o.s.Phone,
                                 Religion = o.s.Religion,
                                




                             };
                return result.ToList<EmpBasicInfoDTO>();
            }
        }
        // laod emp basic for Eucation page  LoadEmpBasic_Tarining
        public List<EmpBasicInfoDTO> LoadEmpBasic_EduPage(int empid, string empname, string moblie, string username, string SurName)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Employees
                            join specilist in Container.EmpSpecialists on s.EmpSpecilistId equals specilist.EmpSpecilistId
                            join emptype in Container.EmpTypes on s.EmpTypeId equals emptype.EmpTypeId
                            select new { s, emptype, specilist };


                if (empid != 0)
                    query = query.Where(c => c.s.EmpId.Equals(empid));

                if (!string.IsNullOrEmpty(empname))
                    query = query.Where(c => c.s.EmpName.Contains(empname));

                if (!string.IsNullOrEmpty(moblie))
                    query = query.Where(c => c.s.Mobile1.Contains(moblie) || c.s.Mobile2.Contains(moblie));

                if (!string.IsNullOrEmpty(username))
                    query = query.Where(c => c.s.UserName.Contains(username));

                if (!string.IsNullOrEmpty(SurName))
                    query = query.Where(c => c.s.SurName.Contains(SurName));


                var result = from o in query

                             where o.s.EduStatus == "2"
                             orderby o.s.EmpId descending
                             select new EmpBasicInfoDTO
                             {
                                 EmpId = o.s.EmpId,
                                 EduStatus = o.s.EduStatus,
                                 Mobile1 = o.s.Mobile1,
                                 EmpName = o.s.EmpName,
                                 Email = o.s.Email,
                                 EmpSpecilistId = o.s.EmpSpecialist.EmpSpecilistId,
                                 SpecilistName = o.s.EmpSpecialist.Specialist,
                                 EmpTypeId = o.emptype.EmpTypeId,
                                 EmptypeName = o.emptype.TypeName,

                                 DOB = o.s.DOB,
                                 FatherName = o.s.FatherName,
                                 SurName = o.s.SurName,
                                 // Image = o.s.Image,
                                 JobStatus = o.s.JobStatus,
                                 JobType = o.s.JobType,
                                 JoinDate = o.s.JoinDate,
                                 Address = o.s.Address,
                                 Merital = o.s.Merital,
                                 Mobile2 = o.s.Mobile2,
                                 MotherName = o.s.MotherName,
                                 Age = o.s.Age,
                                 ImageName = o.s.ImageName,
                                 FamilyContactNum = o.s.FamilyContactNum,
                                 Gender = o.s.Gender,
                                 NationalID = o.s.NationalID,
                                 OtizmStatus = o.s.OtizmStatus,
                                 OtizmType = o.s.OtizmType,
                                 Password = o.s.Password,
                                 RefContactNum = o.s.RefContactNum,
                                 ReferenceBy = o.s.ReferenceBy,
                                 UserName = o.s.UserName,
                                 Nationality = o.s.Nationality,
                                 PermanentAdd = o.s.PermanentAdd,
                                 Phone = o.s.Phone,
                                 Religion = o.s.Religion,


                             };
                return result.ToList<EmpBasicInfoDTO>();
            }
        }

        // laod emp basic for Eucation page  LoadEmpBasic_Discount
        public List<EmpBasicInfoDTO> LoadEmpBasic_Discount(int empid, string empname, string moblie, string username, string SurName)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Employees
                            join specilist in Container.EmpSpecialists on s.EmpSpecilistId equals specilist.EmpSpecilistId
                            join emptype in Container.EmpTypes on s.EmpTypeId equals emptype.EmpTypeId
                            select new { s, emptype, specilist };


                if (empid != 0)
                    query = query.Where(c => c.s.EmpId.Equals(empid));

                if (!string.IsNullOrEmpty(empname))
                    query = query.Where(c => c.s.EmpName.Contains(empname));

                if (!string.IsNullOrEmpty(moblie))
                    query = query.Where(c => c.s.Mobile1.Contains(moblie) || c.s.Mobile2.Contains(moblie));

                if (!string.IsNullOrEmpty(username))
                    query = query.Where(c => c.s.UserName.Contains(username));

                if (!string.IsNullOrEmpty(SurName))
                    query = query.Where(c => c.s.SurName.Contains(SurName));


                var result = from o in query

                             where o.s.DiscountStatus == "2"
                             orderby o.s.EmpId descending
                             select new EmpBasicInfoDTO
                             {
                                 EmpId = o.s.EmpId,
                                 EduStatus = o.s.EduStatus,
                                 Mobile1 = o.s.Mobile1,
                                 EmpName = o.s.EmpName,
                                 Email = o.s.Email,
                                 EmpSpecilistId = o.s.EmpSpecialist.EmpSpecilistId,
                                 SpecilistName = o.s.EmpSpecialist.Specialist,
                                 EmpTypeId = o.emptype.EmpTypeId,
                                 EmptypeName = o.emptype.TypeName,

                                 DOB = o.s.DOB,
                                 FatherName = o.s.FatherName,
                                 SurName = o.s.SurName,
                                 //   Image = o.s.Image,
                                 JobStatus = o.s.JobStatus,
                                 JobType = o.s.JobType,
                                 JoinDate = o.s.JoinDate,
                                 Address = o.s.Address,
                                 Merital = o.s.Merital,
                                 Mobile2 = o.s.Mobile2,
                                 ImageName = o.s.ImageName,
                                 MotherName = o.s.MotherName,
                                 Age = o.s.Age,
                                 FamilyContactNum = o.s.FamilyContactNum,
                                 Gender = o.s.Gender,
                                 NationalID = o.s.NationalID,
                                 OtizmStatus = o.s.OtizmStatus,
                                 OtizmType = o.s.OtizmType,
                                 Password = o.s.Password,
                                 RefContactNum = o.s.RefContactNum,
                                 ReferenceBy = o.s.ReferenceBy,
                                 UserName = o.s.UserName,
                                 Nationality = o.s.Nationality,
                                 PermanentAdd = o.s.PermanentAdd,
                                 Phone = o.s.Phone,
                                 Religion = o.s.Religion,
                                 DiscountStatus = o.s.DiscountStatus

                             };
                return result.ToList<EmpBasicInfoDTO>();
            }
        }


        public List<EmpBasicInfoDTO> LoadEmpBasic_Tarining(int empid, string empname, string moblie, string username, string SurName)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Employees
                            join specilist in Container.EmpSpecialists on s.EmpSpecilistId equals specilist.EmpSpecilistId
                            join emptype in Container.EmpTypes on s.EmpTypeId equals emptype.EmpTypeId
                            select new { s, emptype, specilist };


                if (empid != 0)
                    query = query.Where(c => c.s.EmpId.Equals(empid));

                if (!string.IsNullOrEmpty(empname))
                    query = query.Where(c => c.s.EmpName.Contains(empname));

                if (!string.IsNullOrEmpty(moblie))
                    query = query.Where(c => c.s.Mobile1.Contains(moblie) || c.s.Mobile2.Contains(moblie));

                if (!string.IsNullOrEmpty(username))
                    query = query.Where(c => c.s.UserName.Contains(username));

                if (!string.IsNullOrEmpty(SurName))
                    query = query.Where(c => c.s.SurName.Contains(SurName));


                var result = from o in query

                             where o.s.TariningStatus == "2"
                             orderby o.s.EmpId descending
                             select new EmpBasicInfoDTO
                             {
                                 EmpId = o.s.EmpId,
                                 EduStatus = o.s.EduStatus,
                                 Mobile1 = o.s.Mobile1,
                                 EmpName = o.s.EmpName,
                                 Email = o.s.Email,
                                 EmpSpecilistId = o.s.EmpSpecialist.EmpSpecilistId,
                                 SpecilistName = o.s.EmpSpecialist.Specialist,
                                 EmpTypeId = o.emptype.EmpTypeId,
                                 EmptypeName = o.emptype.TypeName,

                                 DOB = o.s.DOB,
                                 FatherName = o.s.FatherName,
                                 SurName = o.s.SurName,
                                 // Image = o.s.Image,
                                 JobStatus = o.s.JobStatus,
                                 JobType = o.s.JobType,
                                 JoinDate = o.s.JoinDate,
                                 Address = o.s.Address,
                                 Merital = o.s.Merital,
                                 Mobile2 = o.s.Mobile2,
                                 MotherName = o.s.MotherName,
                                 ImageName = o.s.ImageName,
                                 Age = o.s.Age,
                                 FamilyContactNum = o.s.FamilyContactNum,
                                 Gender = o.s.Gender,
                                 NationalID = o.s.NationalID,
                                 OtizmStatus = o.s.OtizmStatus,
                                 OtizmType = o.s.OtizmType,
                                 Password = o.s.Password,
                                 RefContactNum = o.s.RefContactNum,
                                 ReferenceBy = o.s.ReferenceBy,
                                 UserName = o.s.UserName,
                                 Nationality = o.s.Nationality,
                                 PermanentAdd = o.s.PermanentAdd,
                                 Phone = o.s.Phone,
                                 Religion = o.s.Religion,


                             };
                return result.ToList<EmpBasicInfoDTO>();
            }
        }




        public List<EmpBasicInfoDTO> LoadEmpBasic_Experienceinfo(int empid, string empname, string moblie, string username, string SurName)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Employees
                            join specilist in Container.EmpSpecialists on s.EmpSpecilistId equals specilist.EmpSpecilistId
                            join emptype in Container.EmpTypes on s.EmpTypeId equals emptype.EmpTypeId
                            select new { s, emptype, specilist };


                if (empid != 0)
                    query = query.Where(c => c.s.EmpId.Equals(empid));

                if (!string.IsNullOrEmpty(empname))
                    query = query.Where(c => c.s.EmpName.Contains(empname));

                if (!string.IsNullOrEmpty(moblie))
                    query = query.Where(c => c.s.Mobile1.Contains(moblie) || c.s.Mobile2.Contains(moblie));

                if (!string.IsNullOrEmpty(username))
                    query = query.Where(c => c.s.UserName.Contains(username));

                if (!string.IsNullOrEmpty(SurName))
                    query = query.Where(c => c.s.SurName.Contains(SurName));


                var result = from o in query

                             where o.s.ExperienceStatus == "2"
                             orderby o.s.EmpId descending
                             select new EmpBasicInfoDTO
                             {
                                 EmpId = o.s.EmpId,
                                 EduStatus = o.s.EduStatus,
                                 Mobile1 = o.s.Mobile1,
                                 EmpName = o.s.EmpName,
                                 Email = o.s.Email,
                                 EmpSpecilistId = o.s.EmpSpecialist.EmpSpecilistId,
                                 SpecilistName = o.s.EmpSpecialist.Specialist,
                                 EmpTypeId = o.emptype.EmpTypeId,
                                 EmptypeName = o.emptype.TypeName,

                                 DOB = o.s.DOB,
                                 FatherName = o.s.FatherName,
                                 SurName = o.s.SurName,
                                 //Image = o.s.Image,
                                 JobStatus = o.s.JobStatus,
                                 JobType = o.s.JobType,
                                 JoinDate = o.s.JoinDate,
                                 Address = o.s.Address,
                                 Merital = o.s.Merital,
                                 Mobile2 = o.s.Mobile2,
                                 MotherName = o.s.MotherName,
                                 Age = o.s.Age,
                                 FamilyContactNum = o.s.FamilyContactNum,
                                 Gender = o.s.Gender,
                                 NationalID = o.s.NationalID,
                                 OtizmStatus = o.s.OtizmStatus,
                                 OtizmType = o.s.OtizmType,
                                 Password = o.s.Password,
                                 ImageName = o.s.ImageName,
                                 RefContactNum = o.s.RefContactNum,
                                 ReferenceBy = o.s.ReferenceBy,
                                 UserName = o.s.UserName,
                                 Nationality = o.s.Nationality,
                                 PermanentAdd = o.s.PermanentAdd,
                                 Phone = o.s.Phone,
                                 Religion = o.s.Religion,


                             };
                return result.ToList<EmpBasicInfoDTO>();
            }
        }

        // laod emp basic for Eucation page




        public List<EmpBasicInfoDTO> GetEmp_All_Status_Flag(int emptypeid, int spid, int empid)
        {
            List<EmpBasicInfoDTO> GetStatus = new List<EmpBasicInfoDTO>();
            using (var Container = new InventoryContainer())
            {
                var data = new List<EmpBasicInfoDTO>();
                data = (from emp in Container.Employees
                        where emp.EmpType.EmpTypeId.Equals(emptypeid) && emp.EmpSpecialist.EmpSpecilistId.Equals(spid) && emp.EmpId.Equals(empid)
                        select new EmpBasicInfoDTO
                        {
                            EmpId = emp.EmpId,
                            EduStatus = emp.EduStatus,
                            EmpTypeId = emp.EmpType.EmpTypeId,
                            EmpSpecilistId = emp.EmpSpecialist.EmpSpecilistId,
                            //   TariningStatus = emp.TariningStatus


                        }).ToList<EmpBasicInfoDTO>();
                GetStatus.AddRange(data);
                return GetStatus;
            }
        }

        public List<EmpBasicInfoDTO> GetEmp_trining_Status_Flag(int emptypeid, int spid, int empid)
        {
            List<EmpBasicInfoDTO> GetStatus = new List<EmpBasicInfoDTO>();
            using (var Container = new InventoryContainer())
            {
                var data = new List<EmpBasicInfoDTO>();
                data = (from emp in Container.Employees
                        where emp.EmpType.EmpTypeId.Equals(emptypeid) && emp.EmpSpecialist.EmpSpecilistId.Equals(spid) && emp.EmpId.Equals(empid)
                        select new EmpBasicInfoDTO
                        {
                            EmpId = emp.EmpId,

                            EmpTypeId = emp.EmpType.EmpTypeId,
                            EmpSpecilistId = emp.EmpSpecialist.EmpSpecilistId,
                            TariningStatus = emp.TariningStatus


                        }).ToList<EmpBasicInfoDTO>();
                GetStatus.AddRange(data);
                return GetStatus;
            }
        }



        public List<EmpBasicInfoDTO> GetEmp_EXperience_Status_Flag(int emptypeid, int spid, int empid)
        {
            List<EmpBasicInfoDTO> GetStatus = new List<EmpBasicInfoDTO>();
            using (var Container = new InventoryContainer())
            {
                var data = new List<EmpBasicInfoDTO>();
                data = (from emp in Container.Employees
                        where emp.EmpType.EmpTypeId.Equals(emptypeid) && emp.EmpSpecialist.EmpSpecilistId.Equals(spid) && emp.EmpId.Equals(empid)
                        select new EmpBasicInfoDTO
                        {
                            EmpId = emp.EmpId,

                            EmpTypeId = emp.EmpType.EmpTypeId,
                            EmpSpecilistId = emp.EmpSpecialist.EmpSpecilistId,
                            ExperienceStatus = emp.ExperienceStatus


                        }).ToList<EmpBasicInfoDTO>();
                GetStatus.AddRange(data);
                return GetStatus;
            }
        }


        // end emp id and status

        public void Edit_Status_flag(EmpBasicInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new Employee();
                Comp = container.Employees.FirstOrDefault(o => o.EmpId.Equals(DTO.EmpId));
                // Comp.Id = DTO.Id;
                Comp.EduStatus = DTO.EduStatus;
                Comp = (Employee)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        // end emp id and status

        public void Edit_Status_flag_discount(EmpBasicInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new Employee();
                Comp = container.Employees.FirstOrDefault(o => o.EmpId.Equals(DTO.EmpId));
                // Comp.Id = DTO.Id;
                Comp.DiscountStatus = DTO.DiscountStatus;
                Comp = (Employee)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
        public void Edit_Status_flag_Experience(EmpBasicInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new Employee();
                Comp = container.Employees.FirstOrDefault(o => o.EmpId.Equals(DTO.EmpId));
                Comp.ExperienceStatus = DTO.ExperienceStatus;
                Comp = (Employee)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public void Edit_Status_flag_training(EmpBasicInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new Employee();
                Comp = container.Employees.FirstOrDefault(o => o.EmpId.Equals(DTO.EmpId));
                Comp.TariningStatus = DTO.TariningStatus;
                Comp = (Employee)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }



        public List<EmpBasicInfoDTO> GetDesignation(int empid, int emptypeid)
        {
            List<EmpBasicInfoDTO> GetStatus = new List<EmpBasicInfoDTO>();
            using (var Container = new InventoryContainer())
            {
                var data = new List<EmpBasicInfoDTO>();
                data = (from emp in Container.Employees

                        select new EmpBasicInfoDTO
                        {
                            EmpId = emp.EmpId,
                            EmpTypeId = emp.EmpType.EmpTypeId,
                            EmpSpecilistId = emp.EmpSpecialist.EmpSpecilistId,
                            Specialist = emp.EmpSpecialist.Specialist,


                        }).ToList<EmpBasicInfoDTO>();
                GetStatus.AddRange(data);
                return GetStatus;
            }
        }


        public List<EmpSpcialistDTO> GetSpcialistSearch(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.EmpSpecialists
                            join emptype in Container.EmpTypes on s.EmpTypeId equals emptype.EmpTypeId
                            select new { s, emptype };

                if (id != 0)
                    query = query.Where(c => c.emptype.EmpTypeId.Equals(id));

                var result = from o in query
                             orderby o.s.EmpSpecilistId descending
                             select new EmpSpcialistDTO
                             {
                                 EmpSpecilistId = o.s.EmpSpecilistId,
                                 CreateBy = o.s.CreateBy,
                                 TypeName = o.emptype.TypeName,
                                 EmpTypeId = o.emptype.EmpTypeId,
                                 SpecilistName = o.s.Specialist

                             };
                return result.ToList<EmpSpcialistDTO>();
            }
        }


        public List<EmpSpcialistDTO> GetSpcialistSearchAllpage(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.EmpSpecialists
                            join emptype in Container.EmpTypes on s.EmpTypeId equals emptype.EmpTypeId
                            select new { s, emptype };

                if (id != 0)
                    query = query.Where(c => c.emptype.EmpTypeId.Equals(id));

                var result = from o in query
                             //  orderby o.s.Id descending
                             where o.emptype.EmpTypeId.Equals(id)
                             select new EmpSpcialistDTO
                             {
                                 EmpSpecilistId = o.s.EmpSpecilistId,
                                 CreateBy = o.s.CreateBy,
                                 TypeName = o.emptype.TypeName,
                                 EmpTypeId = o.emptype.EmpTypeId,

                                 Specialist = o.s.Specialist
                             };
                return result.ToList<EmpSpcialistDTO>();
            }
        }

        public List<EmpBasicInfoDTO> GetCurrentUserBranchName(string username)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Employees
                            join brnch in Container.InvenBranchProfiles on s.BrProId equals brnch.BrProId
                            select new { s, brnch };

                if (!string.IsNullOrEmpty(username))
                    query = query.Where(c => c.s.UserName.Contains(username));

                var result = from o in query

                             select new EmpBasicInfoDTO
                             {
                                 UserName=o.s.UserName,
                                 BrProId=o.brnch.BrProId
                             };
                return result.ToList<EmpBasicInfoDTO>();
            }
        }
    }
}
