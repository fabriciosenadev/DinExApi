﻿using System;

namespace DinExApi.Domain.Models
{
    public class Category
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Applicable { get; set; } //TODO: migrar para enum
        public string IsCustom { get; set; } //TODO: migrar para enum
        public DateTime CreatedAt { get; set; }
        public DateTime UpdatedAt { get; set; }
        public DateTime DeletedAt { get; set; }
        public User userID { get; set; }
    }
}
