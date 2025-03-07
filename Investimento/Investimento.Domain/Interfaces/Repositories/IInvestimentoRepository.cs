﻿namespace Investimento.Domain.Interfaces.Repositories
{
    public interface IInvestimentoRepository
    {
        Task AdicionarInvestimentoAsync(CrossHelpers.Entities.Investimento investimento);
        Task<List<CrossHelpers.Entities.Investimento>> BuscarInvestimentosAsync(string agencia, string conta, string dac);
    }
}
