using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Domain.Entities
{
    public class Mensalidade
    {
        public int Id { get; set; }
        public int EscolaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        [Required]
        public Escola Escola { get; set; }
    }
}