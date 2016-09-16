using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
  public  class ExpenseHeadBLL
    {
      ExpenseHeadDAL DAL = new ExpenseHeadDAL();
      public void Add(ExpenseHeadDTO DTO)
      {
          DAL.Add(DTO);
      }
      public void Edit(ExpenseHeadDTO DTO)
      {
          DAL.Edit(DTO);
      }
      public List<ExpenseHeadDTO> GetExpenseHead(int id)
      {
          return DAL.GetExpenseHead(id);
      }
    }
}
