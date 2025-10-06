using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Interfaces;

[ApiController]
[Route("api/escolas/{escolaId}/mensalidades")]
public class MensalidadeController : ControllerBase
{
    private readonly IMensalidadeService _mensalidadeService;

    public MensalidadeController(IMensalidadeService mensalidadeService)
    {
        _mensalidadeService = mensalidadeService;
    }

    [HttpGet]
    public async Task<IActionResult> ListarMensalidades(int escolaId)
    {
        var mensalidades = await _mensalidadeService.ObterPorEscolaAsync(escolaId);
        return Ok(mensalidades);
    }
}