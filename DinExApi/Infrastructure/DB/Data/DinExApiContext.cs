using DinExApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DinExApi.Infrastructure.DB.Data
{
    public class DinExApiContext : DbContext
    {
        public DbSet<Category> Category { get; set; }
        public DbSet<User> User { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=DinExDB.sqlite");
        }
    }
}
