using System;

namespace SchoolManagement.Application.DTOs
{
    public class ParcelaDto
    {
        public int Id { get; set; }
        public string NomeAluno { get; set; }
        public decimal Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public bool EstaPaga { get; set; }
        public decimal? Juros { get; set; }
        public decimal? ValorFinal { get; set; }
    }
}