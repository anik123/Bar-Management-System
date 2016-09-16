using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using Utility;

namespace DAL
{
    public class MemberDAL
    {
        public void Add(MemberDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                Member gur = new Member();
                container.Members.AddObject((Member)DTOMapper.DTOObjectConverter(DTO, gur));
                container.SaveChanges();
            }
        }
        public void Edit(MemberDTO DTO)
        {
            using (var container = new InventoryContainer())
            {
                var Mem = new Member();
                Mem = container.Members.FirstOrDefault(o => o.MemberId.Equals(DTO.MemberId));
                Mem.MemberId = DTO.MemberId;
                Mem.MemberNo = DTO.MemberNo;
                Mem.Type = DTO.Type;
                Mem.FullName = DTO.FullName;
                Mem.Exservice = DTO.Exservice;
                Mem.ContactNo = DTO.ContactNo;
                Mem.MemType = DTO.MemType;

                Mem = (Member)DTOMapper.DTOObjectConverter(DTO, Mem);
                container.SaveChanges();
            }
        }
        public List<MemberDTO> GetMember(string memno, string memname, string contactno, string memtype, int memid)
        {
            using (var container = new InventoryContainer())
            {
                var query = from mem in container.Members
                            orderby mem.MemberId descending
                            select new { mem };
                if (!String.IsNullOrEmpty(memno))
                    query = query.Where(o => o.mem.MemberNo.Equals(memno));
                if (!String.IsNullOrEmpty(memname))
                    query = query.Where(o => (o.mem.FullName).Contains(memname));
                if (!String.IsNullOrEmpty(contactno))
                    query = query.Where(o => o.mem.ContactNo.Equals(contactno));
                if (!String.IsNullOrEmpty(memtype))
                    query = query.Where(o => o.mem.MemType.Equals(memtype));
                if (memid != 0)
                    query = query.Where(o => o.mem.MemberId == memid);
                var result = (from o in query
                              orderby o.mem.MemberId descending
                              select new MemberDTO
                              {
                                  MemberId = o.mem.MemberId,
                                  MemberNo = o.mem.MemberNo,
                                  FullName = o.mem.FullName,
                                  Type = o.mem.Type,
                                  Exservice = o.mem.Exservice,
                                  ContactNo = o.mem.ContactNo,
                                  MemType = o.mem.MemType,
                                  SellFullName = o.mem.FullName

                              }).ToList<MemberDTO>();
                return result;
            }
        }
        public List<MemberDTO> GetDueMemeberList(string memno, string memname, string contactno, string memtype)
        {
            using (var container = new InventoryContainer())
            {
                var query = from mem in container.Members
                            join salinfo in container.InvenSalesInfoes on mem.MemberId equals salinfo.MemberId
                            join salpay in container.InvenSalePayments on salinfo.SalId equals salpay.SalId
                            select new { mem, salinfo, salpay };
                if (!String.IsNullOrEmpty(memno))
                    query = query.Where(o => o.mem.MemberNo.Equals(memno));
                if (!String.IsNullOrEmpty(memname))
                    query = query.Where(o => (o.mem.FullName).Contains(memname));
                if (!String.IsNullOrEmpty(contactno))
                    query = query.Where(o => o.mem.ContactNo.Equals(contactno));
                if (!String.IsNullOrEmpty(memtype))
                    query = query.Where(o => o.mem.MemType.Equals(memtype));

                var result = (from o in query
                              where o.salpay.DueAmount > 0
                              select new MemberDTO
                              {
                                  MemberId = o.mem.MemberId,
                                  MemberNo = o.mem.MemberNo,
                                  FullName = o.mem.FullName,
                                  MemType = o.mem.MemType,
                                  Type = o.mem.Type,
                                  Exservice = o.mem.Exservice,
                                  ContactNo = o.mem.ContactNo,

                                  SellFullName = o.mem.FullName
                              }).Distinct().ToList<MemberDTO>();
                return result;
            }
        }
        public List<MemberDTO> GetActiveMemeberList(string memno, string memname, string contactno, string memtype)
        {
            using (var container = new InventoryContainer())
            {
                var query = from mem in container.Members
                            join salinfo in container.InvenSalesInfoes on mem.MemberId equals salinfo.MemberId
                            join salpay in container.InvenSalePayments on salinfo.SalId equals salpay.SalId
                            // join temp in container.InvenTempSales on mem.MemberId equals temp.MemberId into outer
                            // from temp in outer.DefaultIfEmpty()
                            select new { mem, salinfo, salpay };
                if (!String.IsNullOrEmpty(memno))
                    query = query.Where(o => o.mem.MemberNo.Equals(memno));
                if (!String.IsNullOrEmpty(memname))
                    query = query.Where(o => (o.mem.FullName).Contains(memname));
                if (!String.IsNullOrEmpty(contactno))
                    query = query.Where(o => o.mem.ContactNo.Equals(contactno));
                if (!String.IsNullOrEmpty(memtype))
                    query = query.Where(o => o.mem.MemType.Equals(memtype));
                var result = (from o in query

                              select new MemberDTO
                              {
                                  MemberId = o.mem.MemberId,
                                  MemberNo = o.mem.MemberNo,
                                  FullName = o.mem.FullName,
                                  MemType = o.mem.MemType,
                                  Type = o.mem.Type,
                                  Exservice = o.mem.Exservice,
                                  ContactNo = o.mem.ContactNo,

                                  SellFullName = o.mem.FullName
                              }).Distinct().ToList<MemberDTO>();
                return result;
            }
        }
        public List<MemberDTO> GetOpenAccountMemeberList(string memno, string memname, string contactno, string memtype)
        {
            using (var container = new InventoryContainer())
            {
                var query = from mem in container.Members
                            join temp in container.InvenTempSales on mem.MemberId equals temp.MemberId

                            // join temp in container.InvenTempSales on mem.MemberId equals temp.MemberId into outer
                            // from temp in outer.DefaultIfEmpty()
                            select new { mem, temp };
                if (!String.IsNullOrEmpty(memno))
                    query = query.Where(o => o.mem.MemberNo.Equals(memno));
                if (!String.IsNullOrEmpty(memname))
                    query = query.Where(o => (o.mem.FullName).Contains(memname));
                if (!String.IsNullOrEmpty(contactno))
                    query = query.Where(o => o.mem.ContactNo.Equals(contactno));
                if (!String.IsNullOrEmpty(memtype))
                    query = query.Where(o => o.mem.MemType.Equals(memtype));
                var result = (from o in query

                              select new MemberDTO
                              {
                                  MemberId = o.mem.MemberId,
                                  MemberNo = o.mem.MemberNo,
                                  FullName = o.mem.FullName,
                                  MemType = o.mem.MemType,
                                  Type = o.mem.Type,
                                  Exservice = o.mem.Exservice,
                                  ContactNo = o.mem.ContactNo,

                                  SellFullName = o.mem.FullName
                              }).Distinct().ToList<MemberDTO>();
                return result;
            }
        }
        public List<MemberDTO> LoadLastId()
        {
            using (var container = new InventoryContainer())
            {

                var query = from mem in container.Members
                            select new { mem };
                var result = (from o in query
                              orderby o.mem.MemberId descending
                              select new MemberDTO
                              {
                                  MemberId = o.mem.MemberId,
                                  MemberNo = o.mem.MemberNo,
                                  FullName = o.mem.FullName,
                                  MemType = o.mem.MemType,
                                  Type = o.mem.Type,
                                  Exservice = o.mem.Exservice,
                                  ContactNo = o.mem.ContactNo,

                                  SellFullName = o.mem.FullName

                              }).ToList<MemberDTO>();
                return result;
            }
        }
    }
}
