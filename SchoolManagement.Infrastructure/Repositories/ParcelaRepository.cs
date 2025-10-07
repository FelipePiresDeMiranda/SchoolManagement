using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infrastructure.Data;

namespace SchoolManagement.Infrastructure.Repositories
{
    public class ParcelaRepository : IParcelaRepository
    {
        private readonly AppDbContext _context;

        public ParcelaRepository()
        {
        }

        public ParcelaRepository(AppDbContext context)
        {
            _context = context;
        }

        public async Task<IEnumerable<Parcela>> ObterPorAlunoAsync(int alunoId)
        {
            return await _context.Parcelas                
                .Where(p => p.AlunoId == alunoId)
                .ToListAsync();
        }

        public async Task<Parcela> ObterPorIdAsync(int parcelaId)
        {
            return await _context.Parcelas                
                .FirstOrDefaultAsync(p => p.Id == parcelaId);
        }

        public async Task AtualizarAsync(Parcela parcela)
        {
            _context.Parcelas.Update(parcela);
            await _context.SaveChangesAsync();
        }
    }
}