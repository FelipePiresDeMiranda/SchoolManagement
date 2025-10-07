using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Domain.Interfaces
{
    public interface IUsuarioRepository
    {
        /// <summary>
        /// Busca um usuário pelo e-mail.
        /// </summary>
        /// <param name="email">E-mail do usuário</param>
        /// <returns>Instância de Usuario ou null</returns>
        Task<Usuario> ObterPorEmailAsync(string email);

        /// <summary>
        /// Adiciona um novo usuário ao banco.
        /// </summary>
        /// <param name="usuario">Entidade Usuario</param>
        Task AdicionarAsync(Usuario usuario);
    }
}