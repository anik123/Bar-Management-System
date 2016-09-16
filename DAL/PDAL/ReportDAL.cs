using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using PDTO;

namespace DAL.PDAL
{
    public class ReportDAL
    {

        // individual bank account amount 
        public List<BankTransectionDtlDTO> BankAmountIndividual(int bankid, int accounttypeid)
        {

            using (var Container = new InventoryContainer())
            {
                var query =	//joins
              from traninfo in Container.PayBankTransectionInfoes

              join accountinfo in Container.PayBankAccountInfoes on traninfo.AccountInfoId equals accountinfo.AccountInfoId
              join bank in Container.PayBankInfoes on accountinfo.BankId equals bank.BankId
              join accctype in Container.PayAccountTypeInfoes on accountinfo.AccountTypeId equals accctype.AccountTypeId
              select new { traninfo, accountinfo, bank, accctype };


                if (bankid != 0)
                    query = query.Where(c => c.bank.BankId.Equals(bankid));
                if (accounttypeid != 0)
                    query = query.Where(c => c.accctype.AccountTypeId.Equals(accounttypeid));


                var result =
           from o in query
           orderby o.traninfo.BankTransectionId descending
           select new BankTransectionDtlDTO
           {
               BankName = o.bank.BankName,
               BranchName = o.accountinfo.BranchName,
               AccountTypeName = o.accctype.AccountTypeName,
               AccountName = o.accountinfo.AccountName + "-" + o.accountinfo.AccountNum,

               BankAmount = o.traninfo.BankAmount,
           };
                return result.ToList<BankTransectionDtlDTO>();
            }
        }

        // assest status current status
        public List<AssetDTO> CurrentAssetStatus()
        {
            using (var Container = new InventoryContainer())
            {
                var query =	//joins

                    from ass in Container.PayAssets
                    select new { ass };

                var result =
                from o in query
                select new AssetDTO
                {
                    BankAmount_Current = o.ass.BankAmount_Current,
                    CashAmount_Current = o.ass.CashAmount_Current
                }; return result.ToList<AssetDTO>();
            }
        }
        public List<CompanyCashEntryDTO> CashEntryOfCompany(int year, string month)
        {
            using (var Container = new InventoryContainer())
            {
                var query =
              from ab in Container.PayCompanyCashEntries
              join branch in Container.InvenBranchProfiles on ab.BrProId equals branch.BrProId

              select new { ab, branch };

                if (!string.IsNullOrEmpty(month))
                    query = query.Where(c => c.ab.Month.Equals(month));
                if (year != 0)
                    query = query.Where(c => c.ab.Year.Equals(year));

                var result =
           from o in query
           select new CompanyCashEntryDTO
           {

               CashAmount = o.ab.CashAmount,
               CashId = o.ab.CashId,
               CrateDate = o.ab.CrateDate,
               CreateBy = o.ab.CreateBy,
               Remarks = o.ab.Remarks,
               Year = o.ab.Year,
               Month = o.ab.Month,
               CollectionDate = o.ab.CollectionDate,
               BrProName= o.branch.BrProName
               

           };
                return result.ToList<CompanyCashEntryDTO>();
            }
        }
        public List<BankTransectionDtlDTO> BankTransectionRptdtl(DateTime fromdate, DateTime todate, int itemcolletionid)
        {

            using (var Container = new InventoryContainer())
            {
                var query =	//joins
              from trandtl in Container.PayBankTransectionDtlInfoes
              join branch in Container.InvenBranchProfiles on trandtl.BrProId equals branch.BrProId
              join accountinfo in Container.PayBankAccountInfoes on trandtl.AccountInfoId equals accountinfo.AccountInfoId
              join bank in Container.PayBankInfoes on accountinfo.BankId equals bank.BankId
              join accctype in Container.PayAccountTypeInfoes on accountinfo.AccountTypeId equals accctype.AccountTypeId
              select new { trandtl, branch, accountinfo, bank, accctype };


                if (itemcolletionid != 0)
                    query = query.Where(c => c.branch.BrProId.Equals(itemcolletionid));
                if (fromdate == Convert.ToDateTime(" 01/01/0001 12:00:00 AM") && todate == Convert.ToDateTime(" 01/01/0001 12:00:00 AM"))
                {
                    DateTime now = DateTime.Now;
                    DateTime FirstDayInMonth = new DateTime(now.Year, now.Month, 1);

                    fromdate = FirstDayInMonth;
                    todate = System.DateTime.Now;
                }


                var result =
           from o in query
           where o.trandtl.CollectionDate >= fromdate && o.trandtl.CollectionDate <= todate
           orderby o.trandtl.CollectionDate descending
           select new BankTransectionDtlDTO
           {

               // fromm && todate
               FromDate = fromdate,
               ToDate = todate,

               BranchName = o.bank.BankName + "-" + o.accountinfo.BranchName + "-" + o.accctype.AccountTypeName + "-" + o.accountinfo.AccountName + "(" + o.accountinfo.AccountNum + ")", //o.accountinfo.BranchName,

               Amount_EachTransection = o.trandtl.Amount_EachTransection,
               Remarks = o.trandtl.Remarks,
               CollectionDate = o.trandtl.CollectionDate,
               BrProName = o.branch.BrProName
           };
                return result.ToList<BankTransectionDtlDTO>();
            }
        }
    }
}
