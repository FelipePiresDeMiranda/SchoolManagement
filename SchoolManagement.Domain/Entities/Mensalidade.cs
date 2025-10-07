namespace SchoolManagement.Domain.Entities
{
    public class Mensalidade
    {
        public int Id { get; set; }
        public int EscolaId { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public required Escola Escola { get; set; }
    }
}