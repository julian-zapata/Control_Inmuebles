using Control_Inmuebles.Data;
using Microsoft.AspNetCore.Mvc.Rendering;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Control_Inmuebles.Helpers
{
    public static class HGetListas
    {
        private static Control_InmueblesContext _context = new Control_InmueblesContext();

        public static SelectList GetPaisesSelectList()
        {
            var lstPaises = _context.Pais.ToList();
            var SelectListPaises = new SelectList(lstPaises, "Id", "Descripcion");
            return SelectListPaises;
        }

        public static SelectList GetProvinciasSelectList()
        {
            var lstProvincias = _context.Provincia.ToList();
            var SelectListProvincias = new SelectList(lstProvincias, "Id", "Descripcion");
            return SelectListProvincias;
        }

        public static SelectList GetTipoInmuebleSelectList()
        {
            var listaTipoInmuebles = _context.TipoInmueble.ToList();
            var SelectListTipoInmueble = new SelectList(listaTipoInmuebles, "Id", "Descripcion");
            return SelectListTipoInmueble;
        }

        public static SelectList GetBaseInmuebleSelectList()
        {
            var listaBaseInmueble = _context.TipoInmueble.ToList();
            var SelectListBaseInmueble = new SelectList(listaBaseInmueble, "Id", "Descripcion", "Numero");
            return SelectListBaseInmueble;
        }
    }
}
