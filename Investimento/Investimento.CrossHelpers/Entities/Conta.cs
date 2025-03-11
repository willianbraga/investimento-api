using System.ComponentModel.DataAnnotations;

namespace Investimento.CrossHelpers.Entities
{
    public class Conta
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(4)]
        public string Agencia { get; set; }

        [Required]
        [MaxLength(6)]
        public string NumeroConta { get; set; }

        [Required]
        [MaxLength(3)]
        public string DAC { get; set; }

        public List<Investimento> Investimentos { get; set; } = new List<Investimento>();
    }
}
