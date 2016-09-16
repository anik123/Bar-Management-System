using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class LogInvenReorderDTO
    {
        public int LogInvenReorderId { get; set; }
        public string LogField { get; set; }
        public string LogBy { get; set; }
        public DateTime? LogDate { get; set; }
    }
}
