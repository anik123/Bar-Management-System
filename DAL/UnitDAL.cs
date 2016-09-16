using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class UnitDAL
    {

        public void Add(UnitDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                Unit gur = new Unit();
                container.Units.AddObject((Unit)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(UnitDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new Unit();
                Comp = container.Units.FirstOrDefault(o => o.UnitId.Equals(DTO.UnitId));
                Comp.UnitId = DTO.UnitId;
                Comp.UnitName = DTO.UnitName;
                Comp.UpdateBy = DTO.UpdateBy;
                Comp.UpdateDate = DTO.UpdateDate;

                Comp = (Unit)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }


        public List<UnitDTO> GetUnit(int id, string unit)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Units
                            select new { s };
                if (id != 0)
                    query = query.Where(c => c.s.UnitId.Equals(id));
                if (!string.IsNullOrEmpty(unit))
                    query = query.Where(c => c.s.UnitName.Contains(unit));
                var result = from o in query
                             orderby o.s.UnitId ascending

                             select new UnitDTO
                             {

                                 UnitName = o.s.UnitName,

                             };
                return result.ToList<UnitDTO>();
            }
        }
    }
}
