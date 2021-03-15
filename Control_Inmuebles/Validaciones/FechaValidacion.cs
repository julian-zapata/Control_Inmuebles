using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Validaciones
{
    public class FechaValidacion
    {
        public class ValidMinFechaImpServ : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                var fechaMinImpServ = DateTime.Now.AddMonths(-1);

                if ((DateTime)value < fechaMinImpServ)
                {
                    return false;
                }
                return true;
            }
        }

        public class ValidMaxFechaImpServ : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                var fechaMinImpServ = DateTime.Now;

                if ((DateTime)value < fechaMinImpServ)
                {
                    return false;
                }
                return true;
            }
        }

        public class ValidMayor18 : ValidationAttribute
        {
            public override bool IsValid(object value)
            {
                var fechaMinEdad = DateTime.Now.AddYears(-18);

                if ((DateTime)value < fechaMinEdad)
                {
                    return false;
                }
                return true;
            }
        }

    }
}
