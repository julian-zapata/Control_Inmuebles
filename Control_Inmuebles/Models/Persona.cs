using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using static Control_Inmuebles.Validaciones.FechaValidacion;

namespace Control_Inmuebles.Models
{
    public abstract class Persona
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [StringLength(20, MinimumLength = 3, ErrorMessage = "mínimo 3 caracteres")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo puede ingresar letras y espacios")]
        public string Nombre { get; set; }

        [Required]
        [StringLength(12, MinimumLength = 3, ErrorMessage = "mínimo 3 caracteres")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo puede ingresar letras y espacios")]
        public string Apellido { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El número es obligatorio")]
        [StringLength(12, ErrorMessage = "El número es demasiado largo")]
        public string Dni { get; set; }

        [Required]
        [ValidMayor18(ErrorMessage ="La persona debe ser mayor de 18 años")]
        public DateTime FechaNacimiento { get; set; }

        [Required(ErrorMessage = "Domicilio requerido")]
        [StringLength(30, MinimumLength = 3, ErrorMessage = "mínimo 3 caracteres")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo puede ingresar letras y espacios")]
        public string Domicilio { get; set; }

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El número es obligatorio")]
        [StringLength(5, ErrorMessage = "El número es demasiado largo")]
        public string Numero { get; set; }
        //Hacer un metodo que indique que si no tiene numero aparezca un cartel S/N

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [StringLength(5, ErrorMessage = "El número es demasiado largo")]
        public string Piso { get; set; }

        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo una letra o un numero")]
        [StringLength(1, ErrorMessage = "Solo un caracter")]
        public string Departamento { get; set; }

        [Required(ErrorMessage = "Barrio requerido")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo puede ingresar letras y espacios")]
        public string Barrio { get; set; }

        [Required(ErrorMessage = "Domicilio requerido")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo puede ingresar letras y espacios")]
        public string Ciudad { get; set; }

        [Required(ErrorMessage = "Domicilio requerido")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo puede ingresar letras y espacios")]
        public string Provincia { get; set; }

        [Display(Name = "e-mail", Prompt = "pepito@mail.com")]
        [RegularExpression("^(([\\w-]+\\.)+[\\w-]+|([a-zA-Z]{1}|[\\w-]{2,}))@(([a-zA-Z]+[\\w-]+\\.){1,2}[a-zA-Z]{2,4})$",
            ErrorMessage = "e-mail incorrecto")]
        [MaxLength(25)]
        public string Email { get; set; }
    }
}
