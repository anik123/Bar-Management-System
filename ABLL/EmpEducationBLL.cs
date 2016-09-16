using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
    public class EmpEducationBLL
    {
        EmpEducationDAL EDuDAL = new EmpEducationDAL();
        public void Add(EmpEducationDTO DTO)
        {
            EDuDAL.Add(DTO);
        }

        public void Edit(EmpEducationDTO EduDTO)
        {
          
            EDuDAL.Edit(EduDTO);
        }
         // load popup empname
        public List<EmpBasicInfoDTO> LoadEmpName_Discount_EmpPopUp(int emptypeid, int spcilistid)
        {
            return EDuDAL.LoadEmpName_Discount_EmpPopUp(emptypeid, spcilistid);
        }
          // load emp name
        public List<EmpBasicInfoDTO> LoadEmpName_Train(int spcilistid)
        {
            return EDuDAL.LoadEmpName_Train(spcilistid);
        }

        public List<EmpBasicInfoDTO> LoadEmpName_Edu(int spcilistid)
        {
            return EDuDAL.LoadEmpName_Edu(spcilistid);
        }
        // load discount emp 
        public List<EmpBasicInfoDTO> LoadEmpName_Discount(int emptypeid, int spcilistid)
        {
            return EDuDAL.LoadEmpName_Discount(emptypeid,spcilistid);
        }

        public List<EmpBasicInfoDTO> GetALLOtherInfo(int deptid, int designationid, int empid)
        {
            return EDuDAL.GetALLOtherInfo(deptid, designationid, empid);
        }

         // load emppopup all other info
        public List<EmpBasicInfoDTO> GetALLOtherInfo_EmpPopUp(int deptid, int designationid, int empid)
        {
            return EDuDAL.GetALLOtherInfo_EmpPopUp(deptid, designationid, empid);
        }
        // load emp name
        //public List<EmpEducationDTO> LoadEmpEducation(int eduid)
        //{
        //    return EDuDAL.LoadEmpEducation(eduid);
        //}
       

        ////for load education rpt 
        //public List<EmpEducationDTO> LoadEmpEducationInfo(int empid, int eduid)
        //{
        //    return EDuDAL.LoadEmpEducationInfo(empid, eduid);
        //}

        //// show from repeter
        public List<EmpEducationDTO> ShowEducationInfo_ForUpdate(int eduid)
        {
            return EDuDAL.ShowEducationInfo_ForUpdate(eduid);
        }

        //load rpt test

        public List<EmpEducationDTO> LoadEmpEducationInfo_modified(int empid, int eduid, string Deptname, string pname, string designation, string mobile)
        {
            return EDuDAL.LoadEmpEducationInfo_modified(empid, eduid, Deptname, pname, designation, mobile);
        }
    }
}
