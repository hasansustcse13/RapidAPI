namespace BizFrameWork
{
    public interface IBizContext<TDbContext> : IBizContext where TDbContext : IDbContext
    {
        TDbContext DbContext { get; }
    }

    public interface IBizContext
    {
        int UserId { get; }
        string IpAddress { get; }
    }
}
