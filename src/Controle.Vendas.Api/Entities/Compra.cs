using Controle.Vendas.Api.Entidades;

namespace Controle.Vendas.Api.Entidades
{
    public class Compra : Entity
    {
        public DateTime Data { get; set; }
        public virtual int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; }
        public virtual int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; }
    }
}
