using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
    public class SubCode_2BLL
    {
        SubCode_2DAL DAL = new SubCode_2DAL();

        public void Add(SubCode_2DTO DTO)
        {
            DAL.Add(DTO);
        }
        public void Edit(SubCode_2DTO DTO)
        {
            DAL.Edit(DTO);
        }
        // load data for  page
        public List<SubCode_2DTO> LoadSuvCode_2Data(int id, string Subcode2Num, string SubCode2name, int sucodeid1, string subc1no, string subcode1name, string mainheadno, string mainheadname)
        {
            return DAL.LoadSuvCode_2Data(id, Subcode2Num, SubCode2name,sucodeid1,subc1no, subcode1name,mainheadno,mainheadname);
        }

         // load data for  COA Page
        public List<SubCode_2DTO> LoadSuvCode_2Data_COAPage(int SubcodeNum, string SubCodename, int maincodeid, int sucodeid1, int subcode2id)
        {
            return DAL.LoadSuvCode_2Data_COAPage( SubcodeNum, SubCodename, maincodeid, sucodeid1,subcode2id);
        }
    }
}
