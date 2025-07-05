using Microsoft.EntityFrameworkCore;
using ZapateriaAres.API.Models;

namespace ZapateriaAres.API.Data
{
    public class ZapateriaContext : DbContext
    {
        public ZapateriaContext(DbContextOptions<ZapateriaContext> options) : base(options)
        {
        }

        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Producto> Productos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configurar la relación entre Producto y Categoria
            modelBuilder.Entity<Producto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Productos)
                .HasForeignKey(p => p.CategoriaId);

            // Configurar propiedades
            modelBuilder.Entity<Producto>()
                .Property(p => p.Precio)
                .HasPrecision(10, 2);

            modelBuilder.Entity<Categoria>()
                .Property(c => c.Nombre)
                .HasMaxLength(100);

            modelBuilder.Entity<Producto>()
                .Property(p => p.Nombre)
                .HasMaxLength(100);
        }
    }
}