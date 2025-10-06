using SchoolManagement.Application.DTOs;

namespace SchoolManagement.Application.Interfaces
{
    public interface IParcelaService
    {
        Task<IEnumerable<ParcelaDto>> ObterPorAlunoAsync(int alunoId);
        Task<PagamentoDto> MarcarComoPagaAsync(int parcelaId);
    }
}