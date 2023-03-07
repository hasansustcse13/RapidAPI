using AUTH.Biz.DataModels;
using BizFrameWork;
using Microsoft.EntityFrameworkCore;

namespace AUTH.Biz.DBContext
{
    public interface IAuthDBContext : IDbContext
    {
        DbSet<User> Users { get; set; }
    }
}
