using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatchFlix.Models;

namespace MatchFlix.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilmesController : ControllerBase
    {
        private readonly AppDbContext _context;

        public FilmesController(AppDbContext context)
        {
            _context = context;
        }

        // Método que você já tem (GET)
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Filme>>> ListarTodos()
        {
            return await _context.Filmes.ToListAsync();
        }

        // --- COLE O CÓDIGO ABAIXO AQUI ---
        [HttpPost]
        public async Task<ActionResult<Filme>> PostFilme(Filme filme)
        {
            _context.Filmes.Add(filme);
            await _context.SaveChangesAsync();

            // Retorna o filme criado (opcional)
            return CreatedAtAction(nameof(ListarTodos), new { id = filme.Id_Filme }, filme);
        }
        // ---------------------------------
    }
}