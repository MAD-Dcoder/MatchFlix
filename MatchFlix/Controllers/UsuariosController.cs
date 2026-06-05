using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using MatchFlix.Models;
using System;
using System.Threading.Tasks;

namespace MatchFlix.Controllers
{
    [ApiController]
    [Route("api/[controller]")] // Define a rota base: "api/usuarios"
    public class UsuariosController : ControllerBase
    {
        private readonly AppDbContext _context;

        // Construtor para injetar o contexto do banco de dados
        public UsuariosController(AppDbContext context)
        {
            _context = context;
        }

        // FUNCIONALIDADE 1: Cadastro de Usuário
        [HttpPost("cadastrar")] // Adicionado "cadastrar" para diferenciar as rotas POST no Swagger
        public async Task<ActionResult<Usuarios>> Cadastrar(Usuarios novoUsuario)
        {
            var usuarioExiste = await _context.Usuarios
                .AnyAsync(u => u.Email == novoUsuario.Email); // Verifica duplicidade

            if (usuarioExiste)
                return BadRequest("E-Mail já está cadastrado.");

            // GERAÇÃO INTERNA: Garante que a data seja gravada corretamente no MySQL
            novoUsuario.DataCadastro = DateTime.Now;

            _context.Usuarios.Add(novoUsuario);
            await _context.SaveChangesAsync(); // Executa o INSERT

            return Ok(novoUsuario);
        }

        // FUNCIONALIDADE 2: Autenticação (Login)
        [HttpPost("login")]
        public async Task<ActionResult> Login([FromBody] LoginRequest dadosLogin)
        {
            var usuario = await _context.Usuarios
                .FirstOrDefaultAsync(u => u.Email == dadosLogin.Email && u.Senha == dadosLogin.Senha); // Valida dados

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

    public class LoginRequest
    {
        public string Email { get; set; } = string.Empty;
        public string Senha { get; set; } = string.Empty;
    }
}