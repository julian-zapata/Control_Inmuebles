using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Control_Inmuebles.Data;
using Control_Inmuebles.Models.Personas;

namespace Control_Inmuebles.Controllers
{
    public class InquilinosController : Controller
    {
        private readonly Control_InmueblesContext _context;

        public InquilinosController(Control_InmueblesContext context)
        {
            _context = context;
        }

        // GET: Inquilinos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Inquilino.ToListAsync());
        }

        // GET: Inquilinos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquilino = await _context.Inquilino
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inquilino == null)
            {
                return NotFound();
            }

            return View(inquilino);
        }

        // GET: Inquilinos/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Inquilinos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Nombre,Apellido,Dni,Domicilio,Numero,Piso,Departamento,Barrio,Ciudad,Provincia,Email, Nota")] Inquilino inquilino)
        {
            if (ModelState.IsValid)
            {
                _context.Add(inquilino);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(inquilino);
        }

        // GET: Inquilinos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquilino = await _context.Inquilino.FindAsync(id);
            if (inquilino == null)
            {
                return NotFound();
            }
            return View(inquilino);
        }

        // POST: Inquilinos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Nombre,Apellido,Dni,Domicilio,Numero,Piso,Departamento,Barrio,Ciudad,Provincia,Email,Nota")] Inquilino inquilino)
        {
            if (id != inquilino.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(inquilino);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!InquilinoExists(inquilino.Id))
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
            return View(inquilino);
        }

        // GET: Inquilinos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var inquilino = await _context.Inquilino
                .FirstOrDefaultAsync(m => m.Id == id);
            if (inquilino == null)
            {
                return NotFound();
            }

            return View(inquilino);
        }

        // POST: Inquilinos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var inquilino = await _context.Inquilino.FindAsync(id);
            _context.Inquilino.Remove(inquilino);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool InquilinoExists(int id)
        {
            return _context.Inquilino.Any(e => e.Id == id);
        }

        public JsonResult GetInquilinos(int InquilinoId)
        {
            var inq = _context.Inquilino.Where(x => x.Id == InquilinoId).ToList();

            return Json(inq);
        }

    }
}
