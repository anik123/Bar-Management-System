using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DAL;
using DTO;

namespace BLL
{
   public class InvenCentralToPartyReturnDtlBLL
    {


        InvenCentralToPartyReturnDtlDal indal = new InvenCentralToPartyReturnDtlDal();
        public void Add(InvenCentralToPartyReturnDtlDto DTO)
        {
            indal.Add(DTO);
        }
        public void Edit(InvenCentralToPartyReturnDtlDto EduDTO)
        {
            indal.Edit(EduDTO);
        }

    }
}
