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
        //TODO: Migrar prop Applicable para enum
        public string Applicable { get; set; }
        //TODO: Verificar necessidade de criar props de controle: CreatedBY, CreatedAt, UpdatedAt e DeletedAt
    }
}
