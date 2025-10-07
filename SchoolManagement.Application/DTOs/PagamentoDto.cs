namespace SchoolManagement.Application.DTOs
{
    public class PagamentoDto
    {
        public decimal ValorOriginal { get; set; }
        public decimal Juros { get; set; }
        public decimal ValorFinal { get; set; }
        public required string Mensagem { get; set; }
    }
}