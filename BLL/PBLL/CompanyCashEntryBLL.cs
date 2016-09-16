using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDAL;
using PDTO;

namespace PBLL
{
    public class CompanyCashEntryBLL
    {
        CompanyCashEntryDAL CDAL = new CompanyCashEntryDAL();
        public void Add(CompanyCashEntryDTO DTO)
        {
            CDAL.Add(DTO);
        }
        public List<CompanyCashEntryDTO> SumOfCashAmount()
        {
            return CDAL.SumOfCashAmount();
        }

       
    }
}
