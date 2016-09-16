using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class ReportBLL
    {
        ReportDAL DAL = new ReportDAL();
        // operaton summary
        public List<ProductDTO> OperationSummary(int compid, int catid, string FromDate, string ToDate)
        {
            return DAL.OperationSummary(compid, catid, FromDate, ToDate);
        }
        public List<ProductDTO> SaleOperationSummary(int compid, int catid, string FromDate, string ToDate)
        {
            return DAL.SaleOperationSummary(compid, catid, FromDate, ToDate);
        }
        public List<ProductDTO> FinalOperationSummary(int compid, int catid, string FromDate, string ToDate)
        {
            return DAL.FinalOperationSummary(compid, catid, FromDate, ToDate);
        }
        public List<ProductDTO> PurchaseOperationSummary(int compid, int catid, string FromDate, string ToDate)
        {
            return DAL.PurchaseOperationSummary(compid, catid, FromDate, ToDate);
        }

        //Central to party product rept
        public List<InvenChangePaymentDtlDto> Return_Central_To_Party_ProductRpt(int retunno)
        {
            return DAL.Return_Central_To_Party_ProductRpt(retunno);
        }
        //load return product send to central company 
        public List<InvenChangePaymentDtlDto> Branchwise_Return_ProductRpt(int retunno)
        {
            return DAL.Branchwise_Return_ProductRpt(retunno);
        }
        //load sales  rating of product 
        public List<InvenSalePaymentDtlDto> SalesRating_BranchWise(int catid, int brid, string FromDate, string ToDate)
        {
            return DAL.SalesRating_BranchWise(catid, brid, FromDate, ToDate);
        }
        //load sales  payument company 
        public List<InvenSalePaymentDtlDto> BranchWise_SalesInfoLaod(int salid, int brid, string FromDate, string ToDate)
        {
            return DAL.BranchWise_SalesInfoLaod(salid, brid, FromDate, ToDate);
        }
        // Sales Info Branch Wisr
        public List<InvenSalePaymentDtlDto> BranchSalesProduct(int salid)
        {
            return DAL.BranchSalesProduct(salid);
        }

        public List<InvenSalePaymentDtlDto> BranchWise_Profit(int salid, int brid, string FromDate, string ToDate)
        {
            return DAL.BranchWise_Profit(salid, brid, FromDate, ToDate);
        }
        // Stock Status In BranchWise
        public List<InvenStoreStatusDto> BranchStockStatus(int proid, int catid, int compid, int brproid)
        {
            return DAL.BranchStockStatus(proid, catid, compid, brproid);
        }
        // Stock Status Details With Client Requirment
        public List<InvenStoreStatusDto> BranchStockStatus_Details(int proid, int catid, int compid, int brproid)
        {
            return DAL.BranchStockStatus_Details(proid, catid, compid, brproid);
        }

        public List<InvenStoreStatusDto> BranchStockStatus_Details_Rpt(int proid, int catid, int compid, int brproid)
        {
            return DAL.BranchStockStatus_Details_Rpt(proid, catid, compid, brproid);

        }
        public List<InvenStoreStatusDto> BranchStockStatus_Rpt(int proid, int catid, int compid, int brproid)
        {
            return DAL.BranchStockStatus_Rpt(proid, catid, compid, brproid);

        }
        // Stock Status In Central
        public List<InvenCentralStoreStatusDTO> CentralStoreStatus(int proid, int catid, int compid)
        {
            return DAL.CentralStoreStatus(proid, catid, compid);
        }
        // Branch Challan 
        public List<InvenCentralChallanDtlDTO> Challan_BranchWiseRpt(int challanid)
        {
            return DAL.Challan_BranchWiseRpt(challanid);
        }
        // purchase due payment
        public List<InvenCentralPurchasePaymentDTO> PurchasePartialPaymentRptDal(int PurPayDtlId)
        {
            return DAL.PurchasePartialPaymentRptDal(PurPayDtlId);
        }
        // purchse order rept
        public List<InvenCentralPurchasePaymentDTO> PurchaseOrderRpt(int purorderno)
        {
            return DAL.PurchaseOrderRpt(purorderno);
        }
        public List<InvenCentralPurchasePaymentDTO> PurchaseProductReptNew(int purid)
        {
            return DAL.PurchaseProductReptNew(purid);
        }
        public List<InvenSalePaymentDtlDto> LoadDailySale(string date, string TotalSale, string GuestCharge, string card, string ExtraBill, string GouestChargePlus, string TotalAmount, string BarSale, string CateringSale, string BekarySale, string RestuarentSale, string GuestSale, string quan)
        {
            return DAL.LoadDailySale(date, TotalSale, GuestCharge, card, ExtraBill, GouestChargePlus, TotalAmount, BarSale, CateringSale, BekarySale, RestuarentSale, GuestSale, quan);
        }
        public List<InvenSalePaymentDtlDto> LoadDailySaleDue(string date, string TotalSale, string GuestCharge, string card, string ExtraBill, string GouestChargePlus, string TotalAmount, string BarSale, string CateringSale, string BekarySale, string RestuarentSale, string GuestSale, string quan)
        {
            return DAL.LoadDailySaleDue(date, TotalSale, GuestCharge, card, ExtraBill, GouestChargePlus, TotalAmount, BarSale, CateringSale, BekarySale, RestuarentSale, GuestSale, quan);
        }
        public List<InvenSalesDetailDTO> GetdtlByDate(string date)
        {
            return DAL.GetdtlByDate(date);
        }
        public List<InvenTempSaleDTO> BranchTempSalesProduct(int memid, string tdate)
        {
            return DAL.BranchTempSalesProduct(memid, tdate);
        }
    }
}
