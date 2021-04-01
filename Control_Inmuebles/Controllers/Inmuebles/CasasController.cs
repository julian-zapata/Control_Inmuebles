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
    public class CasasController : Controller
    {
        private readonly Control_InmueblesContext _context;

        public CasasController(Control_InmueblesContext context)
        {
            _context = context;
        }

        // GET: Casas
        public async Task<IActionResult> Index()
        {
            return View(await _context.Casa.ToListAsync());
        }

        // GET: Casas/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casa = await _context.Casa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casa == null)
            {
                return NotFound();
            }

            return View(casa);
        }

        // GET: Casas/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Casas/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Descripcion,Observacion,Id,Direccion,Numero,Barrio")] Casa casa)
        {
            if (ModelState.IsValid)
            {
                _context.Add(casa);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(casa);
        }

        // GET: Casas/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casa = await _context.Casa.FindAsync(id);
            if (casa == null)
            {
                return NotFound();
            }
            return View(casa);
        }

        // POST: Casas/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Descripcion,Observacion,Id,Direccion,Numero,Barrio")] Casa casa)
        {
            if (id != casa.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(casa);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CasaExists(casa.Id))
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
            return View(casa);
        }

        // GET: Casas/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var casa = await _context.Casa
                .FirstOrDefaultAsync(m => m.Id == id);
            if (casa == null)
            {
                return NotFound();
            }

            return View(casa);
        }

        // POST: Casas/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var casa = await _context.Casa.FindAsync(id);
            _context.Casa.Remove(casa);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CasaExists(int id)
        {
            return _context.Casa.Any(e => e.Id == id);
        }
    }
}
