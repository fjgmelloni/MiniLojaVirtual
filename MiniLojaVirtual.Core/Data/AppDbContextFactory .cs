using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Design;
using MiniLojaVirtual.Core.Data;

namespace MiniLojaVirtual.Core.Data
{
    public class AppDbContextFactory : IDesignTimeDbContextFactory<ApplicationDbContext>
    {
        public ApplicationDbContext CreateDbContext(string[] args)
        {
            var optionsBuilder = new DbContextOptionsBuilder<ApplicationDbContext>();
            optionsBuilder.UseSqlite("Data Source=../MiniLojaVirtual.Core/loja.db");

            return new ApplicationDbContext(optionsBuilder.Options);
        }
    }
}
