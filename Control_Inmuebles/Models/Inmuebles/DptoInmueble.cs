﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Models.Inmuebles
{
    public class DptoInmueble : Tipo
    {
        [Required]
        public int BaseInmuebleId { get; set; }
    }
}
