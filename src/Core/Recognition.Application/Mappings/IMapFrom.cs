using AutoMapper;
using AutoMapper.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Recognition.Application.Mappings
{
    public interface IMapFrom<T>
    {
        void Mapping(Profile profile)
        {
            profile.Internal().MethodMappingEnabled = false;
            profile.CreateMap(typeof(T), GetType(), MemberList.None);
            profile.CreateMap(GetType(), typeof(T), MemberList.None);
        }
    }
}
