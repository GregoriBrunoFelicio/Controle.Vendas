namespace Controle.Vendas.Api.Entidades
{
    public class Cliente : Entity
    {
        public string Nome { get; set; } = default!;
        public string Sobrenome { get; set; } = default!;
        public decimal TotalDivida => !Compras.Any() ? 0 : Compras.Sum(x => x.Produto.Preco);
        public virtual int TipoClienteId { get; set; }
        public virtual TipoCliente TipoCliente { get; set; }
        public virtual IEnumerable<Compra> Compras { get; set; }
    }
}
