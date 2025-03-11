using Investimento.App.Interfaces;
using Investimento.Domain.Interfaces.Services;

namespace Investimento.App
{
    public class InvestimentoApp : IInvestimentoApp
    {
        private readonly IContasService _contasService;
        private readonly IInvestimentoService _investimentoService;
        public InvestimentoApp(IContasService contasService, IInvestimentoService investimentoService)
        {
            _contasService = contasService;
            _investimentoService = investimentoService;
        }
        public async Task<(bool Sucesso, string Mensagem)> CriarInvestimentoAsync(string codigoProduto, string nomeProduto, string agencia, string conta, string dac, decimal valor)
        {
            var contaCliente = await _contasService.BuscarContaAsync(agencia, conta, dac);
            if (contaCliente == null)
                return (false, "Conta não encontrada ou DAC inválido.");

            var existente = await _investimentoService.BuscarInvestimentoAsync(codigoProduto, contaCliente.Id);

            if (existente != null)
                return (false, "Já existe um investimento para esse produto nessa agência e conta.");

            var investimento = new CrossHelpers.Entities.Investimento()
            {
                CodigoProduto = codigoProduto,
                ContaId = contaCliente.Id,
                NomeProduto = nomeProduto,
                Saldo = valor
            };

            await _investimentoService.AdicionarInvestimentoAsync(investimento);

            return (true, "Investimento criado com sucesso.");
        }

        public async Task<(List<CrossHelpers.Entities.Investimento> Investimentos, string Mensagem)> ListarInvestimentosAsync(string agencia, string conta, string dac)
        {
            var contaCliente = await _contasService.BuscarContaAsync(agencia, conta, dac);
            if (contaCliente == null)
                return (new List<CrossHelpers.Entities.Investimento>(), "Conta não encontrada ou DAC inválido.");

            var investimentos = await _investimentoService.ListarInvestimentosAsync(contaCliente.Id);

            if (!investimentos.Any())
                return (investimentos, "Nenhum investimento encontrado ou o DAC informado é inválido.");

            return (investimentos, "Investimentos encontrados.");
        }

        public async Task<(bool Sucesso, string Mensagem)> AtualizarSaldoAsync(string codigoProduto, string agencia, string conta, string dac, decimal valor)
        {
            var contaCliente = await _contasService.BuscarContaAsync(agencia, conta, dac);
            if (contaCliente == null)
                return (false, "Conta não encontrada ou DAC inválido.");

            var investimento = await _investimentoService.BuscarInvestimentoAsync(codigoProduto, contaCliente.Id);
            if (investimento == null)
                return (false, "Investimento não encontrado.");

            decimal novoSaldo = investimento.Saldo + valor;

            if (novoSaldo < 0)
            {
                return (false, "Limite para transação inválido.");
            }

            investimento.Saldo = novoSaldo;

            await _investimentoService.AtualizarSaldoAsync(investimento);

            return (true, "Saldo atualizado com sucesso.");
        }

        public async Task<(CrossHelpers.Entities.Investimento? Investimento,string Mensagem)> BuscarInvestimentoAsync(string codigoProduto, string agencia, string conta, string dac)
        {
            var contaCliente = await _contasService.BuscarContaAsync(agencia, conta, dac);
            if (contaCliente == null)
                return (null, "Conta não encontrada ou DAC inválido.");

            var investimento = await _investimentoService.BuscarInvestimentoAsync(codigoProduto, contaCliente.Id);

            return (investimento, (investimento != null ? string.Empty : "Investimento não encontrado."));
        }
    }
}
