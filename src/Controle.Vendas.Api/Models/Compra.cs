namespace Controle.Vendas.Api.Models
{
    public class Compra: Entity
    {
        public decimal? Total => Produtos.Sum(x => x.Preco);
        public bool Pago { get; set; }

        public virtual IList<Produto> Produtos { get; set; }
    }
}
