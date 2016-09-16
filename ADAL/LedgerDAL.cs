using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;
using ADTO;
using DAL;


namespace ADAL
{
    public class LedgerDAL
    {

        public void Add(LedgerDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                AccLedger gur = new AccLedger();
                container.AccLedgers.AddObject((AccLedger)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }


        // load data for ledger
        public List<LedgerDTO> LoadLedgerData(int ledgerid, int journalid, int coaid )
        {
            using (var Container = new InventoryContainer())
            {
                var query = from l in Container.AccLedgers
                            join j in Container.AccJournalEntries on l.JournalId equals j.JournalId
                           
                        
                            select new {l,j};

                if (journalid != 0)
                    query = query.Where(c => c.j.JournalId.Equals(journalid));
                if (ledgerid != 0)
                    query = query.Where(c => c.l.LedgerId.Equals(ledgerid));
                if (coaid != 0)
                    query = query.Where(c => c.j.AccCOAInfo.COAId.Equals(coaid));

                var result = from o in query

                          
                             orderby o.l.LedgerId descending
                             select new LedgerDTO
                             {
                                 JournalId = o.j.JournalId,
                                 LedgerId=o.l.LedgerId,
                                 CLBAL=o.l.CLBAL,
                                 OPBAL=o.l.OPBAL,
                                 DRAmount=o.l.DRAmount,
                                 CRAmount=o.l.CRAmount,

                             };
                return result.ToList<LedgerDTO>();
            }
         }
    }
}
