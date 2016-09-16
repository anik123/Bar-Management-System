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
    public class SpecialistDAL
    {

        public void Add(EmpSpcialistDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                EmpSpecialist gur = new EmpSpecialist();
                container.EmpSpecialists.AddObject((EmpSpecialist)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(EmpSpcialistDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new EmpSpecialist();
                Comp = container.EmpSpecialists.FirstOrDefault(o => o.EmpSpecilistId.Equals(DTO.EmpSpecilistId));
                Comp.Specialist = DTO.Specialist;
                Comp.EmpTypeId = DTO.EmpTypeId;
                Comp.UpdateDate = DTO.UpdateDate;
                Comp.UpdateBy = DTO.UpdateBy;
                Comp = (EmpSpecialist)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public List<EmpSpcialistDTO> GetSpcialistSearch(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.EmpSpecialists
                            join emptype in Container.EmpTypes on s.EmpTypeId equals emptype.EmpTypeId
                            select new { s, emptype };

                if (id != 0)
                    query = query.Where(c => c.s.EmpSpecilistId.Equals(id));

                //if (!string.IsNullOrEmpty(empname))
                //    query = query.Where(c => c.s.EmpName.Contains(empname));

                var result = from o in query
                             orderby o.s.EmpSpecilistId descending
                             select new EmpSpcialistDTO
                             {
                                 EmpSpecilistId = o.s.EmpSpecilistId,
                                 Specialist = o.s.Specialist,
                                 CreateBy = o.s.CreateBy,
                                 TypeName = o.emptype.TypeName,
                                 EmpTypeId = o.emptype.EmpTypeId,
                                 SpecilistName = o.s.Specialist

                             };
                return result.ToList<EmpSpcialistDTO>();
            }
        }


    }
}
