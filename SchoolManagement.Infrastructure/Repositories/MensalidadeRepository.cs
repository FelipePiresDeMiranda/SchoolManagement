using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infrastructure.Data;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class MensalidadeRepository : IMensalidadeRepository
    {
        private readonly AppDbContext _context;

        public MensalidadeRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Mensalidade>> ObterPorEscolaAsync(int escolaId)
        {
            return await _context.Mensalidades
                .Include(m => m.Escola)
                .Where(m => m.EscolaId == escolaId)
                .ToListAsync();
        }

        public async Task<Mensalidade> ObterPorIdAsync(int mensalidadeId)
        {
            return await _context.Mensalidades
                .Include(m => m.Escola)
                .FirstOrDefaultAsync(m => m.Id == mensalidadeId);
        }

        public async Task AdicionarAsync(Mensalidade mensalidade)
        {
            await _context.Mensalidades.AddAsync(mensalidade);
            await _context.SaveChangesAsync();
        }

        public async Task AtualizarAsync(Mensalidade mensalidade)
        {
            _context.Mensalidades.Update(mensalidade);
            await _context.SaveChangesAsync();
        }
    }
}