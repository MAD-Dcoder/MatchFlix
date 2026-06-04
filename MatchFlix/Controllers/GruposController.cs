using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatchFlix.Models;
using System.Reflection.Metadata.Ecma335;
using Microsoft.AspNetCore.Http.HttpResults;

namespace MatchFlix.Controllers
{
    [ApiController]
    [Route("api/[Controller]")] // Define a rota para o controlador, neste caso, "api/grupos"
    public class GruposController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GruposController(AppDbContext context) // Construtor para injetar o contexto do banco de dados
        {
            _context = context;
        }

        [HttpPost] // Define que este método responde a requisições POST para "api/grupos"
        public async Task<ActionResult<GrupoSessao>> CriarGrupo(GrupoSessao novoGrupo)
        {
            _context.GruposSessoes.Add(novoGrupo);
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados

            var membroCriador = new MembroGrupo
            {
                Id_Grupo = novoGrupo.Id_Grupo,
                Id_Usuario = novoGrupo.Id_Usuario_Criador
            };

            _context.MembrosGrupos.Add(membroCriador);
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados

            return Ok(novoGrupo); // Retorna o grupo criado com um status 200 OK
        }

        [HttpPost("adicionar-membro")] // Define que este método responde a requisições POST para "api/grupos/adicionar-membro"
        public async Task<IActionResult> AdicionarMembro(MembroGrupo novoMembro)
        {
            var JaEhMembro = await _context.MembrosGrupos
                .AnyAsync(m => m.Id_Grupo == novoMembro.Id_Grupo && m.Id_Usuario == novoMembro.Id_Usuario);

            if(JaEhMembro)
                return BadRequest("Usuário já faz parte do grupo."); // Retorna um status 400 Bad Request se o usuário já for membro do grupo

            _context.MembrosGrupos.Add(novoMembro);
            await _context.SaveChangesAsync(); // Salva as alterações no banco de dados

            return Ok("Membro adicionando com sucesso.");
        }
    }
}
