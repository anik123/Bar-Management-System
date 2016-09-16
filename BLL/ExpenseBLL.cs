using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
  public  class ExpenseBLL
    {
      ExpenseDAL DAL = new ExpenseDAL();
      public void Add(ExpenseDTO DTO)
      {
          DAL.Add(DTO);
      }
      public void Edit(ExpenseDTO DTO)
      {
          DAL.Edit(DTO);
      }
      public List<ExpenseDTO> GetExpenseInfo(int id)
      {

          return DAL.GetExpenseInfo(id);
      }
    }
}
