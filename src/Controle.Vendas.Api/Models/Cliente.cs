namespace Controle.Vendas.Api.Models
{
    public class Cliente: Entity
    {
        public string Nome { get; set; } = default!;
        public string Sobrenome { get; set; } = default!;

        public virtual TipoCliente TipoCliente { get; set; }
        public virtual Conta Conta { get; set; }
    }
}
