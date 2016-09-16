using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class AccountTypeDTO
    {
        public int AccountTypeId { get; set; }
        public string AccountTypeName { get; set; }

        public string CreateBy { get; set; }
        public DateTime? CreateDate { get; set; }
        public string UpdateBy { get; set; }
        public DateTime? UpdateDate { get; set; }
    }
}
