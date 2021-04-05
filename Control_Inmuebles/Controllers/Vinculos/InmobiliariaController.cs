using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Control_Inmuebles.Data;
using Control_Inmuebles.Models.Vinculos;

namespace Control_Inmuebles.Controllers.Vinculos
{
    public class InmobiliariaController : Controller
    {
        private readonly Control_InmueblesContext _context;

        public InmobiliariaController(Control_InmueblesContext context)
        {
            _context = context;
        }

        // GET: Inmobiliaria
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inmobiliaria.ToListAsync());
        }

        // GET: Inmobiliaria/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inmobiliaria = await _context.Inmobiliaria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inmobiliaria == null)
            {
                return NotFound();
            }

            return View(inmobiliaria);
        }

        // GET: Inmobiliaria/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inmobiliaria/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Honorarios,Id,Descripcion")] Inmobiliaria inmobiliaria)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inmobiliaria);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inmobiliaria);
        }

        // GET: Inmobiliaria/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inmobiliaria = await _context.Inmobiliaria.FindAsync(id);
            if (inmobiliaria == null)
            {
                return NotFound();
            }
            return View(inmobiliaria);
        }

        // POST: Inmobiliaria/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Honorarios,Id,Descripcion")] Inmobiliaria inmobiliaria)
        {
            if (id != inmobiliaria.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inmobiliaria);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InmobiliariaExists(inmobiliaria.Id))
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
            return View(inmobiliaria);
        }

        // GET: Inmobiliaria/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inmobiliaria = await _context.Inmobiliaria
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inmobiliaria == null)
            {
                return NotFound();
            }

            return View(inmobiliaria);
        }

        // POST: Inmobiliaria/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inmobiliaria = await _context.Inmobiliaria.FindAsync(id);
            _context.Inmobiliaria.Remove(inmobiliaria);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InmobiliariaExists(int id)
        {
            return _context.Inmobiliaria.Any(e => e.Id == id);
        }
    }
}
