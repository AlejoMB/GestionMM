using Domain.Entities.Inventario;
using Domain.Models;

namespace Web.Helpers
{
    public static class ViewHelpers
    {

        public static List<ColoresModel> CrearTablaColores(List<Color> colores)
        {
            var rowsColoresModel = new List<ColoresModel>();
            var contColores = 1;
            var rowColorModel = new ColoresModel();
            rowColorModel.Colores = new List<Color>();
            foreach (var color in colores)
            {
                if (contColores % 3 == 0)
                {
                    rowColorModel.Colores.Add(color);
                    rowsColoresModel.Add(rowColorModel);
                    rowColorModel = new ColoresModel();
                    rowColorModel.Colores = new List<Color>();
                }
                else
                {
                    rowColorModel.Colores.Add(color);
                }

                if (contColores == colores.Count() && contColores % 3 != 0)
                {
                    rowsColoresModel.Add(rowColorModel);
                }

                contColores++;
            }

            return rowsColoresModel;
        }

    }
}
