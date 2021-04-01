using Control_Inmuebles.Data;
using Control_Inmuebles.Models.Personas;
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

        [RegularExpression("(^[0-9]+$)", ErrorMessage = "Solo se permiten números")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El número es obligatorio")]
        [StringLength(12, ErrorMessage = "El número es demasiado largo")]
        public string NumContrato { get; set; }

                //Agregar el numero de contrato a las demas funciones


        [Required]
        public string PlazoContrato { get; set; }
        //opciones por HTML

        [Required]
        public DateTime ClausuraContrato { get { return FinContrato(AltaContrato); }} 
            //calcular 3 años a partir del alta. Tener en cuenta las clausulas.

        [Required]
        public int PropietarioId { get; set; }

        [Required]
        public int InquilinoId { get; set; }

        [Required]
        public string Inmueble { get; set; }

        public int CasaId { get; set; }
        public int CocheraId { get; set; }
        public int DepartamentoId { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ValorContrato { get; set; }

        [Required]
        public int Garante1 { get; set; }

        [Required]
        public int Garante2 { get; set; }

        public DateTime FinContrato(DateTime date)
        {
            var fin = date.AddYears(+3);
            return fin;
        }

        Control_InmueblesContext context = new Control_InmueblesContext();

        public Inquilino GetInquilino()
        {
            Inquilino inq = context.Inquilino.Where(x => x.Id == InquilinoId).FirstOrDefault();
            return inq;
        }
    }
}
