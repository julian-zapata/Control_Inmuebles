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
    public class ContratoDepartamentosController : Controller
    {
        private readonly Control_InmueblesContext _context;


        public ContratoDepartamentosController(Control_InmueblesContext context)
        {
            _context = context;
        }

        // GET: ContratoDepartamentos
        public async Task<IActionResult> Index()
        {
            return View(await _context.ContratoDepartamento.ToListAsync());
        }

        // GET: ContratoDepartamentos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoDepartamento = await _context.ContratoDepartamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contratoDepartamento == null)
            {
                return NotFound();
            }

            return View(contratoDepartamento);
        }

        // GET: ContratoDepartamentos/Create
        public IActionResult Create()
        {
            ViewBag.Propietarios = HGetListas.GetListaPropietarios();
            ViewBag.Inquilinos = HGetListas.GetListaInquilinos();
            ViewBag.Garantes = HGetListas.GetListaGarantes();
            ViewBag.Depto = HGetListas.GetListaDpto();
            ViewBag.Inmobiliaria = HGetListas.GetListaInmobiliarias();
            return View();
        }

        // POST: ContratoDepartamentos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PropietarioId,InquilinoId,DepartamentoId,PlazoContrato,CuotaMensualPrimerAño,Garante1,Garante2,InmobiliariaId,AltaContrato,NumContrato,EdificioId")] ContratoDepartamento contratoDepartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(contratoDepartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(contratoDepartamento);
        }

        // GET: ContratoDepartamentos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.Propietarios = HGetListas.GetListaPropietarios();
            ViewBag.Inquilinos = HGetListas.GetListaInquilinos();
            ViewBag.Garantes = HGetListas.GetListaGarantes();
            ViewBag.Depto = HGetListas.GetListaDpto();
            ViewBag.Inmobiliaria = HGetListas.GetListaInmobiliarias();

            if (id == null)
            {
                return NotFound();
            }

            var contratoDepartamento = await _context.ContratoDepartamento.FindAsync(id);
            if (contratoDepartamento == null)
            {
                return NotFound();
            }
            return View(contratoDepartamento);
        }

        // POST: ContratoDepartamentos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PropietarioId,InquilinoId,DepartamentoId,PlazoContrato,CuotaMensualPrimerAño,Garante1,Garante2,InmobiliariaId,AltaContrato,NumContrato,EdificioId")] ContratoDepartamento contratoDepartamento)
        {
            if (id != contratoDepartamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(contratoDepartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ContratoDepartamentoExists(contratoDepartamento.Id))
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
            return View(contratoDepartamento);
        }

        // GET: ContratoDepartamentos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var contratoDepartamento = await _context.ContratoDepartamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (contratoDepartamento == null)
            {
                return NotFound();
            }

            return View(contratoDepartamento);
        }

        // POST: ContratoDepartamentos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var contratoDepartamento = await _context.ContratoDepartamento.FindAsync(id);
            _context.ContratoDepartamento.Remove(contratoDepartamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ContratoDepartamentoExists(int id)
        {
            return _context.ContratoDepartamento.Any(e => e.Id == id);
        }
    }
}
