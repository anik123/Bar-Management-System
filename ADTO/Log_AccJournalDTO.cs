using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public class Log_AccJournalDTO
    {
        public int LogJournalId { set; get; }
        public string LogField { set; get; }
        public DateTime? LogDate { set; get; }
        public string LogBy { set; get; }
    }
}
