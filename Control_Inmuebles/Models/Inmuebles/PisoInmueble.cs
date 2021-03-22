using Control_Inmuebles.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Inmuebles
{
    public class PisoInmueble
    {
        [Key]
        public int Id { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El número es obligatorio")]
        [StringLength(3, ErrorMessage = "El número es demasiado largo")]
        public string Descripcion { get; set; }

        [Required]
        public int BaseInmuebleId { get; set; }

        public int TipoInmuebleId { get; set; }

        Control_InmueblesContext context = new Control_InmueblesContext();

        public BaseInmueble GetDirecInmueble()
        {
            BaseInmueble tipo;
            tipo = context.BaseInmueble.Where(x => x.Id == BaseInmuebleId).FirstOrDefault();
            return tipo;
            //para mostrar la direccion
        }

        public TipoInmueble GetTipo()
        {
            TipoInmueble tipo;
            tipo = context.TipoInmueble.Where(x => x.Id == TipoInmuebleId).FirstOrDefault();
            return tipo;
            //para mostrar la direccion
        }
    }
}
