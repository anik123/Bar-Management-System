using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
   public class LedgerBLL
   {
       LedgerDAL dal = new LedgerDAL();
       public void Add(LedgerDTO DTO)
       {
           dal.Add(DTO);
       }
       // load data for ledger
       public List<LedgerDTO> LoadLedgerData(int ledgerid, int journalid, int coaid)
       {
           return dal.LoadLedgerData(ledgerid, journalid,coaid);
       }
    }
}
