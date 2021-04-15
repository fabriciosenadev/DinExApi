using DinExApi.Domain.Models;
using DinExApi.Infrastructure.DB.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DinExApi.Infrastructure.DB.Seeders
{
    public class SeederBaseService
    {
        private DinExApiContext _context;
        public SeederBaseService(DinExApiContext context)
        {
            _context = context;
        }

        public void Seed()
        {
            if (_context.Categories.Any() || _context.PayMethods.Any())
                return; // break execution of seeder

            #region Pay Methods
            PayMethod money = new PayMethod { Id = 1, Name = "Dinheiro", Applicable = "Carteira" };
            PayMethod debit = new PayMethod { Id = 2, Name = "Débito", Applicable = "Conta" };
            PayMethod credit = new PayMethod { Id = 3, Name = "Crédito", Applicable = "Cartão" };
            #endregion

            #region standard Categories
            Category salary = new Category { Id = 1, Name = "Salário", Applicable = "in", IsCustom = "no", CreatedAt = DateTime.Now };
            Category food = new Category { Id = 2, Name = "Alimentação", Applicable = "out", IsCustom = "no", CreatedAt = DateTime.Now };
            Category beauty = new Category { Id = 3, Name = "Beleza", Applicable = "out", IsCustom = "no", CreatedAt = DateTime.Now };
            Category education = new Category { Id = 4, Name = "Educação", Applicable = "out", IsCustom = "no", CreatedAt = DateTime.Now };
            Category fun = new Category { Id = 5, Name = "Lazer", Applicable = "out", IsCustom = "no", CreatedAt = DateTime.Now };
            Category health = new Category { Id = 6, Name = "Saúde", Applicable = "out", IsCustom = "no", CreatedAt = DateTime.Now };
            Category transport = new Category { Id = 7, Name = "Transporte", Applicable = "out", IsCustom = "no", CreatedAt = DateTime.Now };
            #endregion

            #region saving data
            _context.PayMethods.AddRange(money, debit, credit);
            _context.Categories.AddRange(salary, food, beauty, education, fun, health, transport);
            _context.SaveChanges();
            #endregion
        }
    }
}
