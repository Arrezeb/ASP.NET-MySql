using DesafioPedro2.Data;
using DesafioPedro2.ModelDTO;
using DesafioPedro2.Models;
using DesafioPedro2.Repositorios;
using DesafioPedro2.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace DesafioPedro2.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class UsuarioController : Controller
    {
        private readonly DesafioDbContext dbContext;

        public UsuarioController(DesafioDbContext dbContext)
        {
            this.dbContext = dbContext;
        }


        [HttpPost]
        public async Task<IActionResult> AddUsuario(UsuarioDTO usuarioDTO)
        {

            var usuarioExists = await dbContext.Usuarios.SingleOrDefaultAsync(user => user.Login == usuarioDTO.Login);

            if (usuarioExists != null)
            {
                return StatusCode(409, "Usuário já existente");
            }

            var usuario = new Usuario()
            {
                Nome = usuarioDTO.Nome,
                Email = usuarioDTO.Email,
                Login = usuarioDTO.Login,
                Senha = usuarioDTO.Senha,
                LastToken = string.Empty,
                ChaveVerificacao = Guid.NewGuid(),
                IsVerificado = false,
                Ativo = true,
                Excluido = false
            };

            await dbContext.Usuarios.AddAsync(usuario);
            await dbContext.SaveChangesAsync();

            return Ok(usuario);
        }



        [HttpPut("{email}/{chaveVerificacao}")]
        public async Task<IActionResult> AdicionarEmail(string Email, Guid chaveVerificacao)
        {
            var usuarioExists = await dbContext.Usuarios.FirstOrDefaultAsync(user => user.Email.Equals(Email) && user.ChaveVerificacao.Equals(chaveVerificacao));

            if (usuarioExists != null)
            {
                usuarioExists.IsVerificado = true;
                await dbContext.SaveChangesAsync();
                return Ok(usuarioExists);
            }

            return NotFound("Dados Incorretos!");

        }



        [HttpPost]
            [Route("login")]
            public async Task<ActionResult<dynamic>> Authenticate([FromBody] Usuario model)
            {
                // Recupera o usuário
                var user = RepUsuario.Get(model.Nome, model.Senha);

                // Verifica se o usuário existe
                if (user == null)
                    return NotFound(new { message = "Usuário/Login ou senha inválidos" });

                // Gera o Token
                var token = TokenService.GenerateToken(user);

                // Oculta a senha
                user.Senha = "";

                // Retorna os dados
                return new
                {
                    user = user,
                    token = token
                };
            }
    }
}
