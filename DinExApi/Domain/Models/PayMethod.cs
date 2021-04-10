using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Domain.Models
{
    public class PayMethod
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Applicable { get; set; } // TODO: Migrar para enum
    }
}
