using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Control_Inmuebles.Models.Personas;
using Control_Inmuebles.Models;
using Control_Inmuebles.Models.Inmuebles;

namespace Control_Inmuebles.Data
{
    public class Control_InmueblesContext : DbContext
    {
        public Control_InmueblesContext (DbContextOptions<Control_InmueblesContext> options)
            : base(options)
        {
        }

        public DbSet<Control_Inmuebles.Models.Personas.Garante> Garante { get; set; }

        public DbSet<Control_Inmuebles.Models.Personas.Inquilino> Inquilino { get; set; }

        public DbSet<Control_Inmuebles.Models.Personas.Propietario> Propietario { get; set; }

        public DbSet<Control_Inmuebles.Models.Inmueble> Inmueble { get; set; }

        public DbSet<Control_Inmuebles.Models.Inmuebles.BaseInmueble> BaseInmueble { get; set; }

        public DbSet<Control_Inmuebles.Models.Inmuebles.DptoInmueble> DptoInmueble { get; set; }

        public DbSet<Control_Inmuebles.Models.Inmuebles.PisoInmueble> PisoInmueble { get; set; }

        public DbSet<Control_Inmuebles.Models.TipoInmueble> TipoInmueble { get; set; }
    }
}
