using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Inmuebles___Copia
{
    public class Casa : BaseDireccion
    {
        [Required(ErrorMessage = "Campo requerido")]
        [StringLength(50, MinimumLength = 3, ErrorMessage = "mínimo 3 caracteres")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo puede ingresar letras y espacios")]
        public string Descripcion { get; set; }

        [StringLength(50, MinimumLength = 3, ErrorMessage = "mínimo 3 caracteres")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo puede ingresar letras y espacios")]
        public string Observacion { get; set; }
    }
}
