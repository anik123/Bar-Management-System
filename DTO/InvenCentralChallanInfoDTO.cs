using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
   public class InvenCentralChallanInfoDTO
   {
       public int ChallanId { get; set; }
       public int? PurReqNo { get; set; }
       public string ChallanBy { get; set; }
       public DateTime? ChallanDate { get; set; }
       public string Note { get; set; }
       public int? BrProId {get;set;}
       // branch name
       public string BrProName { get; set; }
     
    }
}
