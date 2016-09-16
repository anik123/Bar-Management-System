using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
    public class BalanceSheetRptBLL
    {
        BalanceSheetRptDAL dal = new BalanceSheetRptDAL();
        public void Add(BalanceSheetRptDTO DTO)
        {
            dal.Add(DTO);
        }
        public void Edit(BalanceSheetRptDTO DTO)
        {
            dal.Edit(DTO);
        }
        public List<BalanceSheetRptDTO> LoadBalanceSheetRpt(int id)
        {
            return dal.LoadBalanceSheetRpt(id);
        }

        // check prority 

        public List<BalanceSheetRptDTO> CheckPriorityNumber(int id)
        {
            return dal.CheckPriorityNumber(id);
        }

    }
}
