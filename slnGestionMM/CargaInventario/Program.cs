using OfficeOpenXml.Style;
using OfficeOpenXml;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain;

namespace CargaInventario
{
    public class Program
    {
        static void Main(string[] args)
        {
            string filePath = @"C:\Datos\Inventario.xlsx";
            ProcessSpreadsheet(filePath);
        }

        public static void ProcessSpreadsheet(string filePath)
        {
            var context = new GestionDbContext();
            // Ensure the EPPlus license is set
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Open the Excel package
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                // Get the first worksheet in the workbook
                var worksheet = package.Workbook.Worksheets[0];

                // Get the total number of rows with data
                int totalRows = worksheet.Dimension.Rows;

                // Iterate through each row
                for (int row = 1; row <= totalRows; row++)
                {
                    // Read values from columns A, B, and C
                    string columnA = worksheet.Cells[row, 1].Text;
                    string columnB = worksheet.Cells[row, 2].Text;
                    string columnC = worksheet.Cells[row, 3].Text;

                    // Do something with the values (e.g., print them)
                    Console.WriteLine($"Row {row}: A={columnA}, B={columnB}, C={columnC}");

                    // Modify the background color of cell A1 as an example
                    var cell = worksheet.Cells[row, 1];
                    cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                    cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Yellow);
                }

                // Save changes to the file
                package.Save();
            }
        }
    }
}
