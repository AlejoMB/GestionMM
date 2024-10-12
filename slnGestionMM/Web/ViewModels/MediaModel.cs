using Domain.Entities.Inventario;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Domain.Models
{
    public class MediaModel
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Imagen { get; set; }
        public bool EstaEnPromocion { get; set; }
        public IEnumerable<SelectListItem> TiposMedias { get; set; }
        public int TipoMedia { get; set; }
        public IEnumerable<SelectListItem> Tamanos { get; set; }
        public int Tamano { get; set; }
        public IEnumerable<SelectListItem> Marcas { get; set; }
        public int Marca { get; set; }
        public IEnumerable<SelectListItem> Disenos { get; set; }
        public int Diseno { get; set; }
        public IEnumerable<SelectListItem> Segmentos { get; set; }
        public int Segmento { get; set; }
        public List<ColoresModel> Colores { get; set; }
        public List<int> ColoresSelected { get; set; }
        public string ColoresToSave { get; set; }

        /*TiposMedias = new SelectList(tiposMedias, "Id", "Name");
        Tamanos = new SelectList(tamanos, "Id", "Name");
        Marcas = new SelectList(marcas, "Id", "Name");
        RowsColores = ViewHelpers.CrearTablaColores(colores);
        Disenos = new SelectList(disenos, "Id", "Name");
        Segmentos = new SelectList(segmentos, "Id", "Name");*/
    }
}
