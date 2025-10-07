using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Application.DTOs.Auth
{
    public class LoginResponseDto
    {        
        public required string Token { get; set; }
        public PerfilUsuario Perfil { get; set; }
    }
}