using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Control_Inmuebles.Data;
using Control_Inmuebles.Models.Inmuebles___Copia;

namespace Control_Inmuebles.Controllers.Inmuebles
{
    public class CocherasController : Controller
    {
        private readonly Control_InmueblesContext _context;

        public CocherasController(Control_InmueblesContext context)
        {
            _context = context;
        }

        // GET: Cocheras
        public async Task<IActionResult> Index()
        {
            return View(await _context.Cochera.ToListAsync());
        }

        // GET: Cocheras/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cochera = await _context.Cochera
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cochera == null)
            {
                return NotFound();
            }

            return View(cochera);
        }

        // GET: Cocheras/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Cocheras/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("NumCochera,Id,Direccion,Numero,Barrio")] Cochera cochera)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cochera);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cochera);
        }

        // GET: Cocheras/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cochera = await _context.Cochera.FindAsync(id);
            if (cochera == null)
            {
                return NotFound();
            }
            return View(cochera);
        }

        // POST: Cocheras/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("NumCochera,Id,Direccion,Numero,Barrio")] Cochera cochera)
        {
            if (id != cochera.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cochera);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CocheraExists(cochera.Id))
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
            return View(cochera);
        }

        // GET: Cocheras/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cochera = await _context.Cochera
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cochera == null)
            {
                return NotFound();
            }

            return View(cochera);
        }

        // POST: Cocheras/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cochera = await _context.Cochera.FindAsync(id);
            _context.Cochera.Remove(cochera);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CocheraExists(int id)
        {
            return _context.Cochera.Any(e => e.Id == id);
        }
    }
}
