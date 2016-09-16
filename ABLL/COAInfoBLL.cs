using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ADAL;
using ADTO;

namespace ABLL
{
    public class COAInfoBLL
    {
        COAInfoDAL Dal = new COAInfoDAL();
        public void Add(COAInfoDTO DTO)
        {
            Dal.Add(DTO);
        }
        public void Edit(COAInfoDTO DTO)
        {
            Dal.Edit(DTO);
        }
      
        // load data for main vocher page
        public List<COAInfoDTO> LoadCoAInfo(int id, string CoaNo, string accountName, int subcode_2id, string s2no, string s2name, string s1no, string s1name, string MHeadNo, string MHeadname)
        {
            return Dal.LoadCoAInfo(id,CoaNo, accountName, subcode_2id,s2no,s2name,s1no,s1name,MHeadNo,MHeadname);
        }
         // edit for journal update page
        public void Edit_COAUpdate(COAInfoDTO DTO)
        {
            Dal.Edit_COAUpdate(DTO);
        }
    }
}
