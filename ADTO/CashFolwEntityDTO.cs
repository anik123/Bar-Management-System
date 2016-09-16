using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
    public class CashFolwEntityDTO
    {
        public int CFEId { get; set; }
        public string CFEName { get; set; }
        public int? Priority { get; set; }
        public DateTime? CreateDate { get; set; }
        public string CreateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
        public string UpdateBy { get; set; }
    }
}
