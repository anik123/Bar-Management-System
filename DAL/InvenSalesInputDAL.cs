using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class InvenSalesInputDAL
    {
        
        public void Add(InvenSalesInputDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                InvenSalesInput ino = new InvenSalesInput();
                container.InvenSalesInputs.AddObject((InvenSalesInput)DTOMapper.DTOObjectConverter(DTO, ino));
                container.SaveChanges();
            }
        }
        public void Edit(InvenSalesInputDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Input = new InvenSalesInput();
                Input = container.InvenSalesInputs.FirstOrDefault(o => o.InputId.Equals(DTO.InputId));
                Input.InputId = DTO.InputId;
                Input.GuestCharge = DTO.GuestCharge;
                Input.Card = DTO.Card;
                Input.ExtraBill = DTO.ExtraBill;
                Input.GuestChagePlus = DTO.GuestChagePlus;
                Input.TotalAmount = DTO.TotalAmount;

                Input = (InvenSalesInput)DTOMapper.DTOObjectConverter(DTO, Input);
                container.SaveChanges();
            }
        }
        public List<InvenSalesInputDTO> GetInputByDate(string date)
        {
            using (var container = new InventoryContainer())
            {
                DateTime Date;
                var query = from input in container.InvenSalesInputs
                            select new { input };
                if (!String.IsNullOrEmpty(date))
                {
                    Date = DateTime.Parse(date);
                    query = query.Where(o => o.input.CreatedDate == Date);
                }
                var result = (from o in query
                              select new InvenSalesInputDTO
                              {
                                  InputId = o.input.InputId,
                                  GuestCharge = o.input.GuestCharge,
                                  Card = o.input.Card,
                                  ExtraBill = o.input.ExtraBill,
                                  GuestChagePlus = o.input.GuestChagePlus,
                                  TotalAmount = o.input.TotalAmount,
                                  CreatedDate = o.input.CreatedDate
                              }).ToList<InvenSalesInputDTO>();
                return result;
            }
        }
        public List<InvenSalesInputDTO> GetInputById(int inputid)
        {
            using (var container = new InventoryContainer())
            {
               
                var query = from input in container.InvenSalesInputs
                            select new { input };
                if (inputid!=0)
                {
                   
                    query = query.Where(o => o.input.InputId == inputid);
                }
                var result = (from o in query
                              select new InvenSalesInputDTO
                              {
                                  InputId = o.input.InputId,
                                  GuestCharge = o.input.GuestCharge,
                                  Card = o.input.Card,
                                  ExtraBill = o.input.ExtraBill,
                                  GuestChagePlus = o.input.GuestChagePlus,
                                  TotalAmount = o.input.TotalAmount,
                                  CreatedDate = o.input.CreatedDate
                              }).ToList<InvenSalesInputDTO>();
                return result;
            }
        }
    }
}
