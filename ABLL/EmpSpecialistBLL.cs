using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using ADAL;

namespace ABLL
{
    public class EmpSpecialistBLL
    {
        SpecialistDAL sdal = new SpecialistDAL();

        public void Add(EmpSpcialistDTO DTO)
        {
            sdal.Add(DTO);
        }
        public void Edit(EmpSpcialistDTO DTO)
        {
            sdal.Edit(DTO);
        }
        public List<EmpSpcialistDTO> GetSpcialistSearch(int id) // search
        {
            return sdal.GetSpcialistSearch(id);
        }



    }
}
