using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using ADAL;

namespace ABLL
{
    public class RoleBLL
    {
        RoleDAL RDAL = new RoleDAL();
        public void Add(RoleDTO DTO)
        {
            RDAL.Add(DTO);
        }
        public void Edit(RoleDTO EduDTO)
        {
            RDAL.Edit(EduDTO);
        }

        public List<RoleDTO> LoadRole(int id)
        {
            return RDAL.LoadRole(id);
        }
    }
}
