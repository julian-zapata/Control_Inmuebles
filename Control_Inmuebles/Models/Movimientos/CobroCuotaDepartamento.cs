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
        public int ContratoDepartamentoId { get; set; }


        public int Inquilino { get; set; }
        public int Edificio { get; set; }
        public int Piso { get; set; }
        public int dpto { get; set; }

        //Debe pagar alquiler, agua, impuesto municipal y rentas
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal CoutaAlquiler { get; set; }
        public decimal ValorCouta { get { return MuestraCuota(); } }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal CuotaAgua { get; set; }
        public decimal ValorAgua { get { return MuestraValorAgua(); } }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal CoutaMunicipal { get; set; }
        public decimal ValorRentas { get { return MuestraValorRentas(); } }
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal  CoutaRentas { get; set; }
        public decimal ValorMunicipalidad { get { return MuestraValorMunicipalidad(); } }

        //Metodos para mostrar el valor de cada tipo de cuota
        
        public decimal MuestraCuota()
        {
            ContratoDepartamento ct = new ContratoDepartamento();
            return ct.CuotaMensualPrimerAño;
        }

        Alquiler dp = new Alquiler();

        public decimal MuestraValorAgua()
        {
            return dp.ValorAgua;
        }
        public decimal MuestraValorRentas()
        {
            return dp.ValorRentas;
        }
        public decimal MuestraValorMunicipalidad()
        {
            return dp.ValorMunicipalidad;
        }



        //Mora
        //[Column(TypeName = "decimal(18,4)")]
        //public decimal Mora { get { return RecargoMora(FechaCobro); } }
        //public decimal RecargoMora(DateTime FechaAtraso)
        //{
        //    decimal recargo;
        //    DateTime fecha = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        //    DateTime diasAtraso = fecha.AddDays(+10);
        //    if(FechaAtraso > diasAtraso)
        //    {
        //        int diasRecargo = diasAtraso.Day - FechaAtraso.Day;
        //        decimal porcentajeRecargo = (decimal)(diasRecargo * 0.03);
        //        recargo = CoutaAlquiler * porcentajeRecargo;
        //        return recargo - CoutaAlquiler;
        //    }
        //    return 0;
        //}

        //Interrrupcion de contrato
        //public string MotivoBaja { get; set; }
        //public DateTime FechaBajaAnticipoContrato { get; set; }

        //[Column(TypeName = "decimal(18,4)")]
        //public decimal Indenmizacion { get { return MontoIndenmizacion(FechaBajaAnticipoContrato); } }

        //[Column(TypeName = "decimal(18,4)")]
        //public decimal AlquileresAdeudados { get; set; }

        //public decimal MontoIndenmizacion(DateTime baja)
        //{
        //    ContratoDepartamento c = new ContratoDepartamento();

        //    if (baja < c.AltaContrato.AddMonths(+6))
        //    {
        //        return c.CuotaMensualPrimerAño;
        //    }
        //    else if (baja < c.AltaContrato.AddMonths(+12))
        //    {
        //        return c.CuotaMensualPrimerAño + (c.CuotaMensualPrimerAño / 2);
        //    }
        //    return (0);
        //}
    }
}
