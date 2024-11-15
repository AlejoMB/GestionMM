using OfficeOpenXml.Style;
using OfficeOpenXml;
using Domain;
using Domain.Entities.Authorization;
using Domain.Entities.Compras;
using Microsoft.EntityFrameworkCore;
using Domain.Entities.Inventario;
using Microsoft.IdentityModel.Tokens;

namespace CargarPrecios
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Proceso de carga INICIADO!");
            Console.WriteLine("");
            Console.WriteLine("");
            string filePath = @"C:\Datos\Correcciones_Octubre2.xlsx";
            var _dbContext = new GestionDbContext("Data Source=SQL8006.site4now.net;Initial Catalog=db_aa9b9c_gestionmm;User Id=db_aa9b9c_gestionmm_admin;Password=Nacional1.");
            ActualizarExistencias(filePath, _dbContext);
            Console.WriteLine("");
            Console.WriteLine("");
        }

        public static void CargarPrecios(string filePath, GestionDbContext _dbContext)
        {
            
            // Ensure the EPPlus license is set
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Open the Excel package
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                // Get the first worksheet in the workbook
                for(int i = 0; i < 21; i++) 
                { 
                    var worksheet = package.Workbook.Worksheets[i];

                    Console.WriteLine("");
                    Console.WriteLine("************************************************************");
                    Console.WriteLine((i + 1) + " - Pestaña: " + worksheet.Name);
                    Console.WriteLine("************************************************************");
                    Console.WriteLine("");

                    int totalRows = worksheet.Dimension.Rows;

                    var compraEncab = CrearCompra(_dbContext);

                    int totalCompra = 0;
                
                    for (int row = 1; row <= totalRows; row++)
                    {
                        if(row == 1)
                        {
                            continue;
                        }

                        var comprasDetalle = new ComprasDetalle();

                        try
                        {

                            string mediaText = worksheet.Cells[row, 1].Text;
                            string cantText = worksheet.Cells[row, 2].Text;
                            string precioText = worksheet.Cells[row, 3].Text;


                            if (cantText.Trim() == "0")
                            {
                                Console.WriteLine($"Fila {row}: Media={mediaText}, Media No procesada, cantidad 0");
                                SetExcelMessage(worksheet, row, 4, $"Media={mediaText}, Media No procesada, cantidad 0");
                                continue;
                            }else if (string.IsNullOrEmpty(mediaText) || string.IsNullOrEmpty(cantText) || string.IsNullOrEmpty(cantText))
                            {
                                Console.WriteLine($"Fila {row}: Sin información");
                                SetExcelMessage(worksheet, row, 4, $"Fila {row}: Sin información");
                                continue;
                            }

                            int codigoMedia = Int32.Parse(mediaText);
                            int cantidad = Int32.Parse(cantText);
                            int precio = Int32.Parse(precioText);

                            var media = _dbContext.Medias.FirstOrDefault(m => m.Id == codigoMedia);
                            if(media == null)
                            {
                                Console.WriteLine($"Fila {row}: Codigo de Media no existente");
                                SetExcelMessage(worksheet, row, 4, $"Fila {row}: Codigo de Media no existente");
                                continue;
                            }
                            comprasDetalle = new ComprasDetalle()
                            {
                                Media = media,
                                CostoUnitario = precio,
                                Cantidad = cantidad,
                                Total = cantidad * precio,
                            };

                            totalCompra += comprasDetalle.Total;

                            compraEncab.ComprasDetalle.Add(comprasDetalle);
                            AddExistencia(_dbContext, media, comprasDetalle.Cantidad);
                            Console.WriteLine($"Fila {row}: Media={codigoMedia}, Compra Creada");
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine($"Fila {row}: Error: {ex.Message}");
                            var cell = worksheet.Cells[row, 1];
                            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
                            cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
                        }
                    }

                
                    SetExcelMessage(worksheet, totalRows + 2, 1, "PESTAÑA PROCESADA CON EXITO");



                    package.Save();

                    _dbContext.ComprasEnc.Add(compraEncab);
                    _dbContext.SaveChanges();
                }

                
                
            }

            Console.WriteLine("");
            Console.WriteLine("********************************************");
            Console.WriteLine("PROCESO FINALIZADO");
            Console.WriteLine("********************************************");
            Console.WriteLine("");
        }

        public static void ActualizarExistencias(string filePath, GestionDbContext _dbContext)
        {
            // Ensure the EPPlus license is set
            ExcelPackage.LicenseContext = LicenseContext.NonCommercial;

            // Open the Excel package
            using (var package = new ExcelPackage(new FileInfo(filePath)))
            {
                var worksheet = package.Workbook.Worksheets[0];
                int totalRows = worksheet.Dimension.Rows;

                for (int row = 1; row <= totalRows; row++)
                {
                    if (row == 1)
                    {
                        continue;
                    }

                    string strCodigoMedia = worksheet.Cells[row, 2].Text;
                    string strCantidad = worksheet.Cells[row, 3].Text;
                    int cantidad = 0;

                    bool esEntero = int.TryParse(strCantidad,out cantidad);
                    int codigoMedia = int.Parse(strCodigoMedia);
                    if(esEntero)
                    {
                        var existencia = _dbContext.Existencias.FirstOrDefault(m => m.MediaRef == codigoMedia);
                        if(existencia != null && existencia.CantidadProducto != cantidad)
                        {
                            existencia.CantidadProducto = cantidad;
                            _dbContext.Existencias.Update(existencia);
                            Console.WriteLine($"Fila {row}: CodMedia={codigoMedia}, procesada, cantidad: {cantidad}");
                        }

                        if(existencia == null)
                        {
                            Console.WriteLine($"Fila {row}: CodMedia={codigoMedia}, Existencia no creada");
                        }
                        
                    }
                }

                _dbContext.SaveChanges();
            }
        }

        public static void SetExcelMessage(ExcelWorksheet pestaña, int row, int column, string message)
        {
            var cell = pestaña.Cells[row, column];
            cell.Style.Fill.PatternType = ExcelFillStyle.Solid;
            cell.Style.Fill.BackgroundColor.SetColor(System.Drawing.Color.Red);
            cell.Value = message;
        }

        public static ComprasEnc CrearCompra(GestionDbContext _dbContext)
        {
            var compraEncab = new ComprasEnc()
            {
                Proveedor = _dbContext.Proveedores.FirstOrDefault(p => p.Id == 4),
                MedioPago = _dbContext.MedioPago.FirstOrDefault(m => m.Id == 1),
                FechaPago = DateTime.Now,
                Pagado = true,
                //Total = model.Total,
                FechaCreado = DateTime.Now,
                CreadoPorUser = "02174cf0–9412–4cfe - afbf - 59f706d72cf6"
            };

            return compraEncab;
        }

        public static void AddExistencia(GestionDbContext _dbContext, Media media, int cantidad)
        {
            var existencia = _dbContext.Existencias.FirstOrDefault(e => e.MediaRef == media.Id);
            if (existencia == null)
            {
                _dbContext.Existencias.Add(new Existencias
                {
                    MediaRef = media.Id,
                    CantidadProducto = cantidad

                });
            }
            else
            {
                existencia.CantidadProducto += cantidad;
                _dbContext.Existencias.Update(existencia);
            }
        }
    }
}
