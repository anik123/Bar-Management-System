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
    public class UserRoleDAL
    {
        public void Add(UserRoleDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                PayUserRole gur = new PayUserRole();
                container.PayUserRoles.AddObject((PayUserRole)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(UserRoleDTO EduDTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new PayUserRole();
                Comp = container.PayUserRoles.FirstOrDefault(o => o.UserRoleId.Equals(EduDTO.UserRoleId));
                Comp.UserRoleId = EduDTO.UserRoleId;
                Comp.RoleId = EduDTO.RoleId;
                Comp.EmpId = EduDTO.EmpId;
                Comp.UpdateBy = EduDTO.UpdateBy;
                Comp.UpdateDate = EduDTO.UpdateDate;
                Comp = (PayUserRole)DTOMapper.DTOObjectConverter(EduDTO, Comp);
                container.SaveChanges();
            }
        }


        // load userrole 
        public List<UserRoleDTO> LoadUserRole(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PayUserRoles
                            join emp in Container.Employees on s.EmpId equals emp.EmpId
                            select new { s, emp };
                if (id != 0)
                    query = query.Where(c => c.s.UserRoleId.Equals(id));
                var result = (from o in query
                              orderby o.s.UserRoleId descending
                              select new UserRoleDTO
                              {
                                  UserRoleId = o.s.UserRoleId,
                                  RoleId = o.s.PayRole.RoleId,
                                  RoleName = o.s.PayRole.RoleName,
                                  EmpTypeId = o.s.Employee.EmpType.EmpTypeId,
                                  EmpType = o.s.Employee.EmpType.TypeName,
                                  EmpSpcilistId = o.s.Employee.EmpSpecialist.EmpSpecilistId,
                                  EmpSpcility = o.s.Employee.EmpSpecialist.Specialist,
                                  EmpId = o.emp.EmpId,
                                  EmpName = o.emp.EmpName,
                                  CreateDate = o.s.CreateDate,
                                  CreateBy = o.s.CreateBy,
                                  UpdateBy = o.s.UpdateBy,
                                  UpdateDate = o.s.UpdateDate
                              }).ToList<UserRoleDTO>();

                return result;
            }
        }
        // load emp name
        public List<UserRoleDTO> LoadEmpName(int emptypeid, int spcilistid)
        {
            using (var Container = new InventoryContainer())
            {
                var data = (from o in Container.Employees
                           // where o.EmpType.EmpTypeId.Equals(emptypeid) && o.EmpSpecialist.EmpSpecilistId.Equals(spcilistid)
                            select new UserRoleDTO
                            {
                                EmpTypeId = o.EmpType.EmpTypeId,
                                EmpSpcilistId = o.EmpSpecialist.EmpSpecilistId,
                                // Id = o.Id,
                                EmpId = o.EmpId,
                                EmpName = o.EmpName
                            }

                       ).ToList<UserRoleDTO>();
                return data;
            }
        }

        // load link button emp name       
        public List<UserRoleDTO> LoadUserRole_linkbuttonEmpName(int id, int emptypeid, int empspid, int empid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PayUserRoles
                            join role in Container.PayRoles on s.RoleId equals role.RoleId
                            join emp in Container.Employees on s.EmpId equals emp.EmpId
                            join emptype in Container.EmpTypes on emp.EmpTypeId equals emptype.EmpTypeId
                            join empsp in Container.EmpSpecialists on emp.EmpSpecilistId equals empsp.EmpSpecilistId
                            select new { s, role, emp, emptype, empsp };
                if (id != 0)
                    query = query.Where(c => c.s.UserRoleId.Equals(id));
                if (emptypeid != 0)
                    query = query.Where(c => c.emptype.EmpTypeId.Equals(emptypeid));
                if (empspid != 0)
                    query = query.Where(c => c.empsp.EmpSpecilistId.Equals(empspid));
                if (empid != 0)
                    query = query.Where(c => c.emp.EmpId.Equals(empid));

                var result = (from o in query
                              orderby o.s.UserRoleId descending
                              select new UserRoleDTO
                              {
                                  UserRoleId = o.s.UserRoleId,
                                  RoleId = o.role.RoleId,
                                  RoleName = o.role.RoleName,
                                  EmpId = o.emp.EmpId,
                                  EmpName = o.emp.EmpName,
                                  EmpTypeId = o.emptype.EmpTypeId,
                                  EmpType = o.emptype.TypeName,
                                  EmpSpcilistId = o.empsp.EmpSpecilistId,
                                  EmpSpcility = o.empsp.Specialist,

                                  //  Id = o.emp.Id
                              }).ToList<UserRoleDTO>();

                return result;
            }
        }
        // load link button emp name     new   
        public List<UserRoleDTO> LoadUserRole_linkbuttonEmpName_New(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PayUserRoles
                            join role in Container.PayRoles on s.RoleId equals role.RoleId
                            join emp in Container.Employees on s.EmpId equals emp.EmpId
                            join emptype in Container.EmpTypes on emp.EmpTypeId equals emptype.EmpTypeId
                            join empsp in Container.EmpSpecialists on emp.EmpSpecilistId equals empsp.EmpSpecilistId
                            select new { s, role, emp, emptype, empsp };
                if (id != 0)
                    query = query.Where(c => c.s.UserRoleId.Equals(id));

                var result = (from o in query
                              orderby o.s.UserRoleId descending
                              select new UserRoleDTO
                              {
                                  UserRoleId = o.s.UserRoleId,
                                  RoleId = o.role.RoleId,
                                  RoleName = o.role.RoleName,
                                  EmpId = o.emp.EmpId,
                                  EmpName = o.emp.EmpName,
                                  EmpTypeId = o.emptype.EmpTypeId,
                                  EmpType = o.emptype.TypeName,
                                  EmpSpcilistId = o.empsp.EmpSpecilistId,
                                  EmpSpcility = o.empsp.Specialist,

                                  // Id = o.emp.Id
                              }).ToList<UserRoleDTO>();

                return result;
            }
        }
        // load link button emp name     new   
        public List<UserRoleDTO> LoadUserRole_linkbuttonEmpName_New_2(int id, int emptypeid,int empspecilistid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PayUserRoles
                            join role in Container.PayRoles on s.RoleId equals role.RoleId
                            join emp in Container.Employees on s.EmpId equals emp.EmpId
                            join emptype in Container.EmpTypes on emp.EmpTypeId equals emptype.EmpTypeId
                            join empsp in Container.EmpSpecialists on emp.EmpSpecilistId equals empsp.EmpSpecilistId
                            select new { s, role, emp, emptype, empsp };
                if (id != 0)
                    query = query.Where(c => c.s.UserRoleId.Equals(id));
                if (emptypeid != 0)
                    query = query.Where(c => c.emptype.EmpTypeId.Equals(emptypeid));
                if (empspecilistid != 0)
                    query = query.Where(c => c.empsp.EmpSpecilistId.Equals(empspecilistid));

                var result = (from o in query
                              orderby o.s.UserRoleId descending
                              select new UserRoleDTO
                              {
                                  UserRoleId = o.s.UserRoleId,
                                  RoleId = o.role.RoleId,
                                  RoleName = o.role.RoleName,
                                  EmpId = o.emp.EmpId,
                                  EmpName = o.emp.EmpName,
                                  EmpTypeId = o.emptype.EmpTypeId,
                                  EmpType = o.emptype.TypeName,
                                  EmpSpcilistId = o.empsp.EmpSpecilistId,
                                  EmpSpcility = o.empsp.Specialist,

                                  // Id = o.emp.Id
                              }).ToList<UserRoleDTO>();

                return result;
            }
        }
    }
}



