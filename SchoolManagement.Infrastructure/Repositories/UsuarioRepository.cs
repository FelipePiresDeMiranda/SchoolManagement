using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class UsuarioRepository : IUsuarioRepository
    {
        private readonly AppDbContext _context;

        public UsuarioRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<Usuario> ObterPorEmailAsync(string email)
        {
            if (string.IsNullOrEmpty(email))
                throw new ArgumentException("O email não pode ser nulo ou vazio.", nameof(email));
            if (_context == null)
                throw new InvalidOperationException("O contexto do banco de dados não foi inicializado.");
            if (_context.Usuarios == null)
                throw new InvalidOperationException("A coleção de usuários não está disponível no contexto.");
            return await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == email);
        }

        public async Task AdicionarAsync(Usuario usuario)
        {
            await _context.Usuarios.AddAsync(usuario);
            await _context.SaveChangesAsync();
        }
    }
}