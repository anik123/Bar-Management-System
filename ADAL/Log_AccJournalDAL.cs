using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using Utility;
using DAL;

namespace ADAL
{
    public class Log_AccJournalDAL
    {
        public void AddLogAccJournal(Log_AccJournalDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                Log_AccJournal gur = new Log_AccJournal();
                container.Log_AccJournal.AddObject((Log_AccJournal)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }
        // load data for  log file journal data
        public List<Log_AccJournalDTO> LoadLog_JournalUpdateData(DateTime fromdate, DateTime todate)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Log_AccJournal

                            select new { s };


                var result = from o in query

                             where o.s.LogDate >= fromdate && o.s.LogDate <= todate

                             orderby o.s.LogJournalId descending
                             select new Log_AccJournalDTO
                             {
                                LogBy = o.s.LogBy,
                                LogDate = o.s.LogDate,
                                LogField=o.s.LogField,
                                LogJournalId = o.s.LogJournalId
                                
                             };
                return result.ToList<Log_AccJournalDTO>();
            }
        }


    }

}