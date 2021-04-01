using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Inmuebles___Copia
{
    public class Cochera: BaseDireccion
    {
        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El número es obligatorio")]
        [StringLength(3, ErrorMessage = "El número es demasiado largo")]
        public string NumCochera { get; set; }
    }
}
