using SchoolManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface IMensalidadeRepository
    {
        /// <summary>
        /// Retorna todas as mensalidades associadas a uma escola.
        /// </summary>
        /// <param name="escolaId">ID da escola</param>
        /// <returns>Lista de mensalidades</returns>
        Task<IEnumerable<Mensalidade>> ObterPorEscolaAsync(int escolaId);

        /// <summary>
        /// Retorna uma mensalidade específica pelo seu ID.
        /// </summary>
        /// <param name="mensalidadeId">ID da mensalidade</param>
        /// <returns>Instância da mensalidade ou null</returns>
        Task<Mensalidade> ObterPorIdAsync(int mensalidadeId);

        /// <summary>
        /// Adiciona uma nova mensalidade ao banco.
        /// </summary>
        /// <param name="mensalidade">Instância da mensalidade</param>
        Task AdicionarAsync(Mensalidade mensalidade);

        /// <summary>
        /// Atualiza os dados de uma mensalidade existente.
        /// </summary>
        /// <param name="mensalidade">Instância da mensalidade</param>
        Task AtualizarAsync(Mensalidade mensalidade);
    }
}