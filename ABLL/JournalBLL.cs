using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
    public class JournalBLL
    {
        JournalDAL dal = new JournalDAL();
        public void Add(JournalDTO DTO)
        {
            dal.Add(DTO);
        }
        public void Edit(JournalDTO DTO)
        {
            dal.Edit(DTO);
        }
         // edit for journal update page
        public void Edit_JournalUpdate(JournalDTO DTO)
        {
            dal.Edit_JournalUpdate(DTO);
        }
        // load data for  page
        public List<JournalDTO> LoadJournalData_update(int jounalid)
        {
            return dal.LoadJournalData_update(jounalid);
        }
        // Load transection No
        public List<JournalDTO> Load_Journal_Transection_No()
        {
            return dal.Load_Journal_Transection_No();
        }
          // load data for  update journal link button
        public List<JournalDTO> LoadJournalUpdate_ladger(int jounalid, int transectionno)
        {
            return dal.LoadJournalUpdate_ladger(jounalid, transectionno);
        }

         // load data for  update journal for purchae duepayment load
        public List<JournalDTO> LoadJournalUpdate_Purchase_DuePayment(int coaid, int subcode2id, string referenceentity)
        {
            return dal.LoadJournalUpdate_Purchase_DuePayment(coaid, subcode2id, referenceentity);
        }
         // edit for journal update page
        public void Edit_Journal_Due_Payment(JournalDTO DTO)
        {
            dal.Edit_Journal_Due_Payment(DTO);
        }
    }
}
