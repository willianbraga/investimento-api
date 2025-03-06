using Microsoft.EntityFrameworkCore;

namespace Investimento.Repository.Data
{
    public class InvestimentoDbContext : DbContext
    {
        public InvestimentoDbContext(DbContextOptions<InvestimentoDbContext> options) : base(options) { }
    }
}
