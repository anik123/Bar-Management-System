using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
    public class ExperienceBLL
    {
        ExperienceDAL ExDal = new ExperienceDAL();
        public void Add(ExperienceDTO DTO)
        {
            ExDal.Add(DTO);
        }
        public void Edit(ExperienceDTO EduDTO)
        {
            ExDal.Edit(EduDTO);
        }
        public List<ExperienceDTO> LoadEmpExperienceInfo_new_update(int expid)
        {
            return ExDal.LoadEmpExperienceInfo_new_update(expid);
        }

        public List<ExperienceDTO> LoadEmpExperienceInfo_modified(int empid, int expid, string Deptname, string pname, string designation, string mobile)
        {
            return ExDal.LoadEmpExperienceInfo_modified(empid, expid, Deptname, pname, designation, mobile);
        }

        public List<EmpBasicInfoDTO> LoadEmpName_Experience(int spcilistid)
        {
            return ExDal.LoadEmpName_Experience(spcilistid);
        }
    }
}
