using DotNetExam.Data.Models;
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
        }
    }
}
