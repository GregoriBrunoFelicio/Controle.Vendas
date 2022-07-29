namespace Controle.Vendas.Api.Models
{
    public class Conta: Entity
    {
        public decimal Total => Compras.Sum(x => x.Produto.Preco);
        public bool Pago { get; set; }

        public virtual IList<Compra> Compras { get; set; }
    }
}
