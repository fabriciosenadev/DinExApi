using DinExApi.Domain.Models;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace DinExApi.Persistence.Interfaces
{
    public interface ILaunchRepository : IRepository<Launch>
    {
        Task<IEnumerable<Launch>> FindAllAsync();
        Task<Launch> FindByIdAsync(int launchID);
    }
}
