using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Control_Inmuebles.Data;
using Control_Inmuebles.Models;

namespace Control_Inmuebles.Controllers.Inmuebles
{
    public class TipoInmueblesController : Controller
    {
        private readonly Control_InmueblesContext _context;

        public TipoInmueblesController(Control_InmueblesContext context)
        {
            _context = context;
        }

        // GET: TipoInmuebles
        public async Task<IActionResult> Index()
        {
            return View(await _context.TipoInmueble.ToListAsync());
        }

        // GET: TipoInmuebles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInmueble = await _context.TipoInmueble
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoInmueble == null)
            {
                return NotFound();
            }

            return View(tipoInmueble);
        }

        // GET: TipoInmuebles/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: TipoInmuebles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Descripcion")] TipoInmueble tipoInmueble)
        {
            if (ModelState.IsValid)
            {
                _context.Add(tipoInmueble);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(tipoInmueble);
        }

        // GET: TipoInmuebles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInmueble = await _context.TipoInmueble.FindAsync(id);
            if (tipoInmueble == null)
            {
                return NotFound();
            }
            return View(tipoInmueble);
        }

        // POST: TipoInmuebles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Descripcion")] TipoInmueble tipoInmueble)
        {
            if (id != tipoInmueble.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(tipoInmueble);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!TipoInmuebleExists(tipoInmueble.Id))
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
            return View(tipoInmueble);
        }

        // GET: TipoInmuebles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var tipoInmueble = await _context.TipoInmueble
                .FirstOrDefaultAsync(m => m.Id == id);
            if (tipoInmueble == null)
            {
                return NotFound();
            }

            return View(tipoInmueble);
        }

        // POST: TipoInmuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var tipoInmueble = await _context.TipoInmueble.FindAsync(id);
            _context.TipoInmueble.Remove(tipoInmueble);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool TipoInmuebleExists(int id)
        {
            return _context.TipoInmueble.Any(e => e.Id == id);
        }
    }
}
