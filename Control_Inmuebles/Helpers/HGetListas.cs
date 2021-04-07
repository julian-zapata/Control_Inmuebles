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

        //public static SelectList GetPaisesSelectList()
        //{
        //    var lstPaises = _context.Pais.ToList();
        //    var SelectListPaises = new SelectList(lstPaises, "Id", "Descripcion");
        //    return SelectListPaises;
        //}

        //public static SelectList GetProvinciasSelectList()
        //{
        //    var lstProvincias = _context.Provincia.ToList();
        //    var SelectListProvincias = new SelectList(lstProvincias, "Id", "Descripcion");
        //    return SelectListProvincias;
        //}

        public static SelectList GetListaInquilinos()
        {
            var lista = _context.Inquilino.ToList();
            var select = new SelectList(lista, "Id", "NombreCompleto");
            return select;
        }
         public static SelectList GetListaPropietarios()
        {
            var lista = _context.Propietario.ToList();
            var select = new SelectList(lista, "Id", "NombreCompleto");
            return select;
        }
         public static SelectList GetListaGarantes()
        {
            var lista = _context.Garante.ToList();
            var select = new SelectList(lista, "Id", "NombreCompleto");
            return select;
        }
        // public static SelectList GetListaDptoPiso()
        //{
        //    var lista = _context.Departamento.ToList();
        //    var select = new SelectList(lista, "Id", "Piso");
        //    return select;
        //}
        public static SelectList GetListaDpto()
        {
            var lista = _context.Departamento.ToList();
            var select = new SelectList(lista, "Id", "DatosDepto");
            return select;
        }

        public static SelectList GetListaInmobiliarias()
        {
            var lst = _context.Inmobiliaria.ToList();
            var lstInmobiliaria = new SelectList(lst, "Id", "Descripcion");
            return lstInmobiliaria;
        }

        //public static SelectList GetListaCocheras()
        //{
        //    var lista = _context.Cochera.ToList();
        //    var select = new SelectList(lista, "Id", "Apellido");
        //    return select;
        //}
        // public static SelectList GetListaCasas()
        //{
        //    var lista = _context.Casa.ToList();
        //    var select = new SelectList(lista, "Id", "Apellido");
        //    return select;
        //}

        public static SelectList GetListaEdificios()
        {
            var lista = _context.Edificio.ToList();
            var select = new SelectList(lista, "Id", "Direccion");
            return select;
        }

        public static SelectList GetListaContrato()
        {
            var lista = _context.ContratoDepartamento.ToList();
            var select = new SelectList(lista, "Id", "NombreDepartamento");
            return select;
        }

        public static SelectList GetListaAlquileres()
        {
            var lista = _context.Alquiler.ToList();
            var select = new SelectList(lista, "Id", "DatosInquilinosDepto");
            return select;
        }

    }
}
