using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.CompProfile;
using Utility;

namespace DAL.CompProfile
{
    public class CompProfileInfoDAL
    {
        public void Add(CompProfileInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenCompProfileInfo gur = new InvenCompProfileInfo();
                container.InvenCompProfileInfoes.AddObject((InvenCompProfileInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(CompProfileInfoDTO EduDTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new InvenCompProfileInfo();
                Comp = container.InvenCompProfileInfoes.FirstOrDefault(o => o.CompProId.Equals(EduDTO.CompProId));

                Comp.CompAddress = EduDTO.CompAddress;
                Comp.CompDescription = EduDTO.CompDescription;
                Comp.CompEmail = EduDTO.CompEmail;
                Comp.CompMobile1 = EduDTO.CompMobile1;
                Comp.CompMobile2 = EduDTO.CompMobile2;
                Comp.CompPhone = EduDTO.CompPhone;
                Comp.CompProId = EduDTO.CompProId;
                Comp.CompProName = EduDTO.CompProName;
                Comp.CompWebsite = EduDTO.CompWebsite;
                Comp.UpdateBy = EduDTO.UpdateBy;
                Comp.UpdateDate = EduDTO.UpdateDate;

                Comp = (InvenCompProfileInfo)DTOMapper.DTOObjectConverter(EduDTO, Comp);

                container.SaveChanges();
            }
        }

       // laod compay profile info
        public List<CompProfileInfoDTO> LoadCompProfileInfo(int proid)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenCompProfileInfoes
                            select new { s };


                if (proid != 0)
                    query = query.Where(c => c.s.CompProId.Equals(proid));


                var result = (from o in query
                              orderby o.s.CompProId descending
                              select new CompProfileInfoDTO
                              {
                                  CompAddress = o.s.CompAddress,
                                  CompDescription = o.s.CompDescription,
                                  CompEmail = o.s.CompEmail,
                                  CompMobile1 = o.s.CompMobile1,
                                  CompMobile2 = o.s.CompMobile2,
                                  CompPhone = o.s.CompPhone,
                                  CompProId = o.s.CompProId,
                                  CompProName = o.s.CompProName,
                                  CompWebsite = o.s.CompWebsite,

                              }).ToList<CompProfileInfoDTO>();

                return result;
            }
        }

    }
}
