using AutoMapper;

namespace BizFrameWork
{
    public abstract class BizEntity<TBizContext> : IBizEntity where TBizContext : IBizContext
    {
        protected BizEntity(TBizContext bizContext, IMapper mapper)
        {
            Context = bizContext;
            Mapper = mapper;
        }

        protected TBizContext Context { get; }
        protected IMapper Mapper { get; }
    }
}
