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
            var investimentos = await _investimentoRepository.ListarInvestimentosAsync(1);
            Assert.Empty(investimentos);
        }

        [Fact]
        public async Task Deve_Adicionar_Investimento_Com_Sucesso()
        {
            var investimento = new CrossHelpers.Entities.Investimento
            {
                NomeProduto = "Fundo XPTO",
                CodigoProduto = "XPTO",
                Saldo = 1000.00m,
                ContaId = 1,
            };

            await _investimentoRepository.AdicionarInvestimentoAsync(investimento);
            var investimentos = await _investimentoRepository.ListarInvestimentosAsync(1);

            Assert.Single(investimentos);
            Assert.Equal("Fundo XPTO", investimentos[0].NomeProduto);
        }

        [Fact]
        public async Task Deve_Retornar_Investimentos_Corretos()
        {
            var investimento1 = new CrossHelpers.Entities.Investimento { NomeProduto = "Fundo XPTO", CodigoProduto = "XPTO", Saldo = 1000.00m, ContaId = 1 };
            var investimento2 = new CrossHelpers.Entities.Investimento { NomeProduto = "Fundo YPTO", CodigoProduto = "YPTO", Saldo = 2000.00m, ContaId = 1 };

            await _investimentoRepository.AdicionarInvestimentoAsync(investimento1);
            await _investimentoRepository.AdicionarInvestimentoAsync(investimento2);

            var investimentos = await _investimentoRepository.ListarInvestimentosAsync(1);

            Assert.Equal(2, investimentos.Count);
            Assert.Contains(investimentos, i => i.NomeProduto == "Fundo XPTO");
            Assert.Contains(investimentos, i => i.NomeProduto == "Fundo YPTO");
        }

        [Fact]
        public async Task Deve_Lancar_Excecao_Ao_Adicionar_Investimento_Com_Contexto_Indisponivel()
        {
            _context.Dispose();

            var investimento = new CrossHelpers.Entities.Investimento
            {
                NomeProduto = "Fundo XPTO",
                CodigoProduto = "XPTO",
                Saldo = 1000.00m,
                ContaId = 1
            };

            await Assert.ThrowsAsync<ObjectDisposedException>(() => _investimentoRepository.AdicionarInvestimentoAsync(investimento));
        }

    }
}
