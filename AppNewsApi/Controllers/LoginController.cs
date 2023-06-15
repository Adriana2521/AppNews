using AppNewsApi.DTOs;
using AppNewsApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace AppNewsApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class LoginController : ControllerBase
    {
        public Sistem21NoticiasdbContext Context;
        public LoginController(Sistem21NoticiasdbContext context)
        {
            this.Context = context;
        }

        [HttpGet]
        public IActionResult Login(LoginDTO login)
        {
            var usuario = Context.Usuarios.SingleOrDefault(x => x.Correo ==login.Usuario && x.Contraseña == login.Contraseña);
            if (usuario==null)
            {
                return Unauthorized("Correo o contraseña incorrecta.");
            }
            else
            {
                List<Claim> claims = new()
                {
                    new Claim("Id", usuario.Id.ToString()),
                    new Claim(ClaimTypes.Name, usuario.Nombre),
                    new Claim(ClaimTypes.Email, usuario.Correo ?? ""),
                    new Claim(ClaimTypes.Role, usuario.Rol)
                };

                SecurityTokenDescriptor TokenDescriptor = new()
                {
                    Issuer = "docentes.itesrc.net",
                    Audience = "mauidocentes",
                    IssuedAt = DateTime.UtcNow,
                    Expires = DateTime.UtcNow.AddHours(4),
                    SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(Encoding.UTF8.GetBytes("NoticiasKeyMoviles83G")),
                    SecurityAlgorithms.HmacSha256),
                    Subject = new ClaimsIdentity(claims, JwtBearerDefaults.AuthenticationScheme)
                };
                JwtSecurityTokenHandler handler = new();
                var token = handler.CreateToken(TokenDescriptor);
                //3. Regresar el token
                return Ok(handler.WriteToken(token));
            }
        }
    }
}