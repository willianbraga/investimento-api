using Investimento.Domain.Interfaces.Repositories;
using Investimento.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Investimento.Repository
{
    public class InvestimentoRepository : IInvestimentoRepository
    {
        private readonly InvestimentoDbContext _context;

        public InvestimentoRepository(InvestimentoDbContext contexto)
        {
            _context = contexto;
        }

        public async Task AdicionarInvestimentoAsync(CrossHelpers.Entities.Investimento investimento)
        {
            _context.Investimentos.Add(investimento);

            await _context.SaveChangesAsync();
        }

        public async Task<List<CrossHelpers.Entities.Investimento>> BuscarInvestimentosAsync(string agencia, string conta, string dac)
        {
            return await _context.Investimentos
                    .Where(x => x.Agencia == agencia && x.Conta == conta && x.DAC == dac)
                    .ToListAsync();
        }
    }
}
