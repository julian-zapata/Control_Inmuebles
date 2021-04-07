using Control_Inmuebles.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Inmuebles
{
    public class Edificio : BaseDireccion
    {
       [NotMapped]
        public string DatoEdificio { get { return Direccion + " " + Numero; } }
    }
}
