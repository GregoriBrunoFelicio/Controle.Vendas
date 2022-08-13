using Controle.Vendas.Api.Entidades;

namespace Controle.Vendas.Api.Data.Repositories
{
    public interface IProdutoRepository: IRepository<Produto>
    {
    }

    public class ProdutoRepository : Repository<Produto>, IProdutoRepository
    {
        public ProdutoRepository(ControleVendasContext context) : base(context)
        {
        }
    }
}
