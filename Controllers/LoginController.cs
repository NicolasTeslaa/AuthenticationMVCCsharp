using Microsoft.AspNetCore.Mvc;
using AuthenticationMVCCsharp.Models;
using AuthenticationMVCCsharp.Repositories;
using AuthenticationMVCCsharp.Services;

namespace AuthenticationMVCCsharp.Controllers;

[ApiController]
[Route("v1")]
public class LoginController : ControllerBase
{
    [HttpPost]
    [Route("Login")]
    public async Task<ActionResult<dynamic>> AuthenticateAsync([FromBody] User model)
    {
        // Recupera o usuário
        var user = UserRepository.Get(model.Username, model.Password);

        // Verifica se o usuário existe
        if (User == null)
            return NotFound(new { message = "Usuário ou senha inválidos" });

        // Gera o Token
        var token = TokenService.GenerateToken(user);

        // Oculta a senha
        user.Password = "";

        // Retorna os dados
        return new
        {
            user = User,
            token = token
        };
    }
}
