using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore; // Necessário para .Migrate()
using MiniLojaVirtual.Core.Data;
using MiniLojaVirtual.Core.Models;
using System;
using System.Linq;

namespace MiniLojaVirtual.Core.Data
{
    public static class DbInitializer
    {
        public static void Initialize(ApplicationDbContext context, UserManager<IdentityUser> userManager)
        {
            context.Database.Migrate();

            if (!context.Categorias.Any())
            {
                context.Categorias.AddRange(new[]
                {
                    new Categoria { Nome = "Eletrônicos", Descricao = "Produtos eletrônicos" },
                    new Categoria { Nome = "Roupas", Descricao = "Vestuário e acessórios" },
                    new Categoria { Nome = "Livros", Descricao = "Livros e literatura" }
                });
                context.SaveChanges();
            }

            if (!context.Vendedores.Any())
            {
                context.Vendedores.Add(new Vendedor
                {
                    Id = "seed-admin",
                    Nome = "Admin",
                    Email = "admin@admin.com",
                    Telefone = "9999-9999"
                });
                context.SaveChanges();
            }

            if (!context.Produtos.Any())
            {
                var categoria = context.Categorias.First();
                var vendedor = context.Vendedores.First();
                context.Produtos.Add(new Produto
                {
                    Nome = "Notebook",
                    Descricao = "Notebook de última geração",
                    Preco = 3500,
                    CategoriaId = categoria.Id,
                    VendedorId = vendedor.Id,
                    ImagemUrl = "/img/notebook.jpg"
                });
                context.SaveChanges();
            }

            // Criação de usuário de login com IdentityUser
            if (userManager.FindByEmailAsync("felicio@felicio.com").Result == null)
            {
                var user = new IdentityUser
                {
                    Id = "seed-admin", // <--- garante ligação com Vendedor
                    UserName = "felicio@felicio.com",
                    Email = "felicio@felicio.com",
                    EmailConfirmed = true
                };

                var result = userManager.CreateAsync(user, "Felicio#12").Result;

                if (!result.Succeeded)
                {
                    throw new Exception("Erro ao criar usuário: " + string.Join(", ", result.Errors.Select(e => e.Description)));
                }
            }
        }
    }
}
