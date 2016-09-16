using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class InvenSalesBLL
    {
        InvenSalesDAL Dal = new InvenSalesDAL();
        public void SaveSalesInfo(InvenSalesInfoDto DTO)
        {
            Dal.SaveSalesInfo(DTO);
        }

        public void SaveSalesDtl(InvenSalesDtlDto DTO)
        {
            Dal.SaveSalesDtl(DTO);
        }
        public void Edit_Salespayment(InvenSalesPaymentDto DTO)
        {
            Dal.Edit_Salespayment(DTO);
        }
        public void Edit_ChangeProductPage(InvenSalesDtlDto DTO)
        {

            Dal.Edit_ChangeProductPage(DTO);
        }
        public void SaveSalesPaymentInfo(InvenSalesPaymentDto DTO)
        {
            Dal.SaveSalesPaymentInfo(DTO);
        }
        public void SaveSalesPaymentDtl(InvenSalePaymentDtlDto DTO)
        {
            Dal.SaveSalesPaymentDtl(DTO);
        }
        public List<InvenSalesInfoDto> LaadSalInofId()
        {
            return Dal.LaadSalInofId();
        }
        // last purchase price load
        public List<InvenCentralPurchaseDtlDto> LastPurchasePrice_ProductWise(int productid)
        {
            return Dal.LastPurchasePrice_ProductWise(productid);
        }
        public List<InvenSalesDtlDto> LaodProductId_FromSaledtltable(int saldtlid)
        {
            return Dal.LaodProductId_FromSaledtltable(saldtlid);
        }

        //load sales  payument company 
        public List<InvenSalePaymentDtlDto> BranchWise_SalesInfoLaod(int salid, int brid, string FromDate, string ToDate)
        {
            return Dal.BranchWise_SalesInfoLaod(salid, brid, FromDate, ToDate);
        }
        //load sales  payument company 
        public List<InvenSalePaymentDtlDto> BranchWise_SalesInfoLaod_ChangeProduct(int salid, int brid, string CusName, string CusMbNo, string CusRemarks, string Cuscontactadd, string FromDate)
        {
            return Dal.BranchWise_SalesInfoLaod_ChangeProduct(salid, brid, CusName, CusMbNo, CusRemarks, Cuscontactadd, FromDate);
        }
        public List<InvenSalePaymentDtlDto> LoadMemberDue(int MemId, int SalId, int SalePaymentId)
        {
            return Dal.LoadMemberDue(MemId, SalId, SalePaymentId);
        }
        public List<InvenSalePaymentDtlDto> LoadSalesDate(string FromDate, string ToDate)
        {
            return Dal.LoadSalesDate(FromDate, ToDate);
        }
        public List<InvenSalePaymentDtlDto> LoadDailySale(string date)
        {
            return Dal.LoadDailySale(date);
        }
        public List<InvenSalePaymentDtlDto> LoadDailyGuestCharge(string date)
        {
            return Dal.LoadDailyGuestCharge(date);
        }
        public List<InvenSalePaymentDtlDto> LoadDailyResturent(string date)
        {
            return Dal.LoadDailyResturent(date);
        }
        public List<InvenSalePaymentDtlDto> LoadDailyCatering(string date)
        {
            return Dal.LoadDailyCatering(date);
        }
        public List<InvenSalePaymentDtlDto> LoadDailyBekary(string date)
        {
            return Dal.LoadDailyBekary(date);
        }
        public List<InvenSalePaymentDtlDto> LoadActiveMember(int MemId, int SalId, int SalePaymentId)
        {
            return Dal.LoadActiveMember(MemId, SalId, SalePaymentId);
        }
        public List<InvenSalePaymentDtlDto> LoadActiveMemberDateWise(int MemId, string date)
        {
            return Dal.LoadActiveMemberDateWise(MemId, date);
        }
        public List<InvenSalePaymentDtlDto> DeleteAdjustment(int saldtlid)
        {
            return Dal.DeleteAdjustment(saldtlid);
        }
        public void DeleteAdjustmentById(int saldtlid)
        {
            Dal.DeleteAdjustmentById(saldtlid);
        }
        public void Edit_Adjustpayment(InvenSalesPaymentDto DTO)
        {
            Dal.Edit_Adjustpayment(DTO);
        }
        public List<InvenSalePaymentDtlDto> GetPaymentId(int salid)
        {
            return Dal.GetPaymentId(salid);
        }
        public void Edit_AdjustpaymentDtl(InvenSalePaymentDtlDto DTO)
        {
            Dal.Edit_AdjustpaymentDtl(DTO);
        }
        public void DeleteSalePayment(int Salid)
        {
            Dal.DeleteSalePayment(Salid);
        }
        public void DeleteSalePaymentDtl(int Salid)
        {
            Dal.DeleteSalePaymentDtl(Salid);
        }
        public void DeleteSalInfo(int Salid)
        {
            Dal.DeleteSalInfo(Salid);
        }
        public List<InvenSalePaymentDtlDto> LoadDailySaleWihoutCocktail(string date)
        {
            return Dal.LoadDailySaleWihoutCocktail(date);
        }
        public List<InvenSalePaymentDtlDto> LoadDailySaleCocktail(string date)
        {
            return Dal.LoadDailySaleCocktail(date);
        }




        //DUE SECTION
        public List<InvenSalePaymentDtlDto> LoadDailySaleWihoutCocktailDue(string date)
        {
            return Dal.LoadDailySaleWihoutCocktailDue(date);
        }
        public List<InvenSalePaymentDtlDto> LoadDailySaleCocktailDue(string date)
        {
            return Dal.LoadDailySaleCocktailDue(date);
        }


        public List<InvenSalePaymentDtlDto> LoadSalesDateDue(string FromDate, string ToDate)
        {
            return Dal.LoadSalesDateDue(FromDate, ToDate);
        }
        public List<InvenSalePaymentDtlDto> LoadDailySaleDue(string date)
        {
            return Dal.LoadDailySaleDue(date);
        }
        public List<InvenSalePaymentDtlDto> LoadDailyGuestChargeDue(string date)
        {
            return Dal.LoadDailyGuestChargeDue(date);
        }
        public List<InvenSalePaymentDtlDto> LoadDailyResturentDue(string date)
        {
            return Dal.LoadDailyResturentDue(date);
        }
        public List<InvenSalePaymentDtlDto> LoadDailyCateringDue(string date)
        {
            return Dal.LoadDailyCateringDue(date);
        }
        public List<InvenSalePaymentDtlDto> LoadDailyBekaryDue(string date)
        {
            return Dal.LoadDailyBekaryDue(date);
        }





    }
}
