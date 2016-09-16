using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
    public class CocktailInfoBLL
    {
        CocktailInfoDAL DAL = new CocktailInfoDAL();
        public void Add(CocktailInfoDTO DTO)
        {
            DAL.Add(DTO);
        }
        public void Edit(CocktailInfoDTO DTO)
        {
            DAL.Edit(DTO);
        }
        public List<CocktailInfoDTO> GetCocktail(int proid, int itemproid)
        {
            return DAL.GetCocktail(proid,itemproid);
        }
    }
}
