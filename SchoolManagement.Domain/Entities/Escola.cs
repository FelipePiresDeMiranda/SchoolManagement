namespace SchoolManagement.Domain.Entities
{
    public class Escola
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public required ICollection<Mensalidade> Mensalidades { get; set; }
        public required ICollection<Aluno> Alunos { get; set; }
        public required string Endereco { get; set; }
        public required string Telefone { get; set; }
    }
}