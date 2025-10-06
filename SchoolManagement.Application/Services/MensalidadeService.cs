using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Interfaces;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Application.Services;
public class MensalidadeService : IMensalidadeService
{
    private readonly IMensalidadeRepository _repo;

    public MensalidadeService(IMensalidadeRepository repo)
    {
        _repo = repo;
    }

    public async Task<IEnumerable<MensalidadeDto>> ObterPorEscolaAsync(int escolaId)
    {
        var mensalidades = await _repo.ObterPorEscolaAsync(escolaId);
        return mensalidades.Select(m => new MensalidadeDto { Id = m.Id, Valor = m.Valor, Vencimento = m.DataVencimento });
    }
}