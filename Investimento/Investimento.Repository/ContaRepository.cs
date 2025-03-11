using Investimento.Domain.Interfaces.Repositories;
using Investimento.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Investimento.Repository
{
    public class ContaRepository : IContaRepository
    {
        private readonly InvestimentoDbContext _context;

        public ContaRepository(InvestimentoDbContext contexto)
        {
            _context = contexto;
        }

        public async Task<List<CrossHelpers.Entities.Conta>> ListarContas()
        {
            return await _context.Contas.ToListAsync();
        }

        public async Task<CrossHelpers.Entities.Conta?> BuscarContaAsync(string agencia, string conta, string dac)
        {
            return await _context.Contas
                .FirstOrDefaultAsync(c => c.Agencia == agencia && c.NumeroConta == conta && c.DAC == dac);
        }
    }
}
