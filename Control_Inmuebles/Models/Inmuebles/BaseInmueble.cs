using Control_Inmuebles.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Inmuebles
{
    public class BaseInmueble
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int TipoInmuebleId { get; set; }

        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "mínimo 3 caracteres")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo puede ingresar letras y espacios")]
        public string Direccion { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El número es obligatorio")]
        [StringLength(5, ErrorMessage = "El número es demasiado largo")]
        public string Numero { get; set; }

        public TipoInmueble GetTipo()
        {
            TipoInmueble tipo;
            using (var context = new Control_InmueblesContext())
            {
                tipo = context.TipoInmueble.Where(x => x.Id == TipoInmuebleId).FirstOrDefault();
            }
            return tipo;
        }

        
    }
}
