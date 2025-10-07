using Microsoft.EntityFrameworkCore;
using SchoolManagement.Application.DTOs.Auth;
using SchoolManagement.Application.Interfaces.Auth;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Application.Services.Auth
{
    public class AuthService : IAuthService
    {
        private readonly AppDbContext _context;

        public AuthService(AppDbContext context)
        {
            _context = context;
        }

        public async Task<LoginResponseDto> AutenticarAsync(LoginDto login)
        {
            var usuario = await _context.Usuarios.FirstOrDefaultAsync(u => u.Email == login.Email);
            var senha = login.Senha;
            if (usuario == null || !BCrypt.Net.BCrypt.Verify(login.Senha, usuario.SenhaHash))
                throw new UnauthorizedAccessException("Credenciais inválidas");

            return new LoginResponseDto
            {
                Token = Guid.NewGuid().ToString(), // Simples token local
                Perfil = usuario.Perfil
            };
        }
    }
}
