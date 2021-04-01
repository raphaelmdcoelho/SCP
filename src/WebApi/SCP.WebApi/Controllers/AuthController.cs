using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using SCP.CrossCutting.MapModels.Usuario;
using SCP.Services.Authentication;
using SCP.Services.Token;
using SCP.Services.Usuario;
using System.Threading.Tasks;

namespace SCP.WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;
        private readonly IUsuarioService _usuarioService;

        public AuthController(IAuthService authService,
            IUsuarioService usuarioService)
        {
            _authService = authService;
            _usuarioService = usuarioService;
        }

        [HttpPost("Registrar")]
        [AllowAnonymous]
        public async Task<IActionResult> Register(UsuarioAddModel model)
        {
            ResponseAddUsuarioModel response = await _authService.Register(model, model.Senha);
            if (!response.Success)
            {
                return BadRequest(response);
            }
            return Ok(response);
        }

        [HttpPost]
        [Route("Logar")]
        [AllowAnonymous]
        public async Task<ActionResult<dynamic>> Authenticate([FromBody] LoginModel model)
        {
            // Recupera o usuário
            var user = await _usuarioService.Get(model.Username, model.Senha);

            // Verifica se o usuário existe
            if (user == null)
                return NotFound(new { message = "Usuário ou senha inválidos" });

            // Gera o Token
            var token = TokenService.GenerateToken(user);

            // Oculta a senha
            user.Senha = "";

            // Retorna os dados
            return new
            {
                user = user,
                token = token,
                message = "Usuário cadastrado com sucesso"
            };
        }
    }
}
