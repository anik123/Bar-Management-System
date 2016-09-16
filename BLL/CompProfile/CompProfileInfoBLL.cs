using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.CompProfile;
using DTO.CompProfile;

namespace BLL.CompProfile
{
    public class CompProfileInfoBLL
    {
        CompProfileInfoDAL dal = new CompProfileInfoDAL();
        public void Add(CompProfileInfoDTO DTO)
        {
            dal.Add(DTO);
        }
        public void Edit(CompProfileInfoDTO DTO)
        {
            dal.Edit(DTO);
        }
        // laod compay profile info
        public List<CompProfileInfoDTO> LoadCompProfileInfo(int proid)
        {
            return dal.LoadCompProfileInfo(proid);
        }
    }
}
