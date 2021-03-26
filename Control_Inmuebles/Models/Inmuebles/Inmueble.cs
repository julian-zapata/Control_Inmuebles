using Control_Inmuebles.Models.Inmuebles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models
{
    public class Inmueble : BaseInmueble
    {
        [Required]
        public int PisoInmuebleId { get; set; }

        [Required]
        public int DptoInmuebleId { get; set; }

        [Required]
        public int CiudadId { get; set; }

        [Required]
        public int ProvinciaId { get; set; }

        [Required]
        public int PaisId { get; set; }

        [Required]
        public string Estado { get; set; }
        //Ocupado o desocupado. Valor por lista en HTML

        [StringLength(50, ErrorMessage = "míáximo 50 caracteres")]
        [RegularExpression("^[a-zA-Z ]*$", ErrorMessage = "Solo puede ingresar letras y espacios")]
        public string Observaciones { get; set; }

    }
}
