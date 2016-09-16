
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, and Azure
-- --------------------------------------------------
-- Date Created: 05/14/2013 10:49:05
-- Generated from EDMX file: D:\Grameenbikash Accounting\Inventory\DAL\Inventory.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Inventory];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_AccBalanceSheetRpt_AccMainHeads]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccBalanceSheetRpt] DROP CONSTRAINT [FK_AccBalanceSheetRpt_AccMainHeads];
GO
IF OBJECT_ID(N'[dbo].[FK_AccBalanceSheetRpt_AccSubCode1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccBalanceSheetRpt] DROP CONSTRAINT [FK_AccBalanceSheetRpt_AccSubCode1];
GO
IF OBJECT_ID(N'[dbo].[FK_AccCashFlowReport_AccSubCode1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccCashFlowReport] DROP CONSTRAINT [FK_AccCashFlowReport_AccSubCode1];
GO
IF OBJECT_ID(N'[dbo].[FK_AccCOAInfo_AccSubCode2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccCOAInfoes] DROP CONSTRAINT [FK_AccCOAInfo_AccSubCode2];
GO
IF OBJECT_ID(N'[dbo].[FK_AccIncomeStatementRpt_AccMainHeads]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccIncomeStatementRpt] DROP CONSTRAINT [FK_AccIncomeStatementRpt_AccMainHeads];
GO
IF OBJECT_ID(N'[dbo].[FK_AccJournalEntry_AccCOAInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccJournalEntry] DROP CONSTRAINT [FK_AccJournalEntry_AccCOAInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_AccJournalEntry_AccSubCode2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccJournalEntry] DROP CONSTRAINT [FK_AccJournalEntry_AccSubCode2];
GO
IF OBJECT_ID(N'[dbo].[FK_AccJournalEntry_AccSubVouchers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccJournalEntry] DROP CONSTRAINT [FK_AccJournalEntry_AccSubVouchers];
GO
IF OBJECT_ID(N'[dbo].[FK_AccLedger_AccJournalEntry]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccLedger] DROP CONSTRAINT [FK_AccLedger_AccJournalEntry];
GO
IF OBJECT_ID(N'[dbo].[FK_AccLiabilitiesRpt_AccMainHeads]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccLiabilitiesRpt] DROP CONSTRAINT [FK_AccLiabilitiesRpt_AccMainHeads];
GO
IF OBJECT_ID(N'[dbo].[FK_AccSubCode1_AccMainHeads]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccSubCode1] DROP CONSTRAINT [FK_AccSubCode1_AccMainHeads];
GO
IF OBJECT_ID(N'[dbo].[FK_AccSubCode2_AccMainHeads]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccSubCode2] DROP CONSTRAINT [FK_AccSubCode2_AccMainHeads];
GO
IF OBJECT_ID(N'[dbo].[FK_AccSubCode2_AccSubCode1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccSubCode2] DROP CONSTRAINT [FK_AccSubCode2_AccSubCode1];
GO
IF OBJECT_ID(N'[dbo].[FK_AccSubVoucher_AccMainVoucher]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccSubVouchers] DROP CONSTRAINT [FK_AccSubVoucher_AccMainVoucher];
GO
IF OBJECT_ID(N'[dbo].[FK_AccSubVouchers_AccMainVouchers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccSubVouchers] DROP CONSTRAINT [FK_AccSubVouchers_AccMainVouchers];
GO
IF OBJECT_ID(N'[dbo].[FK_AccTransDetails_AccCOAInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccTransDetails] DROP CONSTRAINT [FK_AccTransDetails_AccCOAInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_AccTransDetails_AccCOAInfoes1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccTransDetails] DROP CONSTRAINT [FK_AccTransDetails_AccCOAInfoes1];
GO
IF OBJECT_ID(N'[dbo].[FK_AccTransDetails_AccSubCode2]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccTransDetails] DROP CONSTRAINT [FK_AccTransDetails_AccSubCode2];
GO
IF OBJECT_ID(N'[dbo].[FK_AccTransDetails_AccSubCode21]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccTransDetails] DROP CONSTRAINT [FK_AccTransDetails_AccSubCode21];
GO
IF OBJECT_ID(N'[dbo].[FK_AccTransDetails_AccSubVouchers]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccTransDetails] DROP CONSTRAINT [FK_AccTransDetails_AccSubVouchers];
GO
IF OBJECT_ID(N'[dbo].[FK_AccTransDetails_AccSubVouchers1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccTransDetails] DROP CONSTRAINT [FK_AccTransDetails_AccSubVouchers1];
GO
IF OBJECT_ID(N'[dbo].[FK_AccTransDetails_AccTranItem]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccTransDetails] DROP CONSTRAINT [FK_AccTransDetails_AccTranItem];
GO
IF OBJECT_ID(N'[dbo].[FK_CashFlowReport_AccCOAInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccCashFlowReport] DROP CONSTRAINT [FK_CashFlowReport_AccCOAInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_CashFlowReport_CashFlowEntity]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[AccCashFlowReport] DROP CONSTRAINT [FK_CashFlowReport_CashFlowEntity];
GO
IF OBJECT_ID(N'[dbo].[FK_CategoryProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_CategoryProduct];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpEducations_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmpEducations] DROP CONSTRAINT [FK_EmpEducations_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpExperienceInfoes_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmpExperienceInfoes] DROP CONSTRAINT [FK_EmpExperienceInfoes_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_Employees_EmpSpecialists]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_EmpSpecialists];
GO
IF OBJECT_ID(N'[dbo].[FK_Employees_EmpTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_EmpTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_Employees_InvenBranchProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Employees] DROP CONSTRAINT [FK_Employees_InvenBranchProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpSpecialists_EmpTypes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmpSpecialists] DROP CONSTRAINT [FK_EmpSpecialists_EmpTypes];
GO
IF OBJECT_ID(N'[dbo].[FK_EmpTrainings_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[EmpTrainings] DROP CONSTRAINT [FK_EmpTrainings_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_Expenses_ExpenseHeads]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Expenses] DROP CONSTRAINT [FK_Expenses_ExpenseHeads];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenBranchProfile_InvenCompProfileInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenBranchProfile] DROP CONSTRAINT [FK_InvenBranchProfile_InvenCompProfileInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenCenteralStoreStatus_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenCenteralStoreStatus] DROP CONSTRAINT [FK_InvenCenteralStoreStatus_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenCentralChallanDtl_InvenCentralChallanInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenCentralChallanDtl] DROP CONSTRAINT [FK_InvenCentralChallanDtl_InvenCentralChallanInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenCentralChallanDtl_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenCentralChallanDtl] DROP CONSTRAINT [FK_InvenCentralChallanDtl_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenCentralChallanInfo_InvenBranchProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenCentralChallanInfo] DROP CONSTRAINT [FK_InvenCentralChallanInfo_InvenBranchProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenCentralPurchaseDtls_InvenCentralPurchaseInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenCentralPurchaseDtls] DROP CONSTRAINT [FK_InvenCentralPurchaseDtls_InvenCentralPurchaseInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenCentralPurchaseDtls_Products1]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenCentralPurchaseDtls] DROP CONSTRAINT [FK_InvenCentralPurchaseDtls_Products1];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenCentralPurchcasePaymentDtls_InvenCentralPurchcasePayments]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenCentralPurchcasePaymentDtls] DROP CONSTRAINT [FK_InvenCentralPurchcasePaymentDtls_InvenCentralPurchcasePayments];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenCentralPurchcasePaymentDtls_PayBankAccountInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenCentralPurchcasePaymentDtls] DROP CONSTRAINT [FK_InvenCentralPurchcasePaymentDtls_PayBankAccountInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenCentralPurchcasePayments_CompanyInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenCentralPurchcasePayments] DROP CONSTRAINT [FK_InvenCentralPurchcasePayments_CompanyInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenCentralPurchcasePayments_InvenCentralPurchaseInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenCentralPurchcasePayments] DROP CONSTRAINT [FK_InvenCentralPurchcasePayments_InvenCentralPurchaseInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenCentralPurRequisition_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenCentralPurRequisition] DROP CONSTRAINT [FK_InvenCentralPurRequisition_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenCentralReturn_InvenBranchReturn]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenCentralReturn] DROP CONSTRAINT [FK_InvenCentralReturn_InvenBranchReturn];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenCentrealPurOrder_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenCentrealPurOrder] DROP CONSTRAINT [FK_InvenCentrealPurOrder_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenChangeDtls_InvenChangeInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenChangeDtls] DROP CONSTRAINT [FK_InvenChangeDtls_InvenChangeInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenChangeDtls_InvenSaleDtls]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenChangeDtls] DROP CONSTRAINT [FK_InvenChangeDtls_InvenSaleDtls];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenChangeDtls_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenChangeDtls] DROP CONSTRAINT [FK_InvenChangeDtls_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenChangeInfoes_InvenBranchProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenChangeInfoes] DROP CONSTRAINT [FK_InvenChangeInfoes_InvenBranchProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenChangePaymentDtls_InvenChangeInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenChangePaymentDtls] DROP CONSTRAINT [FK_InvenChangePaymentDtls_InvenChangeInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenChangePayments_InvenChangeInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenChangePayments] DROP CONSTRAINT [FK_InvenChangePayments_InvenChangeInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenPerRequisition_InvenBranchProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenPerRequisition] DROP CONSTRAINT [FK_InvenPerRequisition_InvenBranchProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenPerRequisition_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenPerRequisition] DROP CONSTRAINT [FK_InvenPerRequisition_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenPurOrder_InvenBranchProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenPurOrder] DROP CONSTRAINT [FK_InvenPurOrder_InvenBranchProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenPurOrder_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenPurOrder] DROP CONSTRAINT [FK_InvenPurOrder_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenReorder_InvenBranchProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenReorder] DROP CONSTRAINT [FK_InvenReorder_InvenBranchProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenReorder_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenReorder] DROP CONSTRAINT [FK_InvenReorder_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenSaleDtls_InvenSalesInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenSaleDtls] DROP CONSTRAINT [FK_InvenSaleDtls_InvenSalesInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenSaleDtls_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenSaleDtls] DROP CONSTRAINT [FK_InvenSaleDtls_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenSalePayments_InvenSalesInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenSalePayments] DROP CONSTRAINT [FK_InvenSalePayments_InvenSalesInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenSalesInfoes_InvenSalesInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenSalesInfoes] DROP CONSTRAINT [FK_InvenSalesInfoes_InvenSalesInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenSalesPaymentDtls_InvenSalesInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenSalesPaymentDtls] DROP CONSTRAINT [FK_InvenSalesPaymentDtls_InvenSalesInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenStoreStatus_InvenBranchProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenStoreStatus] DROP CONSTRAINT [FK_InvenStoreStatus_InvenBranchProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_InvenStoreStatus_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[InvenStoreStatus] DROP CONSTRAINT [FK_InvenStoreStatus_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_PayBankAccountInfoes_InvenBranchProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PayBankAccountInfoes] DROP CONSTRAINT [FK_PayBankAccountInfoes_InvenBranchProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_PayBankAccountInfoes_PayAccountTypeInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PayBankAccountInfoes] DROP CONSTRAINT [FK_PayBankAccountInfoes_PayAccountTypeInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_PayBankAccountInfoes_PayBankInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PayBankAccountInfoes] DROP CONSTRAINT [FK_PayBankAccountInfoes_PayBankInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_PayBankTransectionDtlInfo_PayBankTransectionInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PayBankTransectionDtlInfoes] DROP CONSTRAINT [FK_PayBankTransectionDtlInfo_PayBankTransectionInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_PayBankTransectionDtlInfoes_InvenBranchProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PayBankTransectionDtlInfoes] DROP CONSTRAINT [FK_PayBankTransectionDtlInfoes_InvenBranchProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_PayBankTransectionInfo_PayBankAccountInfo]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PayBankTransectionInfoes] DROP CONSTRAINT [FK_PayBankTransectionInfo_PayBankAccountInfo];
GO
IF OBJECT_ID(N'[dbo].[FK_PayCompanyCashEntries_InvenBranchProfile]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PayCompanyCashEntries] DROP CONSTRAINT [FK_PayCompanyCashEntries_InvenBranchProfile];
GO
IF OBJECT_ID(N'[dbo].[FK_PayUserRole_Employees]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PayUserRole] DROP CONSTRAINT [FK_PayUserRole_Employees];
GO
IF OBJECT_ID(N'[dbo].[FK_PayUserRole_PayRole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PayUserRole] DROP CONSTRAINT [FK_PayUserRole_PayRole];
GO
IF OBJECT_ID(N'[dbo].[FK_Products_CompanyInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_Products_CompanyInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchaseDtls_Products]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseDtls] DROP CONSTRAINT [FK_PurchaseDtls_Products];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchaseDtls_PurchaseInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseDtls] DROP CONSTRAINT [FK_PurchaseDtls_PurchaseInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchaseInfoes_CompanyInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchaseInfoes] DROP CONSTRAINT [FK_PurchaseInfoes_CompanyInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchcasePaymentDtl_PayBankAccountInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchcasePaymentDtl] DROP CONSTRAINT [FK_PurchcasePaymentDtl_PayBankAccountInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchcasePaymentDtl_PurchaseInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchcasePaymentDtl] DROP CONSTRAINT [FK_PurchcasePaymentDtl_PurchaseInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchcasePayments_PayBankAccountInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchcasePayments] DROP CONSTRAINT [FK_PurchcasePayments_PayBankAccountInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_PurchcasePayments_PurchaseInfoes]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[PurchcasePayments] DROP CONSTRAINT [FK_PurchcasePayments_PurchaseInfoes];
GO
IF OBJECT_ID(N'[dbo].[FK_UnitProduct]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Products] DROP CONSTRAINT [FK_UnitProduct];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[AccBalanceSheetRpt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccBalanceSheetRpt];
GO
IF OBJECT_ID(N'[dbo].[AccCashFlowEntity]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccCashFlowEntity];
GO
IF OBJECT_ID(N'[dbo].[AccCashFlowReport]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccCashFlowReport];
GO
IF OBJECT_ID(N'[dbo].[AccCOAInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccCOAInfoes];
GO
IF OBJECT_ID(N'[dbo].[AccIncomeStatementRpt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccIncomeStatementRpt];
GO
IF OBJECT_ID(N'[dbo].[AccJournalEntry]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccJournalEntry];
GO
IF OBJECT_ID(N'[dbo].[AccLedger]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccLedger];
GO
IF OBJECT_ID(N'[dbo].[AccLiabilitiesRpt]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccLiabilitiesRpt];
GO
IF OBJECT_ID(N'[dbo].[AccMainHeads]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccMainHeads];
GO
IF OBJECT_ID(N'[dbo].[AccMainVouchers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccMainVouchers];
GO
IF OBJECT_ID(N'[dbo].[AccSubCode1]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccSubCode1];
GO
IF OBJECT_ID(N'[dbo].[AccSubCode2]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccSubCode2];
GO
IF OBJECT_ID(N'[dbo].[AccSubVouchers]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccSubVouchers];
GO
IF OBJECT_ID(N'[dbo].[AccTranItem]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccTranItem];
GO
IF OBJECT_ID(N'[dbo].[AccTransDetails]', 'U') IS NOT NULL
    DROP TABLE [dbo].[AccTransDetails];
GO
IF OBJECT_ID(N'[dbo].[Categories]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Categories];
GO
IF OBJECT_ID(N'[dbo].[CompanyInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CompanyInfoes];
GO
IF OBJECT_ID(N'[dbo].[EmpEducations]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmpEducations];
GO
IF OBJECT_ID(N'[dbo].[EmpExperienceInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmpExperienceInfoes];
GO
IF OBJECT_ID(N'[dbo].[Employees]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Employees];
GO
IF OBJECT_ID(N'[dbo].[EmpSpecialists]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmpSpecialists];
GO
IF OBJECT_ID(N'[dbo].[EmpTrainings]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmpTrainings];
GO
IF OBJECT_ID(N'[dbo].[EmpTypes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[EmpTypes];
GO
IF OBJECT_ID(N'[dbo].[ExpenseHeads]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ExpenseHeads];
GO
IF OBJECT_ID(N'[dbo].[Expenses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Expenses];
GO
IF OBJECT_ID(N'[dbo].[InvenBranchProfile]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenBranchProfile];
GO
IF OBJECT_ID(N'[dbo].[InvenBranchReturn]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenBranchReturn];
GO
IF OBJECT_ID(N'[dbo].[InvenCenteralStoreStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenCenteralStoreStatus];
GO
IF OBJECT_ID(N'[dbo].[InvenCentralChallanDtl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenCentralChallanDtl];
GO
IF OBJECT_ID(N'[dbo].[InvenCentralChallanInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenCentralChallanInfo];
GO
IF OBJECT_ID(N'[dbo].[InvenCentralPurchaseDtls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenCentralPurchaseDtls];
GO
IF OBJECT_ID(N'[dbo].[InvenCentralPurchaseInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenCentralPurchaseInfoes];
GO
IF OBJECT_ID(N'[dbo].[InvenCentralPurchcasePaymentDtls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenCentralPurchcasePaymentDtls];
GO
IF OBJECT_ID(N'[dbo].[InvenCentralPurchcasePayments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenCentralPurchcasePayments];
GO
IF OBJECT_ID(N'[dbo].[InvenCentralPurRequisition]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenCentralPurRequisition];
GO
IF OBJECT_ID(N'[dbo].[InvenCentralReturn]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenCentralReturn];
GO
IF OBJECT_ID(N'[dbo].[InvenCentrealPurOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenCentrealPurOrder];
GO
IF OBJECT_ID(N'[dbo].[InvenChangeDtls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenChangeDtls];
GO
IF OBJECT_ID(N'[dbo].[InvenChangeInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenChangeInfoes];
GO
IF OBJECT_ID(N'[dbo].[InvenChangePaymentDtls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenChangePaymentDtls];
GO
IF OBJECT_ID(N'[dbo].[InvenChangePayments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenChangePayments];
GO
IF OBJECT_ID(N'[dbo].[InvenCompProfileInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenCompProfileInfo];
GO
IF OBJECT_ID(N'[dbo].[InvenPerRequisition]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenPerRequisition];
GO
IF OBJECT_ID(N'[dbo].[InvenPurOrder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenPurOrder];
GO
IF OBJECT_ID(N'[dbo].[InvenReorder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenReorder];
GO
IF OBJECT_ID(N'[dbo].[InvenSaleDtls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenSaleDtls];
GO
IF OBJECT_ID(N'[dbo].[InvenSalePayments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenSalePayments];
GO
IF OBJECT_ID(N'[dbo].[InvenSalesInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenSalesInfoes];
GO
IF OBJECT_ID(N'[dbo].[InvenSalesPaymentDtls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenSalesPaymentDtls];
GO
IF OBJECT_ID(N'[dbo].[InvenStoreStatus]', 'U') IS NOT NULL
    DROP TABLE [dbo].[InvenStoreStatus];
GO
IF OBJECT_ID(N'[dbo].[Log_AccJournal]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Log_AccJournal];
GO
IF OBJECT_ID(N'[dbo].[Log_InvenReorder]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Log_InvenReorder];
GO
IF OBJECT_ID(N'[dbo].[Log_PayEmpInfo]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Log_PayEmpInfo];
GO
IF OBJECT_ID(N'[dbo].[Log_PayuserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Log_PayuserRole];
GO
IF OBJECT_ID(N'[dbo].[PayAccountTypeInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PayAccountTypeInfoes];
GO
IF OBJECT_ID(N'[dbo].[PayAsset]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PayAsset];
GO
IF OBJECT_ID(N'[dbo].[PayBankAccountInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PayBankAccountInfoes];
GO
IF OBJECT_ID(N'[dbo].[PayBankInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PayBankInfoes];
GO
IF OBJECT_ID(N'[dbo].[PayBankTransectionDtlInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PayBankTransectionDtlInfoes];
GO
IF OBJECT_ID(N'[dbo].[PayBankTransectionInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PayBankTransectionInfoes];
GO
IF OBJECT_ID(N'[dbo].[PayCompanyCashEntries]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PayCompanyCashEntries];
GO
IF OBJECT_ID(N'[dbo].[PayRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PayRole];
GO
IF OBJECT_ID(N'[dbo].[PayUserRole]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PayUserRole];
GO
IF OBJECT_ID(N'[dbo].[Products]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Products];
GO
IF OBJECT_ID(N'[dbo].[PurchaseDtls]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchaseDtls];
GO
IF OBJECT_ID(N'[dbo].[PurchaseInfoes]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchaseInfoes];
GO
IF OBJECT_ID(N'[dbo].[PurchcasePaymentDtl]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchcasePaymentDtl];
GO
IF OBJECT_ID(N'[dbo].[PurchcasePayments]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PurchcasePayments];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO
IF OBJECT_ID(N'[dbo].[Units]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Units];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'AccBalanceSheetRpts'
CREATE TABLE [dbo].[AccBalanceSheetRpts] (
    [BalanceShtId] int IDENTITY(1,1) NOT NULL,
    [MainHeadId] int  NULL,
    [SubCode1Id] int  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [Priority] int  NULL,
    [ActiveStatus] varchar(50)  NULL
);
GO

-- Creating table 'AccCashFlowEntities'
CREATE TABLE [dbo].[AccCashFlowEntities] (
    [CFEId] int IDENTITY(1,1) NOT NULL,
    [CFEName] varchar(max)  NULL,
    [Priority] int  NULL,
    [CreateDate] datetime  NULL,
    [CreateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL
);
GO

-- Creating table 'AccCashFlowReports'
CREATE TABLE [dbo].[AccCashFlowReports] (
    [CFRId] int IDENTITY(1,1) NOT NULL,
    [CFEId] int  NULL,
    [ActiveStatus] varchar(50)  NULL,
    [SubCode_1Id] int  NULL,
    [COAId] int  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'AccCOAInfoes'
CREATE TABLE [dbo].[AccCOAInfoes] (
    [COAId] int IDENTITY(1,1) NOT NULL,
    [COAACCId] nvarchar(max)  NULL,
    [AccountName] nvarchar(max)  NULL,
    [AID] bigint  NULL,
    [SubCode_2Id] int  NULL,
    [APPID] bigint  NULL,
    [Description] nvarchar(max)  NULL,
    [Status] nchar(10)  NULL,
    [Balance] float  NULL,
    [OpeningDate] datetime  NULL,
    [OpenBy] nchar(10)  NULL,
    [UpdateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL
);
GO

-- Creating table 'AccIncomeStatementRpts'
CREATE TABLE [dbo].[AccIncomeStatementRpts] (
    [InStaRptId] int IDENTITY(1,1) NOT NULL,
    [MainHeadId] int  NULL,
    [SubCode1Id] int  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [Priority] int  NULL,
    [ActiveStatus] varchar(50)  NULL
);
GO

-- Creating table 'AccJournalEntries'
CREATE TABLE [dbo].[AccJournalEntries] (
    [JournalId] int IDENTITY(1,1) NOT NULL,
    [SubCode2Id] int  NULL,
    [COAId] int  NULL,
    [SubVoucherId] int  NULL,
    [TransectionNo] int  NOT NULL,
    [JournalType] nvarchar(max)  NULL,
    [DRAmount] float  NULL,
    [CRAmount] float  NULL,
    [VONO] nvarchar(max)  NULL,
    [MRNO] nvarchar(max)  NULL,
    [TransectionDate] datetime  NULL,
    [Remarks] nvarchar(max)  NULL,
    [PostLeadgerStatus] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [CreateBy] varchar(50)  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'AccLedgers'
CREATE TABLE [dbo].[AccLedgers] (
    [LedgerId] int IDENTITY(1,1) NOT NULL,
    [JournalId] int  NULL,
    [OPBAL] float  NULL,
    [DRAmount] float  NULL,
    [CRAmount] float  NULL,
    [CLBAL] float  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL
);
GO

-- Creating table 'AccLiabilitiesRpts'
CREATE TABLE [dbo].[AccLiabilitiesRpts] (
    [LiabRptId] int IDENTITY(1,1) NOT NULL,
    [MainHeadId] int  NULL,
    [SubCode1Id] int  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [Priority] int  NULL,
    [ActiveStatus] varchar(50)  NULL
);
GO

-- Creating table 'AccMainHeads'
CREATE TABLE [dbo].[AccMainHeads] (
    [MainHeadId] int IDENTITY(1,1) NOT NULL,
    [MainHadeNum] varchar(50)  NULL,
    [MainHeadName] varchar(150)  NULL,
    [Description] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [CreateBy] varchar(50)  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL,
    [AID] int  NULL
);
GO

-- Creating table 'AccMainVouchers'
CREATE TABLE [dbo].[AccMainVouchers] (
    [MainVoucherId] int IDENTITY(1,1) NOT NULL,
    [MainVoucherCode] varchar(50)  NULL,
    [MainVoucherName] varchar(150)  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'AccSubCode1'
CREATE TABLE [dbo].[AccSubCode1] (
    [SubCode_1Id] int IDENTITY(1,1) NOT NULL,
    [SubCode_1Num] nvarchar(max)  NOT NULL,
    [SubCode_1Name] nvarchar(550)  NULL,
    [AID] int  NULL,
    [Description] nvarchar(500)  NULL,
    [MainHeadId] int  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL,
    [AssetType] int  NULL,
    [Balance] float  NULL
);
GO

-- Creating table 'AccSubCode2'
CREATE TABLE [dbo].[AccSubCode2] (
    [SubCode2_Id] int IDENTITY(1,1) NOT NULL,
    [SubCode2_Num] nvarchar(max)  NOT NULL,
    [SubCode_2Name] varchar(550)  NULL,
    [AID] int  NULL,
    [Description] varchar(500)  NULL,
    [MainHeadId] int  NULL,
    [SubCode_1Id] int  NULL,
    [Balance] float  NULL,
    [AssetType] int  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL,
    [Depreciation] varchar(550)  NULL
);
GO

-- Creating table 'AccSubVouchers'
CREATE TABLE [dbo].[AccSubVouchers] (
    [SubVoucherId] int IDENTITY(1,1) NOT NULL,
    [SubVoucherCode] varchar(50)  NULL,
    [SubVoucherName] varchar(250)  NULL,
    [MainVoucherId] int  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'AccTranItems'
CREATE TABLE [dbo].[AccTranItems] (
    [TranId] int IDENTITY(1,1) NOT NULL,
    [TranName] varchar(max)  NOT NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'AccTransDetails'
CREATE TABLE [dbo].[AccTransDetails] (
    [AccTransDtlId] int IDENTITY(1,1) NOT NULL,
    [TranId] int  NOT NULL,
    [DRCOAId] int  NOT NULL,
    [DRSubCoId2] int  NOT NULL,
    [DrSubVoucherId] int  NOT NULL,
    [CRCOAId] int  NOT NULL,
    [CRSubCoId2] int  NOT NULL,
    [CrSubVoucherId] int  NOT NULL,
    [CreateDate] datetime  NULL,
    [CreateBy] varchar(50)  NULL
);
GO

-- Creating table 'Categories'
CREATE TABLE [dbo].[Categories] (
    [CatId] int IDENTITY(1,1) NOT NULL,
    [CategoryName] nvarchar(max)  NOT NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'CompanyInfoes'
CREATE TABLE [dbo].[CompanyInfoes] (
    [CompId] int IDENTITY(1,1) NOT NULL,
    [CompName] nvarchar(max)  NULL,
    [CompPermanantAdd] nvarchar(max)  NULL,
    [CompPhone] nvarchar(max)  NULL,
    [CompMobile1] nvarchar(max)  NULL,
    [CompMobile2] nvarchar(max)  NULL,
    [CompEmail] nvarchar(max)  NULL,
    [CompDes] nvarchar(max)  NULL,
    [CompPresentAdd] nvarchar(max)  NULL,
    [Website] nvarchar(max)  NULL,
    [CompStatus] varchar(50)  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'EmpEducations'
CREATE TABLE [dbo].[EmpEducations] (
    [EduId] int IDENTITY(1,1) NOT NULL,
    [EmpId] int  NULL,
    [ResultType] varchar(50)  NULL,
    [Division] varchar(50)  NULL,
    [Cgpa] varchar(50)  NULL,
    [InstituteName] varchar(550)  NULL,
    [Board] varchar(50)  NULL,
    [PassingYear] varchar(50)  NULL,
    [Eximination] varchar(550)  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [Updatedate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [Note] varchar(500)  NULL
);
GO

-- Creating table 'EmpExperienceInfoes'
CREATE TABLE [dbo].[EmpExperienceInfoes] (
    [ExperienceId] int IDENTITY(1,1) NOT NULL,
    [EmpId] int  NULL,
    [Disignation] varchar(50)  NULL,
    [FromDate] datetime  NULL,
    [ToDate] datetime  NULL,
    [OrganizationName] varchar(500)  NULL,
    [Responsibility] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [CreateBy] varchar(50)  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL,
    [Year] varchar(500)  NULL
);
GO

-- Creating table 'Employees'
CREATE TABLE [dbo].[Employees] (
    [EmpId] int IDENTITY(1,1) NOT NULL,
    [EmpName] nvarchar(max)  NULL,
    [SurName] nvarchar(max)  NULL,
    [Gender] nvarchar(max)  NULL,
    [Age] nvarchar(max)  NULL,
    [DOB] datetime  NULL,
    [Address] nvarchar(max)  NULL,
    [Phone] nvarchar(max)  NULL,
    [Mobile1] nvarchar(max)  NULL,
    [Mobile2] nvarchar(max)  NULL,
    [Email] nvarchar(max)  NULL,
    [JoinDate] datetime  NULL,
    [NationalID] nvarchar(max)  NULL,
    [CreateBy] nvarchar(max)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] nvarchar(max)  NULL,
    [UpdateDate] datetime  NULL,
    [MotherName] varchar(250)  NULL,
    [FatherName] varchar(250)  NULL,
    [PermanentAdd] varchar(500)  NULL,
    [Nationality] varchar(50)  NULL,
    [Merital] varchar(50)  NULL,
    [Religion] varchar(50)  NULL,
    [ImageName] varchar(550)  NULL,
    [BrProId] int  NULL,
    [EmpSpecilistId] int  NOT NULL,
    [EmpTypeId] int  NOT NULL,
    [JobType] varchar(50)  NULL,
    [JobStatus] varchar(50)  NULL,
    [ReferenceBy] varchar(250)  NULL,
    [RefContactNum] varchar(50)  NULL,
    [FamilyContactNum] varchar(50)  NULL,
    [OtizmStatus] varchar(50)  NULL,
    [OtizmType] varchar(500)  NULL,
    [UserName] varchar(250)  NULL,
    [Password] varchar(100)  NULL,
    [EduStatus] varchar(50)  NULL,
    [TariningStatus] varchar(50)  NULL,
    [ExperienceStatus] varchar(50)  NULL,
    [SalaryStatus] varchar(50)  NULL,
    [LocationStatus] varchar(50)  NULL,
    [DiscountStatus] varchar(50)  NULL
);
GO

-- Creating table 'EmpSpecialists'
CREATE TABLE [dbo].[EmpSpecialists] (
    [EmpSpecilistId] int IDENTITY(1,1) NOT NULL,
    [Specialist] nvarchar(max)  NOT NULL,
    [EmpTypeId] int  NOT NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'EmpTrainings'
CREATE TABLE [dbo].[EmpTrainings] (
    [TrainingId] int IDENTITY(1,1) NOT NULL,
    [EmpId] int  NULL,
    [TrainingName] varchar(500)  NULL,
    [TopicsCovered] varchar(500)  NULL,
    [InstituteName] varchar(500)  NULL,
    [Location] varchar(500)  NULL,
    [TrainingYear] varchar(50)  NULL,
    [Duration] varchar(150)  NULL,
    [CreateDate] datetime  NULL,
    [CreateBy] varchar(50)  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'EmpTypes'
CREATE TABLE [dbo].[EmpTypes] (
    [EmpTypeId] int IDENTITY(1,1) NOT NULL,
    [TypeName] nvarchar(max)  NOT NULL,
    [CreateBy] varchar(50)  NULL,
    [UpdateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'ExpenseHeads'
CREATE TABLE [dbo].[ExpenseHeads] (
    [ExHeadId] int IDENTITY(1,1) NOT NULL,
    [HeadName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Expenses'
CREATE TABLE [dbo].[Expenses] (
    [ExpanseId] int IDENTITY(1,1) NOT NULL,
    [ExHeadId] int  NOT NULL,
    [Amount] float  NOT NULL,
    [Remarks] nvarchar(max)  NULL,
    [Date] datetime  NULL,
    [CreateDate] datetime  NULL,
    [CreateBy] nvarchar(max)  NULL,
    [UpdateBy] nvarchar(max)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'InvenBranchProfiles'
CREATE TABLE [dbo].[InvenBranchProfiles] (
    [BrProId] int IDENTITY(1,1) NOT NULL,
    [CompProId] int  NOT NULL,
    [BrProName] varchar(550)  NULL,
    [BrAddress] nvarchar(max)  NULL,
    [BrPhone] nvarchar(max)  NULL,
    [BrMobile1] varchar(50)  NULL,
    [BrMobile2] varchar(50)  NULL,
    [BrEmail] nvarchar(50)  NULL,
    [BrWebsite] nvarchar(max)  NULL,
    [BrDescription] nvarchar(max)  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'InvenBranchReturns'
CREATE TABLE [dbo].[InvenBranchReturns] (
    [BranchReturnId] int IDENTITY(1,1) NOT NULL,
    [ChangeDtlId] int  NULL,
    [ReturnBy] varchar(50)  NULL,
    [ReturnDate] datetime  NOT NULL,
    [ReturnNo] int  NOT NULL,
    [ReturnReciveStatus] varchar(50)  NULL,
    [ReciveBy] varchar(50)  NULL,
    [ReciveDate] datetime  NULL,
    [CentralToPartyStatus] varchar(50)  NULL
);
GO

-- Creating table 'InvenCenteralStoreStatus'
CREATE TABLE [dbo].[InvenCenteralStoreStatus] (
    [CentralStoreId] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NULL,
    [QuantityStore] int  NULL
);
GO

-- Creating table 'InvenCentralChallanDtls'
CREATE TABLE [dbo].[InvenCentralChallanDtls] (
    [ChallanDtlId] int IDENTITY(1,1) NOT NULL,
    [ChallanId] int  NULL,
    [ProductId] int  NULL,
    [ChallanQuantity] int  NULL,
    [ChallanPrice] float  NULL
);
GO

-- Creating table 'InvenCentralChallanInfoes'
CREATE TABLE [dbo].[InvenCentralChallanInfoes] (
    [ChallanId] int IDENTITY(1,1) NOT NULL,
    [PurReqNo] int  NULL,
    [ChallanDate] datetime  NULL,
    [ChallanBy] varchar(50)  NULL,
    [Note] varchar(550)  NULL,
    [BrProId] int  NOT NULL
);
GO

-- Creating table 'InvenCentralPurchaseDtls'
CREATE TABLE [dbo].[InvenCentralPurchaseDtls] (
    [PurchaseDtlID] int IDENTITY(1,1) NOT NULL,
    [PurchasePrice] float  NULL,
    [PurId] int  NULL,
    [Quantity] int  NULL,
    [ProductId] int  NOT NULL,
    [ExpriyDate] datetime  NULL,
    [BatchNo] varchar(50)  NULL,
    [ExpirySalesStatus] nchar(10)  NULL
);
GO

-- Creating table 'InvenCentralPurchaseInfoes'
CREATE TABLE [dbo].[InvenCentralPurchaseInfoes] (
    [PurId] int IDENTITY(1,1) NOT NULL,
    [PurDes] varchar(550)  NULL,
    [CreateBy] nvarchar(max)  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [SalesManName] varchar(50)  NULL,
    [PurOrderNo] int  NOT NULL
);
GO

-- Creating table 'InvenCentralPurchcasePaymentDtls'
CREATE TABLE [dbo].[InvenCentralPurchcasePaymentDtls] (
    [PurPayDtlId] int IDENTITY(1,1) NOT NULL,
    [PurPaymentId] int  NULL,
    [PaymentMode] varchar(50)  NULL,
    [PaidAmount] float  NULL,
    [DueAmount] float  NULL,
    [TotalPrice] float  NULL,
    [Note] nvarchar(max)  NULL,
    [PaymentDate] datetime  NULL,
    [PaymentBy] varchar(50)  NULL,
    [ChequeNo] varchar(500)  NULL,
    [ChequeDate] datetime  NULL,
    [IssDate] datetime  NULL,
    [AccountInfoId] int  NULL,
    [LCNumber] varchar(50)  NULL
);
GO

-- Creating table 'InvenCentralPurchcasePayments'
CREATE TABLE [dbo].[InvenCentralPurchcasePayments] (
    [PurPaymentId] int IDENTITY(1,1) NOT NULL,
    [PaidAmount] float  NULL,
    [DueAmount] float  NULL,
    [TotalPrice] float  NULL,
    [PurId] int  NOT NULL,
    [FirstPaymentStatus] nchar(10)  NULL,
    [CompId] int  NULL
);
GO

-- Creating table 'InvenCentralPurRequisitions'
CREATE TABLE [dbo].[InvenCentralPurRequisitions] (
    [CenPurReqId] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NOT NULL,
    [Quantity] int  NULL,
    [UnitPrice] float  NULL,
    [Priority] varchar(50)  NULL,
    [RequisitionNo] int  NOT NULL,
    [RequisitionBy] varchar(50)  NULL,
    [RequisitionDate] datetime  NULL,
    [PurReqStatus] varchar(50)  NULL
);
GO

-- Creating table 'InvenCentralReturns'
CREATE TABLE [dbo].[InvenCentralReturns] (
    [CentralReturnId] int IDENTITY(1,1) NOT NULL,
    [BranchReturnId] int  NULL,
    [ReturnBy] varchar(50)  NULL,
    [ReturnDate] datetime  NOT NULL,
    [ReturnNo] int  NOT NULL
);
GO

-- Creating table 'InvenCentrealPurOrders'
CREATE TABLE [dbo].[InvenCentrealPurOrders] (
    [CentralPurOrderId] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NOT NULL,
    [Quantity] int  NULL,
    [UnitPrice] float  NULL,
    [Priority] varchar(50)  NULL,
    [PurOrderNO] int  NOT NULL,
    [PurOrderBy] varchar(50)  NULL,
    [PurOrderDate] datetime  NULL,
    [PurOrderStatus] varchar(50)  NULL
);
GO

-- Creating table 'InvenChangeDtls'
CREATE TABLE [dbo].[InvenChangeDtls] (
    [ChangeDtlId] int IDENTITY(1,1) NOT NULL,
    [SalePrice] float  NULL,
    [Quantity] int  NULL,
    [ChangeId] int  NULL,
    [ProductId] int  NOT NULL,
    [SaleDtlId] int  NULL,
    [Caused] varchar(550)  NULL,
    [TransectionType] varchar(50)  NULL,
    [CentranlReturnStatus] varchar(50)  NULL
);
GO

-- Creating table 'InvenChangeInfoes'
CREATE TABLE [dbo].[InvenChangeInfoes] (
    [ChangeId] int IDENTITY(1,1) NOT NULL,
    [CreateBy] varchar(50)  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [BrProId] int  NULL,
    [CustomerName] varchar(150)  NULL,
    [CusMobileNo] varchar(50)  NULL,
    [CusContactAdd] varchar(550)  NULL,
    [CusRemarks] varchar(50)  NULL
);
GO

-- Creating table 'InvenChangePaymentDtls'
CREATE TABLE [dbo].[InvenChangePaymentDtls] (
    [ChangePayDtlId] int IDENTITY(1,1) NOT NULL,
    [ChangeId] int  NULL,
    [PaymentMode] varchar(50)  NULL,
    [PaidAmount] float  NULL,
    [Note] nvarchar(max)  NULL,
    [PaymentDate] datetime  NULL,
    [PaymentBy] varchar(50)  NULL,
    [CardNo] varchar(50)  NULL,
    [BankName] varchar(50)  NULL,
    [ApprCode] varchar(50)  NULL,
    [HolderName] varchar(50)  NULL
);
GO

-- Creating table 'InvenChangePayments'
CREATE TABLE [dbo].[InvenChangePayments] (
    [ChangePaymentId] int IDENTITY(1,1) NOT NULL,
    [PaidAmount] float  NULL,
    [DueAmount] float  NULL,
    [Discount] float  NULL,
    [TotalPrice] float  NULL,
    [ChangeId] int  NOT NULL,
    [Vat] float  NULL,
    [DiscountDescription] varchar(850)  NULL
);
GO

-- Creating table 'InvenCompProfileInfoes'
CREATE TABLE [dbo].[InvenCompProfileInfoes] (
    [CompProId] int IDENTITY(1,1) NOT NULL,
    [CompProName] varchar(550)  NULL,
    [CompAddress] nvarchar(max)  NULL,
    [CompPhone] nvarchar(max)  NULL,
    [CompMobile1] varchar(50)  NULL,
    [CompMobile2] varchar(50)  NULL,
    [CompEmail] nvarchar(50)  NULL,
    [CompWebsite] nvarchar(max)  NULL,
    [CompDescription] nvarchar(max)  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'InvenPerRequisitions'
CREATE TABLE [dbo].[InvenPerRequisitions] (
    [PurReqId] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NOT NULL,
    [Quantity] int  NULL,
    [UnitPrice] float  NULL,
    [Priority] varchar(50)  NULL,
    [RequisitionNo] int  NOT NULL,
    [RequisitionBy] varchar(50)  NULL,
    [RequisitionDate] datetime  NULL,
    [PurReqStatus] varchar(50)  NULL,
    [BrProId] int  NULL
);
GO

-- Creating table 'InvenPurOrders'
CREATE TABLE [dbo].[InvenPurOrders] (
    [InvenPurOrderId] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NOT NULL,
    [BrProId] int  NOT NULL,
    [Quantity] int  NULL,
    [UnitPrice] float  NULL,
    [Priority] varchar(50)  NULL,
    [PurOrderNO] int  NOT NULL,
    [PurOrderBy] varchar(50)  NULL,
    [PurOrderDate] datetime  NULL,
    [PurOrderStatus] varchar(50)  NULL
);
GO

-- Creating table 'InvenReorders'
CREATE TABLE [dbo].[InvenReorders] (
    [ReorderId] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NOT NULL,
    [BrProId] int  NOT NULL,
    [ReorderValue] int  NULL,
    [RateOfInterest] float  NULL,
    [PurRequisitonStatus] varchar(50)  NULL,
    [CreateBy] varchar(50)  NULL,
    [Createdate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'InvenSaleDtls'
CREATE TABLE [dbo].[InvenSaleDtls] (
    [SaleDtlId] int IDENTITY(1,1) NOT NULL,
    [SalePrice] float  NULL,
    [Quantity] int  NULL,
    [SalId] int  NULL,
    [ProductId] int  NOT NULL,
    [TransectionType] varchar(50)  NULL
);
GO

-- Creating table 'InvenSalePayments'
CREATE TABLE [dbo].[InvenSalePayments] (
    [SalePaymentId] int IDENTITY(1,1) NOT NULL,
    [PaidAmount] float  NULL,
    [DueAmount] float  NULL,
    [Discount] float  NULL,
    [TotalPrice] float  NULL,
    [SalId] int  NOT NULL,
    [Vat] float  NULL,
    [DiscountDescription] varchar(850)  NULL
);
GO

-- Creating table 'InvenSalesInfoes'
CREATE TABLE [dbo].[InvenSalesInfoes] (
    [SalId] int IDENTITY(1,1) NOT NULL,
    [CreateBy] varchar(50)  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [BrProId] int  NULL,
    [CustomerName] varchar(150)  NULL,
    [CusMobileNo] varchar(50)  NULL,
    [CusContactAdd] varchar(550)  NULL,
    [CusRemarks] varchar(50)  NULL
);
GO

-- Creating table 'InvenSalesPaymentDtls'
CREATE TABLE [dbo].[InvenSalesPaymentDtls] (
    [SalePayDtlId] int IDENTITY(1,1) NOT NULL,
    [SalId] int  NULL,
    [PaymentMode] varchar(50)  NULL,
    [PaidAmount] float  NULL,
    [Note] nvarchar(max)  NULL,
    [PaymentDate] datetime  NULL,
    [PaymentBy] varchar(50)  NULL,
    [CardNo] varchar(50)  NULL,
    [BankName] varchar(50)  NULL,
    [ApprCode] varchar(50)  NULL,
    [HolderName] varchar(50)  NULL
);
GO

-- Creating table 'InvenStoreStatus'
CREATE TABLE [dbo].[InvenStoreStatus] (
    [InvenStoreId] int IDENTITY(1,1) NOT NULL,
    [ProductId] int  NULL,
    [BrProId] int  NULL,
    [QuantityStore] int  NULL
);
GO

-- Creating table 'Log_AccJournal'
CREATE TABLE [dbo].[Log_AccJournal] (
    [LogJournalId] int IDENTITY(1,1) NOT NULL,
    [LogField] varchar(max)  NULL,
    [LogDate] datetime  NULL,
    [LogBy] varchar(50)  NULL
);
GO

-- Creating table 'Log_InvenReorder'
CREATE TABLE [dbo].[Log_InvenReorder] (
    [LogInvenReorderId] int IDENTITY(1,1) NOT NULL,
    [LogField] varchar(max)  NULL,
    [LogDate] datetime  NULL,
    [LogBy] varchar(50)  NULL
);
GO

-- Creating table 'Log_PayEmpInfo'
CREATE TABLE [dbo].[Log_PayEmpInfo] (
    [LogPayEmpInfoId] int IDENTITY(1,1) NOT NULL,
    [LogField] varchar(850)  NULL,
    [LogBy] varchar(50)  NULL,
    [LogDate] datetime  NULL
);
GO

-- Creating table 'Log_PayuserRole'
CREATE TABLE [dbo].[Log_PayuserRole] (
    [LogFilePayUserRoleId] int IDENTITY(1,1) NOT NULL,
    [LogField] varchar(850)  NULL,
    [LogBy] varchar(50)  NULL,
    [LogDate] datetime  NULL
);
GO

-- Creating table 'PayAccountTypeInfoes'
CREATE TABLE [dbo].[PayAccountTypeInfoes] (
    [AccountTypeId] int IDENTITY(1,1) NOT NULL,
    [AccountTypeName] varchar(50)  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'PayAssets'
CREATE TABLE [dbo].[PayAssets] (
    [AssetId] int IDENTITY(1,1) NOT NULL,
    [CashAmount_Current] float  NULL,
    [BankAmount_Current] float  NULL
);
GO

-- Creating table 'PayBankAccountInfoes'
CREATE TABLE [dbo].[PayBankAccountInfoes] (
    [AccountInfoId] int IDENTITY(1,1) NOT NULL,
    [BranchName] varchar(50)  NULL,
    [BankId] int  NULL,
    [Address] varchar(350)  NULL,
    [Phone] varchar(50)  NULL,
    [Mobile] varchar(50)  NULL,
    [AccountTypeId] int  NULL,
    [AccountName] varchar(50)  NULL,
    [AccountNum] varchar(50)  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [ActivationSatus] varchar(50)  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL,
    [BrProId] int  NULL
);
GO

-- Creating table 'PayBankInfoes'
CREATE TABLE [dbo].[PayBankInfoes] (
    [BankId] int IDENTITY(1,1) NOT NULL,
    [BankName] varchar(250)  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'PayBankTransectionDtlInfoes'
CREATE TABLE [dbo].[PayBankTransectionDtlInfoes] (
    [TransectionDtlId] int IDENTITY(1,1) NOT NULL,
    [AccountInfoId] int  NOT NULL,
    [BrProId] int  NULL,
    [Amount_EachTransection] float  NULL,
    [PaymentDate] datetime  NULL,
    [PaymentBy] varchar(50)  NULL,
    [Year] int  NOT NULL,
    [Remarks] varchar(550)  NULL,
    [CollectionDate] datetime  NULL
);
GO

-- Creating table 'PayBankTransectionInfoes'
CREATE TABLE [dbo].[PayBankTransectionInfoes] (
    [BankTransectionId] int IDENTITY(1,1) NOT NULL,
    [AccountInfoId] int  NOT NULL,
    [BankAmount] float  NULL
);
GO

-- Creating table 'PayCompanyCashEntries'
CREATE TABLE [dbo].[PayCompanyCashEntries] (
    [CashId] int IDENTITY(1,1) NOT NULL,
    [BrProId] int  NULL,
    [CashAmount] float  NULL,
    [CreateBy] varchar(50)  NULL,
    [CrateDate] datetime  NULL,
    [Remarks] varchar(450)  NULL,
    [Year] int  NOT NULL,
    [Month] varchar(50)  NULL,
    [CollectionDate] datetime  NULL
);
GO

-- Creating table 'PayRoles'
CREATE TABLE [dbo].[PayRoles] (
    [RoleId] int IDENTITY(1,1) NOT NULL,
    [RoleName] varchar(50)  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'PayUserRoles'
CREATE TABLE [dbo].[PayUserRoles] (
    [UserRoleId] int IDENTITY(1,1) NOT NULL,
    [EmpId] int  NOT NULL,
    [RoleId] int  NOT NULL,
    [CreateBy] nvarchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'Products'
CREATE TABLE [dbo].[Products] (
    [ProductId] int IDENTITY(1,1) NOT NULL,
    [UnitId] int  NULL,
    [CompId] int  NULL,
    [ProductName] nvarchar(max)  NULL,
    [CenterReorderValue] int  NULL,
    [ReorderInsertStatus] varchar(50)  NULL,
    [CategoryId] int  NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- Creating table 'PurchaseDtls'
CREATE TABLE [dbo].[PurchaseDtls] (
    [PurchaseDtlID] int IDENTITY(1,1) NOT NULL,
    [PurchasePrice] float  NULL,
    [Quantity] int  NULL,
    [PurId] int  NOT NULL,
    [ProductId] int  NOT NULL
);
GO

-- Creating table 'PurchaseInfoes'
CREATE TABLE [dbo].[PurchaseInfoes] (
    [PurId] int IDENTITY(1,1) NOT NULL,
    [PurDes] varchar(550)  NULL,
    [CreateBy] nvarchar(max)  NOT NULL,
    [CreateDate] datetime  NOT NULL,
    [SalesManName] varchar(50)  NULL,
    [CompId] int  NULL,
    [DONO] varchar(50)  NULL
);
GO

-- Creating table 'PurchcasePaymentDtls'
CREATE TABLE [dbo].[PurchcasePaymentDtls] (
    [PurPayDtlId] int IDENTITY(1,1) NOT NULL,
    [PaymentMode] varchar(50)  NULL,
    [PaidAmount] float  NULL,
    [DueAmount] float  NULL,
    [TotalPrice] float  NULL,
    [Note] nvarchar(max)  NULL,
    [PurId] int  NOT NULL,
    [PaymentDate] datetime  NULL,
    [PaymentBy] varchar(50)  NULL,
    [ChequeNo] varchar(500)  NULL,
    [ChequeDate] datetime  NULL,
    [IssDate] datetime  NULL,
    [AccountInfoId] int  NULL,
    [LCNumber] varchar(50)  NULL
);
GO

-- Creating table 'PurchcasePayments'
CREATE TABLE [dbo].[PurchcasePayments] (
    [PurPaymentId] int IDENTITY(1,1) NOT NULL,
    [PaymentMode] varchar(50)  NULL,
    [PaidAmount] float  NULL,
    [DueAmount] float  NULL,
    [TotalPrice] float  NULL,
    [Note] nvarchar(max)  NULL,
    [PurId] int  NOT NULL,
    [PaymentDate] datetime  NULL,
    [PaymentBy] varchar(50)  NULL,
    [ChequeNo] varchar(500)  NULL,
    [ChequeDate] datetime  NULL,
    [IssDate] datetime  NULL,
    [AccountInfoId] int  NULL,
    [LCNumber] varchar(50)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- Creating table 'Units'
CREATE TABLE [dbo].[Units] (
    [UnitId] int IDENTITY(1,1) NOT NULL,
    [UnitName] nvarchar(max)  NOT NULL,
    [CreateBy] varchar(50)  NULL,
    [CreateDate] datetime  NULL,
    [UpdateBy] varchar(50)  NULL,
    [UpdateDate] datetime  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [BalanceShtId] in table 'AccBalanceSheetRpts'
ALTER TABLE [dbo].[AccBalanceSheetRpts]
ADD CONSTRAINT [PK_AccBalanceSheetRpts]
    PRIMARY KEY CLUSTERED ([BalanceShtId] ASC);
GO

-- Creating primary key on [CFEId] in table 'AccCashFlowEntities'
ALTER TABLE [dbo].[AccCashFlowEntities]
ADD CONSTRAINT [PK_AccCashFlowEntities]
    PRIMARY KEY CLUSTERED ([CFEId] ASC);
GO

-- Creating primary key on [CFRId] in table 'AccCashFlowReports'
ALTER TABLE [dbo].[AccCashFlowReports]
ADD CONSTRAINT [PK_AccCashFlowReports]
    PRIMARY KEY CLUSTERED ([CFRId] ASC);
GO

-- Creating primary key on [COAId] in table 'AccCOAInfoes'
ALTER TABLE [dbo].[AccCOAInfoes]
ADD CONSTRAINT [PK_AccCOAInfoes]
    PRIMARY KEY CLUSTERED ([COAId] ASC);
GO

-- Creating primary key on [InStaRptId] in table 'AccIncomeStatementRpts'
ALTER TABLE [dbo].[AccIncomeStatementRpts]
ADD CONSTRAINT [PK_AccIncomeStatementRpts]
    PRIMARY KEY CLUSTERED ([InStaRptId] ASC);
GO

-- Creating primary key on [JournalId] in table 'AccJournalEntries'
ALTER TABLE [dbo].[AccJournalEntries]
ADD CONSTRAINT [PK_AccJournalEntries]
    PRIMARY KEY CLUSTERED ([JournalId] ASC);
GO

-- Creating primary key on [LedgerId] in table 'AccLedgers'
ALTER TABLE [dbo].[AccLedgers]
ADD CONSTRAINT [PK_AccLedgers]
    PRIMARY KEY CLUSTERED ([LedgerId] ASC);
GO

-- Creating primary key on [LiabRptId] in table 'AccLiabilitiesRpts'
ALTER TABLE [dbo].[AccLiabilitiesRpts]
ADD CONSTRAINT [PK_AccLiabilitiesRpts]
    PRIMARY KEY CLUSTERED ([LiabRptId] ASC);
GO

-- Creating primary key on [MainHeadId] in table 'AccMainHeads'
ALTER TABLE [dbo].[AccMainHeads]
ADD CONSTRAINT [PK_AccMainHeads]
    PRIMARY KEY CLUSTERED ([MainHeadId] ASC);
GO

-- Creating primary key on [MainVoucherId] in table 'AccMainVouchers'
ALTER TABLE [dbo].[AccMainVouchers]
ADD CONSTRAINT [PK_AccMainVouchers]
    PRIMARY KEY CLUSTERED ([MainVoucherId] ASC);
GO

-- Creating primary key on [SubCode_1Id] in table 'AccSubCode1'
ALTER TABLE [dbo].[AccSubCode1]
ADD CONSTRAINT [PK_AccSubCode1]
    PRIMARY KEY CLUSTERED ([SubCode_1Id] ASC);
GO

-- Creating primary key on [SubCode2_Id] in table 'AccSubCode2'
ALTER TABLE [dbo].[AccSubCode2]
ADD CONSTRAINT [PK_AccSubCode2]
    PRIMARY KEY CLUSTERED ([SubCode2_Id] ASC);
GO

-- Creating primary key on [SubVoucherId] in table 'AccSubVouchers'
ALTER TABLE [dbo].[AccSubVouchers]
ADD CONSTRAINT [PK_AccSubVouchers]
    PRIMARY KEY CLUSTERED ([SubVoucherId] ASC);
GO

-- Creating primary key on [TranId] in table 'AccTranItems'
ALTER TABLE [dbo].[AccTranItems]
ADD CONSTRAINT [PK_AccTranItems]
    PRIMARY KEY CLUSTERED ([TranId] ASC);
GO

-- Creating primary key on [AccTransDtlId] in table 'AccTransDetails'
ALTER TABLE [dbo].[AccTransDetails]
ADD CONSTRAINT [PK_AccTransDetails]
    PRIMARY KEY CLUSTERED ([AccTransDtlId] ASC);
GO

-- Creating primary key on [CatId] in table 'Categories'
ALTER TABLE [dbo].[Categories]
ADD CONSTRAINT [PK_Categories]
    PRIMARY KEY CLUSTERED ([CatId] ASC);
GO

-- Creating primary key on [CompId] in table 'CompanyInfoes'
ALTER TABLE [dbo].[CompanyInfoes]
ADD CONSTRAINT [PK_CompanyInfoes]
    PRIMARY KEY CLUSTERED ([CompId] ASC);
GO

-- Creating primary key on [EduId] in table 'EmpEducations'
ALTER TABLE [dbo].[EmpEducations]
ADD CONSTRAINT [PK_EmpEducations]
    PRIMARY KEY CLUSTERED ([EduId] ASC);
GO

-- Creating primary key on [ExperienceId] in table 'EmpExperienceInfoes'
ALTER TABLE [dbo].[EmpExperienceInfoes]
ADD CONSTRAINT [PK_EmpExperienceInfoes]
    PRIMARY KEY CLUSTERED ([ExperienceId] ASC);
GO

-- Creating primary key on [EmpId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [PK_Employees]
    PRIMARY KEY CLUSTERED ([EmpId] ASC);
GO

-- Creating primary key on [EmpSpecilistId] in table 'EmpSpecialists'
ALTER TABLE [dbo].[EmpSpecialists]
ADD CONSTRAINT [PK_EmpSpecialists]
    PRIMARY KEY CLUSTERED ([EmpSpecilistId] ASC);
GO

-- Creating primary key on [TrainingId] in table 'EmpTrainings'
ALTER TABLE [dbo].[EmpTrainings]
ADD CONSTRAINT [PK_EmpTrainings]
    PRIMARY KEY CLUSTERED ([TrainingId] ASC);
GO

-- Creating primary key on [EmpTypeId] in table 'EmpTypes'
ALTER TABLE [dbo].[EmpTypes]
ADD CONSTRAINT [PK_EmpTypes]
    PRIMARY KEY CLUSTERED ([EmpTypeId] ASC);
GO

-- Creating primary key on [ExHeadId] in table 'ExpenseHeads'
ALTER TABLE [dbo].[ExpenseHeads]
ADD CONSTRAINT [PK_ExpenseHeads]
    PRIMARY KEY CLUSTERED ([ExHeadId] ASC);
GO

-- Creating primary key on [ExpanseId] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [PK_Expenses]
    PRIMARY KEY CLUSTERED ([ExpanseId] ASC);
GO

-- Creating primary key on [BrProId] in table 'InvenBranchProfiles'
ALTER TABLE [dbo].[InvenBranchProfiles]
ADD CONSTRAINT [PK_InvenBranchProfiles]
    PRIMARY KEY CLUSTERED ([BrProId] ASC);
GO

-- Creating primary key on [BranchReturnId] in table 'InvenBranchReturns'
ALTER TABLE [dbo].[InvenBranchReturns]
ADD CONSTRAINT [PK_InvenBranchReturns]
    PRIMARY KEY CLUSTERED ([BranchReturnId] ASC);
GO

-- Creating primary key on [CentralStoreId] in table 'InvenCenteralStoreStatus'
ALTER TABLE [dbo].[InvenCenteralStoreStatus]
ADD CONSTRAINT [PK_InvenCenteralStoreStatus]
    PRIMARY KEY CLUSTERED ([CentralStoreId] ASC);
GO

-- Creating primary key on [ChallanDtlId] in table 'InvenCentralChallanDtls'
ALTER TABLE [dbo].[InvenCentralChallanDtls]
ADD CONSTRAINT [PK_InvenCentralChallanDtls]
    PRIMARY KEY CLUSTERED ([ChallanDtlId] ASC);
GO

-- Creating primary key on [ChallanId] in table 'InvenCentralChallanInfoes'
ALTER TABLE [dbo].[InvenCentralChallanInfoes]
ADD CONSTRAINT [PK_InvenCentralChallanInfoes]
    PRIMARY KEY CLUSTERED ([ChallanId] ASC);
GO

-- Creating primary key on [PurchaseDtlID] in table 'InvenCentralPurchaseDtls'
ALTER TABLE [dbo].[InvenCentralPurchaseDtls]
ADD CONSTRAINT [PK_InvenCentralPurchaseDtls]
    PRIMARY KEY CLUSTERED ([PurchaseDtlID] ASC);
GO

-- Creating primary key on [PurId] in table 'InvenCentralPurchaseInfoes'
ALTER TABLE [dbo].[InvenCentralPurchaseInfoes]
ADD CONSTRAINT [PK_InvenCentralPurchaseInfoes]
    PRIMARY KEY CLUSTERED ([PurId] ASC);
GO

-- Creating primary key on [PurPayDtlId] in table 'InvenCentralPurchcasePaymentDtls'
ALTER TABLE [dbo].[InvenCentralPurchcasePaymentDtls]
ADD CONSTRAINT [PK_InvenCentralPurchcasePaymentDtls]
    PRIMARY KEY CLUSTERED ([PurPayDtlId] ASC);
GO

-- Creating primary key on [PurPaymentId] in table 'InvenCentralPurchcasePayments'
ALTER TABLE [dbo].[InvenCentralPurchcasePayments]
ADD CONSTRAINT [PK_InvenCentralPurchcasePayments]
    PRIMARY KEY CLUSTERED ([PurPaymentId] ASC);
GO

-- Creating primary key on [CenPurReqId] in table 'InvenCentralPurRequisitions'
ALTER TABLE [dbo].[InvenCentralPurRequisitions]
ADD CONSTRAINT [PK_InvenCentralPurRequisitions]
    PRIMARY KEY CLUSTERED ([CenPurReqId] ASC);
GO

-- Creating primary key on [CentralReturnId] in table 'InvenCentralReturns'
ALTER TABLE [dbo].[InvenCentralReturns]
ADD CONSTRAINT [PK_InvenCentralReturns]
    PRIMARY KEY CLUSTERED ([CentralReturnId] ASC);
GO

-- Creating primary key on [CentralPurOrderId] in table 'InvenCentrealPurOrders'
ALTER TABLE [dbo].[InvenCentrealPurOrders]
ADD CONSTRAINT [PK_InvenCentrealPurOrders]
    PRIMARY KEY CLUSTERED ([CentralPurOrderId] ASC);
GO

-- Creating primary key on [ChangeDtlId] in table 'InvenChangeDtls'
ALTER TABLE [dbo].[InvenChangeDtls]
ADD CONSTRAINT [PK_InvenChangeDtls]
    PRIMARY KEY CLUSTERED ([ChangeDtlId] ASC);
GO

-- Creating primary key on [ChangeId] in table 'InvenChangeInfoes'
ALTER TABLE [dbo].[InvenChangeInfoes]
ADD CONSTRAINT [PK_InvenChangeInfoes]
    PRIMARY KEY CLUSTERED ([ChangeId] ASC);
GO

-- Creating primary key on [ChangePayDtlId] in table 'InvenChangePaymentDtls'
ALTER TABLE [dbo].[InvenChangePaymentDtls]
ADD CONSTRAINT [PK_InvenChangePaymentDtls]
    PRIMARY KEY CLUSTERED ([ChangePayDtlId] ASC);
GO

-- Creating primary key on [ChangePaymentId] in table 'InvenChangePayments'
ALTER TABLE [dbo].[InvenChangePayments]
ADD CONSTRAINT [PK_InvenChangePayments]
    PRIMARY KEY CLUSTERED ([ChangePaymentId] ASC);
GO

-- Creating primary key on [CompProId] in table 'InvenCompProfileInfoes'
ALTER TABLE [dbo].[InvenCompProfileInfoes]
ADD CONSTRAINT [PK_InvenCompProfileInfoes]
    PRIMARY KEY CLUSTERED ([CompProId] ASC);
GO

-- Creating primary key on [PurReqId] in table 'InvenPerRequisitions'
ALTER TABLE [dbo].[InvenPerRequisitions]
ADD CONSTRAINT [PK_InvenPerRequisitions]
    PRIMARY KEY CLUSTERED ([PurReqId] ASC);
GO

-- Creating primary key on [InvenPurOrderId] in table 'InvenPurOrders'
ALTER TABLE [dbo].[InvenPurOrders]
ADD CONSTRAINT [PK_InvenPurOrders]
    PRIMARY KEY CLUSTERED ([InvenPurOrderId] ASC);
GO

-- Creating primary key on [ReorderId] in table 'InvenReorders'
ALTER TABLE [dbo].[InvenReorders]
ADD CONSTRAINT [PK_InvenReorders]
    PRIMARY KEY CLUSTERED ([ReorderId] ASC);
GO

-- Creating primary key on [SaleDtlId] in table 'InvenSaleDtls'
ALTER TABLE [dbo].[InvenSaleDtls]
ADD CONSTRAINT [PK_InvenSaleDtls]
    PRIMARY KEY CLUSTERED ([SaleDtlId] ASC);
GO

-- Creating primary key on [SalePaymentId] in table 'InvenSalePayments'
ALTER TABLE [dbo].[InvenSalePayments]
ADD CONSTRAINT [PK_InvenSalePayments]
    PRIMARY KEY CLUSTERED ([SalePaymentId] ASC);
GO

-- Creating primary key on [SalId] in table 'InvenSalesInfoes'
ALTER TABLE [dbo].[InvenSalesInfoes]
ADD CONSTRAINT [PK_InvenSalesInfoes]
    PRIMARY KEY CLUSTERED ([SalId] ASC);
GO

-- Creating primary key on [SalePayDtlId] in table 'InvenSalesPaymentDtls'
ALTER TABLE [dbo].[InvenSalesPaymentDtls]
ADD CONSTRAINT [PK_InvenSalesPaymentDtls]
    PRIMARY KEY CLUSTERED ([SalePayDtlId] ASC);
GO

-- Creating primary key on [InvenStoreId] in table 'InvenStoreStatus'
ALTER TABLE [dbo].[InvenStoreStatus]
ADD CONSTRAINT [PK_InvenStoreStatus]
    PRIMARY KEY CLUSTERED ([InvenStoreId] ASC);
GO

-- Creating primary key on [LogJournalId] in table 'Log_AccJournal'
ALTER TABLE [dbo].[Log_AccJournal]
ADD CONSTRAINT [PK_Log_AccJournal]
    PRIMARY KEY CLUSTERED ([LogJournalId] ASC);
GO

-- Creating primary key on [LogInvenReorderId] in table 'Log_InvenReorder'
ALTER TABLE [dbo].[Log_InvenReorder]
ADD CONSTRAINT [PK_Log_InvenReorder]
    PRIMARY KEY CLUSTERED ([LogInvenReorderId] ASC);
GO

-- Creating primary key on [LogPayEmpInfoId] in table 'Log_PayEmpInfo'
ALTER TABLE [dbo].[Log_PayEmpInfo]
ADD CONSTRAINT [PK_Log_PayEmpInfo]
    PRIMARY KEY CLUSTERED ([LogPayEmpInfoId] ASC);
GO

-- Creating primary key on [LogFilePayUserRoleId] in table 'Log_PayuserRole'
ALTER TABLE [dbo].[Log_PayuserRole]
ADD CONSTRAINT [PK_Log_PayuserRole]
    PRIMARY KEY CLUSTERED ([LogFilePayUserRoleId] ASC);
GO

-- Creating primary key on [AccountTypeId] in table 'PayAccountTypeInfoes'
ALTER TABLE [dbo].[PayAccountTypeInfoes]
ADD CONSTRAINT [PK_PayAccountTypeInfoes]
    PRIMARY KEY CLUSTERED ([AccountTypeId] ASC);
GO

-- Creating primary key on [AssetId] in table 'PayAssets'
ALTER TABLE [dbo].[PayAssets]
ADD CONSTRAINT [PK_PayAssets]
    PRIMARY KEY CLUSTERED ([AssetId] ASC);
GO

-- Creating primary key on [AccountInfoId] in table 'PayBankAccountInfoes'
ALTER TABLE [dbo].[PayBankAccountInfoes]
ADD CONSTRAINT [PK_PayBankAccountInfoes]
    PRIMARY KEY CLUSTERED ([AccountInfoId] ASC);
GO

-- Creating primary key on [BankId] in table 'PayBankInfoes'
ALTER TABLE [dbo].[PayBankInfoes]
ADD CONSTRAINT [PK_PayBankInfoes]
    PRIMARY KEY CLUSTERED ([BankId] ASC);
GO

-- Creating primary key on [TransectionDtlId] in table 'PayBankTransectionDtlInfoes'
ALTER TABLE [dbo].[PayBankTransectionDtlInfoes]
ADD CONSTRAINT [PK_PayBankTransectionDtlInfoes]
    PRIMARY KEY CLUSTERED ([TransectionDtlId] ASC);
GO

-- Creating primary key on [BankTransectionId] in table 'PayBankTransectionInfoes'
ALTER TABLE [dbo].[PayBankTransectionInfoes]
ADD CONSTRAINT [PK_PayBankTransectionInfoes]
    PRIMARY KEY CLUSTERED ([BankTransectionId] ASC);
GO

-- Creating primary key on [CashId] in table 'PayCompanyCashEntries'
ALTER TABLE [dbo].[PayCompanyCashEntries]
ADD CONSTRAINT [PK_PayCompanyCashEntries]
    PRIMARY KEY CLUSTERED ([CashId] ASC);
GO

-- Creating primary key on [RoleId] in table 'PayRoles'
ALTER TABLE [dbo].[PayRoles]
ADD CONSTRAINT [PK_PayRoles]
    PRIMARY KEY CLUSTERED ([RoleId] ASC);
GO

-- Creating primary key on [UserRoleId] in table 'PayUserRoles'
ALTER TABLE [dbo].[PayUserRoles]
ADD CONSTRAINT [PK_PayUserRoles]
    PRIMARY KEY CLUSTERED ([UserRoleId] ASC);
GO

-- Creating primary key on [ProductId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [PK_Products]
    PRIMARY KEY CLUSTERED ([ProductId] ASC);
GO

-- Creating primary key on [PurchaseDtlID] in table 'PurchaseDtls'
ALTER TABLE [dbo].[PurchaseDtls]
ADD CONSTRAINT [PK_PurchaseDtls]
    PRIMARY KEY CLUSTERED ([PurchaseDtlID] ASC);
GO

-- Creating primary key on [PurId] in table 'PurchaseInfoes'
ALTER TABLE [dbo].[PurchaseInfoes]
ADD CONSTRAINT [PK_PurchaseInfoes]
    PRIMARY KEY CLUSTERED ([PurId] ASC);
GO

-- Creating primary key on [PurPayDtlId] in table 'PurchcasePaymentDtls'
ALTER TABLE [dbo].[PurchcasePaymentDtls]
ADD CONSTRAINT [PK_PurchcasePaymentDtls]
    PRIMARY KEY CLUSTERED ([PurPayDtlId] ASC);
GO

-- Creating primary key on [PurPaymentId] in table 'PurchcasePayments'
ALTER TABLE [dbo].[PurchcasePayments]
ADD CONSTRAINT [PK_PurchcasePayments]
    PRIMARY KEY CLUSTERED ([PurPaymentId] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- Creating primary key on [UnitId] in table 'Units'
ALTER TABLE [dbo].[Units]
ADD CONSTRAINT [PK_Units]
    PRIMARY KEY CLUSTERED ([UnitId] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MainHeadId] in table 'AccBalanceSheetRpts'
ALTER TABLE [dbo].[AccBalanceSheetRpts]
ADD CONSTRAINT [FK_AccBalanceSheetRpt_AccMainHeads]
    FOREIGN KEY ([MainHeadId])
    REFERENCES [dbo].[AccMainHeads]
        ([MainHeadId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccBalanceSheetRpt_AccMainHeads'
CREATE INDEX [IX_FK_AccBalanceSheetRpt_AccMainHeads]
ON [dbo].[AccBalanceSheetRpts]
    ([MainHeadId]);
GO

-- Creating foreign key on [SubCode1Id] in table 'AccBalanceSheetRpts'
ALTER TABLE [dbo].[AccBalanceSheetRpts]
ADD CONSTRAINT [FK_AccBalanceSheetRpt_AccSubCode1]
    FOREIGN KEY ([SubCode1Id])
    REFERENCES [dbo].[AccSubCode1]
        ([SubCode_1Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccBalanceSheetRpt_AccSubCode1'
CREATE INDEX [IX_FK_AccBalanceSheetRpt_AccSubCode1]
ON [dbo].[AccBalanceSheetRpts]
    ([SubCode1Id]);
GO

-- Creating foreign key on [CFEId] in table 'AccCashFlowReports'
ALTER TABLE [dbo].[AccCashFlowReports]
ADD CONSTRAINT [FK_CashFlowReport_CashFlowEntity]
    FOREIGN KEY ([CFEId])
    REFERENCES [dbo].[AccCashFlowEntities]
        ([CFEId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CashFlowReport_CashFlowEntity'
CREATE INDEX [IX_FK_CashFlowReport_CashFlowEntity]
ON [dbo].[AccCashFlowReports]
    ([CFEId]);
GO

-- Creating foreign key on [SubCode_1Id] in table 'AccCashFlowReports'
ALTER TABLE [dbo].[AccCashFlowReports]
ADD CONSTRAINT [FK_AccCashFlowReport_AccSubCode1]
    FOREIGN KEY ([SubCode_1Id])
    REFERENCES [dbo].[AccSubCode1]
        ([SubCode_1Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccCashFlowReport_AccSubCode1'
CREATE INDEX [IX_FK_AccCashFlowReport_AccSubCode1]
ON [dbo].[AccCashFlowReports]
    ([SubCode_1Id]);
GO

-- Creating foreign key on [COAId] in table 'AccCashFlowReports'
ALTER TABLE [dbo].[AccCashFlowReports]
ADD CONSTRAINT [FK_CashFlowReport_AccCOAInfoes]
    FOREIGN KEY ([COAId])
    REFERENCES [dbo].[AccCOAInfoes]
        ([COAId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CashFlowReport_AccCOAInfoes'
CREATE INDEX [IX_FK_CashFlowReport_AccCOAInfoes]
ON [dbo].[AccCashFlowReports]
    ([COAId]);
GO

-- Creating foreign key on [SubCode_2Id] in table 'AccCOAInfoes'
ALTER TABLE [dbo].[AccCOAInfoes]
ADD CONSTRAINT [FK_AccCOAInfo_AccSubCode2]
    FOREIGN KEY ([SubCode_2Id])
    REFERENCES [dbo].[AccSubCode2]
        ([SubCode2_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccCOAInfo_AccSubCode2'
CREATE INDEX [IX_FK_AccCOAInfo_AccSubCode2]
ON [dbo].[AccCOAInfoes]
    ([SubCode_2Id]);
GO

-- Creating foreign key on [COAId] in table 'AccJournalEntries'
ALTER TABLE [dbo].[AccJournalEntries]
ADD CONSTRAINT [FK_AccJournalEntry_AccCOAInfoes]
    FOREIGN KEY ([COAId])
    REFERENCES [dbo].[AccCOAInfoes]
        ([COAId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccJournalEntry_AccCOAInfoes'
CREATE INDEX [IX_FK_AccJournalEntry_AccCOAInfoes]
ON [dbo].[AccJournalEntries]
    ([COAId]);
GO

-- Creating foreign key on [CRCOAId] in table 'AccTransDetails'
ALTER TABLE [dbo].[AccTransDetails]
ADD CONSTRAINT [FK_AccTransDetails_AccCOAInfoes]
    FOREIGN KEY ([CRCOAId])
    REFERENCES [dbo].[AccCOAInfoes]
        ([COAId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccTransDetails_AccCOAInfoes'
CREATE INDEX [IX_FK_AccTransDetails_AccCOAInfoes]
ON [dbo].[AccTransDetails]
    ([CRCOAId]);
GO

-- Creating foreign key on [DRCOAId] in table 'AccTransDetails'
ALTER TABLE [dbo].[AccTransDetails]
ADD CONSTRAINT [FK_AccTransDetails_AccCOAInfoes1]
    FOREIGN KEY ([DRCOAId])
    REFERENCES [dbo].[AccCOAInfoes]
        ([COAId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccTransDetails_AccCOAInfoes1'
CREATE INDEX [IX_FK_AccTransDetails_AccCOAInfoes1]
ON [dbo].[AccTransDetails]
    ([DRCOAId]);
GO

-- Creating foreign key on [MainHeadId] in table 'AccIncomeStatementRpts'
ALTER TABLE [dbo].[AccIncomeStatementRpts]
ADD CONSTRAINT [FK_AccIncomeStatementRpt_AccMainHeads]
    FOREIGN KEY ([MainHeadId])
    REFERENCES [dbo].[AccMainHeads]
        ([MainHeadId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccIncomeStatementRpt_AccMainHeads'
CREATE INDEX [IX_FK_AccIncomeStatementRpt_AccMainHeads]
ON [dbo].[AccIncomeStatementRpts]
    ([MainHeadId]);
GO

-- Creating foreign key on [SubCode2Id] in table 'AccJournalEntries'
ALTER TABLE [dbo].[AccJournalEntries]
ADD CONSTRAINT [FK_AccJournalEntry_AccSubCode2]
    FOREIGN KEY ([SubCode2Id])
    REFERENCES [dbo].[AccSubCode2]
        ([SubCode2_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccJournalEntry_AccSubCode2'
CREATE INDEX [IX_FK_AccJournalEntry_AccSubCode2]
ON [dbo].[AccJournalEntries]
    ([SubCode2Id]);
GO

-- Creating foreign key on [SubVoucherId] in table 'AccJournalEntries'
ALTER TABLE [dbo].[AccJournalEntries]
ADD CONSTRAINT [FK_AccJournalEntry_AccSubVouchers]
    FOREIGN KEY ([SubVoucherId])
    REFERENCES [dbo].[AccSubVouchers]
        ([SubVoucherId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccJournalEntry_AccSubVouchers'
CREATE INDEX [IX_FK_AccJournalEntry_AccSubVouchers]
ON [dbo].[AccJournalEntries]
    ([SubVoucherId]);
GO

-- Creating foreign key on [JournalId] in table 'AccLedgers'
ALTER TABLE [dbo].[AccLedgers]
ADD CONSTRAINT [FK_AccLedger_AccJournalEntry]
    FOREIGN KEY ([JournalId])
    REFERENCES [dbo].[AccJournalEntries]
        ([JournalId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccLedger_AccJournalEntry'
CREATE INDEX [IX_FK_AccLedger_AccJournalEntry]
ON [dbo].[AccLedgers]
    ([JournalId]);
GO

-- Creating foreign key on [MainHeadId] in table 'AccLiabilitiesRpts'
ALTER TABLE [dbo].[AccLiabilitiesRpts]
ADD CONSTRAINT [FK_AccLiabilitiesRpt_AccMainHeads]
    FOREIGN KEY ([MainHeadId])
    REFERENCES [dbo].[AccMainHeads]
        ([MainHeadId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccLiabilitiesRpt_AccMainHeads'
CREATE INDEX [IX_FK_AccLiabilitiesRpt_AccMainHeads]
ON [dbo].[AccLiabilitiesRpts]
    ([MainHeadId]);
GO

-- Creating foreign key on [MainHeadId] in table 'AccSubCode1'
ALTER TABLE [dbo].[AccSubCode1]
ADD CONSTRAINT [FK_AccSubCode1_AccMainHeads]
    FOREIGN KEY ([MainHeadId])
    REFERENCES [dbo].[AccMainHeads]
        ([MainHeadId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccSubCode1_AccMainHeads'
CREATE INDEX [IX_FK_AccSubCode1_AccMainHeads]
ON [dbo].[AccSubCode1]
    ([MainHeadId]);
GO

-- Creating foreign key on [MainHeadId] in table 'AccSubCode2'
ALTER TABLE [dbo].[AccSubCode2]
ADD CONSTRAINT [FK_AccSubCode2_AccMainHeads]
    FOREIGN KEY ([MainHeadId])
    REFERENCES [dbo].[AccMainHeads]
        ([MainHeadId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccSubCode2_AccMainHeads'
CREATE INDEX [IX_FK_AccSubCode2_AccMainHeads]
ON [dbo].[AccSubCode2]
    ([MainHeadId]);
GO

-- Creating foreign key on [MainVoucherId] in table 'AccSubVouchers'
ALTER TABLE [dbo].[AccSubVouchers]
ADD CONSTRAINT [FK_AccSubVoucher_AccMainVoucher]
    FOREIGN KEY ([MainVoucherId])
    REFERENCES [dbo].[AccMainVouchers]
        ([MainVoucherId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccSubVoucher_AccMainVoucher'
CREATE INDEX [IX_FK_AccSubVoucher_AccMainVoucher]
ON [dbo].[AccSubVouchers]
    ([MainVoucherId]);
GO

-- Creating foreign key on [MainVoucherId] in table 'AccSubVouchers'
ALTER TABLE [dbo].[AccSubVouchers]
ADD CONSTRAINT [FK_AccSubVouchers_AccMainVouchers]
    FOREIGN KEY ([MainVoucherId])
    REFERENCES [dbo].[AccMainVouchers]
        ([MainVoucherId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccSubVouchers_AccMainVouchers'
CREATE INDEX [IX_FK_AccSubVouchers_AccMainVouchers]
ON [dbo].[AccSubVouchers]
    ([MainVoucherId]);
GO

-- Creating foreign key on [SubCode_1Id] in table 'AccSubCode2'
ALTER TABLE [dbo].[AccSubCode2]
ADD CONSTRAINT [FK_AccSubCode2_AccSubCode1]
    FOREIGN KEY ([SubCode_1Id])
    REFERENCES [dbo].[AccSubCode1]
        ([SubCode_1Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccSubCode2_AccSubCode1'
CREATE INDEX [IX_FK_AccSubCode2_AccSubCode1]
ON [dbo].[AccSubCode2]
    ([SubCode_1Id]);
GO

-- Creating foreign key on [CRSubCoId2] in table 'AccTransDetails'
ALTER TABLE [dbo].[AccTransDetails]
ADD CONSTRAINT [FK_AccTransDetails_AccSubCode2]
    FOREIGN KEY ([CRSubCoId2])
    REFERENCES [dbo].[AccSubCode2]
        ([SubCode2_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccTransDetails_AccSubCode2'
CREATE INDEX [IX_FK_AccTransDetails_AccSubCode2]
ON [dbo].[AccTransDetails]
    ([CRSubCoId2]);
GO

-- Creating foreign key on [DRSubCoId2] in table 'AccTransDetails'
ALTER TABLE [dbo].[AccTransDetails]
ADD CONSTRAINT [FK_AccTransDetails_AccSubCode21]
    FOREIGN KEY ([DRSubCoId2])
    REFERENCES [dbo].[AccSubCode2]
        ([SubCode2_Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccTransDetails_AccSubCode21'
CREATE INDEX [IX_FK_AccTransDetails_AccSubCode21]
ON [dbo].[AccTransDetails]
    ([DRSubCoId2]);
GO

-- Creating foreign key on [CrSubVoucherId] in table 'AccTransDetails'
ALTER TABLE [dbo].[AccTransDetails]
ADD CONSTRAINT [FK_AccTransDetails_AccSubVouchers]
    FOREIGN KEY ([CrSubVoucherId])
    REFERENCES [dbo].[AccSubVouchers]
        ([SubVoucherId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccTransDetails_AccSubVouchers'
CREATE INDEX [IX_FK_AccTransDetails_AccSubVouchers]
ON [dbo].[AccTransDetails]
    ([CrSubVoucherId]);
GO

-- Creating foreign key on [DrSubVoucherId] in table 'AccTransDetails'
ALTER TABLE [dbo].[AccTransDetails]
ADD CONSTRAINT [FK_AccTransDetails_AccSubVouchers1]
    FOREIGN KEY ([DrSubVoucherId])
    REFERENCES [dbo].[AccSubVouchers]
        ([SubVoucherId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccTransDetails_AccSubVouchers1'
CREATE INDEX [IX_FK_AccTransDetails_AccSubVouchers1]
ON [dbo].[AccTransDetails]
    ([DrSubVoucherId]);
GO

-- Creating foreign key on [TranId] in table 'AccTransDetails'
ALTER TABLE [dbo].[AccTransDetails]
ADD CONSTRAINT [FK_AccTransDetails_AccTranItem]
    FOREIGN KEY ([TranId])
    REFERENCES [dbo].[AccTranItems]
        ([TranId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_AccTransDetails_AccTranItem'
CREATE INDEX [IX_FK_AccTransDetails_AccTranItem]
ON [dbo].[AccTransDetails]
    ([TranId]);
GO

-- Creating foreign key on [CategoryId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_CategoryProduct]
    FOREIGN KEY ([CategoryId])
    REFERENCES [dbo].[Categories]
        ([CatId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_CategoryProduct'
CREATE INDEX [IX_FK_CategoryProduct]
ON [dbo].[Products]
    ([CategoryId]);
GO

-- Creating foreign key on [CompId] in table 'InvenCentralPurchcasePayments'
ALTER TABLE [dbo].[InvenCentralPurchcasePayments]
ADD CONSTRAINT [FK_InvenCentralPurchcasePayments_CompanyInfoes]
    FOREIGN KEY ([CompId])
    REFERENCES [dbo].[CompanyInfoes]
        ([CompId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenCentralPurchcasePayments_CompanyInfoes'
CREATE INDEX [IX_FK_InvenCentralPurchcasePayments_CompanyInfoes]
ON [dbo].[InvenCentralPurchcasePayments]
    ([CompId]);
GO

-- Creating foreign key on [CompId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_Products_CompanyInfoes]
    FOREIGN KEY ([CompId])
    REFERENCES [dbo].[CompanyInfoes]
        ([CompId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Products_CompanyInfoes'
CREATE INDEX [IX_FK_Products_CompanyInfoes]
ON [dbo].[Products]
    ([CompId]);
GO

-- Creating foreign key on [CompId] in table 'PurchaseInfoes'
ALTER TABLE [dbo].[PurchaseInfoes]
ADD CONSTRAINT [FK_PurchaseInfoes_CompanyInfoes]
    FOREIGN KEY ([CompId])
    REFERENCES [dbo].[CompanyInfoes]
        ([CompId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseInfoes_CompanyInfoes'
CREATE INDEX [IX_FK_PurchaseInfoes_CompanyInfoes]
ON [dbo].[PurchaseInfoes]
    ([CompId]);
GO

-- Creating foreign key on [EmpId] in table 'EmpEducations'
ALTER TABLE [dbo].[EmpEducations]
ADD CONSTRAINT [FK_EmpEducations_Employees]
    FOREIGN KEY ([EmpId])
    REFERENCES [dbo].[Employees]
        ([EmpId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpEducations_Employees'
CREATE INDEX [IX_FK_EmpEducations_Employees]
ON [dbo].[EmpEducations]
    ([EmpId]);
GO

-- Creating foreign key on [EmpId] in table 'EmpExperienceInfoes'
ALTER TABLE [dbo].[EmpExperienceInfoes]
ADD CONSTRAINT [FK_EmpExperienceInfoes_Employees]
    FOREIGN KEY ([EmpId])
    REFERENCES [dbo].[Employees]
        ([EmpId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpExperienceInfoes_Employees'
CREATE INDEX [IX_FK_EmpExperienceInfoes_Employees]
ON [dbo].[EmpExperienceInfoes]
    ([EmpId]);
GO

-- Creating foreign key on [EmpSpecilistId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employees_EmpSpecialists]
    FOREIGN KEY ([EmpSpecilistId])
    REFERENCES [dbo].[EmpSpecialists]
        ([EmpSpecilistId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Employees_EmpSpecialists'
CREATE INDEX [IX_FK_Employees_EmpSpecialists]
ON [dbo].[Employees]
    ([EmpSpecilistId]);
GO

-- Creating foreign key on [EmpTypeId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employees_EmpTypes]
    FOREIGN KEY ([EmpTypeId])
    REFERENCES [dbo].[EmpTypes]
        ([EmpTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Employees_EmpTypes'
CREATE INDEX [IX_FK_Employees_EmpTypes]
ON [dbo].[Employees]
    ([EmpTypeId]);
GO

-- Creating foreign key on [BrProId] in table 'Employees'
ALTER TABLE [dbo].[Employees]
ADD CONSTRAINT [FK_Employees_InvenBranchProfile]
    FOREIGN KEY ([BrProId])
    REFERENCES [dbo].[InvenBranchProfiles]
        ([BrProId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Employees_InvenBranchProfile'
CREATE INDEX [IX_FK_Employees_InvenBranchProfile]
ON [dbo].[Employees]
    ([BrProId]);
GO

-- Creating foreign key on [EmpId] in table 'EmpTrainings'
ALTER TABLE [dbo].[EmpTrainings]
ADD CONSTRAINT [FK_EmpTrainings_Employees]
    FOREIGN KEY ([EmpId])
    REFERENCES [dbo].[Employees]
        ([EmpId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpTrainings_Employees'
CREATE INDEX [IX_FK_EmpTrainings_Employees]
ON [dbo].[EmpTrainings]
    ([EmpId]);
GO

-- Creating foreign key on [EmpId] in table 'PayUserRoles'
ALTER TABLE [dbo].[PayUserRoles]
ADD CONSTRAINT [FK_PayUserRole_Employees]
    FOREIGN KEY ([EmpId])
    REFERENCES [dbo].[Employees]
        ([EmpId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PayUserRole_Employees'
CREATE INDEX [IX_FK_PayUserRole_Employees]
ON [dbo].[PayUserRoles]
    ([EmpId]);
GO

-- Creating foreign key on [EmpTypeId] in table 'EmpSpecialists'
ALTER TABLE [dbo].[EmpSpecialists]
ADD CONSTRAINT [FK_EmpSpecialists_EmpTypes]
    FOREIGN KEY ([EmpTypeId])
    REFERENCES [dbo].[EmpTypes]
        ([EmpTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_EmpSpecialists_EmpTypes'
CREATE INDEX [IX_FK_EmpSpecialists_EmpTypes]
ON [dbo].[EmpSpecialists]
    ([EmpTypeId]);
GO

-- Creating foreign key on [ExHeadId] in table 'Expenses'
ALTER TABLE [dbo].[Expenses]
ADD CONSTRAINT [FK_Expenses_ExpenseHeads]
    FOREIGN KEY ([ExHeadId])
    REFERENCES [dbo].[ExpenseHeads]
        ([ExHeadId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_Expenses_ExpenseHeads'
CREATE INDEX [IX_FK_Expenses_ExpenseHeads]
ON [dbo].[Expenses]
    ([ExHeadId]);
GO

-- Creating foreign key on [CompProId] in table 'InvenBranchProfiles'
ALTER TABLE [dbo].[InvenBranchProfiles]
ADD CONSTRAINT [FK_InvenBranchProfile_InvenCompProfileInfo]
    FOREIGN KEY ([CompProId])
    REFERENCES [dbo].[InvenCompProfileInfoes]
        ([CompProId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenBranchProfile_InvenCompProfileInfo'
CREATE INDEX [IX_FK_InvenBranchProfile_InvenCompProfileInfo]
ON [dbo].[InvenBranchProfiles]
    ([CompProId]);
GO

-- Creating foreign key on [BrProId] in table 'InvenCentralChallanInfoes'
ALTER TABLE [dbo].[InvenCentralChallanInfoes]
ADD CONSTRAINT [FK_InvenCentralChallanInfo_InvenBranchProfile]
    FOREIGN KEY ([BrProId])
    REFERENCES [dbo].[InvenBranchProfiles]
        ([BrProId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenCentralChallanInfo_InvenBranchProfile'
CREATE INDEX [IX_FK_InvenCentralChallanInfo_InvenBranchProfile]
ON [dbo].[InvenCentralChallanInfoes]
    ([BrProId]);
GO

-- Creating foreign key on [BrProId] in table 'InvenChangeInfoes'
ALTER TABLE [dbo].[InvenChangeInfoes]
ADD CONSTRAINT [FK_InvenChangeInfoes_InvenBranchProfile]
    FOREIGN KEY ([BrProId])
    REFERENCES [dbo].[InvenBranchProfiles]
        ([BrProId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenChangeInfoes_InvenBranchProfile'
CREATE INDEX [IX_FK_InvenChangeInfoes_InvenBranchProfile]
ON [dbo].[InvenChangeInfoes]
    ([BrProId]);
GO

-- Creating foreign key on [BrProId] in table 'InvenPerRequisitions'
ALTER TABLE [dbo].[InvenPerRequisitions]
ADD CONSTRAINT [FK_InvenPerRequisition_InvenBranchProfile]
    FOREIGN KEY ([BrProId])
    REFERENCES [dbo].[InvenBranchProfiles]
        ([BrProId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenPerRequisition_InvenBranchProfile'
CREATE INDEX [IX_FK_InvenPerRequisition_InvenBranchProfile]
ON [dbo].[InvenPerRequisitions]
    ([BrProId]);
GO

-- Creating foreign key on [BrProId] in table 'InvenPurOrders'
ALTER TABLE [dbo].[InvenPurOrders]
ADD CONSTRAINT [FK_InvenPurOrder_InvenBranchProfile]
    FOREIGN KEY ([BrProId])
    REFERENCES [dbo].[InvenBranchProfiles]
        ([BrProId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenPurOrder_InvenBranchProfile'
CREATE INDEX [IX_FK_InvenPurOrder_InvenBranchProfile]
ON [dbo].[InvenPurOrders]
    ([BrProId]);
GO

-- Creating foreign key on [BrProId] in table 'InvenReorders'
ALTER TABLE [dbo].[InvenReorders]
ADD CONSTRAINT [FK_InvenReorder_InvenBranchProfile]
    FOREIGN KEY ([BrProId])
    REFERENCES [dbo].[InvenBranchProfiles]
        ([BrProId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenReorder_InvenBranchProfile'
CREATE INDEX [IX_FK_InvenReorder_InvenBranchProfile]
ON [dbo].[InvenReorders]
    ([BrProId]);
GO

-- Creating foreign key on [BrProId] in table 'InvenSalesInfoes'
ALTER TABLE [dbo].[InvenSalesInfoes]
ADD CONSTRAINT [FK_InvenSalesInfoes_InvenSalesInfoes]
    FOREIGN KEY ([BrProId])
    REFERENCES [dbo].[InvenBranchProfiles]
        ([BrProId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenSalesInfoes_InvenSalesInfoes'
CREATE INDEX [IX_FK_InvenSalesInfoes_InvenSalesInfoes]
ON [dbo].[InvenSalesInfoes]
    ([BrProId]);
GO

-- Creating foreign key on [BrProId] in table 'InvenStoreStatus'
ALTER TABLE [dbo].[InvenStoreStatus]
ADD CONSTRAINT [FK_InvenStoreStatus_InvenBranchProfile]
    FOREIGN KEY ([BrProId])
    REFERENCES [dbo].[InvenBranchProfiles]
        ([BrProId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenStoreStatus_InvenBranchProfile'
CREATE INDEX [IX_FK_InvenStoreStatus_InvenBranchProfile]
ON [dbo].[InvenStoreStatus]
    ([BrProId]);
GO

-- Creating foreign key on [BrProId] in table 'PayBankAccountInfoes'
ALTER TABLE [dbo].[PayBankAccountInfoes]
ADD CONSTRAINT [FK_PayBankAccountInfoes_InvenBranchProfile]
    FOREIGN KEY ([BrProId])
    REFERENCES [dbo].[InvenBranchProfiles]
        ([BrProId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PayBankAccountInfoes_InvenBranchProfile'
CREATE INDEX [IX_FK_PayBankAccountInfoes_InvenBranchProfile]
ON [dbo].[PayBankAccountInfoes]
    ([BrProId]);
GO

-- Creating foreign key on [BrProId] in table 'PayBankTransectionDtlInfoes'
ALTER TABLE [dbo].[PayBankTransectionDtlInfoes]
ADD CONSTRAINT [FK_PayBankTransectionDtlInfoes_InvenBranchProfile]
    FOREIGN KEY ([BrProId])
    REFERENCES [dbo].[InvenBranchProfiles]
        ([BrProId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PayBankTransectionDtlInfoes_InvenBranchProfile'
CREATE INDEX [IX_FK_PayBankTransectionDtlInfoes_InvenBranchProfile]
ON [dbo].[PayBankTransectionDtlInfoes]
    ([BrProId]);
GO

-- Creating foreign key on [BrProId] in table 'PayCompanyCashEntries'
ALTER TABLE [dbo].[PayCompanyCashEntries]
ADD CONSTRAINT [FK_PayCompanyCashEntries_InvenBranchProfile]
    FOREIGN KEY ([BrProId])
    REFERENCES [dbo].[InvenBranchProfiles]
        ([BrProId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PayCompanyCashEntries_InvenBranchProfile'
CREATE INDEX [IX_FK_PayCompanyCashEntries_InvenBranchProfile]
ON [dbo].[PayCompanyCashEntries]
    ([BrProId]);
GO

-- Creating foreign key on [BranchReturnId] in table 'InvenCentralReturns'
ALTER TABLE [dbo].[InvenCentralReturns]
ADD CONSTRAINT [FK_InvenCentralReturn_InvenBranchReturn]
    FOREIGN KEY ([BranchReturnId])
    REFERENCES [dbo].[InvenBranchReturns]
        ([BranchReturnId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenCentralReturn_InvenBranchReturn'
CREATE INDEX [IX_FK_InvenCentralReturn_InvenBranchReturn]
ON [dbo].[InvenCentralReturns]
    ([BranchReturnId]);
GO

-- Creating foreign key on [ProductId] in table 'InvenCenteralStoreStatus'
ALTER TABLE [dbo].[InvenCenteralStoreStatus]
ADD CONSTRAINT [FK_InvenCenteralStoreStatus_Products]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenCenteralStoreStatus_Products'
CREATE INDEX [IX_FK_InvenCenteralStoreStatus_Products]
ON [dbo].[InvenCenteralStoreStatus]
    ([ProductId]);
GO

-- Creating foreign key on [ChallanId] in table 'InvenCentralChallanDtls'
ALTER TABLE [dbo].[InvenCentralChallanDtls]
ADD CONSTRAINT [FK_InvenCentralChallanDtl_InvenCentralChallanInfo]
    FOREIGN KEY ([ChallanId])
    REFERENCES [dbo].[InvenCentralChallanInfoes]
        ([ChallanId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenCentralChallanDtl_InvenCentralChallanInfo'
CREATE INDEX [IX_FK_InvenCentralChallanDtl_InvenCentralChallanInfo]
ON [dbo].[InvenCentralChallanDtls]
    ([ChallanId]);
GO

-- Creating foreign key on [ProductId] in table 'InvenCentralChallanDtls'
ALTER TABLE [dbo].[InvenCentralChallanDtls]
ADD CONSTRAINT [FK_InvenCentralChallanDtl_Products]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenCentralChallanDtl_Products'
CREATE INDEX [IX_FK_InvenCentralChallanDtl_Products]
ON [dbo].[InvenCentralChallanDtls]
    ([ProductId]);
GO

-- Creating foreign key on [PurId] in table 'InvenCentralPurchaseDtls'
ALTER TABLE [dbo].[InvenCentralPurchaseDtls]
ADD CONSTRAINT [FK_InvenCentralPurchaseDtls_InvenCentralPurchaseInfoes]
    FOREIGN KEY ([PurId])
    REFERENCES [dbo].[InvenCentralPurchaseInfoes]
        ([PurId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenCentralPurchaseDtls_InvenCentralPurchaseInfoes'
CREATE INDEX [IX_FK_InvenCentralPurchaseDtls_InvenCentralPurchaseInfoes]
ON [dbo].[InvenCentralPurchaseDtls]
    ([PurId]);
GO

-- Creating foreign key on [ProductId] in table 'InvenCentralPurchaseDtls'
ALTER TABLE [dbo].[InvenCentralPurchaseDtls]
ADD CONSTRAINT [FK_InvenCentralPurchaseDtls_Products1]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenCentralPurchaseDtls_Products1'
CREATE INDEX [IX_FK_InvenCentralPurchaseDtls_Products1]
ON [dbo].[InvenCentralPurchaseDtls]
    ([ProductId]);
GO

-- Creating foreign key on [PurId] in table 'InvenCentralPurchcasePayments'
ALTER TABLE [dbo].[InvenCentralPurchcasePayments]
ADD CONSTRAINT [FK_InvenCentralPurchcasePayments_InvenCentralPurchaseInfoes]
    FOREIGN KEY ([PurId])
    REFERENCES [dbo].[InvenCentralPurchaseInfoes]
        ([PurId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenCentralPurchcasePayments_InvenCentralPurchaseInfoes'
CREATE INDEX [IX_FK_InvenCentralPurchcasePayments_InvenCentralPurchaseInfoes]
ON [dbo].[InvenCentralPurchcasePayments]
    ([PurId]);
GO

-- Creating foreign key on [PurPaymentId] in table 'InvenCentralPurchcasePaymentDtls'
ALTER TABLE [dbo].[InvenCentralPurchcasePaymentDtls]
ADD CONSTRAINT [FK_InvenCentralPurchcasePaymentDtls_InvenCentralPurchcasePayments]
    FOREIGN KEY ([PurPaymentId])
    REFERENCES [dbo].[InvenCentralPurchcasePayments]
        ([PurPaymentId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenCentralPurchcasePaymentDtls_InvenCentralPurchcasePayments'
CREATE INDEX [IX_FK_InvenCentralPurchcasePaymentDtls_InvenCentralPurchcasePayments]
ON [dbo].[InvenCentralPurchcasePaymentDtls]
    ([PurPaymentId]);
GO

-- Creating foreign key on [AccountInfoId] in table 'InvenCentralPurchcasePaymentDtls'
ALTER TABLE [dbo].[InvenCentralPurchcasePaymentDtls]
ADD CONSTRAINT [FK_InvenCentralPurchcasePaymentDtls_PayBankAccountInfoes]
    FOREIGN KEY ([AccountInfoId])
    REFERENCES [dbo].[PayBankAccountInfoes]
        ([AccountInfoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenCentralPurchcasePaymentDtls_PayBankAccountInfoes'
CREATE INDEX [IX_FK_InvenCentralPurchcasePaymentDtls_PayBankAccountInfoes]
ON [dbo].[InvenCentralPurchcasePaymentDtls]
    ([AccountInfoId]);
GO

-- Creating foreign key on [ProductId] in table 'InvenCentralPurRequisitions'
ALTER TABLE [dbo].[InvenCentralPurRequisitions]
ADD CONSTRAINT [FK_InvenCentralPurRequisition_Products]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenCentralPurRequisition_Products'
CREATE INDEX [IX_FK_InvenCentralPurRequisition_Products]
ON [dbo].[InvenCentralPurRequisitions]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'InvenCentrealPurOrders'
ALTER TABLE [dbo].[InvenCentrealPurOrders]
ADD CONSTRAINT [FK_InvenCentrealPurOrder_Products]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenCentrealPurOrder_Products'
CREATE INDEX [IX_FK_InvenCentrealPurOrder_Products]
ON [dbo].[InvenCentrealPurOrders]
    ([ProductId]);
GO

-- Creating foreign key on [ChangeId] in table 'InvenChangeDtls'
ALTER TABLE [dbo].[InvenChangeDtls]
ADD CONSTRAINT [FK_InvenChangeDtls_InvenChangeInfoes]
    FOREIGN KEY ([ChangeId])
    REFERENCES [dbo].[InvenChangeInfoes]
        ([ChangeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenChangeDtls_InvenChangeInfoes'
CREATE INDEX [IX_FK_InvenChangeDtls_InvenChangeInfoes]
ON [dbo].[InvenChangeDtls]
    ([ChangeId]);
GO

-- Creating foreign key on [SaleDtlId] in table 'InvenChangeDtls'
ALTER TABLE [dbo].[InvenChangeDtls]
ADD CONSTRAINT [FK_InvenChangeDtls_InvenSaleDtls]
    FOREIGN KEY ([SaleDtlId])
    REFERENCES [dbo].[InvenSaleDtls]
        ([SaleDtlId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenChangeDtls_InvenSaleDtls'
CREATE INDEX [IX_FK_InvenChangeDtls_InvenSaleDtls]
ON [dbo].[InvenChangeDtls]
    ([SaleDtlId]);
GO

-- Creating foreign key on [ProductId] in table 'InvenChangeDtls'
ALTER TABLE [dbo].[InvenChangeDtls]
ADD CONSTRAINT [FK_InvenChangeDtls_Products]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenChangeDtls_Products'
CREATE INDEX [IX_FK_InvenChangeDtls_Products]
ON [dbo].[InvenChangeDtls]
    ([ProductId]);
GO

-- Creating foreign key on [ChangeId] in table 'InvenChangePaymentDtls'
ALTER TABLE [dbo].[InvenChangePaymentDtls]
ADD CONSTRAINT [FK_InvenChangePaymentDtls_InvenChangeInfoes]
    FOREIGN KEY ([ChangeId])
    REFERENCES [dbo].[InvenChangeInfoes]
        ([ChangeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenChangePaymentDtls_InvenChangeInfoes'
CREATE INDEX [IX_FK_InvenChangePaymentDtls_InvenChangeInfoes]
ON [dbo].[InvenChangePaymentDtls]
    ([ChangeId]);
GO

-- Creating foreign key on [ChangeId] in table 'InvenChangePayments'
ALTER TABLE [dbo].[InvenChangePayments]
ADD CONSTRAINT [FK_InvenChangePayments_InvenChangeInfoes]
    FOREIGN KEY ([ChangeId])
    REFERENCES [dbo].[InvenChangeInfoes]
        ([ChangeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenChangePayments_InvenChangeInfoes'
CREATE INDEX [IX_FK_InvenChangePayments_InvenChangeInfoes]
ON [dbo].[InvenChangePayments]
    ([ChangeId]);
GO

-- Creating foreign key on [ProductId] in table 'InvenPerRequisitions'
ALTER TABLE [dbo].[InvenPerRequisitions]
ADD CONSTRAINT [FK_InvenPerRequisition_Products]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenPerRequisition_Products'
CREATE INDEX [IX_FK_InvenPerRequisition_Products]
ON [dbo].[InvenPerRequisitions]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'InvenPurOrders'
ALTER TABLE [dbo].[InvenPurOrders]
ADD CONSTRAINT [FK_InvenPurOrder_Products]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenPurOrder_Products'
CREATE INDEX [IX_FK_InvenPurOrder_Products]
ON [dbo].[InvenPurOrders]
    ([ProductId]);
GO

-- Creating foreign key on [ProductId] in table 'InvenReorders'
ALTER TABLE [dbo].[InvenReorders]
ADD CONSTRAINT [FK_InvenReorder_Products]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenReorder_Products'
CREATE INDEX [IX_FK_InvenReorder_Products]
ON [dbo].[InvenReorders]
    ([ProductId]);
GO

-- Creating foreign key on [SalId] in table 'InvenSaleDtls'
ALTER TABLE [dbo].[InvenSaleDtls]
ADD CONSTRAINT [FK_InvenSaleDtls_InvenSalesInfoes]
    FOREIGN KEY ([SalId])
    REFERENCES [dbo].[InvenSalesInfoes]
        ([SalId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenSaleDtls_InvenSalesInfoes'
CREATE INDEX [IX_FK_InvenSaleDtls_InvenSalesInfoes]
ON [dbo].[InvenSaleDtls]
    ([SalId]);
GO

-- Creating foreign key on [ProductId] in table 'InvenSaleDtls'
ALTER TABLE [dbo].[InvenSaleDtls]
ADD CONSTRAINT [FK_InvenSaleDtls_Products]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenSaleDtls_Products'
CREATE INDEX [IX_FK_InvenSaleDtls_Products]
ON [dbo].[InvenSaleDtls]
    ([ProductId]);
GO

-- Creating foreign key on [SalId] in table 'InvenSalePayments'
ALTER TABLE [dbo].[InvenSalePayments]
ADD CONSTRAINT [FK_InvenSalePayments_InvenSalesInfoes]
    FOREIGN KEY ([SalId])
    REFERENCES [dbo].[InvenSalesInfoes]
        ([SalId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenSalePayments_InvenSalesInfoes'
CREATE INDEX [IX_FK_InvenSalePayments_InvenSalesInfoes]
ON [dbo].[InvenSalePayments]
    ([SalId]);
GO

-- Creating foreign key on [SalId] in table 'InvenSalesPaymentDtls'
ALTER TABLE [dbo].[InvenSalesPaymentDtls]
ADD CONSTRAINT [FK_InvenSalesPaymentDtls_InvenSalesInfoes]
    FOREIGN KEY ([SalId])
    REFERENCES [dbo].[InvenSalesInfoes]
        ([SalId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenSalesPaymentDtls_InvenSalesInfoes'
CREATE INDEX [IX_FK_InvenSalesPaymentDtls_InvenSalesInfoes]
ON [dbo].[InvenSalesPaymentDtls]
    ([SalId]);
GO

-- Creating foreign key on [ProductId] in table 'InvenStoreStatus'
ALTER TABLE [dbo].[InvenStoreStatus]
ADD CONSTRAINT [FK_InvenStoreStatus_Products]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_InvenStoreStatus_Products'
CREATE INDEX [IX_FK_InvenStoreStatus_Products]
ON [dbo].[InvenStoreStatus]
    ([ProductId]);
GO

-- Creating foreign key on [AccountTypeId] in table 'PayBankAccountInfoes'
ALTER TABLE [dbo].[PayBankAccountInfoes]
ADD CONSTRAINT [FK_PayBankAccountInfoes_PayAccountTypeInfoes]
    FOREIGN KEY ([AccountTypeId])
    REFERENCES [dbo].[PayAccountTypeInfoes]
        ([AccountTypeId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PayBankAccountInfoes_PayAccountTypeInfoes'
CREATE INDEX [IX_FK_PayBankAccountInfoes_PayAccountTypeInfoes]
ON [dbo].[PayBankAccountInfoes]
    ([AccountTypeId]);
GO

-- Creating foreign key on [BankId] in table 'PayBankAccountInfoes'
ALTER TABLE [dbo].[PayBankAccountInfoes]
ADD CONSTRAINT [FK_PayBankAccountInfoes_PayBankInfoes]
    FOREIGN KEY ([BankId])
    REFERENCES [dbo].[PayBankInfoes]
        ([BankId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PayBankAccountInfoes_PayBankInfoes'
CREATE INDEX [IX_FK_PayBankAccountInfoes_PayBankInfoes]
ON [dbo].[PayBankAccountInfoes]
    ([BankId]);
GO

-- Creating foreign key on [AccountInfoId] in table 'PayBankTransectionDtlInfoes'
ALTER TABLE [dbo].[PayBankTransectionDtlInfoes]
ADD CONSTRAINT [FK_PayBankTransectionDtlInfo_PayBankTransectionInfo]
    FOREIGN KEY ([AccountInfoId])
    REFERENCES [dbo].[PayBankAccountInfoes]
        ([AccountInfoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PayBankTransectionDtlInfo_PayBankTransectionInfo'
CREATE INDEX [IX_FK_PayBankTransectionDtlInfo_PayBankTransectionInfo]
ON [dbo].[PayBankTransectionDtlInfoes]
    ([AccountInfoId]);
GO

-- Creating foreign key on [AccountInfoId] in table 'PayBankTransectionInfoes'
ALTER TABLE [dbo].[PayBankTransectionInfoes]
ADD CONSTRAINT [FK_PayBankTransectionInfo_PayBankAccountInfo]
    FOREIGN KEY ([AccountInfoId])
    REFERENCES [dbo].[PayBankAccountInfoes]
        ([AccountInfoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PayBankTransectionInfo_PayBankAccountInfo'
CREATE INDEX [IX_FK_PayBankTransectionInfo_PayBankAccountInfo]
ON [dbo].[PayBankTransectionInfoes]
    ([AccountInfoId]);
GO

-- Creating foreign key on [AccountInfoId] in table 'PurchcasePaymentDtls'
ALTER TABLE [dbo].[PurchcasePaymentDtls]
ADD CONSTRAINT [FK_PurchcasePaymentDtl_PayBankAccountInfoes]
    FOREIGN KEY ([AccountInfoId])
    REFERENCES [dbo].[PayBankAccountInfoes]
        ([AccountInfoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchcasePaymentDtl_PayBankAccountInfoes'
CREATE INDEX [IX_FK_PurchcasePaymentDtl_PayBankAccountInfoes]
ON [dbo].[PurchcasePaymentDtls]
    ([AccountInfoId]);
GO

-- Creating foreign key on [AccountInfoId] in table 'PurchcasePayments'
ALTER TABLE [dbo].[PurchcasePayments]
ADD CONSTRAINT [FK_PurchcasePayments_PayBankAccountInfoes]
    FOREIGN KEY ([AccountInfoId])
    REFERENCES [dbo].[PayBankAccountInfoes]
        ([AccountInfoId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchcasePayments_PayBankAccountInfoes'
CREATE INDEX [IX_FK_PurchcasePayments_PayBankAccountInfoes]
ON [dbo].[PurchcasePayments]
    ([AccountInfoId]);
GO

-- Creating foreign key on [RoleId] in table 'PayUserRoles'
ALTER TABLE [dbo].[PayUserRoles]
ADD CONSTRAINT [FK_PayUserRole_PayRole]
    FOREIGN KEY ([RoleId])
    REFERENCES [dbo].[PayRoles]
        ([RoleId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PayUserRole_PayRole'
CREATE INDEX [IX_FK_PayUserRole_PayRole]
ON [dbo].[PayUserRoles]
    ([RoleId]);
GO

-- Creating foreign key on [ProductId] in table 'PurchaseDtls'
ALTER TABLE [dbo].[PurchaseDtls]
ADD CONSTRAINT [FK_PurchaseDtls_Products]
    FOREIGN KEY ([ProductId])
    REFERENCES [dbo].[Products]
        ([ProductId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseDtls_Products'
CREATE INDEX [IX_FK_PurchaseDtls_Products]
ON [dbo].[PurchaseDtls]
    ([ProductId]);
GO

-- Creating foreign key on [UnitId] in table 'Products'
ALTER TABLE [dbo].[Products]
ADD CONSTRAINT [FK_UnitProduct]
    FOREIGN KEY ([UnitId])
    REFERENCES [dbo].[Units]
        ([UnitId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_UnitProduct'
CREATE INDEX [IX_FK_UnitProduct]
ON [dbo].[Products]
    ([UnitId]);
GO

-- Creating foreign key on [PurId] in table 'PurchaseDtls'
ALTER TABLE [dbo].[PurchaseDtls]
ADD CONSTRAINT [FK_PurchaseDtls_PurchaseInfoes]
    FOREIGN KEY ([PurId])
    REFERENCES [dbo].[PurchaseInfoes]
        ([PurId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchaseDtls_PurchaseInfoes'
CREATE INDEX [IX_FK_PurchaseDtls_PurchaseInfoes]
ON [dbo].[PurchaseDtls]
    ([PurId]);
GO

-- Creating foreign key on [PurId] in table 'PurchcasePaymentDtls'
ALTER TABLE [dbo].[PurchcasePaymentDtls]
ADD CONSTRAINT [FK_PurchcasePaymentDtl_PurchaseInfoes]
    FOREIGN KEY ([PurId])
    REFERENCES [dbo].[PurchaseInfoes]
        ([PurId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchcasePaymentDtl_PurchaseInfoes'
CREATE INDEX [IX_FK_PurchcasePaymentDtl_PurchaseInfoes]
ON [dbo].[PurchcasePaymentDtls]
    ([PurId]);
GO

-- Creating foreign key on [PurId] in table 'PurchcasePayments'
ALTER TABLE [dbo].[PurchcasePayments]
ADD CONSTRAINT [FK_PurchcasePayments_PurchaseInfoes]
    FOREIGN KEY ([PurId])
    REFERENCES [dbo].[PurchaseInfoes]
        ([PurId])
    ON DELETE NO ACTION ON UPDATE NO ACTION;

-- Creating non-clustered index for FOREIGN KEY 'FK_PurchcasePayments_PurchaseInfoes'
CREATE INDEX [IX_FK_PurchcasePayments_PurchaseInfoes]
ON [dbo].[PurchcasePayments]
    ([PurId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------