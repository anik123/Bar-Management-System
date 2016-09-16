using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenCentralReturnDTO
    {
        public int? BranchReturnId { get; set; }
        public int CentralReturnId { get; set; }
        public string ReturnBy { get; set; }
        public DateTime ReturnDate { get; set; }
        public int ReturnNo { get; set; }

    }
}
