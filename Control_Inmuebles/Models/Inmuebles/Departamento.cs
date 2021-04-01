using Control_Inmuebles.Data;
using Control_Inmuebles.Models.Inmuebles;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Inmuebles___Copia
{
    public class Departamento
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int EdificioId { get; set; }

        [Required]
        public string Piso { get; set; }

        [Required]
        public string Dpto { get; set; }

        [Required]
        public string Ambientes { get; set; }

        public string Observacion { get; set; }

        public Edificio GetEdificio()
        {
            Edificio edificio;
            using( var context = new Control_InmueblesContext())
            {
                edificio = context.Edificio.Where(x => x.Id == EdificioId).FirstOrDefault();
            }
            return edificio;
        }
    }
}
