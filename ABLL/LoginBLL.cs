using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
  public  class LoginBLL
  {
      LoginDAL dal = new LoginDAL();
      public List<EmpBasicInfoDTO> LogInTest(string uname, string pass)
      {
          return dal.LogInTest(uname, pass);
      }

      public List<UserRoleDTO> GetRolebyUser(string uname, string pass)
      {
          return dal.GetRolebyUser(uname, pass);
      }
       // for get role name
       public List<UserRoleDTO> GetRoleName_By_User(string uname)
       {
           return dal.GetRoleName_By_User(uname);
       }
  }
}