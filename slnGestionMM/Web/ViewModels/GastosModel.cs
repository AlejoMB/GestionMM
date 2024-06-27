using Domain.Entities.Gastos;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Web.ViewModels
{
    public class GastosModel
    {
        public int Id { get; set; }
        public int tipoGasto { get; set; }
        public List<SelectList> tipoGastos { get; set; }
        public int Valor { get; set; }
        public DateTime Fecha { get; set; }
    }
}
