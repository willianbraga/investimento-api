using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Investimento.CrossHelpers.Entities
{
    public class Investimento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public string NomeProduto { get; set; }

        [Required]
        public string CodigoProduto { get; set; }

        [Column(TypeName = "decimal(18,2)")]
        public decimal Saldo { get; set; }

        [ForeignKey("Conta")]
        public int ContaId { get; set; }
    }
}
