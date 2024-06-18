using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Entities.Gastos;
using Microsoft.AspNetCore.Authorization;

namespace Web.Controllers
{
    [Authorize(Roles = "Administrador")]
    public class GastosController : Controller
    {
        private readonly GestionDbContext _context;

        public GastosController(GestionDbContext context)
        {
            _context = context;
        }

        // GET: Gastos
        public async Task<IActionResult> Index()
        {
            return View(await _context.Gastos.Include(x => x.TipoGasto)
                .AsNoTracking().ToListAsync());
        }

        // GET: Gastos/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastos = await _context.Gastos
                .Include(x => x.TipoGasto)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gastos == null)
            {
                return NotFound();
            }

            return View(gastos);
        }

        // GET: Gastos/Create
        public IActionResult Create()
        {
            PopulateDepartmentsDropDownList();
            return View();
        }

        // POST: Gastos/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Valor,Fecha,TipoGasto")] Gastos gastos,int TipoGasto)
        {
            ModelState.Remove("TipoGasto.name");
            if (ModelState.IsValid)
            {
                gastos.TipoGasto = GetTipoGasto(TipoGasto);
                _context.Add(gastos);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            PopulateDepartmentsDropDownList(TipoGasto);
            return View(gastos);
        }

        public TipoGastos GetTipoGasto(int id)
        {
            return _context.TipoGastos.FirstOrDefault(x => x.Id == id);
        }

        // GET: Gastos/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastos = _context.Gastos.Include(x => x.TipoGasto)
                .AsNoTracking().FirstOrDefault(x=> x.Id == id);
            if (gastos == null)
            {
                return NotFound();
            }
            PopulateDepartmentsDropDownList(gastos.TipoGasto.Id);
            return View(gastos);
        }

        // POST: Gastos/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,Valor,Fecha,TipoGasto")] Gastos gastos, int TipoGasto)
        {
            if (id != gastos.Id)
            {
                return NotFound();
            }
            
            ModelState.Remove("TipoGasto");
            ModelState.Remove("TipoGasto.name");
            if (ModelState.IsValid)
            {
                try
                {
                    gastos.TipoGasto = GetTipoGasto(TipoGasto);
                    _context.Update(gastos);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!GastosExists(gastos.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                PopulateDepartmentsDropDownList(TipoGasto);
                return RedirectToAction(nameof(Index));
            }
            PopulateDepartmentsDropDownList(TipoGasto);
            return View(gastos);
        }

        // GET: Gastos/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var gastos = await _context.Gastos
                .Include(x => x.TipoGasto)
                .AsNoTracking()
                .FirstOrDefaultAsync(m => m.Id == id);
            if (gastos == null)
            {
                return NotFound();
            }

            return View(gastos);
        }

        // POST: Gastos/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var gastos = await _context.Gastos.FindAsync(id);
            if (gastos != null)
            {
                _context.Gastos.Remove(gastos);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool GastosExists(int id)
        {
            return _context.Gastos.Any(e => e.Id == id);
        }

        private void PopulateDepartmentsDropDownList(object selectedTipoGasto = null)
        {
            var departmentsQuery = from d in _context.TipoGastos
                                   orderby d.Name
                                   select d;
            ViewBag.TipoGastoID = new SelectList(departmentsQuery.AsNoTracking(), "Id", "Name", selectedTipoGasto);
        }
    }
}
