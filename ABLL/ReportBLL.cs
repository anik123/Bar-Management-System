using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
    public class ReportBLL
    {
        ReportDAL RDAL = new ReportDAL();
        // Last Journal Report
        public List<JournalDTO> LoadJournalData_update()
        {
            return RDAL.LoadJournalData_update();
        }
        // journal report when update in update journal page
        public List<JournalDTO> JournalReport_UpdateJournalPage(int TransectionNo)
        {
            return RDAL.JournalReport_UpdateJournalPage(TransectionNo);
        }
        // journal search by fromdate to todate
        public List<JournalDTO> JournalReport_DateToDate(DateTime fromdate, DateTime todate)
        {
            return RDAL.JournalReport_DateToDate(fromdate, todate);
        }
        // trail Balance search by fromdate to todate
        public List<LedgerDTO> TrialBalence_DateToDate(DateTime fromdate, DateTime todate)
        {
            return RDAL.TrialBalence_DateToDate(fromdate, todate);
        }
        // Account Payable search by fromdate to todate
        public List<LedgerDTO> AccountPayable(DateTime fromdate, DateTime todate, int accountid, string accountname, int compid, string compname)
        {
            return RDAL.AccountPayable(fromdate, todate, accountid, accountname, compid, compname);
        }
       
        //// Liabilities Report search by fromdate to todate
        public List<LedgerDTO> LiabilitiesReport(DateTime fromdate, DateTime todate, int subccode1id, int subcode2id)
        {
            return RDAL.LiabilitiesReport(fromdate, todate, subccode1id, subcode2id);
        }
        //Chart of Account
        public List<COAInfoDTO> ChartOfAccountReport(int mainheadid, int subcode1id, int subcode2id)
        {
            return RDAL.ChartOfAccountReport(mainheadid, subcode1id, subcode2id);
        }
        // ledger Rpt search by fromdate to todate
        public List<LedgerDTO> LedgerRpt(DateTime fromdate, DateTime todate, string coanum, int mainheadid, int subcode1id, int subcode2id, int coaid)
        {
            return RDAL.LedgerRpt(fromdate, todate, coanum, mainheadid, subcode1id, subcode2id, coaid);
        }
        // Balance sheet Report search by fromdate to todate
        public List<LedgerDTO> BalenceSheet(DateTime fromdate, DateTime todate)
        {
            return RDAL.BalenceSheet(fromdate, todate);
        }
        // Income  Statement_Manual Report search by fromdate to todate
        public List<LedgerDTO> IncomeStatement(double tax)
        {
            return RDAL.IncomeStatement(tax);
        }

        // Income statement

        // Income  Statement_HardCode Report search by fromdate to todate
        public List<LedgerDTO> IncomeStatement_HardCode_Income(double tax)
        {
            return RDAL.IncomeStatement_HardCode_Income(tax);
        }
        // Income  IncomeStatement_HardCode_Expense_CostOfGoodSold Report search by fromdate to todate
        public List<LedgerDTO> IncomeStatement_HardCode_Expense_CostOfGoodSold()
        {
            return RDAL.IncomeStatement_HardCode_Expense_CostOfGoodSold();
        }
        // Income  IncomeStatement_HardCode_Expense_OperatingExpense Report search by fromdate to todate
        public List<LedgerDTO> IncomeStatement_HardCode_Expense_OperatingExpense()
        {
            return RDAL.IncomeStatement_HardCode_Expense_OperatingExpense();
        }
        // Income  IncomeStatement_HardCode_Expense_FinancialExpence Report search by fromdate to todate
        public List<LedgerDTO> IncomeStatement_HardCode_Expense_FinancialExpence()
        {
            return RDAL.IncomeStatement_HardCode_Expense_FinancialExpence();
        }
        // Income  IncomeStatement_HardCode_Expense_FinancialExpence Report search by fromdate to todate
        public List<LedgerDTO> IncomeStatement_HardCode_Expense_otherExpense()
        {
            return RDAL.IncomeStatement_HardCode_Expense_otherExpense();
        }

        //  expence Report 
        public List<LedgerDTO> ExpenseReport(DateTime fromdate, DateTime todate)
        {
            return RDAL.ExpenseReport(fromdate, todate);
        }
          // Cash Flow Report search by fromdate to todate
        public List<LedgerDTO> CashFlowRept(DateTime fromdate, DateTime todate)
        {
            return RDAL.CashFlowRept(fromdate, todate);
        }
    }
}
