using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using Utility;
using DAL;

namespace ADAL
{
    public class CashFlowEntityDAL
    {
        public void Add(CashFolwEntityDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                AccCashFlowEntity gur = new AccCashFlowEntity();
                container.AccCashFlowEntities.AddObject((AccCashFlowEntity)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(CashFolwEntityDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccCashFlowEntity();
                Comp = container.AccCashFlowEntities.FirstOrDefault(o => o.CFEId.Equals(DTO.CFEId));
                Comp.CFEName = DTO.CFEName;
                Comp.UpdateDate = DTO.UpdateDate;
                Comp.UpdateBy = DTO.UpdateBy;
                Comp.Priority = DTO.Priority;
                Comp = (AccCashFlowEntity)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public List<CashFolwEntityDTO> LoadCashFlowEntity(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccCashFlowEntities

                            select new { s };

                if (id != 0)
                    query = query.Where(c => c.s.CFEId.Equals(id));

                var result = from o in query
                             orderby o.s.CFEId descending
                             select new CashFolwEntityDTO
                            {

                                CFEName = o.s.CFEName,
                                CFEId = o.s.CFEId,
                                CreateDate = o.s.CreateDate,
                                CreateBy = o.s.CreateBy,
                                UpdateDate = o.s.UpdateDate,
                                UpdateBy = o.s.UpdateBy,
                                Priority=o.s.Priority

                            };
                return result.ToList<CashFolwEntityDTO>();
            }
        }
    }
}
