using DinExApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DinExApi.Infrastructure.DB.Data
{
    public class DinExApiContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<CategoryUsers> CategoryUsers { get; set; }
        public DbSet<Launch> Launch { get; set; }
        public DbSet<PayMethod> PayMethod { get; set; }
        public DbSet<PayMethodLaunches> PayMethodLaunches { get; set; }
        public DbSet<ScheduledLaunches> ScheduledLaunches { get; set; }
        public DbSet<User> User { get; set; }
        public DbSet<UserAmounts> UserAmounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=DinExDB.sqlite");
        }
    }
}

