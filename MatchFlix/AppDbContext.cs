using Microsoft.EntityFrameworkCore;
using MatchFlix.Models;

namespace MatchFlix
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Mapeamento de todas as classes para virarem tabelas no MySQL
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Filme> Filmes { get; set; }
        public DbSet<GrupoSessao> GruposSessoes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<FilmeGenero> FilmesGeneros { get; set; }
        public DbSet<MembroGrupo> MembrosGrupos { get; set; }
        public DbSet<Sessao> Sessoes { get; set; }
        public DbSet<SessaoFilme> SessoesFilmes { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; }

        // --- ADICIONADO ESTE BLOCO ABAIXO ---
        // Configuração extra para explicar chaves complexas ao Entity Framework
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Avisa ao C# que a tabela Filme_Genero usa os dois IDs juntos como Chave Primária
            modelBuilder.Entity<FilmeGenero>()
                .HasKey(fg => new { fg.Id_Filme, fg.Id_Genero });

            base.OnModelCreating(modelBuilder);
        }
    }
}