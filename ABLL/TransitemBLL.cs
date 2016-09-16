using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using ADAL;
namespace ABLL
{
    public class TransitemBLL
    {
        TransitemDAL dal = new TransitemDAL();

        public void Add(TransitemDTO DTO)
        {

            dal.Add(DTO);

        }

        public void Edit(TransitemDTO DTO) {
            dal.Edit(DTO);
        
        }

        public List<TransitemDTO> LoadTransData(int id)
        {
            return dal.LoadTransData(id);
        }


        

        


    }
}
