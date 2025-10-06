using SchoolManagement.Application.DTOs.Auth;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Interfaces.Auth
{
    public interface IAuthService
    {
        /// <summary>
        /// Autentica um usuário com base no e-mail e senha.
        /// </summary>
        /// <param name="login">DTO contendo e-mail e senha</param>
        /// <returns>Token e perfil do usuário autenticado</returns>
        Task<LoginResponseDto> AutenticarAsync(LoginDto login);
    }
}