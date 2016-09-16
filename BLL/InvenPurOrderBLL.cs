using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class InvenPurOrderBLL
    {
        InvenPurOrderDal DAL = new InvenPurOrderDal();
        public void Add(InvenPurOrderDto DTO)
        {
            DAL.Add(DTO);
        }
        public void Edit(InvenPurOrderDto DTO)
        {
            DAL.Edit(DTO);
        }
        public List<InvenPurOrderDto> GetPurchaseInfo(int id)
        {
            return DAL.GetPurchaseInfo(id);
        }
        public List<InvenPurOrderDto> GetPurOrderNo()
        {
            return DAL.GetPurOrderNo();
        }
    }
}
