using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO.PDTO
{
    public class LogPayUserRollDTO
    {
        public int LogFilePayUserRoleId { get; set; }
        public string LogField { get; set; }
        public string LogBy { get; set; }
        public DateTime? LogDate { get; set; }
    }
}
