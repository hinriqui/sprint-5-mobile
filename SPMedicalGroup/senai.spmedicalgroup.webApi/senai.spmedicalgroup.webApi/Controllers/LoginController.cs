using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using senai.spmedicalgroup.webApi.Domains;
using senai.spmedicalgroup.webApi.Interfaces;
using senai.spmedicalgroup.webApi.ViewModels;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;

namespace senai.spmedicalgroup.webApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        private IUsuarioRepository _Repository { get; set; }

        public LoginController()
        {
            _Repository = new Repositories.UsuarioRepository();
        }

        /// <summary>
        /// Lê todos os objetos cadastrados
        /// </summary>
        /// <returns>Lista de todos os objetos</returns>
        /// <summary>
        /// Busca objeto atráves do ID
        /// </summary>
        /// <returns>Lista apenas o objeto selecionado</returns>
        [HttpPost()]
        public IActionResult Login(LoginViewModel login)
        {
            try
            {
                Domains.Usuario usuarioBuscado = _Repository.Logar(login.email, login.senha);
        
                if (usuarioBuscado == null)
                {
                    return BadRequest($"E-mail ou senha inválidos!");
                }

                var minhasClaims = new[]
                {
                    new Claim(JwtRegisteredClaimNames.Email, usuarioBuscado.Email),
                    new Claim(ClaimTypes.Role, usuarioBuscado.TipoUsuario.ToString()),
                    new Claim("role", usuarioBuscado.TipoUsuario.ToString()),
                    new Claim("username", usuarioBuscado.NomeUsuario)
                };

                var key = new SymmetricSecurityKey(System.Text.Encoding.UTF8.GetBytes("spmg-chave-autenticacao"));

                var creds = new SigningCredentials(key, SecurityAlgorithms.HmacSha256);

                var meuToken = new JwtSecurityToken(
                        issuer: "spMedGroup.webAPI",
                        audience: "spMedGroup.webAPI",
                        claims: minhasClaims,
                        expires: DateTime.Now.AddHours(8),
                        signingCredentials: creds
                    );

                return Ok(new
                {
                    token = new JwtSecurityTokenHandler().WriteToken(meuToken)
                });
            }
            catch (Exception ex)
            {
                return BadRequest(ex);
            }
        }

    }
}
