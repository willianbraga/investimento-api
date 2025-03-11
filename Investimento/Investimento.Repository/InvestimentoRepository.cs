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

        public async Task AtualizarSaldoAsync(CrossHelpers.Entities.Investimento investimento)
        {
            _context.Investimentos.Update(investimento);
            await _context.SaveChangesAsync();
        }

        public async Task<List<CrossHelpers.Entities.Investimento>> ListarInvestimentosAsync(int contaId)
        {
            return await _context.Investimentos
                    .Where(x => x.ContaId == contaId)
                    .ToListAsync();
        }

        public async Task<CrossHelpers.Entities.Investimento?> BuscarInvestimentoAsync(string codigoProduto, int contaId)
        {
            return await _context.Investimentos
                .FirstOrDefaultAsync(i => i.CodigoProduto == codigoProduto && i.ContaId == contaId);
        }
    }
}
