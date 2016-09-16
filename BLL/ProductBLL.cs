using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class ProductBLL
    {
        ProductDAL DAL = new ProductDAL();
        public void Add(ProductDTO DTO)
        {
            DAL.Add(DTO);
        }

        public void Edit(ProductDTO DTO)
        {
            DAL.Edit(DTO);
        }

        public List<ProductDTO> GetProduct(int proid, string productname, int catid, int unitid, int compid)
        {
            return DAL.GetProduct(proid, productname, catid, unitid, compid);
        }

        public List<ProductDTO> GetProductForReOrder(int proid, string productname, int catid, int unitid, int compid)
        {
            return DAL.GetProductForReOrder(proid, productname, catid, unitid, compid);
        }

        public List<ProductDTO> GetProductForReturn(int compid, int catid, int proid)
        {
            return DAL.GetProductForReturn(compid, catid, proid);
        }

        public List<ProductDTO> GetProductForCentralReturn(int compid, int catid, int proid)
        {
            return DAL.GetProductForCentralReturn(compid, catid, proid);
        }
        // for product purchase 
        public List<ProductDTO> GetProduct_Categorywise(int id, int compid)
        {
            return DAL.GetProduct_Categorywise(id, compid);
        }

        public List<ProductDTO> GetProduct_Category(int id, int compid)
        {
            return DAL.GetProduct_Category(id, compid);
        }

        // for product reorder 
        public List<ProductDTO> GetProduct_Categorywise_ReorderLevel(int id)
        {
            return DAL.GetProduct_Categorywise_ReorderLevel(id);
        }
        public List<ProductDTO> GetUnnit_Productwise(int proid)
        {
            return DAL.GetUnnit_Productwise(proid);
        }
        // load all data for sales using  barcode  
        public List<ProductDTO> LoadALL_Using_BarCode_Sales(int proid)
        {
            return DAL.LoadALL_Using_BarCode_Sales(proid);
        }

        public List<ProductDTO> CheckProductCodeExits(int compid, string pcode, int pid)
        {
            return DAL.CheckProductCodeExits(compid, pcode, pid);
        }

        public void EditStatus(ProductDTO PDTO)
        {
            DAL.EditStatus(PDTO);
        }
        public List<ProductDTO> GetProductByCategory(string CateName)
        {
          return  DAL.GetProductByCategory(CateName);
        }
    }
}
