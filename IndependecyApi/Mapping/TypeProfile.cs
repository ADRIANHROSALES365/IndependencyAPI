using AutoMapper;

namespace IndependecyApi.Mapping
{
    public class TypeProfile:Profile
    {
            public TypeProfile()
        {
            CreateMap<Type,TypeDto>().ReverseMap();
            CreateMap<Type,CreateTypeDto>().ReverseMap();
        }
        
    } 
}
