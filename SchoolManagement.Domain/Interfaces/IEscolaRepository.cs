using SchoolManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface IEscolaRepository
    {
        /// <summary>
        /// Retorna todas as escolas cadastradas.
        /// </summary>
        /// <returns>Lista de escolas</returns>
        Task<IEnumerable<Escola>> ObterTodasAsync();

        /// <summary>
        /// Retorna uma escola específica pelo seu ID.
        /// </summary>
        /// <param name="id">ID da escola</param>
        /// <returns>Instância da escola ou null</returns>
        Task<Escola?> ObterPorIdAsync(int id);

        /// <summary>
        /// Adiciona uma nova escola ao banco.
        /// </summary>
        /// <param name="escola">Instância da escola</param>
        Task AdicionarAsync(Escola escola);

        /// <summary>
        /// Atualiza os dados de uma escola existente.
        /// </summary>
        /// <param name="escola">Instância da escola</param>
        Task AtualizarAsync(Escola escola);

        /// <summary>
        /// Remove uma escola pelo seu ID.
        /// </summary>
        /// <param name="id">ID da escola</param>
        Task RemoverAsync(int id);
    }
}