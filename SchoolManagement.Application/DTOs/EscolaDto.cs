using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.DTOs
{
    public class EscolaDto
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        [Required]
        public string Endereco { get; set; }
        public string Telefone { get; set; }
    }
}