namespace Controle.Vendas.Api.Models
{
    public class Cliente : Entity
    {
        public string Nome { get; set; } = default!;
        public string Sobrenome { get; set; } = default!;

        public virtual int TipoClienteId { get; set; }
        public virtual TipoCliente TipoCliente { get; set; }
        public virtual IEnumerable<Compra> Compras { get; set; }
    }
}
