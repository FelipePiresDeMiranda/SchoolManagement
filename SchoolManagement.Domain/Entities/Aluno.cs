using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Domain.Entities
{
    public class Aluno
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public int EscolaId { get; set; }
        [Required]
        public Escola Escola { get; set; }
        public ICollection<Parcela> Parcelas { get; set; }
    }
}
