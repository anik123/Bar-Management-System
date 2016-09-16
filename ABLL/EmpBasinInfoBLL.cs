using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;
using System.IO;


namespace ABLL
{
    public class EmpBasinInfoBLL
    {

        EmpBasicInfoDAL EDAL = new EmpBasicInfoDAL();

        public void Add(EmpBasicInfoDTO DTO)
        {
            EDAL.Add(DTO);
        }

        public void Edit(EmpBasicInfoDTO DTO)
        {
            EDAL.Edit(DTO);
        }
        // Edit password
        public void Edit_Password(EmpBasicInfoDTO DTO)
        {
            EDAL.Edit_Password(DTO);
        }
        public List<EmpBasicInfoDTO> LoadEmpBasic(int empid, string empname, string moblie, string username, string SurName)
        {
            return EDAL.LoadEmpBasic(empid, empname, moblie, username, SurName);
        }
        // laod emp basic for Eucation page  LoadEmpBasic_Discount
        public List<EmpBasicInfoDTO> LoadEmpBasic_Discount(int empid, string empname, string moblie, string username, string SurName)
        {
            return EDAL.LoadEmpBasic_Discount(empid, empname, moblie, username, SurName);
        }
        // for emp education page

        public List<EmpBasicInfoDTO> LoadEmpBasic_EduPage(int empid, string empname, string moblie, string username, string SurName)
        {
            return EDAL.LoadEmpBasic_EduPage(empid, empname, moblie, username, SurName);
        }

        public List<EmpBasicInfoDTO> LoadEmpBasic_Tarining(int empid, string empname, string moblie, string username, string SurName)
        {
            return EDAL.LoadEmpBasic_Tarining(empid, empname, moblie, username, SurName);
        }

        public List<EmpBasicInfoDTO> LoadEmpBasic_Experienceinfo(int empid, string empname, string moblie, string username, string SurName)
        {
            return EDAL.LoadEmpBasic_Experienceinfo(empid, empname, moblie, username, SurName);
        }


        public List<EmpBasicInfoDTO> GetEmp_All_Status_Flag(int emptypeid, int spid, int empid)
        {
            return EDAL.GetEmp_All_Status_Flag(emptypeid, spid, empid);
        }

        public List<EmpBasicInfoDTO> GetEmp_trining_Status_Flag(int emptypeid, int spid, int empid)
        {
            return EDAL.GetEmp_trining_Status_Flag(emptypeid, spid, empid);
        }
        public List<EmpBasicInfoDTO> GetEmp_EXperience_Status_Flag(int emptypeid, int spid, int empid)
        {
            return EDAL.GetEmp_EXperience_Status_Flag(emptypeid, spid, empid);
        }

        public void Edit_Status_flag(EmpBasicInfoDTO DTO)
        {
            EDAL.Edit_Status_flag(DTO);
        }
        // end emp id and status

        public void Edit_Status_flag_discount(EmpBasicInfoDTO DTO)
        {
            EDAL.Edit_Status_flag_discount(DTO);
        }
        public void Edit_Status_flag_training(EmpBasicInfoDTO DTO)
        {
            EDAL.Edit_Status_flag_training(DTO);

        }
        public void Edit_Status_flag_Experience(EmpBasicInfoDTO DTO)
        {
            EDAL.Edit_Status_flag_Experience(DTO);
        }



        // load emp status info


        // load emp designation 
        public List<EmpBasicInfoDTO> GetDesignation(int empid, int emptypeid)
        {

            return EDAL.GetDesignation(empid, emptypeid);
        }
        // load Emp Specilist
        public List<EmpSpcialistDTO> GetSpcialistSearch(int id)
        {
            return EDAL.GetSpcialistSearch(id);
        }
        //load all emp specilist all other page of basicinfo
        public List<EmpSpcialistDTO> GetSpcialistSearchAllpage(int id)
        {
            return EDAL.GetSpcialistSearchAllpage(id);
        }
        public List<EmpBasicInfoDTO> GetCurrentUserBranchName(string username)
        {
            return EDAL.GetCurrentUserBranchName(username);
        }
    }
}
