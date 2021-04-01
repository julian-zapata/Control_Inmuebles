using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Control_Inmuebles.Data;
using Control_Inmuebles.Models.Vinculos;
using Control_Inmuebles.Helpers;

namespace Control_Inmuebles.Controllers.Vinculos
{
    public class ContratosController : Controller
    {
        private readonly Control_InmueblesContext _context;

        public ContratosController(Control_InmueblesContext context)
        {
            _context = context;
        }

        // GET: Contratos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Contrato.ToListAsync());
        }

        // GET: Contratos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contrato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // GET: Contratos/Create
        public IActionResult Create()
        {
            ViewBag.ListaInquilino = HGetListas.GetListaInquilinos();
            ViewBag.ListaPropietario = HGetListas.GetListaPropietarios();
            ViewBag.ListaGarante = HGetListas.GetListaGarantes();
            ViewBag.ListaEdificios = HGetListas.GetListaEdificios();
            ViewBag.ListaCasa = HGetListas.GetListaCasas();
            ViewBag.ListaCochera = HGetListas.GetListaCocheras();
            return View();
        }

        // POST: Contratos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,AltaContrato,PlazoContrato,ClausuraContrato,PropietarioId,InquilinoId,Inmueble,ValorContrato,Garante1,Garante2,CasaId,CocheraId,DepartamentoId")] Contrato contrato)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contrato);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contrato);
        }

        // GET: Contratos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.ListaInquilino = HGetListas.GetListaInquilinos();
            ViewBag.ListaPropietario = HGetListas.GetListaPropietarios();
            ViewBag.ListaGarante = HGetListas.GetListaGarantes();
            ViewBag.ListEdificios = HGetListas.GetListaEdificios();
            ViewBag.ListaCasa = HGetListas.GetListaCasas();
            ViewBag.ListaCochera = HGetListas.GetListaCocheras();

            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contrato.FindAsync(id);
            if (contrato == null)
            {
                return NotFound();
            }
            return View(contrato);
        }

        // POST: Contratos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,AltaContrato,PlazoContrato,ClausuraContrato,PropietarioId,InquilinoId,Inmueble,ValorContrato,Garante1,Garante2,CasaId,CocheraId,DepartamentoId")] Contrato contrato)
        {
            if (id != contrato.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contrato);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoExists(contrato.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            return View(contrato);
        }

        // GET: Contratos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contrato = await _context.Contrato
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contrato == null)
            {
                return NotFound();
            }

            return View(contrato);
        }

        // POST: Contratos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contrato = await _context.Contrato.FindAsync(id);
            _context.Contrato.Remove(contrato);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoExists(int id)
        {
            return _context.Contrato.Any(e => e.Id == id);
        }
    }
}
