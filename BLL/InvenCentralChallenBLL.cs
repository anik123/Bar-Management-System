using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
   public class InvenCentralChallenBLL
    {
       InvenCentralChallanDAL Dal = new InvenCentralChallanDAL();
       public void CentralChallan_BranchWise(InvenCentralChallanInfoDTO DTO)
       {
           Dal.CentralChallan_BranchWise(DTO);
       }
       public void CentralChallanDtl_BranchWise(InvenCentralChallanDtlDTO DTO)
       {
           Dal.CentralChallanDtl_BranchWise(DTO);
       }
       public List<InvenPerRequisitionDto> LoadBranchReqisitonNo(int reqid)
       {
           return Dal.LoadBranchReqisitonNo(reqid);
       }
       public List<InvenCentralChallanInfoDTO> LoadInvenCentralChallanID()
       {
           return Dal.LoadInvenCentralChallanID();
       }
       // laod view all challen 
       public List<InvenCentralChallanInfoDTO> ChallenView_RptUI(int challenno, int brid, string FromDate, string ToDate)
       {
           return Dal.ChallenView_RptUI(challenno, brid, FromDate, ToDate);
       }
    }
}
