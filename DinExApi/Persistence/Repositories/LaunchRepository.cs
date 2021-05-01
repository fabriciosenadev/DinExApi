using DinExApi.Domain.Models;
using DinExApi.Infrastructure.DB.Data;
using DinExApi.Persistence.Interfaces;
using Microsoft.EntityFrameworkCore;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Persistence.Repositories
{
    public class LaunchRepository : Repository<Launch>, ILaunchRepository
    {
        public LaunchRepository(DinExApiContext dinExContext) : base(dinExContext) { }

        public async Task<IEnumerable<Launch>> FindAllAsync()
        {
            return await dinExContext.Launches.ToListAsync();
        }

        public async Task<Launch> FindByIdAsync(int launchID)
        {
            return await dinExContext.Launches.Where(_ => _.Id.Equals(launchID)).FirstAsync();
        }
    }
}
