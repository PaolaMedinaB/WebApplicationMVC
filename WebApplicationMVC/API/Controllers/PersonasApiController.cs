using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.App_Data;
using WebApplicationMVC.API.Models;

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
        public IActionResult CrearPersona([FromBody] PersonaAPI persona)
        {
            //_context.Personas.Add(persona);
            _context.SaveChanges();
            return Ok(persona);
        }

    }
}
