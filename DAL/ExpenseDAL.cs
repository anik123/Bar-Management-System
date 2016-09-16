using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class ExpenseDAL
    {
        public void Add(ExpenseDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                Expens gur = new Expens();
                container.Expenses.AddObject((Expens)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(ExpenseDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new Expens();
                Comp = container.Expenses.FirstOrDefault(o => o.ExpanseId.Equals(DTO.ExHeadId));
                Comp.ExpanseId = DTO.ExHeadId;
                Comp.Amount = DTO.Amount;
                Comp.ExHeadId = DTO.ExHeadId;
                Comp.Date = DTO.Date;
                Comp.Remarks = DTO.Remarks;
                Comp.UpdateBy = DTO.UpdateBy;
                Comp.UpdateDate = DTO.UpdateDate;
                Comp = (Expens)DTOMapper.DTOObjectConverter(DTO, Comp);
                container.SaveChanges();
            }
        }


        public List<ExpenseDTO> GetExpenseInfo(int id)
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.Expenses
                            join head in Container.ExpenseHeads on s.ExHeadId equals head.ExHeadId
                            //    join cat in Container.Categories on s.CategoryId equals cat.CatId
                            select new { s, head };
                if (id != 0)
                    query = query.Where(c => c.s.ExpanseId.Equals(id));

                var result = from o in query
                             orderby o.s.ExpanseId descending

                             select new ExpenseDTO
                             {
                                 ExHeadId = o.head.ExHeadId,
                                 HeadName = o.head.HeadName,
                                 Amount = o.s.Amount,
                                 Date=o.s.Date,
                                 ExpanseId = o.s.ExpanseId,
                                 Remarks = o.s.Remarks,
                                 CreateBy = o.s.CreateBy,
                                 CreateDate = o.s.CreateDate
                             };
                return result.ToList<ExpenseDTO>();
            }
        }
    }
}
