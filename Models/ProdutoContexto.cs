using Microsoft.EntityFrameworkCore;

namespace MvcEFCore.Models
{
    public class ProdutoContexto(DbContextOptions<ProdutoContexto> options) : DbContext(options)
    {
        public required DbSet<Produto> Produtos { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Produto>()
                .Property(p => p.Preco)
                .HasColumnType("decimal(18,2)");
        }
    }
}