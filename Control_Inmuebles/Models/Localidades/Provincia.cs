using Control_Inmuebles.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Localidades
{
    public class Provincia : Tipo
    {
        
        public int PaisId { get; set; }

        public Pais GetPais()
        {
            Pais pais;
            using(var context = new Control_InmueblesContext())
            {
                pais = context.Pais.Where(x => x.Id == PaisId).FirstOrDefault();
            }
            return pais;
        }
    }
}
