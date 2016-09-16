using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class ExpenseHeadDAL
    {
        public void Add(ExpenseHeadDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                ExpenseHead gur = new ExpenseHead();
                container.ExpenseHeads.AddObject((ExpenseHead)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(ExpenseHeadDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new ExpenseHead();
                Comp = container.ExpenseHeads.FirstOrDefault(o => o.ExHeadId.Equals(DTO.ExHeadId));
                Comp.ExHeadId = DTO.ExHeadId;
                Comp.HeadName = DTO.HeadName;
                Comp = (ExpenseHead)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }


        public List<ExpenseHeadDTO> GetExpenseHead(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.ExpenseHeads
                            select new { s };
                if (id != 0)
                    query = query.Where(c => c.s.ExHeadId.Equals(id));

                var result = from o in query
                             orderby o.s.ExHeadId descending

                             select new ExpenseHeadDTO
                             {
                                 ExHeadId = o.s.ExHeadId,
                                 HeadName = o.s.HeadName
                             };
                return result.ToList<ExpenseHeadDTO>();
            }
        }
    }
}
