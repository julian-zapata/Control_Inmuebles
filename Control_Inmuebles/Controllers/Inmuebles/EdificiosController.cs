using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Control_Inmuebles.Data;
using Control_Inmuebles.Models.Inmuebles;

namespace Control_Inmuebles.Controllers.Inmuebles
{
    public class EdificiosController : Controller
    {
        private readonly Control_InmueblesContext _context;

        public EdificiosController(Control_InmueblesContext context)
        {
            _context = context;
        }

        // GET: Edificios
        public async Task<IActionResult> Index()
        {
            return View(await _context.Edificio.ToListAsync());
        }

        // GET: Edificios/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edificio = await _context.Edificio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (edificio == null)
            {
                return NotFound();
            }

            return View(edificio);
        }

        // GET: Edificios/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Edificios/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Direccion,Numero,Barrio")] Edificio edificio)
        {
            if (ModelState.IsValid)
            {
                _context.Add(edificio);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(edificio);
        }

        // GET: Edificios/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edificio = await _context.Edificio.FindAsync(id);
            if (edificio == null)
            {
                return NotFound();
            }
            return View(edificio);
        }

        // POST: Edificios/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Direccion,Numero,Barrio")] Edificio edificio)
        {
            if (id != edificio.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(edificio);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!EdificioExists(edificio.Id))
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
            return View(edificio);
        }

        // GET: Edificios/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var edificio = await _context.Edificio
                .FirstOrDefaultAsync(m => m.Id == id);
            if (edificio == null)
            {
                return NotFound();
            }

            return View(edificio);
        }

        // POST: Edificios/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var edificio = await _context.Edificio.FindAsync(id);
            _context.Edificio.Remove(edificio);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool EdificioExists(int id)
        {
            return _context.Edificio.Any(e => e.Id == id);
        }
    }
}
