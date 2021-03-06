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
        public decimal ValorCouta { get { return MuestraDatosAlquiler().MuestraDatoContrato().CuotaMensualPrimerAño; } }
        [NotMapped]
        public string DifCuota { get { return DifSigno(CoutaAlquiler, ValorCouta); } }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal CuotaAgua { get; set; }
        [NotMapped]
        public decimal ValorAgua { get { return MuestraDatosAlquiler().ValorAgua; } }
        [NotMapped]
        public string DifAgua { get { return DifSigno(CuotaAgua, ValorAgua); } }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal CoutaMunicipal { get; set; }
        [NotMapped]
        public decimal ValorMunicipal { get { return MuestraDatosAlquiler().ValorMunicipalidad; } }
        [NotMapped]
        public string DifMunicipalidad { get { return DifSigno(CoutaMunicipal, ValorMunicipal); } }

        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal  CoutaRentas { get; set; }
        [NotMapped]
        public decimal ValorRentas { get { return MuestraDatosAlquiler().ValorRentas; } }
        [NotMapped]
        public string DifRentas { get { return DifSigno(CoutaRentas, ValorRentas); } }

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

        public string DifSigno(decimal cobro, decimal valor)
        {
            if (cobro >= valor)
            {
                return "diferencia: + " + (cobro - valor);
            }
            else return "diferencia: " + (cobro - valor) + " deuda existente";
        }

        //Abonó mes completo?
        [NotMapped]
        public string CompletoCuotaMes { get { return PagoCompleto(ValorCouta, CoutaAlquiler); } }
        [NotMapped]
        public string CompletoAguaMes { get { return PagoCompleto(ValorAgua, CuotaAgua); } }
        [NotMapped]
        public string CompletoMunicipalidadMes { get { return PagoCompleto(ValorMunicipal, CoutaMunicipal); } }
        [NotMapped]
        public string CompletoRentasMes { get { return PagoCompleto(ValorRentas, CoutaRentas); } }

        //Metodos de pago completo o mora
        public string PagoCompleto(decimal valor, decimal pago)
        {
            if (valor <= pago)
            {
                return "completo";
            }
            else return "en deuda";
        }

    }
}
