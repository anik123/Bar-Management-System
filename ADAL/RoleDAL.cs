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
    public class RoleDAL
    {
        public void Add(RoleDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                PayRole gur = new PayRole();
                container.PayRoles.AddObject((PayRole)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(RoleDTO EduDTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new PayRole();
                Comp = container.PayRoles.FirstOrDefault(o => o.RoleId.Equals(EduDTO.RoleId));
                Comp.RoleName = EduDTO.RoleName;
                Comp.UpdateBy = EduDTO.UpdateBy;
                Comp.UpdateDate = EduDTO.UpdateDate;
                Comp = (PayRole)DTOMapper.DTOObjectConverter(EduDTO, Comp);
                container.SaveChanges();
            }
        }

        public List<RoleDTO> LoadRole(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PayRoles
                           
                            select new { s };
                if (id != 0)
                    query = query.Where(c => c.s.RoleId.Equals(id));
                var result = (from o in query
                              orderby o.s.RoleId descending
                              select new RoleDTO
                              {
                                  RoleName = o.s.RoleName,
                                  RoleId = o.s.RoleId,
                                  CreateDate = o.s.CreateDate,
                                  CreateBy=o.s.CreateBy,
                                  UpdateBy=o.s.UpdateBy,
                                  UpdateDate=o.s.UpdateDate
                              }).ToList<RoleDTO>();

                return result;
            }
        }

    }
}
