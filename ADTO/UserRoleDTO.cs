using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ADTO
{
   public class UserRoleDTO
    {
       public int UserRoleId { get; set; }
       public int EmpId { get; set; }
       public int RoleId { get; set; }
       public string CreateBy { get; set; }
       public DateTime? CreateDate { get; set; }
       public string UpdateBy { get; set; }
       public DateTime? UpdateDate { get; set; }

       public int Id { get; set; }// emp id
       // for load perpose
       public string EmpName { get; set; }

       public int EmpTypeId { get; set; }
       public int EmpSpcilistId { get; set; }
       public string EmpType { get; set; }
       public string EmpSpcility { get; set; }
       public string RoleName { get; set; }
    }
}
