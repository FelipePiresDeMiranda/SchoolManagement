using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;
namespace SchoolManagement.Tests.Unit.Rules;
[TestFixture]
public class ParcelaRulesTests
{    

    [Test]
    public void ObterStatusPagamento_DeveRetornarPago_QuandoValorPagoMaiorQueZero()
    {        
        var parcela = new Parcela { ValorPago = 100, DataVencimento = DateTime.Today.AddDays(-5)};
        var status = parcela.ObterStatusPagamento();
        Assert.That(status, Is.EqualTo(StatusPagamento.Pago));
    }

    [Test]
    public void ObterStatusPagamento_DeveRetornarAtraso_QuandoNaoPagoEVencido()
    {        
        var parcela = new Parcela { ValorPago = 0, DataVencimento = DateTime.Today.AddDays(-1)};
        var status = parcela.ObterStatusPagamento();
        Assert.That(status, Is.EqualTo(StatusPagamento.Atraso));
    }

    [Test]
    public void ObterStatusPagamento_DeveRetornarNaoPago_QuandoNaoPagoEMDentroDoPrazo()
    {        
        var parcela = new Parcela { ValorPago = 0, DataVencimento = DateTime.Today.AddDays(2) };
        var status = parcela.ObterStatusPagamento();
        Assert.That(status, Is.EqualTo(StatusPagamento.NaoPago));
    }
}