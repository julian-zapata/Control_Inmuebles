using Control_Inmuebles.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Inmuebles
{
    public class DptoInmueble
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(3, MinimumLength = 1, ErrorMessage = "Hasta 3 caracteres válidos")]
        [RegularExpression("^[a-zA-Z]*$", ErrorMessage = "Solo puede ingresar letras y/o numeros")]
        public string Descripcion { get; set; }

        [Required]
        public int BaseInmuebleId { get; set; }

        [Required]
        public int PisoInmuebleId { get; set; }

        Control_InmueblesContext context = new Control_InmueblesContext();

        public BaseInmueble GetDirecInmueble()
        {
            BaseInmueble tipo;
                tipo = context.BaseInmueble.Where(x => x.Id == BaseInmuebleId).FirstOrDefault();
            return tipo;
        }

        public PisoInmueble GetPiso()
        {
            PisoInmueble piso;
                piso = context.PisoInmueble.Where(x => x.Id == PisoInmuebleId).FirstOrDefault();
            return piso;
        }
    }
}
