using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DTO
{
    public class InvenSaleXtraInfoDTO
    {
       public int SaleXtraInfoId { set; get; }
       public int? SalId { set; get; }
       public double? CateringBill { set; get; }
       public double? RestuarentBill { set; get; }
       public double? BekaryBill { set; get; }
    }
}
