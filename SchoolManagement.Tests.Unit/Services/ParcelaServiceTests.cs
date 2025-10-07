using Moq;
using SchoolManagement.Application.Services;
using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Interfaces;
using SchoolManagement.Infrastructure.Repositories;

namespace SchoolManagement.Tests.Unit.Services;
[TestFixture]
public class ParcelaServiceTests
{
    private Mock<IParcelaRepository> _repoMock;
    private ParcelaService _service;

    [SetUp]
    public void Setup()
    {
        _repoMock = new Mock<IParcelaRepository>();
        _service = new ParcelaService(_repoMock.Object);
    }

    [Test]
    public async Task MarcarComoPagaAsync_DeveCalcularJuros_QuandoEmAtraso()
    {
        var escola = new Escola { Alunos = new List<Aluno>(), Endereco = "", Mensalidades = new List<Mensalidade>(), Nome = "", Telefone = "", Id = 2 };
        var parcela = new Parcela
        {
            Id = 1,
            Valor = 100,
            ValorPago = 106,
            DataVencimento = DateTime.Today.AddDays(-3),
            Aluno = new Aluno { Id = 1, Nome = "João", Escola = escola, Parcelas = new List<Parcela>(), EscolaId = 3 },
            Mensalidade = new Mensalidade { Id = 1, Valor = 100, DataVencimento = DateTime.Today.AddDays(-3), Escola = escola}
        };

        _repoMock.Setup(r => r.ObterPorIdAsync(1)).ReturnsAsync(parcela);

        var resultado = await _service.MarcarComoPagaAsync(1);

        Assert.That((resultado.Juros / parcela.Valor) * 100, Is.EqualTo(6)); // 6% de juros
        Assert.That(resultado.ValorFinal, Is.EqualTo(106));
        Assert.That(resultado.Mensagem, Is.EqualTo("Pagamento com juros aplicado."));
    }
}