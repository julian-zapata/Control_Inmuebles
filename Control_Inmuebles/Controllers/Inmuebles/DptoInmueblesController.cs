using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Control_Inmuebles.Data;
using Control_Inmuebles.Models.Inmuebles;
using Control_Inmuebles.Helpers;

namespace Control_Inmuebles.Controllers.Inmuebles
{
    public class DptoInmueblesController : Controller
    {
        private readonly Control_InmueblesContext _context;

        public DptoInmueblesController(Control_InmueblesContext context)
        {
            _context = context;
        }

        // GET: DptoInmuebles
        public async Task<IActionResult> Index()
        {
            return View(await _context.DptoInmueble.ToListAsync());
        }

        // GET: DptoInmuebles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dptoInmueble = await _context.DptoInmueble
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dptoInmueble == null)
            {
                return NotFound();
            }

            return View(dptoInmueble);
        }

        // GET: DptoInmuebles/Create
        public IActionResult Create()
        {
            ViewBag.ListaDirecInmueble = HGetListas.GetDirecInmuebleSelectList();
            ViewBag.ListaPisoInmueble = HGetListas.GetPisoSelectList();
            return View();
        }

        // POST: DptoInmuebles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("PisoInmuebleId,BaseInmuebleId,Id,Descripcion")] DptoInmueble dptoInmueble)
        {
            if (ModelState.IsValid)
            {
                _context.Add(dptoInmueble);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(dptoInmueble);
        }

        // GET: DptoInmuebles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.ListaDirecInmueble = HGetListas.GetDirecInmuebleSelectList();
            ViewBag.ListaPisoInmueble = HGetListas.GetPisoSelectList();

            if (id == null)
            {
                return NotFound();
            }

            var dptoInmueble = await _context.DptoInmueble.FindAsync(id);
            if (dptoInmueble == null)
            {
                return NotFound();
            }
            return View(dptoInmueble);
        }

        // POST: DptoInmuebles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("PisoInmuebleId,BaseInmuebleId,Id,Descripcion")] DptoInmueble dptoInmueble)
        {
            if (id != dptoInmueble.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(dptoInmueble);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!DptoInmuebleExists(dptoInmueble.Id))
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
            return View(dptoInmueble);
        }

        // GET: DptoInmuebles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var dptoInmueble = await _context.DptoInmueble
                .FirstOrDefaultAsync(m => m.Id == id);
            if (dptoInmueble == null)
            {
                return NotFound();
            }

            return View(dptoInmueble);
        }

        // POST: DptoInmuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var dptoInmueble = await _context.DptoInmueble.FindAsync(id);
            _context.DptoInmueble.Remove(dptoInmueble);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool DptoInmuebleExists(int id)
        {
            return _context.DptoInmueble.Any(e => e.Id == id);
        }
        
    }
}
