using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.App_Data;
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
        public IActionResult Login([FromBody] Usuario usuario)
        {
            var user = _context.Usuarios.FirstOrDefault(u => u.NombreUsuario == usuario.NombreUsuario && u.Pass == usuario.Pass);

            if (user != null)
            {
                return Ok("Login exitoso");
            }
            else
            {
                return BadRequest("Usuario o contraseña incorrectos");
            }
        }

        [HttpPost]
        public IActionResult CrearUsuario([FromBody] Usuario usuario)
        {

            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            return Ok(usuario);
        }
    }
}
