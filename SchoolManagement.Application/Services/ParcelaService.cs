using SchoolManagement.Application.DTOs;
using SchoolManagement.Application.Interfaces;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;

namespace SchoolManagement.Application.Services
{
    public class ParcelaService : IParcelaService
    {
        private readonly IParcelaRepository _parcelaRepository;

        public ParcelaService(IParcelaRepository parcelaRepository)
        {
            _parcelaRepository = parcelaRepository;
        }

        public async Task<IEnumerable<ParcelaDto>> ObterPorAlunoAsync(int alunoId)
        {
            var parcelas = await _parcelaRepository.ObterPorAlunoAsync(alunoId);

            return parcelas.Select(p => new ParcelaDto
            {
                Id = p.Id,
                NomeAluno = p.Aluno.Nome,
                Valor = p.Valor,
                Vencimento = p.DataVencimento,
                EstaPaga = p.EstaPaga,
                Juros = CalcularJuros(p),
                ValorFinal = CalcularValorFinal(p)
            });
        }

        public async Task<PagamentoDto> MarcarComoPagaAsync(int parcelaId)
        {
            var parcela = await _parcelaRepository.ObterPorIdAsync(parcelaId);

            if (parcela == null)
                throw new Exception("Parcela não encontrada.");

            if (parcela.EstaPaga)
                throw new Exception("Parcela já está paga.");

            var juros = CalcularJuros(parcela);
            var valorFinal = CalcularValorFinal(parcela);

            if (parcela.ValorPago >= valorFinal)
            {
                parcela.EstaPaga = true;
                parcela.ValorPago = valorFinal;
                await _parcelaRepository.AtualizarAsync(parcela);
            }
            else
            {
                throw new Exception(string.Concat("O valor pago da parcela é menor que o valor devido. valor pago: R$", parcela.ValorPago, " valor de juros R$", juros, " valor devido: R$", valorFinal));
            }

            return new PagamentoDto
            {
                ValorOriginal = parcela.Valor,
                Juros = juros,
                ValorFinal = valorFinal,
                Mensagem = (juros > 0) ? "Pagamento com juros aplicado." : "Pagamento registrado com sucesso."
            };
        }

        public async Task<PagamentoDto> AtualizarJurosAsync(int parcelaId)
        {
            var parcela = await _parcelaRepository.ObterPorIdAsync(parcelaId);

            if (parcela == null)
            {
                throw new Exception("Parcela não encontrada.");
            }

            if (parcela.EstaPaga)
                throw new Exception("Parcela já está paga.");

            parcela.EstaPaga = true;
            await _parcelaRepository.AtualizarAsync(parcela);

            var juros = CalcularJuros(parcela);
            var valorFinal = CalcularValorFinal(parcela);

            return new PagamentoDto
            {
                ValorOriginal = parcela.Valor,
                Juros = juros,
                ValorFinal = valorFinal,
                Mensagem = "Pagamento registrado com sucesso."
            };
        }

        static private decimal CalcularJuros(Parcela parcela)
        {
            if (parcela.EstaPaga || parcela.DataVencimento >= DateTime.Today)
                return 0;

            var diasAtraso = (DateTime.Today - parcela.DataVencimento).Days;
            var taxa = 0.02m; // 2% ao dia
            return Math.Round(parcela.Valor * taxa * diasAtraso, 2);
        }

        static private decimal CalcularValorFinal(Parcela parcela)
        {
            var juros = CalcularJuros(parcela);
            return parcela.Valor + juros;
        }
    }
}