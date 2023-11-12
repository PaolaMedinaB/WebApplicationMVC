using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.App_Data;
using WebApplicationMVC.API.Models;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.API.Controllers
{
    [ApiController]
    [Route("api/usuarios")]
    public class UsuariosController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public UsuariosController(ApplicationDbContext context)
        {
            _context = context;
        }



        [HttpPost("login")]
        public IActionResult Login([FromBody] UsuarioAPI usuarioAPI)
        {

            var usuario = _context.Usuarios.SingleOrDefault(u => u.NombreUsuario == usuarioAPI.NombreUsuario && u.Pass == usuarioAPI.Pass);

            if (usuario != null)
            {
                // Credentials are valid
                return Ok("Login exitoso!"); // Redirect to a success page or perform other actions
            }
            else
            {
                // Credentials are not valid
                return BadRequest("Nombre de usuario o contraseña incorrectos");
            }
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] UsuarioAPI usuarioAPI)
        {
            Usuario usuario = new Usuario();
            usuario.NombreUsuario = usuarioAPI.NombreUsuario;
            usuario.Pass = usuarioAPI.Pass;
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Ok(usuario);

        }

    }
}
