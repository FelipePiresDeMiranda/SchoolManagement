using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Infrastructure.Data
{
    public static class SeedUsuarios
    {
        public static void Inicializar(AppDbContext context)
        {
            if (!context.Usuarios.Any())
            {
                context.Usuarios.Add(new Usuario
                {
                    Email = "admin@escola.com",
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword("admin123"),
                    Perfil = PerfilUsuario.Administrador
                });

                context.Usuarios.Add(new Usuario
                {
                    Email = "pai@responsavel.com",
                    SenhaHash = BCrypt.Net.BCrypt.HashPassword("pai123"),
                    Perfil = PerfilUsuario.Responsavel
                });

                context.SaveChanges();
            }
        }
    }
}
