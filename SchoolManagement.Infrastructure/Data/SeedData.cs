using SchoolManagement.Domain.Entities;
using SchoolManagement.Domain.Enums;

namespace SchoolManagement.Infrastructure.Data
{
    public static class SeedData
    {
        //Chame SeedData.Inicializar(context) no Program.cs após o CreateScope

        public static void Inicializar(AppDbContext context)
        {
            if (!context.Escolas.Any())
            {
                var escola = new Escola { Nome = "Escola Modelo", Mensalidades = new List<Mensalidade>(), Alunos = new List<Aluno>(), Endereco = "", Telefone = "" };
                context.Escolas.Add(escola);
                context.SaveChanges();

                var mensalidade = new Mensalidade
                {                    
                    Valor = 500,
                    DataVencimento = DateTime.Today.AddDays(10),
                    Parcelas = new List<Parcela>()
                };
                context.Mensalidades.Add(mensalidade);

                var aluno = new Aluno { Nome = "João da Silva", EscolaId = escola.Id, Escola = escola, Mensalidade = mensalidade };
                context.Alunos.Add(aluno);
                context.SaveChanges();

                var parcela = new Parcela
                {
                    AlunoId = aluno.Id,                    
                    Valor = mensalidade.Valor,
                    DataVencimento = mensalidade.DataVencimento,
                    ValorPago = 0,
                    Status = StatusPagamento.NaoPago                    
                };
                context.Parcelas.Add(parcela);
                context.SaveChanges();
            }
        }
    }
}