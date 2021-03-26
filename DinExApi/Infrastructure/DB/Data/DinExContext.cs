using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using DinExApi.Domain.Models;
using Microsoft.EntityFrameworkCore;

namespace DinExApi.Infrastructure.DB.Data
{
    public class DinExContext: DbContext
    {
        public DinExContext(DbContextOptions<DinExContext> options) : base(options)
        {
        }

        public DbSet<PayMethod> PayMethod { get; set; }
    }
}
