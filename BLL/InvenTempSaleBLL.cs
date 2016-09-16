using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class InvenTempSaleBLL
    {
        InvenTempSaleDAL DAL = new InvenTempSaleDAL();
        public void Add(InvenTempSaleDTO DTO)
        {
            DAL.Add(DTO);
        }
        public void Delete(int MemId)
        {
            DAL.Delete(MemId);
        }
        public void DeleteTempId(int TempId)
        {
            DAL.DeleteTempId(TempId);
        }
        public void Delete(int MemId, int ProId)
        {
            DAL.Delete(MemId, ProId);
        }
        public List<InvenTempSaleDTO> GetAllInfo(int MemId)
        {
            return DAL.GetAllInfo(MemId);
        }
        public List<InvenTempSaleDTO> LoadTempId()
        {
            return DAL.LoadTempId();
        }
        public List<InvenTempSaleDTO> GetOpenBalanceDate(string date)
        {
            return DAL.GetOpenBalanceDate(date);
        }
        public List<InvenTempSaleDTO> getTempById(int memid, string date)
        {
            return DAL.getTempById(memid, date);
        }
        public void DeleteByDate(string date)
        {
            DAL.DeleteByDate(date);
        }
        public List<InvenTempSaleDTO> GetAllByTempId(int temId)
        {
            return DAL.GetAllByTempId(temId);
        }
        public void DeleteByTempId(int TempId)
        {
            DAL.DeleteByTempId(TempId);
        }
    }
}
