using DinExApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DinExApi.Infrastructure.DB.Data
{
    public class DinExApiContext : DbContext
    {
        public DinExApiContext(DbContextOptions<DinExApiContext> options) : base(options)
        {

        }
        public DbSet<Category> Categories { get; set; }
        public DbSet<CategoryUsers> CategoryUsers { get; set; }
        public DbSet<Launch> Launches { get; set; }
        public DbSet<PayMethod> PayMethods { get; set; }
        public DbSet<PayMethodLaunches> PayMethodLaunches { get; set; }
        public DbSet<ScheduledLaunches> ScheduledLaunches { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserAmounts> UserAmounts { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=DinExDB.sqlite");
        }
    }
}

