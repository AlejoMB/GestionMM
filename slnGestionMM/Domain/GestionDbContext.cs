using Domain.Entities.Authorization;
using Domain.Entities.Inventario;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        }
    }
}
