using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class Log_InventoryDAL
    {
        // Inventory Reorder table for barnch wise reorder add 
        public void Add_Reorder_BranchWise_Log(LogInvenReorderDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                Log_InvenReorder gur = new Log_InvenReorder();
                container.Log_InvenReorder.AddObject((Log_InvenReorder)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }
        //load  Inventory Reorder table for barnch wise reorder  
        public List<LogInvenReorderDTO> LoadLog_Reorder_BranchWise(string FromDate, string ToDate)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Log_InvenReorder

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
                             orderby o.s.LogInvenReorderId descending
                             select new LogInvenReorderDTO
                             {
                                 LogBy = o.s.LogBy,
                                 LogDate = o.s.LogDate,
                                 LogField = o.s.LogField,
                                 LogInvenReorderId = o.s.LogInvenReorderId

                             };
                return result.ToList<LogInvenReorderDTO>();
            }
        }
    }
}
