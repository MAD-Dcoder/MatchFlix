using Microsoft.EntityFrameworkCore;
using MatchFlix.Models;

namespace MatchFlix
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        // Mapeamento de todas as classes para virarem tabelas no MySQL
        public DbSet<Usuarios> Usuarios { get; set; }
        public DbSet<Filme> Filmes { get; set; } // Ajustado para a classe singular Filme
        public DbSet<GrupoSessao> GruposSessoes { get; set; }
        public DbSet<Genero> Generos { get; set; }
        public DbSet<FilmeGenero> FilmesGeneros { get; set; }
        public DbSet<MembroGrupo> MembrosGrupos { get; set; }
        public DbSet<Sessao> Sessoes { get; set; } // Ajustado para a classe singular Sessao
        public DbSet<SessaoFilme> SessoesFilmes { get; set; }
        public DbSet<Match> Matches { get; set; }
        public DbSet<Avaliacao> Avaliacoes { get; set; } // Confirme se na classe interna está Avaliacao ou Avaliacao

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // 1. Configuração da única Chave Composta real do sistema (Filme_Genero)
            modelBuilder.Entity<FilmeGenero>()
                .HasKey(fg => new { fg.Id_Filme, fg.Id_Genero });

            // 2. Chave Simples para MembroGrupo (pois vocês já usaram a Tag [Key] no arquivo)
            modelBuilder.Entity<MembroGrupo>()
                .HasKey(mg => mg.Id_Membro_Grupo);

            // 3. Chave Simples para SessaoFilme (pois vocês já usaram a Tag [Key] no arquivo)
            modelBuilder.Entity<SessaoFilme>()
                .HasKey(sf => sf.Id_Sessao_Filme);

            base.OnModelCreating(modelBuilder);
        }
    }
}