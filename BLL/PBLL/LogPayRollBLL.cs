using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.PDAL;
using DTO.PDTO;

namespace BLL.PBLL
{
    public class LogPayRollBLL
    {
        Log_PayRollDAL LDAL = new Log_PayRollDAL();
         // Emp basic info with pass 
        public void AddPayEmpBasicInfo_Log(Log_PayEmpInfoDTO DTO)
        {
            LDAL.AddPayEmpBasicInfo_Log(DTO);
        }
          // pay user role 
        public void AddUserRole_Log(LogPayUserRollDTO DTO)
        {
            LDAL.AddUserRole_Log(DTO);
        }
         // load data for  log file journal data
        public List<Log_PayEmpInfoDTO> LoadLog_EmpBaicInfo(string FromDate, string ToDate)
        {
            return LDAL.LoadLog_EmpBaicInfo(FromDate, ToDate);
        }
         // load data for  log file journal data
        public List<LogPayUserRollDTO> LoadLog_UserRole(string FromDate, string ToDate)
        {
            return LDAL.LoadLog_UserRole(FromDate, ToDate);
        }
        
    }
}
