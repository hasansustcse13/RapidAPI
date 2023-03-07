using AUTH.Biz.DataModels;
using Microsoft.EntityFrameworkCore;

namespace AUTH.Biz.DBContext
{
    internal static class SeedData
    {
        internal static void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().HasData(
                new User { Id = 1, FirstName = "Nurul", LastName = "Hasan", Email = "hasan@gmail.com", Password = "12345" },
                new User { Id = 2, FirstName = "Admin", LastName = "User", Email = "admin@gmail.com", Password = "12345" }
            );
        }
    }
}
