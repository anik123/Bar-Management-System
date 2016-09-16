using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class InvenCentralPurchseBLL
    {
        InvenCentralPurchaseDAL DAL = new InvenCentralPurchaseDAL();
        public void PurchaseInfo(InvenCentralPurchaeInfoDTO DTO)
        {
            DAL.PurchaseInfo(DTO);
        }
        public void SavePurchaseDtl(InvenCentralPurchaseDtlDto DTO)
        {
            DAL.SavePurchaseDtl(DTO);
        }
        public void SavePaymentInfo(InvenCentralPurchasePaymentDTO DTO)
        {
            DAL.SavePaymentInfo(DTO);
        }
        public void SavePurPaymentDtl(InvenCentralPurchasePaymentDTO DTO)
        {
            DAL.SavePurPaymentDtl(DTO);
        }
        // load pur payment dtl id
        public List<InvenCentralPurchasePaymentDtlDto> LoadPharmPaymentDtlId()
        {
            return DAL.LoadPharmPaymentDtlId();
        }
        // purcahse Payment 
        public void EditPurchasePayment(InvenCentralPurchasePaymentDTO DTO)
        {
            DAL.EditPurchasePayment(DTO);
        }
        public List<InvenCentralPurchaeInfoDTO> LoadPurID()
        {
            return DAL.LoadPurID();
        }
        //load central pur payument company 
        public List<InvenCentralPurchasePaymentDTO> CentralPurchasePayment_Client_Load(int purid, int orderid, int Compid, string SalesManName, string FromDate, string ToDate)
        {
            return DAL.CentralPurchasePayment_Client_Load(purid, orderid, Compid, SalesManName, FromDate, ToDate);
        }
        //load pharm pur Due payument company 

        public List<InvenCentralPurchasePaymentDTO> PharmPurchase_Due_Payment(int purid, int orderid, int Compid, string SalesManName, string FromDate, string ToDate)
        {
            return DAL.PharmPurchase_Due_Payment(purid, orderid, Compid, SalesManName, FromDate, ToDate);
        }
        //load sales  payument company 
        public List<InvenCentralPurchasePaymentDTO> PurchaseStatementLaod(int purid, int compid, string FromDate, string ToDate)
        {
            return DAL.PurchaseStatementLaod(purid, compid, FromDate, ToDate);
        }
    }
}
