using Controle.Vendas.Api.Entidades;
using Controle.Vendas.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Controle.Vendas.Api.Data
{
    public class ControleVendasContext : DbContext
    {
        public virtual DbSet<Cliente> Cliente { get; set; } = null!;
        public virtual DbSet<Compra> Compra { get; set; } = null!;
        public virtual DbSet<Produto> Produto { get; set; } = null!;
        public virtual DbSet<TipoCliente> TipoCliente { get; set; } = null!;

        public ControleVendasContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Cliente>().Navigation(x => x.Compras).AutoInclude();
            modelBuilder.Entity<Cliente>().Navigation(x => x.TipoCliente).AutoInclude();
            modelBuilder.Entity<Compra>().Navigation(x => x.Cliente).AutoInclude();
            modelBuilder.Entity<Compra>().Navigation(x => x.Produto).AutoInclude();
        }
    }
}
