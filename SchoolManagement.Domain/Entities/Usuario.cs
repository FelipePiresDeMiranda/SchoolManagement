using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Domain.Entities
{
    public class Usuario
    {
        public int Id { get; set; }
        public required string Email { get; set; }
        public required string SenhaHash { get; set; }
        public PerfilUsuario Perfil { get; set; }
    }
}
