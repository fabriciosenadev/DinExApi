using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Domain.Models
{
    public class PayMethodLaunches
    {
        public int Id { get; set; }
        public PayMethod PayMethod { get; set; }
        public Launch Launch { get; set; }
        public User CreatedBy { get; set; }
        public DateTime CreatedAt { get; set; }
        public DateTime? UpdatedAt { get; set; }
        public DateTime? DeletedAt { get; set; }
    }
}
