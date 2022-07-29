namespace Controle.Vendas.Api.Models
{
    public class Compra: Entity
    {
        public DateTime Data { get; set; }

        public virtual Produto Produto { get; set; }
        public virtual Conta Conta { get; set; }
    }
}
