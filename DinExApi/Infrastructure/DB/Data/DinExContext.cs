using DinExApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DinExApi.Infrastructure.DB.Data
{
    public class DinExContext : DbContext
    {
        public DinExContext(DbContextOptions<DinExContext> options) : base(options)
        {
        }

        public DbSet<PayMethod> PayMethod { get; set; }
        public DbSet<Category> Category { get; set; }
    }
}
