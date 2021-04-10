using DinExApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DinExApi.Infrastructure.DB.Data
{
    public class DinExApiContext : DbContext
    {
        public DbSet<User> User { get; set; }
        public DbSet<Category> Category { get; set; }
        public DbSet<PayMethod> PayMethod { get; set; }
        public DbSet<Launch> Launch { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=DinExDB.sqlite");
        }
    }
}
