using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Domain;
using Domain.Entities.Inventario;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using Web.Helpers;
using Domain.Models;
using System.Drawing;
using Web.ViewModels;

namespace Web.Controllers
{
    public class MediaController : Controller
    {
        private readonly GestionDbContext _context;
        private readonly IWebHostEnvironment _env;
        const string URLImages = "https://www.mediaslunas.com/imagenes/";
        public MediaController(GestionDbContext context, IWebHostEnvironment env)
        {
            _context = context;
            _env = env;
        }

        // GET: Media
        public async Task<IActionResult> Index(int? pageNumber)
        {
            int pageSize = 30;
            var medias = from m in _context.Medias
                         select m;

            //return View(await _context.Medias.ToListAsync());
            return View(await PaginatedList<Media>.CreateAsync(medias.AsNoTracking(), pageNumber ?? 1, pageSize));
        }

        [HttpPost]
        public async Task<IActionResult> Index(string codigoMedia)
        {
            int idMedia = Int32.Parse(codigoMedia);
            int pageSize = 30;
            var medias = from m in _context.Medias
                         where m.Id == idMedia
                         select m;

            //return View(await _context.Medias.ToListAsync());
            return View(await PaginatedList<Media>.CreateAsync(medias.AsNoTracking(), 1, pageSize));
        }

        // GET: Media/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Medias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        // GET: Media/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Media/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,Name,Imagen,EstaEnPromocion,CreadoPorUser,FechaCreado")] Media media)
        {
            if (ModelState.IsValid)
            {
                _context.Add(media);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            return View(media);
        }

        // GET: Media/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = _context.Medias
                                .Include(m => m.TipoMedia)
                                .Include(m => m.Tamano)
                                .Include(m => m.Marca)
                                .Include(m => m.Diseno)
                                .Include(m => m.Segmento)
                                .FirstOrDefault(m => m.Id == id);
            if (media == null)
            {
                return NotFound();
            }
            var model = new MediaModel
            {
                Id = media.Id,
                Name = media.Name,
                Imagen = media.Imagen,
                EstaEnPromocion = media.EstaEnPromocion,
                TiposMedias = new SelectList(_context.TipoMedias.ToList(), "Id", "Name"),
                TipoMedia = media.TipoMedia == null ? 0 : media.TipoMedia.Id,
                Tamanos = new SelectList(_context.Tamanos.ToList(), "Id", "Name"),
                Tamano = media.Tamano == null ? 0 : media.Tamano.Id,
                Marcas = new SelectList(_context.Marcas.ToList(), "Id", "Name"),
                Marca = media.Marca == null ? 0 : media.Marca.Id,
                Disenos = new SelectList(_context.Disenos.ToList(), "Id", "Name"),
                Diseno = media.Diseno == null? 0 : media.Diseno.Id,
                Segmentos = new SelectList(_context.Segmentos.ToList(), "Id", "Name"),
                Segmento = media.Segmento == null ? 0 : media.Segmento.Id,
                Colores = ViewHelpers.CrearTablaColores(_context.Colores.ToList()),
                ColoresSelected = _context.MediaColores.Include(m => m.Media).Include(m => m.Color).Where(m => m.Media.Id == media.Id).Select(m => m.Color.Id).ToList(),
            };

            return View(model);
        }

        // POST: Media/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [FromForm] MediaModel mediaModel/*int id, [Bind("Id,Name,Imagen,EstaEnPromocion,CreadoPorUser,FechaCreado")] Media media*/)
        {
            if (id != mediaModel.Id)
            {
                return NotFound();
            }

            
            try
            {
                var mediaSave = _context.Medias.Find(mediaModel.Id);
                mediaSave.Name = mediaModel.Name;
                mediaSave.EstaEnPromocion = mediaModel.EstaEnPromocion;

                mediaSave.TipoMedia = _context.TipoMedias.FirstOrDefault(m => m.Id == mediaModel.TipoMedia);
                mediaSave.Tamano = _context.Tamanos.FirstOrDefault(m => m.Id == mediaModel.Tamano);
                mediaSave.Marca = _context.Marcas.FirstOrDefault(m => m.Id == mediaModel.Marca);
                mediaSave.Diseno = _context.Disenos.FirstOrDefault(m => m.Id == mediaModel.Diseno);
                mediaSave.Segmento = _context.Segmentos.FirstOrDefault(m => m.Id == mediaModel.Segmento);

                


                if (mediaModel.ColoresToSave != null)
                {
                    var coloresToDelete = _context.MediaColores.Include(c => c.Color).Where(m => m.Media.Id == mediaModel.Id);
                    _context.MediaColores.RemoveRange(coloresToDelete);

                    foreach (var color in mediaModel.ColoresToSave.Split(","))
                    {
                        int idColor = int.Parse(color);

                        var mediaColor = new MediaColores
                        {
                            Color = _context.Colores.FirstOrDefault(m => m.Id == idColor),
                            Media = mediaSave
                        };

                        _context.MediaColores.Add(mediaColor);
                    }
                }

                _context.Update(mediaSave);
                await _context.SaveChangesAsync();
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!MediaExists(mediaModel.Id))
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

        // GET: Media/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var media = await _context.Medias
                .FirstOrDefaultAsync(m => m.Id == id);
            if (media == null)
            {
                return NotFound();
            }

            return View(media);
        }

        // POST: Media/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var media = await _context.Medias.FindAsync(id);
            var coloresMedia = _context.MediaColores.Where(x => x.Media.Id == id);

            _context.MediaColores.RemoveRange(coloresMedia);

            if (media != null)
            {
                _context.Medias.Remove(media);
            }

            await _context.SaveChangesAsync();

            string filePath = GetFilePath(media.Name.Trim().Replace(" ", "_")) + "_" + media.Id + ".png";

            if (System.IO.File.Exists(filePath))
            {
                System.IO.File.Delete(filePath);
            }

            return RedirectToAction(nameof(Index));
        }

        private bool MediaExists(int id)
        {
            return _context.Medias.Any(e => e.Id == id);
        }

        public string GetFilePath(string productCode)
        {
            return _env.WebRootPath + "\\Imagenes\\" + productCode;
        }
    }
}
