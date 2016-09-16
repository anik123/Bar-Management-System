using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
    public class IncomeStatementRptBLL
    {

        IncomeStatementRptSetupDAL dal = new IncomeStatementRptSetupDAL();

        public void Add(IncomeStatementRptDTO DTO)
        {
            dal.Add(DTO);
        }
        public void Edit(IncomeStatementRptDTO DTO)
        {
            dal.Edit(DTO);
        }
        public List<IncomeStatementRptDTO> LoadIncomeStatementRpt(int id)
        {
            return dal.LoadIncomeStatementRpt(id);
        }
    }
}
