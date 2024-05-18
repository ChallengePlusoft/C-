using beautyTech.Models;
using Microsoft.EntityFrameworkCore;

namespace beautyTech.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
        }
        public DbSet<Empresa> Empresa { get; set; }
        public DbSet<Produto> Produto { get; set; }

        public DbSet<Cliente> Cliente { get; set; }


    }
}
