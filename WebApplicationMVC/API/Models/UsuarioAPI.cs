namespace WebApplicationMVC.API.Models
{
    public class UsuarioAPI
    {
        public int Id { get; set; }

        public string NombreUsuario { get; set; }

        public string Pass { get; set; }

        public DateTime FechaCreacion { get; set; }
    }

}
