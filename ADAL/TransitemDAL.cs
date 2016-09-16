using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADTO;
using Utility;
using DAL;

namespace ADAL
{
    public class TransitemDAL
    {
        public void Add(TransitemDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                AccTranItem gur = new AccTranItem();
                container.AccTranItems.AddObject((AccTranItem)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(TransitemDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccTranItem();
                Comp = container.AccTranItems.FirstOrDefault(o => o.TranId.Equals(DTO.TranId));
                Comp.TranId = DTO.TranId;
                Comp.TranName = DTO.TranName;
                Comp.UpdateDate = DTO.UpdateDate;
                Comp.UpdateBy = DTO.UpdateBy;

                Comp = (AccTranItem)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        // edit for journal update page
        public void Edit_TransitemUpdate(TransitemDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new AccTranItem();
                Comp = container.AccTranItems.FirstOrDefault(o => o.TranId.Equals(DTO.TranId));

                Comp.TranId = DTO.TranId;
                Comp = (AccTranItem)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }

        public List<TransitemDTO> LoadTransDataById(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccTranItems

                            select new { s };

                if (id != 0)
                    query = query.Where(c => c.s.TranId.Equals(id));

                var result = from o in query
                             orderby o.s.TranId descending
                             //   where o.s.MainHeadId.Equals(id)
                             select new TransitemDTO
                             {

                                 TranId = o.s.TranId,
                                 TranName = o.s.TranName,
                                 UpdateBy = o.s.UpdateBy,
                                 UpdateDate = o.s.UpdateDate,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,

                             };
                return result.ToList<TransitemDTO>();
            }
        }

        public List<TransitemDTO> LoadTransData(int id)
        {


            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.AccTranItems

                            select new { s };

                if (id != 0)
                    query = query.Where(c => c.s.TranId.Equals(id));


                var result = from o in query
                             orderby o.s.TranId descending
                             //   where o.s.MainHeadId.Equals(id)
                             select new TransitemDTO
                             {

                                 TranId = o.s.TranId,
                                 TranName = o.s.TranName,
                                 UpdateBy = o.s.UpdateBy,
                                 UpdateDate = o.s.UpdateDate,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate,

                             };
                return result.ToList<TransitemDTO>();
            }
        }

    }
}
