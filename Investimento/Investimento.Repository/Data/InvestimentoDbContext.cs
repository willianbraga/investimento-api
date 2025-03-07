using Microsoft.EntityFrameworkCore;

namespace Investimento.Repository.Data
{
    public class InvestimentoDbContext : DbContext
    {
        public InvestimentoDbContext(DbContextOptions<InvestimentoDbContext> options) : base(options) { }

        public DbSet<CrossHelpers.Entities.Investimento> Investimentos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.ApplyConfigurationsFromAssembly(typeof(InvestimentoDbContext).Assembly);
        }
    }
}
