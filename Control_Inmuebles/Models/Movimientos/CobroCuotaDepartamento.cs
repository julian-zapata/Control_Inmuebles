using Control_Inmuebles.Data;
using Control_Inmuebles.Models.Inmuebles___Copia;
using Control_Inmuebles.Models.Vinculos;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Movimientos
{
    public class CobroCuotaDepartamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime FechaCobro { get; set; }

        [Required]
        public int AlquilerId { get; set; }

        [NotMapped]
        public int Inquilino { get; set; }
        [NotMapped]
        public int Edificio { get; set; }
         [NotMapped]
        public int Departamento { get; set; }
        

        //Debe pagar alquiler, agua, impuesto municipal y rentas
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal CoutaAlquiler { get; set; }
        [NotMapped]
        public decimal ValorCouta { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal CuotaAgua { get; set; }
        [NotMapped]
        public decimal ValorAgua { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal CoutaMunicipal { get; set; }
        [NotMapped]
        public decimal ValorRentas { get; set; }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal  CoutaRentas { get; set; }
        [NotMapped]
        public decimal ValorMunicipalidad { get;set; }

        //Metodos para mostrar el valor de cada tipo de cuota
        
       public Alquiler MuestraDatosAlquiler()
        {
            Alquiler alq;
            using(var context = new Control_InmueblesContext())
            {
                alq = context.Alquiler.Where(x => x.Id == AlquilerId).FirstOrDefault();
            }
            return alq;
        }
    }
}
