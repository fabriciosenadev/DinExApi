using System;

namespace DinExApi.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Applicable { get; set; } //TODO: migrar para enum
        public string IsCustom { get; set; } //TODO: migrar para enum
        public int CreatedBy { get; set; } // receberá o Id do usuario
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
    }
}
