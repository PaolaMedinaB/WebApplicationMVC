using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using WebApplicationMVC.App_Data;
using System.Diagnostics;
using WebApplicationMVC.Models;

namespace WebApplicationMVC.Controllers
{
    public class HomeController : Controller
    {
        private readonly ApplicationDbContext _context;
        
        public HomeController(ApplicationDbContext context)
        {
            _context = context;
            
        }

        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Usuarios()
        {
            return View("Usuarios/Login");
        }

        public IActionResult Personas()
        {
            var personas = _context.Personas.ToList();
            return View("Personas/List", personas);
        }
        
        public IActionResult CreateForm()
        {
            return View("Personas/Create");
        }
        public IActionResult Create(Persona persona)
        {
            _context.Personas.Add(persona);
            _context.SaveChanges();
            //return Ok(persona);
            var personas = _context.Personas.ToList();
            return View("Personas/List", personas);
        }

        public IActionResult CreateUserForm()
        {
            return View("Usuarios/CreateUser");
        }
        public IActionResult CreateUser(Usuario usuario)
        {
            _context.Usuarios.Add(usuario);
            _context.SaveChanges();
            TempData["SuccessMessage"] = "Usuario creado exitosamente.";
            return View("Usuarios/Login");

         }

        public IActionResult Login(string nombreUsuario, string pass)
        {

            var usuario = _context.Usuarios.SingleOrDefault(u => u.NombreUsuario == nombreUsuario && u.Pass == pass);

            if (usuario != null)
            {
                // Credentials are valid
                return Ok("Login exitoso!"); // Redirect to a success page or perform other actions
            }
            else
            {
                // Credentials are not valid
                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos");
                return View("Usuarios/Login"); // Return to the login view with an error message
            }
        }
        [HttpPost]
        public IActionResult LoCheckCredentialsgin(string userName, string password)
        {
            // Lógica para validar el inicio de sesión
            var usuario = _context.Usuarios.SingleOrDefault(u => u.NombreUsuario == userName && u.Pass == password);

            if (usuario != null)
            {
                // Usuario válido, redirigir a la página principal
                return Ok("Login exitoso!");
            
        }
            else
            {
                // Usuario no válido, mostrar mensaje de error
                ModelState.AddModelError("", "Nombre de usuario o contraseña incorrectos");
                return View();
            }
        }

        //[ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        //public IActionResult Error()
        //{
        //    return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        //}
    }
}