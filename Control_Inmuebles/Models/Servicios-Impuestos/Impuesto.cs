using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Servicios_Impuestos
{
    public class Impuesto : BaseImpuestoServicio
    {
        [Required(ErrorMessage = "Campo requerido")]
        public int TipoImpuestoId { get; set; }
    }
}
