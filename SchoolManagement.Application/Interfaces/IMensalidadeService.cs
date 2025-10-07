using SchoolManagement.Application.DTOs;

namespace SchoolManagement.Application.Interfaces
{
    public interface IMensalidadeService
    {
        Task<IEnumerable<MensalidadeDto>> ObterPorEscolaAsync(int escolaId);

        Task AdicionarAsync(MensalidadeDto dto);
    }
}