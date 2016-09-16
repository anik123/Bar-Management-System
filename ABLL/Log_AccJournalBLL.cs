using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
    public class Log_AccJournalBLL
    {
        Log_AccJournalDAL dal = new Log_AccJournalDAL();
        public void AddLogAccJournal(Log_AccJournalDTO DTO)
        {
            dal.AddLogAccJournal(DTO);
        }
         // load data for  log file journal data
        public List<Log_AccJournalDTO> LoadLog_JournalUpdateData(DateTime fromdate, DateTime todate)
        {
            return dal.LoadLog_JournalUpdateData(fromdate, todate);
        }
    }
}
