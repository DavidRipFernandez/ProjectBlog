using BlogTecorp.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Emit;

namespace BlogTecorp.Infrastructure.Persistence.Contexts
{
    public class BlogTecorpContext : DbContext
    {
        public BlogTecorpContext(DbContextOptions<BlogTecorpContext> options) : base(options) { }

        public DbSet<Product> Products { get; set; }
        // Agregamos el DbSet de Clientes
        public DbSet<Cliente> Clientes { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // Configuración básica usando Fluent API
            modelBuilder.Entity<Cliente>(entity => {
                entity.HasKey(e => e.ClienteId);
                entity.Property(e => e.Name).IsRequired().HasMaxLength(150);
                entity.Property(e => e.Email).HasMaxLength(100);
            });

            // Configuración para Product (AQUÍ ESTÁ LA SOLUCIÓN A LA ADVERTENCIA)
            modelBuilder.Entity<Product>(entity => {
                entity.HasKey(e => e.ProductId);
                // Le decimos explícitamente que use 18 dígitos en total, y 2 para los decimales
                entity.Property(e => e.Price).HasPrecision(18, 2);
            });
        }
    }
}