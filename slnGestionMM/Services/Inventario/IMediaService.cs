using Domain.Entities.Inventario;
using Domain.Models.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Inventario
{
    public interface IMediaService
    {
        IQueryable<Media> SearchMedia(AddProductoModel searchModel);
    }
}
