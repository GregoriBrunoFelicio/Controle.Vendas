namespace Controle.Vendas.Api.Models
{
    public class Cliente
    {
        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public string Sobrenome { get; set; } = default!;

        public virtual TipoCliente TipoCliente { get; set; }
        public virtual Conta Conta { get; set; }
    }
}
