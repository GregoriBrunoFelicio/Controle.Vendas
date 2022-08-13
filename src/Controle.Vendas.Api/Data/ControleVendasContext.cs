using Controle.Vendas.Api.Entidades;
using Controle.Vendas.Api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Controle.Vendas.Api.Data
{
    public class ControleVendasContext : DbContext
    {
        public virtual DbSet<Cliente> Cliente { get; set; }
        public virtual DbSet<Compra> Compra { get; set; }
        public virtual DbSet<Produto> Produto { get; set; }
        public virtual DbSet<TipoCliente> TipoCliente { get; set; }

        public ControleVendasContext(DbContextOptions dbContextOptions) : base(dbContextOptions)
        {
        }
    }
}
