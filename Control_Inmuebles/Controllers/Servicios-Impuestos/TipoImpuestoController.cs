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
    public class TipoImpuestoController : Controller
    {
        private readonly Control_InmueblesContext _context;

        public TipoImpuestoController(Control_InmueblesContext context)
        {
            _context = context;
        }

        // GET: TipoImpuesto
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoImpuesto.ToListAsync());
        }

        // GET: TipoImpuesto/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoImpuesto = await _context.TipoImpuesto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoImpuesto == null)
            {
                return NotFound();
            }

            return View(tipoImpuesto);
        }

        // GET: TipoImpuesto/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoImpuesto/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] TipoImpuesto tipoImpuesto)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoImpuesto);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoImpuesto);
        }

        // GET: TipoImpuesto/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoImpuesto = await _context.TipoImpuesto.FindAsync(id);
            if (tipoImpuesto == null)
            {
                return NotFound();
            }
            return View(tipoImpuesto);
        }

        // POST: TipoImpuesto/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] TipoImpuesto tipoImpuesto)
        {
            if (id != tipoImpuesto.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoImpuesto);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoImpuestoExists(tipoImpuesto.Id))
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
            return View(tipoImpuesto);
        }

        // GET: TipoImpuesto/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoImpuesto = await _context.TipoImpuesto
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoImpuesto == null)
            {
                return NotFound();
            }

            return View(tipoImpuesto);
        }

        // POST: TipoImpuesto/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoImpuesto = await _context.TipoImpuesto.FindAsync(id);
            _context.TipoImpuesto.Remove(tipoImpuesto);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoImpuestoExists(int id)
        {
            return _context.TipoImpuesto.Any(e => e.Id == id);
        }
    }
}
