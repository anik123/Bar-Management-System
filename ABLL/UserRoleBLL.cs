using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;


namespace ABLL
{
    public class UserRoleBLL
    {

        UserRoleDAL DAL = new UserRoleDAL();
        public void Add(UserRoleDTO DTO)
        {
            DAL.Add(DTO);
        }

        public void Edit(UserRoleDTO EduDTO)
        {
            DAL.Edit(EduDTO);
        }
        public List<UserRoleDTO> LoadUserRole(int id)
        {
            return DAL.LoadUserRole(id);
        }

        // load emp name
        public List<UserRoleDTO> LoadEmpName(int emptypeid, int spcilistid)
        {
            return DAL.LoadEmpName(emptypeid, spcilistid);
        }

        // load link button emp name       
        public List<UserRoleDTO> LoadUserRole_linkbuttonEmpName(int id, int emptypeid, int empspid, int empid)
        {
            return DAL.LoadUserRole_linkbuttonEmpName(id, emptypeid, empspid, empid);
        }

        // load link button emp name     new   
        public List<UserRoleDTO> LoadUserRole_linkbuttonEmpName_New(int id)
        {
            return DAL.LoadUserRole_linkbuttonEmpName_New(id);
        }

         // load link button emp name     new   
        public List<UserRoleDTO> LoadUserRole_linkbuttonEmpName_New_2(int id, int emptypeid, int empspecilistid)
        {
            return DAL.LoadUserRole_linkbuttonEmpName_New_2(id, emptypeid, empspecilistid);
        }
    }
}
