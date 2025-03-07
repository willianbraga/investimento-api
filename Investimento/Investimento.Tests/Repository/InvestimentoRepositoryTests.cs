using Investimento.Domain.Interfaces.Repositories;
using Investimento.Repository;
using Investimento.Repository.Data;
using Microsoft.EntityFrameworkCore;

namespace Investimento.Tests.Repository
{
    public class InvestimentoRepositoryTests
    {
        private readonly IInvestimentoRepository _investimentoRepository;
        private readonly InvestimentoDbContext _context;

        public InvestimentoRepositoryTests()
        {
            var context = new DbContextOptionsBuilder<InvestimentoDbContext>()
                    .UseInMemoryDatabase(databaseName: "Investimento_Tests")
                    .Options;

            _context = new InvestimentoDbContext(context);
            _investimentoRepository = new InvestimentoRepository(_context);
        }

        [Fact]
        public async Task Deve_Retornar_Lista_Vazia_Se_Nao_Houver_Investimentos()
        {
            var investimentos = await _investimentoRepository.BuscarInvestimentosAsync("0001", "123456", "7");
            Assert.Empty(investimentos);
        }

        [Fact]
        public async Task Deve_Adicionar_Investimento_Com_Sucesso()
        {
            var investimento = new CrossHelpers.Entities.Investimento
            {
                NomeProduto = "Fundo XPTO",
                CodigoProduto = "XPTO123",
                Saldo = 10000.50m,
                Agencia = "0001",
                Conta = "123456",
                DAC = "7"
            };

            await _investimentoRepository.AdicionarInvestimentoAsync(investimento);
            var investimentos = await _investimentoRepository.BuscarInvestimentosAsync("0001", "123456", "7");

            Assert.Single(investimentos);
            Assert.Equal("Fundo XPTO", investimentos[0].NomeProduto);
        }

        [Fact]
        public async Task Deve_Retornar_Investimentos_Corretos()
        {
            var investimento1 = new CrossHelpers.Entities.Investimento { NomeProduto = "Fundo A", CodigoProduto = "A1", Saldo = 5000.00m, Agencia = "0001", Conta = "123456", DAC = "7" };
            var investimento2 = new CrossHelpers.Entities.Investimento { NomeProduto = "Fundo B", CodigoProduto = "B1", Saldo = 8000.00m, Agencia = "0001", Conta = "123456", DAC = "7" };

            await _investimentoRepository.AdicionarInvestimentoAsync(investimento1);
            await _investimentoRepository.AdicionarInvestimentoAsync(investimento2);

            var investimentos = await _investimentoRepository.BuscarInvestimentosAsync("0001", "123456", "7");

            Assert.Equal(2, investimentos.Count);
            Assert.Contains(investimentos, i => i.NomeProduto == "Fundo A");
            Assert.Contains(investimentos, i => i.NomeProduto == "Fundo B");
        }

        [Fact]
        public async Task Deve_Lancar_Excecao_Ao_Adicionar_Investimento_Com_Contexto_Indisponivel()
        {
            _context.Dispose();

            var investimento = new CrossHelpers.Entities.Investimento
            {
                NomeProduto = "Fundo XPTO",
                CodigoProduto = "XPTO123",
                Saldo = 10000.50m,
                Agencia = "0001",
                Conta = "123456",
                DAC = "7"
            };

            await Assert.ThrowsAsync<ObjectDisposedException>(() => _investimentoRepository.AdicionarInvestimentoAsync(investimento));
        }

    }
}
