using Domain;
using Domain.Entities.Inventario;
using Domain.Models.Inventario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks; 
namespace Services.Inventario
{
    public class MediaService : IMediaService
    {
        private readonly GestionDbContext _dbContext;

        public MediaService(GestionDbContext dbContext)
        {
            _dbContext = dbContext;
        }

        public IQueryable<Media> SearchMedia(AddProductoModel searchModel)
        {
            var query = _dbContext.Medias.Include(m => m.TipoMedia)
                .Include(m => m.Tamano)
                .Include(m => m.Marca)
                .Include(m => m.MediaColores)
                .Include(m => m.Diseno)
                .Include(m => m.Segmento).AsQueryable();

            if (searchModel.TipoMediaId != null)
            {
                query = query.Where(m => m.TipoMedia.Id == searchModel.TipoMediaId);
            }

            if (searchModel.TamanoId != null)
            {
                query = query.Where(m => m.Tamano.Id == searchModel.TamanoId);
            }

            if (searchModel.MarcaId != null)
            {
                query = query.Where(m => m.Marca.Id == searchModel.MarcaId);
            }

            if(searchModel.Colores != null && searchModel.Colores.Any())
            {
                query = query.Where(m => m.MediaColores.Any(mc => searchModel.Colores.Contains(mc.Color.Id)));
            }

            if (searchModel.DisenoId != null)
            {
                query = query.Where(m => m.Diseno.Id == searchModel.DisenoId);
            }

            if (searchModel.SegmentoId != null)
            {
                query = query.Where(m => m.Segmento.Id == searchModel.SegmentoId);
            }

            if (!string.IsNullOrEmpty(searchModel.Name))
            {
                query = query.Where(m => m.Name.Contains(searchModel.Name));
            }

            return query;
        }
    }
}
