using AUTH.Biz.DBContext;
using BizFrameWork;

namespace AUTH.Biz.BizEntities
{
    public interface IAuthBizContext : IBizContext<IAuthDBContext>
    {
        UserBizEntity Users { get; }
    }
}
