using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities.Gastos
{
    public class Gastos
    {
        public int Id { get; set; }
        public TipoGastos TipoGasto { get; set; } = new TipoGastos();
        public int Valor { get; set; }
        public DateTime Fecha { get; set; }
    }
}
