using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DTO;
using DAL;

namespace BLL
{
public    class InvenBranchToCentralReturnDtlBLL
    {

    InvenBranchToCentralReturnDtlDal indal = new InvenBranchToCentralReturnDtlDal();
    public void Add(InvenBranchToCentralReturnDtlDto DTO)
        {
            indal.Add(DTO);
        }
    public void Edit(InvenBranchToCentralReturnDtlDto EduDTO)
        {
            indal.Edit(EduDTO);
        }

    }
}
