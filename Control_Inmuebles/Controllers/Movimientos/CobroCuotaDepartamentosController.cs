using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Control_Inmuebles.Data;
using Control_Inmuebles.Models.Movimientos;

namespace Control_Inmuebles.Controllers.Movimientos
{
    public class CobroCuotaDepartamentosController : Controller
    {
        private readonly Control_InmueblesContext _context;

        public CobroCuotaDepartamentosController(Control_InmueblesContext context)
        {
            _context = context;
        }

        // GET: CobroCuotaDepartamentoes
        public async Task<IActionResult> Index()
        {
            return View(await _context.CobroCuotaDepartamento.ToListAsync());
        }

        // GET: CobroCuotaDepartamentoes/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobroCuotaDepartamento = await _context.CobroCuotaDepartamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobroCuotaDepartamento == null)
            {
                return NotFound();
            }

            return View(cobroCuotaDepartamento);
        }

        // GET: CobroCuotaDepartamentoes/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: CobroCuotaDepartamentoes/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,FechaCobro,InquilinoId,ContratoDepartamento,Edificio,Piso,dpto,CoutaAlquiler,CuotaAgua,CoutaMunicipal,CoutaRentas,MotivoBaja,FechaBajaAnticipoContrato,AlquileresAdeudados")] CobroCuotaDepartamento cobroCuotaDepartamento)
        {
            if (ModelState.IsValid)
            {
                _context.Add(cobroCuotaDepartamento);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(cobroCuotaDepartamento);
        }

        // GET: CobroCuotaDepartamentoes/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobroCuotaDepartamento = await _context.CobroCuotaDepartamento.FindAsync(id);
            if (cobroCuotaDepartamento == null)
            {
                return NotFound();
            }
            return View(cobroCuotaDepartamento);
        }

        // POST: CobroCuotaDepartamentoes/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for 
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,FechaCobro,InquilinoId,ContratoDepartamento,Edificio,Piso,dpto,CoutaAlquiler,CuotaAgua,CoutaMunicipal,CoutaRentas,MotivoBaja,FechaBajaAnticipoContrato,AlquileresAdeudados")] CobroCuotaDepartamento cobroCuotaDepartamento)
        {
            if (id != cobroCuotaDepartamento.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(cobroCuotaDepartamento);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!CobroCuotaDepartamentoExists(cobroCuotaDepartamento.Id))
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
            return View(cobroCuotaDepartamento);
        }

        // GET: CobroCuotaDepartamentoes/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var cobroCuotaDepartamento = await _context.CobroCuotaDepartamento
                .FirstOrDefaultAsync(m => m.Id == id);
            if (cobroCuotaDepartamento == null)
            {
                return NotFound();
            }

            return View(cobroCuotaDepartamento);
        }

        // POST: CobroCuotaDepartamentoes/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var cobroCuotaDepartamento = await _context.CobroCuotaDepartamento.FindAsync(id);
            _context.CobroCuotaDepartamento.Remove(cobroCuotaDepartamento);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool CobroCuotaDepartamentoExists(int id)
        {
            return _context.CobroCuotaDepartamento.Any(e => e.Id == id);
        }
    }
}
