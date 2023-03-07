using AUTH.Biz.BOs;
using AUTH.Biz.DataModels;
using AutoMapper;

namespace AUTH.Biz
{
    internal class MapperConfig
    {
        public static MapperConfiguration GetMapperConfiguration()
        {
            return new MapperConfiguration(cfg =>
            {
                cfg.CreateMap<User, UserBO>().ReverseMap();
            });
        }
    }
}
