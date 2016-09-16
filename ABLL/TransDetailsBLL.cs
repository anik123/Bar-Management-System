using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;

using ADAL;

namespace ABLL
{
    public class TransDetailsBLL
    {
        TransDetailsDAL dal = new TransDetailsDAL();
        public void Add(TransDetailsDTO DTO)
        {

            dal.Add(DTO);

        }

        public void Edit(TransDetailsDTO DTO)
        {
            dal.Edit(DTO);

        }

        public List<TransDetailsDTO> LoadTransDetailsData_DR(int id)
        {
            return dal.LoadTransDetailsData_DR(id);
        }
        public List<TransDetailsDTO> LoadTransDetailsData_CR(int id)
        {
            return dal.LoadTransDetailsData_CR(id);
        }
    }
}
