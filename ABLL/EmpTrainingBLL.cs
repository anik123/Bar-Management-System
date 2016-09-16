using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
    public class EmpTrainingBLL
    {
        EmpTrainingDAL TDAL = new EmpTrainingDAL();
        public void Add(EmpTrainingDTO DTO)
        {
            TDAL.Add(DTO);
        }


        public void Edit(EmpTrainingDTO EduDTO)
        {
            TDAL.Edit(EduDTO);
        }
        public List<EmpTrainingDTO> LoadEmpTrainingInfo_modified(int empid, int trinId, string Deptname, string pname, string designation, string mobile)
        {
            return TDAL.LoadEmpTrainingInfo_modified(empid, trinId, Deptname, pname, designation, mobile);
        }
        public List<EmpTrainingDTO> ShowtrianingInfo_ForUpdate(int tarinid)
        {
            return TDAL.ShowtrianingInfo_ForUpdate(tarinid);
        }
        public List<EmpBasicInfoDTO> LoadEmpName_training(int spcilistid)
        {
            return TDAL.LoadEmpName_training(spcilistid);
        }

    }
}