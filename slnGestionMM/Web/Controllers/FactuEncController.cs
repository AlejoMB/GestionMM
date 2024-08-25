using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Entities.Facturacion;
using Domain.Models.FactuEnc;
using Domain.Models.Informes;

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
            ConstruirAnos();

            var model = new FactuEncModel();
            model.Facutras = new List<FacturaEnc>();
            //model.Facutras = await _context.FacturaEnc.ToListAsync();

            return View(model);
        }

        [HttpPost]
        public IActionResult Index(FactuEncModel model)
        {
            ConstruirAnos();

            model.Facutras = new List<FacturaEnc>();

            if (!string.IsNullOrEmpty(model.Mes) && !string.IsNullOrEmpty(model.Ano))
            {
                var mes = int.Parse(model.Mes);
                var ano = int.Parse(model.Ano);
                IQueryable<FacturaEnc> query = _context.FacturaEnc.Where(f => f.FechaCreado.Month == mes && f.FechaCreado.Year == ano);

                if(!string.IsNullOrEmpty(model.NoFactura))
                {
                    var noFactu = int.Parse(model.NoFactura);
                    query = query.Where(f => f.Id == noFactu);
                }
                model.Facutras = query.ToList();
            }

            

            return View(model);
        }

        private void ConstruirAnos()
        {
            var anoInicial = 2024;

            var listaAnos = new List<SelectListItem>();
            for (int year = anoInicial; year <= DateTime.Now.Year; year++)
            {
                listaAnos.Add(new SelectListItem { Value = $"{year}", Text = $"{year}" });
            }
            ViewBag.DropDownOptions = listaAnos;
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
            var detalles = _context.FacturaDetalle.Include(det => det.Media).Where(det => det.Encabezado.Id == id).ToList();
            if (facturaEnc != null)
            {
                foreach(var detalle in detalles)
                {
                    var existencia = _context.Existencias.FirstOrDefault(e => e.MediaRef == detalle.Media.Id);
                    if (existencia != null)
                    {
                        existencia.CantidadProducto += detalle.Cantidad;
                        _context.Update(existencia);
                    }
                }

                _context.FacturaDetalle.RemoveRange(detalles);

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
