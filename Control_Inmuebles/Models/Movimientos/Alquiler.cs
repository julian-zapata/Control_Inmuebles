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
        //public int EdificioId { get; set; }
        //public int DepartamentoId { get; set; }
        //public int InquilinoId { get; set; }

        //Inmueble

        public int DepartamentoId { get; set; }

        //Valor de la Cuota
        public decimal ValorCuota { get { return MuestraCuota(); } }

        public decimal MuestraCuota()
        {
            ContratoDepartamento cd = new ContratoDepartamento();
            return cd.CuotaMensualPrimerAño;
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
        public bool CompletoCuotaMes { get { return MesCompleto(); } }
        public bool CompletoAguaMes { get { return AguaCompleto(); } }
        public bool CompletoMunicipalidadMes { get {return MunicipalCompleto(); } }
        public bool CompletoRentasMes { get { return RentasCompleto(); } }

        ContratoDepartamento contrato = new ContratoDepartamento();
        CobroCuotaDepartamento cobro = new CobroCuotaDepartamento();
        AguasCordobesas ag = new AguasCordobesas();
        Municipal m = new Municipal();
        Rentas r = new Rentas();

        public bool MesCompleto()
        {
            if(contrato.CuotaMensualPrimerAño == cobro.CoutaAlquiler)
            {
                return true;
            }
            return false;
        }

        public bool AguaCompleto()
        {
            if(ag.Monto == cobro.CuotaAgua)
            {
                return true;
            }
            return false;
        }

        public bool MunicipalCompleto()
        {
            if(m.Monto == cobro.CoutaMunicipal)
            {
                return true;
            }
            return false;
        }

         public bool RentasCompleto()
        {
            if(r.Monto == cobro.CoutaRentas)
            {
                return true;
            }
            return false;
        }

    }
}
