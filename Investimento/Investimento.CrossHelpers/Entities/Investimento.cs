using System.ComponentModel.DataAnnotations.Schema;

namespace Investimento.CrossHelpers.Entities
{
    public class Investimento
    {
        public int Id { get; set; }
        public string? NomeProduto { get; set; }
        public string? CodigoProduto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Saldo { get; set; }

        public string? Agencia { get; set; }
        public string? Conta { get; set; }
        public string? DAC { get; set; }
    }
}
