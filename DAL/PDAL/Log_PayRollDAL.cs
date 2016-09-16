using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.PDTO;
using Utility;

namespace DAL.PDAL
{
    public class Log_PayRollDAL
    {
        // Emp basic info with pass 
        public void AddPayEmpBasicInfo_Log(Log_PayEmpInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                Log_PayEmpInfo gur = new Log_PayEmpInfo();
                container.Log_PayEmpInfo.AddObject((Log_PayEmpInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }
        // pay user role 
        public void AddUserRole_Log(LogPayUserRollDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                Log_PayuserRole gur = new Log_PayuserRole();
                container.Log_PayuserRole.AddObject((Log_PayuserRole)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }
        // load data for  log file journal data
        public List<Log_PayEmpInfoDTO> LoadLog_EmpBaicInfo(string FromDate, string ToDate)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Log_PayEmpInfo

                            select new { s };
                DateTime To, From;
                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    To = To.AddDays(1);
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.s.LogDate >= From && c.s.LogDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.s.LogDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.s.LogDate == From);
                }

                var result = from o in query

                            // where o.s.LogDate >= fromdate && o.s.LogDate <= todate

                             orderby o.s.LogPayEmpInfoId descending
                             select new Log_PayEmpInfoDTO
                             {
                                 LogBy = o.s.LogBy,
                                 LogDate = o.s.LogDate,
                                 LogField = o.s.LogField,
                                 LogPayEmpInfoId = o.s.LogPayEmpInfoId

                             };
                return result.ToList<Log_PayEmpInfoDTO>();
            }
        }
        // load data for  log file journal data
        public List<LogPayUserRollDTO> LoadLog_UserRole(string FromDate, string ToDate)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Log_PayuserRole

                            select new { s };
                DateTime To, From;
                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    To = To.AddDays(1);
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.s.LogDate >= From && c.s.LogDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.s.LogDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.s.LogDate == From);
                }

                var result = from o in query

                        //     where o.s.LogDate >= fromdate && o.s.LogDate <= todate

                             orderby o.s.LogFilePayUserRoleId descending
                             select new LogPayUserRollDTO
                             {
                                 LogBy = o.s.LogBy,
                                 LogDate = o.s.LogDate,
                                 LogField = o.s.LogField,
                                 LogFilePayUserRoleId = o.s.LogFilePayUserRoleId

                             };
                return result.ToList<LogPayUserRollDTO>();
            }
        }
    }
}
