using Control_Inmuebles.Data;
using Control_Inmuebles.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Localidades
{
    public class Ciudad : Tipo
    {
        public int PaisId { get; set; }
        public int ProvinciaId { get; set; }

        Control_InmueblesContext context = new Control_InmueblesContext();

        public Pais GetPais()
        {
            Pais pais = context.Pais.Where(x => x.Id == PaisId).FirstOrDefault();
            return pais;
        }

        public Provincia GetProvincia()
        {
            Provincia provincia = context.Provincia.Where(x => x.Id == ProvinciaId).FirstOrDefault();
            return provincia;
        }
    }
}
