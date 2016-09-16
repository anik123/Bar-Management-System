using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class PurchaseDueBLL
    {
        PurchaseDueDAL PDal = new PurchaseDueDAL();
        // save pur payment dtl in due page
        public void SavePurchasePaymentDtl_Pay_Due(InvenCentralPurchasePaymentDtlDto DTO)
        {
            PDal.SavePurchasePaymentDtl_Pay_Due(DTO);
        }
        //load pharm pur Due payument company 
        public List<InvenCentralPurchasePaymentDTO> CentralPurchase_Due_Payment(int purid, int orderid, int Compid, string SalesManName, string FromDate, string ToDate)
        {
            return PDal.CentralPurchase_Due_Payment(purid, orderid, Compid, SalesManName, FromDate, ToDate);
        }
        public List<InvenCentralPurchasePaymentDTO> GetPurchaseDue(int payid, int Compid, string SalesManName)
        {
            return PDal.GetPurchaseDue(payid, Compid, SalesManName);
        }

        // view dtl dal
        public List<InvenCentralPurchasePaymentDTO> GetPyurchaseDueDtalil(int payid, int paymentdtlid, int Compid, string SalesManName)
        {
            return PDal.GetPyurchaseDueDtalil(payid, paymentdtlid, Compid, SalesManName);
        }
    }
}
