using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class InvenCentralToPartyReturnDtlDal
    {
        public void Add(InvenCentralToPartyReturnDtlDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenCentralToPartyReturnDtl inreo = new InvenCentralToPartyReturnDtl();
                container.InvenCentralToPartyReturnDtls.AddObject((InvenCentralToPartyReturnDtl)DTOMapper.DTOObjectConverter(DTO, inreo));
                container.SaveChanges();
            }
        }
        public void Edit(InvenCentralToPartyReturnDtlDto DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenCentralToPartyReturnDtl();
                Comp = container.InvenCentralToPartyReturnDtls.FirstOrDefault(o => o.centralReId.Equals(DTO.centralReId));

                Comp.centralReId = DTO.centralReId;
                Comp.reBy = DTO.reBy;
                Comp.reDate = DTO.reDate;
                Comp.reCompId = DTO.reCompId;
                Comp.reProBranchId = DTO.reProBranchId;
                Comp.reProId = DTO.reProId;
                Comp.reQty = DTO.reQty;
                Comp.reProAmount = DTO.reProAmount;
                Comp = (InvenCentralToPartyReturnDtl)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }
      
    }
}
