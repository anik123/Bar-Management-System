using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
    public class EmpTypeBLL
    {
        EmpTypeDAL tDAL = new EmpTypeDAL();
        public void Add(EmpTypeDTO DTO)
        {
            tDAL.Add(DTO);
        }
        public void Edit(EmpTypeDTO DTO)
        {
            tDAL.Edit(DTO);
        }
        public List<EmpTypeDTO> GetEmpType(int id)
        {
            return tDAL.GetEmpType(id);
        }
    }
}
