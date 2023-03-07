using AUTH.API.DTOs;
using AUTH.Biz.BOs;
using AutoMapper;

namespace AUTH.API.Infrastructure
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<UserBO, UserDTO>()
                .ReverseMap();
        }
    }
}
