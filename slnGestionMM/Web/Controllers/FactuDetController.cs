using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Entities.Facturacion;
using Domain.Entities.Inventario;

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
            ejemploRedondeo();
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
        public IActionResult Create(int? id)
        {
            ViewBag.EncabezadoId = id;

            return View();
        }

        // POST: FactuDet/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,PrecioUnitario,Cantidad,Total,Media.Id")] FacturaDetalle facturaDetalle)
        {
            var idMedia = Int32.Parse(Request.Form["IdMedia"]);
            var idEncabezado = facturaDetalle.Id;

            var media = _context.Medias.Find(idMedia);
            var facturaEnc = _context.FacturaEnc.FirstOrDefault(f => f.Id == facturaDetalle.Id);

            //Detalle Nuevo
            facturaDetalle.Media = media;
            facturaDetalle.Encabezado = facturaEnc;
            facturaDetalle.Total = facturaDetalle.Cantidad * facturaDetalle.PrecioUnitario;
            facturaDetalle.Id = 0;
            _context.Add(facturaDetalle);

            //Actualizacion de Existencias
            var existenciaEntity = _context.Existencias.FirstOrDefault(e => e.MediaRef == facturaDetalle.Media.Id);
            existenciaEntity.CantidadProducto -= facturaDetalle.Cantidad;
            _context.Update(existenciaEntity);

            //Obtener totales de detalle
            var totalFactuEnc = _context.FacturaDetalle.Where(d => d.Encabezado.Id == idEncabezado).Sum(d => d.Total);
            facturaEnc.Total = totalFactuEnc + facturaDetalle.Total;

            await _context.SaveChangesAsync();
            ViewBag.IdMedia = media;

            //return RedirectToRoute( ("FactuDet", new { id = idMedia });

            return RedirectToRoute(new
            {
                controller = "FactuDet",
                action = "Index",
                id = idEncabezado
            });
            //return View(facturaDetalle);
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

            try
            {
                facturaDetalle = UpdateTotalsDetalleEncabezado(id, facturaDetalle.PrecioUnitario, facturaDetalle.Cantidad);
                //_context.Update(facturaDetalle);
                //await _context.SaveChangesAsync();
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
                
            
            return View(facturaDetalle);
        }


        public FacturaDetalle UpdateTotalsDetalleEncabezado(int id, int precioUnitario, int cantidad)
        {
            var facturaDetalle = _context.FacturaDetalle.Include(f => f.Encabezado).Include(f => f.Media).FirstOrDefault(f => f.Id == id);
            int idEncabezado = facturaDetalle.Encabezado.Id;

            int existencia = cantidad - facturaDetalle.Cantidad;

            facturaDetalle.Cantidad = cantidad;
            facturaDetalle.PrecioUnitario = precioUnitario;
            facturaDetalle.Total = precioUnitario * cantidad;

            var existenciaEntity = _context.Existencias.FirstOrDefault(e => e.MediaRef == facturaDetalle.Media.Id);
            existenciaEntity.CantidadProducto += existencia;

            _context.Update(existenciaEntity);

            _context.Update(facturaDetalle);
            _context.SaveChanges();
            

            var detalles = _context.FacturaDetalle.Where(f => f.Encabezado.Id == idEncabezado);
            int totalEnc = 0;
            foreach (var item in detalles)
            {
                totalEnc += item.Total;
            }

            var encabezado = _context.FacturaEnc.FirstOrDefault(f => f.Id == idEncabezado);
            if (encabezado != null)
            {
                encabezado.Total = totalEnc;
                _context.Update(encabezado);
                _context.SaveChangesAsync();
            }


            return facturaDetalle;
        }

        // GET: FactuDet/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var facturaDetalle = await _context.FacturaDetalle.Include(f => f.Encabezado)
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
            var facturaDetalle = _context.FacturaDetalle.Include(f => f.Encabezado).Include(f => f.Media).FirstOrDefault(f => f.Id == id);
            FacturaEnc facturaEnc = new FacturaEnc();
            if (facturaDetalle != null)
            {
                

                var existenciaEntity = _context.Existencias.FirstOrDefault(e => e.MediaRef == facturaDetalle.Media.Id);
                existenciaEntity.CantidadProducto += facturaDetalle.Cantidad;
                _context.Update(existenciaEntity);

                facturaEnc = _context.FacturaEnc.FirstOrDefault(f => f.Id == facturaDetalle.Encabezado.Id);
                facturaEnc.Total -= facturaDetalle.Total;
                _context.Update(facturaEnc);

                _context.FacturaDetalle.Remove(facturaDetalle);
            }

            await _context.SaveChangesAsync();
            return RedirectToRoute(new
            {
                controller = "FactuDet",
                action = "Index",
                id = facturaEnc.Id
            });
        }

        private bool FacturaDetalleExists(int id)
        {
            return _context.FacturaDetalle.Any(e => e.Id == id);
        }

        public void ejemploRedondeo()
        {
            int valorOriginal = 4300; // Ejemplo de valor original
            int valorFinal; // Variable para almacenar el valor final

            // Sumarle el 20% y redondear en base a las decenas
            int valorConIncremento = (int)Math.Round(valorOriginal * 1.30);
            int decenas = valorConIncremento % 100;

            if (decenas < 50)
            {
                valorFinal = valorConIncremento - decenas; // Redondear hacia abajo
            }
            else if (decenas == 50)
            {
                valorFinal = valorConIncremento; // Mantener igual si las decenas son 50
            }
            else
            {
                valorFinal = valorConIncremento + (100 - decenas); // Redondear hacia arriba
            }

            // Mostrar el valor final
            Console.WriteLine($"Valor original: {valorOriginal}");
            Console.WriteLine($"Valor final (con incremento y redondeo): {valorFinal}");
        }
    }
}
