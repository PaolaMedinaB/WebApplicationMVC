using Microsoft.AspNetCore.Mvc.Rendering;
using System.ComponentModel.DataAnnotations;
using System.Data.SqlTypes;

namespace WebApplicationMVC.Models
{
    public class Persona
    {
        public int Id { get; set; }

        public string Nombres { get; set; }

        public string Apellidos { get; set; }

        public string NumeroIdentificacion { get; set; }

        public string Email { get; set; }

        public string TipoIdentificacion { get; set; }
        [DataType(DataType.DateTime)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd HH:mm:ss}", ApplyFormatInEditMode = true)]
        public DateTime FechaCreacion { get; set; }
        //public DateTime? FechaCreacion { get; set; } = DateTime.MinValue;

        // Calculated column: ID number with concatenated ID type
        public string NumeroIdentificacionConcat => $"{NumeroIdentificacion} - {TipoIdentificacion}";

        // Calculated column: concatenated first and last names
        public string NombresApellidosConcat => $"{Nombres} {Apellidos}";
    }

}
