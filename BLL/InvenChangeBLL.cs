using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class InvenChangeBLL
    {
        InvenChangeDAL Dal = new InvenChangeDAL();
        public void SaveChangeInfo(InvenChangeInfoDto DTO)
        {
            Dal.SaveChangeInfo(DTO);
        }
        public void SaveChangeDtl(InvenChangeDtlDto DTO)
        {
            Dal.SaveChangeDtl(DTO);
        }
        public void Edit_ChangeDtl_CentralSendStatus(InvenChangeDtlDto DTO)
        {
             Dal.Edit_ChangeDtl_CentralSendStatus(DTO);
        }
        public void SaveChangePaymentInfo(InvenChangePaymentDto DTO)
        {
            Dal.SaveChangePaymentInfo(DTO);
        }
        public void SaveChangePaymentDtl(InvenChangePaymentDtlDto DTO)
        {
            Dal.SaveChangePaymentDtl(DTO);
        }
        public List<InvenChangeInfoDto> LoadChangeInofId()
        {
            return Dal.LoadChangeInofId();
        }
        //load sales  payument company 
        public List<InvenChangePaymentDtlDto> BranchWise_ChangeInfoLaod(int salid, int brid, string FromDate, string ToDate)
        {
            return Dal.BranchWise_ChangeInfoLaod(salid, brid, FromDate, ToDate);
        }
    }
}

