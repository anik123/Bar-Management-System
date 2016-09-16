using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DAL
{
    public class InvenCentralStoreDTO
    {
        public int CentralStoreId { get; set; }
        public int? ProductId { get; set; }
        public int? QuantityStore { get; set; }
    }
}
