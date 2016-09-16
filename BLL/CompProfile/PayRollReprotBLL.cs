using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.PDAL;
using PDTO;

namespace BLL.CompProfile
{
   public class PayRollReprotBLL
    {
       ReportDAL PayRptDal = new ReportDAL();
        // individual bank account amount 
        public List<BankTransectionDtlDTO> BankAmountIndividual(int bankid, int accounttypeid)
        {
            return PayRptDal.BankAmountIndividual(bankid, accounttypeid);
        }
        // assest status current status
        public List<AssetDTO> CurrentAssetStatus()
        {
            return PayRptDal.CurrentAssetStatus();
        }
        // Cash transection 
        public List<CompanyCashEntryDTO> CashEntryOfCompany(int year, string month)
        {
            return PayRptDal.CashEntryOfCompany(year, month);
        }
        public List<BankTransectionDtlDTO> BankTransectionRptdtl(DateTime fromdate, DateTime todate, int itemcolletionid)
        {
            return PayRptDal.BankTransectionRptdtl(fromdate, todate, itemcolletionid);
        }
    }
}
