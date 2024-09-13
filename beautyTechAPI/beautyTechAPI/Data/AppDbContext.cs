using Microsoft.EntityFrameworkCore;
using beautyTechAPI.Models;
namespace beautyTechAPI.Data
{
    public class AppDbContext: DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options)
        {
        }

        public DbSet<Empresa> Empresas { get; set; }
        public DbSet<Produto> Produtos { get; set; }

        public DbSet<Cliente> Clientes { get; set; }



    }
}
