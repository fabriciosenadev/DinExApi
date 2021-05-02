using DinExApi.Domain.Models;
using System;

namespace DinExApi.API.DTO
{
    public class LaunchDTO
    {
        public int Id { get; set; }
        public DateTime Date { get; set; }
        public Category Category { get; set; }
        public string Description { get; set; }
        public decimal Amount { get; set; }
        public string Status { get; set; }
    }
}
