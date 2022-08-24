using Controle.Vendas.Api.Entidades;
using Microsoft.EntityFrameworkCore;

namespace Controle.Vendas.Api.Data.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        public Task<IEnumerable<Cliente>> ObterComCompras();
        public Task<IEnumerable<Cliente>> ObterTodos();
    }

    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ControleVendasContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cliente>> ObterComCompras()
        {
            return await _dbSet
                .Include(x => x.Compras).ThenInclude(x => x.Produto)
                .Include(x => x.TipoCliente)
                .ToListAsync();
        }

        public async Task<IEnumerable<Cliente>> ObterTodos() => await _dbSet
                .Include(x => x.Compras).ThenInclude(x => x.Produto)
                .Include(x => x.TipoCliente)
                .ToListAsync();
    }
}
