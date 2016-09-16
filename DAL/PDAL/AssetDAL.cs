using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;

using PDTO;
using Utility;

namespace PDAL
{
    public class AssetDAL
    {

        public void Add(AssetDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                PayAsset gur = new PayAsset();
                container.PayAssets.AddObject((PayAsset)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }

        public void Edit(AssetDTO EduDTO)
        {
            using (var container = new InventoryContainer())
            {
                var Comp = new PayAsset();
                Comp = container.PayAssets.FirstOrDefault(o => o.AssetId.Equals(EduDTO.AssetId));

                Comp.BankAmount_Current = EduDTO.BankAmount_Current;
                Comp.CashAmount_Current = EduDTO.CashAmount_Current;

                Comp = (PayAsset)DTOMapper.DTOObjectConverter(EduDTO, Comp);

                container.SaveChanges();
            }
        }

        public List<AssetDTO> Asset_Current()
        {
            using (var Container = new InventoryContainer())
            {
                var query = from s in Container.PayAssets
                            select new { s };

                var result = (from o in query

                              select new AssetDTO
                              {
                                  AssetId = o.s.AssetId,
                                  BankAmount_Current = o.s.BankAmount_Current,
                                  CashAmount_Current = o.s.CashAmount_Current,
                              }).ToList<AssetDTO>();

                return result;
            }
        }
    }
}
