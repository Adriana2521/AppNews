using AppNewsApi.DTOs;
using AppNewsApi.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace AppNewsApi.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class NoticiasController : ControllerBase
    {
        Sistem21NoticiasdbContext Context;
        public NoticiasController(Sistem21NoticiasdbContext context)
        {
            this.Context = context;
        }

        [HttpGet]
        public IActionResult GetAll()
        {
            //Buscamos el id en los claims
            var idclaim = User.Claims.Where(x => x.Type=="Id").Select(x => int.Parse(x.Value)).FirstOrDefault();

            var admins = Context.Usuarios.OrderBy(x => x.Id).Select(x => new UsuarioDTO()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Rol = x.Rol,
                Correo = x.Correo ?? "",
                Noticias = x.Noticias
            });
            if (admins != null)
            {
                return Ok(admins);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("admin")]
        public IActionResult GetAdmins()
        {
            //Buscamos el id en los claims
            var idclaim = User.Claims.Where(x => x.Type=="Id").Select(x => int.Parse(x.Value)).FirstOrDefault();

            var admins = Context.Usuarios.OrderBy(x => x.Id).Where(x => x.Rol=="Administrador").Select(x => new UsuarioDTO()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Rol = x.Rol,
                Correo = x.Correo ?? "",
                Noticias = x.Noticias
            });
            if (admins != null)
            {
                return Ok(admins);
            }
            else
            {
                return BadRequest();
            }
        }
        [HttpGet("Usuario")]
        public IActionResult GetUsuarios()
        {
            //Buscamos el id en los claims
            var idclaim = User.Claims.Where(x => x.Type=="Id").Select(x => int.Parse(x.Value)).FirstOrDefault();

            var admins = Context.Usuarios.OrderBy(x => x.Id).Where(x => x.Rol=="Usuario").Select(x => new UsuarioDTO()
            {
                Id = x.Id,
                Nombre = x.Nombre,
                Rol = x.Rol,
                Correo = x.Correo ?? "",
                Noticias = x.Noticias
            });
            if (admins != null)
            {
                return Ok(admins);
            }
            else
            {
                return BadRequest();
            }
        }
    }
}
