using SchoolManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace SchoolManagement.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string SenhaHash { get; set; }
        public PerfilUsuario Perfil { get; set; }
    }
}
