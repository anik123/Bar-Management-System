using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class CompanyBLL
    {
        CompanyInfoDAL DAL = new CompanyInfoDAL();
        public void Add(CompanyInfoDTO DTO)
        {
            DAL.Add(DTO);
        }

        public void Edit(CompanyInfoDTO DTO)
        {
            DAL.Edit(DTO);
        }
        //SearchComInfo(int CompId, string CompName, string CompMobile, string CompAdd)
        public List<CompanyInfoDTO> SearchComInfo(int CompId, string CompName, string CompMobile, string CompAdd)
        {
            return DAL.SearchComInfo(CompId, CompName, CompMobile, CompAdd);
        }
    }
}
