using Investimento.CrossHelpers.Entities;
using Microsoft.EntityFrameworkCore;

namespace Investimento.Repository.Data
{
    public class InvestimentoDbContext : DbContext
    {
        public InvestimentoDbContext(DbContextOptions<InvestimentoDbContext> options) : base(options) { }

        public DbSet<CrossHelpers.Entities.Investimento> Investimentos { get; set; }
        public DbSet<CrossHelpers.Entities.Conta> Contas { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Conta>().HasData(
                new Conta { Id = 1, Agencia = "0001", NumeroConta = "123456", DAC = "123" },
                new Conta { Id = 2, Agencia = "0002", NumeroConta = "654321", DAC = "456" },
                new Conta { Id = 3, Agencia = "0003", NumeroConta = "567890", DAC = "789" }
            );
        }
    }
}
