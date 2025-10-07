using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Interfaces;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Application.Services;
public class MensalidadeService : IMensalidadeService
{
    private readonly IMensalidadeRepository _mensalidadeRepository;

    public MensalidadeService(IMensalidadeRepository repo)
    {
        _mensalidadeRepository = repo;
    }

    public async Task<IEnumerable<MensalidadeDto>> ObterPorEscolaAsync(int escolaId)
    {
        var mensalidades = await _mensalidadeRepository.ObterPorEscolaAsync(escolaId);
        return mensalidades.Select(m => new MensalidadeDto { Id = m.Id, Valor = m.Valor, Vencimento = m.DataVencimento });
    }

    public async Task AdicionarAsync(MensalidadeDto dto)
    {
        var mensalidade = new Mensalidade
        {
            DataVencimento = dto.Vencimento,
            Valor = dto.Valor,
            Parcelas = new List<Parcela>()
        };

        await _mensalidadeRepository.AdicionarAsync(mensalidade);
        dto.Id = mensalidade.Id;
    }
}