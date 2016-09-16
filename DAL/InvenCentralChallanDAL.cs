using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Utility;
using DTO;

namespace DAL
{
    public class InvenCentralChallanDAL
    {
        public void CentralChallan_BranchWise(InvenCentralChallanInfoDTO DTO)
        {

            using (var container = new InventoryContainer())
            {
                InvenCentralChallanInfo gur = new InvenCentralChallanInfo();
                container.InvenCentralChallanInfoes.AddObject((InvenCentralChallanInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }

        public void CentralChallanDtl_BranchWise(InvenCentralChallanDtlDTO DTO)
        {

            using (var container = new InventoryContainer())
            {
                InvenCentralChallanDtl gur = new InvenCentralChallanDtl();
                container.InvenCentralChallanDtls.AddObject((InvenCentralChallanDtl)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }

        }
        public List<InvenPerRequisitionDto> LoadBranchReqisitonNo(int reqid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenPerRequisitions
                            select new { s };
                if (reqid != 0)
                    query = query.Where(c => c.s.PurReqId.Equals(reqid));
                var result = from o in query

                             select new InvenPerRequisitionDto
                             {
                                 PurReqId = o.s.PurReqId,
                                 RequisitionNo = o.s.RequisitionNo,
                                 BrProId = o.s.InvenBranchProfile.BrProId


                             };
                return result.ToList<InvenPerRequisitionDto>();
            }
        }
        public List<InvenCentralChallanInfoDTO> LoadInvenCentralChallanID()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCentralChallanInfoes
                            select new { s };

                var result = from o in query
                             orderby o.s.ChallanId descending
                             select new InvenCentralChallanInfoDTO
                             {
                                 ChallanId = o.s.ChallanId

                             };
                return result.ToList<InvenCentralChallanInfoDTO>();
            }
        }

        // laod view all challen 
        public List<InvenCentralChallanInfoDTO> ChallenView_RptUI(int challenno, int brid, string FromDate, string ToDate)
        {
            DateTime To, From;
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCentralChallanInfoes
                            select new { s };
                if (!String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    //  To = To.AddDays(1);
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.s.ChallanDate >= From && c.s.ChallanDate <= To);
                }
                else if (String.IsNullOrEmpty(FromDate.ToString()) && !String.IsNullOrEmpty(ToDate.ToString()))
                {
                    To = Convert.ToDateTime(ToDate);
                    query = query.Where(c => c.s.ChallanDate == To);
                }
                else if (!String.IsNullOrEmpty(FromDate.ToString()) && String.IsNullOrEmpty(ToDate.ToString()))
                {
                    From = Convert.ToDateTime(FromDate);
                    query = query.Where(c => c.s.ChallanDate == From);
                }
                if (brid != 0)
                    query = query.Where(c => c.s.InvenBranchProfile.BrProId.Equals(brid));
                if (challenno != 0)
                    query = query.Where(c => c.s.ChallanId.Equals(challenno));
                var result = from o in query
                             orderby o.s.ChallanId descending
                             select new InvenCentralChallanInfoDTO
                             {
                                 ChallanId = o.s.ChallanId,
                                 ChallanDate = o.s.ChallanDate,
                                 ChallanBy = o.s.ChallanBy,
                                 BrProName = o.s.InvenBranchProfile.BrProName,
                                 Note = o.s.Note,
                                 PurReqNo = o.s.PurReqNo,
                                 BrProId=o.s.InvenBranchProfile.BrProId
                             };
                return result.ToList<InvenCentralChallanInfoDTO>();
            }
        }
    }
}
