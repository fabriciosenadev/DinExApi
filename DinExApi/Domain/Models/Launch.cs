using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Domain.Models
{
    public class Launch
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Category Cotegory { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public PayMethod? PayMehtod { get; set; }
    }
}
