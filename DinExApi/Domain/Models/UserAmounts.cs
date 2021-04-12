﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Domain.Models
{
    public class UserAmounts
    {
        public int Id { get; set; }
        public User User { get; set; }
        public decimal AmountAvailable { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
    }
}
