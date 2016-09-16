using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using DAL;

namespace ADAL
{
    public class ReportDAL
    {
        // Last Journal Report
        public List<JournalDTO> LoadJournalData_update()
        {
            int lastprintId = 0;
            List<JournalDTO> outpatient = new List<JournalDTO>();
            using (var Container = new InventoryContainer())
            {
                var data = (from o in Container.AccJournalEntries

                            select o.TransectionNo).Max();
                lastprintId = Convert.ToInt32(data);

            }

            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccJournalEntries
                            join s2 in Container.AccSubCode2 on s.SubCode2Id equals s2.SubCode2_Id
                            join SV in Container.AccSubVouchers on s.SubVoucherId equals SV.SubVoucherId
                            join coa in Container.AccCOAInfoes on s.COAId equals coa.COAId
                            select new { s, s2, SV, coa };

                var result = from o in query
                             where o.s.TransectionNo.Equals(lastprintId)
                             orderby o.s.JournalId descending
                             select new JournalDTO
                             {
                                 JournalId = o.s.JournalId,
                                 TransectionNo = o.s.TransectionNo,
                                 DRAmount = o.s.DRAmount,
                                 CRAmount = o.s.CRAmount,
                                 TransectionDate = o.s.TransectionDate,
                                 VONO = o.s.VONO,
                                 MRNO = o.s.MRNO,
                                 Remarks = o.s.Remarks,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,
                                 UpdateBy = o.s.UpdateBy,
                                 UpdateDate = o.s.UpdateDate,
                                 JournalType = o.s.JournalType,

                                 SubCode2Id = o.s2.SubCode2_Id,
                                 SubCode2Name_Num = o.s2.SubCode2_Num + "-" + o.s2.SubCode_2Name,


                                 COAId = o.coa.COAId,
                                 COAName_Num = o.coa.COAACCId + "-" + o.coa.AccountName,
                                 AccountName = o.coa.AccountName,
                                 COAACCId = o.coa.COAACCId,

                                 SubVoucherId = o.SV.SubVoucherId,
                                 SubVoucherCodeName = o.SV.SubVoucherCode + "-" + o.SV.SubVoucherName,
                                 SubVoucherName = o.SV.SubVoucherName


                             };
                return result.ToList<JournalDTO>();
            }
        }

        // journal report when update in update journal page
        public List<JournalDTO> JournalReport_UpdateJournalPage(int TransectionNo)
        {


            using (var Container = new InventoryContainer())
            {
                var query = from l in Container.AccLedgers
                            join s in Container.AccJournalEntries on l.JournalId equals s.JournalId
                            join s2 in Container.AccSubCode2 on s.SubCode2Id equals s2.SubCode2_Id
                            join SV in Container.AccSubVouchers on s.SubVoucherId equals SV.SubVoucherId
                            join coa in Container.AccCOAInfoes on s.COAId equals coa.COAId
                            select new { l, s, s2, SV, coa };


                if (TransectionNo != 0)
                    query = query.Where(c => c.s.TransectionNo.Equals(TransectionNo));

                var result = from o in query
                             orderby o.s.JournalId descending
                             select new JournalDTO
                             {

                                 JournalId = o.s.JournalId,
                                 TransectionNo = o.s.TransectionNo,
                                 DRAmount = o.s.DRAmount,
                                 CRAmount = o.s.CRAmount,
                                 TransectionDate = o.s.TransectionDate,
                                 VONO = o.s.VONO,
                                 MRNO = o.s.MRNO,
                                 Remarks = o.s.Remarks,
                                 CreateBy = o.l.CreateBy,
                                 CreateDate = o.s.CreateDate,
                                 UpdateBy = o.s.UpdateBy,
                                 UpdateDate = o.s.UpdateDate,
                                 JournalType = o.s.JournalType,

                                 SubCode2Id = o.s2.SubCode2_Id,
                                 SubCode2Name_Num = o.s2.SubCode2_Num + "-" + o.s2.SubCode_2Name,


                                 COAId = o.coa.COAId,
                                 COAName_Num = o.coa.COAACCId + "-" + o.coa.AccountName,
                                 AccountName = o.coa.AccountName,
                                 COAACCId = o.coa.COAACCId,

                                 SubVoucherId = o.SV.SubVoucherId,
                                 SubVoucherCodeName = o.SV.SubVoucherCode + "-" + o.SV.SubVoucherName,
                                 SubVoucherName = o.SV.SubVoucherName,



                             };
                return result.ToList<JournalDTO>();
            }
        }

        // journal search by fromdate to todate
        public List<JournalDTO> JournalReport_DateToDate(DateTime fromdate, DateTime todate)
        {


            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccJournalEntries
                            join s2 in Container.AccSubCode2 on s.SubCode2Id equals s2.SubCode2_Id
                            join SV in Container.AccSubVouchers on s.SubVoucherId equals SV.SubVoucherId
                            join coa in Container.AccCOAInfoes on s.COAId equals coa.COAId
                            select new { s, s2, SV, coa };
                if (fromdate == Convert.ToDateTime(" 01/01/0001 12:00:00 AM") && todate == Convert.ToDateTime(" 01/01/0001 12:00:00 AM"))
                {
                    DateTime now = DateTime.Now;
                    DateTime FirstDayInMonth = new DateTime(now.Year, now.Month, 1);
                    fromdate = FirstDayInMonth;
                    todate = System.DateTime.Now;
                }

                var result = from o in query
                             // where Convert.ToString( o.s.TransectionDate).Equals(fromdate) && Convert.ToString( o.s.TransectionDate).Equals(todate)
                             where o.s.TransectionDate >= fromdate && o.s.TransectionDate <= todate

                             orderby o.s.JournalId descending
                             select new JournalDTO
                             {
                                 JournalId = o.s.JournalId,
                                 TransectionNo = o.s.TransectionNo,
                                 DRAmount = o.s.DRAmount,
                                 CRAmount = o.s.CRAmount,
                                 TransectionDate = o.s.TransectionDate,
                                 VONO = o.s.VONO,
                                 MRNO = o.s.MRNO,
                                 Remarks = o.s.Remarks,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,
                                 UpdateBy = o.s.UpdateBy,
                                 UpdateDate = o.s.UpdateDate,
                                 JournalType = o.s.JournalType,

                                 SubCode2Id = o.s2.SubCode2_Id,
                                 SubCode2Name_Num = o.s2.SubCode2_Num + "-" + o.s2.SubCode_2Name,

                                 // fromm && todate
                                 FromDate = fromdate,
                                 ToDate = todate,

                                 COAId = o.coa.COAId,
                                 COAName_Num = o.coa.COAACCId + "-" + o.coa.AccountName,
                                 AccountName = o.coa.AccountName,
                                 COAACCId = o.coa.COAACCId,

                                 SubVoucherId = o.SV.SubVoucherId,
                                 SubVoucherCodeName = o.SV.SubVoucherCode + "-" + o.SV.SubVoucherName,
                                 SubVoucherName = o.SV.SubVoucherName,



                             };
                return result.ToList<JournalDTO>();
            }
        }


        // trail Balance search by fromdate to todate
        public List<LedgerDTO> TrialBalence_DateToDate(DateTime fromdate, DateTime todate)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from l in Container.AccLedgers
                            join j in Container.AccJournalEntries on l.JournalId equals j.JournalId
                            join s2 in Container.AccSubCode2 on j.SubCode2Id equals s2.SubCode2_Id
                            join coa in Container.AccCOAInfoes on j.COAId equals coa.COAId
                            select new { l, j, s2, coa };
                if (fromdate == Convert.ToDateTime(" 01/01/0001 12:00:00 AM") && todate == Convert.ToDateTime(" 01/01/0001 12:00:00 AM"))
                {
                    DateTime now = DateTime.Now;
                    DateTime FirstDayInMonth = new DateTime(now.Year, now.Month, 1);
                    // DateTime lastdayInMonthe = FirstDayInMonth.AddMonths(1).AddDays(-1);

                    fromdate = FirstDayInMonth;
                    todate = System.DateTime.Now;
                }

                var result = from o in query
                             where o.l.CreateDate >= fromdate && o.l.CreateDate <= todate

                             group o.l by new {o.coa.AccountName, o.s2.AccSubCode1.AccMainHead.MainHeadName, o.s2.AccSubCode1.SubCode_1Name, o.s2.SubCode2_Id, o.s2.AccSubCode1.AccMainHead.MainHadeNum, o.s2.SubCode2_Num, o.s2.SubCode_2Name } into ls// o.s2.AccSubCode1.AccMainHead.MainHeadId 
                             orderby ls.Key.SubCode2_Num ascending
                             select new LedgerDTO
                             {

                                 DRAmount = ls.Sum(s => s.DRAmount),
                                 CRAmount = ls.Sum(s => s.CRAmount),
                                 MainheadNum = ls.Key.MainHadeNum,
                                 MainHeadName_Num = ls.Key.MainHadeNum + "-" + ls.Key.MainHeadName,
                                 SubCode_2Name = ls.Key.SubCode_2Name,
                                 SubCode2_Num = ls.Key.SubCode2_Num,

                                 SubCode_1Name=ls.Key.SubCode_1Name,
                                 MainHeadName=ls.Key.MainHeadName,
                                 AccountName=ls.Key.AccountName,


                                 // fromm && todate
                                 FromDate = fromdate,
                                 ToDate = todate,

                             };
                return result.ToList<LedgerDTO>();
            }
        }

        // Account Payable search by fromdate to todate
        public List<LedgerDTO> AccountPayable(DateTime fromdate, DateTime todate, int accountid, string accountname, int compid, string compname)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from l in Container.AccLedgers
                            join j in Container.AccJournalEntries on l.JournalId equals j.JournalId
                            join s2 in Container.AccSubCode2 on j.SubCode2Id equals s2.SubCode2_Id
                            join coa in Container.AccCOAInfoes on j.COAId equals coa.COAId
                            join SV in Container.AccSubVouchers on j.SubVoucherId equals SV.SubVoucherId
                            select new { l, j, s2, coa, SV };
                //if (!string.IsNullOrEmpty(accountname))
                //    query = query.Where(c => c.s2.SubCode_2Name.Contains(accountname));
                //if (accountid != 0)
                //    query = query.Where(c => c.s2.SubCode2_Id.Equals(accountid));

                var result = from o in query
                             where o.l.CreateDate >= fromdate && o.l.CreateDate <= todate

                             select new LedgerDTO
                             {
                                 // fromm && todate
                                 FromDate = fromdate,
                                 ToDate = todate,

                                 DRAmount = o.l.DRAmount,
                                 CRAmount = o.l.CRAmount,
                                 OPBAL = o.l.OPBAL,
                                 CLBAL = o.l.CLBAL,

                                 CreateDate = o.l.CreateDate,
                                 SubCode2Id = o.s2.SubCode2_Id,
                                 SubCode2Name_Num = o.s2.SubCode2_Num + "-" + o.s2.SubCode_2Name,


                                 COAId = o.coa.COAId,
                                 COAName_Num = o.coa.COAACCId + "-" + o.coa.AccountName,
                                 AccountName = o.coa.AccountName,
                                 COAACCId = o.coa.COAACCId,

                                 SubVoucherId = o.SV.SubVoucherId,
                                 SubVoucherCodeName = o.SV.SubVoucherCode + "-" + o.SV.SubVoucherName,
                                 SubVoucherName = o.SV.SubVoucherName,

                             };
                return result.ToList<LedgerDTO>();
            }
        }

        // Liabilities Report search by fromdate to todate
        public List<LedgerDTO> LiabilitiesReport(DateTime fromdate, DateTime todate, int subccode1id, int subcode2id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from l in Container.AccLedgers
                            join j in Container.AccJournalEntries on l.JournalId equals j.JournalId
                            join s2 in Container.AccSubCode2 on j.SubCode2Id equals s2.SubCode2_Id
                            join coa in Container.AccCOAInfoes on j.COAId equals coa.COAId
                            join SV in Container.AccSubVouchers on j.SubVoucherId equals SV.SubVoucherId
                            select new { l, j, s2, coa, SV };


                if (fromdate == Convert.ToDateTime(" 01/01/0001 12:00:00 AM") && todate == Convert.ToDateTime(" 01/01/0001 12:00:00 AM"))
                {
                    DateTime now = DateTime.Now;
                    DateTime FirstDayInMonth = new DateTime(now.Year, now.Month, 1);
                    //  DateTime lastdayInMonthe = FirstDayInMonth.AddMonths(1).AddDays(-1);

                    fromdate = FirstDayInMonth;
                    todate = System.DateTime.Now;
                }


                if (subccode1id != 0)
                    query = query.Where(c => c.s2.AccSubCode1.SubCode_1Id.Equals(subccode1id));
                if (subcode2id != 0)
                    query = query.Where(c => c.s2.SubCode2_Id.Equals(subcode2id));
                string maindheadid = "7000";
                var result = from o in query
                             where o.s2.AccSubCode1.AccMainHead.MainHadeNum == maindheadid && o.l.CreateDate >= fromdate && o.l.CreateDate <= todate  //&& o.s2.AccSubCode1.AccMainHead.MainHadeNum == "7000"
                             // where o.s2.AccSubCode1.AccMainHead.MainHadeNum=="7000" 


                             group o.l by new
                             {
                                 o.s2.SubCode2_Id,
                                 o.s2.SubCode_2Name,
                                 o.s2.SubCode2_Num,
                                 o.s2.AccSubCode1.SubCode_1Id,
                                 o.s2.AccSubCode1.SubCode_1Num,
                                 o.s2.AccSubCode1.SubCode_1Name,
                             } into ls
                             //   orderby ls.Key.SubCode2_Num ascending
                             select new LedgerDTO
                             {
                                 CRAmount = ls.Sum(s => s.CRAmount),

                                 SubCode2Id = ls.Key.SubCode2_Id,
                                 SubCode_2Name = ls.Key.SubCode_2Name,
                                 SubCode2_Num = ls.Key.SubCode2_Num,

                                 SubCode_1Id = ls.Key.SubCode_1Id,
                                 SubCode_1Name = ls.Key.SubCode_1Name,
                                 SubCode_1Num = ls.Key.SubCode_1Num,
                                 SubCode1Name_Num = ls.Key.SubCode_1Num + "-" + ls.Key.SubCode_1Name,
                                 // fromm && todate
                                 FromDate = fromdate,
                                 ToDate = todate,

                             };
                return result.ToList<LedgerDTO>();
            }
        }


        //Chart of Account
        public List<COAInfoDTO> ChartOfAccountReport(int mainheadid, int subcode1id, int subcode2id)
        {

            using (var Container = new InventoryContainer())
            {
                var query = from coa in Container.AccCOAInfoes
                            join s2 in Container.AccSubCode2 on coa.SubCode_2Id equals s2.SubCode2_Id
                            join s1 in Container.AccSubCode1 on s2.SubCode_1Id equals s1.SubCode_1Id
                            join main in Container.AccMainHeads on s1.MainHeadId equals main.MainHeadId
                            select new { coa, s2, s1, main };
                if (mainheadid != 0)
                    query = query.Where(c => c.main.MainHeadId.Equals(mainheadid));
                if (subcode1id != 0)
                    query = query.Where(c => c.s1.SubCode_1Id.Equals(subcode1id));
                if (subcode2id != 0)
                    query = query.Where(c => c.s2.SubCode2_Id.Equals(subcode2id));

                var result = from o in query
                             select new COAInfoDTO
                             {
                                 COAId = o.coa.COAId,
                                 AccountName = o.coa.COAACCId + "-" + o.coa.AccountName,
                                 COAACCId = o.coa.COAACCId,
                                 OpenBy = o.coa.OpenBy,
                                 OpeningDate = o.coa.OpeningDate,
                                 UpdateBy = o.coa.UpdateBy,
                                 UpdateDate = o.coa.UpdateDate,
                                 Balance = o.coa.Balance,

                                 MainHeadId = o.main.MainHeadId,
                                 MainheadNum = o.main.MainHadeNum,
                                 MainHeadName = o.main.MainHeadName,
                                 MainHeadName_Num = o.main.MainHadeNum + "-" + o.main.MainHeadName,

                                 SubCode_1Id = o.s1.SubCode_1Id,
                                 SubCode_1Name = o.s1.SubCode_1Name,
                                 SubCode_1Num = o.s1.SubCode_1Num,
                                 SubCode1Name_Num = o.s1.SubCode_1Num + "-" + o.s1.SubCode_1Name,

                                 SubCode_2Id = o.s2.SubCode2_Id,
                                 SubCode_2Name = o.s2.SubCode_2Name,
                                 SubCode2_Num = o.s2.SubCode2_Num,
                                 SubCode2Name_Num = o.s2.SubCode2_Num + "-" + o.s2.SubCode_2Name

                             };
                return result.ToList<COAInfoDTO>();
            }
        }


        // ledger Rpt search by fromdate to todate
        public List<LedgerDTO> LedgerRpt(DateTime fromdate, DateTime todate, string coanum, int mainheadid, int subcode1id, int subcode2id, int coaid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from l in Container.AccLedgers
                            join j in Container.AccJournalEntries on l.JournalId equals j.JournalId
                            join s2 in Container.AccSubCode2 on j.SubCode2Id equals s2.SubCode2_Id
                            join s1 in Container.AccSubCode1 on s2.SubCode_1Id equals s1.SubCode_1Id
                            join main in Container.AccMainHeads on s1.MainHeadId equals main.MainHeadId
                            join coa in Container.AccCOAInfoes on j.COAId equals coa.COAId
                            join SV in Container.AccSubVouchers on j.SubVoucherId equals SV.SubVoucherId
                            select new { l, j, s2, s1, main, coa, SV };
                if (!string.IsNullOrEmpty(coanum))
                    query = query.Where(c => c.coa.COAACCId.Contains(coanum));
                if (mainheadid != 0)
                    query = query.Where(c => c.main.MainHeadId.Equals(mainheadid));
                if (subcode1id != 0)
                    query = query.Where(c => c.s1.SubCode_1Id.Equals(subcode1id));
                if (subcode2id != 0)
                    query = query.Where(c => c.s2.SubCode2_Id.Equals(subcode2id));
                if (coaid != 0)
                    query = query.Where(c => c.coa.COAId.Equals(coaid));

                var result = from o in query
                             where o.l.CreateDate >= fromdate && o.l.CreateDate <= todate

                             select new LedgerDTO
                             {
                                 // fromm && todate
                                 FromDate = fromdate,
                                 ToDate = todate,

                                 LedgerId = o.l.LedgerId,
                                 DRAmount = o.l.DRAmount,
                                 CRAmount = o.l.CRAmount,
                                 OPBAL = o.l.OPBAL,
                                 CLBAL = o.l.CLBAL,

                                 JournalId = o.j.JournalId,

                                 CreateDate = o.l.CreateDate,
                                 CreateBy = o.l.CreateBy,
                                 SubCode2Id = o.s2.SubCode2_Id,
                                 SubCode2Name_Num = o.s2.SubCode2_Num + "-" + o.s2.SubCode_2Name,


                                 COAId = o.coa.COAId,
                                 COAName_Num = o.coa.COAACCId + "-" + o.coa.AccountName,
                                 AccountName = o.coa.AccountName,
                                 COAACCId = o.coa.COAACCId,



                             };
                return result.ToList<LedgerDTO>();
            }
        }

        // Balance sheet Report search by fromdate to todate
        public List<LedgerDTO> BalenceSheet(DateTime fromdate, DateTime todate)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from l in Container.AccLedgers
                            join j in Container.AccJournalEntries on l.JournalId equals j.JournalId
                            join s2 in Container.AccSubCode2 on j.SubCode2Id equals s2.SubCode2_Id
                            join s1 in Container.AccSubCode1 on s2.SubCode_1Id equals s1.SubCode_1Id
                            join main in Container.AccMainHeads on s1.MainHeadId equals main.MainHeadId
                            join balrpt in Container.AccBalanceSheetRpts on main.MainHeadId equals balrpt.MainHeadId
                            join coa in Container.AccCOAInfoes on j.COAId equals coa.COAId
                            join SV in Container.AccSubVouchers on j.SubVoucherId equals SV.SubVoucherId
                            select new { l, j, s2, s1, main, balrpt, coa, SV };
              //  string[] countries = new string[] { "7000", "9000" };


                if (fromdate == Convert.ToDateTime(" 01/01/0001 12:00:00 AM") && todate == Convert.ToDateTime(" 01/01/0001 12:00:00 AM"))
                {
                    DateTime now = DateTime.Now;
                    DateTime FirstDayInMonth = new DateTime(now.Year, now.Month, 1);
                    //  DateTime lastdayInMonthe = FirstDayInMonth.AddMonths(1).AddDays(-1);

                    fromdate = FirstDayInMonth;
                    todate = System.DateTime.Now;
                }


                var result = from o in query
                            
                            // where countries.Contains(o.s2.AccSubCode1.AccMainHead.MainHadeNum) && o.l.CreateDate >= fromdate && o.l.CreateDate <= todate
                             group o.l by new
                                {
                                    o.s2.AccSubCode1.AccMainHead.MainHeadId,
                                    o.s2.AccSubCode1.AccMainHead.MainHeadName,
                                    o.s2.AccSubCode1.AccMainHead.MainHadeNum,
                                    o.s2.SubCode2_Id,
                                    o.s2.SubCode_2Name,
                                    o.s2.SubCode2_Num,
                                    o.s2.AccSubCode1.SubCode_1Id,
                                    o.s2.AccSubCode1.SubCode_1Num,
                                    o.s2.AccSubCode1.SubCode_1Name,
                                    o.balrpt.Priority
                                } into ls

                             select new LedgerDTO
                             {



                                 DRAmount = ls.Sum(s => s.DRAmount),
                                 CRAmount = ls.Sum(s => s.CRAmount),
                                 SubCode2Id = ls.Key.SubCode2_Id,
                                 SubCode_2Name = ls.Key.SubCode_2Name,// + "-" + ls.Key.SubCode2_Num,
                                 SubCode2_Num = ls.Key.SubCode2_Num,

                                 SubCode_1Id = ls.Key.SubCode_1Id,
                                 SubCode_1Name = ls.Key.SubCode_1Name,//+ "-" + ls.Key.SubCode_1Num,

                                 MainHeadId = ls.Key.MainHeadId,
                                 MainHeadName = ls.Key.MainHeadName,//+ "-" + ls.Key.MainHadeNum,

                                 // fromm && todate
                                 FromDate = fromdate,
                                 ToDate = todate,

                             };
                return result.ToList<LedgerDTO>();
            }
        }

        // Income  Statement_Manual Report search by fromdate to todate
        public List<LedgerDTO> IncomeStatement(double tax)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from l in Container.AccLedgers
                            join j in Container.AccJournalEntries on l.JournalId equals j.JournalId
                            join s2 in Container.AccSubCode2 on j.SubCode2Id equals s2.SubCode2_Id
                            join s1 in Container.AccSubCode1 on s2.SubCode_1Id equals s1.SubCode_1Id
                            join main in Container.AccMainHeads on s1.MainHeadId equals main.MainHeadId
                            join incomerpt in Container.AccIncomeStatementRpts on main.MainHeadId equals incomerpt.MainHeadId
                            join coa in Container.AccCOAInfoes on j.COAId equals coa.COAId
                            join SV in Container.AccSubVouchers on j.SubVoucherId equals SV.SubVoucherId
                            select new { l, j, s2, s1, main, incomerpt, coa, SV };
                // string[] accno = new string[] { "5000", "4000" };


                var result = from o in query
                             // orderby o.incomerpt.Priority ascending

                             //  where accno.Contains(o.s2.AccSubCode1.AccMainHead.MainHadeNum)
                             //   orderby accno descending
                             // orderby accno.Substring(0, 1) descending 
                             //  orderby  o.coa.AccSubCode2.AccSubCode1.AccMainHead.MainHeadId ascending
                             group o.l by new
                             {
                                 o.s2.AccSubCode1.AccMainHead.MainHeadId,
                                 o.s2.AccSubCode1.AccMainHead.MainHeadName,
                                 o.s2.AccSubCode1.AccMainHead.MainHadeNum,
                                 o.s2.SubCode2_Id,
                                 o.s2.SubCode_2Name,
                                 o.s2.SubCode2_Num,

                                 o.s2.AccSubCode1.SubCode_1Id,
                                 o.s2.AccSubCode1.SubCode_1Num,
                                 o.s2.AccSubCode1.SubCode_1Name,

                                 o.incomerpt.Priority
                             }
                                 into ls
                                 orderby ls.Key.Priority descending
                                 //orderby ls.Key descending
                                 // orderby ls.Count() descending,ls.Key.MainHeadName
                                 // orderby ls.Key.MainHadeNum ascending
                                 //orderby ls.Key ascending
                                 select new LedgerDTO
                                 {
                                     DRAmount = ls.Sum(s => s.DRAmount),
                                     CRAmount = ls.Sum(s => s.CRAmount),
                                     SubCode2Id = ls.Key.SubCode2_Id,
                                     SubCode_2Name = ls.Key.SubCode_2Name,
                                     SubCode2_Num = ls.Key.SubCode2_Num,

                                     SubCode_1Id = ls.Key.SubCode_1Id,
                                     SubCode_1Name = ls.Key.SubCode_1Name,
                                     Priority = ls.Key.Priority,
                                     MainHeadId = ls.Key.MainHeadId,
                                     MainHeadName = ls.Key.MainHeadName,
                                     MainheadNum = ls.Key.MainHadeNum,
                                     Tax = tax
                                 };
                return result.ToList<LedgerDTO>();
            }
        }

        // Income  Statement_HardCode Report search by fromdate to todate
        public List<LedgerDTO> IncomeStatement_HardCode_Income(double tax)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from l in Container.AccLedgers
                            join j in Container.AccJournalEntries on l.JournalId equals j.JournalId
                            join s2 in Container.AccSubCode2 on j.SubCode2Id equals s2.SubCode2_Id
                            join coa in Container.AccCOAInfoes on j.COAId equals coa.COAId
                            join SV in Container.AccSubVouchers on j.SubVoucherId equals SV.SubVoucherId
                            select new { l, j, s2, coa, SV };

                //string[] str = new string[] { " bb.First().OpeningDate.ToString()" };
                //str = DateTime.Now.Date.ToShortDateString().Split('/');
                //int yearnew = Convert.ToInt16(str[2]);

                int curyear = System.DateTime.Now.Year;
                var result = from o in query


                             //    where   (c => c.l.cr.Month == 1)
                             where o.s2.AccSubCode1.AccMainHead.MainHadeNum == "5000" // && o.l.CreateDate.ToString("")
                             //&& o.l.CreateDate.Year = curyear //&& o.l.CreateDate.ToString("2012-MM-dd") == DateTime.Now.ToString("yyyy-MM-dd")
                             group o.l by new
                             {
                                 //year= o.l.CreateDate.ye
                                 o.s2.AccSubCode1.AccMainHead.MainHeadId,
                                 o.s2.AccSubCode1.AccMainHead.MainHeadName,
                                 o.s2.AccSubCode1.AccMainHead.MainHadeNum,
                                 o.s2.SubCode2_Id,
                                 o.s2.SubCode_2Name,
                                 o.s2.SubCode2_Num,
                                 o.s2.AccSubCode1.SubCode_1Id,
                                 o.s2.AccSubCode1.SubCode_1Num,
                                 o.s2.AccSubCode1.SubCode_1Name,
                             }
                                 into ls
                                 select new LedgerDTO
                                {
                                    DRAmount = ls.Sum(s => s.DRAmount),

                                    SubCode2Id = ls.Key.SubCode2_Id,
                                    SubCode_2Name = ls.Key.SubCode_2Name,
                                    SubCode2_Num = ls.Key.SubCode2_Num,

                                    SubCode_1Id = ls.Key.SubCode_1Id,
                                    SubCode_1Name = ls.Key.SubCode_1Name,

                                    MainHeadId = ls.Key.MainHeadId,
                                    MainHeadName = ls.Key.MainHeadName,
                                    MainheadNum = ls.Key.MainHadeNum,
                                    Tax = tax
                                };
                return result.ToList<LedgerDTO>();
            }
        }
        // Income  IncomeStatement_HardCode_Expense_CostOfGoodSold Report search by fromdate to todate
        public List<LedgerDTO> IncomeStatement_HardCode_Expense_CostOfGoodSold()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from l in Container.AccLedgers
                            join j in Container.AccJournalEntries on l.JournalId equals j.JournalId
                            join s2 in Container.AccSubCode2 on j.SubCode2Id equals s2.SubCode2_Id
                            join coa in Container.AccCOAInfoes on j.COAId equals coa.COAId
                            join SV in Container.AccSubVouchers on j.SubVoucherId equals SV.SubVoucherId
                            select new { l, j, s2, coa, SV };


                var result = from o in query
                             where o.s2.AccSubCode1.SubCode_1Num == "4003"
                             group o.l by new
                             {
                                 o.s2.AccSubCode1.AccMainHead.MainHeadId,
                                 o.s2.AccSubCode1.AccMainHead.MainHeadName,
                                 o.s2.AccSubCode1.AccMainHead.MainHadeNum,
                                 o.s2.SubCode2_Id,
                                 o.s2.SubCode_2Name,
                                 o.s2.SubCode2_Num,
                                 o.s2.AccSubCode1.SubCode_1Id,
                                 o.s2.AccSubCode1.SubCode_1Num,
                                 o.s2.AccSubCode1.SubCode_1Name,
                             }
                                 into ls
                                 select new LedgerDTO
                                 {
                                     CRAmount = ls.Sum(s => s.CRAmount),

                                     SubCode2Id = ls.Key.SubCode2_Id,
                                     SubCode_2Name = ls.Key.SubCode_2Name,
                                     SubCode2_Num = ls.Key.SubCode2_Num,

                                     SubCode_1Id = ls.Key.SubCode_1Id,
                                     SubCode_1Name = ls.Key.SubCode_1Name,

                                     MainHeadId = ls.Key.MainHeadId,
                                     MainHeadName = ls.Key.MainHeadName,
                                     MainheadNum = ls.Key.MainHadeNum,

                                 };
                return result.ToList<LedgerDTO>();
            }
        }
        // Income  IncomeStatement_HardCode_Expense_OperatingExpense Report search by fromdate to todate
        public List<LedgerDTO> IncomeStatement_HardCode_Expense_OperatingExpense()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from l in Container.AccLedgers
                            join j in Container.AccJournalEntries on l.JournalId equals j.JournalId
                            join s2 in Container.AccSubCode2 on j.SubCode2Id equals s2.SubCode2_Id
                            join coa in Container.AccCOAInfoes on j.COAId equals coa.COAId
                            join SV in Container.AccSubVouchers on j.SubVoucherId equals SV.SubVoucherId
                            select new { l, j, s2, coa, SV };


                var result = from o in query
                             where o.s2.AccSubCode1.SubCode_1Num == "4004"
                             group o.l by new
                             {
                                 o.s2.AccSubCode1.AccMainHead.MainHeadId,
                                 o.s2.AccSubCode1.AccMainHead.MainHeadName,
                                 o.s2.AccSubCode1.AccMainHead.MainHadeNum,
                                 o.s2.SubCode2_Id,
                                 o.s2.SubCode_2Name,
                                 o.s2.SubCode2_Num,
                                 o.s2.AccSubCode1.SubCode_1Id,
                                 o.s2.AccSubCode1.SubCode_1Num,
                                 o.s2.AccSubCode1.SubCode_1Name,
                             }
                                 into ls
                                 select new LedgerDTO
                                 {
                                     CRAmount = ls.Sum(s => s.CRAmount),

                                     SubCode2Id = ls.Key.SubCode2_Id,
                                     SubCode_2Name = ls.Key.SubCode_2Name,
                                     SubCode2_Num = ls.Key.SubCode2_Num,

                                     SubCode_1Id = ls.Key.SubCode_1Id,
                                     SubCode_1Name = ls.Key.SubCode_1Name,

                                     MainHeadId = ls.Key.MainHeadId,
                                     MainHeadName = ls.Key.MainHeadName,
                                     MainheadNum = ls.Key.MainHadeNum,

                                 };
                return result.ToList<LedgerDTO>();
            }
        }

        // Income  IncomeStatement_HardCode_Expense_FinancialExpence Report search by fromdate to todate
        public List<LedgerDTO> IncomeStatement_HardCode_Expense_FinancialExpence()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from l in Container.AccLedgers
                            join j in Container.AccJournalEntries on l.JournalId equals j.JournalId
                            join s2 in Container.AccSubCode2 on j.SubCode2Id equals s2.SubCode2_Id
                            join coa in Container.AccCOAInfoes on j.COAId equals coa.COAId
                            join SV in Container.AccSubVouchers on j.SubVoucherId equals SV.SubVoucherId
                            select new { l, j, s2, coa, SV };


                var result = from o in query
                             where o.s2.AccSubCode1.SubCode_1Num == "4002"
                             group o.l by new
                             {
                                 o.s2.AccSubCode1.AccMainHead.MainHeadId,
                                 o.s2.AccSubCode1.AccMainHead.MainHeadName,
                                 o.s2.AccSubCode1.AccMainHead.MainHadeNum,
                                 o.s2.SubCode2_Id,
                                 o.s2.SubCode_2Name,
                                 o.s2.SubCode2_Num,
                                 o.s2.AccSubCode1.SubCode_1Id,
                                 o.s2.AccSubCode1.SubCode_1Num,
                                 o.s2.AccSubCode1.SubCode_1Name,
                             }
                                 into ls
                                 select new LedgerDTO
                                 {
                                     CRAmount = ls.Sum(s => s.CRAmount),

                                     SubCode2Id = ls.Key.SubCode2_Id,
                                     SubCode_2Name = ls.Key.SubCode_2Name,
                                     SubCode2_Num = ls.Key.SubCode2_Num,

                                     SubCode_1Id = ls.Key.SubCode_1Id,
                                     SubCode_1Name = ls.Key.SubCode_1Name,

                                     MainHeadId = ls.Key.MainHeadId,
                                     MainHeadName = ls.Key.MainHeadName,
                                     MainheadNum = ls.Key.MainHadeNum,

                                 };
                return result.ToList<LedgerDTO>();
            }
        }

        // Income  IncomeStatement_HardCode_Expense_FinancialExpence Report search by fromdate to todate
        public List<LedgerDTO> IncomeStatement_HardCode_Expense_otherExpense()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from l in Container.AccLedgers
                            join j in Container.AccJournalEntries on l.JournalId equals j.JournalId
                            join s2 in Container.AccSubCode2 on j.SubCode2Id equals s2.SubCode2_Id
                            join coa in Container.AccCOAInfoes on j.COAId equals coa.COAId
                            join SV in Container.AccSubVouchers on j.SubVoucherId equals SV.SubVoucherId
                            select new { l, j, s2, coa, SV };




                var result = from o in query
                             where o.s2.AccSubCode1.SubCode_1Num == "4001" //&& o.l.CreateDate.g
                             group o.l by new
                             {
                                 o.s2.AccSubCode1.AccMainHead.MainHeadId,
                                 o.s2.AccSubCode1.AccMainHead.MainHeadName,
                                 o.s2.AccSubCode1.AccMainHead.MainHadeNum,
                                 o.s2.SubCode2_Id,
                                 o.s2.SubCode_2Name,
                                 o.s2.SubCode2_Num,
                                 o.s2.AccSubCode1.SubCode_1Id,
                                 o.s2.AccSubCode1.SubCode_1Num,
                                 o.s2.AccSubCode1.SubCode_1Name,
                             }
                                 into ls
                                 select new LedgerDTO
                                 {
                                     CRAmount = ls.Sum(s => s.CRAmount),

                                     SubCode2Id = ls.Key.SubCode2_Id,
                                     SubCode_2Name = ls.Key.SubCode_2Name,
                                     SubCode2_Num = ls.Key.SubCode2_Num,

                                     SubCode_1Id = ls.Key.SubCode_1Id,
                                     SubCode_1Name = ls.Key.SubCode_1Name,

                                     MainHeadId = ls.Key.MainHeadId,
                                     MainHeadName = ls.Key.MainHeadName,
                                     MainheadNum = ls.Key.MainHadeNum,

                                 };
                return result.ToList<LedgerDTO>();
            }
        }

        // end of hard code Income Satement


        //  expence Report 
        public List<LedgerDTO> ExpenseReport(DateTime fromdate, DateTime todate)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from l in Container.AccLedgers
                            join j in Container.AccJournalEntries on l.JournalId equals j.JournalId
                            join s2 in Container.AccSubCode2 on j.SubCode2Id equals s2.SubCode2_Id
                            join coa in Container.AccCOAInfoes on j.COAId equals coa.COAId
                            join SV in Container.AccSubVouchers on j.SubVoucherId equals SV.SubVoucherId
                            select new { l, j, s2, coa, SV };
                string[] accno = new string[] { "4000" };

                if (fromdate == Convert.ToDateTime(" 01/01/0001 12:00:00 AM") && todate == Convert.ToDateTime(" 01/01/0001 12:00:00 AM"))
                {
                    DateTime now = DateTime.Now;
                    DateTime FirstDayInMonth = new DateTime(now.Year, now.Month, 1);
                    fromdate = FirstDayInMonth;
                    todate = System.DateTime.Now;
                }


                var result = from o in query
                             where accno.Contains(o.s2.AccSubCode1.AccMainHead.MainHadeNum) && o.l.CreateDate >= fromdate && o.l.CreateDate <= todate
                             group o.l by new
                                 {
                                     o.s2.AccSubCode1.AccMainHead.MainHeadId,
                                     o.s2.AccSubCode1.AccMainHead.MainHeadName,
                                     o.s2.AccSubCode1.AccMainHead.MainHadeNum,
                                     o.s2.SubCode2_Id,
                                     o.s2.SubCode_2Name,
                                     o.s2.SubCode2_Num,
                                     o.s2.AccSubCode1.SubCode_1Id,
                                     o.s2.AccSubCode1.SubCode_1Num,
                                     o.s2.AccSubCode1.SubCode_1Name,
                                     o.coa.AccountName
                                 }
                                 into ls

                                 orderby ls.Key descending

                                 select new LedgerDTO
                                 {

                                     CRAmount = ls.Sum(s => s.CRAmount),
                                     AccountName = ls.Key.AccountName,
                                     SubCode2Id = ls.Key.SubCode2_Id,
                                     SubCode_2Name = ls.Key.SubCode_2Name,
                                     SubCode2_Num = ls.Key.SubCode2_Num,

                                     SubCode_1Id = ls.Key.SubCode_1Id,
                                     SubCode_1Name = ls.Key.SubCode_1Name,

                                     MainHeadId = ls.Key.MainHeadId,
                                     MainHeadName = ls.Key.MainHeadName,
                                     MainheadNum = ls.Key.MainHadeNum,

                                     FromDate = fromdate,
                                     ToDate = todate
                                 };
                return result.ToList<LedgerDTO>();
            }
        }


        // Cash Flow Report search by fromdate to todate
        public List<LedgerDTO> CashFlowRept(DateTime fromdate, DateTime todate)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from l in Container.AccLedgers
                            join j in Container.AccJournalEntries on l.JournalId equals j.JournalId
                            join s2 in Container.AccSubCode2 on j.SubCode2Id equals s2.SubCode2_Id
                            join coa in Container.AccCOAInfoes on j.COAId equals coa.COAId
                            join cfr in Container.AccCashFlowReports on coa.COAId equals cfr.COAId
                            join SV in Container.AccSubVouchers on j.SubVoucherId equals SV.SubVoucherId
                            select new { l, j, s2, coa, cfr, SV };


                if (fromdate == Convert.ToDateTime(" 01/01/0001 12:00:00 AM") && todate == Convert.ToDateTime(" 01/01/0001 12:00:00 AM"))
                {
                    // DateTime now = DateTime.Now;
                    // DateTime FirstDayInMonth = new DateTime(now.Year, now.Month, 1);
                    //  DateTime lastdayInMonthe = FirstDayInMonth.AddMonths(1).AddDays(-1);

                    fromdate = Convert.ToDateTime(" 01/05/2012");//FirstDayInMonth;
                    todate = System.DateTime.Now;
                }


                var result = from o in query
                             where o.l.CreateDate >= fromdate && o.l.CreateDate <= todate
                             group o.l by new
                             {
                                 o.cfr.AccCashFlowEntity.CFEName,
                                 o.s2.AccSubCode1.AccMainHead.MainHeadId,
                                 o.s2.AccSubCode1.AccMainHead.MainHeadName,
                                 o.s2.AccSubCode1.AccMainHead.MainHadeNum,
                                 o.s2.SubCode2_Id,
                                 o.s2.SubCode_2Name,
                                 o.s2.SubCode2_Num,
                                 o.s2.AccSubCode1.SubCode_1Id,
                                 o.s2.AccSubCode1.SubCode_1Num,
                                 o.s2.AccSubCode1.SubCode_1Name,
                                 o.coa.AccountName
                             } into ls

                             select new LedgerDTO
                             {


                                 CFEName = ls.Key.CFEName,
                                 DRAmount = ls.Sum(s => s.DRAmount),
                                 CRAmount = ls.Sum(s => s.CRAmount),
                                 SubCode2Id = ls.Key.SubCode2_Id,
                                 
                                 AccountName=ls.Key.AccountName,
                                 SubCode_2Name = ls.Key.SubCode_2Name,// + "-" + ls.Key.SubCode2_Num,
                                 SubCode2_Num = ls.Key.SubCode2_Num,

                                 SubCode_1Id = ls.Key.SubCode_1Id,
                                 SubCode_1Name = ls.Key.SubCode_1Name,//+ "-" + ls.Key.SubCode_1Num,

                                 MainHeadId = ls.Key.MainHeadId,
                                 MainHeadName = ls.Key.MainHeadName,//+ "-" + ls.Key.MainHadeNum,

                                 // fromm && todate
                                 FromDate = fromdate,
                                 ToDate = todate,

                             };
                return result.ToList<LedgerDTO>();
            }
        }
    }
}
