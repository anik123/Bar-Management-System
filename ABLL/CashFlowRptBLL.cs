using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
    public class CashFlowRptBLL
    {

        CashFlowReportDAL dal = new CashFlowReportDAL();
        public void Add(CashFlowReportDTO DTO)
        {
            dal.Add(DTO);
        }
        public void Edit(CashFlowReportDTO DTO)
        {
            dal.Edit(DTO);
        }
        public List<CashFlowReportDTO> LoadCashFlowRptData(int crid, string cfname, string coaname, string subcode2name, string subcode1name, string mainheadname)
        {
            return dal.LoadCashFlowRptData(crid, cfname, coaname, subcode2name, subcode1name, mainheadname);
        }
    }
}
