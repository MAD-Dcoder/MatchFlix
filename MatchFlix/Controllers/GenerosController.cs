using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatchFlix.Models;

namespace MatchFlix.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class GenerosController : ControllerBase
    {
        private readonly AppDbContext _context;

        public GenerosController(AppDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public async Task<ActionResult<IEnumerable<Genero>>> ListarTodos()
        {
            var generos = await _context.Generos.ToListAsync();
            return Ok(generos);
        }

        [HttpPost]
        public async Task<ActionResult<Genero>> Cadastrar(Genero novoGenero)
        {
            _context.Generos.Add(novoGenero);
            await _context.SaveChangesAsync();

            return Ok(novoGenero);
        }


    }
}
