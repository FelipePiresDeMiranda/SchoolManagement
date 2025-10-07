using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.DTOs
{
    public class EscolaDto
    {
        public int Id { get; set; }               
        public required string Nome { get; set; }        
        public required string Endereco { get; set; }        
        public required string Telefone { get; set; }
    }
}