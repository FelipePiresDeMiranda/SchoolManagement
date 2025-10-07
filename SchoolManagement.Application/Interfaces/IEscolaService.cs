using SchoolManagement.Application.DTOs;

namespace SchoolManagement.Application.Interfaces
{
    public interface IEscolaService
    {
        /// <summary>
        /// Retorna todas as escolas cadastradas.
        /// </summary>
        Task<IEnumerable<EscolaDto>> ObterTodasAsync();

        /// <summary>
        /// Retorna uma escola específica pelo ID.
        /// </summary>
        Task<EscolaDto> ObterPorIdAsync(int id);

        /// <summary>
        /// Cadastra uma nova escola.
        /// </summary>
        Task AdicionarAsync(EscolaDto dto);

        /// <summary>
        /// Atualiza os dados de uma escola existente.
        /// </summary>
        Task AtualizarAsync(EscolaDto dto);

        /// <summary>
        /// Remove uma escola pelo ID.
        /// </summary>
        Task RemoverAsync(int id);
    }
}