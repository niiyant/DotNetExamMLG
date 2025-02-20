using DotNetExam.Data.Models;
using DotNetExam.Entities.Models;
using Microsoft.EntityFrameworkCore;

namespace DotNetExam.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Cliente> Clientes { get; set; }
        public DbSet<Tienda> Tiendas { get; set; }
        public DbSet<Articulo> Articulos { get; set; }
        public DbSet<TiendaArticulo> TiendaArticulos { get; set; }
        public DbSet<ClienteArticulo> ClienteArticulos { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            // Configurar la relación muchos a muchos entre Tienda y Articulo
            modelBuilder.Entity<TiendaArticulo>()
                .HasKey(ta => new { ta.TiendaId, ta.ArticuloId });

            modelBuilder.Entity<TiendaArticulo>()
                .HasOne(ta => ta.Tienda)
                .WithMany(t => t.ArticulosEnTienda)
                .HasForeignKey(ta => ta.TiendaId);

            modelBuilder.Entity<TiendaArticulo>()
                .HasOne(ta => ta.Articulo)
                .WithMany(a => a.Tiendas)
                .HasForeignKey(ta => ta.ArticuloId);

            // Configurar la relación muchos a muchos entre Cliente y Articulo
            modelBuilder.Entity<ClienteArticulo>()
                .HasKey(ca => new { ca.ClienteId, ca.ArticuloId });

            modelBuilder.Entity<ClienteArticulo>()
                .HasOne(ca => ca.Cliente)
                .WithMany(c => c.Compras)
                .HasForeignKey(ca => ca.ClienteId);

            modelBuilder.Entity<ClienteArticulo>()
                .HasOne(ca => ca.Articulo)
                .WithMany(a => a.Compradores)
                .HasForeignKey(ca => ca.ArticuloId);

            modelBuilder.Entity<Articulo>()
                .Property(a => a.Precio)
                .HasPrecision(18, 2);
            var tienda1 = new Tienda { Id = 1, Sucursal = "Tienda A", Direccion = "Calle 123" };
            var tienda2 = new Tienda { Id = 2, Sucursal = "Tienda B", Direccion = "Avenida 456" };
            var articulo1 = new Articulo { Id = 1, Codigo = "ART001",Imagen = "https://http2.mlstatic.com/D_NQ_NP_869818-MLU77724314601_072024-O.webp", Descripcion = "Laptop", Precio = 1500.00m, Stock = 10 };
            var articulo2 = new Articulo { Id = 2, Codigo = "ART002", Imagen = "https://http2.mlstatic.com/D_NQ_NP_877416-CBT77139740446_062024-O.webp", Descripcion = "Smartphone", Precio = 800.00m, Stock = 20 };
            var articulo3 = new Articulo { Id = 3, Codigo = "ART003", Imagen = "https://http2.mlstatic.com/D_NQ_NP_709058-MLU78169795366_082024-O.webp", Descripcion = "Tablet", Precio = 400.00m, Stock = 15 };
            var articulo4 = new Articulo { Id = 4, Codigo = "ART004", Imagen = "https://http2.mlstatic.com/D_NQ_NP_886158-MLA46737528644_072021-O.webp", Descripcion = "Monitor", Precio = 250.00m, Stock = 25 };

            var tiendaArticulos = new List<TiendaArticulo>
            {
                new TiendaArticulo { TiendaId = 1, ArticuloId = 1, Fecha = DateTime.Now },
                new TiendaArticulo { TiendaId = 1, ArticuloId = 2, Fecha = DateTime.Now },
                new TiendaArticulo { TiendaId = 2, ArticuloId = 3, Fecha = DateTime.Now },
                new TiendaArticulo { TiendaId = 2, ArticuloId = 4, Fecha = DateTime.Now }
            };
            modelBuilder.Entity<Tienda>().HasData(tienda1, tienda2);
            modelBuilder.Entity<Articulo>().HasData(articulo1, articulo2, articulo3, articulo4);
            modelBuilder.Entity<TiendaArticulo>().HasData(tiendaArticulos);
        }
    }
}
