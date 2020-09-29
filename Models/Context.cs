using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace StrongMuscle.Models {
    class Context : DbContext {
        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Exercicio> Exercicios { get; set; }
        public DbSet<Funcionario> Funcionarios { get; set; }
        public DbSet<Treino> Treinos { get; set; }
        public DbSet<ItemTreino> ItensTreino { get; set; }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) =>
            optionsBuilder.UseSqlServer(@"Server=(LocalDb)\MSSQLLocalDB;Database=StrongMuscle;Trusted_Connection=true");
    }
}
