using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class InvenCentralPurRequisitionBLL
    {
        InvenCentralPurRequisitonDAL DAL = new InvenCentralPurRequisitonDAL();
        public void Add(InvenCentralPurRequisitonDTO DTO)
        {
            DAL.Add(DTO);
        }
        public void Edit(InvenCentralPurRequisitonDTO DTO)
        {
            DAL.Edit(DTO);
        }
        public void Edit_PurRequsitionStatus(InvenCentralPurRequisitonDTO DTO)
        {
            DAL.Edit_PurRequsitionStatus(DTO);
        }
        public List<InvenCentralPurRequisitonDTO> GetRequisitionInfo(int id, int reqno)
        {
            return DAL.GetRequisitionInfo(id, reqno);
        }
        public List<InvenCentralPurRequisitonDTO> GetRequisition_PurOrderpage(string FromDate, string ToDate, int CompanyId, int Recno)
        {
            return DAL.GetRequisition_PurOrderpage(FromDate, ToDate, CompanyId, Recno);
        }
        public List<InvenCentralPurRequisitonDTO> GetReqList()
        {
            return DAL.GetReqList();
        }
        public List<InvenCentralPurRequisitonDTO> GetReqList_Dropdownlist()
        {
            return DAL.GetReqList_Dropdownlist();
        }
        public List<InvenCentralPurRequisitonDTO> GetRequisition_CentralPurOrderpage(string FromDate, string ToDate, int CompanyId, int Recno)
        {
            return DAL.GetRequisition_CentralPurOrderpage(FromDate, ToDate, CompanyId, Recno);
        }
        public List<InvenCentralPurRequisitonDTO> GetInfo(int RecNo)
        {
            return DAL.GetInfo(RecNo);
        }
        public List<InvenCentralPurRequisitonDTO> GetInfo_By_RequisitionNoWise(int RecNo)
        {
            return DAL.GetInfo_By_RequisitionNoWise(RecNo);
        }
    }
}
