using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using DAL;

namespace ADAL
{
   public class LoginDAL
   {
       public List<EmpBasicInfoDTO> LogInTest(string uname, string pass)
       {
           using (var container = new InventoryContainer())
           {
               var data = (from com in container.Employees
                           where com.Password.Equals(pass) && com.UserName.Equals(uname)
                           select new EmpBasicInfoDTO
                           {

                               UserName = com.UserName,
                               //  RoleName = com.Role.RoleName,
                               Password = com.Password



                           }).ToList<EmpBasicInfoDTO>();

               return data;

           }
       }


       public List<UserRoleDTO> GetRolebyUser(string uname, string pass)
       {
           using (var Container = new InventoryContainer())
           {
               var data = (from com in Container.PayUserRoles
                           where com.Employee.Password.Equals(pass) && com.Employee.UserName.Equals(uname)
                           select new UserRoleDTO
                           {
                               RoleName = com.PayRole.RoleName

                           }).ToList<UserRoleDTO>();

               return data;

           }

       }


       // for get role name
       public List<UserRoleDTO> GetRoleName_By_User(string uname)
       {
           using (var Container = new InventoryContainer())
           {
               var data = (from com in Container.PayUserRoles
                           where com.Employee.UserName.Equals(uname)
                           select new UserRoleDTO
                           {
                               RoleName = com.PayRole.RoleName,
                               RoleId=com.PayRole.RoleId

                           }).ToList<UserRoleDTO>();

               return data;

           }

       }
   }
}
