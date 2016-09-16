using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
   public class InvenBranchToCentralReturnDtlDal
    {
       public void Add(InvenBranchToCentralReturnDtlDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenBranchToCentralReturnDtl inreo = new InvenBranchToCentralReturnDtl();
                container.InvenBranchToCentralReturnDtls.AddObject((InvenBranchToCentralReturnDtl)DTOMapper.DTOObjectConverter(DTO, inreo));
                container.SaveChanges();
            }
        }
       public void Edit(InvenBranchToCentralReturnDtlDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenBranchToCentralReturnDtl();
                Comp = container.InvenBranchToCentralReturnDtls.FirstOrDefault(o => o.branchReId.Equals(DTO.branchReId));

                Comp.branchReId = DTO.branchReId;
                Comp.reBy = DTO.reBy;
                Comp.reDate = DTO.reDate;
                Comp.reCompId = DTO.reCompId;
                Comp.reProBranchId = DTO.reProBranchId;
                Comp.reProId = DTO.reProId;
                Comp.reQty = DTO.reQty;
                Comp.reProAmount = DTO.reProAmount;
                Comp = (InvenBranchToCentralReturnDtl)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
      
    }
}
