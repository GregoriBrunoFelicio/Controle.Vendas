namespace Controle.Vendas.Api.Entities
{
    public class Compra : Entity
    {
        public DateTime Data { get; set; }
        public virtual int ClienteId { get; set; }
        public virtual Cliente Cliente { get; set; } = null!;
        public virtual int ProdutoId { get; set; }
        public virtual Produto Produto { get; set; } = null!;
    }
}
