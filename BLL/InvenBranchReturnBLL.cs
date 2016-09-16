using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class InvenBranchReturnBLL
    {
        InvenBranchReturnDAL DAL = new InvenBranchReturnDAL();
        public void SaveBranchReturn(InvenBranchReturnDTO DTO)
        {
            DAL.SaveBranchReturn(DTO);
        }
        public void Edit(InvenBranchReturnDTO DTO)
        {
            DAL.Edit(DTO);
        }
        // edit brnch central to party
        public void Edit_Central_To_Party(InvenBranchReturnDTO DTO)
        {
            DAL.Edit_Central_To_Party(DTO);
        }
        //load return product send to central company 
        public List<InvenChangePaymentDtlDto> Branchwise_Return_Product(int chdtlid, int catid, int compid, int brid, string FromDate, string ToDate)
        {
            return DAL.Branchwise_Return_Product(chdtlid, catid, compid, brid, FromDate, ToDate);
        }
        public List<InvenBranchReturnDTO> LoadReturnId()
        {
            return DAL.LoadReturnId();
        }
        //load return product recive  
        public List<InvenChangePaymentDtlDto> Central_Return_Product_Recive(int retunid, int catid, int productid, int compid, int brid, string FromDate, string ToDate)
        {
            return DAL.Central_Return_Product_Recive(retunid, catid, productid, compid, brid, FromDate, ToDate);
        }

        //load return product send  central to party 
        public List<InvenChangePaymentDtlDto> Central_Return_Product_To_Party(int retunid, int catid, int productid, int compid, int brid)
        {
            return DAL.Central_Return_Product_To_Party(retunid, catid, productid, compid, brid);
        }
        //branch  to central product rept
        public List<InvenChangePaymentDtlDto> Return_Branch_To_Central_ProductRpt_Detail(int brprid, int retunno, int compid, string FromDate, string ToDate)
        {
            return DAL.Return_Branch_To_Central_ProductRpt_Detail(brprid, retunno, compid, FromDate, ToDate);
        }
          //load return product send to central company 
        public List<InvenChangePaymentDtlDto> Branchwise_Return_ProductRpt(int retunno)
        {
            return DAL.Branchwise_Return_ProductRpt(retunno);
        }
    }
}
