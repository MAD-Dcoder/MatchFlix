using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatchFlix.Models;

namespace MatchFlix.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class SessoesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public SessoesController(AppDbContext context)
        {
            _context = context;
        }

        // 1. INICIAR UMA SESSÃO DE VOTAÇÃO (POST: api/sessoes)
        [HttpPost]
        public async Task<ActionResult<Sessao>> CriarSessao(Sessao novaSessao)
        {
            novaSessao.DataCriacao = DateTime.Now;
            novaSessao.Status = "Ativa";

            _context.Sessoes.Add(novaSessao);
            await _context.SaveChangesAsync();

            return Ok(novaSessao);
        }

        // 2. ADICIONAR UM FILME À SESSÃO (POST: api/sessoes/adicionar-filme)
        [HttpPost("adicionar-filme")]
        public async Task<IActionResult> AdicionarFilmeNaSessao(SessaoFilme sessaoFilme)
        {
            _context.SessoesFilmes.Add(sessaoFilme);
            await _context.SaveChangesAsync();

            return Ok("Filme adicionado à sessão com sucesso!");
        }

        // 3. VOTAR EM UM FILME (POST: api/sessoes/votar)
        // Aqui o usuário diz se deu "Like" ou "Dislike"
        [HttpPost("votar")]
        public async Task<IActionResult> VotarNoFilme([FromBody] Avaliacao voto)
        {
            voto.DataAvaliacao = DateTime.Now;
            _context.Avaliacoes.Add(voto);
            await _context.SaveChangesAsync();

            // REGRA DE MATCH: Vamos checar se o voto foi "Like" e se todos do grupo também deram "Like"
            if (voto.Voto == "Like")
            {
                // Descobre qual é o grupo dessa sessão
                var sessao = await _context.Sessoes.FindAsync(voto.Id_Sessao);
                if (sessao != null)
                {
                    // Conta quantos membros o grupo tem no total
                    var totalMembrosGrupo = await _context.MembrosGrupos
                        .CountAsync(m => m.Id_Grupo == sessao.Id_Grupo);

                    // Conta quantos "Likes" esse filme específico já recebeu nessa sessão
                    var totalLikesFilme = await _context.Avaliacoes
                        .CountAsync(a => a.Id_Sessao == voto.Id_Sessao && a.Id_Filme == voto.Id_Filme && a.Voto == "Like");

                    // Se o número de likes for igual ao número de membros, temos um MATCH!
                    if (totalLikesFilme == totalMembrosGrupo)
                    {
                        var novoMatch = new Match
                        {
                            Id_Sessao = voto.Id_Sessao,
                            Id_Filme = voto.Id_Filme,
                            DataMatch = DateTime.Now
                        };

                        _context.Matches.Add(novoMatch);
                        await _context.SaveChangesAsync();

                        return Ok(new { Mensagem = "DEU MATCH! Todo mundo quer assistir a esse filme!", Match = novoMatch });
                    }
                }
            }

            return Ok(new { Mensagem = "Voto registrado com sucesso!" });
        }

        // 4. LISTAR MATCHES DA SESSÃO (GET: api/sessoes/{idSessao}/matches)
        [HttpGet("{idSessao}/matches")]
        public async Task<ActionResult<IEnumerable<Match>>> ListarMatches(int idSessao)
        {
            var matches = await _context.Matches
                .Where(m => m.Id_Sessao == idSessao)
                .Include(m => m.Filme) // Traz junto os dados do Filme para ficar bonito na tela
                .ToListAsync();

            return Ok(matches);
        }
    }
}