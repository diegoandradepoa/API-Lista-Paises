using ListaDePaises.API.Entities;
using ListaDePaises.API.Models;
using Microsoft.EntityFrameworkCore;

namespace ListaDePaises.API.Persistence
{
    public class PaisesDbContext : DbContext
    {
        // Construtor
        public PaisesDbContext(DbContextOptions<PaisesDbContext> options) 
            : base(options) 
        {
        }
        // Definicao das tabelas
        public DbSet<Paises> Paises { get; set; }

        // Definicao da chave primária
        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.Entity<Paises>(e =>
            {
                e.HasKey(s => s.Id);
            });
        }
    }
}
