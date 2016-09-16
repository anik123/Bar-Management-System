using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class InvenSaleXtraInfoBLL
    {
        InvenSaleXtraInfoDAL DAL = new InvenSaleXtraInfoDAL();
        public void Add(InvenSaleXtraInfoDTO DTO)
        {
            DAL.Add(DTO);
        }
    }
}
