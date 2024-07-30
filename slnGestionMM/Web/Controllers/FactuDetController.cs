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
    public class FactuDetController : Controller
    {
        private readonly GestionDbContext _context;

        public FactuDetController(GestionDbContext context)
        {
            _context = context;
        }

        // GET: FactuDet
        public async Task<IActionResult> Index(string id)
        {
            if (!string.IsNullOrEmpty(id))
            {
                var idDetalle = int.Parse(id);
                return View(_context.FacturaDetalle.Include(f => f.Encabezado).Include(f => f.Media).Where(x => x.Encabezado.Id == idDetalle));
            }
            else
            {
                return View(await _context.FacturaDetalle.Include(f => f.Encabezado).Include(f => f.Media).ToListAsync());
            }
        }

        // GET: FactuDet/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalle = await _context.FacturaDetalle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facturaDetalle == null)
            {
                return NotFound();
            }

            return View(facturaDetalle);
        }

        // GET: FactuDet/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: FactuDet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PrecioUnitario,Cantidad,Total")] FacturaDetalle facturaDetalle)
        {
            if (ModelState.IsValid)
            {
                _context.Add(facturaDetalle);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(facturaDetalle);
        }

        // GET: FactuDet/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalle = _context.FacturaDetalle.Include(f => f.Encabezado).Include(f => f.Media).FirstOrDefault(f => f.Id == id);
            if (facturaDetalle == null)
            {
                return NotFound();
            }
            return View(facturaDetalle);
        }

        // POST: FactuDet/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,PrecioUnitario,Cantidad,Total")] FacturaDetalle facturaDetalle)
        {
            if (id != facturaDetalle.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(facturaDetalle);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!FacturaDetalleExists(facturaDetalle.Id))
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
            return View(facturaDetalle);
        }

        // GET: FactuDet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalle = await _context.FacturaDetalle
                .FirstOrDefaultAsync(m => m.Id == id);
            if (facturaDetalle == null)
            {
                return NotFound();
            }

            return View(facturaDetalle);
        }

        // POST: FactuDet/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var facturaDetalle = await _context.FacturaDetalle.FindAsync(id);
            if (facturaDetalle != null)
            {
                _context.FacturaDetalle.Remove(facturaDetalle);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool FacturaDetalleExists(int id)
        {
            return _context.FacturaDetalle.Any(e => e.Id == id);
        }
    }
}
