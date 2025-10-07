using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.Interfaces;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Route("api/responsaveis")]
    public class ResponsavelController : ControllerBase
    {
        private readonly IParcelaService _parcelaService;

        public ResponsavelController(IParcelaService parcelaService)
        {
            _parcelaService = parcelaService;
        }

        /// <summary>
        /// Retorna todas as parcelas de um responsável (aluno).
        /// </summary>
        [HttpGet("{responsavelId}/parcelas")]
        public async Task<IActionResult> ObterParcelas(int responsavelId)
        {
            // Aqui, assumimos que o responsável é o aluno.
            var parcelas = await _parcelaService.ObterPorAlunoAsync(responsavelId);
            return Ok(parcelas);
        }
    }
}