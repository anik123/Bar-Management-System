using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class MemberBLL
    {
        MemberDAL DAL = new MemberDAL();
        public void Add(MemberDTO DTO)
        {
            DAL.Add(DTO);
        }
        public void Edit(MemberDTO DTO)
        {
            DAL.Edit(DTO);
        }
        public List<MemberDTO> GetMember(string memno, string memname, string contactno,string memtype,int memberid)
        {
            return DAL.GetMember(memno, memname, contactno, memtype, memberid);
        }
        public List<MemberDTO> GetDueMemeberList(string memno, string memname, string contactno,string memtype)
        {
            return DAL.GetDueMemeberList(memno, memname, contactno, memtype);
        }
        public List<MemberDTO> GetActiveMemeberList(string memno, string memname, string contactno,string memtype)
        {
            return DAL.GetActiveMemeberList(memno, memname, contactno, memtype);
        }
        public List<MemberDTO> GetOpenAccountMemeberList(string memno, string memname, string contactno, string memtype)
        {
            return DAL.GetOpenAccountMemeberList(memno, memname, contactno, memtype);
        }
        public List<MemberDTO> LoadLastId()
        {
            return DAL.LoadLastId();
        }
    }
}
