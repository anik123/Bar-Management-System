using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using ADAL;

namespace ABLL
{
    public class CrystalReptBLL
    {

        CrystalReptDAL dal = new CrystalReptDAL();
        public List<SubVoucherDTO> GenerateSuvCodeNo(string Vochername, string Subvochername)
        {
            return dal.GenerateSuvCodeNo(Vochername, Subvochername);
        }

    }
}
