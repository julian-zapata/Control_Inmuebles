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
    public class BaseInmueblesController : Controller
    {
        
        private readonly Control_InmueblesContext _context;

        public BaseInmueblesController(Control_InmueblesContext context)
        {
            _context = context;
        }

        // GET: BaseInmuebles
        public async Task<IActionResult> Index()
        {
            return View(await _context.BaseInmueble.ToListAsync());
        }

        // GET: BaseInmuebles/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseInmueble = await _context.BaseInmueble
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseInmueble == null)
            {
                return NotFound();
            }

            return View(baseInmueble);
        }

        // GET: BaseInmuebles/Create
        public IActionResult Create()
        {
            ViewBag.ListaTipoInmueble = HGetListas.GetTipoInmuebleSelectList();
            return View();
        }

        // POST: BaseInmuebles/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,TipoInmuebleId,Direccion,Numero")] BaseInmueble baseInmueble)
        {
            if (ModelState.IsValid)
            {
                _context.Add(baseInmueble);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(baseInmueble);
        }

        // GET: BaseInmuebles/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            ViewBag.ListaTipoInmueble = HGetListas.GetTipoInmuebleSelectList();

            if (id == null)
            {
                return NotFound();
            }

            var baseInmueble = await _context.BaseInmueble.FindAsync(id);
            if (baseInmueble == null)
            {
                return NotFound();
            }
            return View(baseInmueble);
        }

        // POST: BaseInmuebles/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,TipoInmuebleId,Direccion,Numero")] BaseInmueble baseInmueble)
        {
            if (id != baseInmueble.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(baseInmueble);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!BaseInmuebleExists(baseInmueble.Id))
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
            return View(baseInmueble);
        }

        // GET: BaseInmuebles/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var baseInmueble = await _context.BaseInmueble
                .FirstOrDefaultAsync(m => m.Id == id);
            if (baseInmueble == null)
            {
                return NotFound();
            }

            return View(baseInmueble);
        }

        // POST: BaseInmuebles/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var baseInmueble = await _context.BaseInmueble.FindAsync(id);
            _context.BaseInmueble.Remove(baseInmueble);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool BaseInmuebleExists(int id)
        {
            return _context.BaseInmueble.Any(e => e.Id == id);
        }
    }
}
