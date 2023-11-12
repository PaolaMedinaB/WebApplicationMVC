namespace WebApplicationMVC.API.Models
{
    public class PersonaAPI
    {
        public int Id { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string NumeroIdentificacion { get; set; }

        public string Email { get; set; }

        public string TipoIdentificacion { get; set; }

        public DateTime FechaCreacion { get; set; }

        // Columna calculada: número de identificación con tipo de identificación concatenados
        public string NumeroIdentificacionConcat => $"{NumeroIdentificacion} - {TipoIdentificacion}";

        // Columna calculada: nombres y apellidos concatenados
        public string NombresApellidosConcat => $"{Nombres} {Apellidos}";
    }

}
