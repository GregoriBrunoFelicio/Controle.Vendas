using Controle.Vendas.Api.Entities;

namespace Controle.Vendas.Api.Data.Repositories
{
    public interface ICompraRepository: IRepository<Compra>
    {
    }

    public class CompraRepository : Repository<Compra>, ICompraRepository
    {
        public CompraRepository(ControleVendasContext context) : base(context)
        {
        }
    }
}
