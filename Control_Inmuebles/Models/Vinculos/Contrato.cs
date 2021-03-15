using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Vinculos
{
    public class Contrato
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public DateTime AltaContrato { get; set; }

        [Required]
        public string PlazoContrato { get; set; }

        [Required]
        public DateTime ClausuraContrato { get; set; }

        [Required]
        public int PropietarioId { get; set; }

        [Required]
        public int InquilinoId { get; set; }

        [Required]
        public int InmuebleId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ValorContrato { get; set; }

        [Required]
        public string DestinoInmueble { get; set; }
            //destino en lista HTML

        [Required]
        public int GaranteId { get; set; }


    }
}
