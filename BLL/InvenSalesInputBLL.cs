using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class InvenSalesInputBLL
    {
        InvenSalesInputDAL DAL = new InvenSalesInputDAL();
        public void Add(InvenSalesInputDTO DTO)
        {
            DAL.Add(DTO);
        }
        public void Edit(InvenSalesInputDTO DTO)
        {
            DAL.Edit(DTO);
        }
        public List<InvenSalesInputDTO> GetInputByDate(string date)
        {
            return DAL.GetInputByDate(date);
        }
        public List<InvenSalesInputDTO> GetInputById(int inputid)
        {
            return DAL.GetInputById(inputid);
        } 
    }
}
