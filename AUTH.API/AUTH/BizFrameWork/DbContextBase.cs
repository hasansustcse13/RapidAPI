using System;
using System.Threading.Tasks;
using System.Threading;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Storage;

namespace BizFrameWork
{
    public abstract class DbContextBase : DbContext, IDbContext
    {
        public DbContextBase(DbContextOptions options) : base(options) { }

        private IDbContextTransaction _currentTransaction;

        // SaveChnages will automatically rollback; Tranasaction used only for demonstrative purpose
        public int SaveChangesWithTransaction()
        {
            _currentTransaction ??= Database.BeginTransaction();

            try
            {
                var result = base.SaveChanges();

                _currentTransaction.Commit();

                return result;
            }
            catch (Exception)
            {
                _currentTransaction.Rollback();
                throw;
            }
            finally
            {
                _currentTransaction.Dispose();
                _currentTransaction = null;
            }
        }

        public async Task<int> SaveChangesWithTransactionChangesAsync(CancellationToken cancellationToken = default(CancellationToken))
        {
            _currentTransaction ??= await Database.BeginTransactionAsync(cancellationToken);

            try
            {
                var result = await base.SaveChangesAsync(cancellationToken);

                await _currentTransaction.CommitAsync(cancellationToken);

                return result;
            }
            catch (Exception)
            {
                await _currentTransaction.RollbackAsync(cancellationToken);
                throw;
            }
            finally
            {
                await _currentTransaction.DisposeAsync();
                _currentTransaction = null;
            }
        }
    }
}
