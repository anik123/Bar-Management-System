using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenChangeInfoDto
    {

        public int ChangeId { get; set; }
        public string CreateBy { get; set; }
        public DateTime CreateDate { get; set; }
        public int? BrProId { get; set; }
        public string CustomerName { get; set; }
        public string CusMobileNo { get; set; }
        public string CusContactAdd { get; set; }
        public string CusRemarks { get; set; }
        public string TransectionType { get; set; }
        public int? SalId { get; set; }


    }
}
