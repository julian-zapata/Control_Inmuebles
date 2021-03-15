using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;
using static Control_Inmuebles.Validaciones.FechaValidacion;

namespace Control_Inmuebles.Models.Servicios_Impuestos
{
    public class BaseImpuestoServicio
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [ValidMinFechaImpServ(ErrorMessage = "EL campo puede ingresar como máximo un mes de atraso")]
        [ValidMaxFechaImpServ(ErrorMessage ="El campo ingresado no puede superar la fecha del día")]
        public DateTime Fecha { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        public string Periodo { get; set; }
            //Valores fijados en HTML (dropdownlist)

        [Required(ErrorMessage = "Campo requerido")]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Monto { get; set; }
    }
}
