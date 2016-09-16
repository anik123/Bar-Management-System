using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class MemberDTO
    {
        public int MemberId { set; get; }
        public string MemberNo { set; get; }
        public string Type { set; get; }
        public string FullName { set; get; }
        public string Exservice { set; get; }
        public string ContactNo { set; get; }
        public string MemType { set; get; }

        //extra

        // public string FullName { set; get; }
        public string SellFullName { set; get; }

    }
}
