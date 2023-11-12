using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.App_Data;
using WebApplicationMVC.API.Models;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.API.Controllers
{
    [ApiController]
    [Route("api/personas")]
    public class PersonasController : ControllerBase
    {
        private readonly ApplicationDbContext _context;

        public PersonasController(ApplicationDbContext context)
        {
            _context = context;
        }

        [HttpGet]
        public IActionResult GetPersonas()
        {
            var personas = _context.Personas.ToList();
            return Ok(personas);
        }

        [HttpPost]
        public IActionResult CrearPersona([FromBody] PersonaAPI personaAPI)
        {
            try
            {
                Persona persona = new Persona();
                // Manually map properties
                persona.Nombres = personaAPI.Nombres;
                persona.Apellidos = personaAPI.Apellidos;
                persona.NumeroIdentificacion = personaAPI.NumeroIdentificacion;
                persona.Email = personaAPI.Email;
                persona.TipoIdentificacion = personaAPI.TipoIdentificacion;
                persona.FechaCreacion = personaAPI.FechaCreacion;

                _context.Personas.Add(persona);
                _context.SaveChanges();
                return Ok(persona);
            }
            
            catch (Exception ex)
            {
                return BadRequest(new { error = ex.Message, stackTrace = ex.StackTrace
            });
    }
        }

    }
}
