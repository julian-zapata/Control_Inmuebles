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
    public class PisoInmueblesController : Controller
    {
        private readonly Control_InmueblesContext _context;

        public PisoInmueblesController(Control_InmueblesContext context)
        {
            _context = context;
        }

        // GET: PisoInmuebles
        public async Task<IActionResult> Index()
        {
            return View(await _context.PisoInmueble.ToListAsync());
        }

        // GET: PisoInmuebles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pisoInmueble = await _context.PisoInmueble
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pisoInmueble == null)
            {
                return NotFound();
            }

            return View(pisoInmueble);
        }

        // GET: PisoInmuebles/Create
        public IActionResult Create()
        {
            ViewBag.ListaTipoInmueble = HGetListas.GetBaseInmuebleSelectList();
            ViewBag.ListaDirecInmueble = HGetListas.GetDirecInmuebleSelectList();
            return View();
        }

        // POST: PisoInmuebles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("BaseInmuebleId,Id,Descripcion,TipoInmuebleId")] PisoInmueble pisoInmueble)
        {
            if (ModelState.IsValid)
            {
                _context.Add(pisoInmueble);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(pisoInmueble);
        }

        // GET: PisoInmuebles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.ListaTipoInmueble = HGetListas.GetBaseInmuebleSelectList();
            ViewBag.ListaDirecInmueble = HGetListas.GetDirecInmuebleSelectList();

            if (id == null)
            {
                return NotFound();
            }

            var pisoInmueble = await _context.PisoInmueble.FindAsync(id);
            if (pisoInmueble == null)
            {
                return NotFound();
            }
            return View(pisoInmueble);
        }

        // POST: PisoInmuebles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("BaseInmuebleId,Id,Descripcion,TipoInmuebleId")] PisoInmueble pisoInmueble)
        {
            if (id != pisoInmueble.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(pisoInmueble);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!PisoInmuebleExists(pisoInmueble.Id))
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
            return View(pisoInmueble);
        }

        // GET: PisoInmuebles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var pisoInmueble = await _context.PisoInmueble
                .FirstOrDefaultAsync(m => m.Id == id);
            if (pisoInmueble == null)
            {
                return NotFound();
            }

            return View(pisoInmueble);
        }

        // POST: PisoInmuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var pisoInmueble = await _context.PisoInmueble.FindAsync(id);
            _context.PisoInmueble.Remove(pisoInmueble);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool PisoInmuebleExists(int id)
        {
            return _context.PisoInmueble.Any(e => e.Id == id);
        }

        public JsonResult GetPisos(int baseId)
        {
            var pisos = _context.PisoInmueble.Where(x => x.BaseInmuebleId == baseId).ToList();

            return Json(pisos);
        }
    }
}
