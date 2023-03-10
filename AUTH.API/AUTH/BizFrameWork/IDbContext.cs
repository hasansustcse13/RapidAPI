using System;
using System.Threading.Tasks;
using System.Threading;

namespace BizFrameWork
{
    public interface IDbContext : IDisposable
    {
        int SaveChanges();
        Task<int> SaveChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
        int SaveChangesWithTransaction();
        Task<int> SaveChangesWithTransactionChangesAsync(CancellationToken cancellationToken = default(CancellationToken));
    }
}
