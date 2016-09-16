using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAL;
using Utility;


namespace DAL
{
    public class CompanyInfoDAL
    {
        public void Add(CompanyInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                CompanyInfo gur = new CompanyInfo();

                container.CompanyInfoes.AddObject((CompanyInfo)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }
        public void Edit(CompanyInfoDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new CompanyInfo();

                Comp = container.CompanyInfoes.FirstOrDefault(o => o.CompId.Equals(DTO.CompId));
                Comp.CompPresentAdd = DTO.CompPresentAdd;
                Comp.CompName_BarCode = DTO.CompName_BarCode;
                Comp.CompPermanantAdd = DTO.CompPermanantAdd;
                Comp.Website = DTO.Website;
                Comp.CompDes = DTO.CompDes;
                Comp.CompEmail = DTO.CompEmail;
                Comp.CompMobile1 = DTO.CompMobile1;
                Comp.CompMobile2 = DTO.CompMobile2;
                Comp.CompName = DTO.CompName;
                Comp.UpdateBy = DTO.UpdateBy;
                Comp.UpdateDate = DTO.UpdateDate;
                Comp.CompStatus = DTO.CompStatus;
                Comp = (CompanyInfo)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public List<CompanyInfoDTO> SearchComInfo(int CompId, string CompName, string CompMobile, string CompAdd)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.CompanyInfoes

                            select new { s };

               
                if (CompId != 0)
                    query = query.Where(c => c.s.CompId.Equals(CompId));
                
                 if (!string.IsNullOrEmpty(CompName))
                     query = query.Where(c => c.s.CompName.Contains(CompName));

                // GetContacts().Where(c => searchTerms.Any(term => c.FullName.Contains(term)))
                //  query.Where(c => CompName.Any(term => c.s.CompName.Contains(term)));

                //query.Where((string)CompanyInfo.EntityKeyPropertyName("CompName")).CompareTo(CompName);
                //  query.Where ((string)s.Element("CompName")).Contains(CompName);
                //   query.Where(c => c.s.CompName.Contains(CompName)).Single();
                //  (gr.Name as string).Equals(name, StringComparison.OrdinalIgnoreCase)

                // query.Where(c=>c.s.CompName as string
                //query.Where(c => CompName.Equals(c.s.CompName.ToLower()));
                //query.Where(c =>( c.s.CompName as string).Equals(CompName, StringComparison.OrdinalIgnoreCase));

                //if (!string.IsNullOrEmpty(CompMobile))
                //    query.Where(c => c.s.CompMobile1.Contains(CompMobile) || c.s.CompMobile2.Contains(CompMobile));

                //if (!string.IsNullOrEmpty(CompAdd))
                //    query.Where(c => c.s.CompPresentAdd.Contains(CompAdd) || c.s.CompPermanantAdd.Contains(CompAdd));



                var result = from o in query
                             orderby o.s.CompId descending
                             where (o.s.CompName.Contains(CompName) || o.s.CompMobile1.Contains(CompMobile))
                             select new CompanyInfoDTO
                        {
                            CompId = o.s.CompId,
                            CompName = o.s.CompName,
                            CompPermanantAdd = o.s.CompPermanantAdd,
                            CompName_BarCode=o.s.CompName_BarCode,
                            CompMobile1 = o.s.CompMobile1,
                            CompPresentAdd = o.s.CompPresentAdd,
                            CompDes = o.s.CompDes,
                            CompEmail = o.s.CompEmail,
                            CompMobile2 = o.s.CompMobile2,
                            Website = o.s.Website,
                            CompPhone = o.s.CompPhone,
                            CompStatus = o.s.CompStatus

                        };
                return result.ToList<CompanyInfoDTO>();
            }
        }



    }
}
