using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class InvenSaleXtraInfoDAL
    {
        InvenSaleXtraInfoDTO DTO = new InvenSaleXtraInfoDTO();
        public void Add(InvenSaleXtraInfoDTO DTO)
        {

            using (var container = new InventoryContainer())
            {
                InvenSaleXtraInfo gur = new InvenSaleXtraInfo();
                container.InvenSaleXtraInfoes.AddObject((InvenSaleXtraInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }
    }
}
