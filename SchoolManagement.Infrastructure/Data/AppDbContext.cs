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

            // Escola -> Alunos (1:N)
            modelBuilder.Entity<Escola>()
                .HasMany(e => e.Alunos)
                .WithOne(a => a.Escola)
                .HasForeignKey(a => a.EscolaId)
                .OnDelete(DeleteBehavior.Cascade);

            // Escola -> Mensalidades (1:N)
            modelBuilder.Entity<Escola>()
                .HasMany(e => e.Mensalidades)
                .WithOne()
                .HasForeignKey("EscolaId")
                .OnDelete(DeleteBehavior.Cascade);

            // Mensalidade -> Parcelas (1:N)
            modelBuilder.Entity<Mensalidade>()
                .HasMany(m => m.Parcelas)
                .WithOne()
                .HasForeignKey("MensalidadeId")
                .OnDelete(DeleteBehavior.Cascade);

            // Aluno -> Mensalidade (1:1)
            modelBuilder.Entity<Aluno>()
                .HasOne(a => a.Mensalidade)
                .WithOne()
                .HasForeignKey<Aluno>("MensalidadeId")
                .OnDelete(DeleteBehavior.NoAction);
        }
    }
}