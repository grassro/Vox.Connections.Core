using Authentication.Model;
using Authetication.Data.Repository;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;

namespace Authentication.Controllers
{
    [Route("api/[controller]")]
    public class LoginController : Controller
    {

        private readonly IUsuarioRepository repo;

        public LoginController(IUsuarioRepository _repo)
        {
            repo = _repo;
        }

        /// <summary>
        /// Método que autentica o usuário e cria um novo token
        /// </summary>
        /// <param name="username">Nome de Usuário</param>
        /// <param name="password">Senha</param>
        /// <param name="signingConfigurations">Parametros de configuração em Model -> SigningCOnfiguration.cs</param>
        /// <param name="tokenConfigurations">Configuração do token em launckSettings.json -> TokenConfigurations</param>
        /// <returns></returns>
        [AllowAnonymous]
        [HttpPost("{username}/{password}")]
        public object Post(string username, string password, [FromServices]SigningConfigurations signingConfigurations, [FromServices]Token tokenConfigurations)
        {
            bool credenciaisValidas = false;

            //verifica se foi informado o usuário e a senha
            if (!String.IsNullOrWhiteSpace(username) && !String.IsNullOrWhiteSpace(password))
            {
                var usuarioBase = repo.Find(username, password);
                credenciaisValidas = (usuarioBase != null &&
                    username == usuarioBase.Result.UserID &&
                    password == usuarioBase.Result.Password);
            }

            //Caso as credenciais forem válidas, prossegue com a criação do token
            if (credenciaisValidas)
            {
                ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(username, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.UniqueName, username)
                    }
                );

                DateTime dataCriacao = DateTime.Now;
                DateTime dataExpiracao = dataCriacao +
                    TimeSpan.FromSeconds(tokenConfigurations.Seconds);

                var handler = new JwtSecurityTokenHandler();

                //Cria um novo token
                var securityToken = handler.CreateToken(new SecurityTokenDescriptor
                {
                    Issuer = tokenConfigurations.Issuer,
                    Audience = tokenConfigurations.Audience,
                    SigningCredentials = signingConfigurations.SigningCredentials,
                    Subject = identity,
                    NotBefore = dataCriacao,
                    Expires = dataExpiracao
                });
                var token = handler.WriteToken(securityToken);

                return new
                {
                    authenticated = true,
                    created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                    expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                    accessToken = token,
                    message = "OK"
                };
            }
            else
            {
                return new
                {
                    authenticated = false,
                    message = "Falha ao autenticar"
                };
            }
        }
    }
}