using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO.BrProfile;
using Utility;

namespace DAL.BrProfile
{
    public class BranchProfileDAL
    {
        public void Add(BranchProfileDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenBranchProfile gur = new InvenBranchProfile();
                container.InvenBranchProfiles.AddObject((InvenBranchProfile)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(BranchProfileDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Br = new InvenBranchProfile();
                Br = container.InvenBranchProfiles.FirstOrDefault(o => o.BrProId.Equals(DTO.BrProId));
                Br.CompProId = DTO.CompProId;
                Br.BrAddress = DTO.BrAddress;
                Br.BrDescription = DTO.BrDescription;
                Br.BrEmail = DTO.BrEmail;
                Br.BrMobile1 = DTO.BrMobile1;
                Br.BrMobile2 = DTO.BrMobile2;
                Br.BrPhone = DTO.BrPhone;
                Br.BrProId = DTO.BrProId;
                Br.BrProName = DTO.BrProName;
                Br.BrWebsite = DTO.BrWebsite;
                Br.UpdateBy = DTO.UpdateBy;
                Br.UpdateDate = DTO.UpdateDate;

                Br = (InvenBranchProfile)DTOMapper.DTOObjectConverter(DTO, Br);

                container.SaveChanges();
            }
        }

        // laod Bray profile info
        public List<BranchProfileDTO> LoadBrProfileInfo(int proid, string CompName, string CompMobile, string CompAdd)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.InvenBranchProfiles
                            join compf in Container.InvenCompProfileInfoes on s.CompProId equals compf.CompProId
                            select new { s,compf };


                if (proid != 0)
                    query = query.Where(c => c.s.BrProId.Equals(proid));
                  if (!string.IsNullOrEmpty(CompName))
                    query.Where(c => c.s.BrProName.Equals(CompName));

                if (!string.IsNullOrEmpty(CompMobile))
                    query.Where(c => c.s.BrMobile1.Contains(CompMobile) || c.s.BrMobile2.Contains(CompMobile));

                if (!string.IsNullOrEmpty(CompAdd))
                    query.Where(c => c.s.BrAddress.Contains(CompAdd) );

                var result = (from o in query
                              orderby o.s.BrProId descending
                              select new BranchProfileDTO
                              {
                                  CompProId=o.compf.CompProId,
                                  CompProName=o.compf.CompProName,
                                  BrAddress = o.s.BrAddress,
                                  BrDescription = o.s.BrDescription,
                                  BrEmail = o.s.BrEmail,
                                  BrMobile1 = o.s.BrMobile1,
                                  BrMobile2 = o.s.BrMobile2,
                                  BrPhone = o.s.BrPhone,
                                  BrProId = o.s.BrProId,
                                  BrProName = o.s.BrProName,
                                  BrWebsite = o.s.BrWebsite,

                              }).ToList<BranchProfileDTO>();

                return result;
            }
        }

    }
}
