using SchoolManagement.Domain.Entities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace SchoolManagement.Domain.Interfaces
{
    public interface IParcelaRepository
    {
        /// <summary>
        /// Retorna todas as parcelas associadas a um aluno.
        /// </summary>
        /// <param name="alunoId">ID do aluno</param>
        /// <returns>Lista de parcelas</returns>
        Task<IEnumerable<Parcela>> ObterPorAlunoAsync(int alunoId);

        /// <summary>
        /// Retorna uma parcela específica pelo seu ID.
        /// </summary>
        /// <param name="parcelaId">ID da parcela</param>
        /// <returns>Instância da parcela ou null</returns>
        Task<Parcela> ObterPorIdAsync(int parcelaId);

        /// <summary>
        /// Atualiza os dados de uma parcela.
        /// </summary>
        /// <param name="parcela">Instância da parcela a ser atualizada</param>
        Task AtualizarAsync(Parcela parcela);
    }
}