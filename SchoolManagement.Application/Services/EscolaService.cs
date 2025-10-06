using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Interfaces;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SchoolManagement.Application.Services
{
    public class EscolaService : IEscolaService
    {
        private readonly IEscolaRepository _escolaRepository;

        public EscolaService(IEscolaRepository escolaRepository)
        {
            _escolaRepository = escolaRepository;
        }

        public async Task<IEnumerable<EscolaDto>> ObterTodasAsync()
        {
            var escolas = await _escolaRepository.ObterTodasAsync();

            return escolas.Select(e => new EscolaDto
            {
                Id = e.Id,
                Nome = e.Nome,
                Endereco = e.Endereco,
                Telefone = e.Telefone
            });
        }

        public async Task<EscolaDto> ObterPorIdAsync(int id)
        {
            var escola = await _escolaRepository.ObterPorIdAsync(id);
            if (escola == null) return null;

            return new EscolaDto
            {
                Id = escola.Id,
                Nome = escola.Nome,
                Endereco = escola.Endereco,
                Telefone = escola.Telefone
            };
        }

        public async Task AdicionarAsync(EscolaDto dto)
        {
            var escola = new Escola
            {
                Nome = dto.Nome,
                Endereco = dto.Endereco,
                Telefone = dto.Telefone
            };

            await _escolaRepository.AdicionarAsync(escola);
            dto.Id = escola.Id;
        }

        public async Task AtualizarAsync(EscolaDto dto)
        {
            var escola = new Escola
            {
                Id = dto.Id,
                Nome = dto.Nome,
                Endereco = dto.Endereco,
                Telefone = dto.Telefone
            };

            await _escolaRepository.AtualizarAsync(escola);
        }

        public async Task RemoverAsync(int id)
        {
            await _escolaRepository.RemoverAsync(id);
        }
    }
}