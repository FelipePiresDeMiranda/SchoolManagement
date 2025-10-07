using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;
namespace SchoolManagement.Tests.Unit.Rules;
[TestFixture]
public class ParcelaRulesTests
{
    private readonly Escola escola = new Escola { Alunos = new List<Aluno>(), Endereco = "", Mensalidades = new List<Mensalidade>(), Nome = "", Telefone = "", Id = 2 };

    [Test]
    public void ObterStatusPagamento_DeveRetornarPago_QuandoValorPagoMaiorQueZero()
    {
        
        var aluno = new Aluno { Id = 1, Nome = "João", Escola = escola, Parcelas = new List<Parcela>(), EscolaId = 3 };
        var mensalidade = new Mensalidade { Id = 1, Valor = 100, DataVencimento = DateTime.Today.AddDays(10), Escola = escola, EscolaId = escola.Id };
        var parcela = new Parcela { ValorPago = 100, DataVencimento = DateTime.Today.AddDays(-5), Aluno = aluno, AlunoId = aluno.Id, Mensalidade = mensalidade };
        var status = parcela.ObterStatusPagamento();
        Assert.That(status, Is.EqualTo(StatusPagamento.Pago));
    }

    [Test]
    public void ObterStatusPagamento_DeveRetornarAtraso_QuandoNaoPagoEVencido()
    {
        var aluno = new Aluno { Id = 1, Nome = "João", Escola = escola, Parcelas = new List<Parcela>(), EscolaId = 3 };
        var mensalidade = new Mensalidade { Id = 1, Valor = 100, DataVencimento = DateTime.Today.AddDays(10), Escola = escola, EscolaId = escola.Id };
        var parcela = new Parcela { ValorPago = 0, DataVencimento = DateTime.Today.AddDays(-1), Aluno = aluno, Mensalidade = mensalidade};
        var status = parcela.ObterStatusPagamento();
        Assert.That(status, Is.EqualTo(StatusPagamento.Atraso));
    }

    [Test]
    public void ObterStatusPagamento_DeveRetornarNaoPago_QuandoNaoPagoEMDentroDoPrazo()
    {
        var aluno = new Aluno { Id = 1, Nome = "João", Escola = escola, Parcelas = new List<Parcela>(), EscolaId = 3 };
        var mensalidade = new Mensalidade { Id = 1, Valor = 100, DataVencimento = DateTime.Today.AddDays(10), Escola = escola, EscolaId = escola.Id };
        var parcela = new Parcela { ValorPago = 0, DataVencimento = DateTime.Today.AddDays(2), Aluno = aluno, Mensalidade = mensalidade };
        var status = parcela.ObterStatusPagamento();
        Assert.That(status, Is.EqualTo(StatusPagamento.NaoPago));
    }
}