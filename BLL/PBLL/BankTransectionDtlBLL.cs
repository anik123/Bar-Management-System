using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDAL;
using PDTO;

namespace PBLL
{
    public class BankTransectionDtlBLL
    {
        BankTransectionDtlDAL dtlDAL = new BankTransectionDtlDAL();
        public void Add(BankTransectionDtlDTO DTO)
        {
            dtlDAL.Add(DTO);
        }
    }
}
