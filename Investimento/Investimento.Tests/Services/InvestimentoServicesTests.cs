using Investimento.Domain.Interfaces.Repositories;
using Investimento.Domain.Interfaces.Services;
using Investimento.Domain.Services;
using Moq;

namespace Investimento.Tests.Services
{
    public class InvestimentoServicesTests
    {
        private readonly Mock<IInvestimentoRepository> _mockRepository;
        private readonly IInvestimentoService _investimentoService;

        public InvestimentoServicesTests()
        {
            _mockRepository = new Mock<IInvestimentoRepository>();
            _investimentoService = new InvestimentoService(_mockRepository.Object);
        }

        [Fact]
        public async Task Deve_Retornar_Investimentos_Se_Existirem()
        {
            var investimentosFake = new List<CrossHelpers.Entities.Investimento>
            {
                new CrossHelpers.Entities.Investimento { NomeProduto = "Fundo XPTO", CodigoProduto = "XPTO", Saldo = 1000.00m, Agencia = "0001", Conta = "123456", DAC = "7" }
            };

            _mockRepository.Setup(repo => repo.BuscarInvestimentosAsync("0001", "123456", "7"))
                .ReturnsAsync(investimentosFake);

            var resultado = await _investimentoService.BuscarInvestimentosAsync("0001", "123456", "7");

            Assert.Single(resultado);
            Assert.Equal("Fundo XPTO", resultado[0].NomeProduto);
        }

        [Fact]
        public async Task Deve_Retornar_Lista_Vazia_Se_Nao_Houver_Investimentos()
        {
            _mockRepository.Setup(repo => repo.BuscarInvestimentosAsync("0001", "123456", "7"))
                .ReturnsAsync(new List<CrossHelpers.Entities.Investimento>());

            var resultado = await _investimentoService.BuscarInvestimentosAsync("0001", "123456", "7");

            Assert.Empty(resultado);
        }
    }
}
