using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Interfaces;
using SchoolManagement.Application.Services;

namespace SchoolManagement.API.Controllers;
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

    ///// <summary>
    ///// Cadastra uma nova Mensalidade.
    ///// </summary>
    //[HttpPost]
    //public async Task<IActionResult> Adicionar([FromBody] MensalidadeDto dto)
    //{
    //    await _mensalidadeService.AdicionarAsync(dto);
    //    return CreatedAtAction(nameof(ObterPorId), new { id = dto.Id }, dto);
    //}
}