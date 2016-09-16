using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL.BrProfile;
using DTO.BrProfile;

namespace BLL.CompProfile
{
   public class BranchProfileBLL
    {
       BranchProfileDAL dal = new BranchProfileDAL();
       public void Add(BranchProfileDTO DTO)
       {
           dal.Add(DTO);
       }
       public void Edit(BranchProfileDTO DTO)
       {
           dal.Edit(DTO);
       }
          // laod Bray profile info
       public List<BranchProfileDTO> LoadBrProfileInfo(int proid, string CompName, string CompMobile, string CompAdd)
       {
           return dal.LoadBrProfileInfo(proid, CompName, CompMobile, CompAdd);
       }
    }
}
