namespace SchoolManagement.Domain.Entities
{
    public class Aluno
    {
        public int Id { get; set; }
        public required string Nome { get; set; }
        public int EscolaId { get; set; }
        public required Escola Escola { get; set; }
        public int MensalidadeId { get; set; }
        public required Mensalidade Mensalidade { get; set; }
    }
}
