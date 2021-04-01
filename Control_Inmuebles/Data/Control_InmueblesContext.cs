using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Control_Inmuebles.Models.Personas;
using Control_Inmuebles.Models;
using Control_Inmuebles.Models.Inmuebles;
using Control_Inmuebles.Models.Localidades;
using Control_Inmuebles.Models.Servicios_Impuestos;
using Control_Inmuebles.Models.Vinculos;
using Microsoft.Extensions.Configuration;
using Control_Inmuebles.Models.Inmuebles___Copia;

namespace Control_Inmuebles.Data
{
    public class Control_InmueblesContext : DbContext
    {
        public Control_InmueblesContext() : base()
        {
            initContext();
        }

        public Control_InmueblesContext (DbContextOptions<Control_InmueblesContext> options)
            : base(options)
        {
            initContext();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder options) => options.UseSqlServer(connectionString);

        private string connectionString;
        private void initContext()
        {
            var builder = new ConfigurationBuilder();
            builder.AddJsonFile("appsettings.json", optional: false);
            var configuration = builder.Build();
            connectionString = configuration.GetConnectionString("Control_InmueblesContext").ToString();
        }

        public DbSet<Control_Inmuebles.Models.Personas.Garante> Garante { get; set; }

        public DbSet<Control_Inmuebles.Models.Personas.Inquilino> Inquilino { get; set; }

        public DbSet<Control_Inmuebles.Models.Personas.Propietario> Propietario { get; set; }

        public DbSet<Control_Inmuebles.Models.Localidades.Ciudad> Ciudad { get; set; }

        public DbSet<Control_Inmuebles.Models.Localidades.Pais> Pais { get; set; }

        public DbSet<Control_Inmuebles.Models.Localidades.Provincia> Provincia { get; set; }

        public DbSet<Control_Inmuebles.Models.Servicios_Impuestos.Impuesto> Impuesto { get; set; }

        public DbSet<Control_Inmuebles.Models.Servicios_Impuestos.Servicio> Servicio { get; set; }

        public DbSet<Control_Inmuebles.Models.Servicios_Impuestos.TipoImpuesto> TipoImpuesto { get; set; }

        public DbSet<Control_Inmuebles.Models.Servicios_Impuestos.TipoServicio> TipoServicio { get; set; }

        public DbSet<Control_Inmuebles.Models.Vinculos.Contrato> Contrato { get; set; }

        public DbSet<Control_Inmuebles.Models.Inmuebles.Edificio> Edificio { get; set; }

        public DbSet<Control_Inmuebles.Models.Inmuebles___Copia.Departamento> Departamento { get; set; }

        public DbSet<Control_Inmuebles.Models.Inmuebles___Copia.Cochera> Cochera { get; set; }

        public DbSet<Control_Inmuebles.Models.Inmuebles___Copia.Casa> Casa { get; set; }

    }
}
