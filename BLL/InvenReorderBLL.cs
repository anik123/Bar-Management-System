using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class InvenReorderBLL
    {

        InvenReorderDal DAL = new InvenReorderDal();
        public void Add(InvenReorderDto DTO)
        {
            DAL.Add(DTO);
        }
        public void Edit(InvenReorderDto DTO)
        {
            DAL.Edit(DTO);
        }
        public void Edit_PurrequisitonStatus(InvenReorderDto DTO)
        {
            DAL.Edit_PurrequisitonStatus(DTO);
        }
        public List<InvenReorderDto> GetReorderInfo_UpdateProductInfo(int id, int catid, int brid, int compid, int proid)
        {
            return DAL.GetReorderInfo_UpdateProductInfo(id, catid, brid, compid, proid);
        }
        public List<InvenReorderDto> GetReorderInfo(int id, int catid, int brid, int compid, int proid)
        {
            return DAL.GetReorderInfo(id, catid, brid, compid, proid);
        }
        ////load  rate of interest
        //public List<InvenReorderDto> GetInterestPrice_OrderInfo_BranchWise(int brprid, int proid)
        //{
        //    return DAL.GetInterestPrice_OrderInfo_BranchWise(brprid, proid);
        //}
        //// for product reorder using outer join
        //public List<ProductDTO> GetProduct_Categorywise_ReorderLevel_New(int catid, int brproid)
        //{
        //    return DAL.GetProduct_Categorywise_ReorderLevel_New(catid, brproid);
        //}
        // for product reorder using outer join for update
        //public List<ProductDTO> GetProduct_Categorywise_ReorderLevel_Update(int catid, int brproid)
        //{
        //    return DAL.GetProduct_Categorywise_ReorderLevel_Update(catid, brproid);
        //}
    }
}
