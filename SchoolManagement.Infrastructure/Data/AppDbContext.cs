using Microsoft.EntityFrameworkCore;
using SchoolManagement.Domain.Entities;

namespace SchoolManagement.Infrastructure.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options)
            : base(options)
        {
        }

        public DbSet<Escola> Escolas { get; set; }
        public DbSet<Aluno> Alunos { get; set; }
        public DbSet<Mensalidade> Mensalidades { get; set; }
        public DbSet<Parcela> Parcelas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Parcela>()
                .HasOne(p => p.Aluno)
                .WithMany(a => a.Parcelas)
                .HasForeignKey(p => p.AlunoId);

            modelBuilder.Entity<Mensalidade>()
                .HasOne(m => m.Escola)
                .WithMany(e => e.Mensalidades)
                .HasForeignKey(m => m.EscolaId);
        }
    }
}