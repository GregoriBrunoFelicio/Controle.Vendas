namespace Controle.Vendas.Api.Models
{
    public class Produto
    {
        public int Id { get; set; }
        public string Nome { get; set; } = default!;
        public decimal Preco { get; set; }
    }
}
