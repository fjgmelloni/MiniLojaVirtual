using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using MiniLojaVirtual.Core.Models;

namespace MiniLojaVirtual.Core.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }

        public DbSet<Produto> Produtos { get; set; }
        public DbSet<Categoria> Categorias { get; set; }
        public DbSet<Vendedor> Vendedores { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            base.OnModelCreating(builder);

            builder.Entity<Vendedor>()
                .HasKey(v => v.Id);

            builder.Entity<Produto>()
                .Property(p => p.Preco).HasColumnType("decimal(18,2)");

            builder.Entity<Produto>()
                .HasOne(p => p.Categoria)
                .WithMany(c => c.Produtos)
                .HasForeignKey(p => p.CategoriaId);

            builder.Entity<Produto>()
                .HasOne<Vendedor>()
                .WithMany(v => v.Produtos)
                .HasForeignKey(p => p.VendedorId);
        }
    }
}
