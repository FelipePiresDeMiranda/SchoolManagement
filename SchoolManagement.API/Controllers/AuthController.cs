using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs.Auth;
using SchoolManagement.Application.Interfaces.Auth;

namespace SchoolManagement.API.Controllers;
[ApiController]
[Route("api/auth")]
public class AuthController : ControllerBase
{
    private readonly IAuthService _authService;

    public AuthController(IAuthService authService)
    {
        _authService = authService;
    }

    [HttpPost("login")]
    public async Task<IActionResult> Login([FromBody] LoginDto login)
    {
        try
        {
            var result = await _authService.AutenticarAsync(login);
            return Ok(result);
        }
        catch (UnauthorizedAccessException ex)
        {
            return Unauthorized(new { mensagem = ex.Message });
        }
    }
}