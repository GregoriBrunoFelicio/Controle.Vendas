namespace Controle.Vendas.Api.Entities
{
    public class Cliente : Entity
    {
        public string Nome { get; set; } = default!;
        public string Sobrenome { get; set; } = default!;
        public decimal TotalDivida => Compras != null && Compras.Any() ? Compras.Sum(x => x.Produto.Preco) : 0;
        public virtual int TipoClienteId { get; set; }
        public virtual TipoCliente TipoCliente { get; set; } = default!;
        public virtual IEnumerable<Compra>? Compras { get; set; }
        public bool Ativo { get; set; } = true;
    }
}
