using DinExApi.Domain.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Persistence.Interfaces
{
    public interface IPayMethodRepository
    {
        Task<List<PayMethod>> FindAllAsync();
    }
}
