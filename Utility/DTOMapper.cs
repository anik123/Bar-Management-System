using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Utility
{
  public  class DTOMapper
    {
        static public Object DTOObjectConverter(Object source, Object destination)
        {


            AutoMapper.Mapper.CreateMap(source.GetType(), destination.GetType());

            return AutoMapper.Mapper.Map(source, source.GetType(), destination.GetType());
        }



    }
}