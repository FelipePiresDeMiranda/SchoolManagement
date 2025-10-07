using Microsoft.AspNetCore.Mvc;
using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Interfaces;

namespace SchoolManagement.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class EscolaController : ControllerBase
    {
        private readonly IEscolaService _escolaService;

        public EscolaController(IEscolaService escolaService)
        {
            _escolaService = escolaService;
        }

        /// <summary>
        /// Retorna todas as escolas cadastradas.
        /// </summary>
        [HttpGet]
        public async Task<IActionResult> ObterTodas()
        {
            var escolas = await _escolaService.ObterTodasAsync();
            return Ok(escolas);
        }

        /// <summary>
        /// Retorna uma escola específica pelo ID.
        /// </summary>
        [HttpGet("{id}")]
        public async Task<IActionResult> ObterPorId(int id)
        {
            var escola = await _escolaService.ObterPorIdAsync(id);
            if (escola == null)
                return NotFound();

            return Ok(escola);
        }

        /// <summary>
        /// Cadastra uma nova escola.
        /// </summary>
        [HttpPost]
        public async Task<IActionResult> Adicionar([FromBody] EscolaDto dto)
        {
            await _escolaService.AdicionarAsync(dto);
            return CreatedAtAction(nameof(ObterPorId), new { id = dto.Id }, dto);
        }

        /// <summary>
        /// Atualiza os dados de uma escola existente.
        /// </summary>
        [HttpPut("{id}")]
        public async Task<IActionResult> Atualizar(int id, [FromBody] EscolaDto dto)
        {
            if (id != dto.Id)
                return BadRequest("ID da URL não corresponde ao corpo da requisição.");

            await _escolaService.AtualizarAsync(dto);
            return NoContent();
        }

        /// <summary>
        /// Remove uma escola pelo ID.
        /// </summary>
        [HttpDelete("{id}")]
        public async Task<IActionResult> Remover(int id)
        {
            await _escolaService.RemoverAsync(id);
            return NoContent();
        }
    }
}