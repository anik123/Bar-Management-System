using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class InvenCentralStoreStatusBLL
    {
        InvenCentralStoreStatusDAL dal = new InvenCentralStoreStatusDAL();
        public void Add(InvenCentralStoreStatusDTO DTO)
        {
            dal.Add(DTO);
        }
        public void Edit(InvenCentralStoreStatusDTO DTO)
        {
            dal.Edit(DTO);
        }
        public void EditStoreQty (InvenCentralStoreStatusDTO DTO)
        {
            dal.EditStoreQty(DTO);
        }
        public void EditQty(InvenCentralStoreStatusDTO DTO)
        {
            dal.EditQty(DTO);
        }
        public void EditCenQty(InvenCentralStoreStatusDTO DTO)
        {
            dal.EditCenQty(DTO);
        }

        public List<InvenCentralStoreStatusDTO> LoadCentralStockStatus(int proid)
        {
            return dal.LoadCentralStockStatus(proid);
        }
        public List<ProductDTO> GetProduct(int proid, string productname, int catid, int unitid, int compid)
        {
            return dal.GetProduct(proid, productname, catid, unitid, compid);
        }

        public List<InvenCentralPurRequisitonDTO> CheckPurReq(int purid,int proid)
        {
            return dal.CheckPurReq(purid,proid);
        }

        public List<ProductDTO> GetProductForReorder(int proid, string productname, int catid, int unitid, int compid)
        {
            return dal.GetProductForReorder(proid, productname, catid, unitid, compid);
            
        }
        public List<ProductDTO> GetProductQunatity(int proid)
        {
            return dal.GetProductQunatity(proid);
        }
    }
}
