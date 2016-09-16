using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class InvenCentralReturnBLL
    {
        InvenCentralReturnDAL DAL = new InvenCentralReturnDAL();
        public void SaveCentralReturn(InvenCentralReturnDTO DTO)
        {
            DAL.SaveCentralReturn(DTO);
        }
        public List<InvenCentralReturnDTO> LaodPartyReturnNO()
        {
            return DAL.LaodPartyReturnNO();
        }
          //Central to party product rept
        public List<InvenChangePaymentDtlDto> Return_Central_To_Party_ProductRpt_Detail(int retunno, int compid, string FromDate, string ToDate)
        {
            return DAL.Return_Central_To_Party_ProductRpt_Detail(retunno, compid, FromDate, ToDate);
        }
          //Central to party product rept
        public List<InvenChangePaymentDtlDto> Return_Central_To_Party_ProductRpt(int retunno)
        {
            return DAL.Return_Central_To_Party_ProductRpt(retunno);
        }
    }
}
