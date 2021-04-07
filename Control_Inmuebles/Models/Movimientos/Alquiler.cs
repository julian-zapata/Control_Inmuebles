using Control_Inmuebles.Data;
using Control_Inmuebles.Models.Impuestos;
using Control_Inmuebles.Models.Servicios;
using Control_Inmuebles.Models.Vinculos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Movimientos
{
    public class Alquiler
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int ContratoDepartamentoId { get; set; }

        //Valor de la Cuota
        [NotMapped]
        public decimal ValorCuota { get; set; }

        public ContratoDepartamento MuestraDatoContrato()
        {
            ContratoDepartamento cd;
            using(var context = new Control_InmueblesContext())
            {
                cd = context.ContratoDepartamento.Where(x => x.Id == ContratoDepartamentoId).FirstOrDefault();
            }
            return cd;
        }

        //Impuesto por unidad
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ValorAgua { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ValorRentas { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal ValorMunicipalidad { get; set; }

        //Abonó mes completo?
        [NotMapped]
        public string CompletoCuotaMes { get;  }
        [NotMapped]
        public string CompletoAguaMes { get; }
        [NotMapped]
        public string CompletoMunicipalidadMes { get; }
        [NotMapped]
        public string CompletoRentasMes { get;  }

        //Metodos de pago completo o mora

        [NotMapped]
        public string DatosInquilinosDepto { get { return MuestraDatoContrato().NombreDepartamento; } }
        [NotMapped]
        public string NombreInquilino { get { return MuestraDatoContrato().NombreInquilino; } }
    }
}
