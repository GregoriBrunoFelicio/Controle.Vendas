using Controle.Vendas.Api.Entities;
using Microsoft.EntityFrameworkCore;

namespace Controle.Vendas.Api.Data.Repositories
{
    public interface IClienteRepository : IRepository<Cliente>
    {
        Task<IEnumerable<Cliente>> ObterComDividaAsync();
        Task InativarAsync(Cliente cliente);
        Task<Cliente?> ObterPorNomeAsync(string nome);
    }

    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ControleVendasContext context) : base(context)
        {
        }

        public async Task<IEnumerable<Cliente>> ObterComDividaAsync()
        {
            var clientesComDividas = await DbSet
                .AsNoTracking()
                .Where(x => x.Ativo && x.Compras!.Any())
                .ToListAsync();

            return clientesComDividas.OrderByDescending(x => x.TotalDivida);
        }
            

        public override async Task<IEnumerable<Cliente>> GetAllAsync() =>
            await DbSet
                .AsNoTracking()
                .Where(x => x.Ativo)
                .OrderBy(x => x.Nome)
                .ToListAsync();

        public async Task InativarAsync(Cliente cliente)
        {
            cliente.Ativo = false;
            await UpdateAsync(cliente);
        }

        public async Task<Cliente?> ObterPorNomeAsync(string nome) =>
            await DbSet.AsNoTracking()
                .FirstOrDefaultAsync(x => x.Nome == nome);
    }
}
