using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
   public class InvenCentralPurOrderBLL
    {
       InvenCentralPurOrderDAL DAL = new InvenCentralPurOrderDAL();
       public void Add(InvenCentralPurOrderDTO DTO)
       {
           DAL.Add(DTO);
       }
       public void Edit(InvenCentralPurOrderDTO DTO)
       {
           DAL.Edit(DTO);
       }
       public List<InvenCentralPurOrderDTO> GetPurchaseOrderInfo(int id, int orderno)
       {
           return DAL.GetPurchaseOrderInfo(id, orderno);
       }
       public List<InvenCentralPurOrderDTO> GetOrderNum_Dropdownlist()
       {
           return DAL.GetOrderNum_Dropdownlist();
       }
       public List<InvenCentralPurOrderDTO> GetOrderNo_CentralPurchasepage(string FromDate, string ToDate, int CompanyId, int Recno)
       {
           return DAL.GetOrderNo_CentralPurchasepage(FromDate, ToDate, CompanyId, Recno);
       }
       // purorder no wise load
       public List<InvenCentralPurOrderDTO> GetOrderNo_CentralPurchasepage_UnderPurOrder(int Recno)
       {
           return DAL.GetOrderNo_CentralPurchasepage_UnderPurOrder(Recno);
       }
       public List<InvenCentralPurOrderDTO> GetPurOrderNo()
       {
           return DAL.GetPurOrderNo();
       }
      
    }
}
