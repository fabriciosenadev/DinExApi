using DinExApi.Domain.Models;
using DinExApi.Infrastructure.DB.Data;
using DinExApi.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Persistence.Repositories
{
    public class PayMethodRepository : IPayMethodRepository
    {
        public readonly DinExContext _context;
        public PayMethodRepository(DinExContext context)
        {
            _context = context;
        }
        public async Task<List<PayMethod>> FindAllAsync()
        {
            return await _context.PayMethod.OrderBy(x => x.Name).ToListAsync();
        }
    }
}
