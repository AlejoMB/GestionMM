using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Entities.Facturacion;

namespace Web.Controllers
{
    public class FactuEncController : Controller
    {
        private readonly GestionDbContext _context;

        public FactuEncController(GestionDbContext context)
        {
            _context = context;
        }

        // GET: FactuEnc
        public async Task<IActionResult> Index()
        {
            return View(await _context.FacturaEnc.ToListAsync());
        }

        // GET: FactuEnc/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaEnc = await _context.FacturaEnc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facturaEnc == null)
            {
                return NotFound();
            }

            return View(facturaEnc);
        }

        // GET: FactuEnc/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FactuEnc/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Total,NoGuia,FechaPago,CreadoPorUser,FechaCreado")] FacturaEnc facturaEnc)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturaEnc);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facturaEnc);
        }

        // GET: FactuEnc/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaEnc = await _context.FacturaEnc.FindAsync(id);
            if (facturaEnc == null)
            {
                return NotFound();
            }
            return View(facturaEnc);
        }

        // POST: FactuEnc/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Total,NoGuia,FechaPago,CreadoPorUser,FechaCreado")] FacturaEnc facturaEnc)
        {
            if (id != facturaEnc.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturaEnc);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaEncExists(facturaEnc.Id))
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
            return View(facturaEnc);
        }

        // GET: FactuEnc/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaEnc = await _context.FacturaEnc
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facturaEnc == null)
            {
                return NotFound();
            }

            return View(facturaEnc);
        }

        // POST: FactuEnc/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaEnc = await _context.FacturaEnc.FindAsync(id);
            if (facturaEnc != null)
            {
                _context.FacturaEnc.Remove(facturaEnc);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaEncExists(int id)
        {
            return _context.FacturaEnc.Any(e => e.Id == id);
        }
    }
}
