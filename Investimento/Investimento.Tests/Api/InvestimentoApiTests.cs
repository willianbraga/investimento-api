using Microsoft.AspNetCore.Mvc.Testing;
using Microsoft.Extensions.DependencyInjection;
using Newtonsoft.Json;
using System.Text;

namespace Investimento.Tests.Api
{
    public class InvestimentoApiTests : IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _httpClient;

        public InvestimentoApiTests(WebApplicationFactory<Program> factory)
        {
            _httpClient = factory.CreateClient();
        }

        [Fact]
        public async Task Deve_Cadastrar_Investimento_Com_Sucesso()
        {
            var requestBody = new
            {
                NomeProduto = "Fundo XPTO",
                CodigoProduto = "XPTO",
                Saldo = 1000.00m,
                Agencia = "0001",
                Conta = "123456",
                DAC = "7"
            };

            var response = await PostInvestimentoAsync(requestBody);
            Assert.Equal(System.Net.HttpStatusCode.Created, response.StatusCode);
        }

        [Fact]
        public async Task Deve_Retornar_404_Se_Nao_Houver_Investimentos()
        {
            var response = await GetInvestimentosAsync("0003", "123456", "7");
            Assert.Equal(System.Net.HttpStatusCode.NotFound, response.StatusCode);
        }

        [Fact]
        public async Task Deve_Retornar_Investimentos_Cadastrados()
        {
            var response = await GetInvestimentosAsync("0001", "123456", "7");

            Assert.Equal(System.Net.HttpStatusCode.OK, response.StatusCode);

            var investimentos = JsonConvert.DeserializeObject<List<CrossHelpers.Entities.Investimento>>(await response.Content.ReadAsStringAsync());

            Assert.NotNull(investimentos);
            Assert.NotEmpty(investimentos);
        }

        private async Task<HttpResponseMessage> PostInvestimentoAsync(object investimento)
        {
            var content = new StringContent(JsonConvert.SerializeObject(investimento), Encoding.UTF8, "application/json");
            return await _httpClient.PostAsync("/api/investimento", content);
        }

        private async Task<HttpResponseMessage> GetInvestimentosAsync(string agencia, string conta, string dac)
        {
            return await _httpClient.GetAsync($"/api/investimento?agencia={agencia}&conta={conta}&dac={dac}");
        }
    }
}
