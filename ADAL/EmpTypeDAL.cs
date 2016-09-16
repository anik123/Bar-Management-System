using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using ADAL;
using Utility;
using DAL;


namespace ADAL
{
    public class EmpTypeDAL
    {
        public void Add(EmpTypeDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                EmpType gur = new EmpType();
                container.EmpTypes.AddObject((EmpType)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(EmpTypeDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new EmpType();
                Comp = container.EmpTypes.FirstOrDefault(o => o.EmpTypeId.Equals(DTO.EmpTypeId));
                Comp.TypeName = DTO.TypeName;
                Comp.UpdateBy = DTO.UpdateBy;
                Comp.UpdateDate = DTO.UpdateDate;

                Comp = (EmpType)DTOMapper.DTOObjectConverter(DTO, Comp);

                container.SaveChanges();
            }
        }


        public List<EmpTypeDTO> GetEmpType(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.EmpTypes
                            select new { s };
                if (id != 0)
                    query = query.Where(c => c.s.EmpTypeId.Equals(id));

                var result = from o in query
                             orderby o.s.EmpTypeId descending

                             select new EmpTypeDTO
                             {
                                 EmpTypeId = o.s.EmpTypeId,
                                 TypeName = o.s.TypeName,
                                 CreateBy = o.s.CreateBy
                             };
                return result.ToList<EmpTypeDTO>();
            }
        }

    }
}
