using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Application.DTOs.Auth
{
    public class LoginDto
    {
        [Required]
        public string Email { get; set; }
        public string Senha { get; set; }
    }
}