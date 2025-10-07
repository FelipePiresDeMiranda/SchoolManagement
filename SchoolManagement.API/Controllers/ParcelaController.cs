using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Interfaces;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ParcelaController : ControllerBase
    {
        private readonly IParcelaService _parcelaService;

        public ParcelaController(IParcelaService parcelaService)
        {
            _parcelaService = parcelaService;
        }

        /// <summary>
        /// Retorna todas as parcelas de um aluno.
        /// </summary>
        [HttpGet("aluno/{alunoId}")]
        public async Task<IActionResult> ObterPorAluno(int alunoId)
        {
            var parcelas = await _parcelaService.ObterPorAlunoAsync(alunoId);
            return Ok(parcelas);
        }

        /// <summary>
        /// Marca uma parcela como paga.
        /// </summary>
        [HttpPost("{parcelaId}/pagar")]
        public async Task<IActionResult> MarcarComoPaga(int parcelaId)
        {
            try
            {
                var resultado = await _parcelaService.MarcarComoPagaAsync(parcelaId);
                return Ok(resultado);
            }
            catch (System.Exception ex)
            {
                return BadRequest(new { erro = ex.Message });
            }
        }
    }
}