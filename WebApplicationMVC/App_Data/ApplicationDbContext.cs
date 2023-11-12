using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System.Collections.Generic;
using WebApplicationMVC.Controllers;
using WebApplicationMVC.API.Models;
using WebApplicationMVC.Models;
using System.ComponentModel.DataAnnotations.Schema;

namespace WebApplicationMVC.App_Data
{
    public class ApplicationDbContext : DbContext
    {
        private readonly IConfiguration Configuration;

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options, IConfiguration configuration)
            : base(options)
        {
            Configuration = configuration;
        }
        //[NotMapped]
        public DbSet<Persona> Personas { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Configuration.GetConnectionString("DefaultConnection"));
            //optionsBuilder.UseSqlServer(@"Server=LAPTOP-I0JS4GM9;Database=DV-Partners");
        }
        
    }

}

