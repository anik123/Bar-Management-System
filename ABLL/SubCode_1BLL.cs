
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
    public class SubCode_1BLL
    {
        SubCode_1DAL DAL = new SubCode_1DAL();

        public void Add(SubCode_1DTO DTO)
        {
            DAL.Add(DTO);
        }
        public void Edit(SubCode_1DTO DTO)
        {
            DAL.Edit(DTO);
        }

        // load data for  page
        public List<SubCode_1DTO> LoadSuvCode_1Data(int id, string SubcodeNum, string SubCodename, int mainheadid, string mainheadname, string mainheadno)
        {
            return DAL.LoadSuvCode_1Data(id, SubcodeNum, SubCodename,mainheadid,mainheadname,mainheadno);
        }
        
        //load for liabilities dropdownlist

        public List<SubCode_1DTO> LoadSuvCode_1Data_Liabilities()
        {
            return DAL.LoadSuvCode_1Data_Liabilities();
        }

    }
}
