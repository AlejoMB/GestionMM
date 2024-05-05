using Domain.Entities.Authorization;
using Domain.Entities.Compras;
using Domain.Entities.Facturacion;
using Domain.Entities.Inventario;
using Microsoft.EntityFrameworkCore;


namespace Domain
{
    public class GestionDbContext : DbContext
    {
        public GestionDbContext()
        {
        }

        public GestionDbContext(string connectionString) : base(GetOptions(connectionString))
        {
        }

        private static DbContextOptions GetOptions(string connectionString)
        {
            return SqlServerDbContextOptionsExtensions.UseSqlServer(new DbContextOptionsBuilder(), connectionString).Options;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                optionsBuilder.UseSqlServer("Data Source=localhost\\SQLEXPRESS;Initial Catalog=GestionMM; Integrated Security=true;TrustServerCertificate=True;");
            }
        }

        public GestionDbContext(DbContextOptions<GestionDbContext> options) : base(options)
        {
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Rol> Roles { get; set; }
        public DbSet<RolesUser> RolesUser { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Bodega> Bodegas { get; set; }
        public DbSet<Proveedor> Proveedores { get; set; }
        public DbSet<Tamano> Tamanos { get; set; }
        public DbSet<TipoMedia> TipoMedias { get; set; }
        public DbSet<Marca> Marcas { get; set; }
        public DbSet<Color> Colores { get; set; }
        public DbSet<Diseno> Disenos { get; set; }
        public DbSet<Segmento> Segmentos { get; set; }
        public DbSet<MediaColores> MediaColores { get; set; }
        public DbSet<MedioPago> MedioPago { get; set; }

        public DbSet<ComprasEnc> ComprasEnc { get; set; }
        public DbSet<ComprasDetalle> ComprasDetalle { get; set; }
        public DbSet<Clientes> Cliente { get; set; }
        public DbSet<TipoEnvios> TipoEnvio { get; set; }
        public DbSet<Transportadora> Transportadora { get; set; }
        

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Rol>().HasKey(x => x.Id);
            var rol = new Rol() { Id = 1, Name = "Administrador" };
            modelBuilder.Entity<Rol>().HasData(rol);
            modelBuilder.Entity<User>().HasData(
                new User
                {
                    Id = 1,
                    FirstName = "System",
                    LastName = "",
                    Username = "System",
                    Password = "System"
                }
            );
            modelBuilder.Entity<RolesUser>().HasData(new RolesUser { RolesUserId = 1, RolId = 1, UserId = 1 });

            modelBuilder.Entity<TipoMedia>().HasData(new TipoMedia { Id = 1, Name = "Deportivas" });
            modelBuilder.Entity<TipoMedia>().HasData(new TipoMedia { Id = 2, Name = "Calcetines" });
            modelBuilder.Entity<TipoMedia>().HasData(new TipoMedia { Id = 3, Name = "Mallas" });
            modelBuilder.Entity<TipoMedia>().HasData(new TipoMedia { Id = 4, Name = "Bucaneras" });
            modelBuilder.Entity<TipoMedia>().HasData(new TipoMedia { Id = 5, Name = "Calentadora" });
            modelBuilder.Entity<TipoMedia>().HasData(new TipoMedia { Id = 6, Name = "Compresoras" });
            modelBuilder.Entity<TipoMedia>().HasData(new TipoMedia { Id = 7, Name = "Dercoradas" });
            modelBuilder.Entity<TipoMedia>().HasData(new TipoMedia { Id = 8, Name = "Colegialas" });
            modelBuilder.Entity<TipoMedia>().HasData(new TipoMedia { Id = 9, Name = "Antideslizante" });

            modelBuilder.Entity<Tamano>().HasData(new Tamano { Id = 1, Name = "Larga" });
            modelBuilder.Entity<Tamano>().HasData(new Tamano { Id = 2, Name = "Tobillera" });
            modelBuilder.Entity<Tamano>().HasData(new Tamano { Id = 3, Name = "Canilleras" });
            modelBuilder.Entity<Tamano>().HasData(new Tamano { Id = 4, Name = "Tobilleras largas (2/4)" });
            modelBuilder.Entity<Tamano>().HasData(new Tamano { Id = 5, Name = "Talonera" });
            modelBuilder.Entity<Tamano>().HasData(new Tamano { Id = 6, Name = "3/4" });
            modelBuilder.Entity<Tamano>().HasData(new Tamano { Id = 7, Name = "Pantalon" });
            modelBuilder.Entity<Tamano>().HasData(new Tamano { Id = 8, Name = "Pernera" });
            modelBuilder.Entity<Tamano>().HasData(new Tamano { Id = 9, Name = "6-8" });
            modelBuilder.Entity<Tamano>().HasData(new Tamano { Id = 10, Name = "4-6" });
            modelBuilder.Entity<Tamano>().HasData(new Tamano { Id = 11, Name = "8-10" });
            modelBuilder.Entity<Tamano>().HasData(new Tamano { Id = 12, Name = "9-11" });

            modelBuilder.Entity<Marca>().HasData(new Marca { Id = 1, Name = "Nike" });
            modelBuilder.Entity<Marca>().HasData(new Marca { Id = 2, Name = "Adiddas" });
            modelBuilder.Entity<Marca>().HasData(new Marca { Id = 3, Name = "Puma" });
            modelBuilder.Entity<Marca>().HasData(new Marca { Id = 4, Name = "XPN" });
            modelBuilder.Entity<Marca>().HasData(new Marca { Id = 5, Name = "Jogo" });
            modelBuilder.Entity<Marca>().HasData(new Marca { Id = 6, Name = "Jordan" });
            modelBuilder.Entity<Marca>().HasData(new Marca { Id = 7, Name = "alo" });

            modelBuilder.Entity<Diseno>().HasData(new Diseno { Id = 1, Name = "Estampado" });
            modelBuilder.Entity<Diseno>().HasData(new Diseno { Id = 2, Name = "Jaspeado - Chispas" });
            modelBuilder.Entity<Diseno>().HasData(new Diseno { Id = 3, Name = "Jaspeado - Cuadros" });
            modelBuilder.Entity<Diseno>().HasData(new Diseno { Id = 4, Name = "Anti Resvalante" });
            modelBuilder.Entity<Diseno>().HasData(new Diseno { Id = 5, Name = "Patas Pollo" });
            modelBuilder.Entity<Diseno>().HasData(new Diseno { Id = 6, Name = "Importadas" });
            modelBuilder.Entity<Diseno>().HasData(new Diseno { Id = 7, Name = "Gala - Económicas" });
            modelBuilder.Entity<Diseno>().HasData(new Diseno { Id = 8, Name = "Gala - Importadas" });
            modelBuilder.Entity<Diseno>().HasData(new Diseno { Id = 9, Name = "Edu. Física - Económicas" });
            modelBuilder.Entity<Diseno>().HasData(new Diseno { Id = 10, Name = "Edu. Física - Importadas" });

            modelBuilder.Entity<Segmento>().HasData(new Segmento { Id = 1, Name = "Adultos" });
            modelBuilder.Entity<Segmento>().HasData(new Segmento { Id = 2, Name = "Niños" });

            modelBuilder.Entity<Color>().HasData(new Color { Id = 1, Name = "Blanco" , RgbColor = "#ffffff" });
            modelBuilder.Entity<Color>().HasData(new Color { Id = 2, Name = "Negro", RgbColor = "#000000" });
            modelBuilder.Entity<Color>().HasData(new Color { Id = 3, Name = "Rojo", RgbColor = "#FF0000" });
            modelBuilder.Entity<Color>().HasData(new Color { Id = 4, Name = "Beige", RgbColor = "#F3E5AB" });
            modelBuilder.Entity<Color>().HasData(new Color { Id = 5, Name = "Fucsia", RgbColor = "#E68FAC" });
            modelBuilder.Entity<Color>().HasData(new Color { Id = 6, Name = "Azul", RgbColor = "#0000ff" }); 
            modelBuilder.Entity<Color>().HasData(new Color { Id = 7, Name = "Amarillo", RgbColor = "#FFFF00" }); 
            modelBuilder.Entity<Color>().HasData(new Color { Id = 8, Name = "Verde", RgbColor = "#008000" });

            modelBuilder.Entity<TipoEnvios>().HasData(new TipoEnvios { Id = 1, Name = "Domicilio" });
            modelBuilder.Entity<TipoEnvios>().HasData(new TipoEnvios { Id = 2, Name = "Contra Entrega" });

            modelBuilder.Entity<Transportadora>().HasData(new Transportadora { Id = 1, Name = "Inter Rapidisimo" });

            modelBuilder.Entity<MedioPago>().HasData(new MedioPago { Id = 1, Name = "Efectivo" });
            modelBuilder.Entity<MedioPago>().HasData(new MedioPago { Id = 2, Name = "Transferencia" });
            modelBuilder.Entity<MedioPago>().HasData(new MedioPago { Id = 3, Name = "Transportadora" });

        }
    }
}

