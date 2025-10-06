using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infrastructure.Data;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class EscolaRepository : IEscolaRepository
    {
        private readonly AppDbContext _context;

        public EscolaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Escola>> ObterTodasAsync()
        {
            return await _context.Escolas.ToListAsync();
        }

        public async Task<Escola?> ObterPorIdAsync(int id)
        {
            return await _context.Escolas.FirstOrDefaultAsync(e => e.Id == id);
        }

        public async Task AdicionarAsync(Escola escola)
        {
            await _context.Escolas.AddAsync(escola);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Escola escola)
        {
            _context.Escolas.Update(escola);
            await _context.SaveChangesAsync();
        }

        public async Task RemoverAsync(int id)
        {
            var escola = await ObterPorIdAsync(id);
            if (escola != null)
            {
                _context.Escolas.Remove(escola);
                await _context.SaveChangesAsync();
            }
        }
    }
}