using Controle.Vendas.Api.Models;

namespace Controle.Vendas.Api.Data.Repositories
{
    public interface IClienteRepository: IRepository<Cliente>
    {
    }

    public class ClienteRepository : Repository<Cliente>, IClienteRepository
    {
        public ClienteRepository(ControleVendasContext context) : base(context)
        {
        }
    }
}
