using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Control_Inmuebles.Data;
using Control_Inmuebles.Models.Servicios_Impuestos;

namespace Control_Inmuebles.Controllers.Servicios_Impuestos
{
    public class ImpuestosController : Controller
    {
        private readonly Control_InmueblesContext _context;

        public ImpuestosController(Control_InmueblesContext context)
        {
            _context = context;
        }

        // GET: Impuestos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Impuesto.ToListAsync());
        }

        // GET: Impuestos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impuesto = await _context.Impuesto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (impuesto == null)
            {
                return NotFound();
            }

            return View(impuesto);
        }

        // GET: Impuestos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Impuestos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("TipoImpuestoId,Id,Fecha,Periodo,Monto")] Impuesto impuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(impuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(impuesto);
        }

        // GET: Impuestos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impuesto = await _context.Impuesto.FindAsync(id);
            if (impuesto == null)
            {
                return NotFound();
            }
            return View(impuesto);
        }

        // POST: Impuestos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("TipoImpuestoId,Id,Fecha,Periodo,Monto")] Impuesto impuesto)
        {
            if (id != impuesto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(impuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!ImpuestoExists(impuesto.Id))
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
            return View(impuesto);
        }

        // GET: Impuestos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var impuesto = await _context.Impuesto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (impuesto == null)
            {
                return NotFound();
            }

            return View(impuesto);
        }

        // POST: Impuestos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var impuesto = await _context.Impuesto.FindAsync(id);
            _context.Impuesto.Remove(impuesto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool ImpuestoExists(int id)
        {
            return _context.Impuesto.Any(e => e.Id == id);
        }
    }
}
