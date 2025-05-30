using ApiWeb9.Models;
using Microsoft.EntityFrameworkCore;

namespace ApiWeb9.Data
{
    public class AppDbContext : DbContext
    {

        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<ProdutoModel> Produtos { get; set; }
    }
}
