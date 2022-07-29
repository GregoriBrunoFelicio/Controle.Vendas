using Controle.Vendas.Api.Models;

namespace Controle.Vendas.Api.Data.Repositories
{
    public interface IContaRepository: IRepository<Conta>
    {
    }

    public class ContaRepository : Repository<Conta>, IContaRepository
    {
        public ContaRepository(ControleVendasContext context) : base(context)
        {
        }
    }
}
