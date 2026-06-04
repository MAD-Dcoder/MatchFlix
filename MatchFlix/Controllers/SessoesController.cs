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
            // Ajustado para as propriedades reais da sua Model: DataInicio, DataFim e status (minúsculo)
            novaSessao.DataInicio = DateTime.Now;
            novaSessao.DataFim = DateTime.Now.AddDays(1); // Define um fim padrão de 24h para a sessão
            novaSessao.status = "Ativa";

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
        [HttpPost("votar")]
        public async Task<IActionResult> VotarNoFilme([FromBody] Avaliacao voto)
        {
            // Ajustado para DataHora (propriedade real da sua Model Avaliacao)
            voto.DataHora = DateTime.Now;
            _context.Avaliacoes.Add(voto);
            await _context.SaveChangesAsync();

            // REGRA DE MATCH: Se o usuário deu "Like" (true)
            if (voto.like)
            {
                // Buscamos a linha da SessaoFilme para descobrir a qual Sessão e Filme esse voto pertence
                var sessaoFilme = await _context.SessoesFilmes.FindAsync(voto.Id_Sessao_Filme);

                if (sessaoFilme != null)
                {
                    // Buscamos a Sessão correspondente para achar o Id_Grupo
                    var sessao = await _context.Sessoes.FindAsync(sessaoFilme.Id_Sessao);

                    if (sessao != null)
                    {
                        // Conta quantos membros o grupo tem no total
                        var totalMembrosGrupo = await _context.MembrosGrupos
                            .CountAsync(m => m.Id_Grupo == sessao.Id_Grupo);

                        // Conta quantos "Likes" (true) esse filme específico recebeu nesta mesma sessão
                        var totalLikesFilme = await _context.Avaliacoes
                            .CountAsync(a => a.Id_Sessao_Filme == voto.Id_Sessao_Filme && a.like == true);

                        // Se o número de likes chegar ao total de membros do grupo, DEU MATCH!
                        if (totalLikesFilme == totalMembrosGrupo)
                        {
                            var novoMatch = new Match
                            {
                                Id_Sessao = sessaoFilme.Id_Sessao,
                                Id_Filme = sessaoFilme.Id_Filme,
                                Total_Likes = totalLikesFilme,
                                DataMacth = DateTime.Now // Mantido o nome exato "DataMacth" da sua Model
                            };

                            _context.Matches.Add(novoMatch);
                            await _context.SaveChangesAsync();

                            return Ok(new { Mensagem = "DEU MATCH! Todo mundo do grupo quer assistir a esse filme!", Match = novoMatch });
                        }
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
                .Include(m => m.Filme) // Carrega os dados do filme associado
                .ToListAsync();

            return Ok(matches);
        }
    }
}