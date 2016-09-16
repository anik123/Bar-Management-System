using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
  public  class InvenPerRequisitionBLL
    {
        InvenPerRequisitionDal DAL = new InvenPerRequisitionDal();
        public void Add(InvenPerRequisitionDto DTO)
        {
            DAL.Add(DTO);
        }
        public void Edit(InvenPerRequisitionDto DTO)
        {
            DAL.Edit(DTO);
        }
        public void Edit_PurRequsitionStatus(InvenPerRequisitionDto DTO)
        {
            DAL.Edit_PurRequsitionStatus(DTO);
        }
        public List<InvenPerRequisitionDto> GetRequisitionInfo(int id, int reqno)
        {
            return DAL.GetRequisitionInfo(id, reqno);
        }
        public List<InvenPerRequisitionDto> GetRequisition_PurOrderpage(string FromDate, string ToDate, int CompanyId, int Recno)
        {
            return DAL.GetRequisition_PurOrderpage(FromDate, ToDate, CompanyId, Recno);
        }
        public List<InvenPerRequisitionDto> RequsiitonWiseProdctInfoLoad(int RecNo)
        {
            return DAL.RequsiitonWiseProdctInfoLoad(RecNo);
        }
        public List<InvenPerRequisitionDto> GetRequisitionNo_BranchChallen(string FromDate, string ToDate, int brproid, int Recno)
        {
            return DAL.GetRequisitionNo_BranchChallen(FromDate, ToDate, brproid, Recno);
        }
        public List<InvenPerRequisitionDto> GetReqList()
        {
            return DAL.GetReqList();
        }
    }
}
