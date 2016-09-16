using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenBranchReturnDTO
    {
        public int BranchReturnId { get; set; }
        public int? ChangeDtlId { get; set; }
        public string ReturnBy { get; set; }
        public DateTime ReturnDate { get; set; }
        public int? ReturnNo { get; set; }
        public string PartyReturnStatus { get; set; }

        /*
                public int PartyReturnNo { get; set; }
                public DateTime? PartyReturnDate { get; set; }
                public string PartyReturnBy { get; set; }
                */
        public DateTime? ReciveDate { get; set; }
        public string ReciveBy { get; set; }
        public string ReturnReciveStatus { get; set; }
        public string CentralToPartyStatus { get; set; }
    }
}
