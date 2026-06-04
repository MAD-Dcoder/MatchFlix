using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatchFlix.Models;

namespace MatchFlix.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Define a rota para o controlador, neste caso, "api/filmes"
    public class FilmesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FilmesController(AppDbContext context) // Construtor para injetar o contexto do banco de dados
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> ListarTodos() // Define que este método responde a requisições GET para "api/filmes"
        {
            var filmes = await _context.Filmes.ToListAsync();
            return Ok(filmes);
        }

        [HttpGet("{id}")] // Define que este método responde a requisições GET para "api/filmes/{id}"
        public async Task<ActionResult<Filme>> BuscarPorId(int id)
        {
            var filme = await _context.Filmes.FindAsync(id); // Busca o filme pelo ID

            if (filme == null)
                return NotFound("Filme não encontrado."); // Retorna 404 se o filme não for encontrado

            return Ok(filme); // Retorna o filme encontrado

        }

        [HttpPost]
        public async Task<ActionResult<Filme>> Cadastrar(Filme novoFilme)
        {
            _context.Filmes.Add(novoFilme); // Adiciona o novo filme ao contexto
            await _context.SaveChangesAsync(); // Salva as mudanças no banco de dados

            return Ok(novoFilme); // Retorna o filme cadastrado
        }
    }
}
