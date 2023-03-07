using AUTH.Biz.DataModels;
using AUTH.Biz.DbModelMapping;
using Microsoft.EntityFrameworkCore;

namespace AUTH.Biz.DBContext
{
    public class AuthDbContext : DbContext, IAuthDBContext
    {
        public AuthDbContext(DbContextOptions<AuthDbContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new UserMapper());


            SeedData.OnModelCreating(modelBuilder);
        }
    }
}
