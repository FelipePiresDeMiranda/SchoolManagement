using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Domain.Entities
{
    public class Parcela
    {
        public int Id { get; set; }
        public int AlunoId { get; set; }        
        public decimal Valor { get; set; }
        public DateTime DataVencimento { get; set; }
        public decimal ValorPago { get; set; }
        public StatusPagamento Status { get; set; }        

        public bool EstaPaga { get; set; }

        public StatusPagamento ObterStatusPagamento()
        {
            if (ValorPago > 0) return StatusPagamento.Pago;
            if (DataVencimento < DateTime.Today) return StatusPagamento.Atraso;
            return StatusPagamento.NaoPago;
        }
    }    
}