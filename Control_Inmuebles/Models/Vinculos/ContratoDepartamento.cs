using Control_Inmuebles.Data;
using Control_Inmuebles.Models.Inmuebles;
using Control_Inmuebles.Models.Inmuebles___Copia;
using Control_Inmuebles.Models.Personas;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Vinculos
{
    public class ContratoDepartamento
    {
        //ContratoDepartamento de vivienda habitacional
        [Key]
        public int Id { get; set; }

        //Locador
        [Required]
        public int PropietarioId { get; set; }

        //Locatario
        [Required]
        public int InquilinoId { get; set; }

        //Primera(Objeto)
        [Required]
        public int EdificioId { get; set; }
        public int DepartamentoId { get; set; }

        //Segunda(Plazo)
        [Required]
        public int PlazoContrato { get; set; }
            //opciones por HTML


        //Tercera(Alquiler-Precio)
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal CuotaMensualPrimerAño { get; set; }

        //Cuarta(Periodo y lugar de pago)
        //Quinta(expensas, impuestos, servicio)
        //Sexta(Titularidad del servicio)
        //Septima(Mejoras y modificaciones)
        //Octava(Prohibiciones)
        //Novena(Responsabilidades)
        //Decima(Reparaciones)
        //Decima primera(Restitucion)
        //Decima segunda(fianza)

        [Required]
        public int Garante1 { get; set; }

        [Required]
        public int Garante2 { get; set; }

        //Decima tercera(Resolucion anticipada)
        //Decima cuarta (Renovacion)
        //Decima quinta (Falta de pago)
        //Decima sexta (Autorizacion para administacion)

        [Required]
        public int InmobiliariaId { get; set; }

        //Decima septima(domicilios)
        //Decima octava(juridiccion)
        //Decima novena(sellado)
        //Vigesima(firmas  e instrumentacion)

        //Vigesima primera(lugar y fecha)

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime AltaContrato { get; set; }

        [Required]
        [DisplayFormat(ApplyFormatInEditMode = true, DataFormatString = "{0:dd/MM/yyyy}")]
        public DateTime ClausuraContrato { get { return FinContrato(AltaContrato, PlazoContrato); } }

        public DateTime FinContrato(DateTime date, int plazo)
        {
            var fin = date.AddYears(+plazo);
            return fin;
        }

        [RegularExpression("(^[0-9]{4}-[0-9]{4}-[0-9]{4}-[0-9]{4}$)", ErrorMessage = "Solo se permiten números")]
        [Required(AllowEmptyStrings = false, ErrorMessage = "El número es obligatorio")]
        [StringLength(30, ErrorMessage = "El número es demasiado largo")]
        public string NumContrato { get; set; }

        [NotMapped]
        public string HelperGetDatos { get { return InquilinoId + " " + EdificioId + " " + DepartamentoId; } }

        //Get datos en Index

        public Propietario GetPropietario()
        {
            Propietario persona;
            using (var context = new Control_InmueblesContext())
            {
                persona = context.Propietario.Where(x => x.Id == PropietarioId).FirstOrDefault();
            }
            return persona;
        }
         public Inquilino GetInquilino()
        {
            Inquilino persona;
            using (var context = new Control_InmueblesContext())
            {
                persona = context.Inquilino.Where(x => x.Id == InquilinoId).FirstOrDefault();
            }
            return persona;
        }
         public Garante GetGarante1()
        {
            Garante persona;
            using (var context = new Control_InmueblesContext())
            {
                persona = context.Garante.Where(x => x.Id == Garante1).FirstOrDefault();
            }
            return persona;
        }
        public Garante GetGarante2()
        {
            Garante persona;
            using (var context = new Control_InmueblesContext())
            {
                persona = context.Garante.Where(x => x.Id == Garante2).FirstOrDefault();
            }
            return persona;
        }
        public Departamento GetEdificio()
        {
            Departamento ed;
            using (var context = new Control_InmueblesContext())
            {
                ed = context.Departamento.Where(x => x.Id == EdificioId).FirstOrDefault();
            }
            return ed;
        }
        public Departamento GetDepartamento()
        {
            Departamento ed;
            using (var context = new Control_InmueblesContext())
            {
                ed = context.Departamento.Where(x => x.Id == DepartamentoId).FirstOrDefault();
            }
            return ed;
        }
        public Inmobiliaria GetInmobiliaria()
        {
            Inmobiliaria ed;
            using (var context = new Control_InmueblesContext())
            {
                ed = context.Inmobiliaria.Where(x => x.Id == InmobiliariaId).FirstOrDefault();
            }
            return ed;
        }

        [NotMapped]
        public string NombreDepartamento { get { return GetInquilino().NombreCompleto + " " + GetDepartamento().DatosDepto; } }
         [NotMapped]
        public string NombreInquilino { get { return GetInquilino().NombreCompleto; } }
         [NotMapped]
        public string NombreDpto { get { return GetDepartamento().DatosDepto; } }
        
    }
}
