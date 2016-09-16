using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class Log_InventoryBLL
    {
        Log_InventoryDAL LDAL = new Log_InventoryDAL();
        // Inventory Reorder table for barnch wise reorder add 
        public void Add_Reorder_BranchWise_Log(LogInvenReorderDTO DTO)
        {
            LDAL.Add_Reorder_BranchWise_Log(DTO);
        }
         //load  Inventory Reorder table for barnch wise reorder  
        public List<LogInvenReorderDTO> LoadLog_Reorder_BranchWise(string FromDate, string ToDate)
        {
            return LDAL.LoadLog_Reorder_BranchWise(FromDate, ToDate);
        }
    }
}
