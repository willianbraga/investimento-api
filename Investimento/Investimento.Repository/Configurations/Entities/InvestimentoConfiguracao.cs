using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Investimento.CrossHelpers.Configurations.Entities
{
    public class InvestimentoConfiguracao : IEntityTypeConfiguration<CrossHelpers.Entities.Investimento>
    {
        public void Configure(EntityTypeBuilder<CrossHelpers.Entities.Investimento> builder)
        {
            builder.Property(i => i.Saldo).HasPrecision(18, 2);
        }
    }
}
