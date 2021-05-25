using System;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.IdentityModel.Tokens;
using SchoolAPI.Models;

namespace SchoolAPI.Controllers
{
    [Route("api/login")]
    public class LoginController : ControllerBase
    {
        private readonly RepositoryContext context;
        private readonly IConfiguration conf;
        public LoginController(RepositoryContext context, IConfiguration conf)
        {
            this.context = context;
            this.conf = conf;
        }

        private string Hash(string texto)
        {
            using (SHA1Managed sha1 = new SHA1Managed())
            {
                byte[] stringTemp = System.Text.Encoding.UTF8.GetBytes(texto);
                var hash = sha1.ComputeHash(stringTemp);
                return Convert.ToBase64String(hash);
            }
        }

        [HttpPost]
        public IActionResult Post([FromBody] Usuario usuario)
        {

            Usuario tmp = context.Usuarios.FirstOrDefault(x => x.Correo == usuario.Correo
            && x.Pass == Hash(usuario.Pass));
            if(tmp == null)
            {
                return Ok(new { StatusCode = "400", mensaje = "Usuario y/o password incorrecto", token = "NG" });
            }
            else
            {
                string token = obtenerToken(tmp);
                return Ok(new {StatusCode = "200", mensaje = "Bienvenido usuario", token = token, usuario=usuario });
            }
        }

        private string obtenerToken(Usuario usuario)
        {
            var SecretKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(conf["Authentication:SecretKey"]));
            var credenciales = new SigningCredentials(SecretKey, SecurityAlgorithms.HmacSha256);
            var encabezado = new JwtHeader(credenciales);

            Claim[] claims = new[]
            {
                new Claim(ClaimTypes.Name, usuario.Nombre),
                new Claim(ClaimTypes.UserData, usuario.Correo)
            };

            JwtPayload datos = new JwtPayload
            (
                conf["Authentication:Issuer"],
                conf["Authentication:Audience"],
                claims, DateTime.Now, DateTime.Now.AddMinutes(5)
            );
            JwtSecurityToken token = new JwtSecurityToken(encabezado, datos);
            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }
}