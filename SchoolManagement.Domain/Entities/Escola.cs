using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Domain.Entities
{
    public class Escola
    {
        public int Id { get; set; }
        public string Nome { get; set; }

        public ICollection<Mensalidade> Mensalidades { get; set; }
        [Required]
        public ICollection<Aluno> Alunos { get; set; }
        [Required]
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}