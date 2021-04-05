﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Vinculos
{
    public class Inmobiliaria: Tipo
    {
        [Required]
        [Column(TypeName = "decimal(18,4)")]
        public decimal Honorarios { get; set; }
    }
}
