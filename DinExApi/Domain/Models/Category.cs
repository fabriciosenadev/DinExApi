using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Applicable { get; set; } //TODO: migrar para enum
        public string IsCustom { get; set; } //TODO: migrar para enum
        //TODO: Verificar necessidade de criar props de controle: CreatedBY, CreatedAt, UpdatedAt e DeletedAt
    }
}
