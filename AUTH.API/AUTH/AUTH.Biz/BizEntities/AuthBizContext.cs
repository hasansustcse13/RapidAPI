using AUTH.Biz.DBContext;
using AutoMapper;
using BizFrameWork;

namespace AUTH.Biz.BizEntities
{
    public class AuthBizContext : BizContextBase<IAuthDBContext>, IAuthBizContext
    {
        protected AuthBizContext(IAuthDBContext dBContext, int userId, string ipAddress) : base(dBContext, userId, ipAddress)
        {
            Mapper = new Mapper(MapperConfig.GetMapperConfiguration());

            Users = new UserBizEntity(this, Mapper);
        }

        public static AuthBizContext Create(IAuthDBContext dbContext, int userId, string ipAddress)
        {
            return new AuthBizContext(dbContext, userId, ipAddress);
        }

        protected Mapper Mapper { get; }

        public UserBizEntity Users { get; }

    }
}
