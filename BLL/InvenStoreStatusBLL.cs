using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
    public class InvenStoreStatusBLL
    {
        InvenStoreStatusDal DAL = new InvenStoreStatusDal();
        public void Add(InvenStoreStatusDto DTO)
        {
            DAL.Add(DTO);
        }
        public void Edit(InvenStoreStatusDto DTO)
        {
            DAL.Edit(DTO);
        }

        public void EditQty(InvenStoreStatusDto DTO)
        {
            DAL.EditQty(DTO);
        }
        public List<InvenStoreStatusDto> GetStoreStatus_Central(int id, int catid, int proid, int branchid, int compid, int reordervalue)
        {
            return DAL.GetCurrentStockStaus(id, catid, proid, branchid, compid, reordervalue);
        }
        public List<InvenStoreStatusDto> GetStoreStatusById(int id, int catid, int proid, int branchid, int compid, int reordervalue)
        {

            return DAL.GetStoreStatusById(id, catid, proid, branchid,compid,reordervalue);
        }
        public List<InvenStoreStatusDto> GetCurrentStockStaus(int id, int catid, int proid, int branchid, int compid, int reordervalue)
        {
            return DAL.GetCurrentStockStaus(id, catid, proid, branchid, compid, reordervalue);
        }

        public List<InvenStoreStatusDto> GetStoreStatusByProId(int proid,int brnchid)
        {

            return DAL.GetStoreStatusByProId(proid, brnchid);
        }

    }
}
