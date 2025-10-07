namespace SchoolManagement.Domain.Entities
{
    public class Mensalidade
    {
        public int Id { get; set; }
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public required List<Parcela> Parcelas { get; set; }
        public int EscolaId { get; set; }
    }
}