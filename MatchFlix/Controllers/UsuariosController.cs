using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatchFlix.Models;

namespace MatchFlix.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Define a rota para o controlador, neste caso, "api/usuarios"
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;


        // Construtor para injetar o contexto do banco de dados
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }
        [HttpPost] // Define que este método responde a requisições POST para "api/usuarios"
        public async Task<ActionResult<Usuarios>> Cadastrar(Usuarios novoUsuario) // Método para cadastrar um novo usuário
        {

            var usuarioExiste = await _context.Usuarios
                .AnyAsync(u => u.Email == novoUsuario.Email); // Verifica se já existe um usuário com o mesmo e-mail


            if (usuarioExiste)
                return BadRequest("E-Mail já está cadastrado.");

            _context.Usuarios.Add(novoUsuario);

            await _context.SaveChangesAsync();

            return Ok(novoUsuario);
        }
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest dadosLogin) // Método para realizar o login do usuário, respondendo a POST em "api/usuarios/login"
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == dadosLogin.Email && u.Senha == dadosLogin.Senha); // Verifica se existe um usuário com o e-mail e senha fornecidos

            if (usuario == null)
                return Unauthorized("E-Mail ou senha inválidos.");

            return Ok(new
            {
                Mensagem = "Login realizado com sucesso",
                UsuarioId = usuario.Id_Usuario,
                Nome = usuario.Nome
            });
        }
    }
    public class LoginRequest // Classe para representar os dados de login enviados pelo cliente
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}   
