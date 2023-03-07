namespace BizFrameWork
{
    public abstract class BizContextBase<TDbContext> : IBizContext where TDbContext : IDbContext
    {
        protected BizContextBase(TDbContext dbContext, int userId, string ipAddress)
        {
            DbContext = dbContext;
            UserId = userId;
            IpAddress = ipAddress;
        }

        public TDbContext DbContext { get; }
        public int UserId { get; }
        public string IpAddress { get; }
    }
}
