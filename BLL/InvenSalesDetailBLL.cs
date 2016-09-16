using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class InvenSalesDetailBLL
    {
        InvenSalesDetailDAL DAL = new InvenSalesDetailDAL();
        public void Add(InvenSalesDetailDTO DTO)
        {
            DAL.Add(DTO);
        }
        public void Edit(InvenSalesDetailDTO DTO)
        {
            DAL.Edit(DTO);
        }
        public void EditStock(InvenSalesDetailDTO DTO)
        {
            DAL.EditStock(DTO);
        }
        public List<InvenSalesDetailDTO> GetdtlId(int ProId, string date)
        {
            return DAL.GetdtlId(ProId, date);
        }
        public List<InvenSalesDetailDTO> GetdtlIdAfter(int ProId, string date)
        {
            return DAL.GetdtlIdAfter(ProId, date);
        }
        public void EditStockOnlyStockInPage(InvenSalesDetailDTO DTO)
        {
            DAL.EditStockOnlyStockInPage(DTO);
        }
        public void EditTotalQuan(InvenSalesDetailDTO DTO)
        {
            DAL.EditTotalQuan(DTO);
        }
    }
}
